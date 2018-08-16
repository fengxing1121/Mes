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

        #region BE_Product2Hardware InsertObject()
        public int InsertProduct2Hardware(Product2Hardware obj)
        {
            string sql = @"INSERT INTO[BE_Product2Hardware]([ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@ItemID
				, @ProductID
				, @BarcodeNo
				, @HardwareCode
				, @HardwareName
				, @HardwareCategory
				, @Style
				, @Qty
				, @Unit
				, @Remarks
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

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", Convert2DBnull(obj.HardwareCode));
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", Convert2DBnull(obj.HardwareName));
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", Convert2DBnull(obj.HardwareCategory));
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

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

        #region BE_Product2Hardware UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateProduct2HardwareByItemID(Product2Hardware obj)
        {
            string sql = @"UPDATE [BE_Product2Hardware] SET [ProductID]=@ProductID
				, [BarcodeNo]=@BarcodeNo
				, [HardwareCode]=@HardwareCode
				, [HardwareName]=@HardwareName
				, [HardwareCategory]=@HardwareCategory
				, [Style]=@Style
				, [Qty]=@Qty
				, [Unit]=@Unit
				, [Remarks]=@Remarks
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", Convert2DBnull(obj.ProductID));
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", Convert2DBnull(obj.HardwareCode));
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", Convert2DBnull(obj.HardwareName));
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", Convert2DBnull(obj.HardwareCategory));
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pRemarks = new SqlParameter("Remarks", Convert2DBnull(obj.Remarks));
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

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
        public int DeleteProduct2HardwareByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_Product2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadProduct2HardwareByItemID(Product2Hardware obj)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
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
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    obj.HardwareCode = dr["HardwareCode"].ToString();
                    obj.HardwareName = dr["HardwareName"].ToString();
                    obj.HardwareCategory = dr["HardwareCategory"].ToString();
                    obj.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    obj.Unit = dr["Unit"].ToString();
                    obj.Remarks = dr["Remarks"].ToString();
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

        #region BE_Product2Hardware CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountProduct2Hardwares()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByProductID(Guid productID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByRemarks(string remarks)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProduct2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsProduct2Hardwares()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Product2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByProductID(Guid productID)
        {
            string sql = "SELECT TOP 1 [ProductID] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT TOP 1 [BarcodeNo] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "SELECT TOP 1 [HardwareCode] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "SELECT TOP 1 [HardwareName] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "SELECT TOP 1 [HardwareCategory] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByRemarks(string remarks)
        {
            string sql = "SELECT TOP 1 [Remarks] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProduct2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Product2Hardware] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteProduct2Hardwares()
        {
            string sql = "DELETE FROM [BE_Product2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByProductID(Guid productID)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByStyle(string style)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByRemarks(string remarks)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProduct2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Product2Hardware] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Product2Hardware> LoadProduct2Hardwares()
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByProductID(Guid productID)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductID = new SqlParameter("ProductID", productID);
            pProductID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductID);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByHardwareName(string hardwareName)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByStyle(string style)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByQty(decimal qty)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByUnit(string unit)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByRemarks(string remarks)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByCreated(DateTime created)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByModified(DateTime modified)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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
        public List<Product2Hardware> LoadProduct2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ItemID]
				, [ProductID]
				, [BarcodeNo]
				, [HardwareCode]
				, [HardwareName]
				, [HardwareCategory]
				, [Style]
				, [Qty]
				, [Unit]
				, [Remarks]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Product2Hardware] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Product2Hardware> ret = new List<Product2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product2Hardware iret = new Product2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["ProductID"]))
                        iret.ProductID = (Guid)dr["ProductID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    iret.HardwareCode = dr["HardwareCode"].ToString();
                    iret.HardwareName = dr["HardwareName"].ToString();
                    iret.HardwareCategory = dr["HardwareCategory"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    iret.Remarks = dr["Remarks"].ToString();
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

        #region BE_Product2Hardware SearchObject()
        public SearchResult SearchProductHardware(SearchProduct2HardwareArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CategoryID] ASC,[ProductCode]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [ItemID]                                           
                                            ,[BE_ProductMain].[CategoryID]
	                                        ,[BE_Category].[CategoryName]
                                            ,[ProductCode]
                                            ,[ProductName]
                                            ,[Size]
                                            ,[Color]
                                            ,[MaterialStyle]
                                            ,[MaterialCategory]
                                            ,[Price]
                                            ,[BE_Product2Hardware].[ProductID]
                                            ,[BarcodeNo]
                                            ,[HardwareCode]
                                            ,[HardwareName]
                                            ,[HardwareCategory]
                                            ,[Style]
                                            ,[Qty]
                                            ,[Unit]
                                            ,[Remarks]
                                            ,[BE_Product2Hardware].[Created]
                                            ,[BE_Product2Hardware].[CreatedBy]
                                            ,[BE_Product2Hardware].[Modified]
                                            ,[BE_Product2Hardware].[ModifiedBy]
                                        FROM 
                                            [BE_Product2Hardware]
                                            LEFT JOIN [BE_ProductMain] on [BE_Product2Hardware].[ProductID] = [BE_ProductMain].[ProductID]
                                            LEFT JOIN [BE_Category]  with(nolock) on [BE_ProductMain].[CategoryID] = [BE_Category].[CategoryID]
                                        WHERE 1=1");


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

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
