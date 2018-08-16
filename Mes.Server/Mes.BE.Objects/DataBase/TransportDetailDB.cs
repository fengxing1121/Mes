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

        #region BE_TransportDetail InsertObject()
        public int InsertTransportDetail(TransportDetail obj)
        {
            string sql = @"INSERT INTO[BE_TransportDetail]([TransportID]
				, [OrderID]
				) VALUES(@TransportID
				, @OrderID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", Convert2DBnull(obj.TransportID));
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_TransportDetail UpdateObject()、DeleteObject()、LoadObject()
        public int DeleteTransportDetailByTransportID_OrderID(Guid transportID, Guid orderID)
        {
            string sql = @"DELETE [BE_TransportDetail] WHERE [TransportID]=@TransportID AND [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadTransportDetailByTransportID_OrderID(TransportDetail obj)
        {
            string sql = @"SELECT [TransportID]
				, [OrderID]
 				FROM [BE_TransportDetail] WITH(NOLOCK) WHERE [TransportID]=@TransportID AND [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", Convert2DBnull(obj.TransportID));
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        obj.TransportID = (Guid)dr["TransportID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
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

        #region BE_TransportDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountTransportDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportDetailsByTransportID(Guid transportID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportDetail] WITH(NOLOCK) WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportDetailsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportDetail] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsTransportDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_TransportDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportDetailsByTransportID(Guid transportID)
        {
            string sql = "SELECT TOP 1 [TransportID] FROM [BE_TransportDetail] WITH(NOLOCK) WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportDetailsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_TransportDetail] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteTransportDetails()
        {
            string sql = "DELETE FROM [BE_TransportDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportDetailsByTransportID(Guid transportID)
        {
            string sql = "DELETE FROM [BE_TransportDetail] WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportDetailsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_TransportDetail] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public List<TransportDetail> LoadTransportDetails()
        {
            string sql = @"SELECT [TransportID]
				, [OrderID]
				 FROM [BE_TransportDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<TransportDetail> ret = new List<TransportDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportDetail iret = new TransportDetail();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportDetail> LoadTransportDetailsByTransportID(Guid transportID)
        {
            string sql = @"SELECT [TransportID]
				, [OrderID]
				 FROM [BE_TransportDetail] WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            List<TransportDetail> ret = new List<TransportDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportDetail iret = new TransportDetail();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportDetail> LoadTransportDetailsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [TransportID]
				, [OrderID]
				 FROM [BE_TransportDetail] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<TransportDetail> ret = new List<TransportDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportDetail iret = new TransportDetail();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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

        #region BE_TransportDetail SearchObject()
        public SearchResult SearchTransportDetail(SearchTransportDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[TransportNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_TransportMain].[TransportID]
                                      ,[TransportNo]
	                                  ,[EnterpriseName]
									  ,[BE_Order].[OrderNo]
									  ,[BE_Order].[CustomerName]
	                                  ,[BE_Order].[Address] as [CustomerAddress]
									  ,[BE_Order].[Mobile] as [CustomerMobile]
									  ,[BE_LogisticsEnterprise].[Address] as [EnterpriseAddress]
									  ,[BE_LogisticsEnterprise].[Mobile] as [EnterpriseMobile]
                                      ,[BE_TransportMain].[CarID]
	                                  ,[PlateNo]
	                                  ,[DriverName]
	                                  ,[CarName]
	                                  ,[CarStyle]	 
                                      ,[Source]
                                      ,[Target]
                                      ,[Price]
                                      ,[BE_TransportMain].[Created]
                                      ,[BE_TransportMain].[CreatedBy]
                                      ,[BE_TransportDetail].[OrderID]
                                  FROM 
										[BE_TransportMain] with(nolock)
										LEFT JOIN [BE_TransportDetail] on [BE_TransportMain].[TransportID] =[BE_TransportDetail].[TransportID]
										LEFT JOIN [BE_Order] on [BE_TransportDetail].[OrderID] = [BE_Order].[OrderID]
										LEFT JOIN [BE_Car] with(nolock) on [BE_TransportMain].[CarID] = [BE_Car].[CarID]
										LEFT JOIN [BE_LogisticsEnterprise] on [BE_Car].[EnterpriseID] = [BE_LogisticsEnterprise].[EnterpriseID]
									WHERE 1=1");


            if (args.TransportID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_TransportMain].[TransportID", "mbTransportID", args.TransportID.Value);
            }
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_TransportDetail].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (!string.IsNullOrEmpty(args.EnterpriseName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "EnterpriseName", "mbEnterpriseName", args.EnterpriseName);
            }

            if (!string.IsNullOrEmpty(args.CustomerAddress))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Address", "mbCustomerAddress", args.CustomerAddress);
            }

            if (!string.IsNullOrEmpty(args.EnterpriseAddress))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_LogisticsEnterprise].[Address", "mbEnterpriseAddress", args.EnterpriseAddress);
            }

            if (!string.IsNullOrEmpty(args.PlateNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PlateNo", "mbPlateNo", args.PlateNo);
            }

            if (!string.IsNullOrEmpty(args.DriverName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DriverName", "mbDriverName", args.DriverName);
            }

            if (!string.IsNullOrEmpty(args.TransportNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "TransportNo", "mbTransportNo", args.TransportNo);
            }

            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
