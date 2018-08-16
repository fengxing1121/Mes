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

        #region BE_ProductDetail InsertObject()
        public int InsertProductDetail(ProductDetail obj)
        {
            string sql = @"INSERT INTO[BE_ProductDetail]([ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@ItemID
				, @ProductID
				, @ItemName
				, @ItemType
				, @MaterialType
				, @PackageSizeType
				, @PackageCategory
				, @BarcodeNo
				, @TextureDirection
				, @MadeWidth
				, @MadeHeight
				, @MadeLength
				, @EndWidth
				, @EndLength
				, @Qty
				, @FrontLabel
				, @BackLabel
				, @Remarks
				, @EdgeDesc
				, @IsSpecialShap
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", Convert2DBnull(obj.PackageSizeType));
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", Convert2DBnull(obj.PackageCategory));
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", Convert2DBnull(obj.TextureDirection));
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", Convert2DBnull(obj.EndWidth));
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            SqlParameter pEndLength = new SqlParameter("EndLength", Convert2DBnull(obj.EndLength));
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", Convert2DBnull(obj.FrontLabel));
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", Convert2DBnull(obj.BackLabel));
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", Convert2DBnull(obj.EdgeDesc));
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateProductDetailByBarcodeNo(ProductDetail obj)
        {
            string sql = @"UPDATE [BE_ProductDetail] SET [ItemID]=@ItemID
				, [ProductID]=@ProductID
				, [ItemName]=@ItemName
				, [ItemType]=@ItemType
				, [MaterialType]=@MaterialType
				, [PackageSizeType]=@PackageSizeType
				, [PackageCategory]=@PackageCategory
				, [TextureDirection]=@TextureDirection
				, [MadeWidth]=@MadeWidth
				, [MadeHeight]=@MadeHeight
				, [MadeLength]=@MadeLength
				, [EndWidth]=@EndWidth
				, [EndLength]=@EndLength
				, [Qty]=@Qty
				, [FrontLabel]=@FrontLabel
				, [BackLabel]=@BackLabel
				, [Remarks]=@Remarks
				, [EdgeDesc]=@EdgeDesc
				, [IsSpecialShap]=@IsSpecialShap
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", Convert2DBnull(obj.PackageSizeType));
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", Convert2DBnull(obj.PackageCategory));
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", Convert2DBnull(obj.TextureDirection));
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", Convert2DBnull(obj.EndWidth));
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            SqlParameter pEndLength = new SqlParameter("EndLength", Convert2DBnull(obj.EndLength));
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", Convert2DBnull(obj.FrontLabel));
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", Convert2DBnull(obj.BackLabel));
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", Convert2DBnull(obj.EdgeDesc));
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateProductDetailByItemID(ProductDetail obj)
        {
            string sql = @"UPDATE [BE_ProductDetail] SET [ProductID]=@ProductID
				, [ItemName]=@ItemName
				, [ItemType]=@ItemType
				, [MaterialType]=@MaterialType
				, [PackageSizeType]=@PackageSizeType
				, [PackageCategory]=@PackageCategory
				, [BarcodeNo]=@BarcodeNo
				, [TextureDirection]=@TextureDirection
				, [MadeWidth]=@MadeWidth
				, [MadeHeight]=@MadeHeight
				, [MadeLength]=@MadeLength
				, [EndWidth]=@EndWidth
				, [EndLength]=@EndLength
				, [Qty]=@Qty
				, [FrontLabel]=@FrontLabel
				, [BackLabel]=@BackLabel
				, [Remarks]=@Remarks
				, [EdgeDesc]=@EdgeDesc
				, [IsSpecialShap]=@IsSpecialShap
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", Convert2DBnull(obj.MaterialType));
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", Convert2DBnull(obj.PackageSizeType));
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", Convert2DBnull(obj.PackageCategory));
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", Convert2DBnull(obj.TextureDirection));
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", Convert2DBnull(obj.MadeWidth));
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", Convert2DBnull(obj.MadeHeight));
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", Convert2DBnull(obj.MadeLength));
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", Convert2DBnull(obj.EndWidth));
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            SqlParameter pEndLength = new SqlParameter("EndLength", Convert2DBnull(obj.EndLength));
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", Convert2DBnull(obj.FrontLabel));
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", Convert2DBnull(obj.BackLabel));
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", Convert2DBnull(obj.EdgeDesc));
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", Convert2DBnull(obj.IsSpecialShap));
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailByBarcodeNo(string barcodeNo)
        {
            string sql = @"DELETE [BE_ProductDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_ProductDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadProductDetailByBarcodeNo(ProductDetail obj)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.MaterialType = dr["MaterialType"].ToString();
                    obj.PackageSizeType = dr["PackageSizeType"].ToString();
                    obj.PackageCategory = dr["PackageCategory"].ToString();
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    obj.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        obj.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        obj.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        obj.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        obj.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        obj.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    obj.FrontLabel = dr["FrontLabel"].ToString();
                    obj.BackLabel = dr["BackLabel"].ToString();
                    obj.Remarks = dr["Remarks"].ToString();
                    obj.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        obj.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public int LoadProductDetailByItemID(ProductDetail obj)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        obj.ProductID = (Guid)dr["ProductID"];
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.MaterialType = dr["MaterialType"].ToString();
                    obj.PackageSizeType = dr["PackageSizeType"].ToString();
                    obj.PackageCategory = dr["PackageCategory"].ToString();
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    obj.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        obj.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        obj.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        obj.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        obj.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        obj.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    obj.FrontLabel = dr["FrontLabel"].ToString();
                    obj.BackLabel = dr["BackLabel"].ToString();
                    obj.Remarks = dr["Remarks"].ToString();
                    obj.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        obj.IsSpecialShap = (bool)dr["IsSpecialShap"];
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

        #region BE_ProductDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountProductDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByProductID(Guid productID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByItemType(string itemType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByMaterialType(string materialType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByPackageCategory(string packageCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByTextureDirection(string textureDirection)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByMadeLength(decimal madeLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByEndWidth(decimal endWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByEndLength(decimal endLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByFrontLabel(string frontLabel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByBackLabel(string backLabel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByRemarks(string remarks)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsProductDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_ProductDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByProductID(Guid productID)
        {
            string sql = "SELECT TOP 1 [ProductID] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByItemType(string itemType)
        {
            string sql = "SELECT TOP 1 [ItemType] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByMaterialType(string materialType)
        {
            string sql = "SELECT TOP 1 [MaterialType] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = "SELECT TOP 1 [PackageSizeType] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByPackageCategory(string packageCategory)
        {
            string sql = "SELECT TOP 1 [PackageCategory] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT TOP 1 [BarcodeNo] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByTextureDirection(string textureDirection)
        {
            string sql = "SELECT TOP 1 [TextureDirection] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "SELECT TOP 1 [MadeWidth] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "SELECT TOP 1 [MadeHeight] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByMadeLength(decimal madeLength)
        {
            string sql = "SELECT TOP 1 [MadeLength] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByEndWidth(decimal endWidth)
        {
            string sql = "SELECT TOP 1 [EndWidth] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByEndLength(decimal endLength)
        {
            string sql = "SELECT TOP 1 [EndLength] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByFrontLabel(string frontLabel)
        {
            string sql = "SELECT TOP 1 [FrontLabel] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByBackLabel(string backLabel)
        {
            string sql = "SELECT TOP 1 [BackLabel] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByRemarks(string remarks)
        {
            string sql = "SELECT TOP 1 [Remarks] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "SELECT TOP 1 [EdgeDesc] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "SELECT TOP 1 [IsSpecialShap] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_ProductDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteProductDetails()
        {
            string sql = "DELETE FROM [BE_ProductDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByProductID(Guid productID)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByItemType(string itemType)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByMaterialType(string materialType)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByPackageCategory(string packageCategory)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByTextureDirection(string textureDirection)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByMadeLength(decimal madeLength)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByEndWidth(decimal endWidth)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByEndLength(decimal endLength)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByFrontLabel(string frontLabel)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByBackLabel(string backLabel)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByRemarks(string remarks)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_ProductDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<ProductDetail> LoadProductDetails()
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByProductID(Guid productID)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByItemName(string itemName)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByItemType(string itemType)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByMaterialType(string materialType)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [MaterialType]=@MaterialType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialType = new SqlParameter("MaterialType", materialType);
            pMaterialType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMaterialType);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByPackageSizeType(string packageSizeType)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [PackageSizeType]=@PackageSizeType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageSizeType = new SqlParameter("PackageSizeType", packageSizeType);
            pPackageSizeType.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pPackageSizeType);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByPackageCategory(string packageCategory)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [PackageCategory]=@PackageCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageCategory = new SqlParameter("PackageCategory", packageCategory);
            pPackageCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageCategory);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByBarcodeNo(string barcodeNo)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByTextureDirection(string textureDirection)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [TextureDirection]=@TextureDirection";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTextureDirection = new SqlParameter("TextureDirection", textureDirection);
            pTextureDirection.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTextureDirection);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByMadeWidth(decimal madeWidth)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [MadeWidth]=@MadeWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeWidth = new SqlParameter("MadeWidth", madeWidth);
            pMadeWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeWidth);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByMadeHeight(decimal madeHeight)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [MadeHeight]=@MadeHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeHeight = new SqlParameter("MadeHeight", madeHeight);
            pMadeHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeHeight);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByMadeLength(decimal madeLength)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [MadeLength]=@MadeLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeLength = new SqlParameter("MadeLength", madeLength);
            pMadeLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeLength);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByEndWidth(decimal endWidth)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [EndWidth]=@EndWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndWidth = new SqlParameter("EndWidth", endWidth);
            pEndWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndWidth);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByEndLength(decimal endLength)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [EndLength]=@EndLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEndLength = new SqlParameter("EndLength", endLength);
            pEndLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pEndLength);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByQty(decimal qty)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByFrontLabel(string frontLabel)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [FrontLabel]=@FrontLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFrontLabel = new SqlParameter("FrontLabel", frontLabel);
            pFrontLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pFrontLabel);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByBackLabel(string backLabel)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [BackLabel]=@BackLabel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBackLabel = new SqlParameter("BackLabel", backLabel);
            pBackLabel.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pBackLabel);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByRemarks(string remarks)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByEdgeDesc(string edgeDesc)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [EdgeDesc]=@EdgeDesc";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEdgeDesc = new SqlParameter("EdgeDesc", edgeDesc);
            pEdgeDesc.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pEdgeDesc);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByIsSpecialShap(bool isSpecialShap)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [IsSpecialShap]=@IsSpecialShap";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSpecialShap = new SqlParameter("IsSpecialShap", isSpecialShap);
            pIsSpecialShap.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSpecialShap);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByModified(DateTime modified)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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
        public List<ProductDetail> LoadProductDetailsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [ItemName]
				, [ItemType]
				, [MaterialType]
				, [PackageSizeType]
				, [PackageCategory]
				, [BarcodeNo]
				, [TextureDirection]
				, [MadeWidth]
				, [MadeHeight]
				, [MadeLength]
				, [EndWidth]
				, [EndLength]
				, [Qty]
				, [FrontLabel]
				, [BackLabel]
				, [Remarks]
				, [EdgeDesc]
				, [IsSpecialShap]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<ProductDetail> ret = new List<ProductDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductDetail iret = new ProductDetail();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.MaterialType = dr["MaterialType"].ToString();
                    iret.PackageSizeType = dr["PackageSizeType"].ToString();
                    iret.PackageCategory = dr["PackageCategory"].ToString();
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.TextureDirection = dr["TextureDirection"].ToString();
                    if (!Convert.IsDBNull(dr["MadeWidth"]))
                        iret.MadeWidth = (decimal)dr["MadeWidth"];
                    if (!Convert.IsDBNull(dr["MadeHeight"]))
                        iret.MadeHeight = (decimal)dr["MadeHeight"];
                    if (!Convert.IsDBNull(dr["MadeLength"]))
                        iret.MadeLength = (decimal)dr["MadeLength"];
                    if (!Convert.IsDBNull(dr["EndWidth"]))
                        iret.EndWidth = (decimal)dr["EndWidth"];
                    if (!Convert.IsDBNull(dr["EndLength"]))
                        iret.EndLength = (decimal)dr["EndLength"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.FrontLabel = dr["FrontLabel"].ToString();
                    iret.BackLabel = dr["BackLabel"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
                    iret.EdgeDesc = dr["EdgeDesc"].ToString();
                    if (!Convert.IsDBNull(dr["IsSpecialShap"]))
                        iret.IsSpecialShap = (bool)dr["IsSpecialShap"];
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

        #region BE_ProductDetail SearchObject()
        public SearchResult SearchProductDetail(SearchProductDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CategoryID] ASC,[ProductCode],[BarcodeNo]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_ProductMain].[ProductID]                                        
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
                                          ,[Remark]
	                                      ,[ItemID]   
                                          ,[ItemName]
                                          ,[ItemType]
                                          ,[MaterialType]
                                          ,[PackageSizeType]
                                          ,[PackageCategory]
                                          ,[BarcodeNo]
                                          ,[TextureDirection]
                                          ,[MadeWidth]
                                          ,[MadeHeight]
                                          ,[MadeLength]
                                          ,[EndWidth]
                                          ,[EndLength]
                                          ,[Qty]
                                          ,[FrontLabel]
                                          ,[BackLabel]
                                          ,[Remarks]
                                          ,[EdgeDesc]
                                          ,[IsSpecialShap]     
                                          ,[BE_ProductDetail].[Created]
                                          ,[BE_ProductDetail].[CreatedBy]
                                          ,[BE_ProductDetail].[Modified]
                                          ,[BE_ProductDetail].[ModifiedBy]
                                      FROM 
	                                       [BE_ProductMain] with(nolock)
	                                        LEFT JOIN [BE_ProductDetail] with(nolock) on [BE_ProductMain].[ProductID] = [BE_ProductDetail].[ProductID]
	                                        LEFT JOIN [BE_Category] with(nolock) on [BE_ProductMain].[CategoryID] = [BE_Category].[CategoryID]
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

            if (args.ItemID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductDetail].[ItemID", "mbItemID", args.ItemID.Value);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductDetail].[IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap.Value);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
