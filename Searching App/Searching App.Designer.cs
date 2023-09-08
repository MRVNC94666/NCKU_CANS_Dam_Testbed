namespace Searching_App
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Topic = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.duration = new System.Windows.Forms.Label();
            this.year1 = new System.Windows.Forms.ComboBox();
            this.month1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.day1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hour1 = new System.Windows.Forms.ComboBox();
            this.min1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.min2 = new System.Windows.Forms.ComboBox();
            this.hour2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.day2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.month2 = new System.Windows.Forms.ComboBox();
            this.year2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Result = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.starttime = new System.Windows.Forms.Label();
            this.endtime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Topic);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1324, 74);
            this.panel1.TabIndex = 0;
            // 
            // Topic
            // 
            this.Topic.AutoSize = true;
            this.Topic.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Topic.Location = new System.Drawing.Point(281, 11);
            this.Topic.Name = "Topic";
            this.Topic.Size = new System.Drawing.Size(809, 55);
            this.Topic.TabIndex = 0;
            this.Topic.Text = "CANS Dam Testbed Data Searching App";
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(953, 82);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(262, 55);
            this.Search.TabIndex = 1;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(1221, 82);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(89, 55);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // duration
            // 
            this.duration.AutoSize = true;
            this.duration.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.duration.Location = new System.Drawing.Point(3, 75);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(254, 31);
            this.duration.TabIndex = 1;
            this.duration.Text = "Select time duration : ";
            // 
            // year1
            // 
            this.year1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year1.FormattingEnabled = true;
            this.year1.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022"});
            this.year1.Location = new System.Drawing.Point(81, 110);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(69, 27);
            this.year1.TabIndex = 3;
            this.year1.Text = "YYYY";
            this.year1.SelectedIndexChanged += new System.EventHandler(this.year1_SelectedIndexChanged);
            // 
            // month1
            // 
            this.month1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month1.FormattingEnabled = true;
            this.month1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.month1.Location = new System.Drawing.Point(185, 110);
            this.month1.Name = "month1";
            this.month1.Size = new System.Drawing.Size(50, 27);
            this.month1.TabIndex = 4;
            this.month1.Text = "MM";
            this.month1.SelectedIndexChanged += new System.EventHandler(this.month1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(156, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "-";
            // 
            // day1
            // 
            this.day1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day1.FormattingEnabled = true;
            this.day1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day1.Location = new System.Drawing.Point(270, 110);
            this.day1.Name = "day1";
            this.day1.Size = new System.Drawing.Size(50, 27);
            this.day1.TabIndex = 6;
            this.day1.Text = "DD";
            this.day1.SelectedIndexChanged += new System.EventHandler(this.day1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(241, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(399, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = ":";
            // 
            // hour1
            // 
            this.hour1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hour1.FormattingEnabled = true;
            this.hour1.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hour1.Location = new System.Drawing.Point(343, 110);
            this.hour1.Name = "hour1";
            this.hour1.Size = new System.Drawing.Size(50, 27);
            this.hour1.TabIndex = 9;
            this.hour1.Text = "hh";
            this.hour1.SelectedIndexChanged += new System.EventHandler(this.hour1_SelectedIndexChanged);
            // 
            // min1
            // 
            this.min1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min1.FormattingEnabled = true;
            this.min1.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.min1.Location = new System.Drawing.Point(425, 110);
            this.min1.Name = "min1";
            this.min1.Size = new System.Drawing.Size(50, 27);
            this.min1.TabIndex = 10;
            this.min1.Text = "mm";
            this.min1.SelectedIndexChanged += new System.EventHandler(this.min1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(481, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "to";
            // 
            // min2
            // 
            this.min2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min2.FormattingEnabled = true;
            this.min2.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.min2.Location = new System.Drawing.Point(861, 110);
            this.min2.Name = "min2";
            this.min2.Size = new System.Drawing.Size(50, 27);
            this.min2.TabIndex = 19;
            this.min2.Text = "mm";
            this.min2.SelectedIndexChanged += new System.EventHandler(this.min2_SelectedIndexChanged);
            // 
            // hour2
            // 
            this.hour2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hour2.FormattingEnabled = true;
            this.hour2.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hour2.Location = new System.Drawing.Point(779, 110);
            this.hour2.Name = "hour2";
            this.hour2.Size = new System.Drawing.Size(50, 27);
            this.hour2.TabIndex = 18;
            this.hour2.Text = "hh";
            this.hour2.SelectedIndexChanged += new System.EventHandler(this.hour2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(835, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(677, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 31);
            this.label6.TabIndex = 16;
            this.label6.Text = "-";
            // 
            // day2
            // 
            this.day2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day2.FormattingEnabled = true;
            this.day2.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day2.Location = new System.Drawing.Point(706, 110);
            this.day2.Name = "day2";
            this.day2.Size = new System.Drawing.Size(50, 27);
            this.day2.TabIndex = 15;
            this.day2.Text = "DD";
            this.day2.SelectedIndexChanged += new System.EventHandler(this.day2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(592, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "-";
            // 
            // month2
            // 
            this.month2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month2.FormattingEnabled = true;
            this.month2.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.month2.Location = new System.Drawing.Point(621, 110);
            this.month2.Name = "month2";
            this.month2.Size = new System.Drawing.Size(50, 27);
            this.month2.TabIndex = 13;
            this.month2.Text = "MM";
            this.month2.SelectedIndexChanged += new System.EventHandler(this.month2_SelectedIndexChanged);
            // 
            // year2
            // 
            this.year2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year2.FormattingEnabled = true;
            this.year2.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022"});
            this.year2.Location = new System.Drawing.Point(517, 110);
            this.year2.Name = "year2";
            this.year2.Size = new System.Drawing.Size(69, 27);
            this.year2.TabIndex = 12;
            this.year2.Text = "YYYY";
            this.year2.SelectedIndexChanged += new System.EventHandler(this.year2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(917, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 31);
            this.label8.TabIndex = 20;
            this.label8.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(3, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 31);
            this.label9.TabIndex = 21;
            this.label9.Text = "From";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1301, 517);
            this.dataGridView1.TabIndex = 22;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Result.Location = new System.Drawing.Point(3, 143);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(84, 31);
            this.Result.TabIndex = 23;
            this.Result.Text = "Result";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(471, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = ")";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(285, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "~";
            // 
            // starttime
            // 
            this.starttime.AutoSize = true;
            this.starttime.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starttime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.starttime.Location = new System.Drawing.Point(114, 151);
            this.starttime.Name = "starttime";
            this.starttime.Size = new System.Drawing.Size(65, 21);
            this.starttime.TabIndex = 28;
            this.starttime.Text = "           ";
            // 
            // endtime
            // 
            this.endtime.AutoSize = true;
            this.endtime.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endtime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.endtime.Location = new System.Drawing.Point(303, 151);
            this.endtime.Name = "endtime";
            this.endtime.Size = new System.Drawing.Size(85, 21);
            this.endtime.TabIndex = 29;
            this.endtime.Text = "               ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(102, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 23);
            this.label12.TabIndex = 30;
            this.label12.Text = "(";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 824);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.endtime);
            this.Controls.Add(this.starttime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.min2);
            this.Controls.Add(this.hour2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.day2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.month2);
            this.Controls.Add(this.year2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.min1);
            this.Controls.Add(this.hour1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.day1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.month1);
            this.Controls.Add(this.year1);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "CANS Dam Testbed Data Searching App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Topic;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label duration;
        private System.Windows.Forms.ComboBox year1;
        private System.Windows.Forms.ComboBox month1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox day1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox hour1;
        private System.Windows.Forms.ComboBox min1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox min2;
        private System.Windows.Forms.ComboBox hour2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox day2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox month2;
        private System.Windows.Forms.ComboBox year2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label starttime;
        private System.Windows.Forms.Label endtime;
        private System.Windows.Forms.Label label12;
    }
}

