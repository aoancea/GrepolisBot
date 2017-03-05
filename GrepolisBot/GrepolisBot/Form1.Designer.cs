namespace GrepolisBot
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			AbortThreadExecution();

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadResources = new System.Windows.Forms.Button();
            this.cbxRandomizeTimer = new System.Windows.Forms.CheckBox();
            this.cbxWarehouseOptimization = new System.Windows.Forms.CheckBox();
            this.chkHideFarmingDialog = new System.Windows.Forms.CheckBox();
            this.cbxHideInTray = new System.Windows.Forms.CheckBox();
            this.lblFarmCountDown = new System.Windows.Forms.Label();
            this.rdoLoot = new System.Windows.Forms.RadioButton();
            this.rdoDemand = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbxCity4 = new System.Windows.Forms.GroupBox();
            this.btnResetCity4 = new System.Windows.Forms.Button();
            this.lblCityTimer4 = new System.Windows.Forms.Label();
            this.lblCityName4 = new System.Windows.Forms.Label();
            this.gbxCity3 = new System.Windows.Forms.GroupBox();
            this.btnResetCity3 = new System.Windows.Forms.Button();
            this.lblCityTimer3 = new System.Windows.Forms.Label();
            this.lblCityName3 = new System.Windows.Forms.Label();
            this.gbxCity2 = new System.Windows.Forms.GroupBox();
            this.btnResetCity2 = new System.Windows.Forms.Button();
            this.lblCityTimer2 = new System.Windows.Forms.Label();
            this.lblCityName2 = new System.Windows.Forms.Label();
            this.gbxCity1 = new System.Windows.Forms.GroupBox();
            this.btnResetCity1 = new System.Windows.Forms.Button();
            this.lblCityTimer1 = new System.Windows.Forms.Label();
            this.lblCityName1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxCity4.SuspendLayout();
            this.gbxCity3.SuspendLayout();
            this.gbxCity2.SuspendLayout();
            this.gbxCity1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(6, 61);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1220, 524);
            this.webBrowser1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadResources);
            this.groupBox1.Controls.Add(this.cbxRandomizeTimer);
            this.groupBox1.Controls.Add(this.cbxWarehouseOptimization);
            this.groupBox1.Controls.Add(this.chkHideFarmingDialog);
            this.groupBox1.Controls.Add(this.cbxHideInTray);
            this.groupBox1.Controls.Add(this.lblFarmCountDown);
            this.groupBox1.Controls.Add(this.rdoLoot);
            this.groupBox1.Controls.Add(this.rdoDemand);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1220, 49);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnLoadResources
            // 
            this.btnLoadResources.Location = new System.Drawing.Point(968, 19);
            this.btnLoadResources.Name = "btnLoadResources";
            this.btnLoadResources.Size = new System.Drawing.Size(95, 23);
            this.btnLoadResources.TabIndex = 18;
            this.btnLoadResources.Text = "Load Resources";
            this.btnLoadResources.UseVisualStyleBackColor = true;
            this.btnLoadResources.Click += new System.EventHandler(this.btnLoadResources_Click);
            // 
            // cbxRandomizeTimer
            // 
            this.cbxRandomizeTimer.AutoSize = true;
            this.cbxRandomizeTimer.Checked = true;
            this.cbxRandomizeTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRandomizeTimer.Location = new System.Drawing.Point(858, 23);
            this.cbxRandomizeTimer.Name = "cbxRandomizeTimer";
            this.cbxRandomizeTimer.Size = new System.Drawing.Size(104, 17);
            this.cbxRandomizeTimer.TabIndex = 17;
            this.cbxRandomizeTimer.Text = "Randomize timer";
            this.cbxRandomizeTimer.UseVisualStyleBackColor = true;
            this.cbxRandomizeTimer.CheckedChanged += new System.EventHandler(this.cbxRandomizeTimer_CheckedChanged);
            // 
            // cbxWarehouseOptimization
            // 
            this.cbxWarehouseOptimization.AutoSize = true;
            this.cbxWarehouseOptimization.Checked = true;
            this.cbxWarehouseOptimization.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxWarehouseOptimization.Location = new System.Drawing.Point(713, 23);
            this.cbxWarehouseOptimization.Name = "cbxWarehouseOptimization";
            this.cbxWarehouseOptimization.Size = new System.Drawing.Size(139, 17);
            this.cbxWarehouseOptimization.TabIndex = 16;
            this.cbxWarehouseOptimization.Text = "Warehouse optimization";
            this.cbxWarehouseOptimization.UseVisualStyleBackColor = true;
            this.cbxWarehouseOptimization.CheckedChanged += new System.EventHandler(this.cbxWarehouseOptimization_CheckedChanged);
            // 
            // chkHideFarmingDialog
            // 
            this.chkHideFarmingDialog.AutoSize = true;
            this.chkHideFarmingDialog.Location = new System.Drawing.Point(605, 23);
            this.chkHideFarmingDialog.Name = "chkHideFarmingDialog";
            this.chkHideFarmingDialog.Size = new System.Drawing.Size(102, 17);
            this.chkHideFarmingDialog.TabIndex = 15;
            this.chkHideFarmingDialog.Text = "Hide farm dialog";
            this.chkHideFarmingDialog.UseVisualStyleBackColor = true;
            this.chkHideFarmingDialog.CheckedChanged += new System.EventHandler(this.chkHideFarmingDialog_CheckedChanged);
            // 
            // cbxHideInTray
            // 
            this.cbxHideInTray.AutoSize = true;
            this.cbxHideInTray.Location = new System.Drawing.Point(521, 23);
            this.cbxHideInTray.Name = "cbxHideInTray";
            this.cbxHideInTray.Size = new System.Drawing.Size(78, 17);
            this.cbxHideInTray.TabIndex = 14;
            this.cbxHideInTray.Text = "HideInTray";
            this.cbxHideInTray.UseVisualStyleBackColor = true;
            // 
            // lblFarmCountDown
            // 
            this.lblFarmCountDown.AutoSize = true;
            this.lblFarmCountDown.Location = new System.Drawing.Point(1085, 24);
            this.lblFarmCountDown.Name = "lblFarmCountDown";
            this.lblFarmCountDown.Size = new System.Drawing.Size(33, 13);
            this.lblFarmCountDown.TabIndex = 13;
            this.lblFarmCountDown.Text = "Timer";
            // 
            // rdoLoot
            // 
            this.rdoLoot.AutoSize = true;
            this.rdoLoot.Location = new System.Drawing.Point(326, 22);
            this.rdoLoot.Name = "rdoLoot";
            this.rdoLoot.Size = new System.Drawing.Size(46, 17);
            this.rdoLoot.TabIndex = 11;
            this.rdoLoot.TabStop = true;
            this.rdoLoot.Text = "Loot";
            this.rdoLoot.UseVisualStyleBackColor = true;
            this.rdoLoot.CheckedChanged += new System.EventHandler(this.rdoLoot_CheckedChanged);
            // 
            // rdoDemand
            // 
            this.rdoDemand.AutoSize = true;
            this.rdoDemand.Location = new System.Drawing.Point(234, 22);
            this.rdoDemand.Name = "rdoDemand";
            this.rdoDemand.Size = new System.Drawing.Size(65, 17);
            this.rdoDemand.TabIndex = 10;
            this.rdoDemand.TabStop = true;
            this.rdoDemand.Text = "Demand";
            this.rdoDemand.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(390, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start with captain";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "https://grepolis.com/";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Hello!";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 617);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 591);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 591);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbxCity4);
            this.groupBox2.Controls.Add(this.gbxCity3);
            this.groupBox2.Controls.Add(this.gbxCity2);
            this.groupBox2.Controls.Add(this.gbxCity1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1226, 585);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resources arrival";
            // 
            // gbxCity4
            // 
            this.gbxCity4.Controls.Add(this.btnResetCity4);
            this.gbxCity4.Controls.Add(this.lblCityTimer4);
            this.gbxCity4.Controls.Add(this.lblCityName4);
            this.gbxCity4.Location = new System.Drawing.Point(6, 238);
            this.gbxCity4.Name = "gbxCity4";
            this.gbxCity4.Size = new System.Drawing.Size(279, 67);
            this.gbxCity4.TabIndex = 3;
            this.gbxCity4.TabStop = false;
            this.gbxCity4.Text = "#4";
            // 
            // btnResetCity4
            // 
            this.btnResetCity4.Location = new System.Drawing.Point(198, 38);
            this.btnResetCity4.Name = "btnResetCity4";
            this.btnResetCity4.Size = new System.Drawing.Size(75, 23);
            this.btnResetCity4.TabIndex = 5;
            this.btnResetCity4.Text = "Reset";
            this.btnResetCity4.UseVisualStyleBackColor = true;
            this.btnResetCity4.Click += new System.EventHandler(this.btnResetCity4_Click);
            // 
            // lblCityTimer4
            // 
            this.lblCityTimer4.AutoSize = true;
            this.lblCityTimer4.Location = new System.Drawing.Point(97, 26);
            this.lblCityTimer4.Name = "lblCityTimer4";
            this.lblCityTimer4.Size = new System.Drawing.Size(29, 13);
            this.lblCityTimer4.TabIndex = 1;
            this.lblCityTimer4.Text = "timer";
            // 
            // lblCityName4
            // 
            this.lblCityName4.AutoSize = true;
            this.lblCityName4.Location = new System.Drawing.Point(6, 26);
            this.lblCityName4.Name = "lblCityName4";
            this.lblCityName4.Size = new System.Drawing.Size(65, 13);
            this.lblCityName4.TabIndex = 0;
            this.lblCityName4.Text = "lblCityName:";
            // 
            // gbxCity3
            // 
            this.gbxCity3.Controls.Add(this.btnResetCity3);
            this.gbxCity3.Controls.Add(this.lblCityTimer3);
            this.gbxCity3.Controls.Add(this.lblCityName3);
            this.gbxCity3.Location = new System.Drawing.Point(6, 165);
            this.gbxCity3.Name = "gbxCity3";
            this.gbxCity3.Size = new System.Drawing.Size(279, 67);
            this.gbxCity3.TabIndex = 2;
            this.gbxCity3.TabStop = false;
            this.gbxCity3.Text = "#3";
            // 
            // btnResetCity3
            // 
            this.btnResetCity3.Location = new System.Drawing.Point(198, 38);
            this.btnResetCity3.Name = "btnResetCity3";
            this.btnResetCity3.Size = new System.Drawing.Size(75, 23);
            this.btnResetCity3.TabIndex = 6;
            this.btnResetCity3.Text = "Reset";
            this.btnResetCity3.UseVisualStyleBackColor = true;
            this.btnResetCity3.Click += new System.EventHandler(this.btnResetCity3_Click);
            // 
            // lblCityTimer3
            // 
            this.lblCityTimer3.AutoSize = true;
            this.lblCityTimer3.Location = new System.Drawing.Point(97, 26);
            this.lblCityTimer3.Name = "lblCityTimer3";
            this.lblCityTimer3.Size = new System.Drawing.Size(29, 13);
            this.lblCityTimer3.TabIndex = 1;
            this.lblCityTimer3.Text = "timer";
            // 
            // lblCityName3
            // 
            this.lblCityName3.AutoSize = true;
            this.lblCityName3.Location = new System.Drawing.Point(6, 26);
            this.lblCityName3.Name = "lblCityName3";
            this.lblCityName3.Size = new System.Drawing.Size(65, 13);
            this.lblCityName3.TabIndex = 0;
            this.lblCityName3.Text = "lblCityName:";
            // 
            // gbxCity2
            // 
            this.gbxCity2.Controls.Add(this.btnResetCity2);
            this.gbxCity2.Controls.Add(this.lblCityTimer2);
            this.gbxCity2.Controls.Add(this.lblCityName2);
            this.gbxCity2.Location = new System.Drawing.Point(6, 92);
            this.gbxCity2.Name = "gbxCity2";
            this.gbxCity2.Size = new System.Drawing.Size(279, 67);
            this.gbxCity2.TabIndex = 1;
            this.gbxCity2.TabStop = false;
            this.gbxCity2.Text = "#2";
            // 
            // btnResetCity2
            // 
            this.btnResetCity2.Location = new System.Drawing.Point(198, 38);
            this.btnResetCity2.Name = "btnResetCity2";
            this.btnResetCity2.Size = new System.Drawing.Size(75, 23);
            this.btnResetCity2.TabIndex = 7;
            this.btnResetCity2.Text = "Reset";
            this.btnResetCity2.UseVisualStyleBackColor = true;
            this.btnResetCity2.Click += new System.EventHandler(this.btnResetCity2_Click);
            // 
            // lblCityTimer2
            // 
            this.lblCityTimer2.AutoSize = true;
            this.lblCityTimer2.Location = new System.Drawing.Point(97, 26);
            this.lblCityTimer2.Name = "lblCityTimer2";
            this.lblCityTimer2.Size = new System.Drawing.Size(29, 13);
            this.lblCityTimer2.TabIndex = 1;
            this.lblCityTimer2.Text = "timer";
            // 
            // lblCityName2
            // 
            this.lblCityName2.AutoSize = true;
            this.lblCityName2.Location = new System.Drawing.Point(6, 26);
            this.lblCityName2.Name = "lblCityName2";
            this.lblCityName2.Size = new System.Drawing.Size(65, 13);
            this.lblCityName2.TabIndex = 0;
            this.lblCityName2.Text = "lblCityName:";
            // 
            // gbxCity1
            // 
            this.gbxCity1.Controls.Add(this.btnResetCity1);
            this.gbxCity1.Controls.Add(this.lblCityTimer1);
            this.gbxCity1.Controls.Add(this.lblCityName1);
            this.gbxCity1.Location = new System.Drawing.Point(6, 19);
            this.gbxCity1.Name = "gbxCity1";
            this.gbxCity1.Size = new System.Drawing.Size(279, 67);
            this.gbxCity1.TabIndex = 0;
            this.gbxCity1.TabStop = false;
            this.gbxCity1.Text = "#1";
            // 
            // btnResetCity1
            // 
            this.btnResetCity1.Location = new System.Drawing.Point(198, 38);
            this.btnResetCity1.Name = "btnResetCity1";
            this.btnResetCity1.Size = new System.Drawing.Size(75, 23);
            this.btnResetCity1.TabIndex = 4;
            this.btnResetCity1.Text = "Reset";
            this.btnResetCity1.UseVisualStyleBackColor = true;
            this.btnResetCity1.Click += new System.EventHandler(this.btnResetCity1_Click);
            // 
            // lblCityTimer1
            // 
            this.lblCityTimer1.AutoSize = true;
            this.lblCityTimer1.Location = new System.Drawing.Point(97, 26);
            this.lblCityTimer1.Name = "lblCityTimer1";
            this.lblCityTimer1.Size = new System.Drawing.Size(29, 13);
            this.lblCityTimer1.TabIndex = 1;
            this.lblCityTimer1.Text = "timer";
            // 
            // lblCityName1
            // 
            this.lblCityName1.AutoSize = true;
            this.lblCityName1.Location = new System.Drawing.Point(6, 26);
            this.lblCityName1.Name = "lblCityName1";
            this.lblCityName1.Size = new System.Drawing.Size(65, 13);
            this.lblCityName1.TabIndex = 0;
            this.lblCityName1.Text = "lblCityName:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 634);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbxCity4.ResumeLayout(false);
            this.gbxCity4.PerformLayout();
            this.gbxCity3.ResumeLayout(false);
            this.gbxCity3.PerformLayout();
            this.gbxCity2.ResumeLayout(false);
            this.gbxCity2.PerformLayout();
            this.gbxCity1.ResumeLayout(false);
            this.gbxCity1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdoLoot;
		private System.Windows.Forms.RadioButton rdoDemand;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Label lblFarmCountDown;
		public System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.CheckBox cbxHideInTray;
		private System.Windows.Forms.CheckBox chkHideFarmingDialog;
		private System.Windows.Forms.CheckBox cbxWarehouseOptimization;
		private System.Windows.Forms.CheckBox cbxRandomizeTimer;
		private System.Windows.Forms.Button btnLoadResources;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gbxCity1;
		private System.Windows.Forms.Label lblCityTimer1;
		private System.Windows.Forms.Label lblCityName1;
		private System.Windows.Forms.GroupBox gbxCity4;
		private System.Windows.Forms.Label lblCityTimer4;
		private System.Windows.Forms.Label lblCityName4;
		private System.Windows.Forms.GroupBox gbxCity3;
		private System.Windows.Forms.Label lblCityTimer3;
		private System.Windows.Forms.Label lblCityName3;
		private System.Windows.Forms.GroupBox gbxCity2;
		private System.Windows.Forms.Label lblCityTimer2;
		private System.Windows.Forms.Label lblCityName2;
		private System.Windows.Forms.Button btnResetCity4;
		private System.Windows.Forms.Button btnResetCity3;
		private System.Windows.Forms.Button btnResetCity2;
		private System.Windows.Forms.Button btnResetCity1;
	}
}

