using MES.Libraries;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes.Package
{
    public partial class frmCabinetStatus : Form
    {
        public Guid OrderID
        {
            get;
            set;
        }

        public frmCabinetStatus()
        {
            InitializeComponent();
        }

        public frmCabinetStatus(Guid orderID)
        {
            InitializeComponent();
            this.OrderID = orderID;
            Initialize();
        }

        public void Initialize()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchOrder2CabinetArgs args = new SearchOrder2CabinetArgs();
                    args.OrderBy = "[Sequence]";
                    args.OrderIDs = new List<Guid>() { this.OrderID };
                    SearchResult sr = p.Client.SearchOrder2Cabinet(CGlobal.SenderUser, args);
                    int count = sr.DataSet.Tables[0].Select("CabinetStatus='N'").Length;

                    Order order = p.Client.GetOrder(CGlobal.SenderUser, OrderID);

                    this.tvCabinet.Nodes.Clear();
                    TreeNode root = new TreeNode();
                    root.Text = string.Format("订单号：{0}；已完成：{1}；未完成：{2}；取消：{3}",order.OrderNo,sr.DataSet.Tables[0].Select("CabinetStatus='F'").Length,sr.DataSet.Tables[0].Select("CabinetStatus='N'").Length,sr.DataSet.Tables[0].Select("CabinetStatus='C'").Length);
                    foreach (DataRow row in sr.DataSet.Tables[0].Rows)
                    {
                        TreeNode subNode = new TreeNode();
                        subNode.Text = string.Format("{0}【{1},{2},{3},{4}】 -- {5}", row["CabinetName"], row["Size"], row["Color"], row["MaterialStyle"], row["MaterialCategory"], GetStatus(row["CabinetStatus"].ToString()));
                        root.Nodes.Add(subNode);
                    }
                    tvCabinet.Nodes.Add(root);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetStatus(string status)
        {
            switch (status)
            {
                case "N":
                    return "未完成";
                case "F":
                    return "已完成";
                case "C":
                    return "已取消";
                default:
                    return "未完成";
            }
        }
    }
}
