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
       
        #region BE_Supplier InsertObject()
        public int InsertSupplier(Supplier obj)
        {
            string sql = @"INSERT INTO[BE_Supplier]([SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@SupplierID
				, @Category
				, @SupplierCode
				, @SupplierName
				, @Address
				, @Province
				, @City
				, @LinkMan
				, @Tel
				, @Mobile
				, @Email
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pSupplierCode = new SqlParameter("SupplierCode", Convert2DBnull(obj.SupplierCode));
            pSupplierCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierCode);

            SqlParameter pSupplierName = new SqlParameter("SupplierName", Convert2DBnull(obj.SupplierName));
            pSupplierName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierName);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

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

        #region BE_Supplier UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSupplierBySupplierID(Supplier obj)
        {
            string sql = @"UPDATE [BE_Supplier] SET [Category]=@Category
				, [SupplierCode]=@SupplierCode
				, [SupplierName]=@SupplierName
				, [Address]=@Address
				, [Province]=@Province
				, [City]=@City
				, [LinkMan]=@LinkMan
				, [Tel]=@Tel
				, [Mobile]=@Mobile
				, [Email]=@Email
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pSupplierCode = new SqlParameter("SupplierCode", Convert2DBnull(obj.SupplierCode));
            pSupplierCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierCode);

            SqlParameter pSupplierName = new SqlParameter("SupplierName", Convert2DBnull(obj.SupplierName));
            pSupplierName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierName);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

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

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSupplierBySupplierID(Guid supplierID)
        {
            string sql = @"DELETE [BE_Supplier] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSupplierBySupplierID(Supplier obj)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        obj.SupplierID = (Guid)dr["SupplierID"];
                    obj.Category = dr["Category"].ToString();
                    obj.SupplierCode = dr["SupplierCode"].ToString();
                    obj.SupplierName = dr["SupplierName"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.Province = dr["Province"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Remark = dr["Remark"].ToString();
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

        #region BE_Supplier CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSuppliers()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersBySupplierID(Guid supplierID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByCategory(string category)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersBySupplierCode(string supplierCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierCode]=@SupplierCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierCode = new SqlParameter("SupplierCode", supplierCode);
            pSupplierCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersBySupplierName(string supplierName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierName]=@SupplierName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierName = new SqlParameter("SupplierName", supplierName);
            pSupplierName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByAddress(string address)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByProvince(string province)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByCity(string city)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByLinkMan(string linkMan)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByTel(string tel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSuppliersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Supplier] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSuppliers()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersBySupplierID(Guid supplierID)
        {
            string sql = "SELECT TOP 1 [SupplierID] FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByCategory(string category)
        {
            string sql = "SELECT TOP 1 [Category] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersBySupplierCode(string supplierCode)
        {
            string sql = "SELECT TOP 1 [SupplierCode] FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierCode]=@SupplierCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierCode = new SqlParameter("SupplierCode", supplierCode);
            pSupplierCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersBySupplierName(string supplierName)
        {
            string sql = "SELECT TOP 1 [SupplierName] FROM [BE_Supplier] WITH(NOLOCK) WHERE [SupplierName]=@SupplierName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierName = new SqlParameter("SupplierName", supplierName);
            pSupplierName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByAddress(string address)
        {
            string sql = "SELECT TOP 1 [Address] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByProvince(string province)
        {
            string sql = "SELECT TOP 1 [Province] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByCity(string city)
        {
            string sql = "SELECT TOP 1 [City] FROM [BE_Supplier] WITH(NOLOCK) WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByLinkMan(string linkMan)
        {
            string sql = "SELECT TOP 1 [LinkMan] FROM [BE_Supplier] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByTel(string tel)
        {
            string sql = "SELECT TOP 1 [Tel] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByEmail(string email)
        {
            string sql = "SELECT TOP 1 [Email] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Supplier] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Supplier] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSuppliersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Supplier] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSuppliers()
        {
            string sql = "DELETE FROM [BE_Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersBySupplierID(Guid supplierID)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByCategory(string category)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersBySupplierCode(string supplierCode)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [SupplierCode]=@SupplierCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierCode = new SqlParameter("SupplierCode", supplierCode);
            pSupplierCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersBySupplierName(string supplierName)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [SupplierName]=@SupplierName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierName = new SqlParameter("SupplierName", supplierName);
            pSupplierName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByAddress(string address)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByProvince(string province)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByCity(string city)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByLinkMan(string linkMan)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByTel(string tel)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByEmail(string email)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSuppliersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Supplier] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Supplier> LoadSuppliers()
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersBySupplierID(Guid supplierID)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByCategory(string category)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersBySupplierCode(string supplierCode)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [SupplierCode]=@SupplierCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierCode = new SqlParameter("SupplierCode", supplierCode);
            pSupplierCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierCode);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersBySupplierName(string supplierName)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [SupplierName]=@SupplierName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierName = new SqlParameter("SupplierName", supplierName);
            pSupplierName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSupplierName);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByAddress(string address)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByProvince(string province)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByCity(string city)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByLinkMan(string linkMan)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByTel(string tel)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByMobile(string mobile)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByEmail(string email)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByRemark(string remark)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByCreated(DateTime created)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByModified(DateTime modified)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
        public List<Supplier> LoadSuppliersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [SupplierID]
				, [Category]
				, [SupplierCode]
				, [SupplierName]
				, [Address]
				, [Province]
				, [City]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Email]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Supplier] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Supplier> ret = new List<Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Supplier iret = new Supplier();
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SupplierCode = dr["SupplierCode"].ToString();
                    iret.SupplierName = dr["SupplierName"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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

        #region BE_Supplier SearchObject()
        public SearchResult SearchSupplier(SearchSupplierArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Address] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [SupplierID]
                                          ,[Category]
                                          ,[SupplierCode]
                                          ,[SupplierName]
                                          ,[Address]
                                          ,[Province]
                                          ,[City]
                                          ,[LinkMan]
                                          ,[Tel]
                                          ,[Mobile]
                                          ,[Email]
                                          ,[Remark]
                                          ,[Created]
                                          ,[CreatedBy]
                                          ,[Modified]
                                          ,[ModifiedBy]
                                      FROM [BE_Supplier] with(nolock)
	                                  WHERE 1=1");

            this.SetParameters_In(mbBuilder, cmd, "SupplierID", "mbSupplierID", args.SupplierIDs);
            if (!string.IsNullOrEmpty(args.SupplierCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SupplierCode", "mbSupplierCode", args.SupplierCode);
            }
            if (!string.IsNullOrEmpty(args.SupplierName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SupplierName", "mbSupplierName", args.SupplierName);
            }
            if (!string.IsNullOrEmpty(args.Category))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Category", "mbCategory", args.Category);
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
            if (!string.IsNullOrEmpty(args.Province))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Province", "mbProvince", args.Province);
            }
            if (!string.IsNullOrEmpty(args.City))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "City", "mbCity", args.City);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Address", "mbAddress", args.Address);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
