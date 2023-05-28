using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharpIdeas.Memorandum
{
    public partial class MainFrm : Form
    {
        int selectedId;

        string connString = @"Data Source = localhost; port=3306;Initial Catalog = Memorandum; uid=root;password=123456;Charset=utf8;SslMode=None";
        string sql;
        readonly MySqlConnection mySqlConnection;
        MySqlCommand mycomm;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataSet ds;
        
        public MainFrm()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection(connString);
            ds = new DataSet();
            mycomm = new MySqlCommand();
            mycomm.Connection = mySqlConnection;
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 日期, import_rank as 重要程度 from remind;";
            UpdataDataGridView(sql);
            UpdataInformations();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            UpdataDataGridView();
        }

        private void btnOrderTime_Click(object sender, EventArgs e)
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 日期, import_rank as 重要程度 from remind order by remind_date";
            UpdataDataGridView(sql);
        }

        private void btnOrderRank_Click(object sender, EventArgs e)
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 日期, import_rank as 重要程度 from remind order by import_rank";
            UpdataDataGridView(sql);
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = (int)dgvShow.Rows[dgvShow.SelectedCells[0].RowIndex].Cells["编号"].Value;
            UpdataInformations();
        }

        private void UpdataDataGridView()
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 日期, import_rank as 重要程度 from remind;";
            UpdataDataGridView(sql);
        }

        private void UpdataDataGridView(string sql)
        {
            try
            {
                mySqlConnection.Open();

                adapter = new MySqlDataAdapter(sql, mySqlConnection);
                ds.Tables.Clear();
                adapter.Fill(ds);
                dgvShow.DataSource = ds.Tables[0];
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { mySqlConnection.Close(); }
        }

        private void UpdataInformations()
        {
            if(dgvShow.SelectedCells.Count == 0)
            {
                MessageBox.Show("目前没有记录", "提示");
                return;
            }
            string remind_main = "";
            string remind_title = "null";
            DateTime remind_date = new DateTime();
            int import_rank = -1;

            selectedId = (int)dgvShow.Rows[dgvShow.SelectedCells[0].RowIndex].Cells["编号"].Value;

            sql = string.Format("select * from remind where id = {0};", selectedId);

            try
            {
                mySqlConnection.Open();

                mycomm.CommandText = sql;
                dr = mycomm.ExecuteReader();

                while (dr.Read())
                {
                    remind_main = dr["remind_main"].ToString();
                    remind_title = dr["remind_title"].ToString();
                    remind_date = DateTime.Parse(dr["remind_date"].ToString());
                    import_rank = (int)dr["import_rank"];
                }
            }
            catch(Exception ex ) { MessageBox.Show(ex.Message); }
            finally { mySqlConnection.Close(); }

            lblTitle.Text = remind_title;
            lblDate.Text = remind_date.ToString("d");
            lblRank.Text = import_rank.ToString();
            rtxtMain.Text = remind_main;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddRemindFrm().ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new UpdataRemindFrm((int)dgvShow.Rows[dgvShow.SelectedCells[0].RowIndex].Cells["编号"].Value).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您是否要删除该记录") == DialogResult.OK)
            {
                try
                {
                    mySqlConnection.Open();

                    sql = string.Format("delete from remind where id = {0}", selectedId);

                    mycomm.CommandText = sql;
                    mycomm.ExecuteNonQuery();

                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
                finally { mySqlConnection.Close(); }
                UpdataDataGridView();

            }
        }

        private void MainFrm_Activated(object sender, EventArgs e)
        {
            UpdataDataGridView();
        }
    }
}
