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
       
        #region BE_WorkCenter InsertObject()
        public int InsertWorkCenter(WorkCenter obj)
        {
            string sql = @"INSERT INTO[BE_WorkCenter]([WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@WorkCenterID
				, @WorkShopID
				, @WorkCenterCode
				, @WorkCenterName
				, @WorkFlowID
				, @MaxCapacity
				, @CountCapacityType
				, @Style
				, @Model
				, @Remark
				, @SettingCode
				, @Sequence
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", Convert2DBnull(obj.WorkCenterID));
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", Convert2DBnull(obj.WorkCenterCode));
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", Convert2DBnull(obj.WorkCenterName));
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", Convert2DBnull(obj.MaxCapacity));
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", Convert2DBnull(obj.CountCapacityType));
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pModel = new SqlParameter("Model", Convert2DBnull(obj.Model));
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", Convert2DBnull(obj.SettingCode));
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

        #region BE_WorkCenter UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWorkCenterByWorkCenterCode(WorkCenter obj)
        {
            string sql = @"UPDATE [BE_WorkCenter] SET [WorkCenterID]=@WorkCenterID
				, [WorkShopID]=@WorkShopID
				, [WorkCenterName]=@WorkCenterName
				, [WorkFlowID]=@WorkFlowID
				, [MaxCapacity]=@MaxCapacity
				, [CountCapacityType]=@CountCapacityType
				, [Style]=@Style
				, [Model]=@Model
				, [Remark]=@Remark
				, [SettingCode]=@SettingCode
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", Convert2DBnull(obj.WorkCenterID));
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", Convert2DBnull(obj.WorkCenterName));
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", Convert2DBnull(obj.MaxCapacity));
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", Convert2DBnull(obj.CountCapacityType));
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pModel = new SqlParameter("Model", Convert2DBnull(obj.Model));
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", Convert2DBnull(obj.SettingCode));
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", Convert2DBnull(obj.WorkCenterCode));
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateWorkCenterByWorkCenterID(WorkCenter obj)
        {
            string sql = @"UPDATE [BE_WorkCenter] SET [WorkShopID]=@WorkShopID
				, [WorkCenterCode]=@WorkCenterCode
				, [WorkCenterName]=@WorkCenterName
				, [WorkFlowID]=@WorkFlowID
				, [MaxCapacity]=@MaxCapacity
				, [CountCapacityType]=@CountCapacityType
				, [Style]=@Style
				, [Model]=@Model
				, [Remark]=@Remark
				, [SettingCode]=@SettingCode
				, [Sequence]=@Sequence
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", Convert2DBnull(obj.WorkCenterCode));
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", Convert2DBnull(obj.WorkCenterName));
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", Convert2DBnull(obj.MaxCapacity));
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", Convert2DBnull(obj.CountCapacityType));
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pModel = new SqlParameter("Model", Convert2DBnull(obj.Model));
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", Convert2DBnull(obj.SettingCode));
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

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

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", Convert2DBnull(obj.WorkCenterID));
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterByWorkCenterCode(string workCenterCode)
        {
            string sql = @"DELETE [BE_WorkCenter] WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", workCenterCode);
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCenterByWorkCenterID(Guid workCenterID)
        {
            string sql = @"DELETE [BE_WorkCenter] WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWorkCenterByWorkCenterCode(WorkCenter obj)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", Convert2DBnull(obj.WorkCenterCode));
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        obj.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        obj.WorkShopID = (Guid)dr["WorkShopID"];
                    obj.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    obj.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        obj.MaxCapacity = (int)dr["MaxCapacity"];
                    obj.CountCapacityType = dr["CountCapacityType"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Model = dr["Model"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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
        public int LoadWorkCenterByWorkCenterID(WorkCenter obj)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", Convert2DBnull(obj.WorkCenterID));
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        obj.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        obj.WorkShopID = (Guid)dr["WorkShopID"];
                    obj.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    obj.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        obj.MaxCapacity = (int)dr["MaxCapacity"];
                    obj.CountCapacityType = dr["CountCapacityType"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Model = dr["Model"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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

        #region BE_WorkCenter CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWorkCenters()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByWorkCenterID(Guid workCenterID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByWorkCenterCode(string workCenterCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", workCenterCode);
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByWorkCenterName(string workCenterName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterName]=@WorkCenterName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", workCenterName);
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByMaxCapacity(int maxCapacity)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [MaxCapacity]=@MaxCapacity";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", maxCapacity);
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByCountCapacityType(string countCapacityType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [CountCapacityType]=@CountCapacityType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", countCapacityType);
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByModel(string model)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersBySettingCode(string settingCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [SettingCode]=@SettingCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", settingCode);
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkCentersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWorkCenters()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WorkCenter]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByWorkCenterID(Guid workCenterID)
        {
            string sql = "SELECT TOP 1 [WorkCenterID] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT TOP 1 [WorkShopID] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByWorkCenterCode(string workCenterCode)
        {
            string sql = "SELECT TOP 1 [WorkCenterCode] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", workCenterCode);
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByWorkCenterName(string workCenterName)
        {
            string sql = "SELECT TOP 1 [WorkCenterName] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkCenterName]=@WorkCenterName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", workCenterName);
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT TOP 1 [WorkFlowID] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByMaxCapacity(int maxCapacity)
        {
            string sql = "SELECT TOP 1 [MaxCapacity] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [MaxCapacity]=@MaxCapacity";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", maxCapacity);
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByCountCapacityType(string countCapacityType)
        {
            string sql = "SELECT TOP 1 [CountCapacityType] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [CountCapacityType]=@CountCapacityType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", countCapacityType);
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByModel(string model)
        {
            string sql = "SELECT TOP 1 [Model] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersBySettingCode(string settingCode)
        {
            string sql = "SELECT TOP 1 [SettingCode] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [SettingCode]=@SettingCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", settingCode);
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkCentersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_WorkCenter] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWorkCenters()
        {
            string sql = "DELETE FROM [BE_WorkCenter]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByWorkCenterID(Guid workCenterID)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByWorkShopID(Guid workShopID)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByWorkCenterCode(string workCenterCode)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", workCenterCode);
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByWorkCenterName(string workCenterName)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [WorkCenterName]=@WorkCenterName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", workCenterName);
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByWorkFlowID(Guid workFlowID)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByMaxCapacity(int maxCapacity)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [MaxCapacity]=@MaxCapacity";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", maxCapacity);
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByCountCapacityType(string countCapacityType)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [CountCapacityType]=@CountCapacityType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", countCapacityType);
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByStyle(string style)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByModel(string model)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersBySettingCode(string settingCode)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [SettingCode]=@SettingCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", settingCode);
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkCentersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_WorkCenter] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<WorkCenter> LoadWorkCenters()
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByWorkCenterID(Guid workCenterID)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [WorkCenterID]=@WorkCenterID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterID = new SqlParameter("WorkCenterID", workCenterID);
            pWorkCenterID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkCenterID);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByWorkShopID(Guid workShopID)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByWorkCenterCode(string workCenterCode)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [WorkCenterCode]=@WorkCenterCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterCode = new SqlParameter("WorkCenterCode", workCenterCode);
            pWorkCenterCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterCode);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByWorkCenterName(string workCenterName)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [WorkCenterName]=@WorkCenterName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkCenterName = new SqlParameter("WorkCenterName", workCenterName);
            pWorkCenterName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkCenterName);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByWorkFlowID(Guid workFlowID)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByMaxCapacity(int maxCapacity)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [MaxCapacity]=@MaxCapacity";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", maxCapacity);
            pMaxCapacity.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxCapacity);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByCountCapacityType(string countCapacityType)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [CountCapacityType]=@CountCapacityType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCountCapacityType = new SqlParameter("CountCapacityType", countCapacityType);
            pCountCapacityType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pCountCapacityType);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByStyle(string style)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByModel(string model)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [Model]=@Model";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModel = new SqlParameter("Model", model);
            pModel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModel);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByRemark(string remark)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersBySettingCode(string settingCode)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [SettingCode]=@SettingCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSettingCode = new SqlParameter("SettingCode", settingCode);
            pSettingCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSettingCode);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersBySequence(int sequence)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByCreated(DateTime created)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByModified(DateTime modified)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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
        public List<WorkCenter> LoadWorkCentersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [WorkCenterID]
				, [WorkShopID]
				, [WorkCenterCode]
				, [WorkCenterName]
				, [WorkFlowID]
				, [MaxCapacity]
				, [CountCapacityType]
				, [Style]
				, [Model]
				, [Remark]
				, [SettingCode]
				, [Sequence]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_WorkCenter] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<WorkCenter> ret = new List<WorkCenter>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkCenter iret = new WorkCenter();
                    if (!Convert.IsDBNull(dr["WorkCenterID"]))
                        iret.WorkCenterID = (Guid)dr["WorkCenterID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    iret.WorkCenterCode = dr["WorkCenterCode"].ToString();
                    iret.WorkCenterName = dr["WorkCenterName"].ToString();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (int)dr["MaxCapacity"];
                    iret.CountCapacityType = dr["CountCapacityType"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Model = dr["Model"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.SettingCode = dr["SettingCode"].ToString();
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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

        #region BE_WorkCenter SearchObject()
        public SearchResult SearchWorkCenter(SearchWorkCenterArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkCenterCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WorkCenter].[WorkCenterID]
                                          ,[BE_WorkCenter].[WorkCenterCode]
                                          ,[BE_WorkCenter].[WorkCenterName]
                                          ,[BE_WorkCenter].[WorkFlowID]
                                          ,[BE_WorkFlow].[WorkFlowName]
                                          ,[BE_WorkCenter].[MaxCapacity]
                                          ,[BE_WorkCenter].[CountCapacityType]
										  ,[BE_WorkCenter].[WorkShopID]
                                          ,[BE_WorkCenter].[Style]
                                          ,[BE_WorkCenter].[Model]
										  ,[BE_WorkShop].[WorkingLineID]
										  ,[BE_WorkShop].[WorkShopCode]
										  ,[BE_WorkShop].[WorkShopName]
                                          ,[BE_WorkCenter].[Remark]
                                          ,[BE_WorkCenter].[SettingCode]
                                          ,[BE_WorkCenter].[Sequence]
                                          ,[BE_WorkCenter].[Created]
                                          ,[BE_WorkCenter].[CreatedBy]
                                          ,[BE_WorkCenter].[Modified]
                                          ,[BE_WorkCenter].[ModifiedBy]										  
										  ,[BE_WorkingLine].[WorkingLineName]
                                      FROM 
									      [BE_WorkCenter] with(nolock)
                                          LEFT JOIN [BE_WorkFlow] with(nolock) on [BE_WorkCenter].[WorkFlowID] = [BE_WorkFlow].[WorkFlowID]
										  LEFT JOIN [BE_WorkShop] with(nolock) on [BE_WorkCenter].[WorkShopID] = [BE_WorkShop].[WorkShopID]
										  LEFT JOIN [BE_WorkingLine] with(nolock) on [BE_WorkShop].[WorkingLineID] = [BE_WorkingLine].[WorkingLineID]
	                                  WHERE 1=1");


            if (!string.IsNullOrEmpty(args.WorkCenterCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkCenterCode", "mbWorkCenterCode", args.WorkCenterCode);
            }
            if (!string.IsNullOrEmpty(args.WorkCenterName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkCenterName", "mbWorkCenterName", args.WorkCenterName);
            }
            if (args.WorkFlowID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkCenter].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID.Value);
            }
            if (args.WorkShopID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkShop].[WorkShopID", "mbWorkShopID", args.WorkShopID.Value);
            }
            if (args.WorkingLineID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkShop].[WorkingLineID", "mbWorkingLineID", args.WorkingLineID.Value);
            }
            if (args.WorkCenterID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkCenter].[WorkCenterID", "mbWorkCenterID", args.WorkCenterID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkFlowCode", "mbWorkFlowCode", args.WorkFlowCode);
            }
            if (!string.IsNullOrEmpty(args.WorkFlowName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkFlowName", "mbWorkFlowName", args.WorkFlowName);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
