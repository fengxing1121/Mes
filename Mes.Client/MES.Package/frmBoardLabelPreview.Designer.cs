using Mes.Package.Report;

namespace Mes.Package
{
    partial class frmBoardLabelPreview
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoardLabelPreview));
            this.rptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dsBarcode = new Mes.Package.Report.dsBarcode();
            this.tbBoardLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBoardLabelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptView
            // 
            this.rptView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbBoardLabelBindingSource;
            this.rptView.LocalReport.DataSources.Add(reportDataSource1);
            this.rptView.LocalReport.ReportEmbeddedResource = "Mes.Package.Report.rptBoardLabel.rdlc";
            this.rptView.Location = new System.Drawing.Point(0, 56);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(528, 278);
            this.rptView.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBarcode.Location = new System.Drawing.Point(104, 8);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(296, 31);
            this.txtBarcode.TabIndex = 93;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Red;
            this.btnConfirm.Location = new System.Drawing.Point(408, 8);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(104, 32);
            this.btnConfirm.TabIndex = 94;
            this.btnConfirm.Text = "确定(&Y)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 33);
            this.label7.TabIndex = 101;
            this.label7.Text = "条码：";
            // 
            // dsBarcode
            // 
            this.dsBarcode.DataSetName = "dsBarcode";
            this.dsBarcode.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbBoardLabelBindingSource
            // 
            this.tbBoardLabelBindingSource.DataMember = "tbBoardLabel";
            this.tbBoardLabelBindingSource.DataSource = this.dsBarcode;
            // 
            // frmBoardLabelPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 332);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.rptView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBoardLabelPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "板件标签";
            this.Load += new System.EventHandler(this.frmBoardLabelPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBoardLabelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptView;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource tbBoardLabelBindingSource;
        private dsBarcode dsBarcode;
    }
}