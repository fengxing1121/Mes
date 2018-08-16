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

        #region BE_PartnerTask InsertObject()
        public int InsertPartnerTask(PartnerTask obj)
        {
            string sql = @"INSERT INTO[BE_PartnerTask]([PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@PartnerID
				, @TaskID
				, @TaskNo
				, @ReferenceID
				, @StepNo
				, @StepName
				, @TaskType
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", Convert2DBnull(obj.TaskNo));
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", Convert2DBnull(obj.ReferenceID));
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pTaskType = new SqlParameter("TaskType", Convert2DBnull(obj.TaskType));
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

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

        #region BE_PartnerTask UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerTaskByPartnerID_TaskNo(PartnerTask obj)
        {
            string sql = @"UPDATE [BE_PartnerTask] SET [TaskID]=@TaskID
				, [ReferenceID]=@ReferenceID
				, [StepNo]=@StepNo
				, [StepName]=@StepName
				, [TaskType]=@TaskType
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PartnerID]=@PartnerID AND [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", Convert2DBnull(obj.ReferenceID));
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pTaskType = new SqlParameter("TaskType", Convert2DBnull(obj.TaskType));
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

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

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", Convert2DBnull(obj.TaskNo));
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePartnerTaskByTaskID(PartnerTask obj)
        {
            string sql = @"UPDATE [BE_PartnerTask] SET [PartnerID]=@PartnerID
				, [TaskNo]=@TaskNo
				, [ReferenceID]=@ReferenceID
				, [StepNo]=@StepNo
				, [StepName]=@StepName
				, [TaskType]=@TaskType
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", Convert2DBnull(obj.TaskNo));
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", Convert2DBnull(obj.ReferenceID));
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pTaskType = new SqlParameter("TaskType", Convert2DBnull(obj.TaskType));
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

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

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskByPartnerID_TaskNo(Guid partnerID, string taskNo)
        {
            string sql = @"DELETE [BE_PartnerTask] WHERE [PartnerID]=@PartnerID AND [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", taskNo);
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskByTaskID(Guid taskID)
        {
            string sql = @"DELETE [BE_PartnerTask] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerTaskByPartnerID_TaskNo(PartnerTask obj)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID AND [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", Convert2DBnull(obj.TaskNo));
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        obj.TaskID = (Guid)dr["TaskID"];
                    obj.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        obj.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    obj.StepName = dr["StepName"].ToString();
                    obj.TaskType = dr["TaskType"].ToString();
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
        public int LoadPartnerTaskByTaskID(PartnerTask obj)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
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
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        obj.TaskID = (Guid)dr["TaskID"];
                    obj.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        obj.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    obj.StepName = dr["StepName"].ToString();
                    obj.TaskType = dr["TaskType"].ToString();
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

        #region BE_PartnerTask CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerTasks()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByTaskID(Guid taskID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByTaskNo(string taskNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", taskNo);
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByReferenceID(Guid referenceID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [ReferenceID]=@ReferenceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", referenceID);
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByStepNo(int stepNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByStepName(string stepName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByTaskType(string taskType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskType]=@TaskType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskType = new SqlParameter("TaskType", taskType);
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTasksByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerTasks()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerTask]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByTaskID(Guid taskID)
        {
            string sql = "SELECT TOP 1 [TaskID] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByTaskNo(string taskNo)
        {
            string sql = "SELECT TOP 1 [TaskNo] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", taskNo);
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByReferenceID(Guid referenceID)
        {
            string sql = "SELECT TOP 1 [ReferenceID] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [ReferenceID]=@ReferenceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", referenceID);
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByStepNo(int stepNo)
        {
            string sql = "SELECT TOP 1 [StepNo] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByStepName(string stepName)
        {
            string sql = "SELECT TOP 1 [StepName] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByTaskType(string taskType)
        {
            string sql = "SELECT TOP 1 [TaskType] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [TaskType]=@TaskType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskType = new SqlParameter("TaskType", taskType);
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTasksByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PartnerTask] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerTasks()
        {
            string sql = "DELETE FROM [BE_PartnerTask]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByTaskID(Guid taskID)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByTaskNo(string taskNo)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", taskNo);
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByReferenceID(Guid referenceID)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [ReferenceID]=@ReferenceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", referenceID);
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByStepNo(int stepNo)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByStepName(string stepName)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByTaskType(string taskType)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [TaskType]=@TaskType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskType = new SqlParameter("TaskType", taskType);
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTasksByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PartnerTask] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerTask> LoadPartnerTasks()
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByTaskID(Guid taskID)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByTaskNo(string taskNo)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [TaskNo]=@TaskNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskNo = new SqlParameter("TaskNo", taskNo);
            pTaskNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskNo);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByReferenceID(Guid referenceID)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [ReferenceID]=@ReferenceID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pReferenceID = new SqlParameter("ReferenceID", referenceID);
            pReferenceID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pReferenceID);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByStepNo(int stepNo)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByStepName(string stepName)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByTaskType(string taskType)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [TaskType]=@TaskType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskType = new SqlParameter("TaskType", taskType);
            pTaskType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTaskType);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByCreated(DateTime created)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByModified(DateTime modified)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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
        public List<PartnerTask> LoadPartnerTasksByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [PartnerID]
				, [TaskID]
				, [TaskNo]
				, [ReferenceID]
				, [StepNo]
				, [StepName]
				, [TaskType]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerTask] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PartnerTask> ret = new List<PartnerTask>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTask iret = new PartnerTask();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    iret.TaskNo = dr["TaskNo"].ToString();
                    if (!Convert.IsDBNull(dr["ReferenceID"]))
                        iret.ReferenceID = (Guid)dr["ReferenceID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.TaskType = dr["TaskType"].ToString();
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

        #region BE_PartnerTasks SearchObject()
        public SearchResult SearchPartnerTasks(SearchPartnerTaskArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[TaskNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();
            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
										[BE_PartnerTask].[PartnerID]
										,[BE_PartnerTask].[TaskID]	
										,[BE_PartnerTask].[ReferenceID]									
										,[BE_PartnerTask].[TaskNo]
										,[BE_PartnerTask].[TaskType]
										,[BE_PartnerTask].[StepNo]
										,[BE_PartnerTask].[StepName]
										,[BE_PartnerTask].[CreatedBy]
										,[BE_PartnerTask].[Created]
										,[BE_PartnerTask].[ModifiedBy]
										,[BE_PartnerTask].[Modified]	
										,[BE_Partner].[PartnerName]
										,[BE_RoomDesigner].[Designer]
										,[BE_RoomDesigner].[DesignerNo]
										,[BE_RoomDesigner].[CustomerID]
										,[DesignerName] = (select UserName from BE_PartnerUser	where UserID= [BE_RoomDesigner].[Designer])	
                                        ,C.CustomerName
                                        ,K.KJLDesignID																									
                                    FROM 
	                                    [BE_PartnerTask] with(nolock) 
										LEFT JOIN [BE_Partner] with(nolock) on [BE_PartnerTask].[PartnerID] = [BE_Partner].[PartnerID]
										LEFT JOIN [BE_RoomDesigner] with(nolock) on  [BE_RoomDesigner].[DesignerID] = [BE_PartnerTask].[ReferenceID]
                                        left join [BE_Customer] C on C.CustomerID=[BE_RoomDesigner].CustomerID
                                        left join [BE_RoomDesignerKJLRelation] K on K.DesignerNo=[BE_RoomDesigner].DesignerNo
										left join BE_PartnerUser on BE_PartnerUser.UserID=BE_RoomDesigner.Designer
                                    WHERE 
	                                    1=1");
            //经销商筛选
            //if (args.PartnerID.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerTask].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            //}

            //任务权限
            if (!string.IsNullOrEmpty(args.StepNo))
            {
                string sqlParm =string.Format(" and [BE_PartnerTask].[stepNo]  in({0}) ", args.StepNo);
                mbBuilder.Append(sqlParm);
            }

            //公司

            if (!string.IsNullOrEmpty(args.CompanyID.ToString()) && String.Equals(args.CompanyID.ToString(), "4A8A1AC8-6807-49C1-B81F-D054B073426A", StringComparison.CurrentCultureIgnoreCase) != true)
            {
                string sqlParm = " and BE_PartnerUser.CompanyID='" + args.CompanyID + "' ";
                mbBuilder.Append(sqlParm);
            }
            //经销商PartnerIDs
            //if (!string.IsNullOrEmpty(args.PartnerIDs))
            //{
            //    string PartnerIDs = args.PartnerIDs;
            //    string sqlParm = " and [BE_PartnerUser].[PartnerID]  in(select a from [dbo].[f_split]('" + PartnerIDs + "',',')) ";
            //    mbBuilder.Append(sqlParm);
            //}
            //经销商UserCodes
            //if (!string.IsNullOrEmpty(args.UserCodes))
            //{
            //    string UserCodes = args.UserCodes;
            //    string sqlParm = " and [BE_PartnerUser].[UserCode]  in(select a from [dbo].[f_split]('" + UserCodes + "',',')) ";
            //    mbBuilder.Append(sqlParm);
            //}
            this.SetParameters_In(mbBuilder, cmd, "StepName", "mbStepKey", args.StepNames);
            if (args.TaskID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "TaskID", "mbTaskIDs", args.TaskID.Value);
            }
            if (args.ReferenceID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "ReferenceID", "mbReferenceIDs", args.ReferenceID.Value);
            }
            if (!string.IsNullOrEmpty(args.TaskNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "TaskNo", "mbTaskTitle", args.TaskNo);
            }
            if (!string.IsNullOrEmpty(args.TaskType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "TaskType", "mbTaskType", args.TaskType);
            }

            //经销商 登录用户名筛选
            //if (!string.IsNullOrEmpty(args.Resource))
            //{
            //    mbBuilder.AppendFormat(@" and [BE_PartnerTask].[TaskID] in (
            //                                select 
            //                                 [TaskID] 
            //                                from 
            //                                 [BE_PartnerTaskResource]  with(nolock) 
            //                                where 
            //                                 [Resource] in (
            //                                     select 
            //                                       [RoleName] 
            //                                      from 
            //                                       [BE_PartnerRole]  with(nolock) 
            //                                      where 
            //                                       [RoleID] in(
            //		                                        select 
            //				                                        [RoleID] 
            //			                                        from 
            //				                                        [BE_PartnerUser2Role]  with(nolock) 
            //				                                        LEFT JOIN [BE_PartnerUser]  with(nolock)  on [BE_PartnerUser2Role].[UserID] = [BE_PartnerUser].[UserID]
            //			                                        where 
            //				                                        [UserCode] = N'{0}'
            //	                                          )
            //                                     )
            //                                 or [Resource] = N'{0}'
            //                                 )", args.Resource);

            //}

            if (!string.IsNullOrEmpty(args.EndedBy))
            {
                mbBuilder.AppendFormat(@" and [BE_PartnerTask].[TaskID] in (select distinct [TaskID] from [BE_PartnerTaskStep] where EndedBy=N'{0}')", args.EndedBy);
            }
            this.SetParameters_Between(mbBuilder, cmd, "BE_PartnerTask].[Created", "taCreated", args.CreatedFrom, args.CreatedTo);

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
