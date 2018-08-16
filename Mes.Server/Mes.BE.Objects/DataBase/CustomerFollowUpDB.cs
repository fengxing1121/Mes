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
        
        #region BE_CustomerFollowUp InsertObject()
        public int InsertCustomerFollowUp(CustomerFollowUp obj)
        {
            string sql = @"INSERT INTO[BE_CustomerFollowUp]([FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@FollowID
				, @CustomerID
				, @FollowType
				, @Title
				, @Remark
				, @ImportantResult
				, @Suggest
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", Convert2DBnull(obj.FollowID));
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pFollowType = new SqlParameter("FollowType", Convert2DBnull(obj.FollowType));
            pFollowType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFollowType);

            SqlParameter pTitle = new SqlParameter("Title", Convert2DBnull(obj.Title));
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pImportantResult = new SqlParameter("ImportantResult", Convert2DBnull(obj.ImportantResult));
            pImportantResult.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImportantResult);

            SqlParameter pSuggest = new SqlParameter("Suggest", Convert2DBnull(obj.Suggest));
            pSuggest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSuggest);

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

        #region BE_CustomerFollowUp UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCustomerFollowUpByFollowID(CustomerFollowUp obj)
        {
            string sql = @"UPDATE [BE_CustomerFollowUp] SET [CustomerID]=@CustomerID
				, [FollowType]=@FollowType
				, [Title]=@Title
				, [Remark]=@Remark
				, [ImportantResult]=@ImportantResult
				, [Suggest]=@Suggest
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pFollowType = new SqlParameter("FollowType", Convert2DBnull(obj.FollowType));
            pFollowType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFollowType);

            SqlParameter pTitle = new SqlParameter("Title", Convert2DBnull(obj.Title));
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pImportantResult = new SqlParameter("ImportantResult", Convert2DBnull(obj.ImportantResult));
            pImportantResult.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImportantResult);

            SqlParameter pSuggest = new SqlParameter("Suggest", Convert2DBnull(obj.Suggest));
            pSuggest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSuggest);

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

            SqlParameter pFollowID = new SqlParameter("FollowID", Convert2DBnull(obj.FollowID));
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpByFollowID(Guid followID)
        {
            string sql = @"DELETE [BE_CustomerFollowUp] WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", followID);
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCustomerFollowUpByFollowID(CustomerFollowUp obj)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", Convert2DBnull(obj.FollowID));
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        obj.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    obj.FollowType = dr["FollowType"].ToString();
                    obj.Title = dr["Title"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.ImportantResult = dr["ImportantResult"].ToString();
                    obj.Suggest = dr["Suggest"].ToString();
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

        #region BE_CustomerFollowUp CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCustomerFollowUps()
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByFollowID(Guid followID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", followID);
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByCustomerID(Guid customerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByFollowType(string followType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [FollowType]=@FollowType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowType = new SqlParameter("FollowType", followType);
            pFollowType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFollowType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByTitle(string title)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByImportantResult(string importantResult)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [ImportantResult]=@ImportantResult";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImportantResult = new SqlParameter("ImportantResult", importantResult);
            pImportantResult.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImportantResult);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsBySuggest(string suggest)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Suggest]=@Suggest";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSuggest = new SqlParameter("Suggest", suggest);
            pSuggest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSuggest);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomerFollowUpsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCustomerFollowUps()
        {
            string sql = "SELECT TOP 1 * FROM [BE_CustomerFollowUp]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByFollowID(Guid followID)
        {
            string sql = "SELECT TOP 1 [FollowID] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", followID);
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByCustomerID(Guid customerID)
        {
            string sql = "SELECT TOP 1 [CustomerID] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByFollowType(string followType)
        {
            string sql = "SELECT TOP 1 [FollowType] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [FollowType]=@FollowType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowType = new SqlParameter("FollowType", followType);
            pFollowType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFollowType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByTitle(string title)
        {
            string sql = "SELECT TOP 1 [Title] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByImportantResult(string importantResult)
        {
            string sql = "SELECT TOP 1 [ImportantResult] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [ImportantResult]=@ImportantResult";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImportantResult = new SqlParameter("ImportantResult", importantResult);
            pImportantResult.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImportantResult);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsBySuggest(string suggest)
        {
            string sql = "SELECT TOP 1 [Suggest] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Suggest]=@Suggest";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSuggest = new SqlParameter("Suggest", suggest);
            pSuggest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSuggest);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomerFollowUpsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_CustomerFollowUp] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCustomerFollowUps()
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByFollowID(Guid followID)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", followID);
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByCustomerID(Guid customerID)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByFollowType(string followType)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [FollowType]=@FollowType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowType = new SqlParameter("FollowType", followType);
            pFollowType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFollowType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByTitle(string title)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByImportantResult(string importantResult)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [ImportantResult]=@ImportantResult";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImportantResult = new SqlParameter("ImportantResult", importantResult);
            pImportantResult.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImportantResult);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsBySuggest(string suggest)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [Suggest]=@Suggest";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSuggest = new SqlParameter("Suggest", suggest);
            pSuggest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSuggest);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerFollowUpsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_CustomerFollowUp] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<CustomerFollowUp> LoadCustomerFollowUps()
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByFollowID(Guid followID)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [FollowID]=@FollowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowID = new SqlParameter("FollowID", followID);
            pFollowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pFollowID);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByCustomerID(Guid customerID)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByFollowType(string followType)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [FollowType]=@FollowType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFollowType = new SqlParameter("FollowType", followType);
            pFollowType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFollowType);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByTitle(string title)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [Title]=@Title";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTitle = new SqlParameter("Title", title);
            pTitle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTitle);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByRemark(string remark)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByImportantResult(string importantResult)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [ImportantResult]=@ImportantResult";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImportantResult = new SqlParameter("ImportantResult", importantResult);
            pImportantResult.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImportantResult);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsBySuggest(string suggest)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [Suggest]=@Suggest";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSuggest = new SqlParameter("Suggest", suggest);
            pSuggest.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSuggest);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByCreated(DateTime created)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByModified(DateTime modified)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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
        public List<CustomerFollowUp> LoadCustomerFollowUpsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [FollowID]
				, [CustomerID]
				, [FollowType]
				, [Title]
				, [Remark]
				, [ImportantResult]
				, [Suggest]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_CustomerFollowUp] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<CustomerFollowUp> ret = new List<CustomerFollowUp>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    CustomerFollowUp iret = new CustomerFollowUp();
                    if (!Convert.IsDBNull(dr["FollowID"]))
                        iret.FollowID = (Guid)dr["FollowID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    iret.FollowType = dr["FollowType"].ToString();
                    iret.Title = dr["Title"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.ImportantResult = dr["ImportantResult"].ToString();
                    iret.Suggest = dr["Suggest"].ToString();
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

        #region BE_CustomerFollowUp SearchObject()
        public SearchResult SearchCustomerFollowUp(SearchCustomerFollowUpArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BE_Customer].[PartnerID],[BE_CustomerFollowUp].[CustomerID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_CustomerFollowUp].[FollowID]
                                          ,[BE_CustomerFollowUp].[CustomerID]
                                          ,[BE_CustomerFollowUp].[FollowType]
                                          ,[BE_CustomerFollowUp].[Title]
                                          ,[BE_CustomerFollowUp].[Remark]
                                          ,[BE_CustomerFollowUp].[ImportantResult]
                                          ,[BE_CustomerFollowUp].[Suggest]
                                          ,[BE_CustomerFollowUp].[Created]
                                          ,[BE_CustomerFollowUp].[CreatedBy]
                                          ,[BE_CustomerFollowUp].[Modified]
                                          ,[BE_CustomerFollowUp].[ModifiedBy]
	                                      ,[BE_Customer].[CustomerName]
	                                      ,[BE_Customer].[PartnerID]
	                                      ,[BE_Partner].[PartnerName]
                                      FROM 
	                                     [BE_CustomerFollowUp] with(nolock)
	                                     LEFT JOIN [BE_Customer] with(nolock) on [BE_CustomerFollowUp].[CustomerID] = [BE_Customer].[CustomerID]
	                                     LEFT JOIN [BE_Partner] with(nolock) on [BE_Partner].[PartnerID] = [BE_Customer].[PartnerID]
	                                  WHERE 1=1");



            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.FollowType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "FollowType", "mbFollowType", args.FollowType);
            }
            if (!string.IsNullOrEmpty(args.Title))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Title", "mbTitle", args.Title);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_CustomerFollowUp].[CustomerID", "mCustomerID", args.CustomerID.Value);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Customer].[PartnerID", "mPartnerID", args.PartnerID.Value);
            }
            //this.SetParameters_Between(mbBuilder, cmd, "Designed", "mbDesigned", args.DesignedFrom, args.DesignedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
