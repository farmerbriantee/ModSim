
namespace ModSim
{
    partial class FormSim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSim));
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurentLon = new System.Windows.Forms.Label();
            this.lblCurrentLat = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripEthernet = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblWASCounts = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSwitchStatus = new System.Windows.Forms.Label();
            this.lblWorkSwitchStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl1To8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl9To16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRemoteAutoSteer = new System.Windows.Forms.Button();
            this.btnWorkSwitch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxKSXT = new System.Windows.Forms.CheckBox();
            this.cboxNDA = new System.Windows.Forms.CheckBox();
            this.lblWAS = new System.Windows.Forms.Label();
            this.tbarSteerAngleWAS = new System.Windows.Forms.TrackBar();
            this.Heading = new System.Windows.Forms.Label();
            this.cboxOGI = new System.Windows.Forms.CheckBox();
            this.cboxRMC = new System.Windows.Forms.CheckBox();
            this.cboxGGA = new System.Windows.Forms.CheckBox();
            this.Kmh = new System.Windows.Forms.Label();
            this.mSec = new System.Windows.Forms.Label();
            this.cboxHDT = new System.Windows.Forms.CheckBox();
            this.cboxAVR = new System.Windows.Forms.CheckBox();
            this.cboxVTG = new System.Windows.Forms.CheckBox();
            this.tbarSpeed = new System.Windows.Forms.TrackBar();
            this.simTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSteerAngleWAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(478, 330);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 151;
            this.label6.Text = "Lat";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(475, 352);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 16);
            this.label8.TabIndex = 152;
            this.label8.Text = "Lon";
            // 
            // lblCurentLon
            // 
            this.lblCurentLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurentLon.AutoSize = true;
            this.lblCurentLon.BackColor = System.Drawing.Color.Transparent;
            this.lblCurentLon.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurentLon.ForeColor = System.Drawing.Color.Black;
            this.lblCurentLon.Location = new System.Drawing.Point(502, 351);
            this.lblCurentLon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurentLon.Name = "lblCurentLon";
            this.lblCurentLon.Size = new System.Drawing.Size(119, 18);
            this.lblCurentLon.TabIndex = 154;
            this.lblCurentLon.Text = "-888.8888888";
            // 
            // lblCurrentLat
            // 
            this.lblCurrentLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentLat.AutoSize = true;
            this.lblCurrentLat.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentLat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLat.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentLat.Location = new System.Drawing.Point(502, 329);
            this.lblCurrentLat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentLat.Name = "lblCurrentLat";
            this.lblCurrentLat.Size = new System.Drawing.Size(109, 18);
            this.lblCurrentLat.TabIndex = 153;
            this.lblCurrentLat.Text = "-53.1234567";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(471, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(106, 70);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 149;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEthernet,
            this.deviceManagerToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::ModSim.Properties.Resources.Settings48;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(90, 68);
            // 
            // toolStripEthernet
            // 
            this.toolStripEthernet.Name = "toolStripEthernet";
            this.toolStripEthernet.Size = new System.Drawing.Size(296, 70);
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceManagerToolStripMenuItem.Image = global::ModSim.Properties.Resources.DeviceManager;
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(296, 70);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // lblIP
            // 
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.Color.Black;
            this.lblIP.Location = new System.Drawing.Point(8, 4);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(144, 56);
            this.lblIP.TabIndex = 464;
            this.lblIP.Text = "288.288.288.288";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblIP.Click += new System.EventHandler(this.lblIP_Click);
            // 
            // lblWASCounts
            // 
            this.lblWASCounts.AutoSize = true;
            this.lblWASCounts.BackColor = System.Drawing.Color.Transparent;
            this.lblWASCounts.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWASCounts.ForeColor = System.Drawing.Color.Black;
            this.lblWASCounts.Location = new System.Drawing.Point(90, 135);
            this.lblWASCounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWASCounts.Name = "lblWASCounts";
            this.lblWASCounts.Size = new System.Drawing.Size(43, 18);
            this.lblWASCounts.TabIndex = 476;
            this.lblWASCounts.Text = "Only";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 477;
            this.label3.Text = "Angle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(29, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 478;
            this.label4.Text = "Counts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 481;
            this.label2.Text = "Switch:";
            // 
            // lblSwitchStatus
            // 
            this.lblSwitchStatus.AutoSize = true;
            this.lblSwitchStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblSwitchStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitchStatus.ForeColor = System.Drawing.Color.Black;
            this.lblSwitchStatus.Location = new System.Drawing.Point(90, 170);
            this.lblSwitchStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSwitchStatus.Name = "lblSwitchStatus";
            this.lblSwitchStatus.Size = new System.Drawing.Size(18, 18);
            this.lblSwitchStatus.TabIndex = 482;
            this.lblSwitchStatus.Text = "*";
            // 
            // lblWorkSwitchStatus
            // 
            this.lblWorkSwitchStatus.AutoSize = true;
            this.lblWorkSwitchStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkSwitchStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkSwitchStatus.ForeColor = System.Drawing.Color.Black;
            this.lblWorkSwitchStatus.Location = new System.Drawing.Point(90, 193);
            this.lblWorkSwitchStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkSwitchStatus.Name = "lblWorkSwitchStatus";
            this.lblWorkSwitchStatus.Size = new System.Drawing.Size(18, 18);
            this.lblWorkSwitchStatus.TabIndex = 484;
            this.lblWorkSwitchStatus.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(38, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 19);
            this.label9.TabIndex = 483;
            this.label9.Text = "Work:";
            // 
            // lbl1To8
            // 
            this.lbl1To8.AutoSize = true;
            this.lbl1To8.BackColor = System.Drawing.Color.Transparent;
            this.lbl1To8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1To8.ForeColor = System.Drawing.Color.Black;
            this.lbl1To8.Location = new System.Drawing.Point(27, 255);
            this.lbl1To8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1To8.Name = "lbl1To8";
            this.lbl1To8.Size = new System.Drawing.Size(106, 23);
            this.lbl1To8.TabIndex = 500;
            this.lbl1To8.Text = "00000000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(27, 235);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 19);
            this.label10.TabIndex = 499;
            this.label10.Text = "8     <<      1";
            // 
            // lbl9To16
            // 
            this.lbl9To16.AutoSize = true;
            this.lbl9To16.BackColor = System.Drawing.Color.Transparent;
            this.lbl9To16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9To16.ForeColor = System.Drawing.Color.Black;
            this.lbl9To16.Location = new System.Drawing.Point(27, 307);
            this.lbl9To16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl9To16.Name = "lbl9To16";
            this.lbl9To16.Size = new System.Drawing.Size(106, 23);
            this.lbl9To16.TabIndex = 502;
            this.lbl9To16.Text = "00000000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(27, 286);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 19);
            this.label12.TabIndex = 501;
            this.label12.Text = "16    <<     9";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::ModSim.Properties.Resources.Cancel64;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(583, 389);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 58);
            this.btnExit.TabIndex = 192;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRemoteAutoSteer
            // 
            this.btnRemoteAutoSteer.Location = new System.Drawing.Point(29, 29);
            this.btnRemoteAutoSteer.Name = "btnRemoteAutoSteer";
            this.btnRemoteAutoSteer.Size = new System.Drawing.Size(61, 45);
            this.btnRemoteAutoSteer.TabIndex = 514;
            this.btnRemoteAutoSteer.Text = "Steer";
            this.btnRemoteAutoSteer.UseVisualStyleBackColor = true;
            this.btnRemoteAutoSteer.Click += new System.EventHandler(this.btnRemoteAutoSteer_Click);
            // 
            // btnWorkSwitch
            // 
            this.btnWorkSwitch.Location = new System.Drawing.Point(113, 29);
            this.btnWorkSwitch.Name = "btnWorkSwitch";
            this.btnWorkSwitch.Size = new System.Drawing.Size(55, 45);
            this.btnWorkSwitch.TabIndex = 515;
            this.btnWorkSwitch.Text = "Work";
            this.btnWorkSwitch.UseVisualStyleBackColor = true;
            this.btnWorkSwitch.Click += new System.EventHandler(this.btnWorkSwitch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoteAutoSteer);
            this.groupBox1.Controls.Add(this.btnWorkSwitch);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblWASCounts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblSwitchStatus);
            this.groupBox1.Controls.Add(this.lblWorkSwitchStatus);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl1To8);
            this.groupBox1.Controls.Add(this.lbl9To16);
            this.groupBox1.Location = new System.Drawing.Point(223, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 359);
            this.groupBox1.TabIndex = 516;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steer Module";
            // 
            // cboxKSXT
            // 
            this.cboxKSXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxKSXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxKSXT.Location = new System.Drawing.Point(562, 288);
            this.cboxKSXT.Name = "cboxKSXT";
            this.cboxKSXT.Size = new System.Drawing.Size(80, 24);
            this.cboxKSXT.TabIndex = 537;
            this.cboxKSXT.Text = "KSXT";
            this.cboxKSXT.UseVisualStyleBackColor = true;
            // 
            // cboxNDA
            // 
            this.cboxNDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxNDA.Checked = true;
            this.cboxNDA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxNDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxNDA.Location = new System.Drawing.Point(460, 288);
            this.cboxNDA.Name = "cboxNDA";
            this.cboxNDA.Size = new System.Drawing.Size(69, 24);
            this.cboxNDA.TabIndex = 536;
            this.cboxNDA.Text = "NDA";
            this.cboxNDA.UseVisualStyleBackColor = true;
            // 
            // lblWAS
            // 
            this.lblWAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWAS.Location = new System.Drawing.Point(424, 21);
            this.lblWAS.Name = "lblWAS";
            this.lblWAS.Size = new System.Drawing.Size(206, 26);
            this.lblWAS.TabIndex = 535;
            this.lblWAS.Text = "Steer Angle: 0°";
            this.lblWAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWAS.Click += new System.EventHandler(this.lblWAS_Click);
            // 
            // tbarSteerAngleWAS
            // 
            this.tbarSteerAngleWAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarSteerAngleWAS.LargeChange = 1;
            this.tbarSteerAngleWAS.Location = new System.Drawing.Point(413, 56);
            this.tbarSteerAngleWAS.Maximum = 6000;
            this.tbarSteerAngleWAS.Minimum = -6000;
            this.tbarSteerAngleWAS.Name = "tbarSteerAngleWAS";
            this.tbarSteerAngleWAS.Size = new System.Drawing.Size(229, 45);
            this.tbarSteerAngleWAS.TabIndex = 534;
            this.tbarSteerAngleWAS.TickFrequency = 100;
            this.tbarSteerAngleWAS.Scroll += new System.EventHandler(this.tbarSteerAngleWAS_Scroll);
            // 
            // Heading
            // 
            this.Heading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.Location = new System.Drawing.Point(464, 99);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(127, 20);
            this.Heading.TabIndex = 524;
            this.Heading.Text = "Heading: 112°";
            this.Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxOGI
            // 
            this.cboxOGI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxOGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxOGI.Location = new System.Drawing.Point(460, 260);
            this.cboxOGI.Name = "cboxOGI";
            this.cboxOGI.Size = new System.Drawing.Size(69, 24);
            this.cboxOGI.TabIndex = 532;
            this.cboxOGI.Text = "OGI";
            this.cboxOGI.UseVisualStyleBackColor = true;
            // 
            // cboxRMC
            // 
            this.cboxRMC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxRMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRMC.Location = new System.Drawing.Point(562, 259);
            this.cboxRMC.Name = "cboxRMC";
            this.cboxRMC.Size = new System.Drawing.Size(69, 24);
            this.cboxRMC.TabIndex = 531;
            this.cboxRMC.Text = "RMC";
            this.cboxRMC.UseVisualStyleBackColor = true;
            // 
            // cboxGGA
            // 
            this.cboxGGA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxGGA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxGGA.Location = new System.Drawing.Point(460, 201);
            this.cboxGGA.Name = "cboxGGA";
            this.cboxGGA.Size = new System.Drawing.Size(69, 24);
            this.cboxGGA.TabIndex = 530;
            this.cboxGGA.Text = "GGA";
            this.cboxGGA.UseVisualStyleBackColor = true;
            // 
            // Kmh
            // 
            this.Kmh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Kmh.AutoSize = true;
            this.Kmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kmh.Location = new System.Drawing.Point(421, 132);
            this.Kmh.Name = "Kmh";
            this.Kmh.Size = new System.Drawing.Size(79, 20);
            this.Kmh.TabIndex = 529;
            this.Kmh.Text = "Kmh: 0.0";
            // 
            // mSec
            // 
            this.mSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mSec.AutoSize = true;
            this.mSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSec.Location = new System.Drawing.Point(543, 134);
            this.mSec.Name = "mSec";
            this.mSec.Size = new System.Drawing.Size(79, 16);
            this.mSec.TabIndex = 528;
            this.mSec.Text = "M/Sec: 0.0";
            // 
            // cboxHDT
            // 
            this.cboxHDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxHDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHDT.Location = new System.Drawing.Point(562, 230);
            this.cboxHDT.Name = "cboxHDT";
            this.cboxHDT.Size = new System.Drawing.Size(69, 24);
            this.cboxHDT.TabIndex = 527;
            this.cboxHDT.Text = "HDT";
            this.cboxHDT.UseVisualStyleBackColor = true;
            // 
            // cboxAVR
            // 
            this.cboxAVR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxAVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAVR.Location = new System.Drawing.Point(562, 201);
            this.cboxAVR.Name = "cboxAVR";
            this.cboxAVR.Size = new System.Drawing.Size(69, 24);
            this.cboxAVR.TabIndex = 526;
            this.cboxAVR.Text = "AVR";
            this.cboxAVR.UseVisualStyleBackColor = true;
            // 
            // cboxVTG
            // 
            this.cboxVTG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxVTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxVTG.Location = new System.Drawing.Point(460, 230);
            this.cboxVTG.Name = "cboxVTG";
            this.cboxVTG.Size = new System.Drawing.Size(69, 24);
            this.cboxVTG.TabIndex = 525;
            this.cboxVTG.Text = "VTG";
            this.cboxVTG.UseVisualStyleBackColor = true;
            // 
            // tbarSpeed
            // 
            this.tbarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarSpeed.LargeChange = 10;
            this.tbarSpeed.Location = new System.Drawing.Point(414, 151);
            this.tbarSpeed.Maximum = 500;
            this.tbarSpeed.Minimum = -200;
            this.tbarSpeed.Name = "tbarSpeed";
            this.tbarSpeed.Size = new System.Drawing.Size(229, 45);
            this.tbarSpeed.TabIndex = 519;
            this.tbarSpeed.TickFrequency = 50;
            this.tbarSpeed.Scroll += new System.EventHandler(this.tbarSpeed_Scroll);
            // 
            // simTimer
            // 
            this.simTimer.Enabled = true;
            this.simTimer.Tick += new System.EventHandler(this.simTimer_Tick);
            // 
            // FormSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(654, 455);
            this.Controls.Add(this.cboxKSXT);
            this.Controls.Add(this.cboxNDA);
            this.Controls.Add(this.lblWAS);
            this.Controls.Add(this.tbarSteerAngleWAS);
            this.Controls.Add(this.Heading);
            this.Controls.Add(this.cboxOGI);
            this.Controls.Add(this.cboxRMC);
            this.Controls.Add(this.cboxGGA);
            this.Controls.Add(this.Kmh);
            this.Controls.Add(this.mSec);
            this.Controls.Add(this.cboxHDT);
            this.Controls.Add(this.cboxAVR);
            this.Controls.Add(this.cboxVTG);
            this.Controls.Add(this.tbarSpeed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblCurentLon);
            this.Controls.Add(this.lblCurrentLat);
            this.Controls.Add(this.lblIP);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "FormSim";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Module Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSim_FormClosing);
            this.Load += new System.EventHandler(this.FormSim_Load);
            this.Resize += new System.EventHandler(this.FormSim_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSteerAngleWAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurentLon;
        private System.Windows.Forms.Label lblCurrentLat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblWASCounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSwitchStatus;
        private System.Windows.Forms.Label lblWorkSwitchStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl1To8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl9To16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem toolStripEthernet;
        private System.Windows.Forms.Button btnRemoteAutoSteer;
        private System.Windows.Forms.Button btnWorkSwitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cboxKSXT;
        private System.Windows.Forms.CheckBox cboxNDA;
        private System.Windows.Forms.Label lblWAS;
        private System.Windows.Forms.TrackBar tbarSteerAngleWAS;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.CheckBox cboxOGI;
        private System.Windows.Forms.CheckBox cboxRMC;
        private System.Windows.Forms.CheckBox cboxGGA;
        private System.Windows.Forms.Label Kmh;
        private System.Windows.Forms.Label mSec;
        private System.Windows.Forms.CheckBox cboxHDT;
        private System.Windows.Forms.CheckBox cboxAVR;
        private System.Windows.Forms.CheckBox cboxVTG;
        private System.Windows.Forms.TrackBar tbarSpeed;
        private System.Windows.Forms.Timer simTimer;
    }
}

