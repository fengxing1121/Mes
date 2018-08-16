namespace Mes.Package
{
    partial class frmCabinetStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCabinetStatus));
            this.tvCabinet = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvCabinet
            // 
            this.tvCabinet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCabinet.Location = new System.Drawing.Point(0, 0);
            this.tvCabinet.Name = "tvCabinet";
            this.tvCabinet.Size = new System.Drawing.Size(533, 311);
            this.tvCabinet.TabIndex = 0;
            // 
            // frmCabinetStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 311);
            this.Controls.Add(this.tvCabinet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCabinetStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "柜子打包状态";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCabinet;
    }
}