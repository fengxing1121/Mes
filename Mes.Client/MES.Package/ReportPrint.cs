using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportRendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ThoughtWorks.QRCode.Codec;

namespace Mes.Package
{
    /// <summary>
    /// 打印方法类
    /// </summary>
    public class ReportPrint
    {
        public string LogoFile { get; set; }
        public short CopyQty { get; set; }
        public void Print(SearchResult sr)
        {

            using (ProxyBE p = new ProxyBE())
            {
                #region:100*55的条码
                /*
                DataSet ds = new DataSet("DataSet1");
                DataTable tb = sr.DataSet.Tables[0].Copy();
                tb.Columns.Add(new DataColumn("Remarks", typeof(string)));
                tb.Columns.Add(new DataColumn("PackageDesc", typeof(string)));
                tb.Columns.Add(new DataColumn("Qty", typeof(int)));
                tb.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
                tb.Columns.Add(new DataColumn("Logo", typeof(byte[])));
                tb.Columns.Add(new DataColumn("Style", typeof(string)));
                tb.Columns.Add(new DataColumn("PrintDate", typeof(string)));
                tb.Columns.Add(new DataColumn("Color", typeof(string)));

                //重置报表数据列
                foreach (DataRow row in tb.Rows)
                {
                    SearchPackageDetailArgs subArgs = new SearchPackageDetailArgs();
                    subArgs.OrderID = (Guid)row["OrderID"];
                    subArgs.PackageID = (Guid)row["PackageID"];
                    SearchResult subResult = p.Client.SearchPackageDetail(null, subArgs);

                    int totalQty = 0;
                    //string CabinetNum = "";
                    string remarks = "";
                    string strColor = "";
                    int rowscount = 1;

                    var query = from g in subResult.DataSet.Tables[0].AsEnumerable()
                                group g by new { 
                                    Size = g.Field<string>("Size"), 
                                    PackageNum = g.Field<int>("PackageNum"), 
                                    PackageBarcode = g.Field<string>("PackageBarcode"), 
                                    MaterialType = g.Field<string>("MaterialType"), 
                                    ItemName = g.Field<string>("ItemName"), 
                                    MadeLength = g.Field<decimal>("MadeLength"), 
                                    MadeWidth = g.Field<decimal>("MadeWidth"),
                                    MadeHeight = g.Field<decimal>("MadeHeight") 
                                } into lists_Package
                        select new {
                            ItemName = lists_Package.Key.ItemName,
                            MaterialType = lists_Package.Key.MaterialType,
                            Size = lists_Package.Key.Size,
                            PackageBarcode = lists_Package.Key.PackageBarcode,
                            PackageNum = lists_Package.Key.PackageNum, 
                            MadeWidth = lists_Package.Key.MadeWidth,
                            MadeLength = lists_Package.Key.MadeLength,
                            MadeHeight = lists_Package.Key.MadeHeight,
                            Qty = lists_Package.Sum(n => n.Field<int>("Qty"))
                           };

                    if (query.ToList().Count > 0)
                    {
                        var lists = query.ToList();
                        foreach( var item in lists)
                        {
                            if (rowscount > 10)
                            {
                                break;
                            }
                            totalQty += item.Qty;
                            if (item.ItemName.Length > 4)
                            {
                                remarks += string.Format("{0}:{1}*{2}*{3}={4}\r\n", item.ItemName.Substring(0, 4), item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
                            }
                            else
                            {
                                remarks += string.Format("{0}:{1}*{2}*{3}={4}\r\n", item.ItemName, item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
                            }
                            strColor = item.MaterialType;
                            rowscount++;
                        };
                    }

                    string size = row["Size"].ToString();
                    row["Qty"] = totalQty;
                    row["Color"] = strColor;
                    row["Remarks"] = remarks;
                    row["Barcode"] = getQRcode(row["PackageBarcode"].ToString());
                    row["PackageDesc"] = string.Format("第{0}包共  包", row["PackageNum"]);
                    row["Logo"] = getLogoFile();
                    row["Style"] = "规格：" + size;
                    row["PrintDate"] = DateTime.Now.ToString("日期:yyyy-MM-dd");
                }
                ds.Tables.Add(tb);
                Microsoft.Reporting.WinForms.ReportDataSource rptDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                rptDataSource.Name = "DataSet1";
                rptDataSource.Value = ds.Tables[0];

                LocalReport report = new LocalReport();
                report.DataSources.Clear();
                //设置需要打印的报表的文件名称。            
                report.ReportEmbeddedResource = "Mes.Package.Report.rptPackage.rdlc";
                report.DataSources.Add(rptDataSource);
                //刷新报表中的需要呈现的数据
                report.Refresh();
                PrintStream(report);
                */
                #endregion
                #region 100*70的条码
                DataSet ds = new DataSet("dsPackageLabel");
                DataTable tb = sr.DataSet.Tables[0].Copy();
                tb.Columns.Add(new DataColumn("Remarks", typeof(string)));
                tb.Columns.Add(new DataColumn("PackageDesc", typeof(string)));
                tb.Columns.Add(new DataColumn("Qty", typeof(int)));
                tb.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
                tb.Columns.Add(new DataColumn("Logo", typeof(byte[])));
                tb.Columns.Add(new DataColumn("PrintDate", typeof(string)));


                //重置报表数据列
                foreach (DataRow row in tb.Rows)
                {
                    SearchPackageDetailArgs subArgs = new SearchPackageDetailArgs();
                    subArgs.OrderID = (Guid)row["OrderID"];
                    subArgs.PackageID = (Guid)row["PackageID"];
                    SearchResult subResult = p.Client.SearchPackageDetail(null, subArgs);

                    int totalQty = 0;
                    string remarks = "";
                    string strColor = "";
                    int rowscount = 1;

                    var query = from g in subResult.DataSet.Tables[0].AsEnumerable()
                                group g by new
                                {
                                    Size = g.Field<string>("Size"),
                                    PackageNum = g.Field<int>("PackageNum"),
                                    PackageBarcode = g.Field<string>("PackageBarcode"),
                                    MaterialType = g.Field<string>("MaterialType"),
                                    ItemName = g.Field<string>("ItemName"),
                                    MadeLength = g.Field<decimal>("MadeLength"),
                                    MadeWidth = g.Field<decimal>("MadeWidth"),
                                    MadeHeight = g.Field<decimal>("MadeHeight")
                                } into lists_Package
                                select new
                                {
                                    ItemName = lists_Package.Key.ItemName,
                                    MaterialType = lists_Package.Key.MaterialType,
                                    Size = lists_Package.Key.Size,
                                    PackageBarcode = lists_Package.Key.PackageBarcode,
                                    PackageNum = lists_Package.Key.PackageNum,
                                    MadeWidth = lists_Package.Key.MadeWidth,
                                    MadeLength = lists_Package.Key.MadeLength,
                                    MadeHeight = lists_Package.Key.MadeHeight,
                                    Qty = lists_Package.Sum(n => n.Field<int>("Qty"))
                                };

                    if (query.ToList().Count > 0)
                    {
                        var lists = query.ToList();
                        foreach (var item in lists)
                        {
                            if (rowscount > 10)
                            {
                                break;
                            }
                            totalQty += item.Qty;
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

                            if (item.ItemName.Length > 4)
                            {
                                remarks += string.Format("{0}:{1}*{2}*{3}={4}\r\n", itemName.Substring(0, 4), item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
                            }
                            else
                            {
                                remarks += string.Format("{0}:{1}*{2}*{3}={4}\r\n", itemName, item.MadeLength.ToString("#"), item.MadeWidth.ToString("#"), item.MadeHeight.ToString("#"), item.Qty);
                            }
                            strColor = item.MaterialType;
                            rowscount++;
                        };
                    }
                    row["Qty"] = totalQty;
                    row["Remarks"] = remarks;
                    row["Address"] = row["Province"].ToString() + row["City"].ToString() + row["Address"].ToString();
                    row["Barcode"] = getQRcode(row["PackageBarcode"].ToString());
                    row["PackageDesc"] = string.Format("第 {0} 包", int.Parse(row["PackageNum"].ToString()).ToString("00"));
                    row["Logo"] = getLogoFile();
                    row["PrintDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                }
                ds.Tables.Add(tb);


                ReportDataSource rptDataSource = new ReportDataSource();
                rptDataSource.Name = "dsPackageLabel";
                rptDataSource.Value = ds.Tables[0];

                LocalReport report = new LocalReport();
                report.DataSources.Clear();
                //设置需要打印的报表的文件名称。            
                report.ReportEmbeddedResource = "Mes.Package.Report.rptPackageLabel.rdlc";
                report.DataSources.Add(rptDataSource);
                //刷新报表中的需要呈现的数据
                report.Refresh();
                PrintStream(report);
                #endregion

            }
        }
        /// <summary>
        /// 补打标签
        /// </summary>
        /// <param name="sr"></param>
        public void DocumentPrint(SearchResult sr)
        {
            using (ProxyBE p = new ProxyBE())
            {
                #region 70*200mm的条码
                DataSet ds = new DataSet("tbPackageDataTable");
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
                foreach (DataRow row in sr.DataSet.Tables[0].Rows)
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
                    int rows = lists.Count / 3 + (lists.Count % 3 > 0 ? 1 : 0);
                    int totalQty = subResult.Total;
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
                        newRow["Barcode"] = getQRcode(row["PackageBarcode"].ToString());
                        newRow["PackageDesc"] = string.Format("第 {0} 包", int.Parse(row["PackageNum"].ToString()).ToString("00"));
                        newRow["Logo"] = getLogoFile();
                        newRow["PrintDate"] = DateTime.Now.ToString("yyyy年MM月dd日");

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
                        newRow["ItemsQty"] = totalQty;
                        tb.Rows.Add(newRow);
                    }
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
                        newRow["Barcode"] = getQRcode(row["PackageBarcode"].ToString());
                        newRow["PackageDesc"] = string.Format("第 {0} 包", int.Parse(row["PackageNum"].ToString()).ToString("00"));
                        newRow["Logo"] = getLogoFile();
                        newRow["PrintDate"] = DateTime.Now.ToString("yyyy年MM月dd日");
                        newRow["ItemName_1"] = "";
                        newRow["ItemName_2"] = "";
                        newRow["ItemName_3"] = "";
                        newRow["ItemsQty"] = totalQty;
                        tb.Rows.Add(newRow);
                    }
                }
                ds.Tables.Add(tb);

                ReportDataSource rptDataSource = new ReportDataSource();
                rptDataSource.Name = "tbPackageDataTable";
                rptDataSource.Value = ds.Tables[0];

                LocalReport report = new LocalReport();
                report.DataSources.Clear();
                //设置需要打印的报表的文件名称。            
                report.ReportEmbeddedResource = "Mes.Package.Report.Report1.rdlc";
                report.DataSources.Add(rptDataSource);
                //刷新报表中的需要呈现的数据
                report.Refresh();
                PrintStream(report);
                #endregion
            }
        }
        public void PrintCommonLabel(Guid CabinetID, string CategoryName)
        {
            CrptDataSource rptdata = new CrptDataSource();
            DataSet ds = rptdata.GetCommonLabelDataSource(CabinetID, CategoryName, this.LogoFile);
            ReportDataSource rptDataSource = new ReportDataSource();
            rptDataSource.Name = "tbPackageDataTable";
            rptDataSource.Value = ds.Tables[0];

            LocalReport report = new LocalReport();
            report.DataSources.Clear();
            //设置需要打印的报表的文件名称。            
            report.ReportEmbeddedResource = "Mes.Package.Report.rptDoorLabel.rdlc";
            report.DataSources.Add(rptDataSource);
            //刷新报表中的需要呈现的数据
            report.Refresh();
            PrintStream(report);
        }

