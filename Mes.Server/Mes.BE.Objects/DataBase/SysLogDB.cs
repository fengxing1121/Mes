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
      
        #region BE_SysLog InsertObject()
        public int InsertSysLog(SysLog obj)
        {
            string sql = @"INSERT INTO[BE_SysLog]([LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				) VALUES(@LogID
				, @LogType
				, @SourceID
				, @UserCode
				, @Remark
				, @URL
				, @Mehtod
				, @IP
				, @Created
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", Convert2DBnull(obj.LogID));
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            SqlParameter pLogType = new SqlParameter("LogType", Convert2DBnull(obj.LogType));
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            SqlParameter pSourceID = new SqlParameter("SourceID", Convert2DBnull(obj.SourceID));
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pURL = new SqlParameter("URL", Convert2DBnull(obj.URL));
            pURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pURL);

            SqlParameter pMehtod = new SqlParameter("Mehtod", Convert2DBnull(obj.Mehtod));
            pMehtod.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMehtod);

            SqlParameter pIP = new SqlParameter("IP", Convert2DBnull(obj.IP));
            pIP.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIP);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_SysLog UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSysLogByLogID(SysLog obj)
        {
            string sql = @"UPDATE [BE_SysLog] SET [LogType]=@LogType
				, [SourceID]=@SourceID
				, [UserCode]=@UserCode
				, [Remark]=@Remark
				, [URL]=@URL
				, [Mehtod]=@Mehtod
				, [IP]=@IP
				, [Created]=@Created
 				WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", Convert2DBnull(obj.LogType));
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            SqlParameter pSourceID = new SqlParameter("SourceID", Convert2DBnull(obj.SourceID));
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pURL = new SqlParameter("URL", Convert2DBnull(obj.URL));
            pURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pURL);

            SqlParameter pMehtod = new SqlParameter("Mehtod", Convert2DBnull(obj.Mehtod));
            pMehtod.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMehtod);

            SqlParameter pIP = new SqlParameter("IP", Convert2DBnull(obj.IP));
            pIP.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIP);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pLogID = new SqlParameter("LogID", Convert2DBnull(obj.LogID));
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogByLogID(Guid logID)
        {
            string sql = @"DELETE [BE_SysLog] WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSysLogByLogID(SysLog obj)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
 				FROM [BE_SysLog] WITH(NOLOCK) WHERE [LogID]=@LogID";
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
                    obj.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        obj.SourceID = (Guid)dr["SourceID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.URL = dr["URL"].ToString();
                    obj.Mehtod = dr["Mehtod"].ToString();
                    obj.IP = dr["IP"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
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

        #region BE_SysLog CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSysLogs()
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByLogID(Guid logID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByLogType(string logType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsBySourceID(Guid sourceID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByUserCode(string userCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByURL(string uRL)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [URL]=@URL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pURL = new SqlParameter("URL", uRL);
            pURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pURL);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByMehtod(string mehtod)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [Mehtod]=@Mehtod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMehtod = new SqlParameter("Mehtod", mehtod);
            pMehtod.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMehtod);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByIP(string iP)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [IP]=@IP";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIP = new SqlParameter("IP", iP);
            pIP.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIP);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSysLogsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SysLog] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSysLogs()
        {
            string sql = "SELECT TOP 1 * FROM [BE_SysLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByLogID(Guid logID)
        {
            string sql = "SELECT TOP 1 [LogID] FROM [BE_SysLog] WITH(NOLOCK) WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByLogType(string logType)
        {
            string sql = "SELECT TOP 1 [LogType] FROM [BE_SysLog] WITH(NOLOCK) WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsBySourceID(Guid sourceID)
        {
            string sql = "SELECT TOP 1 [SourceID] FROM [BE_SysLog] WITH(NOLOCK) WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByUserCode(string userCode)
        {
            string sql = "SELECT TOP 1 [UserCode] FROM [BE_SysLog] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_SysLog] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByURL(string uRL)
        {
            string sql = "SELECT TOP 1 [URL] FROM [BE_SysLog] WITH(NOLOCK) WHERE [URL]=@URL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pURL = new SqlParameter("URL", uRL);
            pURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pURL);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByMehtod(string mehtod)
        {
            string sql = "SELECT TOP 1 [Mehtod] FROM [BE_SysLog] WITH(NOLOCK) WHERE [Mehtod]=@Mehtod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMehtod = new SqlParameter("Mehtod", mehtod);
            pMehtod.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMehtod);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByIP(string iP)
        {
            string sql = "SELECT TOP 1 [IP] FROM [BE_SysLog] WITH(NOLOCK) WHERE [IP]=@IP";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIP = new SqlParameter("IP", iP);
            pIP.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIP);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSysLogsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_SysLog] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSysLogs()
        {
            string sql = "DELETE FROM [BE_SysLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByLogID(Guid logID)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByLogType(string logType)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsBySourceID(Guid sourceID)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByUserCode(string userCode)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByURL(string uRL)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [URL]=@URL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pURL = new SqlParameter("URL", uRL);
            pURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pURL);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByMehtod(string mehtod)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [Mehtod]=@Mehtod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMehtod = new SqlParameter("Mehtod", mehtod);
            pMehtod.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMehtod);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByIP(string iP)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [IP]=@IP";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIP = new SqlParameter("IP", iP);
            pIP.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIP);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSysLogsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_SysLog] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public List<SysLog> LoadSysLogs()
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByLogID(Guid logID)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [LogID]=@LogID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogID = new SqlParameter("LogID", logID);
            pLogID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLogID);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByLogType(string logType)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [LogType]=@LogType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLogType = new SqlParameter("LogType", logType);
            pLogType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLogType);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsBySourceID(Guid sourceID)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [SourceID]=@SourceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSourceID = new SqlParameter("SourceID", sourceID);
            pSourceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSourceID);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByUserCode(string userCode)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByRemark(string remark)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByURL(string uRL)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [URL]=@URL";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pURL = new SqlParameter("URL", uRL);
            pURL.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pURL);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByMehtod(string mehtod)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [Mehtod]=@Mehtod";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMehtod = new SqlParameter("Mehtod", mehtod);
            pMehtod.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMehtod);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByIP(string iP)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [IP]=@IP";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIP = new SqlParameter("IP", iP);
            pIP.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIP);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        public List<SysLog> LoadSysLogsByCreated(DateTime created)
        {
            string sql = @"SELECT [LogID]
				, [LogType]
				, [SourceID]
				, [UserCode]
				, [Remark]
				, [URL]
				, [Mehtod]
				, [IP]
				, [Created]
				 FROM [BE_SysLog] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<SysLog> ret = new List<SysLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SysLog iret = new SysLog();
                    if (!Convert.IsDBNull(dr["LogID"]))
                        iret.LogID = (Guid)dr["LogID"];
                    iret.LogType = dr["LogType"].ToString();
                    if (!Convert.IsDBNull(dr["SourceID"]))
                        iret.SourceID = (Guid)dr["SourceID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.URL = dr["URL"].ToString();
                    iret.Mehtod = dr["Mehtod"].ToString();
                    iret.IP = dr["IP"].ToString();
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
        #endregion

        #region BE_SysLog SearchObject()
        public SearchResult SearchSysLogs(SearchSysLogArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Created] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [LogID]                                       
                                          ,[LogType]
                                          ,[SourceID]
                                          ,[UserCode]
                                          ,[Remark]
                                          ,[URL]
                                          ,[Mehtod]
                                          ,[IP]
                                          ,[Created]
                                      FROM 
                                           [BE_SysLog] with(nolock)
	                                  WHERE 1=1");


            if (!string.IsNullOrEmpty(args.LogType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "LogType", "mbLogType", args.LogType);
            }

            SetParameters_Between(mbBuilder, cmd, "Created", "mbCreated", args.CreatedFrom, args.CreatedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
