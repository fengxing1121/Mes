using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// ProductHandler 的摘要说明
    /// </summary>
    public class ProductHandler : BaseHttpHandler
    {
        ProductMainParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                parm = new ProductMainParm(context);
                foreach (MethodInfo mi in this.GetType().GetMethods())
                {
                    if (mi.Name.ToLower() == method.ToLower())
                    {
                        mi.Invoke(this, null);
                        break;
                    }
                }
            }
        }
        public void SearchProducts()
        {
            try
            {
                using (ProxyBE op = new ProxyBE())
                {
                    SearchProductArgs args = new SearchProductArgs();
                    args.OrderBy = "[CategoryID] asc,[ProductCode]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;


                    if (!string.IsNullOrEmpty(Request["CategoryID"]))
                    {
                        args.CategoryID = new Guid(Request["CategoryID"]);
                    }

                    SearchResult sr = op.Client.SearchProduct(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        public void SaveProduct()
        {
            try
            {
                using (ProxyBE op = new ProxyBE())
                {
                    //存储文件路径:根目录/CompanyID/Products/yyyyMM/ProductCode/FileType
                    string RootPath = "";// Config.StorageFolder;                    
                    RootPath = Path.Combine(RootPath, "Products");
                    RootPath = Path.Combine(RootPath, DateTime.Now.ToString("yyyyMM"));
                    RootPath = Path.Combine(RootPath, parm.ProductCode);
                    if (!Directory.Exists(RootPath))
                    {
                        Directory.CreateDirectory(RootPath);
                    }
                    string ServerPath = Server.MapPath("/");

                    SaveProductArgs args = new SaveProductArgs();
                    List<ProductProcessFile> ProcessFiles = new List<ProductProcessFile>();

                    #region 处理主表
                    //主图片数据
                    string HeardImg = (ServerPath + Request["HeadImgUrl"].ToString().Replace("/", "\\")).Replace("\\\\", "\\");
                    if (!File.Exists(HeardImg))
                    {
                        throw new Exception("上传的图片文件损坏，请重新上传。");
                    }
                    //保存图片文件
                    string heardimg_savepath = Path.Combine(RootPath, "HeardImg\\" + parm.ProductCode + Path.GetExtension(HeardImg));
                    //if (!Directory.Exists(Path.GetDirectoryName(heardimg_savepath)))
                    //{
                    //    Directory.CreateDirectory(Path.GetDirectoryName(heardimg_savepath));
                    //}
                    //
                    UploadFile(HeardImg, heardimg_savepath);
                    //File.Copy(HeardImg, heardimg_savepath, true);

                    ProductMain main = op.Client.GetProductMain(SenderUser, parm.ProductID);
                    if (main == null)
                    {
                        main = new ProductMain();
                        main.ProductID = parm.ProductID;
                    }
                    main.ProductCode = parm.ProductCode;
                    main.ProductName = parm.ProductName;
                    main.CategoryID = parm.CategoryID;
                    main.Color = parm.Color;
                    main.Size = parm.Size;
                    main.MaterialStyle = parm.MaterialStyle;
                    main.MaterialCategory = parm.MaterialCategory;
                    main.Price = parm.Price;
                    main.Remark = "";
                    main.ImageUrl = heardimg_savepath;

                    //检查ProductCode 是否已经存在
                    ProductMain temp = op.Client.GetProductMainByProductCode(SenderUser, parm.ProductCode);
                    if (temp != null && temp.ProductID != main.ProductID)
                    {
                        throw new PException("产品编号【{0}】已经存在，请重新编号。", parm.ProductCode);
                    }
                    args.ProductMain = main;
                    #endregion

                    #region 处理BOM表
                    string BOMFilePath = (ServerPath + Request["BOMFileUrl"].ToString().Replace("/", "\\")).Replace("\\\\", "\\");
                    if (!File.Exists(BOMFilePath))
                    {
                        throw new Exception("上传的BOM文件损坏，请重新上传。");
                    }

                    //开始解析BOM表
                    List<ProductDetail> list_ProductDetails = ImportBOM(BOMFilePath, main.ProductID);
                    if (list_ProductDetails.Count == 0)
                    {
                        throw new Exception("上传的BOM文件数据有误，请重新上传。");
                    }
                    args.ProductDetails = list_ProductDetails;
                    //保存BOM表
                    string bom_savepath = Path.Combine(RootPath, "BOM\\" + parm.ProductCode + Path.GetExtension(BOMFilePath));

                    //if (!Directory.Exists(Path.GetDirectoryName(bom_savepath)))
                    //{
                    //    Directory.CreateDirectory(Path.GetDirectoryName(bom_savepath));
                    //}
                    //File.Copy(BOMFilePath, bom_savepath, true);
                    UploadFile(BOMFilePath, bom_savepath);

                    ProductProcessFile pf = new ProductProcessFile();
                    pf.ProductID = parm.ProductID;
                    pf.FileID = Guid.NewGuid();
                    pf.FileName = Path.GetFileName(bom_savepath);
                    pf.FilePath = bom_savepath;
                    pf.FileType = "BOM";
                    ProcessFiles.Add(pf);
                    #endregion

                    #region 处理五金表
                    string HardwareFilePath = (ServerPath + Request["HardwareFileUrl"].ToString().Replace("/", "\\")).Replace("\\\\", "\\"); ;
                    if (!File.Exists(HardwareFilePath))
                    {
                        throw new Exception("上传的五金文件损坏，请重新上传。");
                    }
                    //开始解析五金表
                    List<Product2Hardware> list_HardwareDetails = ImportHardwareExcel(HardwareFilePath, main.ProductID);
                    if (list_ProductDetails.Count == 0)
                    {
                        throw new Exception("上传的五金文件数据有误，请重新上传。");
                    }
                    args.Product2Hardwares = list_HardwareDetails;
                    //保存五金表
                    string hardware_savepath = Path.Combine(RootPath, "HardwareBOM\\" + parm.ProductCode + Path.GetExtension(HardwareFilePath));
                    //if (!Directory.Exists(Path.GetDirectoryName(hardware_savepath)))
                    //{
                    //    Directory.CreateDirectory(Path.GetDirectoryName(hardware_savepath));
                    //}
                    //File.Copy(HardwareFilePath, hardware_savepath, true);
                    UploadFile(HardwareFilePath, hardware_savepath);

                    pf = new ProductProcessFile();
                    pf.ProductID = parm.ProductID;
                    pf.FileID = Guid.NewGuid();
                    pf.FileName = Path.GetFileName(hardware_savepath);
                    pf.FilePath = hardware_savepath;
                    pf.FileType = "Hardware";
                    ProcessFiles.Add(pf);
                    #endregion

                    #region 处理加工文件
                    if (string.IsNullOrEmpty(Request["CNCFileUrl"]))
                    {
                        throw new Exception("上传的CNC文件损坏，请重新上传。");
                    }
                    string[] cnc_files = Request["CNCFileUrl"].ToString().Split(',');

                    foreach (string cnc_File in cnc_files)
                    {
                        string SourceFile = (ServerPath + cnc_File.Replace("/", "\\")).Replace("\\\\", "\\"); ;
                        string savepath = Path.Combine(RootPath, "ProcessFile\\" + Path.GetFileName(cnc_File));
                        //if (!Directory.Exists(Path.GetDirectoryName(savepath)))
                        //{
                        //    Directory.CreateDirectory(Path.GetDirectoryName(savepath));
                        //}
                        //if (File.Exists(savepath))
                        //{
                        //    File.Delete(savepath);
                        //}

                        //File.Copy(SourceFile, savepath, true);
                        UploadFile(SourceFile, savepath);

                        pf = new ProductProcessFile();
                        pf.ProductID = parm.ProductID;
                        pf.FileID = Guid.NewGuid();
                        pf.FileName = Path.GetFileName(savepath);
                        pf.FilePath = savepath;
                        if (Path.GetExtension(savepath).ToLower() == ".dxf")
                        {
                            pf.FileType = "DXF";
                        }
                        else
                        {
                            pf.FileType = "CNC";
                        }
                        ProcessFiles.Add(pf);
                    }
                    #endregion

                    #region 处理图纸文件
                    string[] drawing_files = Request["DrawingFileUrl"].ToString().Split(',');
                    foreach (string drawing_File in drawing_files)
                    {
                        string SourceFile = (ServerPath + drawing_File.Replace("/", "\\")).Replace("\\\\", "\\"); ;
                        string savepath = Path.Combine(RootPath, "DrawingFile\\" + Path.GetFileName(drawing_File));
                        //if (!Directory.Exists(Path.GetDirectoryName(savepath)))
                        //{
                        //    Directory.CreateDirectory(Path.GetDirectoryName(savepath));
                        //}
                        //if (File.Exists(savepath))
                        //{
                        //    File.Delete(savepath);
                        //}
                        //File.Copy(SourceFile, savepath, true);
                        UploadFile(SourceFile, savepath);

                        pf = new ProductProcessFile();
                        pf.ProductID = parm.ProductID;
                        pf.FileID = Guid.NewGuid();
                        pf.FileName = Path.GetFileName(savepath);
                        pf.FilePath = savepath;
                        pf.FileType = "DrawingFile";
                        ProcessFiles.Add(pf);
                    }
                    #endregion

                    #region 处理效果文件
                    string[] rendering_files = Request["DrawingFileUrl"].ToString().Split(',');
                    foreach (string rendering_File in rendering_files)
                    {
                        string SourceFile = (ServerPath + rendering_File.Replace("/", "\\")).Replace("\\\\", "\\"); ;
                        string savepath = Path.Combine(RootPath, "RenderingFile\\" + Path.GetFileName(rendering_File));
                        //if (!Directory.Exists(Path.GetDirectoryName(savepath)))
                        //{
                        //    Directory.CreateDirectory(Path.GetDirectoryName(savepath));
                        //}
                        //if (File.Exists(savepath))
                        //{
                        //    File.Delete(savepath);
                        //}
                        //File.Copy(SourceFile, savepath, true);
                        UploadFile(SourceFile, savepath);
                        pf = new ProductProcessFile();
                        pf.ProductID = parm.ProductID;
                        pf.FileID = Guid.NewGuid();
                        pf.FileName = Path.GetFileName(savepath);
                        pf.FilePath = savepath;
                        pf.FileType = "RenderingFile";
                        ProcessFiles.Add(pf);
                    }
                    #endregion

                    args.ProductProcessFiles = ProcessFiles;
                    op.Client.SaveProduct(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
            finally
            {
                string RootPath = Server.MapPath(@"/temp/");
                RootPath += DateTime.Now.ToString("yyyyMMdd") + "\\";
                string ProductID = Request["ProductID"];
                if (ProductID != null)
                {
                    RootPath += ProductID;
                }
                if (Directory.Exists(RootPath))
                {
                    Directory.Delete(RootPath, true);
                }
            }
        }

        private void UploadFile(string sourcefile, string savepath)
        {
            //通过SE上传文件,暂无SE服务，先注释
            //using (ProxySE ps = new ProxySE())
            //{
            //    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
            //    {
            //        byte[] buffer = new byte[fs.Length];
            //        int scSize = fs.Read(buffer, 0, buffer.Length);
            //        ps.Client.UploadDoumentFile(SenderUser, savepath, buffer);
            //    }
            //}
        }

        /// <summary>       
        /// 导入板件BOM
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        private List<ProductDetail> ImportBOM(string FileName, Guid ProductID)
        {
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileName + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=2'";
            DataSet ImportDataSet = null;

            List<ProductDetail> subOrders = new List<ProductDetail>();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                string tableName = schemaTable.Rows[0][2].ToString().Trim();
                string strExcel = string.Format("select * from [{0}]", tableName);
                OleDbDataAdapter myCommand = null;
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ImportDataSet = new DataSet();
                myCommand.Fill(ImportDataSet, "tb");
            }
            DataRow row = ImportDataSet.Tables[0].Rows[0];
            int index = 1;
            List<Material> materials = new List<Material>();

            using (ProxyBE p = new ProxyBE())
            {
                materials = p.Client.GetAllMaterials(SenderUser);

                #region 表头处理
                ExcelColumName Columns = new ExcelColumName();
                foreach (DataColumn name in ImportDataSet.Tables[0].Columns)
                {
                    //板件编号
                    if ("板件编号,板件ID,条码编号,条码,条形码，条形码1".Contains(name.ColumnName))
                    {
                        Columns.BarcodeNo = name.ColumnName;
                    }
                    //部件名称
                    else if ("部件名称,名称,板件名称".Contains(name.ColumnName))
                    {
                        Columns.ItemName = name.ColumnName;

                    }
                    //部件编号
                    else if ("部件编号,部件编码,板件编码".Contains(name.ColumnName))
                    {
                        Columns.MaterialCode = name.ColumnName;
                    }
                    //材质颜色
                    else if ("材质,材料,材质颜色".Contains(name.ColumnName))
                    {
                        Columns.MaterialName = name.ColumnName;
                    }
                    //颜色
                    else if ("颜色".Contains(name.ColumnName))
                    {
                        Columns.Color = name.ColumnName;
                    }
                    //开料长度
                    else if ("开料长度,长度,开料长".Contains(name.ColumnName))
                    {
                        Columns.MadeLength = name.ColumnName;
                    }
                    //开料宽度
                    else if ("开料宽度,宽度,开料宽".Contains(name.ColumnName))
                    {
                        Columns.MadeWidth = name.ColumnName;
                    }
                    //开料厚度
                    else if ("开料厚度,厚度".Contains(name.ColumnName))
                    {
                        Columns.MadeHeight = name.ColumnName;
                    }
                    //成品长度
                    else if ("成品长度,成型长度,成型长".Contains(name.ColumnName))
                    {
                        Columns.EndLength = name.ColumnName;
                    }
                    //成品宽度
                    else if ("成品宽度,成型宽度,成品宽".Contains(name.ColumnName))
                    {
                        Columns.EndWidth = name.ColumnName;
                    }
                    //纹理方向
                    else if ("纹理方向,纹理,修改纹理".Contains(name.ColumnName))
                    {
                        Columns.TextureDirection = name.ColumnName;
                    }
                    //生产批次
                    else if ("代号,生产批次".Contains(name.ColumnName))
                    {
                        Columns.MadeBattchNum = name.ColumnName;
                    }
                    //产品名称
                    else if ("柜,柜号，产品名称".Contains(name.ColumnName))
                    {
                        Columns.CabinetNum = name.ColumnName;
                    }
                    //排孔
                    else if ("孔,排孔,打孔,排孔信息,打孔信息".Contains(name.ColumnName))
                    {
                        Columns.HoleDesc = name.ColumnName;
                    }
                    //封边
                    else if ("封边,封边信息,封边方式,封边描述".Contains(name.ColumnName))
                    {
                        Columns.EdgeDesc = name.ColumnName;
                    }
                    //正面标签
                    else if ("正面标签,正面条码".Contains(name.ColumnName))
                    {
                        Columns.FrontLabel = name.ColumnName;
                    }
                    //反面标签
                    else if ("反面标签,反面条码".Contains(name.ColumnName))
                    {
                        Columns.BackLabel = name.ColumnName;
                    }
                    //备注
                    else if ("备注".Contains(name.ColumnName))
                    {
                        Columns.Remarks = name.ColumnName;
                    }
                    //数量
                    else if ("数量,配件用量".Contains(name.ColumnName))
                    {
                        Columns.Qty = name.ColumnName;
                    }
                    //是否异形
                    else if ("是否异形".Contains(name.ColumnName))
                    {
                        Columns.IsSpesial = name.ColumnName;
                    }
                }
                #endregion


                foreach (DataRow rw in ImportDataSet.Tables[0].Rows)
                {
                    string qty = GetStringByDataRow(rw, Columns.Qty);
                    if (qty == "")
                        break;

                    ProductDetail subOrder = new ProductDetail();
                    subOrder.ItemID = Guid.NewGuid();
                    subOrder.ProductID = ProductID;

                    string barcode = GetStringByDataRow(rw, Columns.BarcodeNo);
                    if (barcode == "")
                    {
                        throw new PException("BOM表中的第{0}行的板件条码数据无效。", index);
                    }
                    else
                    {
                        ProductDetail detail = p.Client.GetProductDetailByBarcode(SenderUser, barcode);
                    }
                    subOrder.BarcodeNo = barcode; //板件条码
                    subOrder.ItemName = GetStringByDataRow(rw, Columns.ItemName);   //板件名称

                    subOrder.MadeLength = decimal.Parse(GetStringByDataRow(rw, Columns.MadeLength));
                    subOrder.MadeWidth = decimal.Parse(GetStringByDataRow(rw, Columns.MadeWidth));
                    subOrder.EndLength = decimal.Parse(GetStringByDataRow(rw, Columns.EndLength));
                    subOrder.EndWidth = decimal.Parse(GetStringByDataRow(rw, Columns.EndWidth));
                    string sHeight = GetStringByDataRow(rw, Columns.MadeHeight);
                    if (sHeight == "")
                    {
                        sHeight = GetStringByDataRow(rw, Columns.Color).ToString().Split(' ')[2].Trim();
                    }
                    subOrder.MadeHeight = decimal.Parse(sHeight);
                    if (subOrder.MadeLength >= 200 && subOrder.MadeWidth >= 200 && subOrder.MadeHeight > 9)
                    {
                        subOrder.MadeLength += 1;
                        subOrder.MadeWidth += 1;
                    }
                    subOrder.Qty = int.Parse(qty);
                    subOrder.TextureDirection = GetStringByDataRow(rw, Columns.TextureDirection);
                    subOrder.Remarks = GetStringByDataRow(rw, Columns.Remarks);
                    subOrder.EdgeDesc = GetStringByDataRow(rw, Columns.EdgeDesc);
                    if (GetStringByDataRow(rw, "正面操作") == "是")
                    {
                        subOrder.FrontLabel = GetStringByDataRow(rw, Columns.FrontLabel);
                    }
                    if (GetStringByDataRow(rw, "背面操作") == "是")
                    {
                        subOrder.BackLabel = GetStringByDataRow(rw, Columns.BackLabel);
                    }

                    string IsSpecialShap = GetStringByDataRow(rw, Columns.IsSpesial);   //板件名称
                    if (IsSpecialShap == "是" || IsSpecialShap.ToLower() == "true")
                    {
                        subOrder.IsSpecialShap = true;
                    }


                    subOrder.MaterialType = GetStringByDataRow(rw, Columns.MaterialName);
                    subOrder.Created = DateTime.Now;
                    subOrder.ItemType = "B";//默认为板件
                    subOrder.PackageCategory = "";
                    if (subOrder.MadeLength < 500)
                    {
                        subOrder.PackageSizeType = "S";
                    }
                    else if (subOrder.MadeLength < 1500)
                    {
                        subOrder.PackageSizeType = "M";
                    }
                    else
                    {
                        subOrder.PackageSizeType = "L";
                    }
                    subOrders.Add(subOrder);
                    index++;
                }
            }
            return subOrders;
        }
        private List<Product2Hardware> ImportHardwareExcel(string savepath, Guid ProductID)
        {
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + savepath + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=2'";
            DataSet ImportDataSet;

            List<Product2Hardware> subOrders = new List<Product2Hardware>();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                string tableName = schemaTable.Rows[0][2].ToString().Trim();
                string strExcel = string.Format("select * from [{0}]", tableName);
                OleDbDataAdapter myCommand = null;
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ImportDataSet = new DataSet();
                myCommand.Fill(ImportDataSet, "tb");
            }
            DataRow row = ImportDataSet.Tables[0].Rows[0];
            int index = 1;
            List<Material> materials = new List<Material>();
            using (ProxyBE p = new ProxyBE())
            {
                materials = p.Client.GetAllMaterials(SenderUser);
            }

            #region 表头处理
            ExcelColumName Columns = new ExcelColumName();
            foreach (DataColumn name in ImportDataSet.Tables[0].Columns)
            {
                //产品编号
                if ("物料编码,产品编号,产品编码".Contains(name.ColumnName))
                {
                    Columns.MaterialCode = name.ColumnName;
                }
                else if ("物料名称,产品名称".Contains(name.ColumnName))
                {
                    Columns.MaterialName = name.ColumnName;
                }
                else if ("规格,型号,长度".Contains(name.ColumnName))
                {
                    Columns.MaterialType = name.ColumnName;
                }
                else if ("类型".Contains(name.ColumnName))
                {
                    Columns.MaterialCategory = name.ColumnName;
                }
                //备注
                else if ("备注".Contains(name.ColumnName))
                {
                    Columns.Remarks = name.ColumnName;
                }
                //备注
                else if ("单位".Contains(name.ColumnName))
                {
                    Columns.Unit = name.ColumnName;
                }
                //数量
                else if ("数量,配件用量".Contains(name.ColumnName))
                {
                    Columns.Qty = name.ColumnName;
                }
            }
            #endregion
            //产品名称
            string CabinetName = Path.GetFileNameWithoutExtension(savepath).Replace("五金BOM-", "");
            foreach (DataRow rw in ImportDataSet.Tables[0].Rows)
            {
                string qty = GetStringByDataRow(rw, Columns.Qty);
                if (qty == "")
                    break;
                Product2Hardware subOrderHardware = new Product2Hardware();
                subOrderHardware.ItemID = Guid.NewGuid();
                subOrderHardware.ProductID = ProductID;
                subOrderHardware.BarcodeNo = GetStringByDataRow(rw, Columns.BarcodeNo);
                subOrderHardware.HardwareName = GetStringByDataRow(rw, Columns.MaterialName);
                subOrderHardware.HardwareCategory = GetStringByDataRow(rw, Columns.MaterialCategory);
                subOrderHardware.Style = GetStringByDataRow(rw, Columns.MaterialType);
                subOrderHardware.Unit = GetStringByDataRow(rw, Columns.Unit);
                subOrderHardware.Qty = int.Parse(qty);
                subOrderHardware.Remarks = GetStringByDataRow(rw, Columns.Remarks);
                subOrders.Add(subOrderHardware);
                index++;
            }
            return subOrders;
        }
        private string GetStringByDataRow(DataRow rw, string columnname)
        {
            string str = "";
            try
            {
                if (!string.IsNullOrEmpty(columnname))
                    str = rw[columnname].ToString().Trim();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return str;
        }
    }
}