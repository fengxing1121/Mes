using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mes.Package
{
    public partial class frmDoors : Form
    {
        public Guid OrderID
        {
            get;
            set;
        }
        public Guid CabinetID
        {
            get;
            set;
        }
        public frmDoors()
        {
            InitializeComponent();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbName.Text == "")
                {
                    throw new Exception("请选择或者输入包的名称。");
                }
                int Qty = 0;
                if (this.txtQty.Text == "")
                {
                    throw new Exception("请输入包的数量。");
                }
                else if (!int.TryParse(txtQty.Text, out Qty))
                {
                    throw new Exception("数量不是有效的数字。");
                }
                else if (Qty <= 0 && Qty > 2)
                {
                    throw new Exception("数量不能小于等于0或者大于2包。");
                }

                foreach (ListViewItem li in this.listPackage.Items)
                {
                    if (li.SubItems[1].Text == this.cbName.Text)
                    {
                        throw new Exception(string.Format("【{0}】已经添加在列表中，请确认是否重复添加。", cbName.Text));
                    }
                }

                ListViewItem item = new ListViewItem();
                item.Text = ((this.listPackage.Items.Count + 1).ToString());
                item.SubItems.Add(this.cbName.Text);
                item.SubItems.Add(this.txtQty.Text);
                this.listPackage.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listPackage.SelectedItems.Count == 0) return;
                ListViewItem li = this.listPackage.SelectedItems[0];
                listPackage.Items.Remove(li);

                int i = 1;
                foreach (ListViewItem sub in this.listPackage.Items)
                {
                    sub.SubItems[0].Text = i.ToString();
                    i++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listPackage.Items.Count == 0)
                {
                    throw new Exception("未添加任何包数据。");
                }
                using (ProxyBE bll = new ProxyBE())
                {
                    Order order = bll.Client.GetOrder(CGlobal.SenderUser, OrderID);
                    //订单添加板件明细
                    List<OrderDetail> suborders = new List<OrderDetail>();

                    List<OrderDetail> details = bll.Client.GetOrderDetails(CGlobal.SenderUser, OrderID);
                    Order2Cabinet cabinet = bll.Client.GetOrder2Cabinet(CGlobal.SenderUser, this.CabinetID);
                    int itemsQty = 1;
                    foreach (ListViewItem li in this.listPackage.Items)
                    {
                        int Qty = int.Parse(li.SubItems[2].Text);
                        for (int i = 0; i < Qty; i++)
                        {
                            OrderDetail subOrder = new OrderDetail();
                            subOrder.ItemID = Guid.NewGuid();
                            subOrder.OrderID = this.OrderID;
                            subOrder.BarcodeNo = order.OrderNo + ((char)(64 + cabinet.Sequence)).ToString() + (itemsQty + details.Count + 50).ToString("000");
                            subOrder.ItemName = li.SubItems[1].Text;
                            subOrder.MadeBattchNum = "";
                            subOrder.MaterialType = "";
                            subOrder.MadeLength = 0;
                            subOrder.MadeWidth = 0;
                            subOrder.MadeHeight = 0;
                            subOrder.Qty = 1;
                            subOrder.TextureDirection = "";
                            subOrder.Edge1 = "";
                            subOrder.Edge2 = "";
                            subOrder.Edge3 = "";
                            subOrder.Edge4 = "";
                            subOrder.HoleDesc = "";
                            subOrder.EndLength = 0;
                            subOrder.EndWidth = 0;
                            subOrder.FrontLabel = "";
                            subOrder.BackLabel = "";
                            subOrder.PackageCategory = "";
                            subOrder.PackageSizeType = "";
                            subOrder.IsSpecialShap = false;
                            subOrder.CabinetID = this.CabinetID;
                            subOrder.Remarks = "";
                            subOrder.EdgeDesc = "";
                            subOrder.DamageQty = 0;
                            subOrder.Created = DateTime.Now;
                            suborders.Add(subOrder);

                            Mes.Client.Service.BE.Package p = new Mes.Client.Service.BE.Package();
                            p.OrderID = OrderID;
                            int pageNum = bll.Client.GetMaxPackageNum(CGlobal.SenderUser, OrderID, subOrder.CabinetID);
                            p.CabinetID = subOrder.CabinetID;
                            p.PackageNum = pageNum;
                            p.PackageBarcode = string.Format("0{0}{1}", order.Created.ToString("yyMMddHHmmss"), pageNum.ToString("00"));
                            p.PackageID = Guid.NewGuid();
                            p.ItemsQty = 1;

                            //保存条码数据
                            PackageDetail obj = new PackageDetail();
                            obj.DetailID = Guid.NewGuid();
                            obj.ItemID = subOrder.ItemID;
                            obj.PakageID = p.PackageID;
                            obj.IsPlanning = true;
                            obj.IsPakaged = true;
                            obj.IsDisabled = false;
                            obj.IsOptimized = true;
                            obj.LayerNum = 0;
                            obj.Qty = 1;
                            obj.CheckedBy = CGlobal.SenderUser.UserCode + "." + CGlobal.SenderUser.UserName;

                            SavePackageArgs saveArgs = new SavePackageArgs();
                            saveArgs.Package = p;

                            PackageDetail detail = new PackageDetail();
                            detail.DetailID = Guid.NewGuid();

                            detail.CheckedBy = CGlobal.SenderUser.UserCode;
                            detail.IsDisabled = false;
                            detail.IsOptimized = true;
                            detail.IsPakaged = true;
                            detail.IsPlanning = true;
                            detail.ItemID = subOrder.ItemID;
                            detail.LayerNum = 0;
                            detail.PakageID = obj.PakageID;
                            detail.Qty = 1;
                            saveArgs.PackageDetail = detail;
                            bll.Client.SavePackage(CGlobal.SenderUser, saveArgs);

                            itemsQty++;
                        }
                    }
                    SaveOrderArgs saveOrderArgs = new SaveOrderArgs();
                    saveOrderArgs.Order = order;
                    saveOrderArgs.OrderDetails = suborders;
                    bll.Client.SaveOrder(CGlobal.SenderUser, saveOrderArgs);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
