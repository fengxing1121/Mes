namespace Mes.Package
{
    partial class frmSystemParamters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemParamters));
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.chkUseCOMPort = new System.Windows.Forms.CheckBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrintQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDensity = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPrint = new System.Windows.Forms.ComboBox();
            this.chkVoiceFlag = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectImg = new System.Windows.Forms.Button();
            this.cbDefaultLogo = new System.Windows.Forms.ComboBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbWorkFlowID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbWorkShiftID = new System.Windows.Forms.ComboBox();
            this.gbPortSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Controls.Add(this.chkUseCOMPort);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.label3);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblParity);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.cmbPortName);
            this.gbPortSettings.Controls.Add(this.cmbStopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Location = new System.Drawing.Point(16, 15);
            this.gbPortSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPortSettings.Size = new System.Drawing.Size(763, 135);
            this.gbPortSettings.TabIndex = 16;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "条码枪参数设置";
            // 
            // chkUseCOMPort
            // 
            this.chkUseCOMPort.AutoSize = true;
            this.chkUseCOMPort.Location = new System.Drawing.Point(363, 100);
            this.chkUseCOMPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUseCOMPort.Name = "chkUseCOMPort";
            this.chkUseCOMPort.Size = new System.Drawing.Size(143, 19);
            this.chkUseCOMPort.TabIndex = 23;
            this.chkUseCOMPort.Text = "使用COM口条码枪";
            this.chkUseCOMPort.UseVisualStyleBackColor = true;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBaudRate.Location = new System.Drawing.Point(353, 28);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(66, 19);
            this.lblBaudRate.TabIndex = 21;
            this.lblBaudRate.Text = "波特率";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDataBits.Location = new System.Drawing.Point(31, 60);
            this.lblDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(66, 19);
            this.lblDataBits.TabIndex = 20;
            this.lblDataBits.Text = "数据位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(31, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "COM口";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Font = new System.Drawing.Font("宋体", 11F);
            this.lblStopBits.Location = new System.Drawing.Point(353, 60);
            this.lblStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(66, 19);
            this.lblStopBits.TabIndex = 18;
            this.lblStopBits.Text = "停止位";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Font = new System.Drawing.Font("宋体", 11F);
            this.lblParity.Location = new System.Drawing.Point(31, 100);
            this.lblParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(47, 19);
            this.lblParity.TabIndex = 17;
            this.lblParity.Text = "校验";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "56000",
            "43000",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400",
            "1200",
            "600",
            "None"});
            this.cmbBaudRate.Location = new System.Drawing.Point(420, 28);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(160, 26);
            this.cmbBaudRate.TabIndex = 14;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "None",
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(107, 60);
            this.cmbDataBits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(160, 26);
            this.cmbDataBits.TabIndex = 13;
            // 
            // cmbPortName
            // 
            this.cmbPortName.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(107, 28);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(160, 26);
            this.cmbPortName.TabIndex = 12;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(420, 60);
            this.cmbStopBits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(160, 26);
            this.cmbStopBits.TabIndex = 11;
            // 
            // cmbParity
            // 
            this.cmbParity.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(107, 96);
            this.cmbParity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(160, 26);
            this.cmbParity.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 540);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(672, 540);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrintQty);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDensity);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaxWeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbPrint);
            this.groupBox1.Location = new System.Drawing.Point(11, 160);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(768, 160);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分包参数：";
            // 
            // txtPrintQty
            // 
            this.txtPrintQty.Font = new System.Drawing.Font("宋体", 13F);
            this.txtPrintQty.Location = new System.Drawing.Point(576, 60);
            this.txtPrintQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrintQty.Name = "txtPrintQty";
            this.txtPrintQty.Size = new System.Drawing.Size(73, 32);
            this.txtPrintQty.TabIndex = 27;
            this.txtPrintQty.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(576, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "打印份数：";
            // 
            // txtDensity
            // 
            this.txtDensity.Font = new System.Drawing.Font("宋体", 13F);
            this.txtDensity.Location = new System.Drawing.Point(469, 110);
            this.txtDensity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Size = new System.Drawing.Size(95, 32);
            this.txtDensity.TabIndex = 25;
            this.txtDensity.Text = "0.8";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("宋体", 16F);
            this.txtBarcode.Location = new System.Drawing.Point(21, 60);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(287, 38);
            this.txtBarcode.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(352, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "板件密度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(320, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "条码打印机：";
            // 
            // txtMaxWeight
            // 
            this.txtMaxWeight.Font = new System.Drawing.Font("宋体", 13F);
            this.txtMaxWeight.Location = new System.Drawing.Point(149, 110);
            this.txtMaxWeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaxWeight.Name = "txtMaxWeight";
            this.txtMaxWeight.Size = new System.Drawing.Size(137, 32);
            this.txtMaxWeight.TabIndex = 23;
            this.txtMaxWeight.Text = "35";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "完成当前分包条码标签：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(11, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "每包限重(KG)";
            // 
            // cbPrint
            // 
            this.cbPrint.Font = new System.Drawing.Font("宋体", 16F);
            this.cbPrint.FormattingEnabled = true;
            this.cbPrint.Location = new System.Drawing.Point(320, 60);
            this.cbPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(244, 35);
            this.cbPrint.TabIndex = 11;
            // 
            // chkVoiceFlag
            // 
            this.chkVoiceFlag.AutoSize = true;
            this.chkVoiceFlag.Location = new System.Drawing.Point(11, 550);
            this.chkVoiceFlag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkVoiceFlag.Name = "chkVoiceFlag";
            this.chkVoiceFlag.Size = new System.Drawing.Size(149, 19);
            this.chkVoiceFlag.TabIndex = 20;
            this.chkVoiceFlag.Text = "启用扫描声音提示";
            this.chkVoiceFlag.UseVisualStyleBackColor = true;
            this.chkVoiceFlag.CheckedChanged += new System.EventHandler(this.chkVoiceFlag_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectImg);
            this.groupBox2.Controls.Add(this.cbDefaultLogo);
            this.groupBox2.Controls.Add(this.picLogo);
            this.groupBox2.Location = new System.Drawing.Point(11, 330);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(768, 125);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logo图片设置";
            // 
            // btnSelectImg
            // 
            this.btnSelectImg.Location = new System.Drawing.Point(203, 70);
            this.btnSelectImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectImg.Name = "btnSelectImg";
            this.btnSelectImg.Size = new System.Drawing.Size(100, 40);
            this.btnSelectImg.TabIndex = 22;
            this.btnSelectImg.Text = "导入(&I)";
            this.btnSelectImg.UseVisualStyleBackColor = true;
            this.btnSelectImg.Click += new System.EventHandler(this.btnSelectImg_Click);
            // 
            // cbDefaultLogo
            // 
            this.cbDefaultLogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultLogo.Font = new System.Drawing.Font("宋体", 11F);
            this.cbDefaultLogo.FormattingEnabled = true;
            this.cbDefaultLogo.Location = new System.Drawing.Point(11, 30);
            this.cbDefaultLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDefaultLogo.Name = "cbDefaultLogo";
            this.cbDefaultLogo.Size = new System.Drawing.Size(287, 26);
            this.cbDefaultLogo.TabIndex = 13;
            this.cbDefaultLogo.SelectedIndexChanged += new System.EventHandler(this.cbDefaultLogo_SelectedIndexChanged);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(309, 20);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(373, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbWorkFlowID);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbWorkShiftID);
            this.groupBox3.Location = new System.Drawing.Point(11, 470);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(768, 60);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(320, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 19);
            this.label8.TabIndex = 27;
            this.label8.Text = "当前检查工序：";
            // 
            // cbWorkFlowID
            // 
            this.cbWorkFlowID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkFlowID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWorkFlowID.FormattingEnabled = true;
            this.cbWorkFlowID.Location = new System.Drawing.Point(469, 20);
            this.cbWorkFlowID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWorkFlowID.Name = "cbWorkFlowID";
            this.cbWorkFlowID.Size = new System.Drawing.Size(160, 32);
            this.cbWorkFlowID.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(25, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 19);
            this.label7.TabIndex = 25;
            this.label7.Text = "班次：";
            // 
            // cbWorkShiftID
            // 
            this.cbWorkShiftID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkShiftID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWorkShiftID.FormattingEnabled = true;
            this.cbWorkShiftID.Location = new System.Drawing.Point(96, 20);
            this.cbWorkShiftID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWorkShiftID.Name = "cbWorkShiftID";
            this.cbWorkShiftID.Size = new System.Drawing.Size(160, 32);
            this.cbWorkShiftID.TabIndex = 24;
            // 
            // frmSystemParamters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 589);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkVoiceFlag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPortSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemParamters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统参数设置";
            this.Load += new System.EventHandler(this.frmSystemParamters_Load);
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPortSettings;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPrint;
        private System.Windows.Forms.CheckBox chkVoiceFlag;
        private System.Windows.Forms.TextBox txtMaxWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDensity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ComboBox cbDefaultLogo;
        private System.Windows.Forms.Button btnSelectImg;
        private System.Windows.Forms.TextBox txtPrintQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseCOMPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbWorkFlowID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbWorkShiftID;
    }
}