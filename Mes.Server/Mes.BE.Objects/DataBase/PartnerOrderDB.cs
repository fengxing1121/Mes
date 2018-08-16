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

        #region BE_PartnerOrder InsertObject()
        public int InsertPartnerOrder(PartnerOrder obj)
        {
            string sql = @"Insert Into [BE_PartnerOrder](
                              [OrderID]
                             ,[OrderNo]
                             ,[OrderType]
                             ,[OutOrderNo]
                             ,[PartnerID]
                             ,[PartnerName]
                             ,[CustomerID]
                             ,[CustomerName]
                             ,[SalesMan]
                             ,[Address]
                             ,[Mobile]
                             ,[BookingDate]
                             ,[ShipDate]
                             ,[Status]
                             ,[StepNo]
                             ,[Remark]
                             ,[AttachmentFile]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
            )Values (
                              @OrderID
                             ,@OrderNo
                             ,@OrderType
                             ,@OutOrderNo
                             ,@PartnerID
                             ,@PartnerName
                             ,@CustomerID
                             ,@CustomerName
                             ,@SalesMan
                             ,@Address
                             ,@Mobile
                             ,@BookingDate
                             ,@ShipDate
                             ,@Status
                             ,@StepNo
                             ,@Remark
                             ,@AttachmentFile
                             ,@Created
                             ,@CreatedBy
                             ,@Modified
                             ,@ModifiedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pOrderNo = new SqlParameter("OrderNo", Convert2DBnull(obj.OrderNo));
            pOrderNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pOrderNo);

            SqlParameter pOrderType = new SqlParameter("OrderType", Convert2DBnull(obj.OrderType));
            pOrderType.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pOrderType);

            SqlParameter pOutOrderNo = new SqlParameter("OutOrderNo", Convert2DBnull(obj.OutOrderNo));
            pOutOrderNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOutOrderNo);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", Convert2DBnull(obj.PartnerName));
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", Convert2DBnull(obj.CustomerName));
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            SqlParameter pSalesMan = new SqlParameter("SalesMan", Convert2DBnull(obj.SalesMan));
            pSalesMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSalesMan);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pBookingDate = new SqlParameter("BookingDate", Convert2DBnull(obj.BookingDate));
            pBookingDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pBookingDate);

            SqlParameter pShipDate = new SqlParameter("ShipDate", Convert2DBnull(obj.ShipDate));
            pShipDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pShipDate);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pAttachmentFile = new SqlParameter("AttachmentFile", Convert2DBnull(obj.AttachmentFile));
            pAttachmentFile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAttachmentFile);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PartnerOrder UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerOrderByOrderID(PartnerOrder obj)
        {
            string sql = @"Update [BE_PartnerOrder] Set
                              [OrderNo]=@OrderNo
                             ,[OrderType]=@OrderType
                             ,[OutOrderNo]=@OutOrderNo
                             ,[PartnerID]=@PartnerID
                             ,[PartnerName]=@PartnerName
                             ,[CustomerID]=@CustomerID
                             ,[CustomerName]=@CustomerName
                             ,[SalesMan]=@SalesMan
                             ,[Address]=@Address
                             ,[Mobile]=@Mobile
                             ,[BookingDate]=@BookingDate
                             ,[ShipDate]=@ShipDate
                             ,[Status]=@Status
                             ,[StepNo]=@StepNo
                             ,[Remark]=@Remark
                             ,[AttachmentFile]=@AttachmentFile
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                             ,[Modified]=@Modified
                             ,[ModifiedBy]=@ModifiedBy
                          Where OrderID=@OrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pOrderNo = new SqlParameter("OrderNo", Convert2DBnull(obj.OrderNo));
            pOrderNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pOrderNo);

            SqlParameter pOrderType = new SqlParameter("OrderType", Convert2DBnull(obj.OrderType));
            pOrderType.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pOrderType);

            SqlParameter pOutOrderNo = new SqlParameter("OutOrderNo", Convert2DBnull(obj.OutOrderNo));
            pOutOrderNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pOutOrderNo);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", Convert2DBnull(obj.PartnerName));
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", Convert2DBnull(obj.CustomerName));
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            SqlParameter pSalesMan = new SqlParameter("SalesMan", Convert2DBnull(obj.SalesMan));
            pSalesMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSalesMan);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pBookingDate = new SqlParameter("BookingDate", Convert2DBnull(obj.BookingDate));
            pBookingDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pBookingDate);

            SqlParameter pShipDate = new SqlParameter("ShipDate", Convert2DBnull(obj.ShipDate));
            pShipDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pShipDate);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pAttachmentFile = new SqlParameter("AttachmentFile", Convert2DBnull(obj.AttachmentFile));
            pAttachmentFile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAttachmentFile);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }

        public int LoadPartnerOrder(PartnerOrder obj)
        {
            string sql = @"Select 
                              [OrderID]
                             ,[OrderNo]
                             ,[OrderType]
                             ,[OutOrderNo]
                             ,[PartnerID]
                             ,[PartnerName]
                             ,[CustomerID]
                             ,[CustomerName]
                             ,[SalesMan]
                             ,[Address]
                             ,[Mobile]
                             ,[BookingDate]
                             ,[ShipDate]
                             ,[Status]
                             ,[StepNo]
                             ,[Remark]
                             ,[AttachmentFile]
                             ,[Created]
                             ,[CreatedBy]
                             ,[Modified]
                             ,[ModifiedBy]
                       From [BE_PartnerOrder] With(NoLock) Where OrderID=@OrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["OrderNo"]))
                        obj.OrderNo = (string)dr["OrderNo"];
                    if (!Convert.IsDBNull(dr["OrderType"]))
                        obj.OrderType = (string)dr["OrderType"];
                    if (!Convert.IsDBNull(dr["OutOrderNo"]))
                        obj.OutOrderNo = (string)dr["OutOrderNo"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["PartnerName"]))
                        obj.PartnerName = (string)dr["PartnerName"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["CustomerName"]))
                        obj.CustomerName = (string)dr["CustomerName"];
                    if (!Convert.IsDBNull(dr["SalesMan"]))
                        obj.SalesMan = (string)dr["SalesMan"];
                    if (!Convert.IsDBNull(dr["Address"]))
                        obj.Address = (string)dr["Address"];
                    if (!Convert.IsDBNull(dr["Mobile"]))
                        obj.Mobile = (string)dr["Mobile"];
                    if (!Convert.IsDBNull(dr["BookingDate"]))
                        obj.BookingDate = (DateTime)dr["BookingDate"];
                    if (!Convert.IsDBNull(dr["ShipDate"]))
                        obj.ShipDate = (DateTime)dr["ShipDate"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (string)dr["Status"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        obj.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["AttachmentFile"]))
                        obj.AttachmentFile = (string)dr["AttachmentFile"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    if (!Convert.IsDBNull(dr["ModifiedBy"]))
                        obj.ModifiedBy = (string)dr["ModifiedBy"];
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


        #region BE_PartnerOrder SearchObject()
        public SearchResult SearchPartnerOrder(SearchPartnerOrderArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT	       [BE_PartnerOrder].[OrderID]
                                                  ,[BE_PartnerOrder].[CustomerID]
                                                  ,[BE_PartnerOrder].[PartnerID]
                                                  ,[BE_PartnerOrder].[OrderNo]
                                                  ,[BE_PartnerOrder].[OutOrderNo]
                                                  ,[BE_PartnerOrder].[OrderType]
										          ,[BE_PartnerOrder].[PartnerName]
                                                  ,[BE_PartnerOrder].[CustomerName]
                                                  ,[BE_PartnerOrder].[Address]
                                                  ,[BE_PartnerOrder].[Mobile]
                                                  ,[BE_PartnerOrder].[BookingDate]
                                                  ,[BE_PartnerOrder].[ShipDate]
                                                  ,[BE_PartnerOrder].[StepNo]
                                                  ,[BE_PartnerOrder].[Remark]
                                                  ,[BE_PartnerOrder].[Created]
                                                  ,[BE_PartnerOrder].[CreatedBy]
                                                  ,[BE_PartnerOrder].[Modified]
                                                  ,[BE_PartnerOrder].[ModifiedBy]
                                                  ,[BE_PartnerOrder].[SalesMan]
                                                  ,[BE_PartnerOrder].[Status]
										          ,[TotalLength]
										          ,[TotalAreal]					  
                                      FROM 
		                                   [BE_PartnerOrder]  with(nolock)
                                           LEFT JOIN
                                            (
                                                select OrderID,Sum(TotalLength) as TotalLength,Sum(TotalAreal) as TotalAreal  from [BE_PartnerOrderProduct] Group By OrderID
                                            ) tb on [BE_PartnerOrder].[OrderID] = tb.[OrderID]
										   
	                                  WHERE 1=1");


            this.SetParameters_In(mbBuilder, cmd, "BE_PartnerOrder].[OrderID", "mbIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_PartnerOrder].[OrderType", "mbOrderTypes", args.OrderTypes);
            this.SetParameters_In(mbBuilder, cmd, "BE_PartnerOrder].[Status", "mbStatus", args.Status);

            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerOrder].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerOrder].[CustomerID", "mbCustomerID", args.CustomerID.Value);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_PartnerOrder].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_PartnerOrder].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_PartnerOrder].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_PartnerOrder].[Address", "mbAddress", args.Address);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_PartnerOrder].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.StepNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerOrder].[StepNo", "mbStepNo", args.StepNo);
            }
            //if (!string.IsNullOrEmpty(args.Resource))
            //{
            //    mbBuilder.AppendFormat(@" and [BE_PartnerOrder].[OrderID] in (
            //                                select 
            //                                 OrderID 
            //                                from 
            //                                 BE_OrderResource  with(nolock)
            //                                where 
            //                                 [Resource] in (
            //                                     select 
            //                                       RoleName 
            //                                      from 
            //                                       BE_Role  with(nolock)
            //                                      where 
            //                                       RoleID in(
            //		                                        select 
            //				                                        RoleID 
            //			                                        from 
            //				                                        BE_User2Role with(nolock)
            //				                                        LEFT JOIN BE_User with(nolock) on BE_User2Role.UserID = BE_User.UserID
            //			                                        where 
            //				                                        UserCode = N'{0}'
            //	                                          )
            //                                     )
            //                                 or [Resource] = N'{0}'
            //                                 )", args.Resource);

            //}

            this.SetParameters_Between(mbBuilder, cmd, "BookingDate", "mbBookingDate", args.BookingDateFrom, args.BookingDateTo);
            this.SetParameters_Between(mbBuilder, cmd, "ShipDate", "mbBookingDate", args.ShipDateFrom, args.ShipDateTo);

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public int UpdatePartnerOrder(Order args)
        {
            StringBuilder mbBuilder = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            mbBuilder.Append(@"UPDATE [BE_PartnerOrder] SET [Status] = @Status,[StepNo]=@StepNo ");
            mbBuilder.Append(" WHERE 1=1 ");

            SqlParameter pStatus = new SqlParameter("Status", args.Status);
            pStatus.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStatus);

            SqlParameter pStepNo = new SqlParameter("StepNo", args.StepNo);
            pStatus.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepNo);

            this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerOrder].[OrderID", "mbOrderID", args.OrderID);
            cmd.CommandText = mbBuilder.ToString();

            cmd.Connection = this.conn;
            cmd.Transaction = this.trans;
            return cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
