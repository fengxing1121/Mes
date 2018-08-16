namespace Mes.Package
{
    partial class frmDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownload));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbBOM = new System.Windows.Forms.RadioButton();
            this.rbCUT = new System.Windows.Forms.RadioButton();
            this.rbDXF = new System.Windows.Forms.RadioButton();
            this.rbCNC = new System.Windows.Forms.RadioButton();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.btnOpendlg = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBattchNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCNCN5 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCNCN5);
            this.groupBox1.Controls.Add(this.rbManual);
            this.groupBox1.Controls.Add(this.rbBOM);
            this.groupBox1.Controls.Add(this.rbCUT);
            this.groupBox1.Controls.Add(this.rbDXF);
            this.groupBox1.Controls.Add(this.rbCNC);
            this.groupBox1.Controls.Add(this.chkDefault);
            this.groupBox1.Controls.Add(this.btnDownLoad);
            this.groupBox1.Controls.Add(this.btnOpendlg);
            this.groupBox1.Controls.Add(this.txtSavePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBattchNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Location = new System.Drawing.Point(360, 112);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(71, 16);
            this.rbManual.TabIndex = 105;
            this.rbManual.TabStop = true;
            this.rbManual.Text = "手工料单";
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // rbBOM
            // 
            this.rbBOM.AutoSize = true;
            this.rbBOM.Location = new System.Drawing.Point(280, 112);
            this.rbBOM.Name = "rbBOM";
            this.rbBOM.Size = new System.Drawing.Size(71, 16);
            this.rbBOM.TabIndex = 104;
            this.rbBOM.TabStop = true;
            this.rbBOM.Text = "优化料单";
            this.rbBOM.UseVisualStyleBackColor = true;
            // 
            // rbCUT
            // 
            this.rbCUT.AutoSize = true;
            this.rbCUT.Location = new System.Drawing.Point(160, 112);
            this.rbCUT.Name = "rbCUT";
            this.rbCUT.Size = new System.Drawing.Size(113, 16);
            this.rbCUT.TabIndex = 103;
            this.rbCUT.TabStop = true;
            this.rbCUT.Text = "优化开料CUT文件";
            this.rbCUT.UseVisualStyleBackColor = true;
            // 
            // rbDXF
            // 
            this.rbDXF.AutoSize = true;
            this.rbDXF.Location = new System.Drawing.Point(16, 112);
            this.rbDXF.Name = "rbDXF";
            this.rbDXF.Size = new System.Drawing.Size(65, 16);
            this.rbDXF.TabIndex = 102;
            this.rbDXF.TabStop = true;
            this.rbDXF.Text = "DXF文件";
            this.rbDXF.UseVisualStyleBackColor = true;
            // 
            // rbCNC
            // 
            this.rbCNC.AutoSize = true;
            this.rbCNC.Location = new System.Drawing.Point(88, 112);
            this.rbCNC.Name = "rbCNC";
            this.rbCNC.Size = new System.Drawing.Size(65, 16);
            this.rbCNC.TabIndex = 101;
            this.rbCNC.TabStop = true;
            this.rbCNC.Text = "CNC文件";
            this.rbCNC.UseVisualStyleBackColor = true;
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new System.Drawing.Point(88, 88);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(96, 16);
            this.chkDefault.TabIndex = 100;
            this.chkDefault.Text = "设为默认位置";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownLoad.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDownLoad.ForeColor = System.Drawing.Color.Red;
            this.btnDownLoad.Location = new System.Drawing.Point(136, 160);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(104, 32);
            this.btnDownLoad.TabIndex = 99;
            this.btnDownLoad.Text = "确定下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // btnOpendlg
            // 
            this.btnOpendlg.Location = new System.Drawing.Point(376, 56);
            this.btnOpendlg.Name = "btnOpendlg";
            this.btnOpendlg.Size = new System.Drawing.Size(48, 23);
            this.btnOpendlg.TabIndex = 4;
            this.btnOpendlg.Text = "浏览";
            this.btnOpendlg.UseVisualStyleBackColor = true;
            this.btnOpendlg.Click += new System.EventHandler(this.btnOpendlg_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.BackColor = System.Drawing.Color.White;
            this.txtSavePath.Location = new System.Drawing.Point(80, 56);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(296, 21);
            this.txtSavePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "存储位置：";
            // 
            // txtBattchNum
            // 
            this.txtBattchNum.Location = new System.Drawing.Point(80, 24);
            this.txtBattchNum.Name = "txtBattchNum";
            this.txtBattchNum.Size = new System.Drawing.Size(296, 21);
            this.txtBattchNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产批次：";
            // 
            // cbCNCN5
            // 
            this.cbCNCN5.AutoSize = true;
            this.cbCNCN5.Location = new System.Drawing.Point(200, 88);
            this.cbCNCN5.Name = "cbCNCN5";
            this.cbCNCN5.Size = new System.Drawing.Size(102, 16);
            this.cbCNCN5.TabIndex = 106;
            this.cbCNCN5.Text = "CNC去掉N5前缀";
            this.cbCNCN5.UseVisualStyleBackColor = true;
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 209);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载加工文件";
            this.Load += new System.EventHandler(this.frmDownload_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBattchNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpendlg;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.RadioButton rbBOM;
        private System.Windows.Forms.RadioButton rbCUT;
        private System.Windows.Forms.RadioButton rbDXF;
        private System.Windows.Forms.RadioButton rbCNC;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.CheckBox cbCNCN5;
    }
}