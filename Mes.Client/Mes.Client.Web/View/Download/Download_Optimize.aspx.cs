using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mes.Client.Web.View.Download
{
    public partial class Download_Optimize : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Request["BattchNum"]))
                {
                    throw new Exception("非法数据请求。提示：批次号无效。");
                }
                try
                {
                    string sourceFileName = Server.MapPath("/template/mes_out.xls");
                    string targetFileName = "";
                    using (ProxyBE p = new ProxyBE())
                    {
                        SearchOrderDetailArgs args = new SearchOrderDetailArgs();
                        args.OrderBy = "[OrderID]";
                        //按批次导出
                        string BattchNo = Request["BattchNum"].ToString();
                        args.BattchCode = BattchNo;
                        args.CabinetStatus = "M";
                        SearchResult sr = p.Client.SearchOrderDetail(SenderUser, args);

                        #region 排除库存件及外购件
                        List<Category> lists = new List<Category>();
                        List<Category> lists_O = new List<Category>();
                        Category cate_S = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, "StorageMaterials");
                        Category cate_O = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, "OutSourcingMaterials");
                        if (cate_S != null)
                        {
                            lists = p.Client.GetCategoriesByParentID(SenderUser, cate_S.CategoryID);
                        }
                        if (cate_O != null)
                        {
                            lists_O = p.Client.GetCategoriesByParentID(SenderUser, cate_O.CategoryID);
                        }
                        lists.AddRange(lists_O);//两个集合合并
                        var whereItems = new Dictionary<string, string>();

                        foreach (Category c in lists)
                        {
                            if (c.IsDisabled) continue;
                            string[] CategoryNames = c.CategoryName.Split(',');
                            string where = "";
                            foreach (string s in CategoryNames)
                            {
                                if (s.Trim() != "")
                                {
                                    where += string.Format(" ItemName not like '%{0}%' ", s);
                                }
                            }
                            whereItems.Add(c.CategoryName, where);
                        }
                        var condition = string.Empty;
                        foreach (var item in whereItems)
                        {
                            condition += item.Value + "And";
                        }
                        condition = condition.TrimEnd('A', 'n', 'd');
                        var srows = sr.DataSet.Tables[0].Select(condition);

                        var tmpDs = new DataSet();
                        DataTable dt = sr.DataSet.Tables[0].Clone(); //复制表结构
                        if (srows.Length > 0)
                        {
                            foreach (var row in srows)
                                dt.ImportRow(row);
                        }
                        tmpDs.Tables.Add(dt);

                        #endregion

                        //批次总柜数
                        int TotalBattchQty = p.Client.GetTotalOrderBattchQty(SenderUser, BattchNo);

                        targetFileName = Path.Combine(Config.StorageFolder, "temp");
                        if (!Directory.Exists(targetFileName))
                        {
                            Directory.CreateDirectory(targetFileName);
                        }
                        targetFileName = Path.Combine(targetFileName, BattchNo + "_排产优化.xls");

                        if (File.Exists(targetFileName))
                        {
                            File.Delete(targetFileName);
                        }
                        File.Copy(sourceFileName, targetFileName, true);

                        //加工文件
                        SearchOrderProcessFileArgs pfArgs = new SearchOrderProcessFileArgs();
                        pfArgs.BattchNum = BattchNo;
                        pfArgs.FileType = new List<string>() { "DXF", "CNC", "ProcessFile" };
                        SearchResult pfResult = p.Client.SearchOrderProcessFile(SenderUser, pfArgs);

                        //订单列表
                        List<Guid> list_OrderIDs = new List<Guid>();
                        List<Category> category_lists = new List<Category>();
                        Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, "OptimizeType");
                        if (category != null)
                        {
                            category_lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        }
                        Dictionary<string, string> conditions = new Dictionary<string, string>();

                        if (category_lists.Count == 0)
                        {
                            conditions.Add("开料", "IsSpecialShap=0");
                        }
                        else
                        {
                            conditions.Add("异形板", "IsSpecialShap=1"); //先抽异型
                            var list = category_lists.OrderByDescending(o => o.Sequence); //排序：先挑Y的数据
                            foreach (Category c in list)
                            {
                                if (c.IsDisabled) continue;
                                string[] CategoryNames = c.CategoryName.Split(',');
                                string where = " 1=1 and (1>2 ";

                                if (CategoryNames.Contains("Y"))
                                {
                                    where += string.Format(" or ItemName like '{0}%')", c.CategoryName);
                                }
                                else if (CategoryNames.Length == 1)
                                {
                                    where += string.Format(" or ItemName like '%{0}%') and MadeWidth>=78 and MadeLength>=78", c.CategoryName);
                                }
                                else
                                {
                                    foreach (string s in CategoryNames)
                                    {
                                        if (s.Trim() != "")
                                        {
                                            where += string.Format(" or ItemName like '%{0}%'", s);
                                        }
                                    }
                                    where += ") and MadeWidth>=78 and MadeLength>=78";
                                }
                                conditions.Add(c.CategoryName, where);
                            }
                        }

                        conditions.Add("小板", "IsSpecialShap=0 and (MadeWidth<78 or MadeLength<78)");
                        //异形
                        //conditions.Add("异形板", "IsSpecialShap=1");
                        conditions.Add("其它", "1=1");
                        using (FileStream fs = new FileStream(targetFileName, FileMode.Open, FileAccess.Read))
                        {
                            #region 导出数据
                            IWorkbook workbook = new HSSFWorkbook(fs);
                            ISheet worksheet = workbook.GetSheetAt(0);
                            int sheet_index = 0;
                            foreach (string key in conditions.Keys)
                            {
                                //DataRow[] rows = sr.DataSet.Tables[0].Select(conditions[key]);
                                DataRow[] rows = tmpDs.Tables[0].Select(conditions[key]);

                                if (rows.Length == 0) continue;

                                #region 填充数据
                                if (sheet_index >= 1)
                                {
                                    worksheet.CopySheet(key + "_优化数据表", true);
                                }
                                else
                                {
                                    workbook.SetSheetName(sheet_index, key + "_优化数据表");
                                }

                                worksheet = workbook.GetSheetAt(sheet_index);
                                sheet_index++;
                                #region 清空sheet页数据
                                int TotalRows = worksheet.LastRowNum;
                                for (int rownum = 1; rownum <= TotalRows; rownum++)
                                {
                                    IRow datarow = worksheet.GetRow(rownum);
                                    worksheet.RemoveRow(datarow);
                                }
                                #endregion

                                int rows_index = 1;//从第2行开始导入
                                foreach (DataRow row in rows)
                                {
                                    Guid OrderID = new Guid(row["OrderID"].ToString());
                                    if (!list_OrderIDs.Contains(OrderID))
                                    {
                                        list_OrderIDs.Add(OrderID);
                                    }

                                    //加工文件
                                    string dxfFile = "";
                                    DataRow[] pfrow = pfResult.DataSet.Tables[0].Select(string.Format("FileName like '%{0}%' and OrderID='{1}'", row["BarcodeNo"].ToString(), OrderID));
                                    if (pfrow.Length > 0)
                                    {
                                        dxfFile = pfrow[0]["FilePath"].ToString();
                                    }

                                    IRow _row = worksheet.CreateRow(rows_index);                        //表示每循环一次，在Excel中创建一行，并给这一行
                                    _row.Height = 25 * 20;
                                    _row.CreateCell(0).SetCellValue(rows_index);                        //序号
                                    _row.CreateCell(1).SetCellValue(row["ItemName"].ToString());        //板件名称
                                    _row.CreateCell(2).SetCellValue(row["BarcodeNo"].ToString());        //板件名称
                                    _row.CreateCell(3).SetCellValue(row["MaterialType"].ToString());    //材质颜色
                                    _row.CreateCell(4).SetCellValue(decimal.Parse(row["MadeLength"].ToString()).ToString("#"));      //开料长度
                                    _row.CreateCell(5).SetCellValue(decimal.Parse(row["MadeWidth"].ToString()).ToString("#"));       //开料宽度
                                    _row.CreateCell(6).SetCellValue(decimal.Parse(row["MadeHeight"].ToString()).ToString("#"));      //厚度
                                    _row.CreateCell(7).SetCellValue(decimal.Parse(row["EndLength"].ToString()).ToString("#"));       //成品长度                                    
                                    _row.CreateCell(8).SetCellValue(decimal.Parse(row["EndWidth"].ToString()).ToString("#"));        //成品宽度
                                    _row.CreateCell(9).SetCellValue(row["IsSpecialShap"].ToString().ToLower() == "true" ? "是" : "否");//是否异形
                                    _row.CreateCell(10).SetCellValue(decimal.Parse(row["Qty"].ToString()).ToString("#"));             //数量
                                    _row.CreateCell(11).SetCellValue(row["TextureDirection"].ToString()); //修改纹理
                                    _row.CreateCell(12).SetCellValue(row["EdgeDesc"].ToString());        //封边描述
                                    _row.CreateCell(13).SetCellValue(row["FrontLabel"].ToString());     //正面条码
                                    _row.CreateCell(14).SetCellValue(row["BackLabel"].ToString());      //反面条码
                                    _row.CreateCell(15).SetCellValue(row["CabinetGroup"].ToString());   //柜体号
                                    _row.CreateCell(16).SetCellValue(row["Remarks"].ToString());        //工艺备注
                                    _row.CreateCell(17).SetCellValue(dxfFile);                          //保存路径
                                    _row.CreateCell(18).SetCellValue(row["OrderNo"].ToString());        //订单号
                                    _row.CreateCell(19).SetCellValue(row["CustomerName"].ToString());   //客户名称
                                    _row.CreateCell(20).SetCellValue(row["Address"].ToString());        //客户地址 
                                    _row.CreateCell(21).SetCellValue(row["ShipDate"].ToString());       //交货日期
                                    _row.CreateCell(22).SetCellValue(row["CabinetName"].ToString());    //产品名称
                                    _row.CreateCell(23).SetCellValue(row["MaterialStyle"].ToString());  //风格                                    
                                    _row.CreateCell(24).SetCellValue(row["MaterialCategory"].ToString()); //材质
                                    _row.CreateCell(25).SetCellValue(row["Color"].ToString());            //颜色
                                    _row.CreateCell(26).SetCellValue(row["BattchCode"].ToString());        //批次号
                                    _row.CreateCell(27).SetCellValue(TotalBattchQty);      //批次总柜数
                                    _row.CreateCell(28).SetCellValue(row["BattchIndex"].ToString());      //批次柜号
                                    int TotalOrderQty = p.Client.GetTotalOrderCabinetQty(SenderUser, new Guid(row["OrderID"].ToString()));
                                    _row.CreateCell(29).SetCellValue(TotalOrderQty);      //订单总柜数
                                    _row.CreateCell(30).SetCellValue(row["Sequence"].ToString());      //当前柜号                                    				
                                    rows_index++;
                                }

                                foreach (DataRow r in rows)
                                {
                                    //sr.DataSet.Tables[0].Rows.Remove(r);
                                    tmpDs.Tables[0].Rows.Remove(r);
                                }
                                #endregion
                            }
                            #endregion
                            Response.Clear();
                            HttpContext.Current.Response.Buffer = true;
                            Response.ContentType = "application/ms-excel";
                            Response.Charset = "GB2312";
                            Response.ContentEncoding = Encoding.UTF8;
                            Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(Path.GetFileName(targetFileName)));
                            using (MemoryStream ms = new MemoryStream())
                            {
                                //将工作簿的内容放到内存流中
                                workbook.Write(ms);
                                //将内存流转换成字节数组发送到客户端
                                Response.BinaryWrite(ms.GetBuffer());
                                //Response.End();
                            }

                            using (MemoryStream ms = new MemoryStream())
                            {
                                workbook.Write(ms);
                                FileStream file = new FileStream(targetFileName, FileMode.Create);
                                workbook.Write(file);
                                file.Close();
                                workbook = null;
                                ms.Close();
                                ms.Dispose();
                            }

                            p.Client.UpdateOrder2CabinetStatusByBattchCode(BattchNo, "P");

                            //排产完成
                            foreach (Guid orderid in list_OrderIDs)
                            {
                                List<Order2Cabinet> cabinets = p.Client.GetOrder2CabinetByOrderID(SenderUser, orderid);
                                if (cabinets.Find(li => li.CabinetStatus == "M") != null) continue;

                                Order order = p.Client.GetOrder(SenderUser, orderid);
                                if (order != null)
                                {
                                    order.Status = "P";
                                    order.StepNo++;

                                    SaveOrderArgs orderArgs = new SaveOrderArgs();
                                    orderArgs.Order = order;

                                    //流程步骤
                                    //OrderTask ot = new OrderTask();
                                    //ot.Action = "订单优化完成，待生产";
                                    //ot.CurrentStep = "订单优化";
                                    //ot.ActionRemarksType = "订单系统操作";
                                    //ot.ActionRemarks = "订单优化完成，待生产";
                                    //ot.Resource = "订单排产组";
                                    //ot.NextResources = "";
                                    //ot.NextStep = "待生产";
                                    //orderArgs.OrderTask = ot;

                                    p.Client.SaveOrder(SenderUser, orderArgs);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}