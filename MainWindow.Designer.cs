namespace ArcamDialNameSpace
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbShortCircuit = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbDCOffset = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTempOutput = new System.Windows.Forms.TextBox();
            this.lblTempLift = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblDirac3 = new System.Windows.Forms.TextBox();
            this.lblDirac2 = new System.Windows.Forms.TextBox();
            this.lblDirac1 = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.TextBox();
            this.lblNetworkState = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.TextBox();
            this.lblPower = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbNetwork = new System.Windows.Forms.ComboBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbForceFocus = new System.Windows.Forms.CheckBox();
            this.lblDialStatus = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblWindowStatus = new System.Windows.Forms.TextBox();
            this.cbRotateHold = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numVolPerClicks = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTripleClick = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbLongClick = new System.Windows.Forms.ComboBox();
            this.cbDoubleClick = new System.Windows.Forms.ComboBox();
            this.cbSingleClick = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSensitivity = new System.Windows.Forms.NumericUpDown();
            this.cbHaptic = new System.Windows.Forms.CheckBox();
            this.mainWindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolPerClicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(777, 330);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(62, 26);
            this.btExit.TabIndex = 16;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblError);
            this.groupBox3.Location = new System.Drawing.Point(12, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(749, 28);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Last command state";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(126, 10);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(10, 13);
            this.lblError.TabIndex = 34;
            this.lblError.Text = "-";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 322);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox2.Controls.Add(this.cbShortCircuit);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.cbDCOffset);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblTempOutput);
            this.groupBox2.Controls.Add(this.lblTempLift);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblDirac3);
            this.groupBox2.Controls.Add(this.lblDirac2);
            this.groupBox2.Controls.Add(this.lblDirac1);
            this.groupBox2.Controls.Add(this.lblFilter);
            this.groupBox2.Controls.Add(this.lblNetworkState);
            this.groupBox2.Controls.Add(this.lblBalance);
            this.groupBox2.Controls.Add(this.lblVolume);
            this.groupBox2.Controls.Add(this.lblVersion);
            this.groupBox2.Controls.Add(this.lblModel);
            this.groupBox2.Controls.Add(this.lblPower);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.cbNetwork);
            this.groupBox2.Controls.Add(this.ipLabel);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.btRefresh);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(421, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 316);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ARCAM ";
            // 
            // cbShortCircuit
            // 
            this.cbShortCircuit.AutoCheck = false;
            this.cbShortCircuit.AutoSize = true;
            this.cbShortCircuit.BackColor = System.Drawing.Color.Transparent;
            this.cbShortCircuit.Location = new System.Drawing.Point(306, 253);
            this.cbShortCircuit.Name = "cbShortCircuit";
            this.cbShortCircuit.Size = new System.Drawing.Size(15, 14);
            this.cbShortCircuit.TabIndex = 58;
            this.cbShortCircuit.UseVisualStyleBackColor = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(222, 253);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 13);
            this.label24.TabIndex = 57;
            this.label24.Text = "Short circuit";
            // 
            // cbDCOffset
            // 
            this.cbDCOffset.AutoCheck = false;
            this.cbDCOffset.AutoSize = true;
            this.cbDCOffset.BackColor = System.Drawing.Color.Transparent;
            this.cbDCOffset.Location = new System.Drawing.Point(135, 253);
            this.cbDCOffset.Name = "cbDCOffset";
            this.cbDCOffset.Size = new System.Drawing.Size(15, 14);
            this.cbDCOffset.TabIndex = 56;
            this.cbDCOffset.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(8, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "DC  Offset";
            // 
            // lblTempOutput
            // 
            this.lblTempOutput.Location = new System.Drawing.Point(261, 225);
            this.lblTempOutput.Name = "lblTempOutput";
            this.lblTempOutput.ReadOnly = true;
            this.lblTempOutput.Size = new System.Drawing.Size(59, 20);
            this.lblTempOutput.TabIndex = 54;
            this.lblTempOutput.TabStop = false;
            // 
            // lblTempLift
            // 
            this.lblTempLift.Location = new System.Drawing.Point(156, 225);
            this.lblTempLift.Name = "lblTempLift";
            this.lblTempLift.ReadOnly = true;
            this.lblTempLift.Size = new System.Drawing.Size(59, 20);
            this.lblTempLift.TabIndex = 53;
            this.lblTempLift.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(132, 228);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "Lift";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(222, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 51;
            this.label19.Text = "Output";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(6, 228);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Temperatures";
            // 
            // lblDirac3
            // 
            this.lblDirac3.Location = new System.Drawing.Point(261, 199);
            this.lblDirac3.Name = "lblDirac3";
            this.lblDirac3.ReadOnly = true;
            this.lblDirac3.Size = new System.Drawing.Size(59, 20);
            this.lblDirac3.TabIndex = 49;
            this.lblDirac3.TabStop = false;
            // 
            // lblDirac2
            // 
            this.lblDirac2.Location = new System.Drawing.Point(198, 199);
            this.lblDirac2.Name = "lblDirac2";
            this.lblDirac2.ReadOnly = true;
            this.lblDirac2.Size = new System.Drawing.Size(59, 20);
            this.lblDirac2.TabIndex = 48;
            this.lblDirac2.TabStop = false;
            // 
            // lblDirac1
            // 
            this.lblDirac1.Location = new System.Drawing.Point(135, 199);
            this.lblDirac1.Name = "lblDirac1";
            this.lblDirac1.ReadOnly = true;
            this.lblDirac1.Size = new System.Drawing.Size(59, 20);
            this.lblDirac1.TabIndex = 47;
            this.lblDirac1.TabStop = false;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(135, 173);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.ReadOnly = true;
            this.lblFilter.Size = new System.Drawing.Size(185, 20);
            this.lblFilter.TabIndex = 44;
            this.lblFilter.TabStop = false;
            // 
            // lblNetworkState
            // 
            this.lblNetworkState.Location = new System.Drawing.Point(135, 149);
            this.lblNetworkState.Name = "lblNetworkState";
            this.lblNetworkState.ReadOnly = true;
            this.lblNetworkState.Size = new System.Drawing.Size(185, 20);
            this.lblNetworkState.TabIndex = 43;
            this.lblNetworkState.TabStop = false;
            // 
            // lblBalance
            // 
            this.lblBalance.Location = new System.Drawing.Point(259, 125);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.ReadOnly = true;
            this.lblBalance.Size = new System.Drawing.Size(61, 20);
            this.lblBalance.TabIndex = 42;
            this.lblBalance.TabStop = false;
            // 
            // lblVolume
            // 
            this.lblVolume.Location = new System.Drawing.Point(135, 125);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.ReadOnly = true;
            this.lblVolume.Size = new System.Drawing.Size(75, 20);
            this.lblVolume.TabIndex = 41;
            this.lblVolume.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(135, 100);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.ReadOnly = true;
            this.lblVersion.Size = new System.Drawing.Size(185, 20);
            this.lblVersion.TabIndex = 39;
            this.lblVersion.TabStop = false;
            // 
            // lblModel
            // 
            this.lblModel.Location = new System.Drawing.Point(135, 76);
            this.lblModel.Name = "lblModel";
            this.lblModel.ReadOnly = true;
            this.lblModel.Size = new System.Drawing.Size(185, 20);
            this.lblModel.TabIndex = 38;
            this.lblModel.TabStop = false;
            // 
            // lblPower
            // 
            this.lblPower.Location = new System.Drawing.Point(135, 52);
            this.lblPower.Name = "lblPower";
            this.lblPower.ReadOnly = true;
            this.lblPower.Size = new System.Drawing.Size(185, 20);
            this.lblPower.TabIndex = 37;
            this.lblPower.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(341, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(62, 24);
            this.btnConnect.TabIndex = 36;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbNetwork
            // 
            this.cbNetwork.FormattingEnabled = true;
            this.cbNetwork.Location = new System.Drawing.Point(135, 25);
            this.cbNetwork.Name = "cbNetwork";
            this.cbNetwork.Size = new System.Drawing.Size(185, 21);
            this.cbNetwork.TabIndex = 35;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.BackColor = System.Drawing.Color.Transparent;
            this.ipLabel.Location = new System.Drawing.Point(6, 27);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(60, 13);
            this.ipLabel.TabIndex = 33;
            this.ipLabel.Text = "IP address ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(6, 201);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "Dirac Filters";
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.Location = new System.Drawing.Point(8, 284);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(72, 26);
            this.btRefresh.TabIndex = 25;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(214, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Balance";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(5, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Version";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(5, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Model";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(5, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Power";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(5, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "DAC Filter";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(5, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Network state";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Volume";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox1.Controls.Add(this.cbForceFocus);
            this.groupBox1.Controls.Add(this.lblDialStatus);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lblWindowStatus);
            this.groupBox1.Controls.Add(this.cbRotateHold);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.numVolPerClicks);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTripleClick);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbLongClick);
            this.groupBox1.Controls.Add(this.cbDoubleClick);
            this.groupBox1.Controls.Add(this.cbSingleClick);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numSensitivity);
            this.groupBox1.Controls.Add(this.cbHaptic);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 316);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SURFACE DIAL";
            // 
            // cbForceFocus
            // 
            this.cbForceFocus.AutoSize = true;
            this.cbForceFocus.BackColor = System.Drawing.Color.Transparent;
            this.cbForceFocus.Location = new System.Drawing.Point(342, 28);
            this.cbForceFocus.Name = "cbForceFocus";
            this.cbForceFocus.Size = new System.Drawing.Size(53, 17);
            this.cbForceFocus.TabIndex = 31;
            this.cbForceFocus.Text = "Force";
            this.cbForceFocus.UseVisualStyleBackColor = false;
            // 
            // lblDialStatus
            // 
            this.lblDialStatus.Location = new System.Drawing.Point(175, 53);
            this.lblDialStatus.Name = "lblDialStatus";
            this.lblDialStatus.ReadOnly = true;
            this.lblDialStatus.Size = new System.Drawing.Size(158, 20);
            this.lblDialStatus.TabIndex = 30;
            this.lblDialStatus.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(6, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "Last dial command";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(6, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "Haptic feedback";
            // 
            // lblWindowStatus
            // 
            this.lblWindowStatus.Location = new System.Drawing.Point(175, 26);
            this.lblWindowStatus.Name = "lblWindowStatus";
            this.lblWindowStatus.ReadOnly = true;
            this.lblWindowStatus.Size = new System.Drawing.Size(158, 20);
            this.lblWindowStatus.TabIndex = 27;
            this.lblWindowStatus.TabStop = false;
            // 
            // cbRotateHold
            // 
            this.cbRotateHold.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRotateHold.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRotateHold.FormattingEnabled = true;
            this.cbRotateHold.Items.AddRange(new object[] {
            "Volume",
            "Balance left/right",
            "Display page",
            "Display brightness",
            "<Nothing>"});
            this.cbRotateHold.Location = new System.Drawing.Point(175, 250);
            this.cbRotateHold.Name = "cbRotateHold";
            this.cbRotateHold.Size = new System.Drawing.Size(159, 21);
            this.cbRotateHold.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(6, 253);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Rotate while holding";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(236, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Vol / clicks";
            // 
            // numVolPerClicks
            // 
            this.numVolPerClicks.Location = new System.Drawing.Point(302, 101);
            this.numVolPerClicks.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numVolPerClicks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVolPerClicks.Name = "numVolPerClicks";
            this.numVolPerClicks.Size = new System.Drawing.Size(32, 20);
            this.numVolPerClicks.TabIndex = 23;
            this.numVolPerClicks.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Double click";
            // 
            // cbTripleClick
            // 
            this.cbTripleClick.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTripleClick.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTripleClick.Items.AddRange(new object[] {
            "Pause - Unpause",
            "Next Track",
            "Previous Track",
            "Mute - Unmute",
            "Standby - Wake",
            "DAC Filter",
            "<Nothing>"});
            this.cbTripleClick.Location = new System.Drawing.Point(175, 190);
            this.cbTripleClick.Name = "cbTripleClick";
            this.cbTripleClick.Size = new System.Drawing.Size(159, 21);
            this.cbTripleClick.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(6, 195);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Triple click";
            // 
            // cbLongClick
            // 
            this.cbLongClick.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLongClick.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLongClick.FormattingEnabled = true;
            this.cbLongClick.Items.AddRange(new object[] {
            "Pause - Unpause",
            "Next Track",
            "Previous Track",
            "Mute - Unmute",
            "Standby - Wake",
            "DAC Filter",
            "<Nothing>"});
            this.cbLongClick.Location = new System.Drawing.Point(175, 220);
            this.cbLongClick.Name = "cbLongClick";
            this.cbLongClick.Size = new System.Drawing.Size(159, 21);
            this.cbLongClick.TabIndex = 18;
            // 
            // cbDoubleClick
            // 
            this.cbDoubleClick.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDoubleClick.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDoubleClick.FormattingEnabled = true;
            this.cbDoubleClick.Items.AddRange(new object[] {
            "Pause - Unpause",
            "Next Track",
            "Previous Track",
            "Mute - Unmute",
            "Standby - Wake",
            "DAC Filter",
            "<Nothing>"});
            this.cbDoubleClick.Location = new System.Drawing.Point(175, 160);
            this.cbDoubleClick.Name = "cbDoubleClick";
            this.cbDoubleClick.Size = new System.Drawing.Size(159, 21);
            this.cbDoubleClick.TabIndex = 17;
            // 
            // cbSingleClick
            // 
            this.cbSingleClick.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSingleClick.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSingleClick.Items.AddRange(new object[] {
            "Pause - Unpause",
            "Next Track",
            "Previous Track",
            "Mute - Unmute",
            "Standby - Wake",
            "DAC Filter",
            "<Nothing>"});
            this.cbSingleClick.Location = new System.Drawing.Point(175, 130);
            this.cbSingleClick.Name = "cbSingleClick";
            this.cbSingleClick.Size = new System.Drawing.Size(159, 21);
            this.cbSingleClick.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Window focus state";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Long click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Single click";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rotation sensitivity";
            // 
            // numSensitivity
            // 
            this.numSensitivity.Location = new System.Drawing.Point(175, 101);
            this.numSensitivity.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSensitivity.Name = "numSensitivity";
            this.numSensitivity.Size = new System.Drawing.Size(32, 20);
            this.numSensitivity.TabIndex = 4;
            this.numSensitivity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // cbHaptic
            // 
            this.cbHaptic.AutoSize = true;
            this.cbHaptic.BackColor = System.Drawing.Color.Transparent;
            this.cbHaptic.Checked = true;
            this.cbHaptic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHaptic.Location = new System.Drawing.Point(175, 79);
            this.cbHaptic.Name = "cbHaptic";
            this.cbHaptic.Size = new System.Drawing.Size(15, 14);
            this.cbHaptic.TabIndex = 1;
            this.cbHaptic.UseVisualStyleBackColor = false;
            // 
            // mainWindowBindingSource
            // 
            this.mainWindowBindingSource.DataSource = typeof(ArcamDialNameSpace.MainWindow);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(850, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btExit);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(866, 400);
            this.Name = "MainWindow";
            this.Text = "Arcam Surface Dial control";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolPerClicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.BindingSource mainWindowBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox lblDirac1;
        private System.Windows.Forms.TextBox lblFilter;
        private System.Windows.Forms.TextBox lblNetworkState;
        private System.Windows.Forms.TextBox lblBalance;
        private System.Windows.Forms.TextBox lblVolume;
        private System.Windows.Forms.TextBox lblVersion;
        private System.Windows.Forms.TextBox lblModel;
        private System.Windows.Forms.TextBox lblPower;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbNetwork;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lblWindowStatus;
        private System.Windows.Forms.ComboBox cbRotateHold;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numVolPerClicks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTripleClick;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbLongClick;
        private System.Windows.Forms.ComboBox cbDoubleClick;
        private System.Windows.Forms.ComboBox cbSingleClick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSensitivity;
        private System.Windows.Forms.CheckBox cbHaptic;
        private System.Windows.Forms.TextBox lblDirac3;
        private System.Windows.Forms.TextBox lblDirac2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox lblDialStatus;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox cbForceFocus;
        private System.Windows.Forms.TextBox lblTempOutput;
        private System.Windows.Forms.TextBox lblTempLift;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbShortCircuit;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox cbDCOffset;
    }
}

