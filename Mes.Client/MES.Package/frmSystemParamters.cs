using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;
using System.IO;
using System.Drawing.Printing;
using SpeechLib;
using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;

namespace Mes.Package
{
    public partial class frmSystemParamters : Form
    {

        #region Public Enumerations

        public enum DataMode { Text, Hex }
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
        #endregion

        public frmSystemParamters()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }

        /// <summary>
        /// 初始化组件的数据，为串口提供相关参数
        /// </summary>
        private void InitializeControlValues()
        {
            cmbParity.Items.Clear();
            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear();
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            cmbPortName.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cmbPortName.Items.Add(s);
            }

            string logoPath = Path.Combine(Application.StartupPath, "logoimgs\\");
            if (!Directory.Exists(logoPath))
            {
                Directory.CreateDirectory(logoPath);
            }
            string[] logoFiles = Directory.GetFiles(logoPath, "*.*", SearchOption.TopDirectoryOnly);
            cbDefaultLogo.Items.Clear();
            cbDefaultLogo.DisplayMember = "Text";
            cbDefaultLogo.ValueMember = "Value";
            foreach (string file in logoFiles)
            {
                cbDefaultLogo.Items.Add(new ListItem(Path.GetFileNameWithoutExtension(file), Path.GetFileName(file)));
            }

