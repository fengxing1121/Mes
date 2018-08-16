using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using MES.Libraries;
using System.Linq;

namespace Mes.BE.Objects
{
    public partial class ObjectProxy
    {

        #region BE_OrderWorkFlow InsertObject()
        public int InsertOrderWorkFlow(OrderWorkFlow obj)
        {
            string sql = @"INSERT INTO[BE_OrderWorkFlow]([WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				) VALUES(@WorkingID
				, @OrderID
				, @ItemID
				, @WorkFlowNo
				, @SourceWorkFlowID
				, @Action
				, @TargetWorkFlowID
				, @TotalQty
				, @MadeQty
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", Convert2DBnull(obj.WorkingID));
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", Convert2DBnull(obj.WorkFlowNo));
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", Convert2DBnull(obj.SourceWorkFlowID));
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", Convert2DBnull(obj.TargetWorkFlowID));
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", Convert2DBnull(obj.MadeQty));
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderWorkFlow UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrderWorkFlowByItemID_WorkFlowNo(OrderWorkFlow obj)
        {
            string sql = @"UPDATE [BE_OrderWorkFlow] SET [WorkingID]=@WorkingID
				, [OrderID]=@OrderID
				, [SourceWorkFlowID]=@SourceWorkFlowID
				, [Action]=@Action
				, [TargetWorkFlowID]=@TargetWorkFlowID
				, [TotalQty]=@TotalQty
				, [MadeQty]=@MadeQty
 				WHERE [ItemID]=@ItemID AND [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", Convert2DBnull(obj.WorkingID));
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", Convert2DBnull(obj.SourceWorkFlowID));
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", Convert2DBnull(obj.TargetWorkFlowID));
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", Convert2DBnull(obj.MadeQty));
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", Convert2DBnull(obj.WorkFlowNo));
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderWorkFlowByItemID_SourceWorkFlowID(OrderWorkFlow obj)
        {
            string sql = @"UPDATE [BE_OrderWorkFlow] SET [WorkingID]=@WorkingID
				, [OrderID]=@OrderID
				, [WorkFlowNo]=@WorkFlowNo
				, [Action]=@Action
				, [TargetWorkFlowID]=@TargetWorkFlowID
				, [TotalQty]=@TotalQty
				, [MadeQty]=@MadeQty
 				WHERE [ItemID]=@ItemID AND [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", Convert2DBnull(obj.WorkingID));
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", Convert2DBnull(obj.WorkFlowNo));
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", Convert2DBnull(obj.TargetWorkFlowID));
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", Convert2DBnull(obj.MadeQty));
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", Convert2DBnull(obj.SourceWorkFlowID));
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderWorkFlowByItemID_TargetWorkFlowID(OrderWorkFlow obj)
        {
            string sql = @"UPDATE [BE_OrderWorkFlow] SET [WorkingID]=@WorkingID
				, [OrderID]=@OrderID
				, [WorkFlowNo]=@WorkFlowNo
				, [SourceWorkFlowID]=@SourceWorkFlowID
				, [Action]=@Action
				, [TotalQty]=@TotalQty
				, [MadeQty]=@MadeQty
 				WHERE [ItemID]=@ItemID AND [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", Convert2DBnull(obj.WorkingID));
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", Convert2DBnull(obj.WorkFlowNo));
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", Convert2DBnull(obj.SourceWorkFlowID));
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", Convert2DBnull(obj.MadeQty));
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", Convert2DBnull(obj.TargetWorkFlowID));
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateOrderWorkFlowByWorkingID(OrderWorkFlow obj)
        {
            string sql = @"UPDATE [BE_OrderWorkFlow] SET [OrderID]=@OrderID
				, [ItemID]=@ItemID
				, [WorkFlowNo]=@WorkFlowNo
				, [SourceWorkFlowID]=@SourceWorkFlowID
				, [Action]=@Action
				, [TargetWorkFlowID]=@TargetWorkFlowID
				, [TotalQty]=@TotalQty
				, [MadeQty]=@MadeQty
 				WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", Convert2DBnull(obj.WorkFlowNo));
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", Convert2DBnull(obj.SourceWorkFlowID));
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", Convert2DBnull(obj.TargetWorkFlowID));
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", Convert2DBnull(obj.TotalQty));
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", Convert2DBnull(obj.MadeQty));
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", Convert2DBnull(obj.WorkingID));
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 删除OrderMadeState by ItemID_WorkFlowID返工 【liuyf】
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteOrderMadeStateByItemID_WorkFlowID(Guid ItemID, Guid WorkFlowID)
        {
            string sql = @"delete from [dbo].[BE_OrderMadeState] where ItemID=@ItemID and WorkFlowID=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", ItemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);
            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", WorkFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int CountOrderWorkFlows(Guid CabinetID)
        {
            string sql = string.Format(@"select count(BE_OrderDetail.CabinetID) from [dbo].[BE_Order2Cabinet] as BE_Order2Cabinet with(nolock)
                                left join[BE_OrderDetail] as BE_OrderDetail with(nolock)
                                on BE_Order2Cabinet.CabinetID = BE_OrderDetail.CabinetID
                                left join[dbo].[BE_OrderWorkFlow] as BE_OrderWorkFlow
                                on BE_OrderDetail.ItemID=BE_OrderWorkFlow.ItemID
                            where BE_OrderDetail.CabinetID='{0}'
                            and WorkFlowNo = 4 and MadeQty = 1", CabinetID);
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        /// <summary>
        /// 改单|消单处理
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Opration">CabinetStatus-N 正常  U申请改单  C申请消单 D产品已取消或已删除</param>
        /// <param name="sender"></param>
        /// <returns></returns>
        public int UpdateCabinetStatus(Order2Cabinet obj, OprationType Opration, Sender sender)
        {
            string sql = string.Empty;

            #region 改单
            if (Opration == OprationType.applyUpdate)
            {
                sql = @"UPDATE    [BE_Order2Cabinet] SET   [ReviewedStatus]='U',applyCount=applyCount+1  WHERE [CabinetID]=@CabinetID and OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

                SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
                pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pCabinetID);

                SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
                pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pOrderID);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Order2CabinetLog Model = new Order2CabinetLog()
                    {
                        LogID = Guid.NewGuid(),
                        StartedBy = sender.UserName,
                        Started = DateTime.Now,
                        Action = "提交改单申请",
                        OrderID = obj.OrderID,
                        CabinetID = obj.CabinetID,
                        OldSize = obj.Size,
                        OldMaterialStyle = obj.MaterialStyle,
                        OldColor = obj.Color,
                        ActionType = 1,
                    };
                    return InsertOrder2CabinetLog(Model);
                }
            }
            else if (Opration == OprationType.allowUpdate)
            {
                Order2CabinetLog Model = LoadOrder2CabinetLog(obj.CabinetID).Where(t => t.IsFinish == false).FirstOrDefault();

                Order2Cabinet Cabinet = LoadOrder2CabinetsByCabinetID(obj.CabinetID).FirstOrDefault();

                sql = @"UPDATE    [BE_Order2Cabinet] SET [Size]=@OldSize, [MaterialStyle]=@OldMaterialStyle, [Color]=@OldColor, [ReviewedStatus]='N'
 				         WHERE [CabinetID]=@CabinetID and OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

                SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
                pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pCabinetID);

                SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
                pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pOrderID);

                SqlParameter pOldSize = new SqlParameter("OldSize", Convert2DBnull(Model.OldSize));
                pOldSize.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(pOldSize);

                SqlParameter pMaterialStyle = new SqlParameter("OldMaterialStyle", Convert2DBnull(Model.OldMaterialStyle));
                pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(pMaterialStyle);

                SqlParameter pColor = new SqlParameter("OldColor", Convert2DBnull(Model.OldColor));
                pColor.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(pColor);

                if (cmd.ExecuteNonQuery() > 0)
                {

                    Order2CabinetLog ModelLog = new Order2CabinetLog()
                    {
                        EndedBy = sender.UserName,
                        Ended = DateTime.Now,
                        Remark = "审核通过",
                        CabinetID = obj.CabinetID,
                        OrderID = obj.OrderID,
                        OldSize = Cabinet.Size,
                        OldColor = Cabinet.Color,
                        OldMaterialStyle = Cabinet.MaterialStyle,
                    };
                    //UpdateOrder2CabinetLogByOldSize(ModelLog);
                    return UpdateOrder2CabinetLog(ModelLog);
                }
            }
            else if (Opration == OprationType.cancelUpdate)
            {
                sql = @"UPDATE    [BE_Order2Cabinet] SET [ReviewedStatus]='N'  WHERE [CabinetID]=@CabinetID and OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

                SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
                pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pCabinetID);

                SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
                pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pOrderID);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Order2CabinetLog Model = new Order2CabinetLog()
                    {
                        EndedBy = sender.UserName,
                        Ended = DateTime.Now,
                        Remark = "审核未通过",
                        CabinetID = obj.CabinetID,
                        OrderID = obj.OrderID,
                    };
                    return UpdateOrder2CabinetLog(Model);
                }
            }
            #endregion

            #region 消单
            else if (Opration == OprationType.applyDelete)
            {
                sql = @"UPDATE    [BE_Order2Cabinet] SET   [ReviewedStatus]='C',applyCount=applyCount+1  WHERE [CabinetID]=@CabinetID and OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

                SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
                pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pCabinetID);

                SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
                pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pOrderID);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Order2CabinetLog Model = new Order2CabinetLog()
                    {
                        LogID = Guid.NewGuid(),
                        StartedBy = sender.UserName,
                        Started = DateTime.Now,
                        Action = "提交消单申请",
                        OrderID = obj.OrderID,
                        CabinetID = obj.CabinetID,
                        ActionType = -1,
                    };
                    return InsertOrder2CabinetLog(Model);
                }

            }
            else if (Opration == OprationType.allowDelete)
            {
                sql = @"UPDATE    [BE_Order2Cabinet] SET   [ReviewedStatus]='D' WHERE [CabinetID]=@CabinetID and OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

                SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
                pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pCabinetID);

                SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
                pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pOrderID);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    List<OrderDetail> list = LoadOrderDetailsByCabinetID(obj.CabinetID).Where(t => t.OrderID == obj.OrderID).ToList();
                    foreach (OrderDetail Item in list)
                    {
                        DeleteOrderMadeStatesByItemID(Item.OrderID, Item.CabinetID, Item.ItemID);
                        DeleteOrderWorkFlowsByItemID(Item.OrderID, Item.ItemID);
                    }
                    Order2CabinetLog Model = new Order2CabinetLog()
                    {
                        EndedBy = sender.UserName,
                        Ended = DateTime.Now,
                        Remark = "审核通过",
                        CabinetID = obj.CabinetID,
                        OrderID = obj.OrderID,
                    };

                    //订单下所有产品已消单时，订单状态为已取消
                    var listInfo1 = LoadOrder2CabinetsByOrderID(Model.OrderID).Where(t => t.CabinetID != obj.CabinetID).ToList();
                    var listInfo2 = listInfo1.Count == 0 ? 0 : listInfo1.Where(t => t.CabinetStatus == "D").Count();
                    if (listInfo1.Count == listInfo2)
                    {
                        //Order order = LoadOrdersByOrderID(Model.OrderID).FirstOrDefault();
                        //OrderStep ts = new OrderStep()
                        //{
                        //    StepID = Guid.NewGuid(),
                        //    OrderID = Model.OrderID,
                        //    StepNo = order.StepNo++,
                        //    StepName = "已取消",
                        //    Action = "已取消",
                        //    TargetStep = "已取消",
                        //    Started = DateTime.Now,
                        //    StartedBy = sender.UserCode + "." + sender.UserName,
                        //    Ended = DateTime.Now,
                        //    EndedBy = sender.UserCode + "." + sender.UserName,
                        //    Remark = "订单下所有产品已消单",
                        //    RemarkType = "已取消订单",
                        //};
                        //InsertOrderStep(ts);
                        //UpdateOrderStatusByOrderID(Model.OrderID, "C");
                    }
                    return UpdateOrder2CabinetLog(Model);
                }
            }
            else if (Opration == OprationType.cancelDelete)
            {
                sql = @"UPDATE    [BE_Order2Cabinet] SET [ReviewedStatus]='N'  WHERE [CabinetID]=@CabinetID and OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

                SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
                pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pCabinetID);

                SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
                pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(pOrderID);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Order2CabinetLog Model = new Order2CabinetLog()
                    {
                        EndedBy = sender.UserName,
                        Ended = DateTime.Now,
                        Remark = "审核未通过",
                        CabinetID = obj.CabinetID,
                        OrderID = obj.OrderID,
                    };
                    return UpdateOrder2CabinetLog(Model);
                }

            }
            #endregion

            return -1;
        }
        #region BE_Order2CabinetLog InsertObject()
        public int InsertOrder2CabinetLog(Order2CabinetLog obj)
        {
            string sql = @"INSERT INTO [BE_Order2CabinetLog]([LogID]
				, [OrderID]
                , [CabinetID]
				, [Action]
                , [ActionType]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [Remark]
                , [OldSize]
                , [OldColor]
                , [OldMaterialStyle]
				) VALUES(@LogID
				, @OrderID
                , @CabinetID
				, @Action
                , @ActionType
				, @StartedBy
				, @Started
				, @EndedBy
				, @Ended
				, @Remark
                , @OldSize
                , @OldColor
                , @OldMaterialStyle
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", Convert2DBnull(obj.LogID));
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pActionType = new SqlParameter("ActionType", Convert2DBnull(obj.ActionType));
            pActionType.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pActionType);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", obj.EndedBy == null ? "" : obj.EndedBy);
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pRemark = new SqlParameter("Remark", obj.Remark == null ? "" : obj.Remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pOldSize = new SqlParameter("OldSize", Convert2DBnull(obj.OldSize));
            pOldSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOldSize);

            SqlParameter pOldColor = new SqlParameter("OldColor", Convert2DBnull(obj.OldColor));
            pOldColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOldColor);

            SqlParameter pOldMaterialStyle = new SqlParameter("OldMaterialStyle", Convert2DBnull(obj.OldMaterialStyle));
            pOldMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOldMaterialStyle);

            return cmd.ExecuteNonQuery();
        }

        public int UpdateOrder2CabinetLogByOldSize(Order2CabinetLog obj)
        {
            string sql = @"UPDATE [BE_Order2CabinetLog] SET  [OldSize]=@OldSize, [OldColor]=@OldColor, [OldMaterialStyle]=@OldMaterialStyle 
                           WHERE [CabinetID]=@CabinetID and [IsFinish]=0 and OrderID=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOldSize = new SqlParameter("OldSize", Convert2DBnull(obj.OldSize));
            pOldSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOldSize);

            SqlParameter pOldColor = new SqlParameter("OldColor", Convert2DBnull(obj.OldColor));
            pOldColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOldColor);

            SqlParameter pOldMaterialStyle = new SqlParameter("OldMaterialStyle", Convert2DBnull(obj.OldMaterialStyle));
            pOldMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOldMaterialStyle);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }

        public int UpdateOrder2CabinetLog(Order2CabinetLog obj)
        {
            string sql = @"UPDATE [BE_Order2CabinetLog] SET 
				                      [EndedBy]=@EndedBy
				                    , [Ended]=@Ended
				                    , [Remark]=@Remark
                                    , [IsFinish]=1
 				        WHERE [CabinetID]=@CabinetID and [IsFinish]=0 and OrderID=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", Convert2DBnull(obj.EndedBy));
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }

        public List<Order2CabinetLog> LoadOrder2CabinetLog(Guid CabinetID)
        {
            string sql = @"SELECT  [LogID]
                                  ,[OrderID]
                                  ,[CabinetID]
                                  ,[Action]
                                  ,[StartedBy]
                                  ,[Started]
                                  ,[EndedBy]
                                  ,[Ended]
                                  ,[Remark]
                                  ,[OldSize]
                                  ,[OldColor]
                                  ,[OldMaterialStyle]
                                  ,[IsFinish]
                                  ,[ActionType]
                              FROM [dbo].[BE_Order2CabinetLog] where CabinetID=@CabinetID Order by [Started] desc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Order2CabinetLog> ret = new List<Order2CabinetLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2CabinetLog iret = new Order2CabinetLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.Action = dr["Action"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.OldSize = dr["OldSize"].ToString();
                    iret.OldColor = dr["OldColor"].ToString();
                    iret.OldMaterialStyle = dr["OldMaterialStyle"].ToString();
                    iret.IsFinish = (bool)dr["IsFinish"];
                    iret.ActionType = (int)dr["ActionType"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        /// <summary>
        /// 改单审核
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public SearchResult SearchOrder2CabinetLogs(SearchOrder2CabinetArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = " [IsFinish] asc,[Started] desc";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT	   [BE_Order2CabinetLog].[CabinetID]
                                              ,[BE_Order2CabinetLog].[OrderID]
											  ,[StartedBy]
											  ,[Started]
											  ,[EndedBy]
											  ,[Ended]
											  ,[BE_Order2CabinetLog].[Remark]
											  ,[Action]
                                              ,[ActionType]
											  ,[IsFinish]
											  ,[OrderNo]
                                              ,[CabinetName]
                                              ,[Size]
                                              ,[MaterialStyle]
                                              ,[Color]
	                                          ,[CabinetStatus]
                                              ,[OldSize]
                                              ,[OldColor]
                                              ,[OldMaterialStyle]
                                              ,[OutOrderNo]
                                              ,[Status]
                                          FROM [dbo].[BE_Order2CabinetLog] AS [BE_Order2CabinetLog] WITH(NOLOCK)
                                          LEFT JOIN [dbo].[BE_Order2Cabinet] AS [BE_Order2Cabinet] WITH(NOLOCK)
                                          ON [BE_Order2CabinetLog].CabinetID=[BE_Order2Cabinet].[CabinetID]
										  LEFT JOIN [dbo].[BE_Order] AS [BE_Order] WITH(NOLOCK)
										  ON [BE_Order2Cabinet].[OrderID]=[BE_Order].[OrderID] where 1=1");

            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                mbBuilder.AppendFormat(string.Format(" and OrderNo='{0}'", args.OrderNo));
            }

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
        public int DeleteOrderWorkFlowByItemID_WorkFlowNo(Guid itemID, int workFlowNo)
        {
            string sql = @"DELETE [BE_OrderWorkFlow] WHERE [ItemID]=@ItemID AND [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", workFlowNo);
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowByItemID_SourceWorkFlowID(Guid itemID, Guid sourceWorkFlowID)
        {
            string sql = @"DELETE [BE_OrderWorkFlow] WHERE [ItemID]=@ItemID AND [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", sourceWorkFlowID);
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowByItemID_TargetWorkFlowID(Guid itemID, Guid targetWorkFlowID)
        {
            string sql = @"DELETE [BE_OrderWorkFlow] WHERE [ItemID]=@ItemID AND [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", targetWorkFlowID);
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowByWorkingID(Guid workingID)
        {
            string sql = @"DELETE [BE_OrderWorkFlow] WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", workingID);
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrderWorkFlowByItemID_WorkFlowNo(OrderWorkFlow obj)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
 				FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [ItemID]=@ItemID AND [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", Convert2DBnull(obj.WorkFlowNo));
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        obj.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        obj.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        obj.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    obj.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        obj.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        obj.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        obj.MadeQty = (int)dr["MadeQty"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadOrderWorkFlowByItemID_SourceWorkFlowID(OrderWorkFlow obj)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
 				FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [ItemID]=@ItemID AND [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", Convert2DBnull(obj.SourceWorkFlowID));
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        obj.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        obj.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        obj.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    obj.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        obj.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        obj.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        obj.MadeQty = (int)dr["MadeQty"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadOrderWorkFlowByItemID_TargetWorkFlowID(OrderWorkFlow obj)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
 				FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [ItemID]=@ItemID AND [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", Convert2DBnull(obj.TargetWorkFlowID));
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        obj.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        obj.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        obj.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    obj.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        obj.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        obj.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        obj.MadeQty = (int)dr["MadeQty"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadOrderWorkFlowByWorkingID(OrderWorkFlow obj)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
 				FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", Convert2DBnull(obj.WorkingID));
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        obj.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        obj.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        obj.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    obj.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        obj.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        obj.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        obj.MadeQty = (int)dr["MadeQty"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        #endregion

        #region BE_OrderWorkFlow CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrderWorkFlows()
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByWorkingID(Guid workingID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", workingID);
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByWorkFlowNo(int workFlowNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", workFlowNo);
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsBySourceWorkFlowID(Guid sourceWorkFlowID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", sourceWorkFlowID);
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByAction(string action)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByTargetWorkFlowID(Guid targetWorkFlowID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", targetWorkFlowID);
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByTotalQty(int totalQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderWorkFlowsByMadeQty(int madeQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [MadeQty]=@MadeQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", madeQty);
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrderWorkFlows()
        {
            string sql = "SELECT TOP 1 * FROM [BE_OrderWorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByWorkingID(Guid workingID)
        {
            string sql = "SELECT TOP 1 [WorkingID] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", workingID);
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByWorkFlowNo(int workFlowNo)
        {
            string sql = "SELECT TOP 1 [WorkFlowNo] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", workFlowNo);
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsBySourceWorkFlowID(Guid sourceWorkFlowID)
        {
            string sql = "SELECT TOP 1 [SourceWorkFlowID] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", sourceWorkFlowID);
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByAction(string action)
        {
            string sql = "SELECT TOP 1 [Action] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByTargetWorkFlowID(Guid targetWorkFlowID)
        {
            string sql = "SELECT TOP 1 [TargetWorkFlowID] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", targetWorkFlowID);
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByTotalQty(int totalQty)
        {
            string sql = "SELECT TOP 1 [TotalQty] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderWorkFlowsByMadeQty(int madeQty)
        {
            string sql = "SELECT TOP 1 [MadeQty] FROM [BE_OrderWorkFlow] WITH(NOLOCK) WHERE [MadeQty]=@MadeQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", madeQty);
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrderWorkFlows()
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByWorkingID(Guid workingID)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", workingID);
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByWorkFlowNo(int workFlowNo)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", workFlowNo);
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsBySourceWorkFlowID(Guid sourceWorkFlowID)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", sourceWorkFlowID);
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByAction(string action)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByTargetWorkFlowID(Guid targetWorkFlowID)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", targetWorkFlowID);
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByTotalQty(int totalQty)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderWorkFlowsByMadeQty(int madeQty)
        {
            string sql = "DELETE FROM [BE_OrderWorkFlow] WHERE [MadeQty]=@MadeQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", madeQty);
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            return cmd.ExecuteNonQuery();
        }
        public List<OrderWorkFlow> LoadOrderWorkFlows()
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByWorkingID(Guid workingID)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [WorkingID]=@WorkingID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkingID = new SqlParameter("WorkingID", workingID);
            pWorkingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkingID);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByItemID(Guid itemID)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByWorkFlowNo(int workFlowNo)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [WorkFlowNo]=@WorkFlowNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowNo = new SqlParameter("WorkFlowNo", workFlowNo);
            pWorkFlowNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWorkFlowNo);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsBySourceWorkFlowID(Guid sourceWorkFlowID)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [SourceWorkFlowID]=@SourceWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceWorkFlowID = new SqlParameter("SourceWorkFlowID", sourceWorkFlowID);
            pSourceWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceWorkFlowID);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByAction(string action)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByTargetWorkFlowID(Guid targetWorkFlowID)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [TargetWorkFlowID]=@TargetWorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetWorkFlowID = new SqlParameter("TargetWorkFlowID", targetWorkFlowID);
            pTargetWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTargetWorkFlowID);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByTotalQty(int totalQty)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [TotalQty]=@TotalQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalQty = new SqlParameter("TotalQty", totalQty);
            pTotalQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalQty);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderWorkFlow> LoadOrderWorkFlowsByMadeQty(int madeQty)
        {
            string sql = @"SELECT [WorkingID]
				, [OrderID]
				, [ItemID]
				, [WorkFlowNo]
				, [SourceWorkFlowID]
				, [Action]
				, [TargetWorkFlowID]
				, [TotalQty]
				, [MadeQty]
				 FROM [BE_OrderWorkFlow] WHERE [MadeQty]=@MadeQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeQty = new SqlParameter("MadeQty", madeQty);
            pMadeQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMadeQty);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        #endregion

        #region BE_OrderWorkFlow SearchObject()
        public SearchResult SearchOrderWorkFlow(SearchOrderWorkFlowArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderID],[CabinetID]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [WorkingID]                                           
                                          ,[BE_OrderWorkFlow].[OrderID]
                                          ,[BE_Order].[OrderNo]
                                          ,[BE_OrderDetail].[CabinetID]
                                          ,[BE_Order2Cabinet].[CabinetName]
                                          ,[BE_OrderWorkFlow].[ItemID]
										  ,[BE_OrderDetail].[ItemName]
										  ,[BE_OrderDetail].[BarcodeNo] as Barcode
										  ,[BE_OrderDetail].[MadeLength]
										  ,[BE_OrderDetail].[MadeWidth]
										  ,[BE_OrderDetail].[MadeHeight]
                                          ,[WorkFlowNo]
                                          ,[SourceWorkFlowID]
	                                      ,[SourceWorkFlow].[WorkFlowCode] as [SourceWorkFlowCode]
	                                      ,[SourceWorkFlow].[WorkFlowName] as [SourceWorkFlowName]
                                          ,[Action]
                                          ,[TargetWorkFlowID]
	                                      ,[DestWorkFlow].[WorkFlowCode] as [TargetWorkFlowCode]
	                                      ,[DestWorkFlow].[WorkFlowName] as [TargetWorkFlowName]
                                          ,[TotalQty]
                                          ,[MadeQty]
	                                      ,((MadeLength * MadeWidth)/1000000) * [BE_OrderDetail].[Qty] as TotalAreal
	                                      ,((MadeLength + MadeWidth) *2 /1000) * [BE_OrderDetail].[Qty] as TotalLength	 
										  ,((MadeLength * MadeWidth)/1000000) * [MadeQty] as TotalMadeAreal
	                                      ,((MadeLength + MadeWidth) *2 /1000) * [MadeQty] as TotalMadeLength 
                                      FROM 
		                                    [BE_OrderWorkFlow] with(nolock)
		                                    LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_OrderWorkFlow].[ItemID] = [BE_OrderDetail].[ItemID]	    
		                                    LEFT JOIN [BE_WorkFlow] as [SourceWorkFlow] with(nolock) on [SourceWorkFlow].[WorkFlowID] = [BE_OrderWorkFlow].[SourceWorkFlowID]
		                                    LEFT JOIN [BE_WorkFlow] as [DestWorkFlow] with(nolock) on [DestWorkFlow].[WorkFlowID] = [BE_OrderWorkFlow].[TargetWorkFlowID]
                                            LEFT JOIN [BE_Order] with(nolock) on [BE_Order].[OrderID] = [BE_OrderWorkFlow].[OrderID]
                                            LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_Order2Cabinet].[CabinetID] = [BE_OrderDetail].[CabinetID]
                                    where	                                                                        
	                                    [TargetWorkFlowID] !='00000000-0000-0000-0000-000000000000'");
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderWorkFlow].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (args.ItemID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderWorkFlow].[ItemID", "mbItemID", args.ItemID.Value);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderDetail].[CabinetID", "mbCabinetID", args.CabinetID.Value);
            }
            if (args.WorkFlowID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderWorkFlow].[SourceWorkFlowID", "mbWorkFlowID", args.WorkFlowID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SourceWorkFlow].[WorkFlowCode", "mbWorkFlowCode", args.WorkFlowCode);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SourceWorkFlow].[WorkFlowName", "mbWorkFlowName", args.WorkFlowName);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (args.ScanFlag.HasValue)
            {
                if (args.ScanFlag.Value)
                {
                    mbBuilder.AppendFormat(" AND ([TotalQty]-[MadeQty]) == 0");
                }
                else
                {
                    mbBuilder.AppendFormat(" AND ([TotalQty]-[MadeQty]) > 0");
                }
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public SearchResult SearchPrintListByOrderWorkFlow(SearchOrderWorkFlowArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderID],[CabinetID]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT		
                                        [BE_OrderWorkFlow].[WorkingID]                                           
                                        ,[BE_OrderWorkFlow].[OrderID]
                                        ,[BE_Order].[OrderNo]
                                        ,[BE_Order].[OutOrderNo]
                                        ,[BE_OrderDetail].[CabinetID]
                                        ,[BE_Order2Cabinet].[CabinetName]
			                            ,[BE_OrderDetail].[BarcodeNo] as Barcode
			                            ,[BE_Order2Cabinet].[Size]
			                            ,[BE_Order2Cabinet].[MaterialStyle]
                                        ,[BE_OrderWorkFlow].[WorkFlowNo]
                                        ,[BE_OrderWorkFlow].[ItemID]
                                        ,[BE_OrderWorkFlow].[SourceWorkFlowID]
	                                    ,[SourceWorkFlow].[WorkFlowCode] as [SourceWorkFlowCode]
	                                    ,[SourceWorkFlow].[WorkFlowName] as [SourceWorkFlowName]
			                            ,[BE_OrderWorkFlow].[PrintCount]
			                            ,[BE_OrderWorkFlow].[PrintDate],[BE_Order].Created
                                        ,[CustomerName]
                                        ,[PartnerOutCode]
                                        ,[PartnerName]
                                        ,[GroupNumber]
                                        ,[ProductNumber]
										,[ItemName]
										,[ItemGroup]
										,[ItemType]
										,[MaterialType]
										,[PackageSizeType]
										,[PackageCategory]
										,[BarcodeNo]
                                        ,[BE_OrderDetail].[MadeWidth]
                                        ,[BE_OrderDetail].[MadeHeight]
                                        ,[BE_OrderDetail].[MadeLength]
                                        ,[BE_OrderDetail].[EndWidth]
                                        ,[BE_OrderDetail].[EndLength]
                                FROM 
		                                [BE_OrderWorkFlow] with(nolock)
		                                LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_OrderWorkFlow].[ItemID] = [BE_OrderDetail].[ItemID]	    
		                                LEFT JOIN [BE_WorkFlow] as [SourceWorkFlow] with(nolock) on [SourceWorkFlow].[WorkFlowID] = [BE_OrderWorkFlow].[SourceWorkFlowID]
                                        LEFT JOIN [BE_Order] with(nolock) on [BE_Order].[OrderID] = [BE_OrderWorkFlow].[OrderID]
                                        LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_Order2Cabinet].[CabinetID] = [BE_OrderDetail].[CabinetID]
                                        LEFT JOIN [dbo].[BE_Partner]  with(nolock) on [BE_Partner].PartnerID=[BE_Order].PartnerID
                            where 1=1 and [BE_OrderWorkFlow].[WorkFlowNo] in(1,7) and ([BE_Order].[OrderNo]='{0}' or [BE_Order].[OutOrderNo]='{0}')", args.OrderNo);
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderWorkFlow].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (!string.IsNullOrEmpty(args.PrintCount))
            {
                this.SetParameters_Between(mbBuilder, cmd, "BE_OrderWorkFlow].[PrintCount", "mbPrintCount", int.Parse(args.PrintCount), int.Parse(args.PrintCount) > 0 ? 999 : 0);
            }
            //if (!string.IsNullOrEmpty(args.OrderNo))
            //{
            //    this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            //}
            if (!string.IsNullOrEmpty(args.RolesTemp))
            {
                mbBuilder.AppendFormat(" and charindex([SourceWorkFlow].[WorkFlowName],'" + args.RolesTemp + "')>0");
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql ", mbBuilder.ToString());
            args.OrderBy = " Created desc,ItemID desc,WorkFlowNo asc ";
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public SearchResult SearchScanListByOrderWorkFlow(SearchOrderWorkFlowArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderID],[CabinetID]";
            }
            //string sql = string.Empty;
            //if (role.Count > 0)
            //{
            //    sql += "LEFT JOIN (";
            //    for (int i = 0; i < role.Count; i++)
            //    {
            //        sql += string.Format(@"SELECT [WorkingID]  FROM [dbo].[BE_OrderWorkFlow] where [Action]='{0}'", role[i].RoleName);
            //        if (i != role.Count - 1) sql += " union all ";
            //    }
            //    sql += ") [BE_OrderWorkFlowByID] ON [BE_OrderWorkFlowByID].WorkingID=[BE_OrderWorkFlow].WorkingID";
            //}

            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT		
                                        [BE_OrderWorkFlow].[WorkingID]                                           
                                        ,[BE_OrderWorkFlow].[OrderID]
                                        ,[BE_Order].[OrderNo]
                                        ,[BE_Order].[OutOrderNo]
                                        ,[BE_OrderDetail].[CabinetID]
                                        ,[BE_Order2Cabinet].[CabinetName]
			                            ,[BE_OrderDetail].[BarcodeNo] as Barcode
			                            ,[BE_Order2Cabinet].[Size]
                                        ,[BE_Order2Cabinet].[Color]
                                        ,[BE_Order2Cabinet].[MaterialStyle]
                                        ,[BE_OrderWorkFlow].[WorkFlowNo]
                                        ,[BE_OrderWorkFlow].[ItemID]
                                        ,[BE_OrderWorkFlow].[SourceWorkFlowID]
	                                    ,[SourceWorkFlow].[WorkFlowCode] as [SourceWorkFlowCode]
	                                    ,[SourceWorkFlow].[WorkFlowName] as [SourceWorkFlowName]
			                            ,[BE_OrderWorkFlow].[PrintCount]
			                            ,[BE_OrderWorkFlow].[PrintDate],[BE_Order].Created
                                        ,[CustomerName]
                                        ,[PartnerOutCode]
                                        ,[PartnerName]
                                        ,[Processed]
                                        ,[GroupNumber]
                                        ,[ProductNumber]
										,[ItemName]
										,[ItemGroup]
										,[ItemType]
										,[MaterialType]
										,[PackageSizeType]
										,[PackageCategory]
										,[BarcodeNo]
                                        ,[BE_OrderDetail].[MadeWidth]
                                        ,[BE_OrderDetail].[MadeHeight]
                                        ,[BE_OrderDetail].[MadeLength]
                                        ,[BE_OrderDetail].[EndWidth]
                                        ,[BE_OrderDetail].[EndLength]
                                FROM 
		                                [BE_OrderWorkFlow] with(nolock)
		                                LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_OrderWorkFlow].[ItemID] = [BE_OrderDetail].[ItemID]	    
		                                LEFT JOIN [BE_WorkFlow] as [SourceWorkFlow] with(nolock) on [SourceWorkFlow].[WorkFlowID] = [BE_OrderWorkFlow].[SourceWorkFlowID]
                                        LEFT JOIN [BE_Order] with(nolock) on [BE_Order].[OrderID] = [BE_OrderWorkFlow].[OrderID]
                                        LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_Order2Cabinet].[CabinetID] = [BE_OrderDetail].[CabinetID]
                                        LEFT JOIN [dbo].[BE_Partner]  with(nolock) on [BE_Partner].PartnerID=[BE_Order].PartnerID
                                        LEFT JOIN [dbo].[BE_OrderMadeState]  with(nolock) on [BE_OrderWorkFlow].WorkingID=[BE_OrderMadeState].WorkFlowID
                            where 1=1  ");



            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderWorkFlow].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (!string.IsNullOrEmpty(args.MadeQty))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderWorkFlow].[MadeQty", "mbMadeQty", int.Parse(args.MadeQty));
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.RolesTemp))
            {
                mbBuilder.AppendFormat(" and charindex([BE_OrderWorkFlow].[Action],'" + args.RolesTemp + "')>0");
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql ", mbBuilder.ToString());
            args.OrderBy = " Created desc,ItemID desc,WorkFlowNo asc ";
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public List<OrderWorkFlow> LoadOrderWorkFlowsBySearchKey(string SearchKey)
        {
            string sql = @"SELECT  [WorkingID]
                                  ,[BE_OrderWorkFlow].[OrderID]
                                  ,[BE_OrderWorkFlow].[ItemID]
                                  ,[WorkFlowNo]
                                  ,[SourceWorkFlowID]
                                  ,[Action]
                                  ,[TargetWorkFlowID]
                                  ,[TotalQty]
                                  ,[MadeQty]
                                  ,[ScanType]
                                  ,[PrintCount]
                                  ,[PrintDate]
                          FROM [dbo].[BE_OrderWorkFlow] AS [BE_OrderWorkFlow]
                          LEFT JOIN [BE_Order] AS [BE_Order]
                          ON [BE_OrderWorkFlow].OrderID=[BE_Order].OrderID
                          LEFT JOIN [BE_OrderDetail] AS [BE_OrderDetail]
                          ON [BE_OrderDetail].ItemID=[BE_OrderWorkFlow].ItemID
                          WHERE ([BE_OrderDetail].BarcodeNo=@SearchKey OR  [BE_Order].OrderNo=@SearchKey OR OutOrderNo=@SearchKey)
                          order by [WorkFlowNo] asc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSearchKey = new SqlParameter("SearchKey", SearchKey);
            pSearchKey.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSearchKey);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();
                    if (!Convert.IsDBNull(dr["WorkingID"]))
                        iret.WorkingID = (Guid)dr["WorkingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];
                    if (!Convert.IsDBNull(dr["SourceWorkFlowID"]))
                        iret.SourceWorkFlowID = (Guid)dr["SourceWorkFlowID"];
                    iret.Action = dr["Action"].ToString();
                    if (!Convert.IsDBNull(dr["TargetWorkFlowID"]))
                        iret.TargetWorkFlowID = (Guid)dr["TargetWorkFlowID"];
                    if (!Convert.IsDBNull(dr["TotalQty"]))
                        iret.TotalQty = (int)dr["TotalQty"];
                    if (!Convert.IsDBNull(dr["MadeQty"]))
                        iret.MadeQty = (int)dr["MadeQty"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<OrderWorkFlow> LoadOrderWorkFlowsByProcessed(Guid ItemID)
        {
            string sql = @"SELECT	[Action] ,
                                    [BE_OrderMadeState].Processed,
                                    [WorkFlowNo]
                          FROM [dbo].[BE_OrderWorkFlow] AS [BE_OrderWorkFlow]
                          LEFT JOIN [dbo].[BE_OrderMadeState] AS [BE_OrderMadeState]
                          ON [BE_OrderWorkFlow].WorkingID=[BE_OrderMadeState].WorkFlowID
                          WHERE [BE_OrderWorkFlow].ItemID=@ItemID
                          order by [WorkFlowNo] asc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", ItemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<OrderWorkFlow> ret = new List<OrderWorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderWorkFlow iret = new OrderWorkFlow();

                    if (!Convert.IsDBNull(dr["WorkFlowNo"]))
                        iret.WorkFlowNo = (int)dr["WorkFlowNo"];

                    iret.Action = dr["Action"].ToString();

                    if (!Convert.IsDBNull(dr["Processed"]))
                        iret.Processed = ((DateTime)dr["Processed"]).ToString("MM-dd HH:mm");

                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int UpdateOrderWorkFlowByPrintCount(Guid WorkingID, Guid OrderID)
        {
            StringBuilder mbBuilder = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            mbBuilder.Append(@"UPDATE [BE_OrderWorkFlow] SET [PrintCount] =PrintCount+1,[PrintDate]=getdate()");
            mbBuilder.Append(" WHERE 1=1 ");

            this.SetParameters_Equals(mbBuilder, cmd, "WorkingID", "mbWorkingIDs", WorkingID);
            this.SetParameters_Equals(mbBuilder, cmd, "OrderID", "mbOrderIDs", OrderID);

            cmd.CommandText = mbBuilder.ToString();
            cmd.Connection = this.conn;
            cmd.Transaction = this.trans;
            return cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
