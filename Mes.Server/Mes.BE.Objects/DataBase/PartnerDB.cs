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
        
        #region BE_Partner InsertObject()
        public int InsertPartner(Partner obj)
        {
            string sql = @"INSERT INTO[BE_Partner]([PartnerID]
                , [CompanyID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@PartnerID
				, @CompanyID
				, @PartnerCode
				, @PartnerName
				, @Province
				, @City
				, @Address
				, @LinkMan
				, @Tel
				, @Mobile
				, @Fax
				, @ShopSize
				, @ShopType
				, @Email
				, @Remark
				, @DiscountType
				, @DiscountRate
				, @Grade
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);
            SqlParameter pCompanyID = new SqlParameter("CompanyID", Convert2DBnull(obj.CompanyID));
            pCompanyID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCompanyID);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", Convert2DBnull(obj.PartnerCode));
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", Convert2DBnull(obj.PartnerName));
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pShopSize = new SqlParameter("ShopSize", Convert2DBnull(obj.ShopSize));
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            SqlParameter pShopType = new SqlParameter("ShopType", Convert2DBnull(obj.ShopType));
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", Convert2DBnull(obj.DiscountType));
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", Convert2DBnull(obj.DiscountRate));
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            SqlParameter pGrade = new SqlParameter("Grade", Convert2DBnull(obj.Grade));
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

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

        #region BE_Partner UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerByPartnerCode(Partner obj)
        {
            string sql = @"UPDATE [BE_Partner] SET [PartnerID]=@PartnerID
				, [PartnerName]=@PartnerName
				, [Province]=@Province
				, [City]=@City
				, [Address]=@Address
				, [LinkMan]=@LinkMan
				, [Tel]=@Tel
				, [Mobile]=@Mobile
				, [Fax]=@Fax
				, [ShopSize]=@ShopSize
				, [ShopType]=@ShopType
				, [Email]=@Email
				, [Remark]=@Remark
				, [DiscountType]=@DiscountType
				, [DiscountRate]=@DiscountRate
				, [Grade]=@Grade
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", Convert2DBnull(obj.PartnerName));
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pShopSize = new SqlParameter("ShopSize", Convert2DBnull(obj.ShopSize));
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            SqlParameter pShopType = new SqlParameter("ShopType", Convert2DBnull(obj.ShopType));
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", Convert2DBnull(obj.DiscountType));
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", Convert2DBnull(obj.DiscountRate));
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            SqlParameter pGrade = new SqlParameter("Grade", Convert2DBnull(obj.Grade));
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

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

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", Convert2DBnull(obj.PartnerCode));
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePartnerByPartnerID(Partner obj)
        {
            string sql = @"UPDATE [BE_Partner] SET [PartnerCode]=@PartnerCode
                , [CompanyID]=@CompanyID
				, [PartnerName]=@PartnerName
				, [Province]=@Province
				, [City]=@City
				, [Address]=@Address
				, [LinkMan]=@LinkMan
				, [Tel]=@Tel
				, [Mobile]=@Mobile
				, [Fax]=@Fax
				, [ShopSize]=@ShopSize
				, [ShopType]=@ShopType
				, [Email]=@Email
				, [Remark]=@Remark
				, [DiscountType]=@DiscountType
				, [DiscountRate]=@DiscountRate
				, [Grade]=@Grade
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", Convert2DBnull(obj.PartnerCode));
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            SqlParameter pCompanyID = new SqlParameter("CompanyID", Convert2DBnull(obj.CompanyID));
            pCompanyID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCompanyID);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", Convert2DBnull(obj.PartnerName));
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            SqlParameter pProvince = new SqlParameter("Province", Convert2DBnull(obj.Province));
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            SqlParameter pCity = new SqlParameter("City", Convert2DBnull(obj.City));
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            SqlParameter pAddress = new SqlParameter("Address", Convert2DBnull(obj.Address));
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", Convert2DBnull(obj.LinkMan));
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pShopSize = new SqlParameter("ShopSize", Convert2DBnull(obj.ShopSize));
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            SqlParameter pShopType = new SqlParameter("ShopType", Convert2DBnull(obj.ShopType));
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", Convert2DBnull(obj.DiscountType));
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", Convert2DBnull(obj.DiscountRate));
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            SqlParameter pGrade = new SqlParameter("Grade", Convert2DBnull(obj.Grade));
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

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

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerByPartnerCode(string partnerCode)
        {
            string sql = @"DELETE [BE_Partner] WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", partnerCode);
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerByPartnerID(Guid partnerID)
        {
            string sql = @"DELETE [BE_Partner] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerByPartnerCode(Partner obj)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", Convert2DBnull(obj.PartnerCode));
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.PartnerCode = dr["PartnerCode"].ToString();
                    obj.PartnerName = dr["PartnerName"].ToString();
                    obj.Province = dr["Province"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        obj.ShopSize = (int)dr["ShopSize"];
                    obj.ShopType = dr["ShopType"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        obj.DiscountRate = (decimal)dr["DiscountRate"];
                    obj.Grade = dr["Grade"].ToString();
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
        public int LoadPartnerByPartnerID(Partner obj)
        {
            string sql = @"SELECT  P.[PartnerID]
				, P.[PartnerCode]
				, P.[PartnerName]
				, P.[Province]
				, P.[City]
				, P.[Address]
				, P.[LinkMan]
				, P.[Tel]
				, P.[Mobile]
				, P.[Fax]
				, P.[ShopSize]
				, P.[ShopType]
				, P.[Email]
				, P.[Remark]
				, P.[DiscountType]
				, P.[DiscountRate]
				, P.[Grade]
				, P.[Created]
				, P.[CreatedBy]
				, P.[Modified]
				, P.[ModifiedBy]
 				FROM [BE_Partner] P
				left join [BE_PartnerUser] U on P.PartnerID=U.PartnerID
                WHERE P.[PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.PartnerCode = dr["PartnerCode"].ToString();
                    obj.PartnerName = dr["PartnerName"].ToString();
                    obj.Province = dr["Province"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        obj.ShopSize = (int)dr["ShopSize"];
                    obj.ShopType = dr["ShopType"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        obj.DiscountRate = (decimal)dr["DiscountRate"];
                    obj.Grade = dr["Grade"].ToString();
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

        public int LoadCompanyByCompanyID(Company obj)
        {
            string sql = @"SELECT [CompanyID]
                          ,[CompanyCode]
                          ,[CompanyName]
                          ,[Province]
                          ,[City]
                          ,[Address]
                          ,[Email]
                          ,[Mobile]
                          ,[LinkMan]
                          ,[Amount]
                          ,[Score]
                          ,[Remark]
                          ,[ReferralCode]
                          ,[ReferralBy]
                          ,[Status]
                          ,[Created]
                          ,[Modified]
                          ,[Sort]
                      FROM [dbo].[BE_Company]
                WHERE [CompanyID]=@CompanyID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCompanyID = new SqlParameter("CompanyID", Convert2DBnull(obj.CompanyID));
            pCompanyID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCompanyID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CompanyID"]))
                        obj.CompanyID = (Guid)dr["CompanyID"];
                    obj.CompanyCode = dr["CompanyCode"].ToString();
                    obj.CompanyName = dr["CompanyName"].ToString();
                    obj.Province = dr["Province"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Amount"]))
                        obj.Amount = (decimal)dr["Amount"];
                    if (!Convert.IsDBNull(dr["Score"]))
                        obj.Score = (decimal)dr["Score"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];


                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadPartnerByMobile(Partner obj)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Partner] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.PartnerCode = dr["PartnerCode"].ToString();
                    obj.PartnerName = dr["PartnerName"].ToString();
                    obj.Province = dr["Province"].ToString();
                    obj.City = dr["City"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.LinkMan = dr["LinkMan"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        obj.ShopSize = (int)dr["ShopSize"];
                    obj.ShopType = dr["ShopType"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        obj.DiscountRate = (decimal)dr["DiscountRate"];
                    obj.Grade = dr["Grade"].ToString();
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

        #region BE_Partner CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartners()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByPartnerCode(string partnerCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", partnerCode);
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByPartnerName(string partnerName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerName]=@PartnerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", partnerName);
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByProvince(string province)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByCity(string city)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByAddress(string address)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByLinkMan(string linkMan)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByTel(string tel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByFax(string fax)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByShopSize(int shopSize)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [ShopSize]=@ShopSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopSize = new SqlParameter("ShopSize", shopSize);
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByShopType(string shopType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [ShopType]=@ShopType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopType = new SqlParameter("ShopType", shopType);
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByDiscountType(string discountType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [DiscountType]=@DiscountType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", discountType);
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByDiscountRate(decimal discountRate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [DiscountRate]=@DiscountRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", discountRate);
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByGrade(string grade)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Grade]=@Grade";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGrade = new SqlParameter("Grade", grade);
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Partner] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartners()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Partner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByPartnerCode(string partnerCode)
        {
            string sql = "SELECT TOP 1 [PartnerCode] FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", partnerCode);
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByPartnerName(string partnerName)
        {
            string sql = "SELECT TOP 1 [PartnerName] FROM [BE_Partner] WITH(NOLOCK) WHERE [PartnerName]=@PartnerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", partnerName);
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByProvince(string province)
        {
            string sql = "SELECT TOP 1 [Province] FROM [BE_Partner] WITH(NOLOCK) WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByCity(string city)
        {
            string sql = "SELECT TOP 1 [City] FROM [BE_Partner] WITH(NOLOCK) WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByAddress(string address)
        {
            string sql = "SELECT TOP 1 [Address] FROM [BE_Partner] WITH(NOLOCK) WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByLinkMan(string linkMan)
        {
            string sql = "SELECT TOP 1 [LinkMan] FROM [BE_Partner] WITH(NOLOCK) WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByTel(string tel)
        {
            string sql = "SELECT TOP 1 [Tel] FROM [BE_Partner] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_Partner] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByFax(string fax)
        {
            string sql = "SELECT TOP 1 [Fax] FROM [BE_Partner] WITH(NOLOCK) WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByShopSize(int shopSize)
        {
            string sql = "SELECT TOP 1 [ShopSize] FROM [BE_Partner] WITH(NOLOCK) WHERE [ShopSize]=@ShopSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopSize = new SqlParameter("ShopSize", shopSize);
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByShopType(string shopType)
        {
            string sql = "SELECT TOP 1 [ShopType] FROM [BE_Partner] WITH(NOLOCK) WHERE [ShopType]=@ShopType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopType = new SqlParameter("ShopType", shopType);
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByEmail(string email)
        {
            string sql = "SELECT TOP 1 [Email] FROM [BE_Partner] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Partner] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByDiscountType(string discountType)
        {
            string sql = "SELECT TOP 1 [DiscountType] FROM [BE_Partner] WITH(NOLOCK) WHERE [DiscountType]=@DiscountType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", discountType);
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByDiscountRate(decimal discountRate)
        {
            string sql = "SELECT TOP 1 [DiscountRate] FROM [BE_Partner] WITH(NOLOCK) WHERE [DiscountRate]=@DiscountRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", discountRate);
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByGrade(string grade)
        {
            string sql = "SELECT TOP 1 [Grade] FROM [BE_Partner] WITH(NOLOCK) WHERE [Grade]=@Grade";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGrade = new SqlParameter("Grade", grade);
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Partner] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Partner] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Partner] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Partner] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartners()
        {
            string sql = "DELETE FROM [BE_Partner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByPartnerCode(string partnerCode)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", partnerCode);
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByPartnerName(string partnerName)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [PartnerName]=@PartnerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", partnerName);
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByProvince(string province)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByCity(string city)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByAddress(string address)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByLinkMan(string linkMan)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByTel(string tel)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByFax(string fax)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByShopSize(int shopSize)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [ShopSize]=@ShopSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopSize = new SqlParameter("ShopSize", shopSize);
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByShopType(string shopType)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [ShopType]=@ShopType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopType = new SqlParameter("ShopType", shopType);
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByEmail(string email)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByDiscountType(string discountType)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [DiscountType]=@DiscountType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", discountType);
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByDiscountRate(decimal discountRate)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [DiscountRate]=@DiscountRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", discountRate);
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByGrade(string grade)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Grade]=@Grade";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGrade = new SqlParameter("Grade", grade);
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Partner] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Partner> LoadPartners()
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByPartnerCode(string partnerCode)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [PartnerCode]=@PartnerCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerCode = new SqlParameter("PartnerCode", partnerCode);
            pPartnerCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerCode);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByPartnerName(string partnerName)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [PartnerName]=@PartnerName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerName = new SqlParameter("PartnerName", partnerName);
            pPartnerName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPartnerName);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByProvince(string province)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Province]=@Province";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProvince = new SqlParameter("Province", province);
            pProvince.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProvince);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByCity(string city)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [City]=@City";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCity = new SqlParameter("City", city);
            pCity.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCity);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByAddress(string address)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Address]=@Address";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pAddress = new SqlParameter("Address", address);
            pAddress.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pAddress);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByLinkMan(string linkMan)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [LinkMan]=@LinkMan";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLinkMan = new SqlParameter("LinkMan", linkMan);
            pLinkMan.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLinkMan);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByTel(string tel)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByMobile(string mobile)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByFax(string fax)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByShopSize(int shopSize)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [ShopSize]=@ShopSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopSize = new SqlParameter("ShopSize", shopSize);
            pShopSize.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pShopSize);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByShopType(string shopType)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [ShopType]=@ShopType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pShopType = new SqlParameter("ShopType", shopType);
            pShopType.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pShopType);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByEmail(string email)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByRemark(string remark)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByDiscountType(string discountType)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [DiscountType]=@DiscountType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountType = new SqlParameter("DiscountType", discountType);
            pDiscountType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDiscountType);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByDiscountRate(decimal discountRate)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [DiscountRate]=@DiscountRate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountRate = new SqlParameter("DiscountRate", discountRate);
            pDiscountRate.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountRate);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByGrade(string grade)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Grade]=@Grade";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGrade = new SqlParameter("Grade", grade);
            pGrade.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGrade);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByCreated(DateTime created)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByModified(DateTime modified)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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
        public List<Partner> LoadPartnersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [PartnerID]
				, [PartnerCode]
				, [PartnerName]
				, [Province]
				, [City]
				, [Address]
				, [LinkMan]
				, [Tel]
				, [Mobile]
				, [Fax]
				, [ShopSize]
				, [ShopType]
				, [Email]
				, [Remark]
				, [DiscountType]
				, [DiscountRate]
				, [Grade]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Partner] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Partner> ret = new List<Partner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Partner iret = new Partner();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.PartnerCode = dr["PartnerCode"].ToString();
                    iret.PartnerName = dr["PartnerName"].ToString();
                    iret.Province = dr["Province"].ToString();
                    iret.City = dr["City"].ToString();
                    iret.Address = dr["Address"].ToString();
                    iret.LinkMan = dr["LinkMan"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["ShopSize"]))
                        iret.ShopSize = (int)dr["ShopSize"];
                    iret.ShopType = dr["ShopType"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.DiscountType = dr["DiscountType"].ToString();
                    if (!Convert.IsDBNull(dr["DiscountRate"]))
                        iret.DiscountRate = (decimal)dr["DiscountRate"];
                    iret.Grade = dr["Grade"].ToString();
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

        #region BE_Partner SearchObject()
        public SearchResult SearchPartner(SearchPartnerArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Address] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"	SELECT P.[PartnerID]
                                          ,P.[PartnerCode]
                                          ,P.[PartnerName]
                                          ,P.[Province]
                                          ,P.[City]
                                          ,P.[Address]
                                          ,P.[LinkMan]
                                          ,P.[Tel]
                                          ,P.[Mobile]
                                          ,P.[Fax]
                                          ,P.[ShopSize]
                                          ,P.[ShopType]
                                          ,P.[Email]
                                          ,P.[Remark]
                                          ,P.[Created]
                                          ,P.[CreatedBy]
                                          ,P.[Modified]
                                          ,P.[ModifiedBy]
                                      FROM [BE_Partner] P
				left join [BE_PartnerUser] U on P.PartnerID=U.PartnerID
	                                  WHERE 1=1 AND  U.IsSystem=1 ");

            
            if (args.PartnerIDs!=null)
            {
                this.SetParameters_In(mbBuilder, cmd, "P].[PartnerID", "mbPartnerID", args.PartnerIDs);
            }
            if (!string.IsNullOrEmpty(args.PartnerCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerCode", "mbPartnerCode", args.PartnerCode);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "P].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Tel))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Tel", "mbTel", args.Tel);
            }
            if (!string.IsNullOrEmpty(args.Fax))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Fax", "mbFax", args.Fax);
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
