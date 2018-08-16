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
        #region BE_WorkOrder InsertObject()
        public int InsertWorkOrder(WorkOrder obj)
        {
            string sql = @"Insert Into [BE_WorkOrder](
                              [WorkOrderID]
                             ,[WorkOrderNo]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[ComponentID]
                             ,[ComponentTypeID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                              @WorkOrderID
                             ,@WorkOrderNo
                             ,@OrderID
                             ,@ProductionID
                             ,@ComponentID
                             ,@ComponentTypeID
                             ,@Status
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            SqlParameter pWorkOrderNo = new SqlParameter("WorkOrderNo", Convert2DBnull(obj.WorkOrderNo));
            pWorkOrderNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkOrderNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkOrder UpdateObject()、DeleteObject()
        public int UpdateWorkOrderByWorkOrderID(WorkOrder obj)
        {
            string sql = @"Update [BE_WorkOrder] Set
                              [WorkOrderNo]=@WorkOrderNo
                             ,[OrderID]=@OrderID
                             ,[ProductionID]=@ProductionID
                             ,[ComponentID]=@ComponentID
                             ,[ComponentTypeID]=@ComponentTypeID
                             ,[Status]=@Status
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            SqlParameter pWorkOrderNo = new SqlParameter("WorkOrderNo", Convert2DBnull(obj.WorkOrderNo));
            pWorkOrderNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkOrderNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteWorkOrderByWorkOrderID(Guid WorkOrderID)
        {
            string sql = @"Delete [BE_WorkOrder]  Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkOrder LoadObject()
        public List<WorkOrder> LoadWorkOrders()
        {
            string sql = @"Select 
                              [WorkOrderID]
                             ,[WorkOrderNo]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[ComponentID]
                             ,[ComponentTypeID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkOrder] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkOrder> ret = new List<WorkOrder>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkOrder iret = new WorkOrder();
                    if (!Convert.IsDBNull(dr["WorkOrderID"]))
                        iret.WorkOrderID = (Guid)dr["WorkOrderID"];
                    if (!Convert.IsDBNull(dr["WorkOrderNo"]))
                        iret.WorkOrderNo = (string)dr["WorkOrderNo"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (string)dr["Status"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<WorkOrder> LoadWorkOrderByWorkOrderID(WorkOrder obj)
        {
            string sql = @"Select 
                              [WorkOrderID]
                             ,[WorkOrderNo]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[ComponentID]
                             ,[ComponentTypeID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkOrder] With(NoLock) Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            List<WorkOrder> ret = new List<WorkOrder>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkOrder iret = new WorkOrder();
                    if (!Convert.IsDBNull(dr["WorkOrderID"]))
                        iret.WorkOrderID = (Guid)dr["WorkOrderID"];
                    if (!Convert.IsDBNull(dr["WorkOrderNo"]))
                        iret.WorkOrderNo = (string)dr["WorkOrderNo"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (string)dr["Status"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadWorkOrder(WorkOrder obj)
        {
            string sql = @"Select 
                              [WorkOrderID]
                             ,[WorkOrderNo]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[ComponentID]
                             ,[ComponentTypeID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkOrder] With(NoLock) Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkOrderID"]))
                        obj.WorkOrderID = (Guid)dr["WorkOrderID"];
                    if (!Convert.IsDBNull(dr["WorkOrderNo"]))
                        obj.WorkOrderNo = (string)dr["WorkOrderNo"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        obj.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        obj.ComponentID = (int)dr["ComponentID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        obj.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (string)dr["Status"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
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

        #region BE_WorkOrder CountObjects()、ExistsObjects()
        public int CountWorkOrder()
        {
            string sql = @"Select Count(*) From [BE_WorkOrder] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountWorkOrderByWorkOrderID(Guid WorkOrderID)
        {
            string sql = @"Select Count(*) From [BE_WorkOrder]  Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsWorkOrder()
        {
            string sql = @"Select Top 1 * From [BE_WorkOrder] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsWorkOrderByWorkOrderID(Guid WorkOrderID)
        {
            string sql = @"Select Top 1 * From [BE_WorkOrder]  Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region BE_WorkOrder SearchObject()
        public SearchResult SearchWorkOrder(SearchWorkOrderArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkOrderID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT  [BE_Order].[OrderID]
		                                    ,[BE_Order].[OrderNo]
		                                    ,[BE_Order].[OrderType]
		                                    ,[BE_Order].[OutOrderNo]
		                                    ,[BE_Order].[PartnerID]
		                                    ,[BE_Order].[PartnerName]
		                                    ,[BE_Order].[CustomerID]
		                                    ,[BE_Order].[CustomerName]
		                                    ,[BE_Order].[SalesMan]
		                                    ,[BE_Order].[Address]
		                                    ,[BE_Order].[Mobile]
		                                    ,[BE_Order].[BookingDate]
		                                    ,[BE_Order].[ShipDate]
		                                    ,[BE_Order].[Status]
		                                    ,[BE_Order].[StepNo]
		                                    ,[BE_ProductionOrder].[ProduceNo]
		                                    ,[BE_WorkOrder].[WorkOrderNo]
		                                    ,[BE_WorkOrder].[WorkOrderID]
                                            ,[BE_WorkOrder].[Created]
                                            ,[BE_WorkOrder].[CreatedBy]
                                            ,[BE_WorkOrder].[ComponentID]
											,[ComponentTypeName]
                                    FROM [BE_WorkOrder]
                                    LEFT JOIN [BE_ProductionOrder]  on [BE_WorkOrder].OrderID=[BE_ProductionOrder].OrderID
                                    LEFT JOIN [BE_Order]  on [BE_WorkOrder].OrderID=[BE_Order].OrderID
									LEFT JOIN [ComponentType]  on [ComponentType].[ComponentTypeID]=[BE_WorkOrder].[ComponentTypeID]
                                    WHERE 1=1 ");

            //this.SetParameters_In(mbBuilder, cmd, "BE_WorkOrder].[WorkOrderID", "mbWorkOrderID", args.WorkOrderID);

            //if (args.ProduceOrderID.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkOrder].[WorkOrderID", "mbWorkOrderID", args.WorkOrderID);
            //}
            //if (!string.IsNullOrEmpty(args.OrderNo))
            //{
            //    this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkOrder].[WorkOrderID", "mbWorkOrderID", args.WorkOrderID);
            //}
            //if (!string.IsNullOrEmpty(args.ProduceOrderID))
            //{
            //    this.SetParameters_Between(mbBuilder, cmd, "BE_WorkOrder].[WorkOrderID", "mbWorkOrderID", args.BookingDateFrom, args.BookingDateTo);
            //}
            //if (args.Ended != DateTime.MinValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkOrder].[WorkOrderID", "mbWorkOrderID", args.WorkOrderID);
            //}
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}