            string filename = Path.Combine(Application.StartupPath, "Profile.xml");
            if (!File.Exists(filename)) return;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNode xmlNode = xmlDoc.DocumentElement;
            if (xmlNode != null)
            {
                if (xmlNode["UseCOMPort"] != null)
                    this.chkUseCOMPort.Checked = bool.Parse(xmlNode["UseCOMPort"].InnerText);

                if (xmlNode["PortName"] != null)
                    cmbPortName.Text = xmlNode["PortName"].InnerText;
                if (xmlNode["Parity"] != null)
                    cmbParity.Text = xmlNode["Parity"].InnerText;
                if (xmlNode["StopBits"] != null)
                    cmbStopBits.Text = xmlNode["StopBits"].InnerText;
                if (xmlNode["DataBits"] != null)
                    cmbDataBits.Text = xmlNode["DataBits"].InnerText;
                if (xmlNode["BaudRate"] != null)
                    cmbBaudRate.Text = xmlNode["BaudRate"].InnerText;
                if (xmlNode["Barcode"] != null)
                    this.txtBarcode.Text = xmlNode["Barcode"].InnerText;
                if (xmlNode["PrinterName"] != null)
                    this.cbPrint.SelectedIndex = cbPrint.Items.IndexOf(xmlNode["PrinterName"].InnerText);
                if (xmlNode["VoiceFlag"] != null)
                    this.chkVoiceFlag.Checked = bool.Parse(xmlNode["VoiceFlag"].InnerText);
                if (xmlNode["MaxWeight"] != null)
                    txtMaxWeight.Text = xmlNode["MaxWeight"].InnerText;
                if (xmlNode["Density"] != null)
                    txtDensity.Text = xmlNode["Density"].InnerText;

                if (xmlNode["PrintQty"] != null)
                    txtPrintQty.Text = xmlNode["PrintQty"].InnerText;


                if (xmlNode["WorkFlowID"] != null)
                {                    
                    this.cbWorkFlowID.SelectedValue = new Guid(xmlNode["WorkFlowID"].InnerText);
                }

                if (xmlNode["WorkShiftID"] != null)
                {                   
                    this.cbWorkShiftID.SelectedValue = new Guid(xmlNode["WorkShiftID"].InnerText);
                }
                if (xmlNode["DefaultLogo"] != null)
                {
                    foreach (object item in cbDefaultLogo.Items)
                    {
                        if (((ListItem)item).Value == xmlNode["DefaultLogo"].InnerText)
                        {
                            cbDefaultLogo.SelectedItem = item;
                            break;
                        }
                    }
                    this.picLogo.Load(Path.Combine(Application.StartupPath, "logoimgs\\" + xmlNode["DefaultLogo"].InnerText));
                }
            }
        }

        private void frmSystemParamters_Load(object sender, EventArgs e)
        {
            try
            {
                initPrint();
                InitializeControlValues();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }

        private void initPrint()
        {
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名 
            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                cbPrint.Items.Add(sPrint);
                if (sPrint == sDefault)
                    cbPrint.SelectedIndex = cbPrint.Items.IndexOf(sPrint);
            }

            using (ProxyBE p = new ProxyBE())
            {
                List<WorkShift> lists_ws = p.Client.GetAllWorkShifts(CGlobal.SenderUser);
                this.cbWorkShiftID.DataSource = lists_ws;
                this.cbWorkShiftID.ValueMember = "WorkShiftID";
                this.cbWorkShiftID.DisplayMember = "WorkShiftName";
                this.cbWorkShiftID.Refresh();

                List<WorkFlow> lists_wf = p.Client.GetAllWorkFlows(CGlobal.SenderUser);
                this.cbWorkFlowID.DataSource = lists_wf;
                this.cbWorkFlowID.ValueMember = "WorkFlowID";
                this.cbWorkFlowID.DisplayMember = "WorkFlowName";
                this.cbWorkFlowID.Refresh();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkUseCOMPort.Checked)
                {
                    if (cmbPortName.Text == "")
                    {
                        MessageBox.Show("请选择发送/接收数据的COM口！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbPortName.Focus();
                        return;
                    }

                    if (cmbBaudRate.Text == "")
                    {
                        MessageBox.Show("请选择发送/接收数据的波特率！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbBaudRate.Focus();
                        return;
                    }

                    if (cmbStopBits.Text == "")
                    {
                        MessageBox.Show("请选择停止位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbStopBits.Focus();
                        return;
                    }

                    if (cmbDataBits.Text == "")
                    {
                        MessageBox.Show("请选择数据位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbDataBits.Focus();
                        return;
                    }

                    if (cmbParity.Text == "")
                    {
                        MessageBox.Show("请选择校验位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbParity.Focus();
                        return;
                    }
                }

                string filename = Path.Combine(Application.StartupPath, "Profile.xml");
                XmlDocument xmDoc = new XmlDocument();
                xmDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Items></Items>");
                XmlElement xmItems = xmDoc.DocumentElement;
                XmlElement xmItem = xmDoc.CreateElement("UseCOMPort");
                xmItem.InnerText = this.chkUseCOMPort.Checked.ToString();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("BaudRate");
                xmItem.InnerText = this.cmbBaudRate.Text.Trim();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("PortName");
                xmItem.InnerText = this.cmbPortName.Text.Trim();
                xmItems.AppendChild(xmItem);


                xmItem = xmDoc.CreateElement("StopBits");
                xmItem.InnerText = this.cmbStopBits.Text.Trim();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("DataBits");
                xmItem.InnerText = this.cmbDataBits.Text.Trim();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("Parity");
                xmItem.InnerText = this.cmbParity.Text.Trim();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("Barcode");
                xmItem.InnerText = this.txtBarcode.Text.Trim();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("PrinterName");
                xmItem.InnerText = this.cbPrint.Text.Trim();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("MaxWeight");
                xmItem.InnerText = this.txtMaxWeight.Text.ToString();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("Density");
                xmItem.InnerText = this.txtDensity.Text.ToString();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("DefaultLogo");
                ListItem item = (ListItem)this.cbDefaultLogo.SelectedItem;
                if (item != null)
                {
                    xmItem.InnerText = item.Value.ToString();
                }
                else
                {
                    xmItem.InnerText = "";
                }
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("PrintQty");
                xmItem.InnerText = this.txtPrintQty.Text.ToString();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("VoiceFlag");
                xmItem.InnerText = this.chkVoiceFlag.Checked.ToString();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("WorkShiftID");
                xmItem.InnerText = this.cbWorkShiftID.SelectedValue.ToString();
                xmItems.AppendChild(xmItem);

                xmItem = xmDoc.CreateElement("WorkFlowID");
                xmItem.InnerText = this.cbWorkFlowID.SelectedValue.ToString();
                xmItems.AppendChild(xmItem);

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                xmDoc.Save(filename);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkVoiceFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                SpVoice Voice = new SpVoice();

                string message = "";
                if (this.chkVoiceFlag.Checked)
                {
                    message = "启用声音提示";
                }
                else
                {
                    message = "取消声音提示";
                }
                Voice.Speak(message, SpFlags);
            }
            catch (Exception ex)
            {
                chkVoiceFlag.Checked = false;
                PLogger.LogError(ex);
            }
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPEG文件(*.jpg)|*.jpg|PNG文件(*.png)|*.png|BMP文件(*.bmp)|*.bmp";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string logoFile = dlg.FileName;
                    if (cbDefaultLogo.Items.Contains(new ListItem(Path.GetFileNameWithoutExtension(logoFile), Path.GetFileName(logoFile))))
                    {
                        throw new Exception("Logo文件已存在。");
                    }
                    else
                    {
                        string logoPath = Path.Combine(Application.StartupPath, "logoimgs\\");
                        if (!Directory.Exists(logoPath))
                        {
                            Directory.CreateDirectory(logoPath);
                        }
                        string destFile = Path.Combine(logoPath, Path.GetFileName(logoFile));
                        File.Copy(logoFile, destFile, true);

                        ListItem item = new ListItem(Path.GetFileNameWithoutExtension(logoFile), Path.GetFileName(logoFile));
                        cbDefaultLogo.Items.Add(item);
                        cbDefaultLogo.SelectedItem = item;
                        this.picLogo.Load(destFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbDefaultLogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListItem item = (ListItem)this.cbDefaultLogo.SelectedItem;
                if (item != null)
                {
                    this.picLogo.Load(Path.Combine(Application.StartupPath, "logoimgs\\" + item.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class ListItem
    {
        public ListItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }

}

