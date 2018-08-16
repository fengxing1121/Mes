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

        #region BE_LogisticsEnterprise InsertObject()
        public int InsertLogisticsEnterprise(LogisticsEnterprise obj)
        {
            string sql = @"INSERT INTO[BE_LogisticsEnterprise]([EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@EnterpriseID
				, @EnterpriseName
				, @Address
				, @LinkMan
				, @Mobile
				, @Tel
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", Convert2DBnull(obj.EnterpriseID));
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            SqlParameter pEnterpriseName = new SqlParameter("EnterpriseName", Convert2DBnull(obj.EnterpriseName));
            pEnterpriseName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnterpriseName);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

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

        #region BE_LogisticsEnterprise UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateLogisticsEnterpriseByEnterpriseID(LogisticsEnterprise obj)
        {
            string sql = @"UPDATE [BE_LogisticsEnterprise] SET [EnterpriseName]=@EnterpriseName
				, [Address]=@Address
				, [LinkMan]=@LinkMan
				, [Mobile]=@Mobile
				, [Tel]=@Tel
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseName = new SqlParameter("EnterpriseName", Convert2DBnull(obj.EnterpriseName));
            pEnterpriseName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnterpriseName);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

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

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", Convert2DBnull(obj.EnterpriseID));
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterpriseByEnterpriseID(Guid enterpriseID)
        {
            string sql = @"DELETE [BE_LogisticsEnterprise] WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadLogisticsEnterpriseByEnterpriseID(LogisticsEnterprise obj)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", Convert2DBnull(obj.EnterpriseID));
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        obj.EnterpriseID = (Guid)dr["EnterpriseID"];
                    obj.EnterpriseName = dr["EnterpriseName"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Tel = dr["Tel"].ToString();
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

        #region BE_LogisticsEnterprise CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountLogisticsEnterprises()
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByEnterpriseID(Guid enterpriseID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByEnterpriseName(string enterpriseName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [EnterpriseName]=@EnterpriseName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseName = new SqlParameter("EnterpriseName", enterpriseName);
            pEnterpriseName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnterpriseName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByAddress(string address)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByLinkMan(string linkMan)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByTel(string tel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLogisticsEnterprisesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsLogisticsEnterprises()
        {
            string sql = "SELECT TOP 1 * FROM [BE_LogisticsEnterprise]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByEnterpriseID(Guid enterpriseID)
        {
            string sql = "SELECT TOP 1 [EnterpriseID] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByEnterpriseName(string enterpriseName)
        {
            string sql = "SELECT TOP 1 [EnterpriseName] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [EnterpriseName]=@EnterpriseName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseName = new SqlParameter("EnterpriseName", enterpriseName);
            pEnterpriseName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnterpriseName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByAddress(string address)
        {
            string sql = "SELECT TOP 1 [Address] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByLinkMan(string linkMan)
        {
            string sql = "SELECT TOP 1 [LinkMan] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByTel(string tel)
        {
            string sql = "SELECT TOP 1 [Tel] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLogisticsEnterprisesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_LogisticsEnterprise] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteLogisticsEnterprises()
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByEnterpriseID(Guid enterpriseID)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByEnterpriseName(string enterpriseName)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [EnterpriseName]=@EnterpriseName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseName = new SqlParameter("EnterpriseName", enterpriseName);
            pEnterpriseName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnterpriseName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByAddress(string address)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByLinkMan(string linkMan)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByTel(string tel)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLogisticsEnterprisesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_LogisticsEnterprise] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<LogisticsEnterprise> LoadLogisticsEnterprises()
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByEnterpriseID(Guid enterpriseID)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByEnterpriseName(string enterpriseName)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [EnterpriseName]=@EnterpriseName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseName = new SqlParameter("EnterpriseName", enterpriseName);
            pEnterpriseName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEnterpriseName);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByAddress(string address)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByLinkMan(string linkMan)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByMobile(string mobile)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByTel(string tel)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByCreated(DateTime created)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByModified(DateTime modified)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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
        public List<LogisticsEnterprise> LoadLogisticsEnterprisesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [EnterpriseID]
				, [EnterpriseName]
				, [Address]
				, [LinkMan]
				, [Mobile]
				, [Tel]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_LogisticsEnterprise] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<LogisticsEnterprise> ret = new List<LogisticsEnterprise>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    LogisticsEnterprise iret = new LogisticsEnterprise();
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.EnterpriseName = dr["EnterpriseName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Tel = dr["Tel"].ToString();
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

        #region BE_LogisticsEnterprise SearchObject()
        public SearchResult SearchLogisticsEnterprise(SearchLogisticsEnterpriseArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[EnterpriseName] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [EnterpriseID]                                        
                                          ,[EnterpriseName]
                                          ,[Address]
                                          ,[LinkMan]
                                          ,[Mobile]
                                          ,[Tel]
                                          ,[Created]
                                          ,[CreatedBy]
                                          ,[Modified]
                                          ,[ModifiedBy]
                                      FROM [BE_LogisticsEnterprise] with(nolock)
                                      WHERE 1=1");



            if (!string.IsNullOrEmpty(args.EnterpriseName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "EnterpriseName", "mbEnterpriseName", args.EnterpriseName);
            }

            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Address", "mbAddress", args.Address);
            }

            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Mobile", "mbMobile", args.Mobile);
            }

            if (!string.IsNullOrEmpty(args.Tel))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Tel", "mbTel", args.Tel);
            }

            if (!string.IsNullOrEmpty(args.LinkMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "LinkMan", "mbLinkMan", args.LinkMan);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
