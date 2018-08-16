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
       
        #region BE_Customer InsertObject()
        public int InsertCustomer(Customer obj)
        {
            string sql = @"INSERT INTO[BE_Customer]([CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@CustomerID
				, @PartnerID
				, @CustomerName
				, @Province
				, @City
				, @LinkMan
				, @Position
				, @Address
				, @Tel
				, @Mobile
				, @Fax
				, @Email
				, @HomePage
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", Convert2DBnull(obj.CustomerName));
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pPosition = new SqlParameter("Position", Convert2DBnull(obj.Position));
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pHomePage = new SqlParameter("HomePage", Convert2DBnull(obj.HomePage));
            pHomePage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHomePage);

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

        #region BE_Customer UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCustomerByCustomerID(Customer obj)
        {
            string sql = @"UPDATE [BE_Customer] SET [PartnerID]=@PartnerID
				, [CustomerName]=@CustomerName
				, [Province]=@Province
				, [City]=@City
				, [LinkMan]=@LinkMan
				, [Position]=@Position
				, [Address]=@Address
				, [Tel]=@Tel
				, [Mobile]=@Mobile
				, [Fax]=@Fax
				, [Email]=@Email
				, [HomePage]=@HomePage
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", Convert2DBnull(obj.CustomerName));
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pPosition = new SqlParameter("Position", Convert2DBnull(obj.Position));
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pHomePage = new SqlParameter("HomePage", Convert2DBnull(obj.HomePage));
            pHomePage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHomePage);

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

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerByCustomerID(Guid customerID)
        {
            string sql = @"DELETE [BE_Customer] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCustomerByCustomerID(Customer obj)
        {
            string sql = @"SELECT		 [BE_Customer].[CustomerID]
                                          ,[BE_Customer].[PartnerID]
                                          ,[BE_Customer].[CustomerName]
                                          ,[BE_Customer].[Province]
                                          ,[BE_Customer].[City]
                                          ,[BE_Customer].[LinkMan]
                                          ,[Position]
                                          ,[BE_Customer].[Address]
                                          ,[BE_Customer].[Tel]
                                          ,[BE_Customer].[Mobile]
                                          ,[BE_Customer].[Fax]
                                          ,[BE_Customer].[Email]
                                          ,[HomePage]
                                          ,[BE_Customer].[Remark]
                                          ,[BE_Customer].[Created]
                                          ,[BE_Customer].[CreatedBy]
                                          ,[BE_Customer].[Modified]
                                          ,[BE_Customer].[ModifiedBy]
										  ,[BE_Partner].[PartnerName]
                                      FROM [BE_Customer]  AS [BE_Customer] with(nolock)
									  LEFT JOIN  [dbo].[BE_Partner] AS [BE_Partner] with(nolock)
									  ON [BE_Customer].PartnerID=[BE_Partner].PartnerID
	                                  WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.CustomerName = dr["CustomerName"].ToString();
                    obj.Province = dr["Province"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();

                    if (!Convert.IsDBNull(dr["PartnerName"]))
                        obj.PartnerName = (string)dr["PartnerName"];
 
                    obj.Email = dr["Email"].ToString();
                    obj.HomePage = dr["HomePage"].ToString();
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

        #region BE_Customer CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCustomers()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByCustomerID(Guid customerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByCustomerName(string customerName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [CustomerName]=@CustomerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", customerName);
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByProvince(string province)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByCity(string city)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByLinkMan(string linkMan)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByPosition(string position)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByAddress(string address)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByTel(string tel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByFax(string fax)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByHomePage(string homePage)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [HomePage]=@HomePage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHomePage = new SqlParameter("HomePage", homePage);
            pHomePage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHomePage);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCustomersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Customer] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCustomers()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Customer]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByCustomerID(Guid customerID)
        {
            string sql = "SELECT TOP 1 [CustomerID] FROM [BE_Customer] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_Customer] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByCustomerName(string customerName)
        {
            string sql = "SELECT TOP 1 [CustomerName] FROM [BE_Customer] WITH(NOLOCK) WHERE [CustomerName]=@CustomerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", customerName);
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByProvince(string province)
        {
            string sql = "SELECT TOP 1 [Province] FROM [BE_Customer] WITH(NOLOCK) WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByCity(string city)
        {
            string sql = "SELECT TOP 1 [City] FROM [BE_Customer] WITH(NOLOCK) WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByLinkMan(string linkMan)
        {
            string sql = "SELECT TOP 1 [LinkMan] FROM [BE_Customer] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByPosition(string position)
        {
            string sql = "SELECT TOP 1 [Position] FROM [BE_Customer] WITH(NOLOCK) WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByAddress(string address)
        {
            string sql = "SELECT TOP 1 [Address] FROM [BE_Customer] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByTel(string tel)
        {
            string sql = "SELECT TOP 1 [Tel] FROM [BE_Customer] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_Customer] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByFax(string fax)
        {
            string sql = "SELECT TOP 1 [Fax] FROM [BE_Customer] WITH(NOLOCK) WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByEmail(string email)
        {
            string sql = "SELECT TOP 1 [Email] FROM [BE_Customer] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByHomePage(string homePage)
        {
            string sql = "SELECT TOP 1 [HomePage] FROM [BE_Customer] WITH(NOLOCK) WHERE [HomePage]=@HomePage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHomePage = new SqlParameter("HomePage", homePage);
            pHomePage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHomePage);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Customer] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Customer] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Customer] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Customer] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCustomersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Customer] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCustomers()
        {
            string sql = "DELETE FROM [BE_Customer]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByCustomerID(Guid customerID)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByCustomerName(string customerName)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [CustomerName]=@CustomerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", customerName);
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByProvince(string province)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByCity(string city)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByLinkMan(string linkMan)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByPosition(string position)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByAddress(string address)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByTel(string tel)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByFax(string fax)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByEmail(string email)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByHomePage(string homePage)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [HomePage]=@HomePage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHomePage = new SqlParameter("HomePage", homePage);
            pHomePage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHomePage);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Customer] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Customer> LoadCustomers()
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByCustomerID(Guid customerID)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByCustomerName(string customerName)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [CustomerName]=@CustomerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerName = new SqlParameter("CustomerName", customerName);
            pCustomerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCustomerName);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByProvince(string province)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByCity(string city)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByLinkMan(string linkMan)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByPosition(string position)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByAddress(string address)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByTel(string tel)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByMobile(string mobile)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByFax(string fax)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByEmail(string email)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByHomePage(string homePage)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [HomePage]=@HomePage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHomePage = new SqlParameter("HomePage", homePage);
            pHomePage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHomePage);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByRemark(string remark)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByCreated(DateTime created)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByModified(DateTime modified)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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
        public List<Customer> LoadCustomersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [CustomerID]
				, [PartnerID]
				, [CustomerName]
				, [Province]
				, [City]
				, [LinkMan]
				, [Position]
				, [Address]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [Email]
				, [HomePage]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Customer] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Customer> ret = new List<Customer>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Customer iret = new Customer();
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.CustomerName = dr["CustomerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.HomePage = dr["HomePage"].ToString();
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

        #region BE_Customer SearchObject()
        public SearchResult SearchCustomer(SearchCustomerArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Address] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT		   [BE_Customer].[CustomerID]
                                                  ,[BE_Customer].[PartnerID]
                                                  ,[BE_Customer].[CustomerName]
                                                  ,[BE_Customer].[Province]
                                                  ,[BE_Customer].[City]
                                                  ,[BE_Customer].[LinkMan]
                                                  ,[Position]
                                                  ,[BE_Customer].[Address]
                                                  ,[BE_Customer].[Tel]
                                                  ,[BE_Partner].[Tel] as [SalesMan]
                                                  ,[BE_Customer].[Mobile]
                                                  ,[BE_Customer].[Fax]
                                                  ,[BE_Customer].[Email]
                                                  ,[HomePage]
                                                  ,[BE_Customer].[Remark]
                                                  ,[BE_Customer].[Created]
                                                  ,[BE_Customer].[CreatedBy]
                                                  ,[BE_Customer].[Modified]
                                                  ,[BE_Customer].[ModifiedBy]
										          ,[BE_Partner].[PartnerName]
                                      FROM [BE_Customer]  AS [BE_Customer] with(nolock)
									  LEFT JOIN  [dbo].[BE_Partner] AS [BE_Partner] with(nolock)
									  ON [BE_Customer].PartnerID=[BE_Partner].PartnerID
	                                  WHERE 1=1");

            if (args.CustomerIDs!=null)
            {
                this.SetParameters_In(mbBuilder, cmd, "BE_Customer].[CustomerID", "mbCustomerID", args.CustomerIDs);
            }
            if (args.PartnerIDs != null)
            {
                this.SetParameters_In(mbBuilder, cmd, "BE_Partner].[PartnerID", "mbPartnerID", args.PartnerIDs);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Tel))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Tel", "mbTel", args.Tel);
            }
            if (!string.IsNullOrEmpty(args.Fax))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Fax", "mbFax", args.Fax);
            }
            if (!string.IsNullOrEmpty(args.Position))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Position", "mbPosition", args.Position);
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
