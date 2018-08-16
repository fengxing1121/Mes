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
        #region BE_PartnerTaskResource InsertObject()
        public int InsertPartnerTaskResource(PartnerTaskResource obj)
        {
            string sql = @"INSERT INTO[BE_PartnerTaskResource]([TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				) VALUES(@TaskID
				, @Resource
				, @Request
				, @Started
				, @StartedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            SqlParameter pResource = new SqlParameter("Resource", Convert2DBnull(obj.Resource));
            pResource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pResource);

            SqlParameter pRequest = new SqlParameter("Request", Convert2DBnull(obj.Request));
            pRequest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRequest);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PartnerTaskResource UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerTaskResourceByTaskID(PartnerTaskResource obj)
        {
            string sql = @"UPDATE [BE_PartnerTaskResource] SET [Resource]=@Resource
				, [Request]=@Request
				, [Started]=@Started
				, [StartedBy]=@StartedBy
 				WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pResource = new SqlParameter("Resource", Convert2DBnull(obj.Resource));
            pResource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pResource);

            SqlParameter pRequest = new SqlParameter("Request", Convert2DBnull(obj.Request));
            pRequest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRequest);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskResourceByTaskID(Guid taskID)
        {
            string sql = @"DELETE [BE_PartnerTaskResource] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerTaskResourceByTaskID(PartnerTaskResource obj)
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
 				FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        obj.TaskID = (Guid)dr["TaskID"];
                    obj.Resource = dr["Resource"].ToString();
                    obj.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        obj.Started = (DateTime)dr["Started"];
                    obj.StartedBy = dr["StartedBy"].ToString();
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

        #region BE_PartnerTaskResource CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerTaskResources()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskResource]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskResourcesByTaskID(Guid taskID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskResourcesByResource(string resource)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [Resource]=@Resource";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pResource = new SqlParameter("Resource", resource);
            pResource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pResource);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskResourcesByRequest(string request)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [Request]=@Request";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRequest = new SqlParameter("Request", request);
            pRequest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRequest);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskResourcesByStarted(DateTime started)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskResourcesByStartedBy(string startedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerTaskResources()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerTaskResource]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskResourcesByTaskID(Guid taskID)
        {
            string sql = "SELECT TOP 1 [TaskID] FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskResourcesByResource(string resource)
        {
            string sql = "SELECT TOP 1 [Resource] FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [Resource]=@Resource";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pResource = new SqlParameter("Resource", resource);
            pResource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pResource);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskResourcesByRequest(string request)
        {
            string sql = "SELECT TOP 1 [Request] FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [Request]=@Request";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRequest = new SqlParameter("Request", request);
            pRequest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRequest);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskResourcesByStarted(DateTime started)
        {
            string sql = "SELECT TOP 1 [Started] FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskResourcesByStartedBy(string startedBy)
        {
            string sql = "SELECT TOP 1 [StartedBy] FROM [BE_PartnerTaskResource] WITH(NOLOCK) WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerTaskResources()
        {
            string sql = "DELETE FROM [BE_PartnerTaskResource]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskResourcesByTaskID(Guid taskID)
        {
            string sql = "DELETE FROM [BE_PartnerTaskResource] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskResourcesByResource(string resource)
        {
            string sql = "DELETE FROM [BE_PartnerTaskResource] WHERE [Resource]=@Resource";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pResource = new SqlParameter("Resource", resource);
            pResource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pResource);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskResourcesByRequest(string request)
        {
            string sql = "DELETE FROM [BE_PartnerTaskResource] WHERE [Request]=@Request";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRequest = new SqlParameter("Request", request);
            pRequest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRequest);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskResourcesByStarted(DateTime started)
        {
            string sql = "DELETE FROM [BE_PartnerTaskResource] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskResourcesByStartedBy(string startedBy)
        {
            string sql = "DELETE FROM [BE_PartnerTaskResource] WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerTaskResource> LoadPartnerTaskResources()
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				 FROM [BE_PartnerTaskResource]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerTaskResource> ret = new List<PartnerTaskResource>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskResource iret = new PartnerTaskResource();
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.Resource = dr["Resource"].ToString();
                    iret.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.StartedBy = dr["StartedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskResource> LoadPartnerTaskResourcesByTaskID(Guid taskID)
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				 FROM [BE_PartnerTaskResource] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            List<PartnerTaskResource> ret = new List<PartnerTaskResource>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskResource iret = new PartnerTaskResource();
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.Resource = dr["Resource"].ToString();
                    iret.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.StartedBy = dr["StartedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskResource> LoadPartnerTaskResourcesByResource(string resource)
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				 FROM [BE_PartnerTaskResource] WHERE [Resource]=@Resource";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pResource = new SqlParameter("Resource", resource);
            pResource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pResource);

            List<PartnerTaskResource> ret = new List<PartnerTaskResource>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskResource iret = new PartnerTaskResource();
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.Resource = dr["Resource"].ToString();
                    iret.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.StartedBy = dr["StartedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskResource> LoadPartnerTaskResourcesByRequest(string request)
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				 FROM [BE_PartnerTaskResource] WHERE [Request]=@Request";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRequest = new SqlParameter("Request", request);
            pRequest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRequest);

            List<PartnerTaskResource> ret = new List<PartnerTaskResource>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskResource iret = new PartnerTaskResource();
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.Resource = dr["Resource"].ToString();
                    iret.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.StartedBy = dr["StartedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskResource> LoadPartnerTaskResourcesByStarted(DateTime started)
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				 FROM [BE_PartnerTaskResource] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            List<PartnerTaskResource> ret = new List<PartnerTaskResource>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskResource iret = new PartnerTaskResource();
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.Resource = dr["Resource"].ToString();
                    iret.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.StartedBy = dr["StartedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskResource> LoadPartnerTaskResourcesByStartedBy(string startedBy)
        {
            string sql = @"SELECT [TaskID]
				, [Resource]
				, [Request]
				, [Started]
				, [StartedBy]
				 FROM [BE_PartnerTaskResource] WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            List<PartnerTaskResource> ret = new List<PartnerTaskResource>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskResource iret = new PartnerTaskResource();
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.Resource = dr["Resource"].ToString();
                    iret.Request = dr["Request"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.StartedBy = dr["StartedBy"].ToString();
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
