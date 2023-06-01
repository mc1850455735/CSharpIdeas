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

        // 禁用窗体关闭按钮
        private const int CP_NOCLOSE_BUTTON = 0x200;
        // 重载属性以实现自定义窗体按钮
        protected override CreateParams CreateParams {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 添加日期, end_date as 截止日期, import_rank as 重要程度 from remind;";
            UpdataDataGridView(sql);
            UpdataInformations();
        }

        // 窗口启动时, 检查所有项目中剩余时间
        private void MainFrm_Load(object sender, EventArgs e)
        {
            // 将数据库中的remind对象存到list中
            List<Remind> remindList = new List<Remind>();

            string remind_title = "null";
            DateTime end_date = new DateTime();
            DateTime start_date = new DateTime();
            int import_rank = -1;
            try
            {
                mySqlConnection.Open();
                sql = "select * from remind;";
                mycomm.CommandText = sql;
                dr = mycomm.ExecuteReader();

                while (dr.Read())
                {
                    remind_title = dr["remind_title"].ToString();
                    import_rank = (int)dr["import_rank"];
                    start_date = DateTime.Parse(dr["remind_date"].ToString()) ;

                    if (dr["end_date"].ToString() != "")
                    {
                        end_date = DateTime.Parse(dr["end_date"].ToString());
                        remindList.Add(new Remind(remind_title, import_rank, start_date, end_date));
                    }
                    else
                    {
                        remindList.Add(new Remind(remind_title, import_rank, start_date));
                    }

                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            finally { mySqlConnection.Close(); }

            string result = "";
            remindList.Sort();
            for(int i = 0; i < remindList.Count; i++)
            {
                if (remindList[i].RestDay <= 3)
                    result += ("\n" + remindList[i].Title + "\t" + "剩余" +remindList[i].RestDay + "天");
            }

            if(result != "")
                MessageBox.Show("以下项目剩余时间已不足3天:" + result);
        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            UpdataDataGridView();
        }

        private void btnOrderTime_Click(object sender, EventArgs e)
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 添加日期, end_date as 截止日期, import_rank as 重要程度 from remind where end_date is not null order by end_date";
            UpdataDataGridView(sql);
        }

        private void btnOrderRank_Click(object sender, EventArgs e)
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 添加日期, end_date as 截止日期, import_rank as 重要程度 from remind order by import_rank desc";
            UpdataDataGridView(sql);
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = (int)dgvShow.Rows[dgvShow.SelectedCells[0].RowIndex].Cells["编号"].Value;
            UpdataInformations();
        }

        private void UpdataDataGridView()
        {
            sql = "select id as 编号, remind_title as 标题, remind_date as 添加日期, end_date as 截止日期, import_rank as 重要程度 from remind;";
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
            DateTime end_date = new DateTime();
            int import_rank = -1;
            bool isEndDateNull = false;

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
                    if(dr["end_date"].ToString() != "")
                        end_date = DateTime.Parse(dr["end_date"].ToString());
                    else 
                        isEndDateNull = true;
                }
            }
            catch(Exception ex ) { MessageBox.Show(ex.Message); }
            finally { mySqlConnection.Close(); }

            lblTitle.Text = remind_title;
            lblDate.Text = remind_date.ToString("d");
            lblRank.Text = import_rank.ToString();
            if (!isEndDateNull)
                lblEndDate.Text = end_date.ToString("d");
            else
                lblEndDate.Text = "null";
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
            if(MessageBox.Show("您是否要删除该记录","删除记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        private void tsmShow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }

    class Remind : IComparable<Remind>
    {
        private string title;
        private int rank;
        private DateTime start_date;
        private DateTime end_date;

        // 有截止日期
        private bool hasEnd;

        public string Title => title;

        public int RestDay
        {
            get { 
                if(hasEnd)
                    return (int)(end_date - DateTime.Now).TotalDays;
                else
                    return int.MaxValue;
            }
        }

        public Remind(string title, int rank, DateTime startDate)
        {
            this.title = title;
            this.rank = rank;
            this.start_date = startDate;
            hasEnd = false;
        }

        public Remind(string title, int rank, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.rank = rank;
            this.start_date = startDate;
            this.end_date = endDate;
            hasEnd= true;
        }

        public int CompareTo(Remind y)
        {
            return this.RestDay - y.RestDay;
        }
    }
}
