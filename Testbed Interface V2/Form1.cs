using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
// using System.Drawing;

namespace Testbed_Interface_V2
{
    public partial class TestbedInterfaceV2 : Form
    {     
        // build modbus clients
        public static ModbusClient client1 = new ModbusClient();
        public static ModbusClient client2 = new ModbusClient();
        public static ModbusClient client3 = new ModbusClient();

        public TestbedInterfaceV2()
        {
            InitializeComponent();
        }
        // attributes

        // ip
        public static string G1ip = "192.168.1.6";
        public static string G2ip = "192.168.1.7";
        public static string G3ip = "192.168.1.7";

        // exit
        private void EXIT_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Exit the App?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        
        private void timerRead_Tick(object Sender, EventArgs e) // for displaying the current time & status
        {

            // Set the caption to the current time
            var culture = new CultureInfo("en-US");
            TIMER.Text = DateTime.Now.ToString(culture);

            // PLC1's status
            if (client1.Connected)
            {
                int[] PLC1Register_0_1 = client1.ReadHoldingRegisters(0, 1); // Read registers [0, 1] values
                string PLC1Status;

                // 把暫存器數值轉成二進位(字串)，並補0
                // 若第15號燈、也就是二進制的第一位為1，那讀進來會變負值，此時必須先+32768將他轉正，再轉成字串，而且補零時記得要把最左邊(第一位)改回'1'。          
                if (PLC1Register_0_1[0] < 0)
                {
                    PLC1Register_0_1[0] += 32768; // 回推 +32768
                    PLC1Status = "1" + Convert.ToString(PLC1Register_0_1[0], 2).PadLeft(15, '0'); // 轉字串，補0後再補一個1                           
                }
                else
                {
                    PLC1Status = Convert.ToString(PLC1Register_0_1[0], 2).PadLeft(16, '0'); // 轉字串，補零 
                }

                // 開始看字串改變燈號，[ 字串位置0 ~ 15 ] 對應 [ 燈號 DI_15~0 ]
                // 目前先以最笨if暴力解                
                if (PLC1Status.Substring(15, 1) == "1") Power1.BackColor = Color.Red; // DI_0 電源
                else Power1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(14, 1) == "1") OnSite1.BackColor = Color.Red; // DI_1 現場 
                else OnSite1.BackColor = Color.Gainsboro;                 
                if (PLC1Status.Substring(13, 1) == "1") Remote1.BackColor = Color.Red; // DI_2 遠方
                else Remote1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(12, 1) == "1") Up1.BackColor = Color.Red; // DI_3 上升 
                else Up1.BackColor = Color.Gainsboro;                 
                if (PLC1Status.Substring(11, 1) == "1") Down1.BackColor = Color.Red; // DI_4 下降
                else Down1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(10, 1) == "1") OpenAll1.BackColor = Color.Red; // DI_5 全開 
                else OpenAll1.BackColor = Color.Gainsboro;
                if (PLC1Status.Substring(9, 1) == "1") CloseAllEX1.BackColor = Color.Red; // DI_6 超全關 
                else CloseAllEX1.BackColor = Color.Gainsboro;                        
                if (PLC1Status.Substring(8, 1) == "1") OpenAllEX1.BackColor = Color.Red; // DI_7 超全開
                else OpenAllEX1.BackColor = Color.Gainsboro;              
                if (PLC1Status.Substring(7, 1) == "1") TorqueOff1.BackColor = Color.Red; // DI_8 關閉過扭力             
                else TorqueOff1.BackColor = Color.Gainsboro;                               
                if (PLC1Status.Substring(6, 1) == "1") EEEscape1.BackColor = Color.Red; // DI_9 3E逃脫             
                else EEEscape1.BackColor = Color.Gainsboro;               
                if (PLC1Status.Substring(5, 1) == "1") GateOverload1.BackColor = Color.Red; // DI_10 吊門機過載
                else GateOverload1.BackColor = Color.Gainsboro;
                if (PLC1Status.Substring(4, 1) == "1") MotorEscape1.BackColor = Color.Red; // DI_11 馬達過熱逃脫
                else MotorEscape1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(3, 1) == "1") EmergencyStop1.BackColor = Color.Red; // DI_12 緊急停止
                else EmergencyStop1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(2, 1) == "1") TorqueOn1.BackColor = Color.Red; // DI_13 開啟過扭力
                else TorqueOn1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(1, 1) == "1") Fault1.BackColor = Color.Red; // DI_14 接地故障
                else Fault1.BackColor = Color.Gainsboro;                
                if (PLC1Status.Substring(0, 1) == "1") CloseAll1.BackColor = Color.Red; //DI_15 全關
                else CloseAll1.BackColor = Color.Gainsboro;

                /* 接下來處理電壓、電流、開度 */
                /* Read registers [2, 10] [電壓前半, 電壓後半, 電流前半, 電流後半, 開度前半, 開度後半] */
                int[] PLC1Register_2_7 = client1.ReadHoldingRegisters(2, 7);
                int regInput1;

                /* 電壓 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string voltagestr1;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput1 = PLC1Register_2_7[1]; //電壓前半段
                if (Convert.ToString(regInput1 / 256, 2).Length <= 8) voltagestr1 = Convert.ToString(regInput1 / 256, 2).PadLeft(8, '0');
                else voltagestr1 = Convert.ToString(regInput1 / 256, 2).Substring(Convert.ToString(regInput1 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput1 % 256, 2).Length <= 8) voltagestr1 += Convert.ToString(regInput1 % 256, 2).PadLeft(8, '0');
                else voltagestr1 += Convert.ToString(regInput1 % 256, 2).Substring(Convert.ToString(regInput1 % 256, 2).Length - 8);
                
                regInput1 = PLC1Register_2_7[0]; //電壓後半段
                if (Convert.ToString(regInput1 / 256, 2).Length <= 8) voltagestr1 += Convert.ToString(regInput1 / 256, 2).PadLeft(8, '0');                
                else voltagestr1 += Convert.ToString(regInput1 / 256, 2).Substring(Convert.ToString(regInput1 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput1 % 256, 2).Length <= 8) voltagestr1 += Convert.ToString(regInput1 % 256, 2).PadLeft(8, '0');
                else voltagestr1 += Convert.ToString(regInput1 % 256, 2).Substring(Convert.ToString(regInput1 % 256, 2).Length - 8);
                
                int voltageuint1 = Convert.ToInt32(voltagestr1, 2); /* 把整理好的二進位字串轉成uint */
                float voltagefloat1 = BitConverter.ToSingle(BitConverter.GetBytes(voltageuint1), 0); /* 轉成浮點數 */
                double voltagedouble1 = Math.Round(Convert.ToDouble(voltagefloat1)); /* 轉成double四捨五入 */
                Voltage1.Text = voltagedouble1.ToString(); /* 顯示在HMI上 */

                /* 電流 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string currentstr1;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */

                regInput1 = PLC1Register_2_7[3]; //電流前半段
                if (Convert.ToString(regInput1 / 256, 2).Length <= 8) currentstr1 = Convert.ToString(regInput1 / 256, 2).PadLeft(8, '0');
                else currentstr1 = Convert.ToString(regInput1 / 256, 2).Substring(Convert.ToString(regInput1 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput1 % 256, 2).Length <= 8) currentstr1 += Convert.ToString(regInput1 % 256, 2).PadLeft(8, '0');
                else currentstr1 += Convert.ToString(regInput1 % 256, 2).Substring(Convert.ToString(regInput1 % 256, 2).Length - 8);
                
                regInput1 = PLC1Register_2_7[2]; //電流後半段
                if (Convert.ToString(regInput1 / 256, 2).Length < 8) currentstr1 += Convert.ToString(regInput1 / 256, 2).PadLeft(8, '0');
                else currentstr1 += Convert.ToString(regInput1 / 256, 2).Substring(Convert.ToString(regInput1 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput1 % 256, 2).Length < 8) currentstr1 += Convert.ToString(regInput1 % 256, 2).PadLeft(8, '0');
                else currentstr1 += Convert.ToString(regInput1 % 256, 2).Substring(Convert.ToString(regInput1 % 256, 2).Length - 8);
                
                uint currentuint1 = Convert.ToUInt32(currentstr1, 2); /* 把整理好的二進位字串轉成uint */
                float currentfloat1 = BitConverter.ToSingle(BitConverter.GetBytes(currentuint1), 0); /* 轉成浮點數 */
                double currentdouble1 = Math.Round(Convert.ToDouble(currentfloat1 * 10)) / 10; /* 轉成double四捨五入 */
                /* 顯示在HMI上 */
                if (currentdouble1 == 0) Current1.Text = "0.0";
                else Current1.Text = currentdouble1.ToString();
                
                /* 開度 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string openingstr1;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput1 = PLC1Register_2_7[5]; //開度前半段

                if (Convert.ToString(regInput1 / 256, 2).Length <= 8) openingstr1 = Convert.ToString(regInput1 / 256, 2).PadLeft(8, '0');                
                else openingstr1 = Convert.ToString(regInput1 / 256, 2).Substring(Convert.ToString(regInput1 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput1 % 256, 2).Length <= 8) openingstr1 += Convert.ToString(regInput1 % 256, 2).PadLeft(8, '0');                
                else openingstr1 += Convert.ToString(regInput1 % 256, 2).Substring(Convert.ToString(regInput1 % 256, 2).Length - 8);
                
                regInput1 = PLC1Register_2_7[4]; //開度後半段
                if (Convert.ToString(regInput1 / 256, 2).Length <= 8) openingstr1 += Convert.ToString(regInput1 / 256, 2).PadLeft(8, '0');                
                else openingstr1 += Convert.ToString(regInput1 / 256, 2).Substring(Convert.ToString(regInput1 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput1 % 256, 2).Length <= 8) openingstr1 += Convert.ToString(regInput1 % 256, 2).PadLeft(8, '0');                
                else openingstr1 += Convert.ToString(regInput1 % 256, 2).Substring(Convert.ToString(regInput1 % 256, 2).Length - 8);
                
                uint openinguint1 = Convert.ToUInt32(openingstr1, 2); /* 把整理好的二進位字串轉成uint */
                float openingfloat1 = BitConverter.ToSingle(BitConverter.GetBytes(openinguint1), 0); /* 轉成浮點數 */
                double openingdouble1 = Math.Round(Convert.ToDouble(openingfloat1 * 100)) / 100; /* 轉成double四捨五入 */
                /* 顯示在HMI上 */
                if (openingdouble1 == 0) Opening1.Text = "0.0";                
                else Opening1.Text = openingdouble1.ToString();
                
                /* 流量用算的 */
                /* 顯示在HMI上 */
                Outflow1.Text = "0.0";
            }

            // PLC2's status
            if (client2.Connected)
            {
                int[] PLC2Register_0 = client2.ReadHoldingRegisters(0, 1); // Read registers [0] values
                string PLC2Status;

                // 把暫存器數值轉成二進位(字串)，並補0
                // 若第15號燈、也就是二進制的第一位為1，那讀進來會變負值，此時必須先+32768將他轉正，再轉成字串，而且補零時記得要把最左邊(第一位)改回'1'。          
                if (PLC2Register_0[0] < 0)
                {
                    PLC2Register_0[0] += 32768; // 回推 +32768
                    PLC2Status = "1" + Convert.ToString(PLC2Register_0[0], 2).PadLeft(15, '0'); // 轉字串，補0後再補一個1                           
                }
                else
                {
                    PLC2Status = Convert.ToString(PLC2Register_0[0], 2).PadLeft(16, '0'); // 轉字串，補零 
                }

                // 開始看字串改變燈號，[ 字串位置0 ~ 15 ] 對應 [ 燈號 DI_15~0 ]
                // 目前先以最笨if暴力解
                
                if (PLC2Status.Substring(15, 1) == "1") Power2.BackColor = Color.Red; // DI_0 電源              
                else if (PLC2Status.Substring(15, 1) == "0") Power2.BackColor = Color.Gainsboro;                               
                if (PLC2Status.Substring(14, 1) == "1") OnSite2.BackColor = Color.Red; // DI_1 現場                 
                else if (PLC2Status.Substring(14, 1) == "0") OnSite2.BackColor = Color.Gainsboro;                                 
                if (PLC2Status.Substring(13, 1) == "1") Remote2.BackColor = Color.Red; // DI_2 遠方                
                else if (PLC2Status.Substring(13, 1) == "0") Remote2.BackColor = Color.Gainsboro;              
                if (PLC2Status.Substring(12, 1) == "1") Up2.BackColor = Color.Red; // DI_3 上升                
                else if (PLC2Status.Substring(12, 1) == "0") Up2.BackColor = Color.Gainsboro;                                
                if (PLC2Status.Substring(11, 1) == "1") Down2.BackColor = Color.Red; // DI_4 下降                
                else if (PLC2Status.Substring(11, 1) == "0") Down2.BackColor = Color.Gainsboro;
                if (PLC2Status.Substring(10, 1) == "1") OpenAll2.BackColor = Color.Red; // DI_5 全開
                else if (PLC2Status.Substring(10, 1) == "0") OpenAll2.BackColor = Color.Gainsboro;
                if (PLC2Status.Substring(9, 1) == "1") CloseAllEX2.BackColor = Color.Red; // DI_6 全關                 
                else if (PLC2Status.Substring(9, 1) == "0") CloseAllEX2.BackColor = Color.Gainsboro;                
                if (PLC2Status.Substring(8, 1) == "1") OpenAllEX2.BackColor = Color.Red; // DI_7 超全開               
                else if (PLC2Status.Substring(8, 1) == "0") OpenAllEX2.BackColor = Color.Gainsboro;                                 
                if (PLC2Status.Substring(7, 1) == "1") TorqueOff2.BackColor = Color.Red; // DI_8 關閉過扭力                
                else if (PLC2Status.Substring(7, 1) == "0") TorqueOff2.BackColor = Color.Gainsboro;                                
                if (PLC2Status.Substring(6, 1) == "1") EEEscape2.BackColor = Color.Red; // DI_9 3E逃脫                
                else if (PLC2Status.Substring(6, 1) == "0") EEEscape2.BackColor = Color.Gainsboro;                                
                if (PLC2Status.Substring(5, 1) == "1") GateOverload2.BackColor = Color.Red; // DI_10 吊門機過載                
                else if (PLC2Status.Substring(5, 1) == "0") GateOverload2.BackColor = Color.Gainsboro;                                    
                if (PLC2Status.Substring(4, 1) == "1") MotorEscape2.BackColor = Color.Red; // DI_11 馬達過熱逃脫
                else if (PLC2Status.Substring(4, 1) == "0") MotorEscape2.BackColor = Color.Gainsboro;                                
                if (PLC2Status.Substring(3, 1) == "1") EmergencyStop2.BackColor = Color.Red; // DI_12 緊急停止                
                else if (PLC2Status.Substring(3, 1) == "0") EmergencyStop2.BackColor = Color.Gainsboro;                                
                if (PLC2Status.Substring(2, 1) == "1") TorqueOn2.BackColor = Color.Red; // DI_13 開啟過扭力                
                else if (PLC2Status.Substring(2, 1) == "0") TorqueOn2.BackColor = Color.Gainsboro;                          
                if (PLC2Status.Substring(1, 1) == "1") Fault2.BackColor = Color.Red; // DI_14 接地故障                
                else if (PLC2Status.Substring(1, 1) == "0") Fault2.BackColor = Color.Gainsboro;                               
                if (PLC2Status.Substring(0, 1) == "1") CloseAll2.BackColor = Color.Red; //DI_15 全關                
                else if (PLC2Status.Substring(0, 1) == "0") CloseAll2.BackColor = Color.Gainsboro;
                

                /* 接下來處理電壓、電流、開度 */
                /* Read registers [2, 7] [電壓前半, 電壓後半, 電流前半, 電流後半, 開度前半, 開度後半] */
                int[] PLC2Register_2_7 = client2.ReadHoldingRegisters(2, 7);
                int regInput2;

                /* 電壓 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string voltagestr2;

                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput2 = PLC2Register_2_7[1]; //電壓前半段

                if (Convert.ToString(regInput2 / 256, 2).Length <= 8) voltagestr2 = Convert.ToString(regInput2 / 256, 2).PadLeft(8, '0');                
                else voltagestr2 = Convert.ToString(regInput2 / 256, 2).Substring(Convert.ToString(regInput2 / 256, 2).Length - 8);  
                
                if (Convert.ToString(regInput2 % 256, 2).Length <= 8) voltagestr2 += Convert.ToString(regInput2 % 256, 2).PadLeft(8, '0');                
                else voltagestr2 += Convert.ToString(regInput2 % 256, 2).Substring(Convert.ToString(regInput2 % 256, 2).Length - 8);
                
                regInput2 = PLC2Register_2_7[0]; //電壓後半段
                if (Convert.ToString(regInput2 / 256, 2).Length <= 8) voltagestr2 += Convert.ToString(regInput2 / 256, 2).PadLeft(8, '0');                
                else voltagestr2 += Convert.ToString(regInput2 / 256, 2).Substring(Convert.ToString(regInput2 / 256, 2).Length - 8);                

                if (Convert.ToString(regInput2 % 256, 2).Length <= 8) voltagestr2 += Convert.ToString(regInput2 % 256, 2).PadLeft(8, '0');                
                else voltagestr2 += Convert.ToString(regInput2 % 256, 2).Substring(Convert.ToString(regInput2 % 256, 2).Length - 8);
                
                int voltageuint2 = Convert.ToInt32(voltagestr2, 2); /* 把整理好的二進位字串轉成uint */
                float voltagefloat2 = BitConverter.ToSingle(BitConverter.GetBytes(voltageuint2), 0); /* 轉成浮點數 */
                double voltagedouble2 = Math.Round(Convert.ToDouble(voltagefloat2)); /* 轉成double四捨五入 */
                Voltage2.Text = voltagedouble2.ToString(); /* 顯示在HMI上 */

                /* 電流 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string currentstr2;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput2 = PLC2Register_2_7[3]; //電流前半段
                if (Convert.ToString(regInput2 / 256, 2).Length <= 8) currentstr2 = Convert.ToString(regInput2 / 256, 2).PadLeft(8, '0');                
                else currentstr2 = Convert.ToString(regInput2 / 256, 2).Substring(Convert.ToString(regInput2 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput2 % 256, 2).Length <= 8) currentstr2 += Convert.ToString(regInput2 % 256, 2).PadLeft(8, '0');                
                else currentstr2 += Convert.ToString(regInput2 % 256, 2).Substring(Convert.ToString(regInput2 % 256, 2).Length - 8);
                
                regInput2 = PLC2Register_2_7[2]; //電流後半段
                if (Convert.ToString(regInput2 / 256, 2).Length < 8) currentstr2 += Convert.ToString(regInput2 / 256, 2).PadLeft(8, '0');                
                else currentstr2 += Convert.ToString(regInput2 / 256, 2).Substring(Convert.ToString(regInput2 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput2 % 256, 2).Length < 8) currentstr2 += Convert.ToString(regInput2 % 256, 2).PadLeft(8, '0');                
                else currentstr2 += Convert.ToString(regInput2 % 256, 2).Substring(Convert.ToString(regInput2 % 256, 2).Length - 8);                

                uint currentuint2 = Convert.ToUInt32(currentstr2, 2); /* 把整理好的二進位字串轉成uint */
                float currentfloat2 = BitConverter.ToSingle(BitConverter.GetBytes(currentuint2), 0); /* 轉成浮點數 */
                double currentdouble2 = Math.Round(Convert.ToDouble(currentfloat2 * 10)) / 10; /* 轉成double四捨五入 */
                /* 顯示在HMI上 */
                if (currentdouble2 == 0) Current2.Text = "0.0";                
                else Current2.Text = currentdouble2.ToString();                

                /* 開度 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string openingstr2;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput2 = PLC2Register_2_7[5]; //電流前半段

                if (Convert.ToString(regInput2 / 256, 2).Length <= 8) openingstr2 = Convert.ToString(regInput2 / 256, 2).PadLeft(8, '0');
                else openingstr2 = Convert.ToString(regInput2 / 256, 2).Substring(Convert.ToString(regInput2 / 256, 2).Length - 8);

                if (Convert.ToString(regInput2 % 256, 2).Length <= 8) openingstr2 += Convert.ToString(regInput2 % 256, 2).PadLeft(8, '0');
                else openingstr2 += Convert.ToString(regInput2 % 256, 2).Substring(Convert.ToString(regInput2 % 256, 2).Length - 8);
                
                regInput2 = PLC2Register_2_7[4]; //電流後半段
                if (Convert.ToString(regInput2 / 256, 2).Length <= 8) openingstr2 += Convert.ToString(regInput2 / 256, 2).PadLeft(8, '0');                
                else openingstr2 += Convert.ToString(regInput2 / 256, 2).Substring(Convert.ToString(regInput2 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput2 % 256, 2).Length <= 8) openingstr2 += Convert.ToString(regInput2 % 256, 2).PadLeft(8, '0');
                else openingstr2 += Convert.ToString(regInput2 % 256, 2).Substring(Convert.ToString(regInput2 % 256, 2).Length - 8);
                

                uint openinguint2 = Convert.ToUInt32(openingstr2, 2); /* 把整理好的二進位字串轉成uint */
                float openingfloat2 = BitConverter.ToSingle(BitConverter.GetBytes(openinguint2), 0); /* 轉成浮點數 */
                double openingdouble2 = Math.Round(Convert.ToDouble(openingfloat2 * 100)) / 100; /* 轉成double四捨五入 */
                if (openingdouble2 <= 0.1) openingdouble2 = 0;
                else if (openingdouble2 > 100) openingdouble2 = 0;
                
                /* 顯示在HMI上 */
                if (openingdouble2 == 0) Opening2.Text = "0.00";
                else Opening2.Text = openingdouble2.ToString();                

                /* 流量 */
                /* 顯示在HMI上 */
                Outflow2.Text = "0.0";
            }

            // PLC3's status
            if (client3.Connected)
            {
                int[] PLC3Register_0 = client3.ReadHoldingRegisters(0, 1); // Read registers [0, 1] values
                string PLC3Status;

                // 把暫存器數值轉成二進位(字串)，並補0
                // 若第15號燈、也就是二進制的第一位為1，那讀進來會變負值，此時必須先+32768將他轉正，再轉成字串，而且補零時記得要把最左邊(第一位)改回'1'。          
                if (PLC3Register_0[0] < 0)
                {
                    PLC3Register_0[0] += 32768; // 回推 +32768
                    PLC3Status = "1" + Convert.ToString(PLC3Register_0[0], 2).PadLeft(15, '0'); // 轉字串，補0後再補一個1                           
                }
                else
                {
                    PLC3Status = Convert.ToString(PLC3Register_0[0], 2).PadLeft(16, '0'); // 轉字串，補零 
                }

                // 開始看字串改變燈號，[ 字串位置0 ~ 15 ] 對應 [ 燈號 DI_15~0 ]
                // 目前先以最笨if暴力解
                 
                if (PLC3Status.Substring(15, 1) == "1") Power3.BackColor = Color.Red; // DI_0 電源                
                else if (PLC3Status.Substring(15, 1) == "0") Power3.BackColor = Color.Gainsboro;                
                if (PLC3Status.Substring(14, 1) == "1") OnSite3.BackColor = Color.Red; // DI_1 現場                 
                else if (PLC3Status.Substring(14, 1) == "0") OnSite3.BackColor = Color.Gainsboro;                  
                if (PLC3Status.Substring(13, 1) == "1") Remote3.BackColor = Color.Red; // DI_2 遠方                
                else if (PLC3Status.Substring(13, 1) == "0") Remote3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(12, 1) == "1") Up3.BackColor = Color.Red; // DI_3 上升                 
                else if (PLC3Status.Substring(12, 1) == "0") Up3.BackColor = Color.Gainsboro;                                 
                if (PLC3Status.Substring(11, 1) == "1") Down3.BackColor = Color.Red; // DI_4 下降                
                else if (PLC3Status.Substring(11, 1) == "0") Down3.BackColor = Color.Gainsboro;
                if (PLC3Status.Substring(10, 1) == "1") OpenAll3.BackColor = Color.Red; // DI_5 全開                
                else if (PLC3Status.Substring(10, 1) == "0") OpenAll3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(9, 1) == "1") CloseAllEX3.BackColor = Color.Red; // DI_6 全關                
                else if (PLC3Status.Substring(9, 1) == "0") CloseAllEX3.BackColor = Color.Gainsboro;                                 
                if (PLC3Status.Substring(8, 1) == "1") OpenAllEX3.BackColor = Color.Red; // DI_7 超全開                
                else if (PLC3Status.Substring(8, 1) == "0") OpenAllEX3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(7, 1) == "1") TorqueOff3.BackColor = Color.Red; // DI_8 關閉過扭力                 
                else if (PLC3Status.Substring(7, 1) == "0") TorqueOff3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(6, 1) == "1") EEEscape3.BackColor = Color.Red; // DI_9 3E逃脫                
                else if (PLC3Status.Substring(6, 1) == "0") EEEscape3.BackColor = Color.Gainsboro;                               
                if (PLC3Status.Substring(5, 1) == "1") GateOverload3.BackColor = Color.Red; // DI_10 吊門機過載                
                else if (PLC3Status.Substring(5, 1) == "0") GateOverload3.BackColor = Color.Gainsboro;                              
                if (PLC3Status.Substring(4, 1) == "1") MotorEscape3.BackColor = Color.Red; // DI_11 馬達過熱逃脫                
                else if (PLC3Status.Substring(4, 1) == "0") MotorEscape3.BackColor = Color.Gainsboro;                               
                if (PLC3Status.Substring(3, 1) == "1") EmergencyStop3.BackColor = Color.Red; // DI_12 緊急停止                
                else if (PLC3Status.Substring(3, 1) == "0") EmergencyStop3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(2, 1) == "1") TorqueOn3.BackColor = Color.Red; // DI_13 開啟過扭力                
                else if (PLC3Status.Substring(2, 1) == "0") TorqueOn3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(1, 1) == "1" ) Fault3.BackColor = Color.Red; // DI_14 接地故障                
                else if (PLC3Status.Substring(1, 1) == "0") Fault3.BackColor = Color.Gainsboro;                                
                if (PLC3Status.Substring(0, 1) == "1") CloseAll3.BackColor = Color.Red; //DI_15 全關                
                else if (PLC3Status.Substring(0, 1) == "0") CloseAll3.BackColor = Color.Gainsboro;                

                /* 接下來處理電壓、電流、開度 */
                /* Read registers [2, 10] [電壓前半, 電壓後半, 電流前半, 電流後半, 開度前半, 開度後半] */
                int[] PLC3Register_2_11 = client3.ReadHoldingRegisters(2, 10);
                int regInput3;

                /* 電壓 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string voltagestr3;

                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput3 = PLC3Register_2_11[1]; //電壓前半段

                if (Convert.ToString(regInput3 / 256, 2).Length <= 8) voltagestr3 = Convert.ToString(regInput3 / 256, 2).PadLeft(8, '0');                
                else voltagestr3 = Convert.ToString(regInput3 / 256, 2).Substring(Convert.ToString(regInput3 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput3 % 256, 2).Length <= 8) voltagestr3 += Convert.ToString(regInput3 % 256, 2).PadLeft(8, '0');                
                else voltagestr3 += Convert.ToString(regInput3 % 256, 2).Substring(Convert.ToString(regInput3 % 256, 2).Length - 8);
                
                regInput3 = PLC3Register_2_11[0]; //電壓後半段

                if (Convert.ToString(regInput3 / 256, 2).Length <= 8) voltagestr3 += Convert.ToString(regInput3 / 256, 2).PadLeft(8, '0');                
                else voltagestr3 += Convert.ToString(regInput3 / 256, 2).Substring(Convert.ToString(regInput3 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput3 % 256, 2).Length <= 8) voltagestr3 += Convert.ToString(regInput3 % 256, 2).PadLeft(8, '0');                
                else voltagestr3 += Convert.ToString(regInput3 % 256, 2).Substring(Convert.ToString(regInput3 % 256, 2).Length - 8);                

                int voltageuint3 = Convert.ToInt32(voltagestr3, 2); /* 把整理好的二進位字串轉成uint */
                float voltagefloat3 = BitConverter.ToSingle(BitConverter.GetBytes(voltageuint3), 0); /* 轉成浮點數 */
                double voltagedouble3 = Math.Round(Convert.ToDouble(voltagefloat3)); /* 轉成double四捨五入 */
                Voltage3.Text = voltagedouble3.ToString(); /* 顯示在HMI上 */

                /* 電流 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string currentstr3;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput3 = PLC3Register_2_11[3]; //電流前半段

                if (Convert.ToString(regInput3 / 256, 2).Length <= 8) currentstr3 = Convert.ToString(regInput3 / 256, 2).PadLeft(8, '0');                
                else currentstr3 = Convert.ToString(regInput3 / 256, 2).Substring(Convert.ToString(regInput3 / 256, 2).Length - 8);
                
                if (Convert.ToString(regInput3 % 256, 2).Length <= 8) currentstr3 += Convert.ToString(regInput3 % 256, 2).PadLeft(8, '0');                
                else currentstr3 += Convert.ToString(regInput3 % 256, 2).Substring(Convert.ToString(regInput3 % 256, 2).Length - 8);
                
                regInput3 = PLC3Register_2_11[2]; //電流後半段

                if (Convert.ToString(regInput3 / 256, 2).Length < 8) currentstr3 += Convert.ToString(regInput3 / 256, 2).PadLeft(8, '0');                
                else currentstr3 += Convert.ToString(regInput3 / 256, 2).Substring(Convert.ToString(regInput3 / 256, 2).Length - 8);                

                if (Convert.ToString(regInput3 % 256, 2).Length < 8) currentstr3 += Convert.ToString(regInput3 % 256, 2).PadLeft(8, '0');                
                else currentstr3 += Convert.ToString(regInput3 % 256, 2).Substring(Convert.ToString(regInput3 % 256, 2).Length - 8);
                
                uint currentuint3 = Convert.ToUInt32(currentstr3, 2); /* 把整理好的二進位字串轉成uint */
                float currentfloat3 = BitConverter.ToSingle(BitConverter.GetBytes(currentuint3), 0); /* 轉成浮點數 */
                double currentdouble3 = Math.Round(Convert.ToDouble(currentfloat3 * 10)) / 10; /* 轉成double四捨五入 */
                /* 顯示在HMI上 */
                if (currentdouble3 == 0) Current3.Text = "0.0";                
                else Current3.Text = currentdouble3.ToString();                

                /* 開度 */
                /* step1. 將代表該物理量的兩個整數轉成2進制並補零 */
                string openingstr3;
                /* 整數除256的商會變成第一個值，餘會變成第二個值，將這兩個數轉成二進制並看看是否滿8bit，沒滿左邊補零 */
                /* [物理量,前半暫存器位址, 後半暫存器位址] -> [電壓, 3, 2]; [電流, 5, 4]; [開度, 7, 6] */
                regInput3 = PLC3Register_2_11[5]; //電流前半段

                if (Convert.ToString(regInput3 / 256, 2).Length <= 8) openingstr3 = Convert.ToString(regInput3 / 256, 2).PadLeft(8, '0');                
                else openingstr3 = Convert.ToString(regInput3 / 256, 2).Substring(Convert.ToString(regInput3 / 256, 2).Length - 8);                

                if (Convert.ToString(regInput3 % 256, 2).Length <= 8) openingstr3 += Convert.ToString(regInput3 % 256, 2).PadLeft(8, '0');                
                else openingstr3 += Convert.ToString(regInput3 % 256, 2).Substring(Convert.ToString(regInput3 % 256, 2).Length - 8);
                
                regInput3 = PLC3Register_2_11[4]; //電流後半段

                if (Convert.ToString(regInput3 / 256, 2).Length <= 8) openingstr3 += Convert.ToString(regInput3 / 256, 2).PadLeft(8, '0');                
                else openingstr3 += Convert.ToString(regInput3 / 256, 2).Substring(Convert.ToString(regInput3 / 256, 2).Length - 8);                

                if (Convert.ToString(regInput3 % 256, 2).Length <= 8) openingstr3 += Convert.ToString(regInput3 % 256, 2).PadLeft(8, '0');                
                else openingstr3 += Convert.ToString(regInput3 % 256, 2).Substring(Convert.ToString(regInput3 % 256, 2).Length - 8);                

                uint openinguint3 = Convert.ToUInt32(openingstr3, 2); /* 把整理好的二進位字串轉成uint */
                float openingfloat3 = BitConverter.ToSingle(BitConverter.GetBytes(openinguint3), 0); /* 轉成浮點數 */
                double openingdouble3 = Math.Round(Convert.ToDouble(openingfloat3 * 100)) / 100; /* 轉成double四捨五入 */
                if (openingdouble3 <= 0.1) openingdouble3 = 0;                
                else if (openingdouble3 > 100) openingdouble3 = 0;
                
                /* 顯示在HMI上 */
                if (openingdouble3 == 0) Opening3.Text = "0.0";                
                else Opening3.Text = openingdouble3.ToString();                

                /* 流量 */
                /* 顯示在HMI上 */
                Outflow3.Text = "0.0";
            }                    
        }




        // 按鈕的觸發 & timer : 以滑鼠按下和放開作為timer的開始與結束，在timer時間內不斷發封包請求動作
        // Gate1 開啟
        private void PushUp1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power1.BackColor == Color.Red & Remote1.BackColor == Color.Red)
            {
                timerPushUp1.Start();
                PushUp1.BackColor= Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushUp1_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushUp1.Stop();
            PushUp1.BackColor = Color.MediumAquamarine;
        }
        private void timerPushUp1_Tick(object sender, EventArgs e)
        {            
            client1.WriteSingleRegister(499, 34);          
        }
        // Gate1 關閉
        private void PushDown1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power1.BackColor == Color.Red & Remote1.BackColor == Color.Red)
            {
                timerPushDown1.Start();
                PushDown1.BackColor= Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushDown1_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushDown1.Stop();
            PushDown1.BackColor= Color.MediumAquamarine;
        }
        private void timerPushDown1_Tick(object sender, EventArgs e)
        {            
            client1.WriteSingleRegister(499, 36);   
        }
        // Gate1 停止
        private void PushStop1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power1.BackColor == Color.Red & Remote1.BackColor == Color.Red)
            {
                timerPushStop1.Start();
                PushStop1.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushStop1_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushStop1.Stop();
            PushStop1.BackColor = Color.MediumAquamarine;
        }
        private void timerPushStop1_Tick(object sender, EventArgs e)
        {            
            client1.WriteSingleRegister(499, 33);           
        }
        // Gate1 緊急停止
        private void PushEStop_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power1.BackColor == Color.Red & Remote1.BackColor == Color.Red)
            {
                timerPushEStop1.Start();
                PushEStop1.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushEStop_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushEStop1.Stop();
            PushEStop1.BackColor = Color.MediumAquamarine;
        }
        private void timerPushEStop1_Tick(object sender, EventArgs e)
        {            
            client1.WriteSingleRegister(499, 40);            
        }

        // Gate2 開啟 
        private void PushUp2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power2.BackColor == Color.Red & Remote2.BackColor == Color.Red)
            {
                timerPushUp2.Start();
                PushUp2.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushUp2_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushUp2.Stop();
            PushUp2.BackColor = Color.MediumAquamarine;
        }
        private void timerPushUp2_Tick(object sender, EventArgs e)
        { 
            client2.WriteSingleRegister(499, 34);         
        }
        // Gate2 關閉
        private void PushDown2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power2.BackColor == Color.Red & Remote2.BackColor == Color.Red)
            {
                timerPushDown2.Start();
                PushDown2.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushDown2_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushDown2.Stop();
            PushDown2.BackColor = Color.MediumAquamarine;
        }
        private void timerPushDown2_Tick(object sender, EventArgs e)
        {            
            client2.WriteSingleRegister(499, 36);           
        }
        // Gate2 停止
        private void PushStop2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power2.BackColor == Color.Red & Remote2.BackColor == Color.Red)
            {
                timerPushStop2.Start();
                PushStop2.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }
        }
        private void PushStop2_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushStop2.Stop();
            PushStop2.BackColor = Color.MediumAquamarine;
        }
        private void timerPushStop2_Tick(object sender, EventArgs e)
        {            
            client2.WriteSingleRegister(499, 33);
        }
        // Gate2 緊急停止
        private void PushEStop2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power2.BackColor == Color.Red & Remote2.BackColor == Color.Red)
            {
                timerPushEStop2.Start();
                PushEStop2.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }          
        }
        private void PushEStop2_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushEStop2.Stop();
            PushEStop2.BackColor = Color.MediumAquamarine;
        }
        private void timerPushEStop2_Tick(object sender, EventArgs e)
        {            
            client2.WriteSingleRegister(499, 40);          
        }

        // Gate3 開啟
        private void PushUp3_MouseDown(object sender, MouseEventArgs e)
        {
            if ( Power3.BackColor == Color.Red & Remote3.BackColor == Color.Red )
            {
                timerPushUp3.Start();
                PushUp3.BackColor = Color.Orange;                
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushUp3_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushUp3.Stop();
            PushUp3.BackColor = Color.MediumAquamarine;
        }
        private void timerPushUp3_Tick(object sender, EventArgs e)
        {            
            client3.WriteSingleRegister(499, 34);           
        }
        // Gate3 關閉
        private void PushDown3_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power3.BackColor == Color.Red & Remote3.BackColor == Color.Red)
            {
                timerPushDown3.Start();
                PushDown3.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }
        }
        private void PushDown3_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushDown3.Stop();
            PushDown3.BackColor= Color.MediumAquamarine;
        }
        private void timerPushDown3_Tick(object sender, EventArgs e)
        {                  
            client3.WriteSingleRegister(499, 37);         
        }
        // Gate3 停止
        private void PushStop3_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power3.BackColor == Color.Red & Remote3.BackColor == Color.Red)
            {                
                timerPushStop3.Start();
                PushStop3.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushStop3_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushStop3.Stop();
            PushStop3.BackColor = Color.MediumAquamarine;
        }
        private void timerPushStop3_Tick(object sender, EventArgs e)
        {
            client3.WriteSingleRegister(499, 33);          
        }
        // Gate3 緊急停止
        private void PushEStop3_MouseDown(object sender, MouseEventArgs e)
        {
            if (Power3.BackColor == Color.Red & Remote3.BackColor == Color.Red)
            {
                timerPushEStop3.Start();
                PushEStop3.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("請確認電源及遠方狀態!", "Error", MessageBoxButtons.OK);
            }            
        }
        private void PushEStop3_MouseUp(object sender, MouseEventArgs e)
        {
            timerPushEStop3.Stop();
            PushEStop3.BackColor = Color.MediumAquamarine;
        }
        private void timerPushEStop3_Tick(object sender, EventArgs e)
        {            
            client3.WriteSingleRegister(499, 40);           
        }

        private void TryConn1_Click(object sender, EventArgs e)
        {
            try
            {
                client1.IPAddress = G1ip;
                client1.Connect();
                TryConn1.ForeColor = Color.Green;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void TryConn2_Click(object sender, EventArgs e)
        {
            try
            {
                client2.IPAddress = G2ip;
                client2.Connect();
                TryConn2.ForeColor = Color.Green;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void TryConn3_Click(object sender, EventArgs e)
        {
            try
            {
                client3.IPAddress = G3ip;
                client3.Connect();
                TryConn3.ForeColor = Color.Green;
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}
