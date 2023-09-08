using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // initial variables for dam
        public static double DStorage_10k = 0;                        // storage of the dam     (10^4 cm)  [7.08~142.50]
        public static double DStorage = 0;                            // storage of the dam     (cm)  [70800~1425000]     
        public static double DStorageVar = 0;                         // variance of the dam's storage
        public static double DWaterlevel = 271.92;                    // water level of the dam (M)          [270.9~274.5]
        public static double DInflow = 0;                             // inflow from upstream   (cms)*60s        [0~13000]
        public static double DOutflow = 0;                            // outflow  of the dam    (cms)*60s        [0~13000] [= G1Outflow + G2Outflow + G3Outflow ]
        public static double G1Outflow = 0;                           // outflow of gate1       (cms)*60s                           
        public static double G1Opening = 0;                           // opening of gate1       (m)       [0.0~8.0]
        public static int G1Status = 0;                               // status of gate1                  [0:still; 1:lifting; -1:closing]
        public static double G2Outflow = 0;                           // outflow of gate2       (cms)*60s                         
        public static double G2Opening = 0;                           // opening of gate2       (m)       [0.0~8.0]
        public static int G2Status = 0;                               // status of gate2                  [0:still; 1:lifting; -1:closing]
        public static double G3Outflow = 0;                           // outflow of gate3       (cms)*60s
        public static double G3Opening = 0;                           // opening of gate3       (m)       [0.0~8.0]
        public static int G3Status = 0;                               // status of gate3                  [0:still; 1:lifting; -1:closing]

        public static string InputData_Path = @"C:\Users\cans\source\repos\CANS_DAM_TESTBED\InputData\20180707_per10min.csv";
        public static string Storage_Path = @"C:\Users\cans\source\repos\CANS_DAM_TESTBED\InputData\storage.csv";
        public static string OutflowData_Path = @"C:\Users\cans\source\repos\CANS_DAM_TESTBED\InputData\outflow.csv";
        public static string[] InputDataTMP = System.IO.File.ReadAllLines(InputData_Path); // (date,INtot,OUTtot)
        public static string[] StorageDataTMP = System.IO.File.ReadAllLines(Storage_Path); // (waterlevel, storage)
        public static string[] OutflowDataTMP = System.IO.File.ReadAllLines(OutflowData_Path); // waterlevel vs opening
        public static double[,] InputData = new double[143,2];
        public static double[,] StorageData = new double[361,2];
        public static double[,] OutflowData = new double[51,161];

        public static int InputData_idx = 0;
        public static int InputData_length = 143;
        public static int InputData_counter = 0;
        public static int StorageData_idx = 0;
        // 由於紀錄的水位精準到小數第二位，而閘門流量表的水位刻度指精準到小數點第一位，因此270.00~270.09屬於270.0，而270.10開始要進到270.1的水位row。
        public static int OutflowData_ridx = 0; // 水壩目前所在的水位row (此row代表之水位 = 270.0 + 0.1 * OutflowData_ridx ，若超過，就要進到下一個水位row)
        public static int OutflowData_cidx1 = 0; // 閘門1 的目前所在開度column (目前開度 = 0.1 * OutflowData_cidx1 )
        public static int OutflowData_cidx2 = 0; // 閘門2 的目前所在開度column (目前開度 = 0.1 * OutflowData_cidx2 )
        public static int OutflowData_cidx3 = 0; // 閘門3 的目前所在開度column (目前開度 = 0.1 * OutflowData_cidx3 )
        public static string ShowData = "WaterLevel, Storage, StorageVar, TotInflow, TotOutflow, Status1, Opening1, Outflow1, Status2, Opening2, Outflow2, Status3, Opening3, Outflow3";


        private void EXIT_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Exit the App?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }// 退出APP
        private void LOAD_Click(object sender, EventArgs e)
        {                    
            // load the data
            int i = 0;
            int j = 0;
            
            foreach (string rows in InputDataTMP)
            {
                string[] columns = rows.Split(',');
                j = 0;
                foreach (string column in columns)
                {
                    InputData[i, j] = Convert.ToDouble(column);                    
                    j++;
                }
                i++;
            }//讀入Input
            i = 0;
            foreach (string rows in StorageDataTMP) 
            {
                string[] columns = rows.Split(',');
                j = 0;
                foreach (string column in columns)
                {
                    StorageData[i, j] = Convert.ToDouble(column);
                    j++;
                }
                i++;
            }// 讀入storage.csv
            i = 0;
            foreach (string rows in OutflowDataTMP)
            {
                string[] columns = rows.Split(',');
                j = 0;
                foreach (string column in columns)
                {
                    OutflowData[i, j] = Convert.ToDouble(column);
                    j++;
                }
                i++;
            }// 讀入Outflow.csv

            // 讀入水位與蓄水量(StorageData_idx一直上加直到該欄水位=初始水位)
            StorageData_idx = Convert.ToInt32((DWaterlevel - 270.9) * 100);
            DStorage = StorageData[StorageData_idx, 1] * 10000;

            // 初始化Inflow、Outflow和開度(目前水位四捨五入至小數點後第一位即為Outflow表中之水位)
            // inflow
            DInflow = InputData[0, 1];
            // 水位index
            OutflowData_ridx = Convert.ToInt32((Math.Round(DWaterlevel, 1) - 270) * 10);
            // 求目前單閘門開度(由第一筆流量，除以15個閘門，再除以600秒得到)
            double Outflow_0 = InputData[0, 1];
            // 閘門1初始開度index，最高80(8.0公尺)
            while((OutflowData_cidx1+1 <= 80) && (OutflowData[OutflowData_ridx, OutflowData_cidx1] < Outflow_0)) OutflowData_cidx1 += 1;

            if(OutflowData_cidx1 == 80)
            {
                Outflow_0 = Outflow_0 - OutflowData[OutflowData_ridx, 80]; // 減去Gate1已負荷的流量
                while ((OutflowData_cidx2 + 1 <= 80) && (OutflowData[OutflowData_ridx, OutflowData_cidx2] < Outflow_0))
                {
                    OutflowData_cidx2 += 1;
                }
            }// 檢查初始狀態是否需要開閘門2

            if (OutflowData_cidx2 == 80)
            {
                Outflow_0 = Outflow_0 - OutflowData[OutflowData_ridx, 80]; // 減去Gate2已負荷的流量
                while ((OutflowData_cidx3 + 1 <= 80) && (OutflowData[OutflowData_ridx, OutflowData_cidx3] < Outflow_0))
                {
                    OutflowData_cidx3 += 1;
                }
            }// 檢查初始狀態是否需要開閘門3

            //初始流量與開度
            G1Outflow = OutflowData[OutflowData_ridx, OutflowData_cidx1];
            G2Outflow = OutflowData[OutflowData_ridx, OutflowData_cidx2];
            G3Outflow = OutflowData[OutflowData_ridx, OutflowData_cidx3];
            DOutflow = G1Outflow + G2Outflow + G3Outflow;
            G1Opening = OutflowData_cidx1 * 0.1;
            G2Opening = OutflowData_cidx2 * 0.1;
            G3Opening = OutflowData_cidx3 * 0.1;

            // 初始容量差
            DStorageVar = DInflow - DOutflow;

            // 顯示各式資料於介面中
            INtot.Text = String.Format("{0:0.00}", DInflow);
            OUT1.Text = String.Format("{0:0.00}", G1Outflow);
            OP1.Text = String.Format("{0:0.0}", G1Opening);
            OUT2.Text = String.Format("{0:0.00}", G2Outflow);
            OP2.Text = String.Format("{0:0.0}", G2Opening);
            OUT3.Text = String.Format("{0:0.00}", G3Outflow);
            OP3.Text = String.Format("{0:0.0}", G3Opening);
            OUTtot.Text = String.Format("{0:0.00}", DOutflow);
            WATERLV.Text = DWaterlevel.ToString();
            STORAGE.Text = String.Format("{0:0.00}", (DStorage / 10000));
            STORAGEvar.Text = DStorageVar.ToString();

            // change buttons color.
            LOAD.BackColor = Color.Green;
            STOP.BackColor = Color.White;
        }// 讀取初始數據和csv檔
        private void RUN_Click(object sender, EventArgs e)
        {
            if (LOAD.BackColor == Color.Green)
            {
                Show.Text = ShowData + Environment.NewLine;
                // start the operation.
                Operate_timer.Start();
                // change buttons color.
                RUN.BackColor = Color.Green;
                STOP.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Please load the states fisrt.", "Error", MessageBoxButtons.OK);
            }
        }// 開始運作
        private void STOP_Click(object sender, EventArgs e)
        {
            // stop the operation.
            Operate_timer.Stop();
            // change buttons color.
            STOP.BackColor = Color.Red;
            LOAD.BackColor = Color.White;
            RUN.BackColor = Color.White;           
        }// 停止運作
        private void Clock_timer_Tick(object sender, EventArgs e)
        {
            // Set the caption to the current time
            var culture = new CultureInfo("en-US");
            CLOCK.Text = DateTime.Now.ToString(culture);
                       
        }// 每秒更新顯示時間
        private void Operate_timer_Tick(object sender, EventArgs e)
        {                                                      
            if (InputData_idx == InputData_length) // 運作的input全部吃完，運作任務執行完成。
            {
                MessageBox.Show("Operation is done.", "Notice", MessageBoxButtons.OK);
                Operate_timer.Stop();
            }

            // 更新inflow
            InputData_counter += 1;
            if (InputData_counter % 10 == 0) // input資料為10分鐘一筆，每10tick換一次input data
            {
                InputData_idx += 1;
            }
            DInflow = InputData[InputData_idx, 1];

            // 更新開度、流量、開閉狀態
            if (OutflowData_cidx1 >= 0 && OutflowData_cidx1 <= 80) G1Opening = OutflowData_cidx1 * 0.1;
            if (OutflowData_cidx2 >= 0 && OutflowData_cidx2 <= 80) G2Opening = OutflowData_cidx2 * 0.1;
            if (OutflowData_cidx3 >= 0 && OutflowData_cidx3 <= 80) G3Opening = OutflowData_cidx3 * 0.1;

            // 一個閘門代表實際五個閘門 (*5)
            // 一個tick代表1分鐘的模擬 (流出量單位為cms)            
            G1Outflow = OutflowData[OutflowData_ridx, OutflowData_cidx1];
            G2Outflow = OutflowData[OutflowData_ridx, OutflowData_cidx2]; 
            G3Outflow = OutflowData[OutflowData_ridx, OutflowData_cidx3];
            DOutflow = G1Outflow + G2Outflow + G3Outflow; // 一個tick模擬60秒

            // 更新容量差、蓄水量
            // 而注意流入流出單位皆為立方公尺/每秒，因此最後計算容量差和更新蓄水量還要除10000
            DStorageVar = Convert.ToDouble(String.Format("{0:0.00}", (DInflow - DOutflow)*60));
            DStorage += DStorageVar;
            DStorage_10k = Convert.ToDouble(String.Format("{0:0.00}", DStorage / 10000));

            // 更新Storage_idx、水位
            if (DWaterlevel >= 270.9 && DWaterlevel <= 274.5)
            {
                // 查看水位是否上修
                if (DStorageVar > 0) while (StorageData[StorageData_idx, 1] < DStorage_10k) StorageData_idx += 1;
                // 查看水位是否下修
                else if (DStorageVar < 0) while (StorageData[StorageData_idx, 1] > DStorage_10k) StorageData_idx -= 1;
                // 更新水位
                DWaterlevel = StorageData[StorageData_idx, 0];
            }
            else
            {
                if (DWaterlevel < 270.9 ) MessageBox.Show("水位低於合理值!", "Error", MessageBoxButtons.OK);
                else if (DWaterlevel > 274.5) MessageBox.Show("水位高於合理值!", "Error", MessageBoxButtons.OK);
                Operate_timer.Stop();
            }
            /*
            // 調整閘門
            if (DStorageVar < 0)
            {
                if (OutflowData_cidx1 > 0 && OutflowData_cidx1 <= 80)
                {
                    OutflowData_cidx1 -= 1;
                    G1Status = 2; // 下降
                }
                else if (OutflowData_cidx1 == 0)
                {
                    G1Status = 4; // 無法下降，已完全關閉
                }

                if (OutflowData_cidx2 > 0 && OutflowData_cidx2 <= 80)
                {
                    OutflowData_cidx2 -= 1;
                    G2Status = 2; // 下降
                }
                else if (OutflowData_cidx2 == 0)
                {
                    G2Status = 4; // 無法下降，已完全關閉
                }

                if (OutflowData_cidx3 > 0 && OutflowData_cidx3 <= 80)
                {
                    OutflowData_cidx3 -= 1;
                    G3Status = 2; // 下降
                }
                else if (OutflowData_cidx3 == 0)
                {
                    G3Status = 4; // 無法下降，已完全關閉
                }
            }
            else if (DStorageVar > 0)
            {
                if (OutflowData_cidx1 >= 0 && OutflowData_cidx1 < 80)
                {
                    OutflowData_cidx1 += 1;
                    G1Status = 1; // 上升
                }
                else if (OutflowData_cidx1 == 80)
                {
                    G1Status = 3; // 無法上升，已完全開啟
                }

                if (OutflowData_cidx2 >= 0 && OutflowData_cidx2 < 80)
                {
                    OutflowData_cidx2 += 1;
                    G2Status = 1; // 上升
                }
                else if (OutflowData_cidx2 == 80)
                {
                    G2Status = 3; // 無法上升，已完全開啟
                }

                if (OutflowData_cidx3 >= 0 && OutflowData_cidx3 < 80)
                {
                    OutflowData_cidx3 += 1;
                    G3Status = 1; // 上升
                }
                else if (OutflowData_cidx3 == 0)
                {
                    G3Status = 3; // 無法上升，已完全開啟
                }
            }
            else // DStorageVar = 0
            {
                G1Status = 0; // 靜止
                G2Status = 0; // 靜止
                G3Status = 0; // 靜止
            }*/
            // 顯示、輸出資料
            Show.Text += DWaterlevel.ToString() + ", " + DStorage.ToString() + ", " + DStorageVar.ToString() + ", " + DInflow.ToString() + ", " + DOutflow.ToString() + ", "
                         + G1Status.ToString() + ", " + G1Opening.ToString() + ", " + G1Outflow.ToString() + ", "
                         + G2Status.ToString() + ", " + G2Opening.ToString() + ", " + G2Outflow.ToString() + ", "
                         + G3Status.ToString() + ", " + G3Opening.ToString() + ", " + G3Outflow.ToString() + Environment.NewLine;

            // 顯示各式資料於介面中
            INtot.Text = String.Format("{0:0.00}", DInflow);
            OUT1.Text = String.Format("{0:0.00}", G1Outflow);
            OP1.Text = String.Format("{0:0.0}", G1Opening);
            OUT2.Text = String.Format("{0:0.00}", G2Outflow);
            OP2.Text = String.Format("{0:0.0}", G2Opening);
            OUT3.Text = String.Format("{0:0.00}", G3Outflow);
            OP3.Text = String.Format("{0:0.0}", G3Opening);
            OUTtot.Text = String.Format("{0:0.00}", DOutflow);
            WATERLV.Text = DWaterlevel.ToString();
            STORAGE.Text = String.Format("{0:0.00}", (DStorage / 10000));
            STORAGEvar.Text = DStorageVar.ToString();
            DataCounter.Text = InputData_counter.ToString();
            InputData_idx_counter.Text = InputData_idx.ToString();

        }// 每秒更新狀態
    }
}
