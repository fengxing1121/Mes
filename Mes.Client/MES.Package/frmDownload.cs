using MES.Libraries;
using Mes.Package.Common;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mes.Package
{
    public partial class frmDownload : Form
    {
        public frmDownload()
        {
            InitializeComponent();
        }

        private void btnOpendlg_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtSavePath.Text = dlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtBattchNum.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请输入生产批次号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    if (txtSavePath.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请选择加工文件存储位置。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    string SavePath = txtSavePath.Text;
            //    if (chkDefault.Checked)//设置默认存储位置
            //    {
            //        XmlDocument doc = new XmlDocument();
            //        doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><FilePath>" + this.txtSavePath.Text.Trim() + "</FilePath>");
            //        string filename = Path.Combine(Application.StartupPath, "DefaultFolder.xml");
            //        if (File.Exists(filename))
            //        {
            //            File.Delete(filename);
            //        }
            //        doc.Save(filename);
            //    }

            //    if (this.rbCNC.Checked)//下载CNC
            //    {
            //        using (ProxyBE be = new ProxyBE())
            //        {
            //            SearchOrderProcessFileArgs args = new SearchOrderProcessFileArgs();
            //            args.BattchNum = this.txtBattchNum.Text.Trim();
            //            args.FileType = new List<string> { "CNC", "ProcessFile" };
            //            SearchResult sr = be.Client.SearchOrderProcessFile(CGlobal.SenderUser, args);
            //            if (sr.Total == 0)
            //            {
            //                throw new Exception("没有找到该批次号文件。");
            //            }

            //            ThreadPool.QueueUserWorkItem(DownloadFile, sr.DataSet);
            //            LoadForm = new frmWait();
            //            LoadForm.ShowDialog();
            //        }
            //    }
            //    else if (this.rbDXF.Checked)//下载DXF
            //    {
            //        using (ProxyBE be = new ProxyBE())
            //        {
            //            SearchOrderProcessFileArgs args = new SearchOrderProcessFileArgs();
            //            args.BattchNum = this.txtBattchNum.Text.Trim();
            //            args.FileType = new List<string> { "DXF", "ProcessFile" };
            //            SearchResult sr = be.Client.SearchOrderProcessFile(CGlobal.SenderUser, args);
            //            if (sr.Total == 0)
            //            {
            //                throw new Exception("没有找到该批次号文件。");
            //            }
            //            ThreadPool.QueueUserWorkItem(DownloadFile, sr.DataSet);
            //            LoadForm = new frmWait();
            //            LoadForm.ShowDialog();
            //        }
            //    }
            //    else if (this.rbBOM.Checked)//优化料单
            //    {
            //        using (ProxyBE be = new ProxyBE())
            //        {
            //            SearchOrderDetailArgs args = new SearchOrderDetailArgs();
            //            args.OrderBy = "[BarcodeNo]";
            //            args.CompanyID = CGlobal.CurrentUser.CompanyID;
            //            args.BattchNum = txtBattchNum.Text;

            //            SearchResult sr = be.Client.SearchOrderDetail(CGlobal.SenderUser, args);
            //            if (sr.Total == 0)
            //            {
            //                throw new Exception("没有找到该批次号文件。");
            //            }
            //        }
            //        ThreadPool.QueueUserWorkItem(DownloadBOM, null);
            //        LoadForm = new frmWait();
            //        LoadForm.ShowDialog();
            //    }
            //    else if (this.rbManual.Checked)//手工料单
            //    {
            //        using (ProxyBE be = new ProxyBE())
            //        {
            //            SearchOrderDetailArgs args = new SearchOrderDetailArgs();
            //            args.OrderBy = "[BarcodeNo]";
            //            args.CompanyID = CGlobal.CurrentUser.CompanyID;
            //            args.BattchNum = txtBattchNum.Text;

            //            SearchResult sr = be.Client.SearchOrderDetail(CGlobal.SenderUser, args);
            //            if (sr.Total == 0)
            //            {
            //                throw new Exception("没有找到该批次号文件。");
            //            }
            //        }
            //        ThreadPool.QueueUserWorkItem(DownloadManual, null);
            //        LoadForm = new frmWait();
            //        LoadForm.ShowDialog();
            //    }
            //    else if (this.rbCUT.Checked)//下载CUT
            //    {
            //        using (ProxyBE be = new ProxyBE())
            //        {
            //            SearchBattchFileArgs args = new SearchBattchFileArgs();
            //            args.BattchNum = this.txtBattchNum.Text.Trim();

            //            SearchResult sr = be.Client.SearchBattchFile(CGlobal.SenderUser, args);
            //            if (sr.Total == 0)
            //            {
            //                throw new Exception("没有找到该批次号文件。");
            //            }

            //            ThreadPool.QueueUserWorkItem(DownloadCUT, sr.DataSet);
            //            LoadForm = new frmWait();
            //            LoadForm.ShowDialog();
            //        }
            //    }
            //    else
            //    {
            //        throw new Exception("请选择需要导出的文件类型。");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    PLogger.LogError(ex);
            //    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        private void DownloadManual(object state)
        {
            //try
            //{
            //    LoadForm.Notify("正在导出手工料单文件，请稍候...");

            //    string sourceFileName = Path.Combine(Application.StartupPath, "template\\mes_manual.xls");

            //    if (!File.Exists(sourceFileName))
            //    {
            //        throw new Exception("手工料单模板文件不存在，请将模板文件恢复后再试.");
            //    }
            //    string targetFileName = "";
            //    using (ProxyBE p = new ProxyBE())
            //    {
            //        SearchOrderDetailArgs args = new SearchOrderDetailArgs();
            //        args.OrderBy = "[BarcodeNo]";
            //        args.CompanyID = CGlobal.CurrentUser.CompanyID;
            //        //按批次导出
            //        string BattchNo = txtBattchNum.Text;
            //        args.BattchNum = BattchNo;

            //        SearchResult sr = p.Client.SearchOrderDetail(CGlobal.SenderUser, args);

            //        #region 排除库存件及外购件
            //        List<Category> lists = new List<Category>();
            //        List<Category> lists_O = new List<Category>();
            //        Category cate_S = p.Client.GetCategoryByParentID_CategoryCode(CGlobal.SenderUser, Guid.Empty, "StorageMaterials");
            //        Category cate_O = p.Client.GetCategoryByParentID_CategoryCode(CGlobal.SenderUser, Guid.Empty, "OutSourcingMaterials");
            //        if (cate_S != null)
            //        {
            //            lists = p.Client.GetCategoriesByParentID(CGlobal.SenderUser, cate_S.CategoryID);
            //        }
            //        if (cate_O != null)
            //        {
            //            lists_O = p.Client.GetCategoriesByParentID(CGlobal.SenderUser, cate_O.CategoryID);
            //        }
            //        lists.AddRange(lists_O);//两个集合合并
            //        var whereItems = new Dictionary<string, string>();

            //        foreach (Category c in lists)
            //        {
            //            if (c.IsDisabled) continue;
            //            string[] CategoryNames = c.CategoryName.Split(',');
            //            string where = "";
            //            foreach (string s in CategoryNames)
            //            {
            //                if (s.Trim() != "")
            //                {
            //                    where += string.Format(" ItemName not like '%{0}%' ", s);
            //                }
            //            }
            //            whereItems.Add(c.CategoryName, where);
            //        }
            //        var condition = string.Empty;
            //        foreach (var item in whereItems)
            //        {
            //            condition += item.Value + "And";
            //        }
            //        condition = condition.TrimEnd('A', 'n', 'd');
            //        var srows = sr.DataSet.Tables[0].Select(condition);

            //        var tmpDs = new DataSet();
            //        DataTable dt = sr.DataSet.Tables[0].Clone(); //复制表结构
            //        if (srows.Length > 0)
            //        {
            //            foreach (var row in srows)
            //                dt.ImportRow(row);
            //        }
            //        tmpDs.Tables.Add(dt);

            //        #endregion
            //        //批次总柜数
            //        int TotalBattchQty = p.Client.GetTotalOrderBattchQty(CGlobal.SenderUser, BattchNo);

            //        targetFileName = txtSavePath.Text;
            //        if (!Directory.Exists(targetFileName))
            //        {
            //            Directory.CreateDirectory(targetFileName);
            //        }
            //        targetFileName = Path.Combine(targetFileName, "手工料单_" + sr.DataSet.Tables[0].Rows[0]["BattchNum"].ToString() + "_排产优化.xls");

            //        if (File.Exists(targetFileName))
            //        {
            //            File.Delete(targetFileName);
            //        }
            //        File.Copy(sourceFileName, targetFileName, true);

            //        //订单列表
            //        List<Guid> list_OrderIDs = new List<Guid>();
            //        List<Category> category_lists = new List<Category>();
            //        Category category = p.Client.GetCategoryByParentID_CategoryCode(CGlobal.SenderUser, Guid.Empty, "OptimizeType");
            //        if (category != null)
            //        {
            //            category_lists = p.Client.GetCategoriesByParentID(CGlobal.SenderUser, category.CategoryID);
            //        }
            //        Dictionary<string, string> conditions = new Dictionary<string, string>();

            //        if (category_lists.Count == 0)
            //        {
            //            conditions.Add("开料", "IsSpecialShap=0");
            //        }
            //        else
            //        {
            //            conditions.Add("异形板", "IsSpecialShap=1"); //先抽异型
            //            var list = category_lists.OrderByDescending(o => o.Sequence); //排序：再挑Y的数据
            //            foreach (Category c in list)
            //            {
            //                if (c.IsDisabled) continue;
            //                string[] CategoryNames = c.CategoryName.Split(',');
            //                string where = " 1=1 and (1>2 ";
            //                if (CategoryNames.Contains("Y"))
            //                {
            //                    where += string.Format(" or ItemName like '{0}%')", c.CategoryName);
            //                }
            //                else if (CategoryNames.Length == 1)
            //                {
            //                    where += string.Format(" or ItemName like '%{0}%') and MadeWidth>=78 and MadeLength>=78", c.CategoryName);
            //                }
            //                else
            //                {
            //                    foreach (string s in CategoryNames)
            //                    {
            //                        if (s.Trim() != "")
            //                        {
            //                            where += string.Format(" or ItemName like '%{0}%'", s);
            //                        }
            //                    }
            //                    where += ") and MadeWidth>=78 and MadeLength>=78";
            //                }
            //                conditions.Add(c.CategoryName, where);
            //            }
            //        }

            //        conditions.Add("小板", "IsSpecialShap=0 and (MadeWidth<78 or MadeLength<78)");
            //        //异形
            //        //conditions.Add("异形板", "IsSpecialShap=1");
            //        conditions.Add("其它", "1=1");

            //        using (FileStream fs = new FileStream(targetFileName, FileMode.Open, FileAccess.Read))
            //        {
            //            #region 导出数据
            //            IWorkbook workbook = new HSSFWorkbook(fs);
            //            ISheet worksheet = workbook.GetSheetAt(0);
            //            int sheet_index = 0;
            //            foreach (string key in conditions.Keys)
            //            {
            //                //DataRow[] rows = sr.DataSet.Tables[0].Select(conditions[key]);
            //                DataRow[] rows = tmpDs.Tables[0].Select(conditions[key]);
            //                if (rows.Length == 0) continue;

            //                #region 填充数据
            //                if (sheet_index >= 1)
            //                {
            //                    worksheet.CopySheet(key + "_优化数据表", true);
            //                }
            //                else
            //                {
            //                    workbook.SetSheetName(sheet_index, key + "_优化数据表");
            //                }

            //                worksheet = workbook.GetSheetAt(sheet_index);
            //                sheet_index++;
            //                #region 清空sheet页数据
            //                int TotalRows = worksheet.LastRowNum;
            //                for (int rownum = 1; rownum <= TotalRows; rownum++)
            //                {
            //                    IRow datarow = worksheet.GetRow(rownum);
            //                    worksheet.RemoveRow(datarow);
            //                }
            //                #endregion

            //                int rows_index = 1;//从第2行开始导入
            //                foreach (DataRow row in rows)
            //                {
            //                    Guid OrderID = new Guid(row["OrderID"].ToString());
            //                    if (!list_OrderIDs.Contains(OrderID))
            //                    {
            //                        list_OrderIDs.Add(OrderID);
            //                    }

            //                    IRow _row = worksheet.CreateRow(rows_index);                        //表示每循环一次，在Excel中创建一行，并给这一行
            //                    _row.Height = 25 * 20;
            //                    _row.CreateCell(0).SetCellValue(rows_index);                        //序号
            //                    _row.CreateCell(1).SetCellValue(row["ItemName"].ToString());        //板件名称
            //                    _row.CreateCell(2).SetCellValue(row["MaterialType"].ToString());    //材质颜色
            //                    _row.CreateCell(3).SetCellValue(decimal.Parse(row["MadeLength"].ToString()).ToString("#"));      //开料长度
            //                    _row.CreateCell(4).SetCellValue(decimal.Parse(row["MadeWidth"].ToString()).ToString("#"));       //开料宽度
            //                    _row.CreateCell(5).SetCellValue(decimal.Parse(row["MadeHeight"].ToString()).ToString("#"));      //厚度                                
            //                    _row.CreateCell(6).SetCellValue(decimal.Parse(row["Qty"].ToString()).ToString("#"));               //数量
            //                    _row.CreateCell(7).SetCellValue(row["BarcodeNo"].ToString());       //条形码1 
            //                    _row.CreateCell(8).SetCellValue(row["OrderNo"].ToString());      //订单号      
            //                    _row.CreateCell(9).SetCellValue(row["BattchNum"].ToString());      //批次号                           				
            //                    rows_index++;
            //                }

            //                foreach (DataRow r in rows)
            //                {
            //                    //sr.DataSet.Tables[0].Rows.Remove(r);
            //                    tmpDs.Tables[0].Rows.Remove(r);
            //                }
            //                #endregion
            //            }

            //            using (MemoryStream ms = new MemoryStream())
            //            {
            //                workbook.Write(ms);
            //                FileStream file = new FileStream(targetFileName, FileMode.Create);
            //                workbook.Write(file);
            //                file.Close();
            //                workbook = null;
            //                ms.Close();
            //                ms.Dispose();
            //            }
            //            #endregion
            //        }
            //    }
            //    LoadForm.Notify("料单导出完成。");
            //    Thread.Sleep(2000);
            //}
            //catch (Exception ex)
            //{
            //    LoadForm.Notify(ex.Message);
            //    Thread.Sleep(2000);
            //}
            //finally
            //{
            //    CloseLoading();
            //}
        }


        frmWait LoadForm = null;
        /// <summary>
        /// CNC及DXF
        /// </summary>
        /// <param name="obj"></param>
        private void DownloadFile(object obj)
        {
            //try
            //{
            //    DataSet ds = (DataSet)obj;
            //    int index = 1;

            //    using (ProxySE se = new ProxySE())
            //    {
            //        bool prefix = cbCNCN5.Checked;

            //        string SavePath = this.txtSavePath.Text;
            //        if (!Directory.Exists(SavePath))
            //        {
            //            Directory.CreateDirectory(SavePath);
            //        }
            //        foreach (DataRow row in ds.Tables[0].Rows)
            //        {
            //            LoadForm.Notify(string.Format("正在导出数据，请稍候...\r\n\t当前处理：{0}/{1}条", index, ds.Tables[0].Rows.Count));
            //            index++;
            //            string FilePath = row["FilePath"].ToString();

            //            string filename = row["FileName"].ToString();
            //            if (prefix)
            //            {
            //                if (filename.Substring(0, 2) == "N5")
            //                {
            //                    filename = filename.Substring(2);
            //                }
            //            }
            //            string SaveFile = Path.Combine(SavePath, filename);
            //            if (File.Exists(SaveFile))
            //            {
            //                File.Delete(SaveFile);
            //            }
            //            byte[] buffer = se.Client.GetDocumentFile(CGlobal.SenderUser, FilePath);
            //            if (buffer != null)
            //            {
            //                using (FileStream outputStream = new FileStream(SaveFile, FileMode.Create))
            //                {
            //                    outputStream.Write(buffer, 0, buffer.Length);
            //                }
            //            }
            //        }
            //        LoadForm.Notify("文件下载完成。");
            //        Thread.Sleep(2000);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    LoadForm.Notify(ex.Message);
            //    Thread.Sleep(2000);
            //}
            //finally
            //{
            //    CloseLoading();
            //}
        }
        private void DownloadBOM(object obj)
        {
            //try
            //{
            //    LoadForm.Notify("正在导出BOM文件，请稍候...");

            //    string sourceFileName = Path.Combine(Application.StartupPath, "template\\mes_out.xls");
            //    string targetFileName = "";
            //    using (ProxyBE p = new ProxyBE())
            //    {
            //        SearchOrderDetailArgs args = new SearchOrderDetailArgs();
            //        args.OrderBy = "[BarcodeNo]";
            //        args.CompanyID = CGlobal.CurrentUser.CompanyID;
            //        //按批次导出
            //        string BattchNo = txtBattchNum.Text;
            //        args.BattchNum = BattchNo;

            //        SearchResult sr = p.Client.SearchOrderDetail(CGlobal.SenderUser, args);

            //        #region 排除库存件及外购件
            //        List<Category> lists = new List<Category>();
            //        List<Category> lists_O = new List<Category>();
            //        Category cate_S = p.Client.GetCategoryByParentID_CategoryCode(CGlobal.SenderUser, Guid.Empty, "StorageMaterials");
            //        Category cate_O = p.Client.GetCategoryByParentID_CategoryCode(CGlobal.SenderUser, Guid.Empty, "OutSourcingMaterials");
            //        if (cate_S != null)
            //        {
            //            lists = p.Client.GetCategoriesByParentID(CGlobal.SenderUser, cate_S.CategoryID);
            //        }
            //        if (cate_O != null)
            //        {
            //            lists_O = p.Client.GetCategoriesByParentID(CGlobal.SenderUser, cate_O.CategoryID);
            //        }
            //        lists.AddRange(lists_O);//两个集合合并
            //        var whereItems = new Dictionary<string, string>();

            //        foreach (Category c in lists)
            //        {
            //            if (c.IsDisabled) continue;
            //            string[] CategoryNames = c.CategoryName.Split(',');
            //            string where = "";
            //            foreach (string s in CategoryNames)
            //            { 
            //                if (s.Trim() != "")
            //                {
            //                    //MaterialType 是排除橱柜的外购件
            //                    where += string.Format(" (ItemName not like '%{0}%' and  MaterialType not like '%{1}%') ", s, s);                                     
            //                }
            //            }
            //            whereItems.Add(c.CategoryName, where);
            //        }
            //        var condition = string.Empty;
            //        foreach (var item in whereItems)
            //        {
            //            condition += item.Value + "And";
            //        }
            //        condition = condition.TrimEnd('A', 'n', 'd');
            //        var srows = sr.DataSet.Tables[0].Select(condition);

            //        var tmpDs = new DataSet();
            //        DataTable dt = sr.DataSet.Tables[0].Clone(); //复制表结构
            //        if (srows.Length > 0)
            //        {
            //            foreach (var row in srows)
            //                dt.ImportRow(row);
            //        }
            //        tmpDs.Tables.Add(dt);
            //        #endregion

            //        //批次总柜数
            //        int TotalBattchQty = p.Client.GetTotalOrderBattchQty(CGlobal.SenderUser, BattchNo);

            //        targetFileName = txtSavePath.Text;
            //        if (!Directory.Exists(targetFileName))
            //        {
            //            Directory.CreateDirectory(targetFileName);
            //        }
            //        targetFileName = Path.Combine(targetFileName, sr.DataSet.Tables[0].Rows[0]["BattchNum"].ToString() + "_排产优化.xls");

            //        if (File.Exists(targetFileName))
            //        {
            //            File.Delete(targetFileName);
            //        }
            //        File.Copy(sourceFileName, targetFileName, true);

            //        //加工文件
            //        SearchOrderProcessFileArgs pfArgs = new SearchOrderProcessFileArgs();
            //        pfArgs.BattchNum = BattchNo;
            //        pfArgs.FileType = new List<string>() { "DXF", "CNC", "ProcessFile" };
            //        SearchResult pfResult = p.Client.SearchOrderProcessFile(CGlobal.SenderUser, pfArgs);

            //        //订单列表
            //        List<Guid> list_OrderIDs = new List<Guid>();
            //        List<Category> category_lists = new List<Category>();
            //        Category category = p.Client.GetCategoryByParentID_CategoryCode(CGlobal.SenderUser, Guid.Empty, "OptimizeType");
            //        if (category != null)
            //        {
            //            category_lists = p.Client.GetCategoriesByParentID(CGlobal.SenderUser, category.CategoryID);
            //        }
            //        Dictionary<string, string> conditions = new Dictionary<string, string>();

            //        if (category_lists.Count == 0)
            //        {
            //            conditions.Add("开料", "IsSpecialShap=0");
            //        }
            //        else
            //        {
            //            conditions.Add("异形板", "IsSpecialShap=1");
            //            var list = category_lists.OrderByDescending(o => o.Sequence); //排序：先挑Y的数据
            //            foreach (Category c in list)
            //            {
            //                if (c.IsDisabled) continue;
            //                string[] CategoryNames = c.CategoryName.Split(',');
            //                string where = " 1=1 and (1>2 ";
            //                if (CategoryNames.Contains("Y"))
            //                {
            //                    where += string.Format(" or ItemName like '{0}%')", c.CategoryName);
            //                }
            //                else if (CategoryNames.Length == 1)
            //                {
            //                    where += string.Format(" or ItemName like '%{0}%') and MadeWidth>=78 and MadeLength>=78", c.CategoryName);
            //                }
            //                else
            //                {
            //                    foreach (string s in CategoryNames)
            //                    {
            //                        if (s.Trim() != "")
            //                        {
            //                            where += string.Format(" or ItemName like '%{0}%'", s);
            //                        }
            //                    }
            //                    where += ") and MadeWidth>=78 and MadeLength>=78";
            //                }
            //                conditions.Add(c.CategoryName, where);
            //            }
            //        }

            //        conditions.Add("小板", "IsSpecialShap=0 and (MadeWidth<78 or MadeLength<78)");
            //        //异形
                   
            //        conditions.Add("其它", "1=1");

            //        using (FileStream fs = new FileStream(targetFileName, FileMode.Open, FileAccess.Read))
            //        {
            //            #region 导出数据
            //            IWorkbook workbook = new HSSFWorkbook(fs);
            //            ISheet worksheet = workbook.GetSheetAt(0);
            //            int sheet_index = 0;
            //            foreach (string key in conditions.Keys)
            //            {
            //                //DataRow[] rows = sr.DataSet.Tables[0].Select(conditions[key]);
            //                DataRow[] rows = tmpDs.Tables[0].Select(conditions[key]);
            //                if (rows.Length == 0) continue;

            //                #region 填充数据
            //                if (sheet_index >= 1)
            //                {
            //                    worksheet.CopySheet(key + "_优化数据表", true);
            //                }
            //                else
            //                {
            //                    workbook.SetSheetName(sheet_index, key + "_优化数据表");
            //                }

            //                worksheet = workbook.GetSheetAt(sheet_index);
            //                sheet_index++;
            //                #region 清空sheet页数据
            //                int TotalRows = worksheet.LastRowNum;
            //                for (int rownum = 1; rownum <= TotalRows; rownum++)
            //                {
            //                    IRow datarow = worksheet.GetRow(rownum);
            //                    worksheet.RemoveRow(datarow);
            //                }
            //                #endregion

            //                int rows_index = 1;//从第2行开始导入
            //                foreach (DataRow row in rows)
            //                {
            //                    Guid OrderID = new Guid(row["OrderID"].ToString());
            //                    if (!list_OrderIDs.Contains(OrderID))
            //                    {
            //                        list_OrderIDs.Add(OrderID);
            //                    }

            //                    //加工文件
            //                    string dxfFile = "";
            //                    DataRow[] pfrow = pfResult.DataSet.Tables[0].Select(string.Format("FileName like '%{0}%' and OrderID='{1}'", row["BarcodeNo"].ToString(), OrderID));
            //                    if (pfrow.Length > 0)
            //                    {
            //                        dxfFile = pfrow[0]["FilePath"].ToString();
            //                    }

            //                    IRow _row = worksheet.CreateRow(rows_index);                        //表示每循环一次，在Excel中创建一行，并给这一行
            //                    _row.Height = 25 * 20;
            //                    _row.CreateCell(0).SetCellValue(rows_index);                        //序号
            //                    _row.CreateCell(1).SetCellValue(row["ItemName"].ToString());        //板件名称
            //                    _row.CreateCell(2).SetCellValue(row["MaterialType"].ToString());    //材质颜色

            //                    decimal MadeLength = decimal.Parse(row["MadeLength"].ToString());
            //                    decimal MadeWidth = decimal.Parse(row["MadeWidth"].ToString());
            //                    double Area = Convert.ToDouble((MadeLength * MadeWidth) * 0.000001M);

            //                    _row.CreateCell(3).SetCellValue(MadeLength.ToString("#"));      //开料长度
            //                    _row.CreateCell(4).SetCellValue(MadeWidth.ToString("#"));       //开料宽度
            //                    _row.CreateCell(5).SetCellValue(Math.Round(Area, 4));       //开料面积

            //                    _row.CreateCell(6).SetCellValue(decimal.Parse(row["MadeHeight"].ToString()).ToString("#"));      //厚度
            //                    _row.CreateCell(7).SetCellValue(decimal.Parse(row["EndLength"].ToString()).ToString("#"));       //成品长度                                    
            //                    _row.CreateCell(8).SetCellValue(decimal.Parse(row["EndWidth"].ToString()).ToString("#"));        //成品宽度
            //                    _row.CreateCell(9).SetCellValue(row["IsSpecialShap"].ToString().ToLower() == "true" ? "是" : "否");//是否异形
            //                    _row.CreateCell(10).SetCellValue(decimal.Parse(row["Qty"].ToString()).ToString("#"));               //数量
            //                    _row.CreateCell(11).SetCellValue(row["TextureDirection"].ToString()); //修改纹理
            //                    _row.CreateCell(12).SetCellValue(row["EdgeDesc"].ToString());        //封边描述
            //                    _row.CreateCell(13).SetCellValue(row["BarcodeNo"].ToString());       //条形码1
            //                    _row.CreateCell(14).SetCellValue(row["FrontLabel"].ToString());      //条形码2
            //                    _row.CreateCell(15).SetCellValue(row["BackLabel"].ToString());      //条形码3
            //                    _row.CreateCell(16).SetCellValue(row["Remarks"].ToString());        //工艺备注
            //                    _row.CreateCell(17).SetCellValue(dxfFile);                          //保存路径
            //                    _row.CreateCell(18).SetCellValue(row["OrderNo"].ToString());        //订单号
            //                    _row.CreateCell(19).SetCellValue(row["CustomerName"].ToString());   //客户名称
            //                    _row.CreateCell(20).SetCellValue(row["Address"].ToString());        //客户地址 
            //                    _row.CreateCell(21).SetCellValue(row["ShipDate"].ToString());       //交货日期
            //                    _row.CreateCell(22).SetCellValue(row["CabinetName"].ToString());    //产品名称
            //                    _row.CreateCell(23).SetCellValue(row["MaterialStyle"].ToString());  //风格                                    
            //                    _row.CreateCell(24).SetCellValue(row["MaterialCategory"].ToString()); //材质
            //                    _row.CreateCell(25).SetCellValue(row["Color"].ToString());      //颜色
            //                    _row.CreateCell(26).SetCellValue(row["BattchNum"].ToString());      //批次号
            //                    _row.CreateCell(27).SetCellValue(TotalBattchQty);      //批次总柜数
            //                    _row.CreateCell(28).SetCellValue(row["BattchIndex"].ToString());      //批次柜号
            //                    int TotalOrderQty = p.Client.GetTotalOrderCabinetQty(CGlobal.SenderUser, new Guid(row["OrderID"].ToString()));
            //                    _row.CreateCell(29).SetCellValue(TotalOrderQty);      //订单总柜数
            //                    _row.CreateCell(30).SetCellValue(row["Sequence"].ToString());      //当前柜号                                    				
            //                    rows_index++;
            //                }

            //                foreach (DataRow r in rows)
            //                {
            //                    //sr.DataSet.Tables[0].Rows.Remove(r);
            //                    tmpDs.Tables[0].Rows.Remove(r);
            //                }
            //                #endregion
            //            }

            //            using (MemoryStream ms = new MemoryStream())
            //            {
            //                workbook.Write(ms);
            //                FileStream file = new FileStream(targetFileName, FileMode.Create);
            //                workbook.Write(file);
            //                file.Close();
            //                workbook = null;
            //                ms.Close();
            //                ms.Dispose();
            //            }
            //            #endregion

            //            #region 优化完成
            //            foreach (Guid orderid in list_OrderIDs)
            //            {
            //                Order order = p.Client.GetOrder(CGlobal.SenderUser, orderid);
            //                if (order != null && order.Status == "M")
            //                {
            //                    order.Status = "P";
            //                    order.StepNo++;

            //                    SaveOrderArgs orderArgs = new SaveOrderArgs();
            //                    orderArgs.Order = order;

            //                    //流程步骤
            //                    OrderTask ot = new OrderTask();
            //                    ot.Action = "订单优化完成，待生产";
            //                    ot.CurrentStep = "订单优化";
            //                    ot.ActionRemarksType = "订单系统操作";
            //                    ot.ActionRemarks = "订单优化完成，待生产";
            //                    ot.Resource = "订单排产组";
            //                    ot.NextResources = "";
            //                    ot.NextStep = "待生产";
            //                    orderArgs.OrderTask = ot;
            //                    p.Client.SaveOrder(CGlobal.SenderUser, orderArgs);
            //                }
            //            }
            //            #endregion
            //        }
            //    }
            //    LoadForm.Notify("料单导出完成。");
            //    Thread.Sleep(2000);
            //}
            //catch (Exception ex)
            //{
            //    LoadForm.Notify(ex.Message);
            //    Thread.Sleep(2000);
            //}
            //finally
            //{
            //    CloseLoading();
            //}
        }
        private void DownloadCUT(object obj)
        {
            //try
            //{
            //    DataSet ds = (DataSet)obj;
            //    int index = 1;

            //    using (ProxySE se = new ProxySE())
            //    {
            //        string SavePath = this.txtSavePath.Text;
            //        if (!Directory.Exists(SavePath))
            //        {
            //            Directory.CreateDirectory(SavePath);
            //        }

            //        foreach (DataRow row in ds.Tables[0].Rows)
            //        {
            //            LoadForm.Notify(string.Format("正在导出CUT文件，请稍候...\r\n\t当前处理：{0}/{1}条", index, ds.Tables[0].Rows.Count));
            //            index++;
            //            string FilePath = row["FilePath"].ToString();
            //            string SaveFile = Path.Combine(SavePath, Path.GetFileName(FilePath));
            //            if (File.Exists(SaveFile))
            //            {
            //                File.Delete(SaveFile);
            //            }
            //            byte[] buffer = se.Client.GetDocumentFile(CGlobal.SenderUser, FilePath);
            //            if (buffer != null)
            //            {
            //                using (FileStream outputStream = new FileStream(SaveFile, FileMode.Create))
            //                {
            //                    outputStream.Write(buffer, 0, buffer.Length);
            //                }
            //            }

            //            //下载完成之后，改变是否已下载状态
            //            using (ProxyBE p = new ProxyBE())
            //            {                            
            //                SaveBattchFileArgs args = new SaveBattchFileArgs();
            //                BattchFile bf = p.Client.GetBattchFile(CGlobal.SenderUser, new Guid(row["FileID"].ToString())); 
            //                args.BattchFile = bf;
            //                bf.IsDownload = true;
            //                bf.ModifiedBy = CGlobal.SenderUser.UserCode + "." + CGlobal.SenderUser.UserName;
            //                p.Client.SaveBattchFile(CGlobal.SenderUser, args);
            //            }                       

            //        }
            //        LoadForm.Notify("文件下载完成。");
            //        Thread.Sleep(2000);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    LoadForm.Notify(ex.Message);
            //    Thread.Sleep(2000);
            //}
            //finally
            //{
            //    CloseLoading();
            //}
        }
        private void CloseLoading()
        {
            if (this.InvokeRequired)
                Invoke(new Action(CloseLoading));
            else
                if (LoadForm != null)
                    LoadForm.Close();
        }
        private void frmDownload_Load(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.Combine(Application.StartupPath, "DefaultFolder.xml");
                if (File.Exists(filename))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filename);
                    XmlNode xmlNode = doc.DocumentElement;
                    if (xmlNode.InnerText != null)
                    {
                        this.txtSavePath.Text = xmlNode.InnerText;
                    }
                }

            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
        }
    }
}
