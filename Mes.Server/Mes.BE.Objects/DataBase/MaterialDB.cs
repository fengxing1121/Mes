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
        #region BE_Material InsertObject()
        public int InsertMaterial(Material obj)
        {
            string sql = @"INSERT INTO[BE_Material]([MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@MaterialID
				, @Category
				, @SubCategory
				, @MaterialCode
				, @MaterialName
				, @Style
				, @Color
				, @Deepth
				, @QuotedPrice
				, @Unit
				, @ImageUrl
				, @Remark
				, @Withholding_Qty
				, @SafetyStock_Qty
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", Convert2DBnull(obj.SubCategory));
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", Convert2DBnull(obj.MaterialCode));
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", Convert2DBnull(obj.MaterialName));
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pDeepth = new SqlParameter("Deepth", Convert2DBnull(obj.Deepth));
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", Convert2DBnull(obj.QuotedPrice));
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", Convert2DBnull(obj.Withholding_Qty));
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", Convert2DBnull(obj.SafetyStock_Qty));
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

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

        #region BE_Material UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateMaterialByMaterialCode(Material obj)
        {
            string sql = @"UPDATE [BE_Material] SET [MaterialID]=@MaterialID
				, [Category]=@Category
				, [SubCategory]=@SubCategory
				, [MaterialName]=@MaterialName
				, [Style]=@Style
				, [Color]=@Color
				, [Deepth]=@Deepth
				, [QuotedPrice]=@QuotedPrice
				, [Unit]=@Unit
				, [ImageUrl]=@ImageUrl
				, [Remark]=@Remark
				, [Withholding_Qty]=@Withholding_Qty
				, [SafetyStock_Qty]=@SafetyStock_Qty
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", Convert2DBnull(obj.SubCategory));
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", Convert2DBnull(obj.MaterialName));
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pDeepth = new SqlParameter("Deepth", Convert2DBnull(obj.Deepth));
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", Convert2DBnull(obj.QuotedPrice));
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", Convert2DBnull(obj.Withholding_Qty));
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", Convert2DBnull(obj.SafetyStock_Qty));
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

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

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", Convert2DBnull(obj.MaterialCode));
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateMaterialByMaterialID(Material obj)
        {
            string sql = @"UPDATE [BE_Material] SET [Category]=@Category
				, [SubCategory]=@SubCategory
				, [MaterialCode]=@MaterialCode
				, [MaterialName]=@MaterialName
				, [Style]=@Style
				, [Color]=@Color
				, [Deepth]=@Deepth
				, [QuotedPrice]=@QuotedPrice
				, [Unit]=@Unit
				, [ImageUrl]=@ImageUrl
				, [Remark]=@Remark
				, [Withholding_Qty]=@Withholding_Qty
				, [SafetyStock_Qty]=@SafetyStock_Qty
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", Convert2DBnull(obj.SubCategory));
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", Convert2DBnull(obj.MaterialCode));
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", Convert2DBnull(obj.MaterialName));
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pDeepth = new SqlParameter("Deepth", Convert2DBnull(obj.Deepth));
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", Convert2DBnull(obj.QuotedPrice));
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", Convert2DBnull(obj.Withholding_Qty));
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", Convert2DBnull(obj.SafetyStock_Qty));
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

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

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialByMaterialCode(string materialCode)
        {
            string sql = @"DELETE [BE_Material] WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", materialCode);
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialByMaterialID(Guid materialID)
        {
            string sql = @"DELETE [BE_Material] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadMaterialByMaterialCode(Material obj)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", Convert2DBnull(obj.MaterialCode));
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        obj.MaterialID = (Guid)dr["MaterialID"];
                    obj.Category = dr["Category"].ToString();
                    obj.SubCategory = dr["SubCategory"].ToString();
                    obj.MaterialCode = dr["MaterialCode"].ToString();
                    obj.MaterialName = dr["MaterialName"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        obj.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        obj.QuotedPrice = (decimal)dr["QuotedPrice"];
                    obj.Unit = dr["Unit"].ToString();
                    obj.ImageUrl = dr["ImageUrl"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        obj.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        obj.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public int LoadMaterialByMaterialID(Material obj)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        obj.MaterialID = (Guid)dr["MaterialID"];
                    obj.Category = dr["Category"].ToString();
                    obj.SubCategory = dr["SubCategory"].ToString();
                    obj.MaterialCode = dr["MaterialCode"].ToString();
                    obj.MaterialName = dr["MaterialName"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        obj.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        obj.QuotedPrice = (decimal)dr["QuotedPrice"];
                    obj.Unit = dr["Unit"].ToString();
                    obj.ImageUrl = dr["ImageUrl"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        obj.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        obj.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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

        #region BE_Material CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountMaterials()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByMaterialID(Guid materialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByCategory(string category)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsBySubCategory(string subCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [SubCategory]=@SubCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", subCategory);
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByMaterialCode(string materialCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", materialCode);
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByMaterialName(string materialName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialName]=@MaterialName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", materialName);
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByColor(string color)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByDeepth(int deepth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Deepth]=@Deepth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeepth = new SqlParameter("Deepth", deepth);
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByQuotedPrice(decimal quotedPrice)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [QuotedPrice]=@QuotedPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", quotedPrice);
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByImageUrl(string imageUrl)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByWithholding_Qty(decimal withholding_Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Withholding_Qty]=@Withholding_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", withholding_Qty);
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsBySafetyStock_Qty(decimal safetyStock_Qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [SafetyStock_Qty]=@SafetyStock_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", safetyStock_Qty);
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsMaterials()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Material]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByMaterialID(Guid materialID)
        {
            string sql = "SELECT TOP 1 [MaterialID] FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByCategory(string category)
        {
            string sql = "SELECT TOP 1 [Category] FROM [BE_Material] WITH(NOLOCK) WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsBySubCategory(string subCategory)
        {
            string sql = "SELECT TOP 1 [SubCategory] FROM [BE_Material] WITH(NOLOCK) WHERE [SubCategory]=@SubCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", subCategory);
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByMaterialCode(string materialCode)
        {
            string sql = "SELECT TOP 1 [MaterialCode] FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", materialCode);
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByMaterialName(string materialName)
        {
            string sql = "SELECT TOP 1 [MaterialName] FROM [BE_Material] WITH(NOLOCK) WHERE [MaterialName]=@MaterialName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", materialName);
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_Material] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByColor(string color)
        {
            string sql = "SELECT TOP 1 [Color] FROM [BE_Material] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByDeepth(int deepth)
        {
            string sql = "SELECT TOP 1 [Deepth] FROM [BE_Material] WITH(NOLOCK) WHERE [Deepth]=@Deepth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeepth = new SqlParameter("Deepth", deepth);
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByQuotedPrice(decimal quotedPrice)
        {
            string sql = "SELECT TOP 1 [QuotedPrice] FROM [BE_Material] WITH(NOLOCK) WHERE [QuotedPrice]=@QuotedPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", quotedPrice);
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_Material] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByImageUrl(string imageUrl)
        {
            string sql = "SELECT TOP 1 [ImageUrl] FROM [BE_Material] WITH(NOLOCK) WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Material] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByWithholding_Qty(decimal withholding_Qty)
        {
            string sql = "SELECT TOP 1 [Withholding_Qty] FROM [BE_Material] WITH(NOLOCK) WHERE [Withholding_Qty]=@Withholding_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", withholding_Qty);
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsBySafetyStock_Qty(decimal safetyStock_Qty)
        {
            string sql = "SELECT TOP 1 [SafetyStock_Qty] FROM [BE_Material] WITH(NOLOCK) WHERE [SafetyStock_Qty]=@SafetyStock_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", safetyStock_Qty);
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Material] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Material] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Material] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Material] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteMaterials()
        {
            string sql = "DELETE FROM [BE_Material]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByMaterialID(Guid materialID)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByCategory(string category)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsBySubCategory(string subCategory)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [SubCategory]=@SubCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", subCategory);
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByMaterialCode(string materialCode)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", materialCode);
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByMaterialName(string materialName)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [MaterialName]=@MaterialName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", materialName);
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByStyle(string style)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByColor(string color)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByDeepth(int deepth)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Deepth]=@Deepth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeepth = new SqlParameter("Deepth", deepth);
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByQuotedPrice(decimal quotedPrice)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [QuotedPrice]=@QuotedPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", quotedPrice);
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByImageUrl(string imageUrl)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByWithholding_Qty(decimal withholding_Qty)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Withholding_Qty]=@Withholding_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", withholding_Qty);
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsBySafetyStock_Qty(decimal safetyStock_Qty)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [SafetyStock_Qty]=@SafetyStock_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", safetyStock_Qty);
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Material] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Material> LoadMaterials()
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByMaterialID(Guid materialID)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByCategory(string category)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsBySubCategory(string subCategory)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [SubCategory]=@SubCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSubCategory = new SqlParameter("SubCategory", subCategory);
            pSubCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSubCategory);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByMaterialCode(string materialCode)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [MaterialCode]=@MaterialCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCode = new SqlParameter("MaterialCode", materialCode);
            pMaterialCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCode);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByMaterialName(string materialName)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [MaterialName]=@MaterialName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialName = new SqlParameter("MaterialName", materialName);
            pMaterialName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialName);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByStyle(string style)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByColor(string color)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByDeepth(int deepth)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Deepth]=@Deepth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDeepth = new SqlParameter("Deepth", deepth);
            pDeepth.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDeepth);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByQuotedPrice(decimal quotedPrice)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [QuotedPrice]=@QuotedPrice";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuotedPrice = new SqlParameter("QuotedPrice", quotedPrice);
            pQuotedPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQuotedPrice);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByUnit(string unit)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByImageUrl(string imageUrl)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByRemark(string remark)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByWithholding_Qty(decimal withholding_Qty)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Withholding_Qty]=@Withholding_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWithholding_Qty = new SqlParameter("Withholding_Qty", withholding_Qty);
            pWithholding_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWithholding_Qty);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsBySafetyStock_Qty(decimal safetyStock_Qty)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [SafetyStock_Qty]=@SafetyStock_Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSafetyStock_Qty = new SqlParameter("SafetyStock_Qty", safetyStock_Qty);
            pSafetyStock_Qty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pSafetyStock_Qty);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByCreated(DateTime created)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByModified(DateTime modified)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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
        public List<Material> LoadMaterialsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [MaterialID]
				, [Category]
				, [SubCategory]
				, [MaterialCode]
				, [MaterialName]
				, [Style]
				, [Color]
				, [Deepth]
				, [QuotedPrice]
				, [Unit]
				, [ImageUrl]
				, [Remark]
				, [Withholding_Qty]
				, [SafetyStock_Qty]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Material] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Material> ret = new List<Material>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material iret = new Material();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    iret.Category = dr["Category"].ToString();
                    iret.SubCategory = dr["SubCategory"].ToString();
                    iret.MaterialCode = dr["MaterialCode"].ToString();
                    iret.MaterialName = dr["MaterialName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Color = dr["Color"].ToString();
                    if (!Convert.IsDBNull(dr["Deepth"]))
                        iret.Deepth = (int)dr["Deepth"];
                    if (!Convert.IsDBNull(dr["QuotedPrice"]))
                        iret.QuotedPrice = (decimal)dr["QuotedPrice"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Withholding_Qty"]))
                        iret.Withholding_Qty = (decimal)dr["Withholding_Qty"];
                    if (!Convert.IsDBNull(dr["SafetyStock_Qty"]))
                        iret.SafetyStock_Qty = (decimal)dr["SafetyStock_Qty"];
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

        #region BE_Material SearchObject()
        public SearchResult SearchMaterial(SearchMaterialArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[MaterialID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [MaterialID]
                                          ,[Category]
                                          ,[SubCategory]
                                          ,[MaterialCode]
                                          ,[MaterialName]
                                          ,[Style]
                                          ,[Color]
                                          ,[Deepth]
                                          ,[QuotedPrice]
                                          ,[Unit]
                                          ,[ImageUrl]
                                          ,[Remark]
                                          ,[Withholding_Qty]
                                          ,[SafetyStock_Qty]
                                          ,[Created]
                                          ,[CreatedBy]
                                          ,[Modified]
                                          ,[ModifiedBy]
                                      FROM [BE_Material] with(nolock)                                     
	                                  WHERE 1=1");

            this.SetParameters_In(mbBuilder, cmd, "MaterialID", "mbMaterialID", args.MaterialIDs);
            this.SetParameters_In(mbBuilder, cmd, "Category", "mbCategory", args.Categorys);
            this.SetParameters_In(mbBuilder, cmd, "SubCategory", "mbSubCategory", args.SubCategorys);

            if (!string.IsNullOrEmpty(args.MaterialCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialCode", "mbMaterialCode", args.MaterialCode);
            }

            if (!string.IsNullOrEmpty(args.MaterialName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialName", "mbMaterialName", args.MaterialName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.Style))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Style", "mbStyle", args.Style);
            }
            if (args.Deepth.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "Deepth", "mbDeepth", args.Deepth.Value);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
