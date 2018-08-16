//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;
//using MES.Libraries;
//using System.Linq;

//namespace Mes.BE.Objects
//{
//    public partial class ObjectProxy
//    {
//        #region BE_OrderResource InsertObject()
//        public int InsertOrderResource(OrderResource obj)
//        {
//            string sql = @"INSERT INTO[BE_OrderResource]([OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				) VALUES(@OrderID
//				, @CabinetID
//				, @Resource
//				, @Request
//				, @Started
//				, @StartedBy
//				)";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
//            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pOrderID);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            SqlParameter pResource = new SqlParameter("Resource", Convert2DBnull(obj.Resource));
//            pResource.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pResource);

//            SqlParameter pRequest = new SqlParameter("Request", Convert2DBnull(obj.Request));
//            pRequest.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pRequest);

//            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
//            pStarted.SqlDbType = SqlDbType.DateTime;
//            cmd.Parameters.Add(pStarted);

//            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
//            pStartedBy.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pStartedBy);

//            return cmd.ExecuteNonQuery();
//        }
//        #endregion

//        #region BE_OrderResource UpdateObject()、DeleteObject()、LoadObject()
//        public int UpdateOrderResourceByCabinetID(OrderResource obj)
//        {
//            string sql = @"UPDATE [BE_OrderResource] SET [OrderID]=@OrderID
//				, [Resource]=@Resource
//				, [Request]=@Request
//				, [Started]=@Started
//				, [StartedBy]=@StartedBy
// 				WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
//            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pOrderID);

//            SqlParameter pResource = new SqlParameter("Resource", Convert2DBnull(obj.Resource));
//            pResource.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pResource);

//            SqlParameter pRequest = new SqlParameter("Request", Convert2DBnull(obj.Request));
//            pRequest.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pRequest);

//            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
//            pStarted.SqlDbType = SqlDbType.DateTime;
//            cmd.Parameters.Add(pStarted);

//            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
//            pStartedBy.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pStartedBy);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourceByCabinetID(Guid cabinetID)
//        {
//            string sql = @"DELETE [BE_OrderResource] WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            return cmd.ExecuteNonQuery();
//        }
//        public int LoadOrderResourceByCabinetID(OrderResource obj)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
// 				FROM [BE_OrderResource] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            int ret = 0;
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        obj.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        obj.CabinetID = (Guid)dr["CabinetID"];
//                    obj.Resource = dr["Resource"].ToString();
//                    obj.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        obj.Started = (DateTime)dr["Started"];
//                    obj.StartedBy = dr["StartedBy"].ToString();
//                    ret += 1;
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        #endregion

//        #region BE_OrderResource CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
//        public int CountOrderResources()
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource]";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public int CountOrderResourcesByOrderID(Guid orderID)
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
//            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pOrderID);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public int CountOrderResourcesByCabinetID(Guid cabinetID)
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public int CountOrderResourcesByResource(string resource)
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource] WITH(NOLOCK) WHERE [Resource]=@Resource";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pResource = new SqlParameter("Resource", resource);
//            pResource.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pResource);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public int CountOrderResourcesByRequest(string request)
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource] WITH(NOLOCK) WHERE [Request]=@Request";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pRequest = new SqlParameter("Request", request);
//            pRequest.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pRequest);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public int CountOrderResourcesByStarted(DateTime started)
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource] WITH(NOLOCK) WHERE [Started]=@Started";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStarted = new SqlParameter("Started", started);
//            pStarted.SqlDbType = SqlDbType.DateTime;
//            cmd.Parameters.Add(pStarted);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public int CountOrderResourcesByStartedBy(string startedBy)
//        {
//            string sql = "SELECT COUNT(*) FROM [BE_OrderResource] WITH(NOLOCK) WHERE [StartedBy]=@StartedBy";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
//            pStartedBy.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pStartedBy);

//            object objret = cmd.ExecuteScalar();
//            return (int)objret;
//        }
//        public bool ExistsOrderResources()
//        {
//            string sql = "SELECT TOP 1 * FROM [BE_OrderResource]";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public bool ExistsOrderResourcesByOrderID(Guid orderID)
//        {
//            string sql = "SELECT TOP 1 [OrderID] FROM [BE_OrderResource] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
//            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pOrderID);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public bool ExistsOrderResourcesByCabinetID(Guid cabinetID)
//        {
//            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_OrderResource] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public bool ExistsOrderResourcesByResource(string resource)
//        {
//            string sql = "SELECT TOP 1 [Resource] FROM [BE_OrderResource] WITH(NOLOCK) WHERE [Resource]=@Resource";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pResource = new SqlParameter("Resource", resource);
//            pResource.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pResource);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public bool ExistsOrderResourcesByRequest(string request)
//        {
//            string sql = "SELECT TOP 1 [Request] FROM [BE_OrderResource] WITH(NOLOCK) WHERE [Request]=@Request";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pRequest = new SqlParameter("Request", request);
//            pRequest.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pRequest);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public bool ExistsOrderResourcesByStarted(DateTime started)
//        {
//            string sql = "SELECT TOP 1 [Started] FROM [BE_OrderResource] WITH(NOLOCK) WHERE [Started]=@Started";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStarted = new SqlParameter("Started", started);
//            pStarted.SqlDbType = SqlDbType.DateTime;
//            cmd.Parameters.Add(pStarted);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public bool ExistsOrderResourcesByStartedBy(string startedBy)
//        {
//            string sql = "SELECT TOP 1 [StartedBy] FROM [BE_OrderResource] WITH(NOLOCK) WHERE [StartedBy]=@StartedBy";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
//            pStartedBy.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pStartedBy);

