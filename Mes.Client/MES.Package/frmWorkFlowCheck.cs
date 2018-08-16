using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Mes.Client.Service.BE;

namespace Mes.Package
{
    public partial class frmWorkFlowCheck : Form
    {
        SerialPort ComPort = new SerialPort();
        bool VoiceFlag = false;
        string FinishedBarcode = "";
        string LogoFile = "";
        decimal MaxWeight = 0;        
        decimal Density = 0;        
        int PrintQty = 1;
        SpVoice Voice;
        string defaultPrint = "";
        Guid WorkShiftID = Guid.Empty;
        Guid WorkFlowID = Guid.Empty;

        public frmWorkFlowCheck()
        {
            InitializeComponent();
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

                    if (xmlNode["StopBits"] != null && xmlNode["StopBits"].InnerText != "None")
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

            if (useComPort)
            {
                ComPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);                
                ComPort.Open();
            }

            this.tsUser.Text = CGlobal.SenderUser.UserCode + "." + CGlobal.SenderUser.UserName;
            using (ProxyBE p = new ProxyBE())
            {
                if (WorkShiftID != Guid.Empty)
                {
                    WorkShift ws = p.Client.GetWorkShift(CGlobal.SenderUser, WorkShiftID);
                    if (ws != null)
                    {
                        this.tsShiftName.Text = ws.WorkShiftName;
                    }
                }

                if (WorkFlowID != Guid.Empty)
                {
                    WorkFlow wf = p.Client.GetWorkFlow(CGlobal.SenderUser, WorkFlowID);
                    if (wf != null)
                    {
                        this.tsWorkFlowName.Text = wf.WorkFlowName;
                    }
                }
                biForm();
            }
        }

        private void biForm()
        {
            using (ProxyBE p = new ProxyBE())
            { 
                SearchOrderSchedulingArgs args = new SearchOrderSchedulingArgs();
                args.OrderBy = "[BattchNum],[Sequence]";
                if (WorkFlowID != null)
                {
                    args.WorkFlowID = WorkFlowID;
                }
                SearchResult sr = p.Client.SearchOrderScheduling(CGlobal.SenderUser, args);
                this.dgDetail.AutoGenerateColumns = false;
                this.dgDetail.DataSource = sr.DataSet.Tables[0];
                this.dgDetail.Refresh();
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
                    throw new Exception("请在参数设置中设置班次和检查对应的工序名称。");
                }
                if (WorkShiftID == Guid.Empty)
                {
                    throw new Exception("请在参数设置中设置班次和检查对应的工序名称。");
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

                using (ProxyBE p = new ProxyBE())
                {
                    OrderDetail subOrder = p.Client.GetOrderDetailByBarcode(CGlobal.SenderUser, ItemBarcode);
                    if (subOrder == null)
                    {
                        this.txtBarcode.Clear();
                        this.txtBarcode.Focus();
                        lblMsg.Text = "【提示】无效条码:" + ItemBarcode;
                        PlayVoice("无效条码");
                        return;
                    }
                    try
                    {
                        p.Client.ScanBarcode(CGlobal.SenderUser, this.txtBarcode.Text.Trim(), WorkShiftID, WorkFlowID);
                        Order order = p.Client.GetOrder(CGlobal.SenderUser, subOrder.OrderID);                        
                    }
                    catch (Exception ex)
                    {
                        this.txtBarcode.Clear();
                        this.txtBarcode.Focus();
                        lblMsg.Text = ex.Message;
                        PlayVoice(ex.Message);
                        return;
                    }
                    //刷新列表                   
                    this.txtBarcode.Clear();
                    this.txtBarcode.Focus();
                    lblMsg.Text = string.Format("扫描成功。{0}:{1}*{2}*{3}", subOrder.ItemName, subOrder.MadeLength.ToString("#"), subOrder.MadeWidth.ToString("#"),subOrder.MadeHeight.ToString("#"));
                    PlayVoice("OK");
                    biForm();
                }
            }
        }
        private void frmWorkFlowCheck_Load(object sender, EventArgs e)
        {
            try
            {
                InitData();

                
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
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
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                frmDownload frm = new frmDownload();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void frmWorkFlowCheck_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
