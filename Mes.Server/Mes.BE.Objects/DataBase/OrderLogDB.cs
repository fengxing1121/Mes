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
        #region BE_OrderLog InsertObject()
        public int InsertOrderLog(OrderLog obj)
        {
            string sql = @"INSERT INTO[BE_OrderLog]([LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				) VALUES(@LogID
				, @OrderID
				, @LogType
				, @Remark
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", Convert2DBnull(obj.LogID));
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pLogType = new SqlParameter("LogType", Convert2DBnull(obj.LogType));
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderLog UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrderLogByLogID(OrderLog obj)
        {
            string sql = @"UPDATE [BE_OrderLog] SET [OrderID]=@OrderID
				, [LogType]=@LogType
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pLogType = new SqlParameter("LogType", Convert2DBnull(obj.LogType));
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pLogID = new SqlParameter("LogID", Convert2DBnull(obj.LogID));
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogByLogID(Guid logID)
        {
            string sql = @"DELETE [BE_OrderLog] WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrderLogByLogID(OrderLog obj)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
 				FROM [BE_OrderLog] WITH(NOLOCK) WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", Convert2DBnull(obj.LogID));
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["LogID"]))
                        obj.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    obj.LogType = dr["LogType"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_OrderLog CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrderLogs()
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderLogsByLogID(Guid logID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog] WITH(NOLOCK) WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderLogsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderLogsByLogType(string logType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog] WITH(NOLOCK) WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderLogsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderLogsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrderLogsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_OrderLog] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrderLogs()
        {
            string sql = "SELECT TOP 1 * FROM [BE_OrderLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderLogsByLogID(Guid logID)
        {
            string sql = "SELECT TOP 1 [LogID] FROM [BE_OrderLog] WITH(NOLOCK) WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderLogsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderLog] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderLogsByLogType(string logType)
        {
            string sql = "SELECT TOP 1 [LogType] FROM [BE_OrderLog] WITH(NOLOCK) WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderLogsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_OrderLog] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderLogsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_OrderLog] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrderLogsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_OrderLog] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrderLogs()
        {
            string sql = "DELETE FROM [BE_OrderLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogsByLogID(Guid logID)
        {
            string sql = "DELETE FROM [BE_OrderLog] WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_OrderLog] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogsByLogType(string logType)
        {
            string sql = "DELETE FROM [BE_OrderLog] WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_OrderLog] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_OrderLog] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrderLogsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_OrderLog] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<OrderLog> LoadOrderLogs()
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderLogsByLogID(Guid logID)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog] WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderLogsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderStatusLogsByOrderID(Guid orderID)
        {
            string sql = @"select OrderID,LogType,Created from (select ROW_NUMBER()over(partition by LogType order by created desc) rowId,*   
                        from BE_OrderLog where OrderID=@OrderID) as AuctionRecords   
                        where rowId=1 order by created desc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderLogsByLogType(string logType)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog] WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderLogsByRemark(string remark)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderLogsByCreated(DateTime created)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<OrderLog> LoadOrderLogsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [LogID]
				, [OrderID]
				, [LogType]
				, [Remark]
				, [Created]
				, [CreatedBy]
				 FROM [BE_OrderLog] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<OrderLog> ret = new List<OrderLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderLog iret = new OrderLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    iret.LogType = dr["LogType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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
    }
}
