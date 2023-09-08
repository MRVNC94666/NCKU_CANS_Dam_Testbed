using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searching_App
{
    public partial class Form1 : Form
    {
        public string time1 = "t1";
        public string time2 = "t2";
        public string yyyy1 = "YYYY";
        public string mm1 = "MM";
        public string dd1 = "DD";
        public string hh1 = "hh";
        public string mmin1 = "mm";
        public string yyyy2 = "YYYY";
        public string mm2 = "MM";
        public string dd2 = "DD";
        public string hh2 = "hh";
        public string mmin2 = "mm";

        public Form1()
        {
            InitializeComponent();
        }

        //Exit
        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Exit the Searching App?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // 時間選取後取值 ( "yyyy1-mm1-dd1 hh1:mmin" ~ "yyyy2-mm2-dd2 hh2:mmin2" )
        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            yyyy1 = year1.SelectedItem.ToString();
            time1 = yyyy1 + "-" + mm1 + "-" + dd1 + " " + hh1 + ":" + mmin1; // 將完整的開始時間存入變數time1
            starttime.Text = time1; // 顯示當前選取開始時間
        }
        private void month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mm1 = month1.SelectedItem.ToString();
            time1 = yyyy1 + "-" + mm1 + "-" + dd1 + " " + hh1 + ":" + mmin1; // 將完整的開始時間存入變數time1
            starttime.Text = time1; // 顯示當前選取開始時間
        }
        private void day1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1 = day1.SelectedItem.ToString();
            time1 = yyyy1 + "-" + mm1 + "-" + dd1 + " " + hh1 + ":" + mmin1; // 將完整的開始時間存入變數time1
            starttime.Text = time1; // 顯示當前選取開始時間
        }
        private void hour1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hh1 = hour1.SelectedItem.ToString();
            time1 = yyyy1 + "-" + mm1 + "-" + dd1 + " " + hh1 + ":" + mmin1; // 將完整的開始時間存入變數time1
            starttime.Text = time1; // 顯示當前選取開始時間
        }
        private void min1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mmin1 = min1.SelectedItem.ToString();
            time1 = yyyy1 + "-" + mm1 + "-" + dd1 + " " + hh1 + ":" + mmin1; // 將完整的開始時間存入變數time1
            starttime.Text = time1; // 顯示當前選取開始時間
        }
        private void year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            yyyy2 = year2.SelectedItem.ToString();
            time2 = yyyy2 + "-" + mm2 + "-" + dd2 + " " + hh2 + ":" + mmin2; // 將完整的結束時間存入變數time2
            endtime.Text = time2; // 顯示當前選取結束時間
        }
        private void month2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mm2 = month2.SelectedItem.ToString();
            time2 = yyyy2 + "-" + mm2 + "-" + dd2 + " " + hh2 + ":" + mmin2; // 將完整的結束時間存入變數time2
            endtime.Text = time2; // 顯示當前選取結束時間
        }
        private void day2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd2 = day2.SelectedItem.ToString();
            time2 = yyyy2 + "-" + mm2 + "-" + dd2 + " " + hh2 + ":" + mmin2; // 將完整的結束時間存入變數time2
            endtime.Text = time2; // 顯示當前選取結束時間
        }
        private void hour2_SelectedIndexChanged(object sender, EventArgs e)
        {
            hh2 = hour2.SelectedItem.ToString();
            time2 = yyyy2 + "-" + mm2 + "-" + dd2 + " " + hh2 + ":" + mmin2; // 將完整的結束時間存入變數time2
            endtime.Text = time2; // 顯示當前選取結束時間
        }
        private void min2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mmin2 = min2.SelectedItem.ToString();
            time2 = yyyy2 + "-" + mm2 + "-" + dd2 + " " + hh2 + ":" + mmin2; // 將完整的結束時間存入變數time2
            endtime.Text = time2; // 顯示當前選取結束時間
        }

        private void Search_Click(object sender, EventArgs e)
        {
            // 連接SQL SERVER
            string strCon = "Data Source=127.0.0.1;Initial Catalog=CANSDamTestbedDB;Persist Security Info=True;User ID=sa;Password=cans92979";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = strCon;

            // open connection
            con.Open();

            // 下指令查詢tabel
            SqlCommand Query = new SqlCommand("select * from Dam_Status_Log where time between @time1 and @time2", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Query;
            da.SelectCommand.Parameters.AddWithValue("@time1", time1);
            da.SelectCommand.Parameters.AddWithValue("@time2", time2);

            // excute query & show table
            var reader = Query.ExecuteReader();

            DataTable showtable = new DataTable();
            showtable.Load(reader);
            this.dataGridView1.DataSource = showtable;

            // close connection
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
