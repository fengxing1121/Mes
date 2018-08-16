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

        #region BE_Order2Hardware InsertObject()
        public int InsertOrder2Hardware(Order2Hardware obj)
        {
            string sql = @"INSERT INTO[BE_Order2Hardware]([ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				, @BarcodeNo
				, @OrderID
				, @CabinetID
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

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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

        #region BE_Order2Hardware UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateOrder2HardwareByItemID(Order2Hardware obj)
        {
            string sql = @"UPDATE [BE_Order2Hardware] SET [BarcodeNo]=@BarcodeNo
				, [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
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

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", Convert2DBnull(obj.BarcodeNo));
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

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
        public int DeleteOrder2HardwareByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_Order2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadOrder2HardwareByItemID(Order2Hardware obj)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
 				FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
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
                    obj.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
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

        #region BE_Order2Hardware CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountOrder2Hardwares()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByRemarks(string remarks)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountOrder2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsOrder2Hardwares()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Order2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT TOP 1 [BarcodeNo] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "SELECT TOP 1 [HardwareCode] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "SELECT TOP 1 [HardwareName] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "SELECT TOP 1 [HardwareCategory] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByRemarks(string remarks)
        {
            string sql = "SELECT TOP 1 [Remarks] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsOrder2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Order2Hardware] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteOrder2Hardwares()
        {
            string sql = "DELETE FROM [BE_Order2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByStyle(string style)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByRemarks(string remarks)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteOrder2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Order2Hardware] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Order2Hardware> LoadOrder2Hardwares()
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByOrderID(Guid orderID)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByHardwareName(string hardwareName)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByStyle(string style)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByQty(decimal qty)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByUnit(string unit)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByRemarks(string remarks)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByCreated(DateTime created)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByModified(DateTime modified)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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
        public List<Order2Hardware> LoadOrder2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [OrderID]
				, [CabinetID]
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
				 FROM [BE_Order2Hardware] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Order2Hardware> ret = new List<Order2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Order2Hardware iret = new Order2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
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

        #region BE_Order2Hardware SearchObject()
        public SearchResult SearchOrder2Hardware(SearchOrder2HardwareArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkCenterCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Order2Hardware].[ItemID]
                                        ,[BE_Order2Hardware].[BarcodeNo]
                                        ,[BE_Order2Hardware].[OrderID]
                                        ,[BE_Order2Hardware].[CabinetID]
                                        ,[BE_Order2Cabinet].[CabinetName]
                                        ,[BE_Order2Cabinet].[Size]
                                        ,[BE_Order2Cabinet].[Color]
                                        ,[BE_Order2Cabinet].[MaterialStyle]
                                        ,[BE_Order2Cabinet].[MaterialCategory]
                                        ,[BE_Order2Hardware].[HardwareCode]
                                        ,[BE_Order2Hardware].[HardwareName]
                                        ,[BE_Order2Hardware].[HardwareCategory]
                                        ,[BE_Order2Hardware].[Style]
                                        ,[BE_Order2Hardware].[Unit]
                                        ,[BE_Order2Hardware].[Qty]
                                        ,[BE_Order2Hardware].[Remarks]
                                        ,[BE_Order2Hardware].[Created]
                                        ,[BE_Order2Hardware].[CreatedBy]
                                        ,[BE_Order2Hardware].[Modified]
                                        ,[BE_Order2Hardware].[ModifiedBy]                                       
                                    FROM [BE_Order2Hardware] with(nolock)                                   
                                    LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_Order2Cabinet].[CabinetID] = [BE_Order2Hardware].[CabinetID]
	                                WHERE 1=1");
            if (args.ItemID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order2Hardware].[ItemID", "mbItemID", args.ItemID.Value);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order2Hardware].[CabinetID", "mbCabinetID", args.CabinetID.Value);
            }
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order2Hardware].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (!string.IsNullOrEmpty(args.HardwareCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "HardwareCode", "mbHardwareCode", args.HardwareCode);
            }
            if (!string.IsNullOrEmpty(args.HardwareName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "HardwareName", "mbHardwareName", args.HardwareName);
            }
            if (!string.IsNullOrEmpty(args.CabinetName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetName);
            }
            if (!string.IsNullOrEmpty(args.HardwareCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "HardwareCategory", "mbHardwareCategory", args.HardwareCategory);
            }
            if (!string.IsNullOrEmpty(args.Style))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Style", "mbStyle", args.Style);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
