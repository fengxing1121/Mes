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
      
        #region BE_Solution InsertObject()
        public int InsertSolution(Solution obj)
        {
            string sql = @"INSERT INTO[BE_Solution]([SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@SolutionID
				, @PartnerID
				, @DesignerID
				, @CustomerID
				, @SolutionCode
				, @SolutionName
				, @DesignSoft
				, @Remark
				, @Version
				, @Designer
				, @Status
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", Convert2DBnull(obj.SolutionCode));
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", Convert2DBnull(obj.SolutionName));
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", Convert2DBnull(obj.DesignSoft));
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pVersion = new SqlParameter("Version", Convert2DBnull(obj.Version));
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            SqlParameter pDesigner = new SqlParameter("Designer", Convert2DBnull(obj.Designer));
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

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

        #region BE_Solution UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSolutionBySolutionCode(Solution obj)
        {
            string sql = @"UPDATE [BE_Solution] SET [SolutionID]=@SolutionID
				, [PartnerID]=@PartnerID
				, [DesignerID]=@DesignerID
				, [CustomerID]=@CustomerID
				, [SolutionName]=@SolutionName
				, [DesignSoft]=@DesignSoft
				, [Remark]=@Remark
				, [Version]=@Version
				, [Designer]=@Designer
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", Convert2DBnull(obj.SolutionName));
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", Convert2DBnull(obj.DesignSoft));
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pVersion = new SqlParameter("Version", Convert2DBnull(obj.Version));
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            SqlParameter pDesigner = new SqlParameter("Designer", Convert2DBnull(obj.Designer));
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

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

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", Convert2DBnull(obj.SolutionCode));
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateSolutionByDesignerID(Solution obj)
        {
            string sql = @"UPDATE [BE_Solution] SET [SolutionID]=@SolutionID
				, [PartnerID]=@PartnerID
				, [CustomerID]=@CustomerID
				, [SolutionCode]=@SolutionCode
				, [SolutionName]=@SolutionName
				, [DesignSoft]=@DesignSoft
				, [Remark]=@Remark
				, [Version]=@Version
				, [Designer]=@Designer
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", Convert2DBnull(obj.SolutionCode));
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", Convert2DBnull(obj.SolutionName));
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", Convert2DBnull(obj.DesignSoft));
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pVersion = new SqlParameter("Version", Convert2DBnull(obj.Version));
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            SqlParameter pDesigner = new SqlParameter("Designer", Convert2DBnull(obj.Designer));
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

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

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateSolutionBySolutionID(Solution obj)
        {
            string sql = @"UPDATE [BE_Solution] SET [PartnerID]=@PartnerID
				, [DesignerID]=@DesignerID
				, [CustomerID]=@CustomerID
				, [SolutionCode]=@SolutionCode
				, [SolutionName]=@SolutionName
				, [DesignSoft]=@DesignSoft
				, [Remark]=@Remark
				, [Version]=@Version
				, [Designer]=@Designer
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", Convert2DBnull(obj.SolutionCode));
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", Convert2DBnull(obj.SolutionName));
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", Convert2DBnull(obj.DesignSoft));
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pVersion = new SqlParameter("Version", Convert2DBnull(obj.Version));
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            SqlParameter pDesigner = new SqlParameter("Designer", Convert2DBnull(obj.Designer));
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

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

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionBySolutionCode(string solutionCode)
        {
            string sql = @"DELETE [BE_Solution] WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", solutionCode);
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionByDesignerID(Guid designerID)
        {
            string sql = @"DELETE [BE_Solution] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionBySolutionID(Guid solutionID)
        {
            string sql = @"DELETE [BE_Solution] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSolutionBySolutionCode(Solution obj)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", Convert2DBnull(obj.SolutionCode));
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        obj.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    obj.SolutionCode = dr["SolutionCode"].ToString();
                    obj.SolutionName = dr["SolutionName"].ToString();
                    obj.DesignSoft = dr["DesignSoft"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.Version = dr["Version"].ToString();
                    obj.Designer = dr["Designer"].ToString();
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
        public int LoadSolutionByDesignerID(Solution obj)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Solution] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        obj.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    obj.SolutionCode = dr["SolutionCode"].ToString();
                    obj.SolutionName = dr["SolutionName"].ToString();
                    obj.DesignSoft = dr["DesignSoft"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.Version = dr["Version"].ToString();
                    obj.Designer = dr["Designer"].ToString();
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
        public int LoadSolutionBySolutionID(Solution obj)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        obj.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    obj.SolutionCode = dr["SolutionCode"].ToString();
                    obj.SolutionName = dr["SolutionName"].ToString();
                    obj.DesignSoft = dr["DesignSoft"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.Version = dr["Version"].ToString();
                    obj.Designer = dr["Designer"].ToString();
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

        #region BE_Solution CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSolutions()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByDesignerID(Guid designerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByCustomerID(Guid customerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsBySolutionCode(string solutionCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", solutionCode);
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsBySolutionName(string solutionName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionName]=@SolutionName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", solutionName);
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByDesignSoft(string designSoft)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [DesignSoft]=@DesignSoft";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", designSoft);
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByVersion(string version)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [Version]=@Version";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVersion = new SqlParameter("Version", version);
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByDesigner(string designer)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByStatus(string status)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSolutions()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Solution]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_Solution] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByDesignerID(Guid designerID)
        {
            string sql = "SELECT TOP 1 [DesignerID] FROM [BE_Solution] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByCustomerID(Guid customerID)
        {
            string sql = "SELECT TOP 1 [CustomerID] FROM [BE_Solution] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsBySolutionCode(string solutionCode)
        {
            string sql = "SELECT TOP 1 [SolutionCode] FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", solutionCode);
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsBySolutionName(string solutionName)
        {
            string sql = "SELECT TOP 1 [SolutionName] FROM [BE_Solution] WITH(NOLOCK) WHERE [SolutionName]=@SolutionName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", solutionName);
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByDesignSoft(string designSoft)
        {
            string sql = "SELECT TOP 1 [DesignSoft] FROM [BE_Solution] WITH(NOLOCK) WHERE [DesignSoft]=@DesignSoft";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", designSoft);
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Solution] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByVersion(string version)
        {
            string sql = "SELECT TOP 1 [Version] FROM [BE_Solution] WITH(NOLOCK) WHERE [Version]=@Version";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVersion = new SqlParameter("Version", version);
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByDesigner(string designer)
        {
            string sql = "SELECT TOP 1 [Designer] FROM [BE_Solution] WITH(NOLOCK) WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByStatus(string status)
        {
            string sql = "SELECT TOP 1 [Status] FROM [BE_Solution] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Solution] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Solution] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Solution] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Solution] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSolutions()
        {
            string sql = "DELETE FROM [BE_Solution]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByDesignerID(Guid designerID)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByCustomerID(Guid customerID)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsBySolutionCode(string solutionCode)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", solutionCode);
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsBySolutionName(string solutionName)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [SolutionName]=@SolutionName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", solutionName);
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByDesignSoft(string designSoft)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [DesignSoft]=@DesignSoft";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", designSoft);
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByVersion(string version)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [Version]=@Version";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVersion = new SqlParameter("Version", version);
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByDesigner(string designer)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByStatus(string status)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Solution] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Solution> LoadSolutions()
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByDesignerID(Guid designerID)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByCustomerID(Guid customerID)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsBySolutionCode(string solutionCode)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [SolutionCode]=@SolutionCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionCode = new SqlParameter("SolutionCode", solutionCode);
            pSolutionCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionCode);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsBySolutionName(string solutionName)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [SolutionName]=@SolutionName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionName = new SqlParameter("SolutionName", solutionName);
            pSolutionName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSolutionName);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByDesignSoft(string designSoft)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [DesignSoft]=@DesignSoft";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignSoft = new SqlParameter("DesignSoft", designSoft);
            pDesignSoft.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesignSoft);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByRemark(string remark)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByVersion(string version)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [Version]=@Version";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVersion = new SqlParameter("Version", version);
            pVersion.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVersion);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByDesigner(string designer)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDesigner);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByStatus(string status)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByCreated(DateTime created)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByModified(DateTime modified)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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
        public List<Solution> LoadSolutionsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [SolutionID]
				, [PartnerID]
				, [DesignerID]
				, [CustomerID]
				, [SolutionCode]
				, [SolutionName]
				, [DesignSoft]
				, [Remark]
				, [Version]
				, [Designer]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Solution] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Solution> ret = new List<Solution>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution iret = new Solution();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.SolutionCode = dr["SolutionCode"].ToString();
                    iret.SolutionName = dr["SolutionName"].ToString();
                    iret.DesignSoft = dr["DesignSoft"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Version = dr["Version"].ToString();
                    iret.Designer = dr["Designer"].ToString();
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

        #region BE_Solution SearchObject()
        public SearchResult SearchSolution(SearchSolutionArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[SolutionID] ASC,[Designer]";
                //args.OrderBy = "Modified desc";

            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
                                          [BE_Solution].[SolutionID]
                                          ,[BE_Solution].[PartnerID]
                                          ,[BE_Solution].[DesignerID]
                                          ,R.[DesignerNo]
                                          ,[BE_Solution].[CustomerID]
	                                      ,[BE_Customer].[CustomerName]
	                                      ,[BE_Customer].[LinkMan]
	                                      ,[BE_Customer].[Mobile]
	                                      ,[BE_Customer].[Address]	  	   
                                          ,[BE_Solution].[SolutionCode]
                                          ,[BE_Solution].[SolutionName]
                                          ,[BE_Solution].[DesignSoft]
                                          ,[BE_Solution].[Remark]
                                          ,[BE_Solution].[Version]
                                          ,[BE_Solution].[Designer]
                                          ,[BE_Solution].[Status]
                                          ,[BE_Solution].[Created]
                                          ,[BE_Solution].[CreatedBy]
                                          ,[BE_Solution].[Modified]
                                          ,[BE_Solution].[ModifiedBy]
										  ,K.KJLDesignID
										,[BE_Partner].[PartnerName]
										,UserName as [DesignerName]
                                      FROM 
	                                       [BE_Solution] with(nolock)
	                                       LEFT JOIN [BE_Customer] with(nolock) on [BE_Solution].[CustomerID] = [BE_Customer].[CustomerID]
										   left join [dbo].[BE_RoomDesigner] R on R.DesignerID=[BE_Solution].DesignerID
										   left join [BE_RoomDesignerKJLRelation] K on K.DesignerNo=R.DesignerNo
										LEFT JOIN [BE_Partner] on [BE_Solution].[PartnerID] = [BE_Partner].[PartnerID]
										left join BE_PartnerUser on BE_PartnerUser.UserID=R.Designer
                                      WHERE 1=1");


            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution].[SolutionID", "mbSolutionID", args.SolutionID.Value);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }

            //公司
            if (!string.IsNullOrEmpty(args.CompanyID.ToString()) && String.Equals(args.CompanyID.ToString(), "4A8A1AC8-6807-49C1-B81F-D054B073426A", StringComparison.CurrentCultureIgnoreCase) != true)
            {
                string sqlParm = " and BE_PartnerUser.CompanyID='" + args.CompanyID + "' ";
                mbBuilder.Append(sqlParm);
            }
            //经销商UserCodes
            //if (!string.IsNullOrEmpty(args.UserCodes))
            //{
            //    string UserCodes = args.UserCodes;
            //    string sqlParm = " and [BE_PartnerUser].[UserCode]  in(select a from [dbo].[f_split]('" + UserCodes + "',',')) ";
            //    mbBuilder.Append(sqlParm);
            //}

            if (args.DesignerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution].[DesignerID", "mbDesignerID", args.DesignerID.Value);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution].[CustomerID", "mbCustomerID", args.CustomerID.Value);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.SolutionCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionCode", "mbSolutionCode", args.SolutionCode);
            }
            if (!string.IsNullOrEmpty(args.SolutionName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Solution].[SolutionName", "mbSolutionName", args.SolutionName);
            }
            if (!string.IsNullOrEmpty(args.Designer))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Solution].[Designer", "mbDesigner", args.Designer);
            }
            if (!string.IsNullOrEmpty(args.Status))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Solution].[Status", "mbStatus", args.Status);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