//            object objret = cmd.ExecuteScalar();
//            return objret != null;
//        }
//        public int DeleteOrderResources()
//        {
//            string sql = "DELETE FROM [BE_OrderResource]";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourcesByOrderID(Guid orderID)
//        {
//            string sql = "DELETE FROM [BE_OrderResource] WHERE [OrderID]=@OrderID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
//            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pOrderID);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourcesByCabinetID(Guid cabinetID)
//        {
//            string sql = "DELETE FROM [BE_OrderResource] WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourcesByResource(string resource)
//        {
//            string sql = "DELETE FROM [BE_OrderResource] WHERE [Resource]=@Resource";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pResource = new SqlParameter("Resource", resource);
//            pResource.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pResource);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourcesByRequest(string request)
//        {
//            string sql = "DELETE FROM [BE_OrderResource] WHERE [Request]=@Request";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pRequest = new SqlParameter("Request", request);
//            pRequest.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pRequest);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourcesByStarted(DateTime started)
//        {
//            string sql = "DELETE FROM [BE_OrderResource] WHERE [Started]=@Started";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStarted = new SqlParameter("Started", started);
//            pStarted.SqlDbType = SqlDbType.DateTime;
//            cmd.Parameters.Add(pStarted);

//            return cmd.ExecuteNonQuery();
//        }
//        public int DeleteOrderResourcesByStartedBy(string startedBy)
//        {
//            string sql = "DELETE FROM [BE_OrderResource] WHERE [StartedBy]=@StartedBy";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
//            pStartedBy.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pStartedBy);

//            return cmd.ExecuteNonQuery();
//        }
//        public List<OrderResource> LoadOrderResources()
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource]";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        public List<OrderResource> LoadOrderResourcesByOrderID(Guid orderID)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource] WHERE [OrderID]=@OrderID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
//            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pOrderID);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        public List<OrderResource> LoadOrderResourcesByCabinetID(Guid cabinetID)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource] WHERE [CabinetID]=@CabinetID";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
//            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
//            cmd.Parameters.Add(pCabinetID);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        public List<OrderResource> LoadOrderResourcesByResource(string resource)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource] WHERE [Resource]=@Resource";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pResource = new SqlParameter("Resource", resource);
//            pResource.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pResource);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        public List<OrderResource> LoadOrderResourcesByRequest(string request)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource] WHERE [Request]=@Request";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pRequest = new SqlParameter("Request", request);
//            pRequest.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pRequest);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        public List<OrderResource> LoadOrderResourcesByStarted(DateTime started)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource] WHERE [Started]=@Started";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStarted = new SqlParameter("Started", started);
//            pStarted.SqlDbType = SqlDbType.DateTime;
//            cmd.Parameters.Add(pStarted);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        public List<OrderResource> LoadOrderResourcesByStartedBy(string startedBy)
//        {
//            string sql = @"SELECT [OrderID]
//				, [CabinetID]
//				, [Resource]
//				, [Request]
//				, [Started]
//				, [StartedBy]
//				 FROM [BE_OrderResource] WHERE [StartedBy]=@StartedBy";
//            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

//            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
//            pStartedBy.SqlDbType = SqlDbType.NVarChar;
//            cmd.Parameters.Add(pStartedBy);

//            List<OrderResource> ret = new List<OrderResource>();
//            SqlDataReader dr = cmd.ExecuteReader();
//            try
//            {
//                while (dr.Read())
//                {
//                    OrderResource iret = new OrderResource();
//                    if (!Convert.IsDBNull(dr["OrderID"]))
//                        iret.OrderID = (Guid)dr["OrderID"];
//                    if (!Convert.IsDBNull(dr["CabinetID"]))
//                        iret.CabinetID = (Guid)dr["CabinetID"];
//                    iret.Resource = dr["Resource"].ToString();
//                    iret.Request = dr["Request"].ToString();
//                    if (!Convert.IsDBNull(dr["Started"]))
//                        iret.Started = (DateTime)dr["Started"];
//                    iret.StartedBy = dr["StartedBy"].ToString();
//                    ret.Add(iret);
//                }
//            }
//            finally
//            {
//                dr.Close();
//            }
//            return ret;
//        }
//        #endregion
//    }
//}
