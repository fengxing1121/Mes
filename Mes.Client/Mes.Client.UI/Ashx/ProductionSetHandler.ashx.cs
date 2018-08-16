using LitJson;
using Mes.Client.Model;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.UI.Ashx
{
    public class ProductionSetHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        ProductionSetParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new ProductionSetParm(context);
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

        #region 查询数据
        public void SearchProductionSet()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchProductionSetArgs args = new SearchProductionSetArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["SetID"]))
                    {
                        args.SetID = parm.SetID;
                    }
                    if (!string.IsNullOrEmpty(Request["Started"]))
                    {
                        args.Started = parm.Started;
                    }
                    if (!string.IsNullOrEmpty(Request["Ended"]))
                    {
                        args.Ended = parm.Ended;
                    }
                    if (!string.IsNullOrEmpty(Request["Weeks"]))
                    {
                        args.Weeks = parm.Weeks;
                    }
                    if (!string.IsNullOrEmpty(Request["Days"]))
                    {
                        args.Days = parm.Days;
                    }
                    if (!string.IsNullOrEmpty(Request["TotalAreal"]))
                    {
                       // args.TotalAreal = parm.TotalAreal;
                    }
                    if (!string.IsNullOrEmpty(Request["Created"]))
                    {
                        args.Created = parm.Created;
                    }
                    if (!string.IsNullOrEmpty(Request["CreatedBy"]))
                    {
                        args.CreatedBy = parm.CreatedBy;
                    }

                    SearchResult sr = p.Client.SearchProductionSet(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void SearchProductionSetDayDetail()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchProductionSetDayDetailArgs args = new SearchProductionSetDayDetailArgs();

                    args.OrderBy = "WeekNo,Datetime  asc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    args.SetID = new Guid(Request["SetID"]);

                    SearchResult sr = p.Client.SearchProductionSetDayDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        #endregion

        #region 操作数据
        public void SaveProductionSet()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SaveProductionSetArgs args = new SaveProductionSetArgs();
                    ProductionSet obj = new ProductionSet();
                    if (!string.IsNullOrEmpty(Request["edit"]))
                    {
                        obj = p.Client.GetProductionSet(SenderUser, parm.SetID);
                    }
                    if (obj == null)
                    {
                        throw new Exception("数据不存在。");
                    }
                    if (string.IsNullOrEmpty(Request["calendars"]))
                    {
                        throw new Exception("参数错误。");
                    }
                    if (string.IsNullOrEmpty(Request["totalareal"]))
                    {
                        throw new Exception("参数错误。");
                    }
                    if (string.IsNullOrEmpty(Request["weeks"]))
                    {
                        throw new Exception("参数错误。");
                    }

                    decimal Monthtotalareal = decimal.Parse(Request["totalareal"]);//销售预测总量
                    List<Calendar> mainlist = JsonMapper.ToObject<List<Calendar>>(Request["calendars"]).OrderBy(t => t.datetime).ToList();

                    obj.SetID = Guid.NewGuid();
                    obj.Started = mainlist.OrderBy(t => t.datetime).FirstOrDefault().datetime;
                    obj.Ended = mainlist.OrderByDescending(t => t.datetime).FirstOrDefault().datetime;
                    obj.Weeks = mainlist.GroupBy(t => t.weekno).Count();
                    obj.Days = mainlist.Count;
                    obj.TotalAreal = Monthtotalareal;
                    args.ProductionSet = obj;

                    if (p.Client.ExistsProductionSetDayDetailByDatetime(obj.Started,obj.Ended))
                    {
                        throw new Exception(string.Format("{0}至{1}已有排班设置", obj.Started.ToString("D"), obj.Ended.ToString("D")));
                    }

                    #region 生产订单排单设置周计划详情表
                    List<ProductionSetWeekDetail> weeklist = new List<ProductionSetWeekDetail>();
                    JsonData sj = JsonMapper.ToObject(Request["weeks"]);
                    if (sj.Count > 0)
                    {
                        foreach (JsonData item in sj)
                        {
                            var MaxCapacity = decimal.Parse(item["MaxCapacity"].ToString());
                            var weekTotalAreal = obj.TotalAreal * (MaxCapacity/100);//每周总产量=销售预测总量*周比列
                            ProductionSetWeekDetail model = new ProductionSetWeekDetail()
                            {
                                ID = Guid.NewGuid(),
                                SetID = obj.SetID,
                                WeekNo = int.Parse(item["WeekNo"].ToString()),
                                TotalAreal = weekTotalAreal,
                                MaxCapacity = MaxCapacity,
                            };
                            weeklist.Add(model);
                        }
                    } 
                    var weekCapacity = weeklist.Sum(t => t.MaxCapacity);
                    if (weekCapacity != 100)
                    {
                        throw new Exception(string.Format("比列设置相加必需为100%，当前比列为{0}%", weekCapacity));
                    }
                    var TotalAreal = weeklist.Sum(t => t.TotalAreal);
                    //if (MaxCapacity != 100)
                    //{
                    //    WriteMessage(-1, string.Format("当前周比列设置可排{0}㎡，实际应排{1}㎡", weekstotal, obj.TotalAreal));
                    //    return;
                    //}
                    args.ProductionSetWeekDetails = weeklist.OrderBy(t => t.WeekNo).ToList();

                    #endregion

                    #region 生产订单排单设置日计划详情表

                    List<ProductionSetDayDetail> daylist = new List<ProductionSetDayDetail>();
                    foreach (Calendar Item in mainlist)
                    {
                        //周排产量
                        var weekTotalAreal =weeklist.Where(t => t.WeekNo == Item.weekno).FirstOrDefault().MaxCapacity * obj.TotalAreal;
                        //这周有多少天
                        var daycount = mainlist.Where(t => t.weekno == Item.weekno).Count();
                        //每天排多少
                        var dayTotalAreal =weekTotalAreal / daycount;

                        ProductionSetDayDetail model = new ProductionSetDayDetail()
                        {
                            ID = Guid.NewGuid(),
                            SetID = obj.SetID,
                            Datetime = Item.datetime,
                            TotalAreal = GetRoundParse(dayTotalAreal),
                            //TotalAreal =dayTotalAreal,
                            MadeTotalAreal = 0,
                            WeekNo = Item.weekno,
                        };
                        daylist.Add(model);
                    }
                    var daytotal= daylist.Sum(t => t.TotalAreal);

                    args.ProductionSetDayDetails = daylist.OrderBy(t => t.Datetime).ToList();
                    #endregion

                    p.Client.SaveProductionSets(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                WriteError(ex.Message, ex);
            }
        }
        public void GetweekAverage()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["totalareal"]))
                    {
                        throw new Exception("参数错误");
                    }
                    if (string.IsNullOrEmpty(Request["calendars"]))
                    {
                        throw new Exception("参数错误");
                    }
                    List<WeekCapacity> list = new List<WeekCapacity>();

                    decimal Monthtotalareal = decimal.Parse(Request["totalareal"]);//销售预测总量

                    List<Calendar> mainlist = JsonMapper.ToObject<List<Calendar>>(Request["calendars"]).OrderBy(t => t.datetime).ToList();

                    var dayAverage = Monthtotalareal / mainlist.Count;//所有工作日平均分配多少

                    var weeklist = mainlist.GroupBy(a => a.weekno).Select(g => (new { weekno = g.Key })).ToList();//总工有几周

                    #region 周运算
                    for (var i = 0; i < weeklist.Count; i++)
                    {
                        var weekdaycount = mainlist.Where(t => t.weekno == weeklist[i].weekno).Count();//这周有多少天
                        var Totalareal = dayAverage * weekdaycount;//每周总量
                        var Maxcapacity = Totalareal / Monthtotalareal;//建议比列=每周总量/销售预测总量

                        WeekCapacity model = new WeekCapacity()
                        {
                            weekno = weeklist[i].weekno,
                            weekdaycount = weekdaycount,
                            maxcapacity = GetRoundParse(Maxcapacity *100),
                            totalareal = GetRoundParse(Totalareal),
                            dayaverage = GetRoundParse(dayAverage),
                        };
                        list.Add(model);
                    }
                    #endregion

                    string json = JSONHelper.List2DataSetJson(SetWeekCapacityByList(list));
                    Response.Write(json);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        
        //修正误差
        private List<WeekCapacity> SetWeekCapacityByList(List<WeekCapacity> list)
        {
            List<WeekCapacity> resurtList = new List<WeekCapacity>();
            var sumcapacity = list.Sum(t => t.maxcapacity);
            var Totalarealweek = list.Sum(t => t.totalareal);
            var weekdaycountweek = list.Sum(t => t.weekdaycount);
            if (sumcapacity < 100)
            {
                var difference = 100 - sumcapacity;
                var model = list.OrderByDescending(t => t.maxcapacity).FirstOrDefault();
                var maxcapacityweek = model.maxcapacity + difference;//把误差值给比列最大的那周
                foreach(WeekCapacity Item in list)
                {
                    if(Item.weekno== model.weekno)
                    {
                        Item.maxcapacity = maxcapacityweek;
                    }
                    resurtList.Add(Item);
                }
            }
            else if (sumcapacity > 100)
            {
                var difference = sumcapacity-100;
                var model = list.OrderByDescending(t => t.maxcapacity).FirstOrDefault();
                var maxcapacityweek = model.maxcapacity -difference;//把误差值给比列最大的那周
                foreach (WeekCapacity Item in list)
                {
                    if (Item.weekno == model.weekno)
                    {
                        Item.maxcapacity = maxcapacityweek;
                    }
                    resurtList.Add(Item);
                }
            }
            else
            {
                resurtList = list;
            }

            var sumcapacity1 = resurtList.Sum(t => t.maxcapacity);
            var Totalarealweek1 = resurtList.Sum(t => t.totalareal);
            var weekdaycountweek1 = resurtList.Sum(t => t.weekdaycount);

            return resurtList;
        }

        public decimal GetRoundParse(decimal totalareal)
        {
            return Math.Round(totalareal, 2, MidpointRounding.AwayFromZero);
        }

        public void GetweekManual()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["totalareal"]))
                    {
                        throw new Exception("参数错误");
                    }
                    if (string.IsNullOrEmpty(Request["weeks"]))
                    {
                        throw new Exception("参数错误");
                    }
                    if (string.IsNullOrEmpty(Request["calendars"]))
                    {
                        throw new Exception("参数错误");
                    }
                    List<WeekCapacity> list = new List<WeekCapacity>();
                    decimal Monthtotalareal = decimal.Parse(Request["totalareal"]);
                    List<Calendar> mainlist = JsonMapper.ToObject<List<Calendar>>(Request["calendars"]).OrderBy(t => t.datetime).ToList();
                    JsonData sj = JsonMapper.ToObject(Request["weeks"]);
                    if (sj.Count > 0)
                    {
                        foreach (JsonData item in sj)
                        {
                            var WeekNo = int.Parse(item["WeekNo"].ToString());
                            var MaxCapacity = decimal.Parse(item["MaxCapacity"].ToString());//自定义比列
                            var weekdaycount = mainlist.Where(t => t.weekno == WeekNo).Count();//这周有多少天
                            var weekTotalAreal = Monthtotalareal * (MaxCapacity/100);//这周总量
                            var dayTotalAreal = weekTotalAreal / weekdaycount;//每天排多少

                            WeekCapacity model = new WeekCapacity()
                            {
                                weekno = int.Parse(item["WeekNo"].ToString()),
                                weekdaycount = weekdaycount,
                                maxcapacity = MaxCapacity,
                                totalareal = GetRoundParse(weekTotalAreal),
                                dayaverage = GetRoundParse(dayTotalAreal),
                            };
                            list.Add(model);
                        }
                    }
                    var weekCapacity = list.Sum(t => t.maxcapacity);
                    if (weekCapacity != 100)
                    {
                        throw new Exception(string.Format("比列设置相加必需为100%，当前比列为{0}%", weekCapacity));
                    }
                    string json = JSONHelper.List2DataSetJson(list);
                    Response.Write(json);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        #endregion
    }
}

