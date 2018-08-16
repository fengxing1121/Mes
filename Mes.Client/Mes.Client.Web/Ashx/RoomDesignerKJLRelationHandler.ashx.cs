using Eagle.Data;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// RoomDesignerKJLRelationHandler 的摘要说明
    /// </summary>
    public class RoomDesignerKJLRelationHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        RoomDesignerKJLRelationParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new RoomDesignerKJLRelationParm(context);
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

        public void SaveRoomDesigner()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    if (Request["DesignNo"] == null)
                    {
                        throw new Exception("设计号不能为空");
                    }
                    if (Request["DesignID"] == null)
                    {
                        throw new Exception("方案ID不能为空");
                    }
                    SaveRoomDesignerKJLRelationArgs args = new SaveRoomDesignerKJLRelationArgs();
                    RoomDesignerKJLRelation model = new RoomDesignerKJLRelation();
                    model.DesignerNo = parm.DesignerNo;
                    model.KJLDesignID = parm.KJLDesignID;

                    args.RoomDesignerKJLRelation = model;
                    RoomDesignerKJLRelation roomDesignerKJLRelation = p.Client.LoadRoomDesignerKJLRelatioByDesignID(SenderUser, args);
                    if (roomDesignerKJLRelation != null)
                    {
                        throw new Exception("该方案已经被绑定");
                    }

                    p.Client.SaveRoomDesignerKJLRelation(SenderUser, args);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void UpdateRoomDesigner()
        {

            try
            {
                Guid DesignerID = new Guid(Request["DesignerID"]);
                using (ProxyBE p = new ProxyBE())
                {
                    RoomDesigner rd = p.Client.GetRoomDesigner(SenderUser, DesignerID);
                    if (rd != null)
                    {
                        Response.Write(JSONHelper.Object2Json(rd));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(null));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        public void GetRoomDesignerKJLRelation()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["DesignID"]))
                {
                    throw new Exception("DesignID:调用参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    SaveRoomDesignerKJLRelationArgs args = new SaveRoomDesignerKJLRelationArgs();
                    RoomDesignerKJLRelation model = new RoomDesignerKJLRelation();
                    model.KJLDesignID = Request["DesignID"].ToString();

                    args.RoomDesignerKJLRelation = model;
                    RoomDesignerKJLRelation roomDesignerKJLRelation = op.Client.LoadRoomDesignerKJLRelatioByDesignID(SenderUser, args);
                    if (roomDesignerKJLRelation != null)
                    {
                        Response.Write(JSONHelper.Object2JSON(roomDesignerKJLRelation));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2JSON(null));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }

        }

        public void ExistsRoomDesignerKJLRelatioByDesignerNo()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["designNo"]))
                {
                    throw new Exception("designNo:设计号参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    bool result = op.Client.ExistsRoomDesignerKJLRelatioByDesignerNo(SenderUser, Convert.ToInt32((Request["designNo"])));
                    if (result)
                    {
                        WriteSuccess();
                    }
                    else
                    {
                        WriteError("该设计号已被绑定，不允许重复绑定");
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        /// <summary>
        /// 设计ID查询
        /// </summary>
        public void CheckDn()
        {
            string kw = Request["kw"].ToString();
            string partNerId = "";
            if (CurrentUser.PartnerID != Guid.Empty)
            {
                partNerId = CurrentUser.PartnerID.ToString();
            }
            Database db = new Database("BE_RoomDesigner_Proc", "CHECKDN", 4, 0, kw, partNerId, kw);
            using (SqlDataReader dr = db.ExecuteReader())
            {
                DataTable dt = StaticFunction.ConvertDataReaderToDataTable(dr);
                string json = JSONHelper.SerializeObject(dt);// JsonConvert.SerializeObject(dt);
                HttpContext.Current.Response.Write(json);
            }

        }
    }
}