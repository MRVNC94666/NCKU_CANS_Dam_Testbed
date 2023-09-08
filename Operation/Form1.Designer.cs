namespace Operation
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
            this.components = new System.ComponentModel.Container();
            this.RUN = new System.Windows.Forms.Button();
            this.STOP = new System.Windows.Forms.Button();
            this.EXIT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.CLOCK = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.OUT3 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.OUT2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.OUT1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.STAT3 = new System.Windows.Forms.Label();
            this.STAT1 = new System.Windows.Forms.Label();
            this.STAT2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.STORAGEvar = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.OUTtot = new System.Windows.Forms.TextBox();
            this.INtot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.STORAGE = new System.Windows.Forms.TextBox();
            this.WATERLV = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OP3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.OP2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.OP1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Operate_timer = new System.Windows.Forms.Timer(this.components);
            this.Clock_timer = new System.Windows.Forms.Timer(this.components);
            this.LOAD = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.TextBox();
            this.DataCounter = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.InputData_idx_counter = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RUN
            // 
            this.RUN.BackColor = System.Drawing.Color.White;
            this.RUN.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RUN.ForeColor = System.Drawing.Color.Black;
            this.RUN.Location = new System.Drawing.Point(223, 337);
            this.RUN.Name = "RUN";
            this.RUN.Size = new System.Drawing.Size(307, 46);
            this.RUN.TabIndex = 0;
            this.RUN.Text = "RUN";
            this.RUN.UseVisualStyleBackColor = false;
            this.RUN.Click += new System.EventHandler(this.RUN_Click);
            // 
            // STOP
            // 
            this.STOP.BackColor = System.Drawing.Color.White;
            this.STOP.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STOP.ForeColor = System.Drawing.Color.Black;
            this.STOP.Location = new System.Drawing.Point(536, 337);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(270, 46);
            this.STOP.TabIndex = 1;
            this.STOP.Text = "STOP";
            this.STOP.UseVisualStyleBackColor = false;
            this.STOP.Click += new System.EventHandler(this.STOP_Click);
            // 
            // EXIT
            // 
            this.EXIT.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EXIT.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EXIT.Location = new System.Drawing.Point(692, 8);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(114, 45);
            this.EXIT.TabIndex = 3;
            this.EXIT.Text = "EXIT";
            this.EXIT.UseVisualStyleBackColor = false;
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(-1, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(425, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "DAM OPERATION GENERATE";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label68.Location = new System.Drawing.Point(434, 8);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(141, 27);
            this.label68.TabIndex = 75;
            this.label68.Text = "Current Time";
            // 
            // CLOCK
            // 
            this.CLOCK.AutoSize = true;
            this.CLOCK.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLOCK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CLOCK.Location = new System.Drawing.Point(435, 32);
            this.CLOCK.Name = "CLOCK";
            this.CLOCK.Size = new System.Drawing.Size(196, 22);
            this.CLOCK.TabIndex = 76;
            this.CLOCK.Text = "-------------------------------";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.OUT3);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.OUT2);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.OUT1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.STAT3);
            this.panel1.Controls.Add(this.STAT1);
            this.panel1.Controls.Add(this.STAT2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.OP3);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.OP2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.OP1);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(6, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 274);
            this.panel1.TabIndex = 77;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(742, 216);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 24);
            this.label30.TabIndex = 149;
            this.label30.Text = "(m)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(742, 124);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 24);
            this.label29.TabIndex = 148;
            this.label29.Text = "(m)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(742, 38);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 24);
            this.label28.TabIndex = 96;
            this.label28.Text = "(m)";
            // 
            // OUT3
            // 
            this.OUT3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OUT3.Location = new System.Drawing.Point(645, 189);
            this.OUT3.Name = "OUT3";
            this.OUT3.Size = new System.Drawing.Size(91, 26);
            this.OUT3.TabIndex = 137;
            this.OUT3.Text = "0";
            this.OUT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(742, 191);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 24);
            this.label25.TabIndex = 147;
            this.label25.Text = "(cms)";
            // 
            // OUT2
            // 
            this.OUT2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OUT2.Location = new System.Drawing.Point(645, 96);
            this.OUT2.Name = "OUT2";
            this.OUT2.Size = new System.Drawing.Size(91, 26);
            this.OUT2.TabIndex = 131;
            this.OUT2.Text = "0";
            this.OUT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(742, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 24);
            this.label24.TabIndex = 146;
            this.label24.Text = "(cms)";
            // 
            // OUT1
            // 
            this.OUT1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OUT1.Location = new System.Drawing.Point(646, 10);
            this.OUT1.Name = "OUT1";
            this.OUT1.Size = new System.Drawing.Size(90, 26);
            this.OUT1.TabIndex = 89;
            this.OUT1.Text = "0";
            this.OUT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(550, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 24);
            this.label15.TabIndex = 85;
            this.label15.Text = "OUTFLOW";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(742, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 24);
            this.label23.TabIndex = 145;
            this.label23.Text = "(cms)";
            // 
            // STAT3
            // 
            this.STAT3.AutoSize = true;
            this.STAT3.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STAT3.ForeColor = System.Drawing.Color.Black;
            this.STAT3.Location = new System.Drawing.Point(645, 245);
            this.STAT3.Name = "STAT3";
            this.STAT3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.STAT3.Size = new System.Drawing.Size(36, 27);
            this.STAT3.TabIndex = 144;
            this.STAT3.Text = "---";
            this.STAT3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // STAT1
            // 
            this.STAT1.AutoSize = true;
            this.STAT1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STAT1.ForeColor = System.Drawing.Color.Black;
            this.STAT1.Location = new System.Drawing.Point(646, 66);
            this.STAT1.Name = "STAT1";
            this.STAT1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.STAT1.Size = new System.Drawing.Size(36, 27);
            this.STAT1.TabIndex = 142;
            this.STAT1.Text = "---";
            this.STAT1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // STAT2
            // 
            this.STAT2.AutoSize = true;
            this.STAT2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STAT2.ForeColor = System.Drawing.Color.Black;
            this.STAT2.Location = new System.Drawing.Point(645, 152);
            this.STAT2.Name = "STAT2";
            this.STAT2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.STAT2.Size = new System.Drawing.Size(36, 27);
            this.STAT2.TabIndex = 141;
            this.STAT2.Text = "---";
            this.STAT2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.STORAGEvar);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.OUTtot);
            this.panel2.Controls.Add(this.INtot);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.STORAGE);
            this.panel2.Controls.Add(this.WATERLV);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 274);
            this.panel2.TabIndex = 112;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(299, 62);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 24);
            this.label22.TabIndex = 148;
            this.label22.Text = "(cms)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(299, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 24);
            this.label21.TabIndex = 147;
            this.label21.Text = "(cms)";
            // 
            // STORAGEvar
            // 
            this.STORAGEvar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STORAGEvar.Location = new System.Drawing.Point(184, 211);
            this.STORAGEvar.Name = "STORAGEvar";
            this.STORAGEvar.Size = new System.Drawing.Size(115, 32);
            this.STORAGEvar.TabIndex = 95;
            this.STORAGEvar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(299, 221);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 22);
            this.label27.TabIndex = 94;
            this.label27.Text = "(10^4 m^3)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(3, 214);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(154, 27);
            this.label26.TabIndex = 93;
            this.label26.Text = "STORAGE VAR.";
            // 
            // OUTtot
            // 
            this.OUTtot.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OUTtot.Location = new System.Drawing.Point(184, 97);
            this.OUTtot.Name = "OUTtot";
            this.OUTtot.Size = new System.Drawing.Size(115, 32);
            this.OUTtot.TabIndex = 88;
            this.OUTtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // INtot
            // 
            this.INtot.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INtot.Location = new System.Drawing.Point(184, 59);
            this.INtot.Name = "INtot";
            this.INtot.Size = new System.Drawing.Size(115, 32);
            this.INtot.TabIndex = 87;
            this.INtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 27);
            this.label5.TabIndex = 82;
            this.label5.Text = "TOTAL OUTFLOW";
            // 
            // STORAGE
            // 
            this.STORAGE.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STORAGE.Location = new System.Drawing.Point(184, 173);
            this.STORAGE.Name = "STORAGE";
            this.STORAGE.Size = new System.Drawing.Size(115, 32);
            this.STORAGE.TabIndex = 85;
            this.STORAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WATERLV
            // 
            this.WATERLV.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WATERLV.Location = new System.Drawing.Point(184, 135);
            this.WATERLV.Name = "WATERLV";
            this.WATERLV.Size = new System.Drawing.Size(115, 32);
            this.WATERLV.TabIndex = 86;
            this.WATERLV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(299, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 24);
            this.label19.TabIndex = 90;
            this.label19.Text = "(m)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(299, 182);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 22);
            this.label18.TabIndex = 89;
            this.label18.Text = "(10^4 m^3)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(0, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(299, 61);
            this.label6.TabIndex = 84;
            this.label6.Text = "DAM STATUS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 27);
            this.label2.TabIndex = 76;
            this.label2.Text = "STORAGE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 27);
            this.label1.TabIndex = 77;
            this.label1.Text = "WATER LEVEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 27);
            this.label3.TabIndex = 80;
            this.label3.Text = "TOTAL INFLOW";
            // 
            // OP3
            // 
            this.OP3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OP3.Location = new System.Drawing.Point(645, 216);
            this.OP3.Name = "OP3";
            this.OP3.Size = new System.Drawing.Size(91, 26);
            this.OP3.TabIndex = 139;
            this.OP3.Text = "0";
            this.OP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(550, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 24);
            this.label13.TabIndex = 135;
            this.label13.Text = "OUTFLOW";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(550, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 24);
            this.label16.TabIndex = 136;
            this.label16.Text = "OPENING";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(550, 245);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 24);
            this.label17.TabIndex = 138;
            this.label17.Text = "STATUS";
            // 
            // OP2
            // 
            this.OP2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OP2.Location = new System.Drawing.Point(645, 123);
            this.OP2.Name = "OP2";
            this.OP2.Size = new System.Drawing.Size(91, 26);
            this.OP2.TabIndex = 133;
            this.OP2.Text = "0";
            this.OP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(550, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 24);
            this.label9.TabIndex = 129;
            this.label9.Text = "OUTFLOW";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(550, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 24);
            this.label10.TabIndex = 130;
            this.label10.Text = "OPENING";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(550, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 24);
            this.label12.TabIndex = 132;
            this.label12.Text = "STATUS";
            // 
            // OP1
            // 
            this.OP1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OP1.Location = new System.Drawing.Point(646, 37);
            this.OP1.Name = "OP1";
            this.OP1.Size = new System.Drawing.Size(90, 26);
            this.OP1.TabIndex = 127;
            this.OP1.Text = "0";
            this.OP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(432, 184);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 40);
            this.label20.TabIndex = 126;
            this.label20.Text = "GATE3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(431, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 40);
            this.label8.TabIndex = 119;
            this.label8.Text = "GATE2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(432, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 40);
            this.label7.TabIndex = 93;
            this.label7.Text = "GATE1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(550, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 24);
            this.label14.TabIndex = 86;
            this.label14.Text = "OPENING";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(550, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 24);
            this.label11.TabIndex = 89;
            this.label11.Text = "STATUS";
            // 
            // Operate_timer
            // 
            this.Operate_timer.Interval = 1000;
            this.Operate_timer.Tick += new System.EventHandler(this.Operate_timer_Tick);
            // 
            // Clock_timer
            // 
            this.Clock_timer.Enabled = true;
            this.Clock_timer.Interval = 1000;
            this.Clock_timer.Tick += new System.EventHandler(this.Clock_timer_Tick);
            // 
            // LOAD
            // 
            this.LOAD.BackColor = System.Drawing.Color.White;
            this.LOAD.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOAD.ForeColor = System.Drawing.Color.Black;
            this.LOAD.Location = new System.Drawing.Point(6, 337);
            this.LOAD.Name = "LOAD";
            this.LOAD.Size = new System.Drawing.Size(211, 46);
            this.LOAD.TabIndex = 127;
            this.LOAD.Text = "LOAD";
            this.LOAD.UseVisualStyleBackColor = false;
            this.LOAD.Click += new System.EventHandler(this.LOAD_Click);
            // 
            // Show
            // 
            this.Show.Location = new System.Drawing.Point(6, 389);
            this.Show.Multiline = true;
            this.Show.Name = "Show";
            this.Show.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Show.Size = new System.Drawing.Size(800, 197);
            this.Show.TabIndex = 128;
            // 
            // DataCounter
            // 
            this.DataCounter.AutoSize = true;
            this.DataCounter.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DataCounter.ForeColor = System.Drawing.Color.Black;
            this.DataCounter.Location = new System.Drawing.Point(261, 594);
            this.DataCounter.Name = "DataCounter";
            this.DataCounter.Size = new System.Drawing.Size(27, 30);
            this.DataCounter.TabIndex = 129;
            this.DataCounter.Text = "0";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(5, 594);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(177, 30);
            this.label31.TabIndex = 130;
            this.label31.Text = "DataCounter : ";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(304, 594);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(189, 30);
            this.label32.TabIndex = 131;
            this.label32.Text = "InputData_idx : ";
            // 
            // InputData_idx_counter
            // 
            this.InputData_idx_counter.AutoSize = true;
            this.InputData_idx_counter.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.InputData_idx_counter.ForeColor = System.Drawing.Color.Black;
            this.InputData_idx_counter.Location = new System.Drawing.Point(571, 594);
            this.InputData_idx_counter.Name = "InputData_idx_counter";
            this.InputData_idx_counter.Size = new System.Drawing.Size(27, 30);
            this.InputData_idx_counter.TabIndex = 132;
            this.InputData_idx_counter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(813, 633);
            this.Controls.Add(this.InputData_idx_counter);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.DataCounter);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.LOAD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.STOP);
            this.Controls.Add(this.CLOCK);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.RUN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RUN;
        private System.Windows.Forms.Button STOP;
        private System.Windows.Forms.Button EXIT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label CLOCK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Operate_timer;
        private System.Windows.Forms.Timer Clock_timer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button LOAD;
        private System.Windows.Forms.TextBox OP3;
        private System.Windows.Forms.TextBox OUT3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox OP2;
        private System.Windows.Forms.TextBox OUT2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox OP1;
        private System.Windows.Forms.TextBox OUT1;
        private System.Windows.Forms.TextBox OUTtot;
        private System.Windows.Forms.TextBox INtot;
        private System.Windows.Forms.TextBox WATERLV;
        private System.Windows.Forms.TextBox STORAGE;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label STAT2;
        private System.Windows.Forms.Label STAT3;
        private System.Windows.Forms.Label STAT1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox STORAGEvar;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Show;
        private System.Windows.Forms.Label DataCounter;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label InputData_idx_counter;
    }
}

