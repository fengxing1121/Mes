using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Package
{
    /// <summary>
    /// 获取dataset数据源
    /// </summary>
    public class CrptDataSource
    {
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="LogoFile"></param>
        /// <returns></returns>
        public DataSet GetItemLabelDataSource(DataTable sourceData, string LogoFile)
        {
            DataSet ds = new DataSet("tbPackageDataTable");
            using (ProxyBE p = new ProxyBE())
            {
                #region 70*200的条码
                
                DataTable tb = new DataTable();
                tb.Columns.Add(new DataColumn("OrderNo", typeof(string)));
                tb.Columns.Add(new DataColumn("OutOrderNo", typeof(string)));
                tb.Columns.Add(new DataColumn("PurchaseNo", typeof(string)));
                tb.Columns.Add(new DataColumn("CustomerName", typeof(string)));
                tb.Columns.Add(new DataColumn("Address", typeof(string)));
                tb.Columns.Add(new DataColumn("LinkMan", typeof(string)));
                tb.Columns.Add(new DataColumn("Mobile", typeof(string)));
                //tb.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tb.Columns.Add(new DataColumn("CabinetName", typeof(string)));
                tb.Columns.Add(new DataColumn("MaterialStyle", typeof(string)));
                tb.Columns.Add(new DataColumn("Size", typeof(string)));
                tb.Columns.Add(new DataColumn("Color", typeof(string)));
                tb.Columns.Add(new DataColumn("PackageNum", typeof(string)));
                tb.Columns.Add(new DataColumn("TotalPackage", typeof(string)));
                tb.Columns.Add(new DataColumn("PackageBarcode", typeof(string)));
                tb.Columns.Add(new DataColumn("ItemName_1", typeof(string)));
                tb.Columns.Add(new DataColumn("ItemName_2", typeof(string)));
                tb.Columns.Add(new DataColumn("ItemName_3", typeof(string)));
                tb.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
                tb.Columns.Add(new DataColumn("Logo", typeof(byte[])));
                tb.Columns.Add(new DataColumn("PrintDate", typeof(string)));
                tb.Columns.Add(new DataColumn("PackageDesc", typeof(string)));
                tb.Columns.Add(new DataColumn("ItemsQty", typeof(Int32)));


                //重置报表数据列
                foreach (DataRow row in sourceData.Rows)
                {
                    SearchPackageDetailArgs subArgs = new SearchPackageDetailArgs();
                    subArgs.OrderID = (Guid)row["OrderID"];
                    subArgs.PackageID = (Guid)row["PackageID"];

                    //包装明细
                    SearchResult subResult = p.Client.SearchPackageDetail(CGlobal.SenderUser, subArgs);

                    var query = from g in subResult.DataSet.Tables[0].AsEnumerable()
                                group g by new
                                {
                                    PackageNum = g.Field<int>("PackageNum"),
                                    PackageBarcode = g.Field<string>("PackageBarcode"),
                                    ItemName = g.Field<string>("ItemName"),
                                    MadeLength = g.Field<decimal>("MadeLength"),
                                    MadeWidth = g.Field<decimal>("MadeWidth"),
                                    MadeHeight = g.Field<decimal>("MadeHeight")
                                } into lists_Package
                                select new
                                {
                                    ItemName = lists_Package.Key.ItemName,
                                    PackageBarcode = lists_Package.Key.PackageBarcode,
                                    PackageNum = lists_Package.Key.PackageNum,
                                    MadeWidth = lists_Package.Key.MadeWidth,
                                    MadeLength = lists_Package.Key.MadeLength,
                                    MadeHeight = lists_Package.Key.MadeHeight,
                                    Qty = lists_Package.Sum(n => n.Field<int>("Qty"))
                                };


                    var lists = query.ToList();
                    int rows = lists.Count / 3 + (lists.Count % 3 > 0 ? 1 : 0);//如果list.count为5行，则rows为2
                    int totalQty = lists.Sum(li => li.Qty);

                    //生产行数据
                    for (int i = 0; i < rows; i++)
                    {
                        DataRow newRow = tb.NewRow();
                        newRow["OrderNo"] = row["OrderNo"];
                        newRow["OutOrderNo"] = row["OutOrderNo"];
                        newRow["PurchaseNo"] = row["PurchaseNo"];
                        newRow["CustomerName"] = row["CustomerName"];
                        newRow["Address"] = row["Address"];
                        newRow["LinkMan"] = row["LinkMan"];
                        newRow["Mobile"] = row["Mobile"];
                        newRow["CabinetName"] = row["CabinetName"];
                        newRow["Size"] = row["Size"];
                        newRow["Color"] = row["Color"];
                        newRow["MaterialStyle"] = row["MaterialStyle"];
                        newRow["PackageNum"] = row["PackageNum"];
                        newRow["TotalPackage"] = "";// row["TotalPackage"].ToString();
                        newRow["PackageBarcode"] = row["PackageBarcode"];
                        newRow["Address"] = row["Province"].ToString() + row["City"].ToString() + row["Address"].ToString();
                        newRow["Barcode"] = CommonView.getQRcode(row["PackageBarcode"].ToString());
                        newRow["PackageDesc"] = string.Format("第 {0} 包", int.Parse(row["PackageNum"].ToString()).ToString("00"));
                        newRow["Logo"] = CommonView.getLogoFile(LogoFile);
                        newRow["PrintDate"] = DateTime.Now.ToString("yyyy年MM月dd日");

                        //处理列数据
                        for (int rowindex = 1; rowindex <= 3; rowindex++)
                        {
                            var item = lists[i * 3 + rowindex - 1];
                            string remarks = "";
                            string itemName = item.ItemName;
                            if ("A,B,C,D,E,F".Contains(itemName.Substring(0, 1)))
                            {
                                itemName = itemName.Substring(1);
                            }

                            int index = item.ItemName.LastIndexOf("mm");
                            if (index >= 0)
                            {
                                itemName = itemName.Substring(index + 2, itemName.Length - (index + 2));
                            }
                            if (item.ItemName.Length > 5)
                            {
                                remarks = string.Format("{0}:{1}*{2}*{3}={4}", itemName.Substring(0, 5), item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
                            }
                            else
                            {
                                remarks = string.Format("{0}:{1}*{2}*{3}={4}", itemName, item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
                            }
                            newRow["ItemName_" + rowindex] = remarks;
                            if (i * 3 + rowindex - 1 == lists.Count - 1) break; //最后一条数据
                        }
                        newRow["ItemsQty"] = totalQty;// row["ItemsQty"];
                        tb.Rows.Add(newRow);
                    }
                    //生成右侧空数据，默认生成13行数据
                    for (int i = rows; i < 13; i++)
                    {
                        DataRow newRow = tb.NewRow();
                        newRow["OrderNo"] = row["OrderNo"];
                        newRow["OutOrderNo"] = row["OutOrderNo"];
                        newRow["PurchaseNo"] = row["PurchaseNo"];
                        newRow["CustomerName"] = row["CustomerName"];
                        newRow["Address"] = row["Address"];
                        newRow["LinkMan"] = row["LinkMan"];
                        newRow["Mobile"] = row["Mobile"];
                        newRow["CabinetName"] = row["CabinetName"];
                        newRow["Size"] = row["Size"];
                        newRow["Color"] = row["Color"];
                        newRow["MaterialStyle"] = row["MaterialStyle"];
                        newRow["PackageNum"] = row["PackageNum"];
                        newRow["TotalPackage"] = "";
                        newRow["PackageBarcode"] = row["PackageBarcode"];
                        newRow["Address"] = row["Province"].ToString() + row["City"].ToString() + row["Address"].ToString();
                        newRow["Barcode"] = CommonView.getQRcode(row["PackageBarcode"].ToString());
                        newRow["PackageDesc"] = string.Format("第 {0} 包", int.Parse(row["PackageNum"].ToString()).ToString("00"));
                        newRow["Logo"] = CommonView.getLogoFile(LogoFile);
                        newRow["PrintDate"] = DateTime.Now.ToString("yyyy年MM月dd日");
                        newRow["ItemName_1"] = "";
                        newRow["ItemName_2"] = "";
                        newRow["ItemName_3"] = "";
                        newRow["ItemsQty"] = totalQty;
                        tb.Rows.Add(newRow);
                    }
                }
                ds.Tables.Add(tb);
                #endregion
            }
            //string str = JSONHelper.Dataset2Json2(ds);
            return ds;
        }

        public DataSet GetCommonLabelDataSource(Guid CabinetID,string CategoryName, string LogoFile)
        {
            DataSet ds = new DataSet("tbPackageDataTable");
            using (ProxyBE p = new ProxyBE())
            {
                Order2Cabinet cabinet = p.Client.GetOrder2Cabinet(CGlobal.SenderUser, CabinetID);
                SearchOrder2CabinetArgs args = new SearchOrder2CabinetArgs();
                args.OrderIDs = new List<Guid> { cabinet.OrderID };
                //args.CabinetName = cabinet.CabinetName;
                args.CabinetID = CabinetID;
                SearchResult sr = p.Client.SearchOrder2Cabinet(CGlobal.SenderUser, args);
                if (sr.Total == 0) return ds;
                #region 100*70的条码
                
                DataTable tb = new DataTable();
                tb.Columns.Add(new DataColumn("OrderNo", typeof(string)));
                tb.Columns.Add(new DataColumn("OutOrderNo", typeof(string)));
                tb.Columns.Add(new DataColumn("PurchaseNo", typeof(string)));
                tb.Columns.Add(new DataColumn("CustomerName", typeof(string)));
                tb.Columns.Add(new DataColumn("Address", typeof(string)));
                tb.Columns.Add(new DataColumn("LinkMan", typeof(string)));
                tb.Columns.Add(new DataColumn("Mobile", typeof(string)));
                tb.Columns.Add(new DataColumn("CabinetName", typeof(string)));
                tb.Columns.Add(new DataColumn("MaterialStyle", typeof(string)));
                tb.Columns.Add(new DataColumn("Size", typeof(string)));
                tb.Columns.Add(new DataColumn("Color", typeof(string)));
                tb.Columns.Add(new DataColumn("Logo", typeof(byte[])));
                tb.Columns.Add(new DataColumn("PrintDate", typeof(string)));
                tb.Columns.Add(new DataColumn("Remark", typeof(string)));
                tb.Columns.Add(new DataColumn("CategoryName", typeof(string)));

                DataRow row = sr.DataSet.Tables[0].Rows[0];

                string[] c = CategoryName.Split(',');
                foreach (string s in c)
                {
                    DataRow newRow = tb.NewRow();
                    newRow["OrderNo"] = row["OrderNo"];
                    newRow["OutOrderNo"] = row["OutOrderNo"];
                    newRow["PurchaseNo"] = row["PurchaseNo"];
                    newRow["CustomerName"] = row["CustomerName"];
                    newRow["Address"] = row["Address"];
                    newRow["LinkMan"] = row["LinkMan"];
                    newRow["Mobile"] = row["Mobile"];
                    newRow["CabinetName"] = row["CabinetName"];
                    newRow["Size"] = row["Size"];
                    newRow["Color"] = row["Color"];
                    newRow["MaterialStyle"] = row["MaterialStyle"];
                    newRow["Address"] = row["Province"].ToString() + row["City"].ToString() + row["Address"].ToString();
                    newRow["Logo"] = getLogoFile(LogoFile);
                    newRow["PrintDate"] = DateTime.Now.ToString("yyyy年MM月dd日");
                    newRow["Remark"] = "";
                    newRow["CategoryName"] = s;
                    tb.Rows.Add(newRow);
                }               

                ds.Tables.Add(tb);                
                #endregion
            }
            return ds;
        }
        private byte[] getLogoFile(string LogoFile)
        {
            if (!File.Exists(LogoFile))
            {
                return null;
            }
            using (System.Drawing.Image img = Bitmap.FromFile(LogoFile))
            {
                ImageFormat format = img.RawFormat;
                using (MemoryStream ms = new MemoryStream())
                {
                    if (format.Equals(ImageFormat.Jpeg))
                    {
                        img.Save(ms, ImageFormat.Jpeg);
                    }
                    else if (format.Equals(ImageFormat.Png))
                    {
                        img.Save(ms, ImageFormat.Png);
                    }
                    else if (format.Equals(ImageFormat.Bmp))
                    {
                        img.Save(ms, ImageFormat.Bmp);
                    }
                    else if (format.Equals(ImageFormat.Gif))
                    {
                        img.Save(ms, ImageFormat.Gif);
                    }
                    else if (format.Equals(ImageFormat.Icon))
                    {
                        img.Save(ms, ImageFormat.Icon);
                    }
                    else
                    {
                        img.Save(ms, ImageFormat.Png);
                    }
                    byte[] buffer = new byte[ms.Length];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }
        }
    }
}
