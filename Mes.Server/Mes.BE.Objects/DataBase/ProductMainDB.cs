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
        
        #region BE_ProductMain InsertObject()
        public int InsertProductMain(ProductMain obj)
        {
            string sql = @"INSERT INTO[BE_ProductMain]([ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@ProductID
				, @CategoryID
				, @ImageUrl
				, @ProductCode
				, @ProductName
				, @Size
				, @Color
				, @MaterialStyle
				, @MaterialCategory
				, @Price
				, @IsDisabled
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pProductName = new SqlParameter("ProductName", Convert2DBnull(obj.ProductName));
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            SqlParameter pSize = new SqlParameter("Size", Convert2DBnull(obj.Size));
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", Convert2DBnull(obj.MaterialStyle));
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", Convert2DBnull(obj.MaterialCategory));
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

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

        #region BE_ProductMain UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateProductMainByProductCode(ProductMain obj)
        {
            string sql = @"UPDATE [BE_ProductMain] SET [ProductID]=@ProductID
				, [CategoryID]=@CategoryID
				, [ImageUrl]=@ImageUrl
				, [ProductName]=@ProductName
				, [Size]=@Size
				, [Color]=@Color
				, [MaterialStyle]=@MaterialStyle
				, [MaterialCategory]=@MaterialCategory
				, [Price]=@Price
				, [IsDisabled]=@IsDisabled
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pProductName = new SqlParameter("ProductName", Convert2DBnull(obj.ProductName));
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            SqlParameter pSize = new SqlParameter("Size", Convert2DBnull(obj.Size));
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", Convert2DBnull(obj.MaterialStyle));
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", Convert2DBnull(obj.MaterialCategory));
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

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

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateProductMainByProductID(ProductMain obj)
        {
            string sql = @"UPDATE [BE_ProductMain] SET [CategoryID]=@CategoryID
				, [ImageUrl]=@ImageUrl
				, [ProductCode]=@ProductCode
				, [ProductName]=@ProductName
				, [Size]=@Size
				, [Color]=@Color
				, [MaterialStyle]=@MaterialStyle
				, [MaterialCategory]=@MaterialCategory
				, [Price]=@Price
				, [IsDisabled]=@IsDisabled
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", Convert2DBnull(obj.CategoryID));
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            SqlParameter pProductName = new SqlParameter("ProductName", Convert2DBnull(obj.ProductName));
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            SqlParameter pSize = new SqlParameter("Size", Convert2DBnull(obj.Size));
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", Convert2DBnull(obj.MaterialStyle));
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", Convert2DBnull(obj.MaterialCategory));
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

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

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainByProductCode(string productCode)
        {
            string sql = @"DELETE [BE_ProductMain] WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductCode = new SqlParameter("ProductCode", productCode);
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainByProductID(Guid productID)
        {
            string sql = @"DELETE [BE_ProductMain] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadProductMainByProductCode(ProductMain obj)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductCode = new SqlParameter("ProductCode", Convert2DBnull(obj.ProductCode));
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    obj.ImageUrl = dr["ImageUrl"].ToString();
                    obj.ProductCode = dr["ProductCode"].ToString();
                    obj.ProductName = dr["ProductName"].ToString();
                    obj.Size = dr["Size"].ToString();
                    obj.Color = dr["Color"].ToString();
                    obj.MaterialStyle = dr["MaterialStyle"].ToString();
                    obj.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
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
        public int LoadProductMainByProductID(ProductMain obj)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        obj.CategoryID = (Guid)dr["CategoryID"];
                    obj.ImageUrl = dr["ImageUrl"].ToString();
                    obj.ProductCode = dr["ProductCode"].ToString();
                    obj.ProductName = dr["ProductName"].ToString();
                    obj.Size = dr["Size"].ToString();
                    obj.Color = dr["Color"].ToString();
                    obj.MaterialStyle = dr["MaterialStyle"].ToString();
                    obj.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
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

        #region BE_ProductMain CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountProductMains()
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByProductID(Guid productID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByCategoryID(Guid categoryID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByImageUrl(string imageUrl)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByProductCode(string productCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductCode = new SqlParameter("ProductCode", productCode);
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByProductName(string productName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductName]=@ProductName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductName = new SqlParameter("ProductName", productName);
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsBySize(string size)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByColor(string color)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByMaterialStyle(string materialStyle)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByMaterialCategory(string materialCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsProductMains()
        {
            string sql = "SELECT TOP 1 * FROM [BE_ProductMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByProductID(Guid productID)
        {
            string sql = "SELECT TOP 1 [ProductID] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByCategoryID(Guid categoryID)
        {
            string sql = "SELECT TOP 1 [CategoryID] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByImageUrl(string imageUrl)
        {
            string sql = "SELECT TOP 1 [ImageUrl] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByProductCode(string productCode)
        {
            string sql = "SELECT TOP 1 [ProductCode] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductCode = new SqlParameter("ProductCode", productCode);
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByProductName(string productName)
        {
            string sql = "SELECT TOP 1 [ProductName] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ProductName]=@ProductName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductName = new SqlParameter("ProductName", productName);
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsBySize(string size)
        {
            string sql = "SELECT TOP 1 [Size] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByColor(string color)
        {
            string sql = "SELECT TOP 1 [Color] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByMaterialStyle(string materialStyle)
        {
            string sql = "SELECT TOP 1 [MaterialStyle] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByMaterialCategory(string materialCategory)
        {
            string sql = "SELECT TOP 1 [MaterialCategory] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_ProductMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteProductMains()
        {
            string sql = "DELETE FROM [BE_ProductMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByProductID(Guid productID)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByCategoryID(Guid categoryID)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByImageUrl(string imageUrl)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByProductCode(string productCode)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductCode = new SqlParameter("ProductCode", productCode);
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByProductName(string productName)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [ProductName]=@ProductName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductName = new SqlParameter("ProductName", productName);
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsBySize(string size)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByColor(string color)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByMaterialStyle(string materialStyle)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByMaterialCategory(string materialCategory)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductMainsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_ProductMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<ProductMain> LoadProductMains()
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByProductID(Guid productID)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByCategoryID(Guid categoryID)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [CategoryID]=@CategoryID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategoryID = new SqlParameter("CategoryID", categoryID);
            pCategoryID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCategoryID);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByImageUrl(string imageUrl)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [ImageUrl]=@ImageUrl";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", imageUrl);
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByProductCode(string productCode)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [ProductCode]=@ProductCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductCode = new SqlParameter("ProductCode", productCode);
            pProductCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductCode);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByProductName(string productName)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [ProductName]=@ProductName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductName = new SqlParameter("ProductName", productName);
            pProductName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pProductName);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsBySize(string size)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [Size]=@Size";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSize = new SqlParameter("Size", size);
            pSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSize);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByColor(string color)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByMaterialStyle(string materialStyle)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [MaterialStyle]=@MaterialStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialStyle = new SqlParameter("MaterialStyle", materialStyle);
            pMaterialStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialStyle);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByMaterialCategory(string materialCategory)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [MaterialCategory]=@MaterialCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialCategory = new SqlParameter("MaterialCategory", materialCategory);
            pMaterialCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialCategory);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByPrice(decimal price)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByRemark(string remark)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByCreated(DateTime created)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByModified(DateTime modified)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<ProductMain> LoadProductMainsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ProductID]
				, [CategoryID]
				, [ImageUrl]
				, [ProductCode]
				, [ProductName]
				, [Size]
				, [Color]
				, [MaterialStyle]
				, [MaterialCategory]
				, [Price]
				, [IsDisabled]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<ProductMain> ret = new List<ProductMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductMain iret = new ProductMain();
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        iret.CategoryID = (Guid)dr["CategoryID"];
                    iret.ImageUrl = dr["ImageUrl"].ToString();
                    iret.ProductCode = dr["ProductCode"].ToString();
                    iret.ProductName = dr["ProductName"].ToString();
                    iret.Size = dr["Size"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.MaterialStyle = dr["MaterialStyle"].ToString();
                    iret.MaterialCategory = dr["MaterialCategory"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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

        #region BE_ProductMain SearchObject()
        public SearchResult SearchProduct(SearchProductArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CategoryID] ASC,[ProductCode]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [ProductID]                                       
                                          ,[BE_ProductMain].[CategoryID]
	                                      ,[BE_Category].[CategoryName]
                                          ,[ImageUrl]
                                          ,[ProductCode]
                                          ,[ProductName]
                                          ,[Size]
                                          ,[Color]
                                          ,[MaterialStyle]
                                          ,[MaterialCategory]
                                          ,[Price]
                                          ,[BE_ProductMain].[Remark]
                                          ,[BE_ProductMain].[IsDisabled]
                                          ,[BE_ProductMain].[Created]
                                          ,[BE_ProductMain].[CreatedBy]
                                          ,[BE_ProductMain].[Modified]
                                          ,[BE_ProductMain].[ModifiedBy]
                                      FROM 
	                                       [BE_ProductMain] with(nolock)
	                                        LEFT JOIN [BE_Category]  with(nolock) on [BE_ProductMain].[CategoryID] = [BE_Category].[CategoryID]
									WHERE 1=1");


            if (args.CategoryID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductMain].[CategoryID", "mbCategoryID", args.CategoryID.Value);
            }
            if (args.ProductID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductMain].[ProductID", "mbProductID", args.ProductID.Value);
            }
            if (!string.IsNullOrEmpty(args.ProductCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ProductCode", "mbProductCode", args.ProductCode);
            }
            if (!string.IsNullOrEmpty(args.CategoryName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CategoryName", "mbCategoryName", args.CategoryName);
            }
            if (!string.IsNullOrEmpty(args.ProductName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_ProductMain].[ProductName", "mbProductName", args.ProductName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_ProductMain].[Color", "mbColor", args.Color);
            }

            if (!string.IsNullOrEmpty(args.Size))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_ProductMain].[Size", "mbSize", args.Size);
            }

            if (!string.IsNullOrEmpty(args.MaterialCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialCategory", "mbMaterialCategory", args.MaterialCategory);
            }
            if (!string.IsNullOrEmpty(args.MaterialStyle))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialStyle", "mbMaterialStyle", args.MaterialStyle);
            }
            this.SetParameters_Between(mbBuilder, cmd, "Price", "mbPrice", args.MinPrice, args.MaxPrice);
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductMain].[IsDisabled", "mbIsDisabled", args.IsDisabled.Value);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
