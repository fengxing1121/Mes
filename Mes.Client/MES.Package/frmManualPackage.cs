using SpeechLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using System.Threading;
using ThoughtWorks.QRCode.Codec;
using Mes.Client.Service.BE;
using MES.Libraries;
using Mes.Client.Service;
using Mes.Package.Common;

namespace Mes.Package
{
    public partial class frmManualPackage : Form
    {

        SerialPort ComPort = new SerialPort();
        bool VoiceFlag = false;
        string FinishedBarcode = "";
        string LogoFile = "";
        //包限重
        decimal MaxWeight = 0;
        //板件密度
        decimal Density = 0;
        //打印份数
        int PrintQty = 1;
        SpVoice Voice;
        string defaultPrint = "";
        Guid WorkShiftID = Guid.Empty;
        Guid WorkFlowID = Guid.Empty;

        public frmManualPackage()
        {
            InitializeComponent();
        }
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ScanBarcode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Order CurrentOrder
        {
            get;
            set;
        }
        private Mes.Client.Service.BE.Package CurrentPackage
        {
            get;
            set;
        }
        private void biForm()
        {
            listPackage();
            listDetail();
        }
        private void listPackage()
        {
            if (this.dgPackage.InvokeRequired)
            {
                this.dgPackage.Invoke(new Action(listPackage));
            }
            else
            {
                //刷新当前包列表
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPackageDetailArgs packageArgs = new SearchPackageDetailArgs();
                    packageArgs.OrderBy = "[BarcodeNo] ASC";
                    if (this.CurrentOrder != null)
                    {
                        packageArgs.OrderID = this.CurrentOrder.OrderID;
                    }
                    packageArgs.IsDisabled = false;

                    if (this.CurrentPackage != null)
                    {
                        packageArgs.CabinetID = CurrentPackage.CabinetID;
                    }
                    SearchResult sr = p.Client.SearchPackageDetail(CGlobal.SenderUser, packageArgs);
                    this.dgPackage.AutoGenerateColumns = false;
                    this.dgPackage.DataSource = sr.DataSet.Tables[0];
                    this.dgPackage.Refresh();
                }
            }
        }
        private void listDetail()
        {
            if (this.dgPackage.InvokeRequired)
            {
                this.dgPackage.Invoke(new Action(listDetail));
            }
            else
            {
                using (ProxyBE p = new ProxyBE())
                {
                    //刷新当前未分包板件列表
                    SearchPackageDetailArgs unpackageArgs = new SearchPackageDetailArgs();
                    if (!string.IsNullOrEmpty(this.txtOrderNo.Text.Trim()))
                    {
                        unpackageArgs.OrderNo = this.txtOrderNo.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(this.txtCabinetName.Text.Trim()))
                    {
                        unpackageArgs.CabinetName = this.txtCabinetName.Text.Trim();
                    }
                    if (this.CurrentPackage != null)
                    {
                        unpackageArgs.CabinetID = CurrentPackage.CabinetID;
                    }
                    if (!string.IsNullOrEmpty(this.txtBarcode_S.Text.Trim()))
                    {
                        unpackageArgs.Barcode = this.txtBarcode_S.Text.Trim();
                    }
                    unpackageArgs.OrderBy = "[BarcodeNo] ASC";
                    if (this.CurrentOrder != null)
                    {
                        unpackageArgs.OrderID = this.CurrentOrder.OrderID;
                    }
                    unpackageArgs.IsDisabled = false;
                    unpackageArgs.IsPakaged = false;
                    SearchResult srUnPack = p.Client.SearchPackageDetail(CGlobal.SenderUser, unpackageArgs);
                    this.listBarcodes.Items.Clear();
                    foreach (DataRow row in srUnPack.DataSet.Tables[0].Rows)
                    {
                        string text = string.Format("{0},{1}:{2} * {3} * {4} = 1", row["BarcodeNo"].ToString(), row["ItemName"].ToString(), decimal.Parse(row["MadeLength"].ToString()).ToString("#"), decimal.Parse(row["MadeWidth"].ToString()).ToString("#"), decimal.Parse(row["MadeHeight"].ToString()).ToString("#"), decimal.Parse(row["Qty"].ToString()).ToString("#"));
                        this.listBarcodes.Items.Add(text);
                    }
                    this.gbAll.Text = string.Format("未分包板件 -- 共{0}件", srUnPack.DataSet.Tables[0].Rows.Count);
                }
            }
        }
        delegate void dreadbarcode();
        private void ScanBarcode()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new dreadbarcode(ScanBarcode), null);
            }
            else
            {
                if (WorkFlowID == Guid.Empty)
                {
                    throw new Exception("请在参数设置中设置班次和分拣对应的工序名称。");
                }
                if (WorkShiftID == Guid.Empty)
                {
                    throw new Exception("请在参数设置中设置班次和分拣对应的工序名称。");
                }
                string ItemBarcode = this.txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(ItemBarcode))
                {
                    this.txtBarcode.Clear();
                    this.txtBarcode.Focus();
                    lblMsg.Text = "【提示】请扫描板件条码";
                    PlayVoice("请扫描板件条码");
                    return;
                }
                #region 完成当前分包操作
                if (ItemBarcode.IndexOf(FinishedBarcode) >= 0 && !string.IsNullOrEmpty(FinishedBarcode))
                {
                    try
                    {
                        //打印分包标签
                        PlayVoice("打印标签");
                        //PrintDocument();
                        StartPrint(this.CurrentPackage.PackageID);
                        this.txtBarcode.Text = "";
                        this.txtBarcode.Focus();
                        this.CurrentPackage = null;
                    }
                    catch (Exception ex)
                    {
                        this.CurrentPackage = null;
                        throw ex;
                    }
                    return;
                }
                #endregion

                using (ProxyBE p = new ProxyBE())
                {

                    OrderDetail subOrder = p.Client.GetOrderDetailByBarcode(CGlobal.SenderUser, ItemBarcode);
                    if (subOrder == null)
                    {
                        this.txtBarcode.Clear();
                        this.txtBarcode.Focus();
                        lblMsg.Text = string.Format("提示:【{0}】条码无效", ItemBarcode);
                        PlayVoice("条码错误");
                        return;
                    }

                    Order order = p.Client.GetOrder(CGlobal.SenderUser, subOrder.OrderID);
                    //初始化订单数据:如果当前订单ID与条码的订单ID不一至时则重置订单信息
                    if (CurrentOrder == null)
                    {
                        this.CurrentOrder = order;
                        this.txtOrderNo.Text = this.CurrentOrder.OrderNo;
                    }
                    //判断当前的板件是否为同一订单板件
                    else if (subOrder.OrderID != this.CurrentOrder.OrderID)
                    {
                        this.txtBarcode.Clear();
                        this.txtBarcode.Focus();
                        lblMsg.Text = "【错误】板件订单号不一致";
                        PlayVoice("订单不一致");
                        MessageBox.Show("板件订单号不一致");
                        return;
                    }

                    List<PackageDetail> pdsubOrder = p.Client.GetPackageDetailsByItemID(CGlobal.SenderUser, subOrder.ItemID);
                    pdsubOrder = pdsubOrder.FindAll(li => li.IsPakaged == false);
                    if (pdsubOrder.Count == 0)
                    {
                        this.txtBarcode.Clear();
                        this.txtBarcode.Focus();
                        lblMsg.Text = string.Format("提示:【{0}】条码重复扫描", ItemBarcode);
                        PlayVoice("重复扫描");
                        return;
                    }

                    
                    decimal weight = subOrder.MadeHeight * subOrder.MadeLength * subOrder.MadeWidth * 0.000001M * Density;
                    if (this.CurrentPackage != null)
                    {
                        if (this.CurrentPackage.Weight + weight >= MaxWeight)
                        {
                            //打印分包标签
                            PlayVoice("打印标签");
                            StartPrint(this.CurrentPackage.PackageID);
                            this.txtBarcode.Text = "";
                            this.txtBarcode.Focus();
                            this.CurrentPackage = null;
                        }
                    }

                    Order2Cabinet cabinet = p.Client.GetOrder2Cabinet(CGlobal.SenderUser, subOrder.CabinetID);
                    if (cabinet != null)
                    {
                        //初始化包数据
                        if (this.CurrentPackage == null)
                        {
                            Mes.Client.Service.BE.Package pack = new Mes.Client.Service.BE.Package();
                            pack.OrderID = this.CurrentOrder.OrderID;
                            int pageNum = 0;
                            pageNum = p.Client.GetMaxPackageNum(CGlobal.SenderUser, pack.OrderID, subOrder.CabinetID);
                            pack.CabinetID = subOrder.CabinetID;
                            pack.PackageNum = pageNum;
                            pack.PackageID = Guid.NewGuid();
                            pack.PackageBarcode = string.Format("0{0}{1}", CurrentOrder.Created.ToString("yyMMddHHmmss"), pageNum.ToString("00"));
                            pack.PackageLength = 0;
                            pack.PackageHeight = 0;
                            pack.PackageWidth = 0;
                            pack.ItemsQty = 0;
                            this.CurrentPackage = pack;
                            this.txtCabinetName.Text = cabinet.CabinetName;
                        }
                        else if (CurrentPackage.CabinetID != cabinet.CabinetID)
                        {
                            this.txtBarcode.Clear();
                            this.txtBarcode.Focus();
                            lblMsg.Text = "【错误】柜体不一致!";
                            PlayVoice("柜体不一致");
                            return;
                        }
                    }
                    else
                    {
                        lblMsg.Text = string.Format("提示:【{0}】条码所属柜体数据丢失，请查看订单是否有误！", ItemBarcode);
                        PlayVoice("订单错误");
                        return;
                    }                   
                                      

                    try
                    {
                        p.Client.ScanBarcode(CGlobal.SenderUser, ItemBarcode, WorkShiftID, WorkFlowID);
                    }
                    catch (Exception ex)
                    {
                        PLogger.LogError(ex);
                        this.txtBarcode.Clear();
                        this.txtBarcode.Focus();
                        lblMsg.Text = ex.Message;
                        PlayVoice("扫描失败");
                        return;
                    }

                    this.CurrentPackage.Weight += weight;
                    this.CurrentPackage.ItemsQty += 1;

                    SavePackageArgs saveArgs = new SavePackageArgs();
                    saveArgs.Package = this.CurrentPackage;
                    PackageDetail packageDetail = pdsubOrder[0];
                    packageDetail.IsPakaged = true;
                    packageDetail.PakageID = this.CurrentPackage.PackageID;
                    saveArgs.PackageDetail = packageDetail;
                    p.Client.SavePackage(CGlobal.SenderUser, saveArgs);

                    this.CurrentPackage = p.Client.GetPackage(CGlobal.SenderUser, this.CurrentPackage.PackageID);
                    this.gbPackage.Text = string.Format("当前：第{0}包", this.CurrentPackage.PackageNum);

                    //刷新列表
                    biForm();
                    this.txtBarcode.Clear();
                    this.txtBarcode.Focus();
                    lblMsg.Text = "扫描完成";
                    PlayVoice("OK");

                    //检查是否已经全部扫描完成
                    if (this.listBarcodes.Items.Count == 0)
                    {
                        //打印分包标签
                        PlayVoice("打印标签");
                        //PrintDocument();
                        StartPrint(this.CurrentPackage.PackageID);
                        this.txtBarcode.Text = "";
                        this.txtBarcode.Focus();
                        this.CurrentPackage = null;

                        cabinet.CabinetStatus = "F";
                        SaveOrder2CabinetArgs cabinetArgs = new SaveOrder2CabinetArgs();
                        cabinetArgs.Order2Cabinet = cabinet;
                        p.Client.SaveOrder2Cabinet(CGlobal.SenderUser, cabinetArgs);

                        SearchPackageDetailArgs p_args = new SearchPackageDetailArgs();
                        p_args.IsDisabled = false;
                        p_args.OrderID = CurrentOrder.OrderID;
                        p_args.IsPakaged = false;

                        SearchResult p_sr = p.Client.SearchPackageDetail(CGlobal.SenderUser, p_args);
                        if (p_sr.Total == 0)
                        {
                            //Order order = p.Client.GetOrder(CGlobal.SenderUser, CurrentOrder.OrderID);
                            order.Status = "I"; //全部打包完成后，订单状态变成待入库
                            SaveOrderArgs saveOrderArgs = new SaveOrderArgs();
                            saveOrderArgs.Order = order;
                            p.Client.SaveOrder(CGlobal.SenderUser, saveOrderArgs);
                        }
                    }
                    //加载树
                    initTree();
                }
            }
        }

        private void StartPrint(Guid PackageID)
        {
            BackgroundWorker _bgwork = new BackgroundWorker();
            _bgwork.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                PrintDocument(PackageID);
            };
            _bgwork.RunWorkerAsync();
        }

        private void PrintDocument(Guid PackageID)
        {
            //if (this.CurrentOrder == null) return;
            //if (this.CurrentPackage == null) return;
            using (ProxyBE p = new ProxyBE())
            {
                //打印标签               
                SearchPackageArgs args = new SearchPackageArgs();
                args.OrderBy = "[PackageNum] asc";
                //args.OrderID = this.CurrentOrder.OrderID;
                args.PackageID = PackageID;// CurrentPackage.PackageID;
                SearchResult sr = p.Client.SearchPackage(CGlobal.SenderUser, args);

                if (sr.Total == 0)
                {
                    throw new Exception("此订单未设置包装数据。");
                }

                ReportPrint rpt = new ReportPrint();
                rpt.CopyQty = (short)this.PrintQty;
                rpt.LogoFile = this.LogoFile;
                rpt.DocumentPrint(sr);
                //重置数据
                this.CurrentPackage = null;
            }
        }
        private void PlayVoice(string message)
        {
            try
            {
                if (VoiceFlag)
                {
                    if (Voice == null)
                        Voice = new SpVoice();
                    SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                    Voice.Speak(message, SpFlags);
                }
            }
            catch (Exception ex)
            {
                VoiceFlag = false;
                PLogger.LogError(ex);
            }
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);
                string receiveData = "";
                // 获取字节长度
                int bytes = ComPort.BytesToRead;
                // 创建字节数组
                byte[] buffer = new byte[bytes];
                // 读取缓冲区的数据到数组
                ComPort.Read(buffer, 0, bytes);
                receiveData += ByteArrayToHexString(buffer).Replace(" ", "").Replace("\r\n", "");
                if (txtBarcode.InvokeRequired)
                {
                    dgSetText d = new dgSetText(SetText);
                    txtBarcode.Invoke(d, receiveData);
                }
                else
                {
                    this.txtBarcode.Text = receiveData;
                }
                BackgroundWorker _bw = new BackgroundWorker();
                _bw.DoWork += delegate(object s, DoWorkEventArgs args)
                {
                    ScanBarcode();
                };
                _bw.RunWorkerAsync();
                receiveData = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        delegate void dgSetText(string text);

        private void SetText(string text)
        {
            this.txtBarcode.Text = text;
        }
        /// <summary>
        /// 字节数组转换十六进制
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToChar(b));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 下一包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentPackage == null)
                {
                    throw new Exception("请选择要打印的订单和包号。");
                }
                PlayVoice("打印标签");                
                StartPrint(this.CurrentPackage.PackageID);
                this.txtBarcode.Text = "";
                this.txtBarcode.Focus();
                this.CurrentPackage = null;
                this.gbPackage.Text = "当前：新包号";
            }
            catch (Exception ex)
            {
                this.CurrentPackage = null;
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmManualPackage_Load(object sender, EventArgs e)
        {
            try
            {
                PLogger.Listeners.Clear();
                PLogger.Listeners.Add(new PTraceListener("PK", Path.Combine(Config.WorkingFolder, "PK")));
                InitData();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }
        /// <summary>
        /// 加载xml参数设置数据
        /// </summary>
        private void InitData()
        {

            if (ComPort.IsOpen)
            {
                ComPort.Close();
            }
            string filename = Path.Combine(Application.StartupPath, "Profile.xml");
            if (!File.Exists(filename)) return;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNode xmlNode = xmlDoc.DocumentElement;

            bool useComPort = false;
            if (xmlNode != null)
            {
                if (xmlNode["UseCOMPort"] != null)
                    useComPort = bool.Parse(xmlNode["UseCOMPort"].InnerText);
                if (xmlNode["Barcode"] != null)
                    FinishedBarcode = xmlNode["Barcode"].InnerText;

                if (useComPort)//使用COM口条码枪
                {
                    if (xmlNode["PortName"] != null)
                        ComPort.PortName = xmlNode["PortName"].InnerText;

                    if (xmlNode["StopBits"] != null&& xmlNode["StopBits"].InnerText!="None")
                        ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), xmlNode["StopBits"].InnerText);

                    if (xmlNode["BaudRate"] != null && xmlNode["BaudRate"].InnerText != "None")
                        ComPort.BaudRate = int.Parse(xmlNode["BaudRate"].InnerText);

                    if (xmlNode["DataBits"] != null && xmlNode["DataBits"].InnerText != "None")
                        ComPort.DataBits = int.Parse(xmlNode["DataBits"].InnerText);

                    if (xmlNode["Parity"] != null)
                        ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), xmlNode["Parity"].InnerText);
                }
                if (xmlNode["VoiceFlag"] != null)
                    VoiceFlag = bool.Parse(xmlNode["VoiceFlag"].InnerText);
                if (xmlNode["DefaultLogo"] != null)
                    LogoFile = Path.Combine(Application.StartupPath, "logoimgs\\" + xmlNode["DefaultLogo"].InnerText);
                if (xmlNode["MaxWeight"] != null)
                    MaxWeight = decimal.Parse(xmlNode["MaxWeight"].InnerText);
                if (xmlNode["Density"] != null)
                    Density = decimal.Parse(xmlNode["Density"].InnerText);
                if (xmlNode["PrintQty"] != null)
                    PrintQty = int.Parse(xmlNode["PrintQty"].InnerText);
                if (xmlNode["PrinterName"] != null)
                    defaultPrint = xmlNode["PrinterName"].InnerText;
                if (xmlNode["WorkFlowID"] != null)
                    WorkFlowID = new Guid(xmlNode["WorkFlowID"].InnerText);
                if (xmlNode["WorkShiftID"] != null)
                    WorkShiftID = new Guid(xmlNode["WorkShiftID"].InnerText);
            }
            this.txtBarcode.Clear();
            this.txtBarcode.Focus();
            if (File.Exists(this.LogoFile))
                this.pictureBox1.Image = Bitmap.FromFile(this.LogoFile);

            if (useComPort)
            {
                ComPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                ComPort.Open();
            }

            this.tsUser.Text = CGlobal.SenderUser.UserCode + "." + CGlobal.SenderUser.UserName;

            using (ProxyBE p = new ProxyBE())
            {
                if (WorkFlowID != Guid.Empty)
                {
                    WorkShift ws = p.Client.GetWorkShift(CGlobal.SenderUser, WorkShiftID);
                    if (ws != null)
                    {
                        this.tsShiftName.Text = ws.WorkShiftName;
                    }
                }
            }
        }
        /// <summary>
        /// 刷新当前未分包板件列表
        /// </summary>
        private void biObjects()
        {
            using (ProxyBE p = new ProxyBE())
            {
                //刷新当前未分包板件列表
                SearchPackageDetailArgs unpackageArgs = new SearchPackageDetailArgs();
                unpackageArgs.OrderBy = "[CabinetID],[PackageNum],[BarcodeNo] ASC";

                if (!string.IsNullOrEmpty(this.txtOrderNo.Text.Trim()))
                {
                    unpackageArgs.OrderNo = this.txtOrderNo.Text.Trim();
                }
                if (!string.IsNullOrEmpty(this.txtCabinetName.Text.Trim()))
                {
                    unpackageArgs.CabinetName = this.txtCabinetName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(this.txtBarcode_S.Text.Trim()))
                {
                    unpackageArgs.Barcode = this.txtBarcode_S.Text.Trim();
                }

                SearchResult srUnPack = p.Client.SearchPackageDetail(CGlobal.SenderUser, unpackageArgs);
                this.dgPackage.AutoGenerateColumns = false;
                this.dgPackage.DataSource = srUnPack.DataSet.Tables[0];
                this.dgPackage.Refresh();

                int unPackagedQty = srUnPack.DataSet.Tables[0].Select("IsPakaged=0").Length;

                var query = from g in srUnPack.DataSet.Tables[0].AsEnumerable()
                            group g by new
                            {
                                CabinetName = g.Field<string>("CabinetName"),
                                CabinetCode = g.Field<string>("CabinetCode"),
                            } into lists_Package
                            select new
                            {
                                CabinetName = lists_Package.Key.CabinetName,
                                CabinetCode = lists_Package.Key.CabinetCode,
                            };

                var lists = query.ToList();

                this.gbCurrent.Text = string.Format("产品合计：{2}件,板件合计：{0}件,其中未打包板件：{1}件", srUnPack.DataSet.Tables[0].Rows.Count, unPackagedQty, lists.Count());
            }
        }

        private void frmManualPackage_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (ComPort.IsOpen)
                {
                    ComPort.Close();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }
        private void btnSystemSetting_Click(object sender, EventArgs e)
        {
            try
            {
                frmSystemParamters frm = new frmSystemParamters();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string output_QRcode(string qrcode)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(qrcode);
            string filename = Path.Combine(Application.StartupPath, "logoimgs\\qr.png");
            image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            return filename;
        }
        /// <summary>
        /// 补打标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            try
            {
                SearchPackageArgs args = new SearchPackageArgs();
                //打印标签
                TreeNode tn = tvPackage.SelectedNode;
                if (tn != null)
                {
                    if (tn.Tag.ToString().Split(',')[0] == "B")
                    {
                        args.PackageID = new Guid(tn.Parent.Tag.ToString().Split(',')[1]);
                    }
                    else
                    {
                        args.PackageID = new Guid(tn.Tag.ToString().Split(',')[1]);
                    }
                }
                else
                {
                    throw new Exception("请选择需要补打的标签的包号。");
                }

                using (ProxyBE p = new ProxyBE())
                {
                    SearchResult sr = p.Client.SearchPackage(CGlobal.SenderUser, args);
                    if (sr.Total == 0)
                    {
                        throw new Exception("没有数据。");
                    }

                    ReportPrint rpt = new ReportPrint();
                    rpt.CopyQty = (short)this.PrintQty;
                    rpt.LogoFile = this.LogoFile;
                    rpt.DocumentPrint(sr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.btnSearch.Text = "请稍候...";
            this.btnSearch.Enabled = false;
            try
            {
                this.CurrentPackage = null;
                this.CurrentOrder = null;

                if (string.IsNullOrEmpty(this.txtOrderNo.Text))
                {
                    throw new Exception("请输入订单号!");
                }
                this.biObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.btnSearch.Text = "查找(&F)";
            this.btnSearch.Enabled = true;
        }

        /// <summary>
        /// 查询列表双击时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPackage_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgPackage.SelectedRows.Count == 0) return;
                using (ProxyBE p = new ProxyBE())
                {
                    DataGridViewRow row = dgPackage.SelectedRows[0];
                    if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                    {
                        Guid OrderID = new Guid(row.Cells[0].Value.ToString());
                        this.CurrentOrder = p.Client.GetOrder(CGlobal.SenderUser, OrderID);
                    }
                    //else
                    //{
                    //    this.CurrentOrder = null;
                    //}
                    if (!string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                    {
                        Guid PackageID = new Guid(row.Cells[2].Value.ToString());
                        this.CurrentPackage = p.Client.GetPackage(CGlobal.SenderUser, PackageID);
                        this.txtBarcode.Focus();
                        this.gbPackage.Text = string.Format("当前：第{0}包", this.CurrentPackage.PackageNum);
                        initTree();//右上已分包数据
                    }
                    else
                    {
                        this.CurrentPackage = null;
                        this.gbPackage.Text ="";
                        this.tvPackage.Nodes.Clear();
                    }
                    this.listDetail();//右下未分包数据
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmManualPackage_Resize(object sender, EventArgs e)
        {
            try
            {
                //gbCurrent.Width = this.Width /10 * 4;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportPrieview rpt = new frmReportPrieview();
                rpt.LogoFile = this.LogoFile;
                rpt.PreviewReport();
                rpt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void initTree()
        {
            try
            {
                TreeNode selected = null;
                if (this.tvPackage.SelectedNode != null)
                {
                    selected = this.tvPackage.SelectedNode;
                }
                this.tvPackage.Nodes.Clear();
                SearchPackageArgs args = new SearchPackageArgs();
                if (CurrentOrder != null)
                {
                    args.OrderID = CurrentOrder.OrderID;
                }
                else
                {
                    return;
                }
                if (CurrentPackage != null)
                {
                    args.CabinetID = CurrentPackage.CabinetID;
                }
                if (!string.IsNullOrEmpty(this.txtCabinetName.Text))
                {
                    args.CabinetName = this.txtCabinetName.Text;
                }
                args.OrderBy = "PackageNum ASC";
                using (ProxyBE p = new ProxyBE())
                {
                    SearchResult sr = p.Client.SearchPackage(CGlobal.SenderUser, args);
                    DataTable tb_cabinet = sr.DataSet.Tables[0].DefaultView.ToTable(true, "CabinetID");
                    foreach (DataRow cabinet_row in tb_cabinet.Rows)
                    {
                        Order2Cabinet cabinet = p.Client.GetOrder2Cabinet(CGlobal.SenderUser, new Guid(cabinet_row["CabinetID"].ToString()));
                        if (cabinet == null) return;
                        TreeNode rootnode = new TreeNode();
                        rootnode.Text = string.Format("{0}({1},{2},{3},{4})", cabinet.CabinetName, cabinet.Size, cabinet.Color, cabinet.MaterialCategory, cabinet.MaterialStyle);
                        rootnode.Tag = "C," + cabinet.CabinetID;
                        DataRow[] rows = sr.DataSet.Tables[0].Select("CabinetID='" + cabinet_row["CabinetID"].ToString() + "'");
                        foreach (DataRow row in rows)
                        {
                            TreeNode tn = new TreeNode();
                            SearchPackageDetailArgs suborderArgs = new SearchPackageDetailArgs();
                            suborderArgs.PackageID = new Guid(row["PackageID"].ToString());
                            SearchResult subSr = p.Client.SearchPackageDetail(CGlobal.SenderUser, suborderArgs);
                            decimal weight = 0;
                            foreach (DataRow rw in subSr.DataSet.Tables[0].Rows)
                            {
                                TreeNode subnode = new TreeNode();
                                subnode.Text = string.Format("{0},{1}:{2} * {3} * {4}", rw["BarcodeNo"].ToString(), rw["ItemName"].ToString(), decimal.Parse(rw["MadeLength"].ToString()).ToString("#"), decimal.Parse(rw["MadeWidth"].ToString()).ToString("#"), decimal.Parse(rw["MadeHeight"].ToString()).ToString("#"));
                                subnode.Tag = "B," + rw["ItemID"].ToString();
                                tn.Nodes.Add(subnode);
                                weight += weight = decimal.Parse(rw["MadeHeight"].ToString()) * decimal.Parse(rw["MadeLength"].ToString()) * decimal.Parse(rw["MadeWidth"].ToString()) * 0.000001M * Density;
                            }
                            tn.Text = string.Format("第{0}包,包重：{1}KG,板件数量：{2}块", row["PackageNum"].ToString(), weight.ToString("#0.00"), subSr.Total);
                            tn.Tag = "P," + row["PackageID"].ToString();

                            if (selected == null && this.CurrentPackage != null)
                            {
                                if (row["PackageID"].ToString() == this.CurrentPackage.PackageID.ToString())
                                {
                                    selected = tn;
                                }
                            }
                            rootnode.Nodes.Add(tn);
                        }
                        if (selected != null && selected.Text != "")
                        {
                            this.tvPackage.SelectedNode = selected;
                            selected.Expand();
                        }
                        rootnode.Expand();
                        this.tvPackage.Nodes.Add(rootnode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("加载数据失败。原因：" + ex.Message);
            }
        }

        private void dgPackage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgPackage.ColumnCount - 1)
                {
                    if (e.Value.ToString().ToLower() == "true")
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.Red;
                        e.Value = "OK";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.Font = new Font("宋体", 11, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnPreivew_Click(object sender, EventArgs e)
        {
            try
            {
                SearchPackageArgs args = new SearchPackageArgs();

                if (this.CurrentPackage != null)
                {
                    args.PackageID = this.CurrentPackage.PackageID;
                }
                if (this.CurrentOrder != null)
                {
                    args.OrderID = CurrentOrder.OrderID;
                }
                if (this.CurrentPackage== null&& this.CurrentOrder == null)
                {
                    throw new Exception("请选择要打印的订单和包号。");
                }
                using (ProxyBE pb = new ProxyBE())
                {
                    SearchResult sr = pb.Client.SearchPackage(CGlobal.SenderUser, args);
                    if (sr.Total == 0)
                    {
                        throw new Exception("没有数据。");
                    }

                    frmReportPrieview p = new frmReportPrieview();
                    p.LogoFile = this.LogoFile;
                    p.reportData = sr.DataSet;
                    p.PreviewReport();
                    p.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBarcodes.SelectedItem == null)
                {
                    throw new Exception("请选择板件。");
                }

                if (listBarcodes.SelectedItems.Count > 0)
                {
                    string text = listBarcodes.SelectedItem.ToString();
                    this.txtBarcode.Text = text.Split(',')[0];
                    ScanBarcode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode tn = tvPackage.SelectedNode;
                if (tn == null)
                {
                    throw new Exception("请选择待移除的板件。");
                }
                if (MessageBox.Show("确定要在此包中移除此工件吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;


                if (tn != null)
                {
                    if (tn.Tag.ToString().Split(',')[0] != "B")
                    {
                        throw new Exception("禁止删除整包数据。");
                    }

                    using (ProxyBE p = new ProxyBE())
                    {
                        CurrentOrder = p.Client.GetOrder(CGlobal.SenderUser, CurrentOrder.OrderID);
                        if (CurrentOrder.Status != "P")
                        {
                            throw new Exception("此订单已经离开产生产(包装)环节，禁止再做此操作。");
                        }

                        Guid itemid = new Guid(tn.Tag.ToString().Split(',')[1]);
                        OrderDetail orderDetail = p.Client.GetOrderDetail(CGlobal.SenderUser, itemid);
                        TreeNode pNode = tn.Parent;
                        p.Client.DeletePackageItem(CGlobal.SenderUser, orderDetail.BarcodeNo, WorkFlowID, pNode.Nodes.Count == 1);

                        pNode.Nodes.Remove(tn);
                        //如果是最后一件，删除包号
                        if (pNode.Nodes.Count == 0)
                        {
                            this.CurrentPackage = null;
                            this.tvPackage.Nodes.Remove(pNode);
                        }
                    }
                    biObjects();
                    this.listDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tvPackage_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode tn = this.tvPackage.SelectedNode;
                if (tn == null) return;

                if (tn.Tag.ToString().Split(',')[0] == "B")
                {
                    return;
                }
                Guid PackageID = new Guid(tn.Tag.ToString().Split(',')[1]);
                using (ProxyBE p = new ProxyBE())
                {
                    this.CurrentPackage = p.Client.GetPackage(CGlobal.SenderUser, PackageID);
                    this.gbPackage.Text = string.Format("当前：第{0}包", this.CurrentPackage.PackageNum);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBoardLabel_Click(object sender, EventArgs e)
        {
            try
            {
                frmBoardLabelPreview frm = new frmBoardLabelPreview();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoor_Click(object sender, EventArgs e)
        {
            try
            {
                #region 
                /*
                if (CurrentOrder == null)
                {
                    throw new Exception("没有包装订单数据");
                }

                if (CurrentPackage == null)
                {
                    throw new Exception("没有包数据");
                }

                //找出所有移门数据：包一包
                using (ProxyBE p = new ProxyBE())
                {
                    Guid CabinetID = CurrentPackage.CabinetID;
                    Guid OrderID = CurrentPackage.OrderID;
                    //刷新当前未分包板件列表
                    SearchPackageDetailArgs args = new SearchPackageDetailArgs();
                    args.OrderBy = "[CabinetID],[PackageNum],[BarcodeNo] ASC";
                    args.OrderID = OrderID;
                    args.CabinetID = CabinetID;
                    args.IsDisabled = false;
                    args.IsPakaged = false;
                    args.ItemName = "移门";
                    SearchResult srUnPack = p.Client.SearchPackageDetail(CGlobal.SenderUser, args);
                    if (srUnPack.Total == 0) return;

                    Package pack = new Package();
                    pack.OrderID = OrderID;
                    int pageNum = 0;
                    pageNum = p.Client.GetMaxPackageNum(CGlobal.SenderUser, OrderID, CabinetID);
                    pack.CabinetID = CabinetID;
                    pack.PackageNum = pageNum;
                    pack.PackageID = Guid.NewGuid();
                    pack.PackageBarcode = string.Format("0{0}{1}", CurrentOrder.Created.ToString("yyMMddHHmmss"), pageNum.ToString("00"));
                    pack.PackageLength = 0;
                    pack.PackageHeight = 0;
                    pack.PackageWidth = 0;
                    pack.ItemsQty = 0;
                    pack.Created = DateTime.Now;
                    pack.CreatedBy = CGlobal.CurrentUser.UserCode + "." + CGlobal.CurrentUser.UserName;
                    this.CurrentPackage = pack;

                    foreach (DataRow row in srUnPack.DataSet.Tables[0].Rows)
                    {
                        PackageDetail packageDetail = p.Client.GetPackageDetail(CGlobal.SenderUser, new Guid(row["DetailID"].ToString()));
                        OrderDetail subOrder = p.Client.GetOrderDetail(CGlobal.SenderUser, packageDetail.ItemID);
                        p.Client.ScanBarcode(CGlobal.SenderUser, subOrder.BarcodeNo, WorkShiftID, WorkFlowID);
                        decimal weight = subOrder.MadeHeight * subOrder.MadeLength * subOrder.MadeWidth * 0.000001M * Density;
                        this.CurrentPackage.Weight += weight;
                        this.CurrentPackage.ItemsQty += 1;

                        SavePackageArgs saveArgs = new SavePackageArgs();
                        saveArgs.Package = this.CurrentPackage;
                        packageDetail.IsPakaged = true;
                        packageDetail.PakageID = this.CurrentPackage.PackageID;
                        saveArgs.PackageDetail = packageDetail;
                        p.Client.SavePackage(CGlobal.SenderUser, saveArgs);
                    }

                    SearchPackageDetailArgs p_args = new SearchPackageDetailArgs();
                    p_args.IsDisabled = false;
                    p_args.OrderID = CurrentOrder.OrderID;
                    p_args.IsPakaged = false;

                    SearchResult p_sr = p.Client.SearchPackageDetail(CGlobal.SenderUser, p_args);
                    if (p_sr.Total == 0)
                    {
                        Order order = p.Client.GetOrder(CGlobal.SenderUser, CurrentOrder.OrderID);
                        order.Status = "I"; //全部打包完成后，订单状态变成待入库
                        SaveOrderArgs saveOrderArgs = new SaveOrderArgs();
                        saveOrderArgs.Order = order;
                        p.Client.SaveOrder(CGlobal.SenderUser, saveOrderArgs);
                    }
                }

                //刷新列表
                biForm();
                //加载树
                initTree();
                */
                #endregion
                if (this.CurrentOrder == null)
                {
                    throw new Exception("请选择一个已经完成打包的订单。");
                }
                if (this.CurrentPackage == null)
                {
                    throw new Exception("请选择一个已经完成打包的柜体。");
                }
                frmDoors frm = new frmDoors();
                frm.OrderID = CurrentPackage.OrderID;
                frm.CabinetID = CurrentPackage.CabinetID;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.initTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnHardware_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoorLabel_Click(object sender, EventArgs e)
        {
            try
            {
                //直接打印
                /*
                ReportPrint rpt = new ReportPrint();
                rpt.CopyQty = (short)this.PrintQty;
                rpt.LogoFile = this.LogoFile;
                rpt.PrintCommonLabel(CurrentPackage.CabinetID, "移门");
                */
                //预览
                frmReportPrieview p = new frmReportPrieview();
                p.LogoFile = this.LogoFile;
                p.PreviewCommonReport(CurrentPackage.CabinetID, "移门,导轨,五金");
                p.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCabinetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if(CurrentOrder==null)
                    throw new Exception("没有订单数据");

                frmCabinetStatus frm = new frmCabinetStatus(CurrentOrder.OrderID);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}