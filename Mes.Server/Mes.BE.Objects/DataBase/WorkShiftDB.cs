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

        #region BE_WorkShift InsertObject()
        public int InsertWorkShift(WorkShift obj)
        {
            string sql = @"INSERT INTO[BE_WorkShift]([WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@WorkShiftID
				, @WorkShiftCode
				, @WorkShiftName
				, @Started
				, @Ended
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", Convert2DBnull(obj.WorkShiftCode));
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", Convert2DBnull(obj.WorkShiftName));
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkShift UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWorkShiftByWorkShiftCode(WorkShift obj)
        {
            string sql = @"UPDATE [BE_WorkShift] SET [WorkShiftID]=@WorkShiftID
				, [WorkShiftName]=@WorkShiftName
				, [Started]=@Started
				, [Ended]=@Ended
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", Convert2DBnull(obj.WorkShiftName));
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", Convert2DBnull(obj.WorkShiftCode));
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateWorkShiftByWorkShiftID(WorkShift obj)
        {
            string sql = @"UPDATE [BE_WorkShift] SET [WorkShiftCode]=@WorkShiftCode
				, [WorkShiftName]=@WorkShiftName
				, [Started]=@Started
				, [Ended]=@Ended
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", Convert2DBnull(obj.WorkShiftCode));
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", Convert2DBnull(obj.WorkShiftName));
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftByWorkShiftCode(string workShiftCode)
        {
            string sql = @"DELETE [BE_WorkShift] WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", workShiftCode);
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftByWorkShiftID(Guid workShiftID)
        {
            string sql = @"DELETE [BE_WorkShift] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWorkShiftByWorkShiftCode(WorkShift obj)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", Convert2DBnull(obj.WorkShiftCode));
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        obj.WorkShiftID = (Guid)dr["WorkShiftID"];
                    obj.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    obj.WorkShiftName = dr["WorkShiftName"].ToString();
                    obj.Started = dr["Started"].ToString();
                    obj.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    obj.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadWorkShiftByWorkShiftID(WorkShift obj)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        obj.WorkShiftID = (Guid)dr["WorkShiftID"];
                    obj.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    obj.WorkShiftName = dr["WorkShiftName"].ToString();
                    obj.Started = dr["Started"].ToString();
                    obj.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    obj.ModifiedBy = dr["ModifiedBy"].ToString();
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

        #region BE_WorkShift CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWorkShifts()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByWorkShiftID(Guid workShiftID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByWorkShiftCode(string workShiftCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", workShiftCode);
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByWorkShiftName(string workShiftName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftName]=@WorkShiftName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", workShiftName);
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByStarted(string started)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByEnded(string ended)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShiftsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWorkShifts()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WorkShift]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByWorkShiftID(Guid workShiftID)
        {
            string sql = "SELECT TOP 1 [WorkShiftID] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByWorkShiftCode(string workShiftCode)
        {
            string sql = "SELECT TOP 1 [WorkShiftCode] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", workShiftCode);
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByWorkShiftName(string workShiftName)
        {
            string sql = "SELECT TOP 1 [WorkShiftName] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [WorkShiftName]=@WorkShiftName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", workShiftName);
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByStarted(string started)
        {
            string sql = "SELECT TOP 1 [Started] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByEnded(string ended)
        {
            string sql = "SELECT TOP 1 [Ended] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShiftsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WorkShift] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWorkShifts()
        {
            string sql = "DELETE FROM [BE_WorkShift]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByWorkShiftID(Guid workShiftID)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByWorkShiftCode(string workShiftCode)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", workShiftCode);
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByWorkShiftName(string workShiftName)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [WorkShiftName]=@WorkShiftName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", workShiftName);
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByStarted(string started)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByEnded(string ended)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShiftsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WorkShift] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WorkShift> LoadWorkShifts()
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByWorkShiftID(Guid workShiftID)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByWorkShiftCode(string workShiftCode)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [WorkShiftCode]=@WorkShiftCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftCode = new SqlParameter("WorkShiftCode", workShiftCode);
            pWorkShiftCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftCode);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByWorkShiftName(string workShiftName)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [WorkShiftName]=@WorkShiftName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftName = new SqlParameter("WorkShiftName", workShiftName);
            pWorkShiftName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkShiftName);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByStarted(string started)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStarted);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByEnded(string ended)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnded);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByCreated(DateTime created)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByModified(DateTime modified)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift> LoadWorkShiftsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShiftCode]
				, [WorkShiftName]
				, [Started]
				, [Ended]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkShift] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WorkShift> ret = new List<WorkShift>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift iret = new WorkShift();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    iret.WorkShiftCode = dr["WorkShiftCode"].ToString();
                    iret.WorkShiftName = dr["WorkShiftName"].ToString();
                    iret.Started = dr["Started"].ToString();
                    iret.Ended = dr["Ended"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
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

        #region BE_WorkShift SearchObject()
        public SearchResult SearchWorkShift(SearchWorkShiftArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkShiftCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WorkShift].[WorkShiftID]
                                          ,[BE_WorkShift].[WorkShiftCode]
                                          ,[BE_WorkShift].[WorkShiftName]
                                          ,[BE_WorkShift].[Started]
                                          ,[BE_WorkShift].[Ended]
                                          ,[BE_WorkShift].[Created]
                                          ,[BE_WorkShift].[CreatedBy]
                                          ,[BE_WorkShift].[Modified]
                                          ,[BE_WorkShift].[ModifiedBy]
                                      FROM 
										  [BE_WorkShift] with(nolock)
	                                  WHERE 1=1");


            if (args.WorkShiftID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "WorkShiftID", "mbWorkFlowID", args.WorkShiftID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkShiftCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkShiftCode", "mbWorkShiftCode", args.WorkShiftCode);
            }
            if (!string.IsNullOrEmpty(args.WorkShiftName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkShiftName", "mbWorkShiftName", args.WorkShiftName);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
