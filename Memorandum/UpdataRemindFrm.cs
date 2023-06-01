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
    public partial class UpdataRemindFrm : Form
    {
        readonly int id;
        string connString = @"Data Source = localhost; port=3306;Initial Catalog = Memorandum; uid=root;password=123456;Charset=utf8;SslMode=None";
        string sql;
        readonly MySqlConnection mySqlConnection;
        MySqlCommand mycomm;
        MySqlDataReader dr;

        bool hasEndDate = true;

        public UpdataRemindFrm(int id)
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection(connString);
            mycomm = new MySqlCommand();
            mycomm.Connection = mySqlConnection;
            this.id = id;
            this.Text = id.ToString();
        }

        private void UpdataRemindFrm_Load(object sender, EventArgs e)
        {
            sql = string.Format("select * from remind where id = {0};", id);

            try
            {
                mySqlConnection.Open();

                mycomm.CommandText = sql;
                dr = mycomm.ExecuteReader();

                while (dr.Read())
                {
                    txtMain.Text = dr["remind_main"].ToString();
                    txtTitle.Text = dr["remind_title"].ToString();
                    numRank.Value = (int)dr["import_rank"];
                    if (dr["end_date"].ToString() != "")
                        rdbHasEndDate.Checked = true;
                    else 
                        rdbHasntEndDate.Checked = true;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { mySqlConnection.Close(); }
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string end_date;
            string remind_main = txtMain.Text;
            string remind_title = txtTitle.Text;
            if (hasEndDate)
                end_date = "'" + mcEndDate.SelectionEnd.ToString("d") + "'";
            else
                end_date = "null";
            int import_rank = (int)numRank.Value;

            sql = string.Format("update remind set remind_title = '{0}', remind_main = '{1}', import_rank = {2}, end_date = {3} where id = {4}",
                remind_title, remind_main, import_rank, end_date ,id);

            try
            {
                mySqlConnection.Open();

                mycomm.CommandText = sql;
                mycomm.ExecuteNonQuery();

                MessageBox.Show("您的数据已经更新成功", "更新成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { mySqlConnection.Close(); }

            this.Close();
        }

        private void rdbHasEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbHasEndDate.Checked)
            {
                hasEndDate = true;
                mcEndDate.Enabled = true;
            }
            else if(rdbHasntEndDate.Checked)
            {
                hasEndDate = false;
                mcEndDate.Enabled = false;
            }
        }
    }


}
