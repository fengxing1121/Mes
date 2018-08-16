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
        #region BE_PartnerTaskStep InsertObject()
        public int InsertPartnerTaskStep(PartnerTaskStep obj)
        {
            string sql = @"INSERT INTO[BE_PartnerTaskStep]([StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				) VALUES(@StepID
				, @TaskID
				, @StepNo
				, @StepName
				, @Action
				, @TargetStep
				, @StartedBy
				, @Started
				, @EndedBy
				, @Ended
				, @RemarkType
				, @Remark
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTargetStep = new SqlParameter("TargetStep", Convert2DBnull(obj.TargetStep));
            pTargetStep.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTargetStep);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", Convert2DBnull(obj.EndedBy));
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pRemarkType = new SqlParameter("RemarkType", Convert2DBnull(obj.RemarkType));
            pRemarkType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemarkType);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PartnerTaskStep UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerTaskStepByStepID(PartnerTaskStep obj)
        {
            string sql = @"UPDATE [BE_PartnerTaskStep] SET [TaskID]=@TaskID
				, [StepNo]=@StepNo
				, [StepName]=@StepName
				, [Action]=@Action
				, [TargetStep]=@TargetStep
				, [StartedBy]=@StartedBy
				, [Started]=@Started
				, [EndedBy]=@EndedBy
				, [Ended]=@Ended
				, [RemarkType]=@RemarkType
				, [Remark]=@Remark
 				WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", Convert2DBnull(obj.TaskID));
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pAction = new SqlParameter("Action", Convert2DBnull(obj.Action));
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            SqlParameter pTargetStep = new SqlParameter("TargetStep", Convert2DBnull(obj.TargetStep));
            pTargetStep.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTargetStep);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", Convert2DBnull(obj.EndedBy));
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pRemarkType = new SqlParameter("RemarkType", Convert2DBnull(obj.RemarkType));
            pRemarkType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemarkType);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepByStepID(Guid stepID)
        {
            string sql = @"DELETE [BE_PartnerTaskStep] WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", stepID);
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerTaskStepByStepID(PartnerTaskStep obj)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
 				FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["StepID"]))
                        obj.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        obj.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    obj.StepName = dr["StepName"].ToString();
                    obj.Action = dr["Action"].ToString();
                    obj.TargetStep = dr["TargetStep"].ToString();
                    obj.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        obj.Started = (DateTime)dr["Started"];
                    obj.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        obj.Ended = (DateTime)dr["Ended"];
                    obj.RemarkType = dr["RemarkType"].ToString();
                    obj.Remark = dr["Remark"].ToString();
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

        #region BE_PartnerTaskStep CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerTaskSteps()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByStepID(Guid stepID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", stepID);
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByTaskID(Guid taskID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByStepNo(int stepNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByStepName(string stepName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByAction(string action)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByTargetStep(string targetStep)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [TargetStep]=@TargetStep";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetStep = new SqlParameter("TargetStep", targetStep);
            pTargetStep.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTargetStep);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByStartedBy(string startedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByStarted(DateTime started)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByEndedBy(string endedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [EndedBy]=@EndedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", endedBy);
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByEnded(DateTime ended)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByRemarkType(string remarkType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [RemarkType]=@RemarkType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarkType = new SqlParameter("RemarkType", remarkType);
            pRemarkType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemarkType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerTaskStepsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerTaskSteps()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerTaskStep]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByStepID(Guid stepID)
        {
            string sql = "SELECT TOP 1 [StepID] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", stepID);
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByTaskID(Guid taskID)
        {
            string sql = "SELECT TOP 1 [TaskID] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByStepNo(int stepNo)
        {
            string sql = "SELECT TOP 1 [StepNo] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByStepName(string stepName)
        {
            string sql = "SELECT TOP 1 [StepName] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByAction(string action)
        {
            string sql = "SELECT TOP 1 [Action] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByTargetStep(string targetStep)
        {
            string sql = "SELECT TOP 1 [TargetStep] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [TargetStep]=@TargetStep";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetStep = new SqlParameter("TargetStep", targetStep);
            pTargetStep.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTargetStep);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByStartedBy(string startedBy)
        {
            string sql = "SELECT TOP 1 [StartedBy] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByStarted(DateTime started)
        {
            string sql = "SELECT TOP 1 [Started] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByEndedBy(string endedBy)
        {
            string sql = "SELECT TOP 1 [EndedBy] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [EndedBy]=@EndedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", endedBy);
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByEnded(DateTime ended)
        {
            string sql = "SELECT TOP 1 [Ended] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByRemarkType(string remarkType)
        {
            string sql = "SELECT TOP 1 [RemarkType] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [RemarkType]=@RemarkType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarkType = new SqlParameter("RemarkType", remarkType);
            pRemarkType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemarkType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerTaskStepsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_PartnerTaskStep] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerTaskSteps()
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByStepID(Guid stepID)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", stepID);
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByTaskID(Guid taskID)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByStepNo(int stepNo)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByStepName(string stepName)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByAction(string action)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByTargetStep(string targetStep)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [TargetStep]=@TargetStep";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetStep = new SqlParameter("TargetStep", targetStep);
            pTargetStep.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTargetStep);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByStartedBy(string startedBy)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByStarted(DateTime started)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByEndedBy(string endedBy)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [EndedBy]=@EndedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", endedBy);
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByEnded(DateTime ended)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByRemarkType(string remarkType)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [RemarkType]=@RemarkType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarkType = new SqlParameter("RemarkType", remarkType);
            pRemarkType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemarkType);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerTaskStepsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_PartnerTaskStep] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerTaskStep> LoadPartnerTaskSteps()
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByStepID(Guid stepID)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [StepID]=@StepID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", stepID);
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByTaskID(Guid taskID)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [TaskID]=@TaskID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTaskID = new SqlParameter("TaskID", taskID);
            pTaskID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTaskID);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByStepNo(int stepNo)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [StepNo]=@StepNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepNo = new SqlParameter("StepNo", stepNo);
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByStepName(string stepName)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [StepName]=@StepName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepName = new SqlParameter("StepName", stepName);
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByAction(string action)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [Action]=@Action";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAction = new SqlParameter("Action", action);
            pAction.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAction);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByTargetStep(string targetStep)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [TargetStep]=@TargetStep";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTargetStep = new SqlParameter("TargetStep", targetStep);
            pTargetStep.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTargetStep);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByStartedBy(string startedBy)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [StartedBy]=@StartedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", startedBy);
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByStarted(DateTime started)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [Started]=@Started";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", started);
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByEndedBy(string endedBy)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [EndedBy]=@EndedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndedBy = new SqlParameter("EndedBy", endedBy);
            pEndedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEndedBy);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByEnded(DateTime ended)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [Ended]=@Ended";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnded = new SqlParameter("Ended", ended);
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByRemarkType(string remarkType)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [RemarkType]=@RemarkType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarkType = new SqlParameter("RemarkType", remarkType);
            pRemarkType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemarkType);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerTaskStep> LoadPartnerTaskStepsByRemark(string remark)
        {
            string sql = @"SELECT [StepID]
				, [TaskID]
				, [StepNo]
				, [StepName]
				, [Action]
				, [TargetStep]
				, [StartedBy]
				, [Started]
				, [EndedBy]
				, [Ended]
				, [RemarkType]
				, [Remark]
				 FROM [BE_PartnerTaskStep] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<PartnerTaskStep> ret = new List<PartnerTaskStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerTaskStep iret = new PartnerTaskStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["TaskID"]))
                        iret.TaskID = (Guid)dr["TaskID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    iret.StepName = dr["StepName"].ToString();
                    iret.Action = dr["Action"].ToString();
                    iret.TargetStep = dr["TargetStep"].ToString();
                    iret.StartedBy = dr["StartedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    iret.EndedBy = dr["EndedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    iret.RemarkType = dr["RemarkType"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
