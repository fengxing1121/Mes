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

        #region BE_WorkCenterScheduling InsertObject()
        public int InsertWorkCenterScheduling(WorkCenterScheduling obj)
        {
            string sql = @"INSERT INTO[BE_WorkCenterScheduling]([WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@WorkID
				, @WorkCenterID
				, @BattchNum
				, @Started
				, @Ended
				, @Status
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", Convert2DBnull(obj.WorkID));
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", Convert2DBnull(obj.WorkCenterID));
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

        #region BE_WorkCenterScheduling UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWorkCenterSchedulingByWorkID(WorkCenterScheduling obj)
        {
            string sql = @"UPDATE [BE_WorkCenterScheduling] SET [WorkCenterID]=@WorkCenterID
				, [BattchNum]=@BattchNum
				, [Started]=@Started
				, [Ended]=@Ended
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", Convert2DBnull(obj.WorkCenterID));
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", Convert2DBnull(obj.BattchNum));
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

            SqlParameter pWorkID = new SqlParameter("WorkID", Convert2DBnull(obj.WorkID));
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingByWorkID(Guid workID)
        {
            string sql = @"DELETE [BE_WorkCenterScheduling] WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", workID);
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWorkCenterSchedulingByWorkID(WorkCenterScheduling obj)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", Convert2DBnull(obj.WorkID));
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        obj.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        obj.WorkCenterID = (Guid)dr["WorkCenterID"];
                    obj.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        obj.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        obj.Ended = (DateTime)dr["Ended"];
                    obj.Status = dr["Status"].ToString();
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

        #region BE_WorkCenterScheduling CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWorkCenterSchedulings()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByWorkID(Guid workID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", workID);
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByWorkCenterID(Guid workCenterID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByBattchNum(string battchNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByStarted(DateTime started)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByEnded(DateTime ended)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByStatus(string status)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCenterSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWorkCenterSchedulings()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WorkCenterScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByWorkID(Guid workID)
        {
            string sql = "SELECT TOP 1 [WorkID] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", workID);
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByWorkCenterID(Guid workCenterID)
        {
            string sql = "SELECT TOP 1 [WorkCenterID] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByBattchNum(string battchNum)
        {
            string sql = "SELECT TOP 1 [BattchNum] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByStarted(DateTime started)
        {
            string sql = "SELECT TOP 1 [Started] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByEnded(DateTime ended)
        {
            string sql = "SELECT TOP 1 [Ended] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByStatus(string status)
        {
            string sql = "SELECT TOP 1 [Status] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCenterSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WorkCenterScheduling] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWorkCenterSchedulings()
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByWorkID(Guid workID)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", workID);
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByWorkCenterID(Guid workCenterID)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByBattchNum(string battchNum)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByStarted(DateTime started)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByEnded(DateTime ended)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByStatus(string status)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WorkCenterScheduling] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WorkCenterScheduling> LoadWorkCenterSchedulings()
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByWorkID(Guid workID)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [WorkID]=@WorkID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkID = new SqlParameter("WorkID", workID);
            pWorkID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkID);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByWorkCenterID(Guid workCenterID)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByBattchNum(string battchNum)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [BattchNum]=@BattchNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNum = new SqlParameter("BattchNum", battchNum);
            pBattchNum.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNum);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByStarted(DateTime started)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByEnded(DateTime ended)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByStatus(string status)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByCreated(DateTime created)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByModified(DateTime modified)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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
        public List<WorkCenterScheduling> LoadWorkCenterSchedulingsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WorkCenterScheduling> ret = new List<WorkCenterScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenterScheduling iret = new WorkCenterScheduling();
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        iret.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    iret.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.Status = dr["Status"].ToString();
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

        #region BE_WorkCenterScheduling SearchObject()
        public SearchResult SearchWorkCenterScheduling(SearchWorkCenterSchedulingArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BE_WorkCenterScheduling].[Started]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WorkCenterScheduling].[WorkID]
                                          ,[BE_WorkCenterScheduling].[WorkCenterID]
                                          ,[BE_WorkCenterScheduling].[BattchNum]
                                          ,[BE_WorkCenterScheduling].[Started]
                                          ,[BE_WorkCenterScheduling].[Ended]
                                          ,[BE_WorkCenterScheduling].[Status]
                                          ,[BE_WorkCenterScheduling].[Created]
                                          ,[BE_WorkCenterScheduling].[CreatedBy]
                                          ,[BE_WorkCenterScheduling].[Modified]
                                          ,[BE_WorkCenterScheduling].[ModifiedBy]
										  ,[BE_WorkCenter].[WorkCenterName]
										  ,[BE_Order].[OrderNo]
										  ,[BE_Order].[CustomerName]
										  ,[BE_WorkShop].[WorkShopName]
										  ,[BE_WorkShop].[WorkShopID]
										  ,[BE_WorkingLine].[WorkingLineName]
										  ,[BE_WorkingLine].[WorkingLineID]
                                      FROM 
									      [BE_WorkCenterScheduling] with(nolock)
                                          LEFT JOIN [BE_WorkCenter] with(nolock) on [BE_WorkCenterScheduling].[WorkCenterID] = [BE_WorkCenter].[WorkCenterID]
									      LEFT JOIN [BE_Order] with(nolock) on [BE_Order].[BattchNum] = [BE_WorkCenterScheduling].[BattchNum]
                                          LEFT JOIN [BE_WorkShop] with(nolock) on [BE_WorkShop].[WorkShopID] = [BE_WorkCenter].[WorkShopID]
                                          LEFT JOIN [BE_WorkingLine] with(nolock) on [BE_WorkingLine].[WorkingLineID] = [BE_WorkShop].[WorkingLineID]
	                                  WHERE 1=1");

            if (args.WorkCenterID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkCenterScheduling].[WorkCenterID", "mbWorkCenterID", args.WorkCenterID.Value);
            }
            if (args.WorkingLineID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkingLine].[WorkingLineID", "mbWorkingLineID", args.WorkingLineID.Value);
            }
            if (args.WorkShopID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkShop].[WorkShopID", "mbWorkShopID", args.WorkShopID.Value);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkCenterName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkCenterName", "mbWorkCenterName", args.WorkCenterName);
            }
            if (!string.IsNullOrEmpty(args.BattchNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkCenterScheduling].[BattchNum", "mbBattchNum", args.BattchNum);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            this.SetParameters_Between(mbBuilder, cmd, "BE_WorkCenterScheduling].[Started", "mbStarted", args.StartedFrom, args.StartedTo);
            this.SetParameters_Between(mbBuilder, cmd, "BE_WorkCenterScheduling].[Ended", "mbEnded", args.EndedFrom, args.EndedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public int LoadLastWorkCenterSchedulingByWorkCenterID(WorkCenterScheduling obj)
        {
            string sql = @"SELECT top 1 [WorkID]
				, [WorkCenterID]
				, [BattchNum]
				, [Started]
				, [Ended]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenterScheduling] WHERE [WorkCenterID]=@WorkCenterID Order By [Ended] DESC";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", obj.WorkCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkID"]))
                        obj.WorkID = (Guid)dr["WorkID"];
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        obj.WorkCenterID = (Guid)dr["WorkCenterID"];
                    obj.BattchNum = dr["BattchNum"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        obj.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        obj.Ended = (DateTime)dr["Ended"];
                    obj.Status = dr["Status"].ToString();
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
    }
}
