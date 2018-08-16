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
        
        #region BE_ProductionOrder InsertObject()
        public int InsertProductionOrder(ProductionOrder obj)
        {
            string sql = @"Insert Into [BE_ProductionOrder](
                              [ProductionID]
                             ,[ProduceNo]
                             ,[OrderID]
                             ,[OrderNo]
                             ,[FinishDate]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Status]
            )Values (
                              @ProductionID
                             ,@ProduceNo
                             ,@OrderID
                             ,@OrderNo
                             ,@FinishDate
                             ,@Created
                             ,@CreatedBy
                             ,@Status
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pProduceNo = new SqlParameter("ProduceNo", Convert2DBnull(obj.ProduceNo));
            pProduceNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProduceNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pOrderNo = new SqlParameter("OrderNo", Convert2DBnull(obj.OrderNo));
            pOrderNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOrderNo);

            SqlParameter pFinishDate = new SqlParameter("FinishDate", Convert2DBnull(obj.FinishDate));
            pFinishDate.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pFinishDate);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionOrder UpdateObject()、DeleteObject()
        public int UpdateProductionOrderByProductionID(ProductionOrder obj)
        {
            string sql = @"Update [BE_ProductionOrder] Set
                              [ProduceNo]=@ProduceNo
                             ,[OrderID]=@OrderID
                             ,[OrderNo]=@OrderNo
                             ,[FinishDate]=@FinishDate
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                             ,[Status]=@Status
                          Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pProduceNo = new SqlParameter("ProduceNo", Convert2DBnull(obj.ProduceNo));
            pProduceNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProduceNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pOrderNo = new SqlParameter("OrderNo", Convert2DBnull(obj.OrderNo));
            pOrderNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOrderNo);

            SqlParameter pFinishDate = new SqlParameter("FinishDate", Convert2DBnull(obj.FinishDate));
            pFinishDate.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pFinishDate);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductionOrderByProductionID(Guid ProductionID)
        {
            string sql = @"Delete [BE_ProductionOrder]  Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionOrder LoadObject()
        public List<ProductionOrder> LoadProductionOrders()
        {
            string sql = @"Select 
                              [ProductionID]
                             ,[ProduceNo]
                             ,[OrderID]
                             ,[OrderNo]
                             ,[FinishDate]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionOrder] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductionOrder> ret = new List<ProductionOrder>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionOrder iret = new ProductionOrder();
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ProduceNo"]))
                        iret.ProduceNo = (string)dr["ProduceNo"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["OrderNo"]))
                        iret.OrderNo = (string)dr["OrderNo"];
                    if (!Convert.IsDBNull(dr["FinishDate"]))
                        iret.FinishDate = (DateTime)dr["FinishDate"];
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

        public List<ProductionOrder> LoadProductionOrderByProductionID(ProductionOrder obj)
        {
            string sql = @"Select 
                              [ProductionID]
                             ,[ProduceNo]
                             ,[OrderID]
                             ,[OrderNo]
                             ,[FinishDate]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionOrder] With(NoLock) Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            List<ProductionOrder> ret = new List<ProductionOrder>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionOrder iret = new ProductionOrder();
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ProduceNo"]))
                        iret.ProduceNo = (string)dr["ProduceNo"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["OrderNo"]))
                        iret.OrderNo = (string)dr["OrderNo"];
                    if (!Convert.IsDBNull(dr["FinishDate"]))
                        iret.FinishDate = (DateTime)dr["FinishDate"];
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

        public int LoadProductionOrder(ProductionOrder obj)
        {
            string sql = @"Select 
                              [ProductionID]
                             ,[ProduceNo]
                             ,[OrderID]
                             ,[OrderNo]
                             ,[FinishDate]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Status]
                       From [BE_ProductionOrder] With(NoLock) Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        obj.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ProduceNo"]))
                        obj.ProduceNo = (string)dr["ProduceNo"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["OrderNo"]))
                        obj.OrderNo = (string)dr["OrderNo"];
                    if (!Convert.IsDBNull(dr["FinishDate"]))
                        obj.FinishDate = (DateTime)dr["FinishDate"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (string)dr["Status"];
                    
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

        #region BE_ProductionOrder CountObjects()、ExistsObjects()
        public int CountProductionOrder()
        {
            string sql = @"Select Count(*) From [BE_ProductionOrder] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductionOrderProductionID(Guid ProductionID)
        {
            string sql = @"Select Count(*) From [BE_ProductionOrder]  Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductionOrder()
        {
            string sql = @"Select Top 1 * From [BE_ProductionOrder] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductionOrderProductionID(Guid ProductionID)
        {
            string sql = @"Select Top 1 * From [BE_ProductionOrder]  Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region BE_ProductionOrder SearchObject()
        public SearchResult SearchProductionOrder(SearchProductionOrderArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ProductionID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT      [BE_Order].[OrderID]
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
		                                        ,[BE_ProductionOrder].[ProductionID]
		                                        ,[BE_ProductionOrder].[ProduceNo]
                                                ,[BE_ProductionOrder].[Created]
                                                ,[BE_ProductionOrder].[CreatedBy]
                                                ,[BE_ProductionOrder].[Status] as ProductionStatus 
		                                        ,[Quantity]
		                                        ,[Amount]
		                                        ,[BE_ProductionOrderScheduling].[Created] AS [SchedulingCreated]
		                                        ,[BE_ProductionOrderScheduling].[CreatedBy] AS [SchedulingCreatedBy]
		                                        ,[BE_ProductionSetDayDetail].[Datetime]
                                        FROM [BE_ProductionOrder]
                                        LEFT JOIN [BE_Order]  on [BE_ProductionOrder].OrderID=[BE_Order].OrderID
                                        LEFT JOIN [dbo].[BE_ProductionOrderScheduling] ON [BE_ProductionOrder].[ProductionID]=[BE_ProductionOrderScheduling].[ProductionID]
                                        LEFT JOIN [dbo].[BE_ProductionSetDayDetail] ON [BE_ProductionSetDayDetail].[ID]=[BE_ProductionOrderScheduling].[DaysDetailID]
                                        LEFT JOIN
                                        (
	                                            select OrderID,sum([Quantity]) as [Quantity],sum([Amount]) as [Amount] 
	                                            FROM [dbo].[ProductComponent] 
	                                            LEFT JOIN [dbo].[BE_OrderProduct] ON [BE_OrderProduct].[ProductCode]=[ProductComponent].[ProductCode]
	                                            WHERE  [ProductComponent].ComponentTypeID={0} Group By OrderID
                                        ) tb on [BE_Order].[OrderID] = tb.[OrderID] 
                                        WHERE 1=1 ", args.ComponentTypeID);

            //this.SetParameters_Equals(mbBuilder, cmd, "ProductComponent].[ComponentTypeID", "mbComponentTypeID", args.ComponentTypeID);

            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[CustomerID", "mbCustomerID", args.CustomerID.Value);
            }
            if (!string.IsNullOrEmpty(args.ProductionStatus))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductionOrder].[Status", "mbStatus", args.ProductionStatus);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Address", "mbAddress", args.Address);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.StepNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[StepNo", "mbStepNo", args.StepNo);
            }
            
            this.SetParameters_Between(mbBuilder, cmd, "BookingDate", "mbBookingDate", args.BookingDateFrom, args.BookingDateTo);
            this.SetParameters_Between(mbBuilder, cmd, "ShipDate", "mbBookingDate", args.ShipDateFrom, args.ShipDateTo);

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public SearchResult SearchProductComponents(Guid OrderID)
        {
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"
                                    SELECT	     [ProductComponent].[ComponentID]
                                                ,[ProductComponent].[ProductCode]
			                                    ,[ProductComponent].[ComponentTypeName]
			                                    ,[ProductComponent].[ComponentCode]
                                                ,[ProductComponent].[ComponentTypeID]
                                                ,[ProductComponent].[Quantity]
                                                ,[ProductComponent].[Amount]
                                                ,[ProductComponent].[Status]
                                                ,[ProductComponent].[Created]
                                                ,[ProductComponent].[CreatedBy]
                                                ,[ProductComponent].[Modified]
                                                ,[ProductComponent].[ModifiedBy]
			                                    ,[BE_OrderProduct].[ProductID]
			                                    ,[BE_OrderProduct].[OrderID]
			                                    ,[BE_OrderProduct].[ProductName]
                                    FROM [dbo].[ProductComponent] AS  [ProductComponent]
                                    LEFT JOIN ComponentType AS [ComponentType]
                                    ON [ProductComponent].ComponentTypeID=[ComponentType].ComponentTypeID
                                    LEFT JOIN [dbo].[BE_OrderProduct] AS [BE_OrderProduct]
                                    ON [BE_OrderProduct].[ProductCode]=[ProductComponent].[ProductCode]
                                    WHERE [ComponentType].ParentID=0");

            this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderProduct].[OrderID", "mbOrderID", OrderID);

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, "[CreatedBy]", 0, 500);
        }

        public SearchResult SearchOrderByProductionOrder(SearchOrderArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT	       [BE_Order].[OrderID]
                                                  ,[BE_Order].[CustomerID]
                                                  ,[BE_Order].[PartnerID]
                                                  ,[BE_Order].[OrderNo]
                                                  ,[BE_Order].[OutOrderNo]
                                                  ,[BE_Order].[OrderType]
										          ,[BE_Order].[PartnerName]
                                                  ,[BE_Order].[CustomerName]
                                                  ,[BE_Order].[Address]
                                                  ,[BE_Order].[Mobile]
                                                  ,[BE_Order].[BookingDate]
                                                  ,[BE_Order].[ShipDate]
                                                  ,[BE_Order].[StepNo]
                                                  ,[BE_Order].[Remark]
                                                  ,[BE_Order].[Created]
                                                  ,[BE_Order].[CreatedBy]
                                                  ,[BE_Order].[Modified]
                                                  ,[BE_Order].[ModifiedBy]
                                                  ,[BE_Order].[SalesMan]
										          ,[BE_Order].[Status]					  
                                      FROM   [BE_Order]  with(nolock)
									  LEFT JOIN [dbo].[BE_ProductionOrder] with(nolock)
									  ON [BE_Order].OrderID=[BE_ProductionOrder].OrderID   
	                                  WHERE 1=1
									  AND [BE_Order].Status='H' and [BE_ProductionOrder].OrderID  IS  NULL");

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}