        private byte[] get2DBarcode(string barcode)
        {
            try
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.BackColor = System.Drawing.Color.White;//图片背景颜色
                b.ForeColor = System.Drawing.Color.Black;//条码颜色
                b.IncludeLabel = true;
                b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//code的显示位置
                b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;//图片格式
                System.Drawing.Font font = new System.Drawing.Font("verdana", 16f);//字体设置
                b.LabelFont = font;
                b.Height = 80;//图片高度设置(px单位)
                b.Width = 400;//图片宽度设置(px单位)
                b.Encode(BarcodeLib.TYPE.CODE128, barcode);//生成图片                        
                byte[] imgData = b.GetImageData(BarcodeLib.SaveTypes.PNG);
                return imgData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private byte[] getQRcode(string qrcode)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 2;
            qrCodeEncoder.QRCodeVersion = 2;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(qrcode);
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                else
                {
                    image.Save(ms, ImageFormat.Png);
                }
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private byte[] getLogoFile()
        {
            if (!File.Exists(this.LogoFile))
            {
                return null;
            }
            using (System.Drawing.Image img = Bitmap.FromFile(this.LogoFile))
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

        /// <summary>
        /// 用来记录当前打印到第几页了
        /// </summary>
        private int m_currentPageIndex;
        /// <summary>
        /// 声明一个Stream对象的列表用来保存报表的输出数据,LocalReport对象的Render方法会将报表按页输出为多个Stream对象。
        /// </summary>
        private IList<Stream> m_streams;
        private bool isLandSapces = false;
        /// <summary>
        /// 用来提供Stream对象的函数，用于LocalReport对象的Render方法的第三个参数。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fileNameExtension"></param>
        /// <param name="encoding"></param>
        /// <param name="mimeType"></param>
        /// <param name="willSeek"></param>
        /// <returns></returns>
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //如果需要将报表输出的数据保存为文件，请使用FileStream对象。
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        /// <summary>
        /// 为Report.rdlc创建本地报告加载数据,输出报告到.emf文件,并打印,同时释放资源
        /// </summary>
        /// <param name="rv">参数:ReportViewer.LocalReport</param>
        public void PrintStream(LocalReport rvDoc)
        {
            //获取LocalReport中的报表页面方向
            isLandSapces = rvDoc.GetDefaultPageSettings().IsLandscape;
            Export(rvDoc);
            PrintSetting();
            DisposeObject();
        }
        private void Export(LocalReport report)
        {
            string deviceInfo =
            @"<DeviceInfo>
                 <OutputFormat>EMF</OutputFormat>
             </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            //将报表的内容按照deviceInfo指定的格式输出到CreateStream函数提供的Stream中。
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private void PrintSetting()
        {

            string filename = Path.Combine(Application.StartupPath, "Profile.xml");
            if (!File.Exists(filename)) return;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNode xmlNode = xmlDoc.DocumentElement;

            string defaultPrint = "";
            if (xmlNode != null)
            {
                if (xmlNode["PrinterName"] != null)
                    defaultPrint = xmlNode["PrinterName"].InnerText;
            }
            xmlDoc = null;

            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("错误:没有检测到打印数据流");
            //声明PrintDocument对象用于数据的打印
            PrintDocument printDoc = new PrintDocument();
            //获取配置文件的清单打印机名称
            //System.Configuration.AppSettingsReader appSettings = new System.Configuration.AppSettingsReader();
            printDoc.PrinterSettings.PrinterName = defaultPrint;// appSettings.GetValue("QDPrint", Type.GetType("System.String")).ToString();
            printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();//指定打印机不显示页码 
            //判断指定的打印机是否可用
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("错误:找不到打印机");
            }
            else
            {
                //设置打印机方向遵从报表方向
                //printDoc.DefaultPageSettings.Landscape = isLandSapces;
                //声明PrintDocument对象的PrintPage事件，具体的打印操作需要在这个事件中处理。
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                //设置打印机打印份数
                printDoc.PrinterSettings.Copies = CopyQty;// 1;
                //执行打印操作，Print方法将触发PrintPage事件。
                printDoc.Print();
            }
        }
        /// <summary>
        /// 处理程序PrintPageEvents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            //Metafile对象用来保存EMF或WMF格式的图形，
            //我们在前面将报表的内容输出为EMF图形格式的数据流。
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            //调整打印机区域的边距
            System.Drawing.Rectangle adjustedRect = new System.Drawing.Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            //绘制一个白色背景的报告
            //ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            //获取报告内容
            //这里的Graphics对象实际指向了打印机
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            //ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            // 准备下一个页,已确定操作尚未结束
            m_currentPageIndex++;

            //设置是否需要继续打印
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void DisposeObject()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }
}
