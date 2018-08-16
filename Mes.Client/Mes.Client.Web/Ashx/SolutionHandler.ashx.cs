using Eagle.Data;
using ICSharpCode.SharpZipLib.Zip;
using Mes.Client.Model;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// SolutionHandler 的摘要说明
    /// </summary>
    public class SolutionHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        SolutionParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new SolutionParm(context);
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
        #endregion

        public void SearchSolutions()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchSolutionArgs args = new SearchSolutionArgs();
                    args.OrderBy = "Modified Desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["SolutionID"]))
                    {
                        args.SolutionID = Guid.Parse(Request["SolutionID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["SolutionName"]))
                    {
                        args.SolutionName = Request["SolutionName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["SolutionCode"]))
                    {
                        args.SolutionCode = Request["SolutionCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["CustomerID"]))
                    {
                        args.CustomerID = Guid.Parse(Request["CustomerID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
                    {
                        args.CustomerName = Request["CustomerName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = Request["Status"].ToString();
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }
                    //工厂
                    //if (CurrentUser.UserType == (int)EnumType.UserType.U)
                    //{
                    //    string filterList = "fumanduo";
                    //    if (filterList.IndexOf(CurrentUser.UserCode) != -1)
                    //        args.UserCodes = filterList;
                    //}

                    args.CompanyID = CurrentUser.CompanyID;//Liu
                    SearchResult sr = p.Client.SearchSolution(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write(ex.Message);
            }
        }

        public string SolutionFileUrl;

        /// <summary>
        /// 保存方案拆单表yfLiu 20180320
        /// </summary>
        public void SaveSolution()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["TaskID"]))
                    {
                        throw new Exception("参数无效");
                    }

                    #region Order

                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, parm.ReferenceID);
                    if (solution == null)
                    {
                        //Solution solution = new Solution();
                        solution = new Solution();
                        solution.SolutionID = Guid.NewGuid();
                        solution.Version = "";
                        solution.Status = "P";
                    }
                    //经销商ID
                    //solution.PartnerID = CurrentUser.PartnerID;
                    string CustomerID = parm.CustomerID.ToString();
                    Database dbPartner = new Database("BE_Customer_Proc", "GETPARTID", 0, 0, CustomerID, "", "");

                    Guid PartnerID = Guid.Parse(dbPartner.ExecuteScalar().ToString());
                    solution.PartnerID = PartnerID;

                    solution.DesignerID = parm.ReferenceID;
                    solution.CustomerID = parm.CustomerID;
                    solution.SolutionCode = GetNumber("EG"); //获取自动编号
                    solution.SolutionName = "方案设计";
                    solution.Designer = CurrentUser.UserCode;
                    solution.DesignSoft = "";// parm.DesignSoft;                    
                    solution.Remark = "";
                    SaveSolutionArgs args = new SaveSolutionArgs();
                    args.Solution = solution;
                    #endregion

                    if (string.IsNullOrEmpty(SolutionFileUrl))
                    {
                        if (Request["SolutionFileUrl"].ToString() == "")
                        {
                            throw new Exception("请上传方案文件。");
                        }
                        else
                        {
                            SolutionFileUrl = Request["SolutionFileUrl"].ToString();
                        }
                        #region 方案文件
                    }

                    SolutionFile file = p.Client.GetSolutionFileBySourceID(SenderUser, solution.SolutionID);

                    if (file == null)
                    {
                        //Solution solution = new Solution();
                        file = new SolutionFile();
                        file.FileID = Guid.NewGuid();
                    }


                    string ServerPath = Server.MapPath("/");
                    SolutionFileUrl = (ServerPath + SolutionFileUrl.Replace("/", "\\")).Replace("\\\\", "\\");
                    file.SolutionID = solution.SolutionID;
                    file.SourceID = solution.SolutionID;
                    file.SourceType = "S";
                    file.Status = "N";
                    file.FileName = Path.GetFileName(SolutionFileUrl.ToString());

                    //string savepath = DateTime.Now.ToString("yyyyMM");
                    //savepath = Path.Combine(savepath, "SolutionFile");
                    //savepath = Path.Combine(savepath, solution.SolutionID.ToString());
                    //savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));
                    //UploadFile(SolutionFileUrl, savepath);
                    //file.FileUrl = savepath;
                    //
                    file.FileUrl = SolutionFileUrl;

                    //List<string> list1 = UnZipFile(SolutionFileUrl, "", solution);
                    //return;
                    p.Client.SaveSolution(SenderUser, args);

                    SaveSolutionFileArgs fileArgs = new SaveSolutionFileArgs();
                    fileArgs.SolutionFile = file;
                    p.Client.SaveSolutionFile(SenderUser, fileArgs);
                    //[0]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/001G01032-0A.mpr"
                    //[1]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/MES拆单模板(改).xls"
                    //[2]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/No00001.bmp"


                    List<string> list = UnZipFile(SolutionFileUrl, "", solution);
                    if (list.Count <= 0)
                    {
                        WriteError("导入失败，请检查xls数据是否有误！");
                    }


                    #endregion

                    #region 任务流程

                    Database dbCheck = new Database("BE_PartnerTask_Proc", "UPSTEPNO3", 4, 0, parm.ReferenceID.ToString(), "生成报价明细", "P");
                    int rst = dbCheck.ExecuteNoQuery();
                    if (rst == 0)
                    {
                        WriteError("失败！");
                    }


                    //PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"].ToString()));
                    //if (task != null)
                    //{
                    //    SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                    //    taskArgs.PartnerTask = task;
                    //    task.StepName = "生成报价明细";
                    //    taskArgs.NextStep = "生成报价明细";
                    //    taskArgs.Resource = CurrentUser.UserCode;//当前处理组
                    //    taskArgs.NextResource = "CPT";//下一个组
                    //    taskArgs.ActionRemarksType = "";
                    //    taskArgs.ActionRemarks = Request["Remark"].ToString();
                    //    taskArgs.Action = "生成报价明细";

                    //    p.Client.SavePartnerTask(SenderUser, taskArgs);
                    //}
                    #endregion
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 多伦斯上传设计方案
        /// </summary>
        public void SaveSolutionDLS()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    //if (string.IsNullOrEmpty(Request["TaskID"]))
                    //{
                    //    throw new Exception("参数无效");
                    //}

                    #region Order

                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, parm.ReferenceID);
                    if (solution == null)
                    {
                        //Solution solution = new Solution();
                        solution = new Solution();
                        solution.SolutionID = Guid.NewGuid();
                        solution.Version = "";
                        solution.Status = "C"; //已上传设计方案
                    }
                    //经销商ID
                    //solution.PartnerID = CurrentUser.PartnerID;
                    string CustomerID = parm.CustomerID.ToString();
                    Database dbPartner = new Database("BE_Customer_Proc", "GETPARTID", 0, 0, CustomerID, "", "");

                    Guid PartnerID = Guid.Parse(dbPartner.ExecuteScalar().ToString());
                    solution.PartnerID = PartnerID;

                    solution.DesignerID = parm.ReferenceID;
                    solution.CustomerID = parm.CustomerID;
                    solution.SolutionCode = GetNumber("EG"); //获取自动编号
                    solution.SolutionName = "方案设计";
                    solution.Designer = CurrentUser.UserCode;
                    solution.DesignSoft = "";// parm.DesignSoft;                    
                    solution.Remark = "";
                    SaveSolutionArgs args = new SaveSolutionArgs();
                    args.Solution = solution;
                    #endregion

                    #region 方案文件

                    IList<filemodel> ArrayPath = new List<filemodel>();
                    if (!string.IsNullOrEmpty(Request["RoomDesignerFiles"]))
                    {
                        ArrayPath = JSONHelper.JSONToObject<IList<filemodel>>(Request["RoomDesignerFiles"]);
                    }
                    if (ArrayPath.Count == 0)
                    {
                        throw new Exception("请上传设计方案文件。");
                    }
                    string filePath = HttpUtility.UrlDecode(ArrayPath[0].filePath);

                    SolutionFile file = p.Client.GetSolutionFileBySourceID(SenderUser, solution.SolutionID);

                    if (file == null)
                    {
                        //Solution solution = new Solution();
                        file = new SolutionFile();
                        file.FileID = Guid.NewGuid();
                    }


                    string ServerPath = Server.MapPath("/");
                    string SolutionFileUrl = ServerPath + filePath;
                    file.SolutionID = solution.SolutionID;
                    file.SourceID = solution.SolutionID;
                    file.SourceType = "S";
                    file.Status = "N";
                    file.FileName = Path.GetFileName(SolutionFileUrl.ToString());

                    //string savepath = DateTime.Now.ToString("yyyyMM");
                    //savepath = Path.Combine(savepath, "SolutionFile");
                    //savepath = Path.Combine(savepath, solution.SolutionID.ToString());
                    //savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));
                    //UploadFile(SolutionFileUrl, savepath);
                    //file.FileUrl = savepath;
                    //
                    file.FileUrl = SolutionFileUrl;

                    //List<string> list1 = UnZipFile(SolutionFileUrl, "", solution);
                    //return;
                    p.Client.SaveSolution(SenderUser, args);

                    SaveSolutionFileArgs fileArgs = new SaveSolutionFileArgs();
                    fileArgs.SolutionFile = file;
                    p.Client.SaveSolutionFile(SenderUser, fileArgs);
                    //[0]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/001G01032-0A.mpr"
                    //[1]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/MES拆单模板(改).xls"
                    //[2]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/No00001.bmp"


                    //List<string> list = UnZipFile(SolutionFileUrl, "", solution);
                    //if (list.Count <= 0)
                    //{
                    //    WriteError("导入失败，请检查xls数据是否有误！");
                    //}


                    #endregion

                    #region 生成一个方案ID
                    if (string.IsNullOrEmpty(Request["DesignerNo"]))
                    {
                        throw new Exception("DesignerNo参数无效");
                    }
                    SaveRoomDesignerKJLRelationArgs kjlArgs = new SaveRoomDesignerKJLRelationArgs();
                    RoomDesignerKJLRelation model = new RoomDesignerKJLRelation();
                    model.DesignerNo = Convert.ToInt32(Request["DesignerNo"]);
                    model.KJLDesignID = "D" + Request["DesignerNo"].ToString();
                    kjlArgs.RoomDesignerKJLRelation = model;
                    p.Client.SaveRoomDesignerKJLRelation(SenderUser, kjlArgs);
                    #endregion

                    #region 任务流程

                    Database dbCheck = new Database("BE_PartnerTask_Proc", "UPSTEPNO3", 3, 0, parm.ReferenceID.ToString(), "待导入拆单文件", "P");
                    int rst = dbCheck.ExecuteNoQuery();
                    if (rst == 0)
                    {
                        WriteError("失败！");
                    }


                    //PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"].ToString()));
                    //if (task != null)
                    //{
                    //    SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                    //    taskArgs.PartnerTask = task;
                    //    task.StepName = "生成报价明细";
                    //    taskArgs.NextStep = "生成报价明细";
                    //    taskArgs.Resource = CurrentUser.UserCode;//当前处理组
                    //    taskArgs.NextResource = "CPT";//下一个组
                    //    taskArgs.ActionRemarksType = "";
                    //    taskArgs.ActionRemarks = Request["Remark"].ToString();
                    //    taskArgs.Action = "生成报价明细";

                    //    p.Client.SavePartnerTask(SenderUser, taskArgs);
                    //}
                    #endregion
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// yfLiu
        /// </summary>
        /// <param name="zipFilePath"></param>
        /// <param name="unZipDir"></param>
        /// <returns></returns>
        public List<string> UnZipFile(string zipFilePath, string unZipDir, Solution SL)
        {

            List<string> fileUrl = new List<string>();
            try
            {
                if (!File.Exists(zipFilePath))
                {
                    throw new Exception("指定文件不存在.");
                }
                if (unZipDir == string.Empty)
                {
                    unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
                }
                if (!unZipDir.EndsWith("/"))
                {
                    unZipDir += "/";
                }
                if (!Directory.Exists(unZipDir))
                {
                    Directory.CreateDirectory(unZipDir);
                }

                string xlsPath = "";
                DataTable dtDingDan = new DataTable();
                DataTable dtBanJian = new DataTable();
                DataTable dtWuJin = new DataTable();
                bool flag = false;


                Guid CabinetID = new Guid();
                Guid SolutionID = SL.SolutionID;

                string Created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string CreatedBy = "CPT.System";
                string Modified = Created;
                string ModifiedBy = "CPT.System";

                string directoryName = "";
                using (ZipInputStream zipInputStream = new ZipInputStream(File.OpenRead(zipFilePath)))
                {
                    ZipEntry zipEntry = null;
                    while ((zipEntry = zipInputStream.GetNextEntry()) != null)
                    {
                        directoryName = Path.GetDirectoryName(zipEntry.Name);
                        string fileName = Path.GetFileName(zipEntry.Name);
                        if (!string.IsNullOrEmpty(directoryName))
                        {
                            Directory.CreateDirectory(unZipDir + directoryName);
                        }


                        //[0]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/001G01032-0A.mpr"
                        //[1]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/MES拆单模板(改).xls"
                        //[2]: "E:\\work2_ws\\project----\\EGui\\YS_MES.Portal.v1.0\\MES.Portal.v1.0\\temp\\20180320\\SolutionFile\\990000010/990000010\\No0001/No00001.bmp"


                        if (fileName != string.Empty)
                        {
                            fileUrl.Add(unZipDir + directoryName + "/" + fileName);

                            using (FileStream streamWrite = File.Create(unZipDir + zipEntry.Name))
                            {
                                int bufferSize = 2048;
                                byte[] buffer = new byte[bufferSize];
                                while (true)
                                {
                                    int bytesRead = zipInputStream.Read(buffer, 0, buffer.Length);
                                    if (bytesRead > 0)
                                    {
                                        streamWrite.Write(buffer, 0, bytesRead);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }


                        if (fileName.IndexOf(".xlsx1") != -1)
                        {
                            //酷家乐拆单1
                            flag = true;
                            xlsPath = unZipDir + directoryName + "/" + fileName;
                            if (File.Exists(xlsPath))
                            {
                                DataSet ds = ExcelHelper.ReadExcelFiless(xlsPath, fileName);
                                if (fileName.IndexOf("板件清单") != -1)
                                    dtBanJian = ds.Tables[0];
                                else if (fileName.IndexOf("五金清单") != -1)
                                    dtWuJin = ds.Tables[0];
                                else if (fileName.IndexOf("客户信息") != -1)
                                    dtDingDan = ds.Tables[0];

                            }
                        }
                        else if (fileName.IndexOf(".xlsx") != -1)
                        {
                            //酷家乐拆单 now
                            flag = true;
                            xlsPath = unZipDir + directoryName + "/" + fileName;
                            if (File.Exists(xlsPath))
                            {
                                dtDingDan = ExcelHelper.ReadExcelFiless(xlsPath, "客户信息").Tables[0];
                                dtBanJian = ExcelHelper.ReadExcelFiless(xlsPath, "板件清单").Tables[0];
                                dtWuJin = ExcelHelper.ReadExcelFiless(xlsPath, "五金清单").Tables[0];
                            }
                        }
                        else if (fileName.IndexOf(".xls") != -1)
                        {
                            xlsPath = unZipDir + directoryName + "/" + fileName;

                            if (File.Exists(xlsPath))
                            {

                                DataTable dtDD = ExcelHelper.InputFromExcel(xlsPath, "订单");
                                string tmpDD = "";

                                for (int i = 0; i < dtDD.Rows.Count; i++)
                                {
                                    CabinetID = Guid.NewGuid();
                                    string CabinetGroup = dtDD.Rows[i]["产品名称"].ToString();
                                    string CabinetName = dtDD.Rows[i]["产品名称"].ToString();
                                    string Size = dtDD.Rows[i]["柜体尺寸"].ToString();
                                    string MaterialStyle = dtDD.Rows[i]["产品风格"].ToString();
                                    string MaterialCategory = dtDD.Rows[i]["材质类型"].ToString();
                                    string Color = dtDD.Rows[i]["柜体颜色"].ToString();

                                    string Unit = "件";
                                    string Qty = "1";
                                    string FileUploadFlag = "1";
                                    string Sequence = "";//排序
                                    string Remark = "";


                                    tmpDD = CabinetID + "@" + SolutionID + "@" + CabinetGroup + "@" + CabinetName + "@" +
                                        Size + "@" + MaterialStyle + "@" + MaterialCategory + "@" +
                                        Color + "@" + Unit + "@" + Qty + "@" + FileUploadFlag + "@" +
                                        Sequence + "@" + Remark + "@" + Created + "@" + CreatedBy + "@" + Modified + "@" + ModifiedBy;
                                    Database dbDD = new Database("BE_Solution2Cabinet_Proc", "ADD", 0, 0, tmpDD, "", "");
                                    int result = dbDD.ExecuteNoQuery();


                                }

                                DataTable dtBJ = ExcelHelper.InputFromExcel(xlsPath, "板件表");
                                string tmpBJ = "";
                                for (int i = 0; i < dtBJ.Rows.Count; i++)
                                {

                                    Guid ItemID = Guid.NewGuid();
                                    string PartsNo = dtBJ.Rows[i]["物料编码"].ToString();
                                    string ItemName = dtBJ.Rows[i]["板件名称"].ToString();
                                    string ItemType = dtBJ.Rows[i]["颜色"].ToString();//颜色
                                    string MaterialType = dtBJ.Rows[i]["材质"].ToString();
                                    string BarcodeNo = dtBJ.Rows[i]["板件ID"].ToString();
                                    string TextureDirection = "";
                                    string HoleDesc = "";
                                    string MadeWidth = dtBJ.Rows[i]["开料宽"].ToString();
                                    string MadeHeigh = dtBJ.Rows[i]["厚"].ToString();
                                    string MadeLength = dtBJ.Rows[i]["开料长"].ToString();
                                    string EndWidth = dtBJ.Rows[i]["成型宽"].ToString();
                                    string EndLength = dtBJ.Rows[i]["成型长"].ToString();
                                    string Qty = dtBJ.Rows[i]["数量"].ToString();
                                    string Frontlabel = dtBJ.Rows[i]["A面MPR"].ToString();
                                    string BackLabel = dtBJ.Rows[i]["B面MPR"].ToString();
                                    string Remarks = dtBJ.Rows[i]["备注"].ToString();
                                    string Edge1 = "";
                                    string Edge2 = "";
                                    string Edge3 = "";
                                    string Edge4 = "";
                                    string EdgeDesc = dtBJ.Rows[i]["封边"].ToString();
                                    string IsSpecialShap = dtBJ.Rows[i]["是否异型"].ToString() == "是" ? "1" : "0";


                                    string mprA = Frontlabel + ".mpr";
                                    string mprB = BackLabel + ".mpr";
                                    string FilePathUrl = "";
                                    string DirPath = (unZipDir + directoryName).Substring((unZipDir + directoryName).IndexOf("temp")).Replace("\\", "/");
                                    if (Frontlabel != "" && BackLabel != "")
                                        FilePathUrl = DirPath + mprA + "," + DirPath + mprB;
                                    else if (Frontlabel != "")
                                        FilePathUrl = DirPath + "/" + mprA;
                                    else
                                        FilePathUrl = DirPath + "/" + mprB;

                                    tmpBJ = ItemID + "@" + PartsNo + "@" + ItemName + "@" + ItemType + "@" + MaterialType
                                        + "@" + BarcodeNo + "@" + SolutionID + "@" + CabinetID + "@" + TextureDirection
                                        + "@" + HoleDesc + "@" + MadeWidth + "@" + MadeHeigh + "@" + MadeLength
                                    + "@" + EndWidth + "@" + EndLength + "@" + Qty + "@" + Frontlabel + "@" + BackLabel + "@" + Remarks
                                     + "@" + Edge1 + "@" + Edge2 + "@" + Edge3 + "@" + Edge4 + "@" + EdgeDesc + "@" + IsSpecialShap + "@" + FilePathUrl
                                     + "@" + Created + "@" + CreatedBy + "@" + Modified + "@" + ModifiedBy;


                                    Database dbBJ = new Database("BE_SolutionDetail_Proc", "ADD", 0, 0, tmpBJ, "", "");
                                    int result = dbBJ.ExecuteNoQuery();
                                }

                                DataTable dtWJ = ExcelHelper.InputFromExcel(xlsPath, "五金表");
                                string tmpWJ = "";
                                for (int i = 0; i < dtWJ.Rows.Count; i++)
                                {
                                    Guid ItemID = Guid.NewGuid();
                                    string BarcodeNo = dtWJ.Rows[i]["物料编码"].ToString();
                                    string HardwareName = dtWJ.Rows[i]["名称"].ToString();
                                    string HardwareCode = dtWJ.Rows[i]["物料编码"].ToString();
                                    string HardwareCategory = dtWJ.Rows[i]["分类"].ToString();
                                    string Style = dtWJ.Rows[i]["规格/型号"].ToString(); //规格型号
                                    string Qty = dtWJ.Rows[i]["数量"].ToString();
                                    string Unit = dtWJ.Rows[i]["单位"].ToString();
                                    string Remarks = dtWJ.Rows[i]["备注"].ToString();

                                    tmpWJ = ItemID + "@" + BarcodeNo + "@" + SolutionID + "@" + CabinetID + "@" +
                                        HardwareCode + "@" + HardwareName + "@" + HardwareCategory + "@" +
                                        Style + "@" + Qty + "@" + Unit + "@" + Remarks + "@" +
                                        Created + "@" + CreatedBy + "@" + Modified + "@" + ModifiedBy;
                                    Database dbWJ = new Database("BE_Solution2Hardware_Proc", "ADD", 0, 0, tmpWJ, "", "");
                                    int result = dbWJ.ExecuteNoQuery();
                                }

                            }
                        }





                    }
                    //DataTable datNew = dat.DefaultView.ToTable(false, new string[] { "部件号", "部件名称" });

                }

                if (flag)
                {
                    //酷家乐拆单
                    //DataTable dtDingDan;
                    //DataTable dtBanJian;
                    //DataTable dtWuJin;


                    string tmpDD = "";

                    DataTable dtIndexs = new DataTable();
                    dtIndexs.Columns.Add("Index", typeof(string)); //数据类型为 文本
                    dtIndexs.Columns.Add("CabinetID", typeof(string)); //数据类型为 文本

                    for (int i = 0; i < dtDingDan.Rows.Count; i++)
                    {
                        CabinetID = Guid.NewGuid();
                        //string CabinetGroup = dtDingDan.Rows[i][8].ToString();//产品名称"].ToString();
                        //string CabinetName = dtDingDan.Rows[i][8].ToString();//产品名称"].ToString();
                        //string Size = dtDingDan.Rows[i][9].ToString();//柜体尺寸"].ToString();
                        //string MaterialStyle = dtDingDan.Rows[i][11].ToString(); //产品风格"].ToString();
                        //string MaterialCategory = dtDingDan.Rows[i][12].ToString(); //材质类型"].ToString();
                        //string Color = dtDingDan.Rows[i][10].ToString(); //柜体颜色"].ToString();

                        string Index = dtDingDan.Rows[i]["柜号"].ToString();
                        string CabinetGroup = dtDingDan.Rows[i]["产品名称"].ToString() + "-" + Index;
                        string CabinetName = dtDingDan.Rows[i]["产品名称"].ToString() + "-" + Index;
                        string Size = dtDingDan.Rows[i]["柜体尺寸"].ToString();
                        string MaterialStyle = "";
                        string MaterialCategory = dtDingDan.Rows[i]["材质类型"].ToString();
                        string Color = dtDingDan.Rows[i]["柜体颜色"].ToString();

                        string Unit = "件";
                        string Qty = "1";
                        string FileUploadFlag = "1";
                        string Sequence = "";//排序
                        string Remark = "";


                        tmpDD = CabinetID + "@" + SolutionID + "@" + CabinetGroup + "@" + CabinetName + "@" +
                            Size + "@" + MaterialStyle + "@" + MaterialCategory + "@" +
                            Color + "@" + Unit + "@" + Qty + "@" + FileUploadFlag + "@" +
                            Sequence + "@" + Remark + "@" + Created + "@" + CreatedBy + "@" + Modified + "@" + ModifiedBy;
                        Database dbDD = new Database("BE_Solution2Cabinet_Proc", "ADD", 0, 0, tmpDD, Index, "");
                        int result = dbDD.ExecuteNoQuery();
                        if (result > 0)
                        {
                            DataRow dr = dtIndexs.NewRow();
                            dr["Index"] = Index;
                            dr["CabinetID"] = CabinetID;
                            dtIndexs.Rows.Add(dr);
                            //dtIndexs.Rows[i]["Index"] = Index;
                            //dtIndexs.Rows[i]["CabinetID"] = CabinetID;
                        }
                    }

                    string tmpBJ = "";
                    for (int i = 0; i < dtBanJian.Rows.Count; i++)
                    {

                        //Guid ItemID = Guid.NewGuid();
                        //string PartsNo = dtBanJian.Rows[i][15].ToString(); //物料编码"].ToString();
                        //string ItemName = dtBanJian.Rows[i][2].ToString(); //板件名称"].ToString();
                        //string ItemType = dtBanJian.Rows[i][5].ToString(); //颜色"].ToString();//颜色
                        //string MaterialType = dtBanJian.Rows[i][4].ToString(); //材质"].ToString();
                        //string BarcodeNo = dtBanJian.Rows[i][1].ToString(); //板件ID"].ToString();
                        //string TextureDirection = "";
                        //string HoleDesc = "";
                        //string MadeWidth = dtBanJian.Rows[i][6].ToString(); //开料宽"].ToString();
                        //string MadeHeigh = dtBanJian.Rows[i][10].ToString(); //厚"].ToString();
                        //string MadeLength = dtBanJian.Rows[i][7].ToString(); //开料长"].ToString();
                        //string EndWidth = dtBanJian.Rows[i][8].ToString(); //成型宽"].ToString();
                        //string EndLength = dtBanJian.Rows[i][9].ToString(); //成型长"].ToString();
                        //string Qty = dtBanJian.Rows[i][11].ToString(); //数量"].ToString();
                        //string Frontlabel = dtBanJian.Rows[i][13].ToString(); //A面MPR"].ToString();
                        //string BackLabel = dtBanJian.Rows[i][14].ToString(); //B面MPR"].ToString();
                        //string Remarks = dtBanJian.Rows[i][17].ToString(); //备注"].ToString();
                        //string Edge1 = "";
                        //string Edge2 = "";
                        //string Edge3 = "";
                        //string Edge4 = "";
                        //string EdgeDesc = dtBanJian.Rows[i][12].ToString(); //封边"].ToString();
                        //string IsSpecialShap = dtBanJian.Rows[i][16].ToString() == "是" ? "1" : "0";//是否异型"].ToString()


                        //string mprA = Frontlabel;
                        //string mprB = BackLabel;
                        //string FilePathUrl = "";
                        //string DirPath = (unZipDir + directoryName).Substring((unZipDir + directoryName).IndexOf("temp")).Replace("\\", "/");
                        //if (Frontlabel != "" && BackLabel != "")
                        //    FilePathUrl = DirPath + mprA + "," + DirPath + mprB;
                        //else if (Frontlabel != "")
                        //    FilePathUrl = DirPath + "/mprs/" + mprA;
                        //else
                        //    FilePathUrl = DirPath + "/mprs/" + mprB;


                        Guid ItemID = Guid.NewGuid();
                        string Index = dtBanJian.Rows[i]["柜号"].ToString();
                        string PartsNo = dtBanJian.Rows[i]["物料编码"].ToString();
                        string ItemName = dtBanJian.Rows[i]["板件名称"].ToString() + "-" + Index;
                        string ItemType = dtBanJian.Rows[i]["颜色"].ToString();//颜色
                        string MaterialType = dtBanJian.Rows[i]["材质"].ToString();
                        string BarcodeNo = dtBanJian.Rows[i]["板件ID"].ToString();
                        string TextureDirection = "";
                        string HoleDesc = "";
                        string MadeWidth = dtBanJian.Rows[i]["开料宽"].ToString();
                        string MadeHeigh = dtBanJian.Rows[i]["厚"].ToString();
                        string MadeLength = dtBanJian.Rows[i]["开料长"].ToString();
                        string EndWidth = dtBanJian.Rows[i]["成型宽"].ToString();
                        string EndLength = dtBanJian.Rows[i]["成型长"].ToString();
                        string Qty = dtBanJian.Rows[i]["数量"].ToString();
                        string Frontlabel = dtBanJian.Rows[i]["A面MPR"].ToString();
                        string BackLabel = dtBanJian.Rows[i]["B面MPR"].ToString();
                        string Remarks = dtBanJian.Rows[i]["备注"].ToString();
                        string Edge1 = "";
                        string Edge2 = "";
                        string Edge3 = "";
                        string Edge4 = "";
                        string EdgeDesc = dtBanJian.Rows[i]["封边"].ToString();
                        string IsSpecialShap = dtBanJian.Rows[i]["是否异型"].ToString() == "是" ? "1" : "0";


                        string mprA = Frontlabel;
                        string mprB = BackLabel;
                        string FilePathUrl = "";
                        string DirPath = (unZipDir + directoryName).Substring((unZipDir + directoryName).IndexOf("temp")).Replace("\\", "/");
                        DirPath += "/";
                        DirPath = DirPath.Replace("//", "/");
                        if (DirPath.IndexOf("mprs") == -1)
                            DirPath = DirPath + "mprs/";

                        if (Frontlabel != "" && BackLabel != "")
                            FilePathUrl = DirPath + mprA + "," + DirPath + mprB;
                        else if (Frontlabel != "")
                            FilePathUrl = DirPath + "/" + mprA;
                        else if (BackLabel != "")
                            FilePathUrl = DirPath + "/" + mprB;




                        string condition = "Index =" + Index;
                        DataRow[] dr = dtIndexs.Select(condition);
                        CabinetID = Guid.Parse(dr[0]["CabinetID"].ToString());

                        tmpBJ = ItemID + "@" + PartsNo + "@" + ItemName + "@" + ItemType + "@" + MaterialType
                            + "@" + BarcodeNo + "@" + SolutionID + "@" + CabinetID + "@" + TextureDirection
                            + "@" + HoleDesc + "@" + MadeWidth + "@" + MadeHeigh + "@" + MadeLength
                        + "@" + EndWidth + "@" + EndLength + "@" + Qty + "@" + Frontlabel + "@" + BackLabel + "@" + Remarks
                         + "@" + Edge1 + "@" + Edge2 + "@" + Edge3 + "@" + Edge4 + "@" + EdgeDesc + "@" + IsSpecialShap + "@" + FilePathUrl
                         + "@" + Created + "@" + CreatedBy + "@" + Modified + "@" + ModifiedBy;


                        Database dbBJ = new Database("BE_SolutionDetail_Proc", "ADD", 0, 0, tmpBJ, "", "");
                        int result = dbBJ.ExecuteNoQuery();
                    }



                    string tmpWJ = "";
                    for (int i = 0; i < dtWuJin.Rows.Count; i++)
                    {
                        //Guid ItemID = Guid.NewGuid();
                        //string BarcodeNo = dtWuJin.Rows[i][5].ToString();//物料编码"].ToString();
                        //string HardwareName = dtWuJin.Rows[i][2].ToString();//名称"].ToString();
                        //string HardwareCode = dtWuJin.Rows[i][5].ToString();//物料编码"].ToString();
                        //string HardwareCategory = dtWuJin.Rows[i][4].ToString();//分类"].ToString();
                        //string Style = dtWuJin.Rows[i][6].ToString();//规格/型号"].ToString(); ;//规格型号
                        //string Qty = dtWuJin.Rows[i][7].ToString();//数量"].ToString();
                        //string Unit = dtWuJin.Rows[i][8].ToString();//单位"].ToString();
                        //string Remarks = dtWuJin.Rows[i][9].ToString();//备注"].ToString();


                        Guid ItemID = Guid.NewGuid();
                        string BarcodeNo = dtWuJin.Rows[i]["物料编码"].ToString();
                        string HardwareName = dtWuJin.Rows[i]["名称"].ToString();
                        string HardwareCode = dtWuJin.Rows[i]["物料编码"].ToString();
                        string HardwareCategory = dtWuJin.Rows[i]["分类"].ToString();
                        string Style = dtWuJin.Rows[i]["规格型号"].ToString(); ;//规格型号
                        string Qty = dtWuJin.Rows[i]["数量"].ToString();
                        string Unit = dtWuJin.Rows[i]["单位"].ToString();
                        string Remarks = dtWuJin.Rows[i]["备注"].ToString();



                        tmpWJ = ItemID + "@" + BarcodeNo + "@" + SolutionID + "@" + CabinetID + "@" +
                            HardwareCode + "@" + HardwareName + "@" + HardwareCategory + "@" +
                            Style + "@" + Qty + "@" + Unit + "@" + Remarks + "@" +
                            Created + "@" + CreatedBy + "@" + Modified + "@" + ModifiedBy;
                        Database dbWJ = new Database("BE_Solution2Hardware_Proc", "ADD", 0, 0, tmpWJ, "", "");
                        int result = dbWJ.ExecuteNoQuery();
                    }
                }


            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
            return fileUrl;
        }

        public void GetCabinets()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    List<Solution2Cabinet> cabinets = p.Client.GetSolution2CabinetsBySolutionID(SenderUser, Guid.Parse(Request["SolutionID"]));
                    Response.Write(JSONHelper.List2DataSetJson(cabinets));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetSolution()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Solution solution = p.Client.GetSolution(SenderUser, Guid.Parse(Request["SolutionID"]));
                    if (solution != null)
                    {
                        Response.Write(JSONHelper.Object2Json(solution));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }

        public void GetSolutionByDesignerID()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["DesignerID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["DesignerID"]));
                    if (solution != null)
                    {
                        Response.Write(JSONHelper.Object2Json(solution));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }

        public void GetSoluionByReferenceID()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("ReferenceID:调用参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    Solution solution = op.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"].ToString()));
                    if (solution != null)
                    {
                        Response.Write(JSONHelper.Object2JSON(solution));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void GetSolutionStatus()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["SolutionID"]) && string.IsNullOrEmpty(Request["Status"]))
                    {
                        throw new Exception("参数调用无效");
                    }
                    var SolutionID = Guid.Parse(Request["SolutionID"].ToString());
                    var solution = p.Client.GetSolution(SenderUser, SolutionID);
                    var kk = Request["Status"].ToString();
                    if (solution != null)
                    {
                        if (!solution.Status.Equals(Request["Status"], StringComparison.CurrentCultureIgnoreCase))
                        {
                            WriteMessage(0, "状态已改变");
                        }
                        else
                        {
                            WriteMessage(1, "状态不变");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetSolutionDetails()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchSolutionDetailArgs args = new SearchSolutionDetailArgs();
                    args.OrderBy = "[CabinetID],[BarcodeNo]";

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.SolutionID = Guid.Parse(Request["SolutionID"]);
                    SearchResult sr = p.Client.SearchSolutionDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetSolutionHardwares()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchSolution2HardwareArgs args = new SearchSolution2HardwareArgs();
                    args.OrderBy = "[CabinetID],[BarcodeNo]";

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.SolutionID = Guid.Parse(Request["SolutionID"]);
                    SearchResult sr = p.Client.SearchSolutionHardware(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetSoltionSpkFile()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchSolutionFileArgs args = new SearchSolutionFileArgs();
                    args.OrderBy = "Created desc";

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.SolutionID = Guid.Parse(Request["SolutionID"]);
                    SearchResult sr = p.Client.SearchSolutionFile(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        //工厂审核通过
        /// <summary>
        /// 工厂审核通过
        /// </summary>
        public void ComfirmSolution()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("ReferenceID:无效参数");
                }
                if (string.IsNullOrEmpty(Request["TaskID"]))
                {
                    throw new Exception("TaskID:无效参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    if (solution != null)
                    {
                        //方案状态：N,待上传方案文件；P,待生成报价明细；Q,待报价确认；F,方案成交；C,方案取消；
                        solution.Status = "Q";
                        SaveSolutionArgs args = new SaveSolutionArgs();
                        args.Solution = solution;
                        p.Client.SaveSolution(SenderUser, args);

                        #region 任务流程
                        PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"]));
                        if (task != null)
                        {
                            SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                            taskArgs.PartnerTask = task;
                            taskArgs.NextStep = "生成报价合同";
                            taskArgs.Resource = CurrentUser.UserCode;//当前处理组
                            taskArgs.NextResource = "报价确认组";//下一处理组
                            taskArgs.ActionRemarksType = "";
                            taskArgs.ActionRemarks = "";
                            taskArgs.Action = "设计方案工厂审核通过";
                            p.Client.SavePartnerTask(SenderUser, taskArgs);
                            WriteSuccess();
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }

        public void CancelSolution()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("ReferenceID:无效参数");
                }
                if (string.IsNullOrEmpty(Request["TaskID"]))
                {
                    throw new Exception("TaskID:无效参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    if (solution != null)
                    {
                        //方案状态：N,待上传方案文件；P,待生成报价明细；Q,待报价确认；F,方案成交；C,方案取消；
                        solution.Status = "C";
                        SaveSolutionArgs args = new SaveSolutionArgs();
                        args.Solution = solution;
                        p.Client.SaveSolution(SenderUser, args);

                        #region 任务流程
                        PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"]));
                        task.StepName = "方案取消";
                        if (task != null)
                        {
                            SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                            taskArgs.PartnerTask = task;
                            taskArgs.NextStep = "方案取消";
                            taskArgs.Resource = "报价确认组";//当前处理组
                            taskArgs.NextResource = "";//下一处理组
                            taskArgs.ActionRemarksType = "";
                            taskArgs.ActionRemarks = "方案取消";
                            taskArgs.Action = "方案取消";

                            p.Client.SavePartnerTask(SenderUser, taskArgs);
                            WriteSuccess();
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }

        public void UndoSolution()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("无效参数");
                }
                if (string.IsNullOrEmpty(Request["TaskID"]))
                {
                    throw new Exception("无效参数");
                }
                using (ProxyBE p = new ProxyBE())
                {

                    string DesignID = Request["ReferenceID"] ?? "";

                    Database db = new Database("BE_PartnerTask_Proc", "SENDSPLITFC", 0, 0, DesignID, "", "");
                    int result = db.ExecuteNoQuery();
                    if (result > 0)
                    {
                        WriteMessage(1, "重置成功！");
                        //WriteSuccess();
                    }
                    else
                    {
                        Response.Write("重置失败");
                    }


                    //Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    //if (solution != null)
                    //{
                    //    //方案状态：N,待上传方案文件；P,待生成报价明细；Q,待报价确认；F,方案成交；C,方案取消；
                    //    solution.Status = "N";
                    //    SaveSolutionArgs args = new SaveSolutionArgs();
                    //    args.Solution = solution;
                    //    p.Client.SaveSolution(SenderUser, args);

                    //    #region 任务流程
                    //    PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"]));

                    //    if (task != null)
                    //    {
                    //        SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                    //        taskArgs.PartnerTask = task;
                    //        task.StepName = "设计师重传方案";
                    //        taskArgs.NextStep = "设计师重传方案";
                    //        taskArgs.Resource = "报价确认组";//当前处理组
                    //        taskArgs.NextResource = solution.Designer;//下一处理组
                    //        taskArgs.ActionRemarksType = "";
                    //        taskArgs.ActionRemarks = "门店方案审核不通过，设计师重新上传方案";
                    //        taskArgs.Action = "门店方案审核不通过，设计师重新上传方案";

                    //        p.Client.SavePartnerTask(SenderUser, taskArgs);
                    //        WriteSuccess();
                    //    }
                    //    #endregion
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }

        public void FileUpload()
        {
            try
            {
                #region 文件上传
                Response.ContentType = "text/plain";
                Response.Charset = "utf-8";
                HttpPostedFile file = null;
                try
                {
                    file = Request.Files["Filedata"];
                }
                catch
                {
                    throw new Exception("文件上传无效。");
                }

                string SolutionID = Request["SolutionID"];
                string CabinetID = Request["CabinetID"];
                string FileType = Request["FileType"];
                string uploadPath = DateTime.Now.ToString("yyyyMMdd") + "/";
                if (SolutionID != null)
                {
                    uploadPath = uploadPath + SolutionID + "/";
                }

                if (FileType != null)
                {
                    uploadPath = uploadPath + FileType + "/";
                }

                //公司ID/yyyyMM/文件类型(SolutionFile)/SolutionID/CabinetID/FileName
                string savepath = DateTime.Now.ToString("yyyyMM");

                if (!string.IsNullOrEmpty(FileType))
                {
                    savepath = Path.Combine(savepath, FileType);
                }
                if (!string.IsNullOrEmpty(SolutionID))
                {
                    savepath = Path.Combine(savepath, SolutionID);
                }
                else
                {
                    throw new Exception("方案数据有误，请关闭后重新再试。");
                }

                if (!string.IsNullOrEmpty(CabinetID))
                {
                    savepath = Path.Combine(savepath, CabinetID);
                }

                savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));

                //通过SE上传文件，缺少SE服务，暂时注释
                //using (ProxySE ps = new ProxySE())
                //{
                //    byte[] buffer = new byte[file.ContentLength];
                //    Stream sr = file.InputStream;
                //    sr.Read(buffer, 0, file.ContentLength);
                //    ps.Client.UploadDoumentFile(SenderUser, savepath, buffer);
                //}
                #endregion

                #region 文件记录
                using (ProxyBE p = new ProxyBE())
                {
                    Guid SourceID = Guid.Empty;
                    string SourceType = "";
                    if (string.IsNullOrEmpty(CabinetID))
                    {
                        SourceID = new Guid(SolutionID);
                        SourceType = "S";
                    }
                    else
                    {
                        SourceID = new Guid(CabinetID);
                        SourceType = "C";
                    }

                    SolutionFile sf = p.Client.GetSolutionFileBySourceID(SenderUser, SourceID);
                    if (sf == null)
                    {
                        sf = new SolutionFile();
                        sf.FileID = Guid.NewGuid();
                    }
                    sf.SolutionID = new Guid(SolutionID);
                    sf.FileName = Path.GetFileName(file.FileName);
                    sf.FileUrl = savepath;
                    sf.Status = "N";
                    sf.SourceID = SourceID;
                    sf.SourceType = SourceType;

                    SaveSolutionFileArgs args = new SaveSolutionFileArgs();
                    args.SolutionFile = sf;
                    p.Client.SaveSolutionFile(SenderUser, args);
                    if (!string.IsNullOrEmpty(CabinetID))
                    {
                        Solution2Cabinet cabinet = p.Client.GetSolution2Cabinet(SenderUser, new Guid(CabinetID));
                        if (cabinet != null)
                        {
                            cabinet.FileUploadFlag = true;
                            p.Client.SaveSolution2Cabinet(SenderUser, cabinet);
                        }
                    }
                    List<Solution2Cabinet> cabinets = p.Client.GetSolution2CabinetsBySolutionID(SenderUser, new Guid(SolutionID));
                    if (cabinets.FindAll(li => li.FileUploadFlag == false).Count == 0)
                    {
                        Solution solution = p.Client.GetSolution(SenderUser, new Guid(SolutionID));
                        if (solution != null)
                        {
                            solution.Status = "P";
                            SaveSolutionArgs saveSolutionArgs = new SaveSolutionArgs();
                            saveSolutionArgs.Solution = solution;
                            p.Client.SaveSolution(SenderUser, saveSolutionArgs);
                        }
                    }
                }
                #endregion

                Response.Write("0");
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        private void UploadFile(string sourcefile, string savepath)
        {
            //通过SE上传文件,无SE服务，暂时注释
            //using (ProxySE ps = new ProxySE())
            //{
            //    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
            //    {
            //        byte[] buffer = new byte[fs.Length];
            //        int scSize = fs.Read(buffer, 0, buffer.Length);
            //        ps.Client.UploadDoumentFile(SenderUser, savepath, buffer);
            //    }
            //    File.Delete(sourcefile);
            //}
        }

        public void CheckFileExists()
        {
        }

        public void GetSolutionFiles()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["QuoteNo"]))
                    {
                        throw new Exception("参数无效");
                    }

                    SearchQuoteMainArgs ag = new SearchQuoteMainArgs();
                    ag.QuoteNo = Request["QuoteNo"];
                    SearchResult sr = p.Client.SearchQuote(SenderUser, ag);
                    if (sr.Total != 0)
                    {
                        string SolutionID = sr.DataSet.Tables[0].Rows[0]["SolutionID"].ToString();
                        SearchSolutionFileArgs args = new SearchSolutionFileArgs();
                        args.RowNumberFrom = pagingParm.RowNumberFrom;
                        args.RowNumberTo = pagingParm.RowNumberTo;
                        args.OrderBy = "Created Desc";

                        if (!string.IsNullOrEmpty(SolutionID))
                        {
                            args.SolutionID = Guid.Parse(SolutionID);
                        }

                        SearchResult s = p.Client.SearchSolutionFile(SenderUser, args);
                        Response.Write(JSONHelper.Dataset2Json(s.DataSet));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Dataset2Json(null));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void ChenSaveUrl()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Solution solution = p.Client.GetSolution(SenderUser, Guid.Parse(Request["SolutionID"]));
                    if (solution != null)
                    {
                        Response.Write(JSONHelper.Object2Json(solution));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }
    }
}