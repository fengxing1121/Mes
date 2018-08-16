using Mes.Package.Report;

namespace Mes.Package
{
    partial class frmReportPrieview
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
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPrieview));
            this.tbPackageLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBarcode = new Mes.Package.Report.dsBarcode();
            this.tbPackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbCommonLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbPackageLabelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPackageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCommonLabelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPackageLabelBindingSource
            // 
            this.tbPackageLabelBindingSource.DataMember = "tbPackageLabel";
            this.tbPackageLabelBindingSource.DataSource = this.dsBarcode;
            // 
            // dsBarcode
            // 
            this.dsBarcode.DataSetName = "dsBarcode";
            this.dsBarcode.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbPackageBindingSource
            // 
            this.tbPackageBindingSource.DataMember = "tbPackage";
            this.tbPackageBindingSource.DataSource = this.dsBarcode;
            // 
            // rptView
            // 
            this.rptView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));            
           
            this.rptView.Location = new System.Drawing.Point(0, 0);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(648, 360);
            this.rptView.TabIndex = 0;
            // 
            // tbCommonLabelBindingSource
            // 
            this.tbCommonLabelBindingSource.DataMember = "tbCommonLabel";
            this.tbCommonLabelBindingSource.DataSource = this.dsBarcode;
            // 
            // frmReportPrieview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 360);
            this.Controls.Add(this.rptView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportPrieview";
            this.Text = "报表预览";
            this.Load += new System.EventHandler(this.frmReportPrieview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPackageLabelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPackageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCommonLabelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptView;
        private System.Windows.Forms.BindingSource tbPackageBindingSource;
        private dsBarcode dsBarcode;
        private System.Windows.Forms.BindingSource tbPackageLabelBindingSource;
        private System.Windows.Forms.BindingSource tbCommonLabelBindingSource;
    }
}