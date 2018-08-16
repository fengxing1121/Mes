namespace Mes.Package
{
    partial class frmDoors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoors));
            this.listPackage = new System.Windows.Forms.ListView();
            this.Col_Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_PackageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPackage
            // 
            this.listPackage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_Index,
            this.Col_PackageName,
            this.Col_Qty});
            this.listPackage.ContextMenuStrip = this.menuDelete;
            this.listPackage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listPackage.FullRowSelect = true;
            this.listPackage.GridLines = true;
            this.listPackage.Location = new System.Drawing.Point(8, 88);
            this.listPackage.Name = "listPackage";
            this.listPackage.Size = new System.Drawing.Size(352, 168);
            this.listPackage.TabIndex = 0;
            this.listPackage.UseCompatibleStateImageBehavior = false;
            this.listPackage.View = System.Windows.Forms.View.Details;
            // 
            // Col_Index
            // 
            this.Col_Index.Text = "序号";
            // 
            // Col_PackageName
            // 
            this.Col_PackageName.Text = "包名称";
            this.Col_PackageName.Width = 150;
            // 
            // Col_Qty
            // 
            this.Col_Qty.Tag = "包数";
            this.Col_Qty.Text = "数量(包)";
            this.Col_Qty.Width = 80;
            // 
            // menuDelete
            // 
            this.menuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteItem});
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(125, 26);
            this.menuDelete.Text = "删除";
            // 
            // menuDeleteItem
            // 
            this.menuDeleteItem.Name = "menuDeleteItem";
            this.menuDeleteItem.Size = new System.Drawing.Size(124, 22);
            this.menuDeleteItem.Text = "删除此项";
            this.menuDeleteItem.Click += new System.EventHandler(this.menuDeleteItem_Click);
            // 
            // cbName
            // 
            this.cbName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbName.FormattingEnabled = true;
            this.cbName.Items.AddRange(new object[] {
            "导轨",
            "左移门",
            "右移门",
            "中移门",
            "五金",
            "拼框门"});
            this.cbName.Location = new System.Drawing.Point(120, 16);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(232, 28);
            this.cbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "包装名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(56, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "数量：";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQty.Location = new System.Drawing.Point(120, 48);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 30);
            this.txtQty.TabIndex = 3;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(232, 48);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(120, 32);
            this.btnAddRow.TabIndex = 4;
            this.btnAddRow.Text = "添加此包";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(240, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "确定添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(8, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "提示：右键删除添加的行数据";
            // 
            // frmDoors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 314);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listPackage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加移门五金包数据";
            this.menuDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listPackage;
        private System.Windows.Forms.ColumnHeader Col_Index;
        private System.Windows.Forms.ColumnHeader Col_PackageName;
        private System.Windows.Forms.ColumnHeader Col_Qty;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteItem;
        private System.Windows.Forms.Label label3;
    }
}