using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpIdeas.Memorandum
{
    public partial class AddRemindFrm : Form
    {
        string connString = @"Data Source = localhost; port=3306;Initial Catalog = Memorandum; uid=root;password=123456;Charset=utf8;SslMode=None";
        string sql;
        readonly MySqlConnection mySqlConnection;
        MySqlCommand mycomm;

        public AddRemindFrm()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection(connString);
            mycomm = new MySqlCommand();
            mycomm.Connection = mySqlConnection;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string remind_main = txtMain.Text;
            string remind_title = txtTitle.Text;
            string remind_date = DateTime.Now.ToString("d");
            int import_rank = (int)numRank.Value;

            sql = string.Format("insert into remind (remind_title, remind_main, remind_date, import_rank) " +
                "values ('{0}', '{1}', '{2}', {3});", remind_title, remind_main, remind_date, import_rank);

            try
            {
                mySqlConnection.Open();

                mycomm.CommandText = sql;
                mycomm.ExecuteNonQuery();

                MessageBox.Show("您的数据已经添加成功", "添加成功");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { mySqlConnection.Close(); this.Close(); }
        }
    }
}
