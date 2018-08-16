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
      
        #region BE_Solution2Hardware InsertObject()
        public int InsertSolution2Hardware(Solution2Hardware obj)
        {
            string sql = @"INSERT INTO[BE_Solution2Hardware]([ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				, @SolutionID
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

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

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

        #region BE_Solution2Hardware UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSolution2HardwareByItemID(Solution2Hardware obj)
        {
            string sql = @"UPDATE [BE_Solution2Hardware] SET [BarcodeNo]=@BarcodeNo
				, [SolutionID]=@SolutionID
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

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

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
        public int DeleteSolution2HardwareByItemID(Guid itemID)
        {
            string sql = @"DELETE [BE_Solution2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSolution2HardwareByItemID(Solution2Hardware obj)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
 				FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
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
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
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

        #region BE_Solution2Hardware CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSolution2Hardwares()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByRemarks(string remarks)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolution2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSolution2Hardwares()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Solution2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "SELECT TOP 1 [BarcodeNo] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "SELECT TOP 1 [HardwareCode] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "SELECT TOP 1 [HardwareName] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "SELECT TOP 1 [HardwareCategory] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByRemarks(string remarks)
        {
            string sql = "SELECT TOP 1 [Remarks] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolution2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Solution2Hardware] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSolution2Hardwares()
        {
            string sql = "DELETE FROM [BE_Solution2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByHardwareName(string hardwareName)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByStyle(string style)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByRemarks(string remarks)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolution2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Solution2Hardware] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Solution2Hardware> LoadSolution2Hardwares()
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByItemID(Guid itemID)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByBarcodeNo(string barcodeNo)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [BarcodeNo]=@BarcodeNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBarcodeNo = new SqlParameter("BarcodeNo", barcodeNo);
            pBarcodeNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBarcodeNo);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByHardwareCode(string hardwareCode)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [HardwareCode]=@HardwareCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCode = new SqlParameter("HardwareCode", hardwareCode);
            pHardwareCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCode);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByHardwareName(string hardwareName)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [HardwareName]=@HardwareName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareName = new SqlParameter("HardwareName", hardwareName);
            pHardwareName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareName);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByHardwareCategory(string hardwareCategory)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [HardwareCategory]=@HardwareCategory";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pHardwareCategory = new SqlParameter("HardwareCategory", hardwareCategory);
            pHardwareCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pHardwareCategory);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByStyle(string style)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByQty(decimal qty)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByUnit(string unit)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByRemarks(string remarks)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [Remarks]=@Remarks";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemarks = new SqlParameter("Remarks", remarks);
            pRemarks.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pRemarks);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByCreated(DateTime created)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByModified(DateTime modified)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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
        public List<Solution2Hardware> LoadSolution2HardwaresByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [ItemID]
				, [BarcodeNo]
				, [SolutionID]
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
				 FROM [BE_Solution2Hardware] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Solution2Hardware> ret = new List<Solution2Hardware>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Solution2Hardware iret = new Solution2Hardware();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    iret.BarcodeNo = dr["BarcodeNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
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

        #region BE_Solution2Hardware SearchObject()
        public SearchResult SearchSolutionHardware(SearchSolution2HardwareArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[SolutionCode] ASC,[BarcodeNo]";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Solution].[SolutionID]	                                       
                                            ,[SolutionCode]
                                            ,[SolutionName]
                                            ,[Size]                                       
                                            ,[MaterialStyle]
                                            ,[MaterialCategory]                                         
                                            ,[BE_Solution2Hardware].[ItemID]
                                            ,[BE_Solution2Hardware].[CabinetID]
                                            ,[BE_Solution2Cabinet].[CabinetName]
                                            ,[BE_Solution2Hardware].[BarcodeNo]
                                            ,[BE_Solution2Hardware].[HardwareCode]
                                            ,[BE_Solution2Hardware].[HardwareName]
                                            ,[BE_Solution2Hardware].[HardwareCategory]
                                            ,[BE_Solution2Hardware].[Style]
                                            ,[BE_Solution2Hardware].[Qty]
                                            ,[BE_Solution2Hardware].[Unit]
                                            ,[BE_Solution2Hardware].[Remarks]
                                            ,[BE_Solution2Hardware].[Created]
                                            ,[BE_Solution2Hardware].[CreatedBy]
                                            ,[BE_Solution2Hardware].[Modified]
                                            ,[BE_Solution2Hardware].[ModifiedBy]
											,[BE_Material].[QuotedPrice]
                                        FROM 
                                            [BE_Solution2Hardware] with(nolock)
                                            LEFT JOIN [BE_Solution] with(nolock) on [BE_Solution2Hardware].[SolutionID] = [BE_Solution].[SolutionID]
                                            LEFT JOIN [BE_Solution2Cabinet] with(nolock) on [BE_Solution2Cabinet].[CabinetID] = [BE_Solution2Hardware].[CabinetID]
											LEFT JOIN [BE_Material] with(nolock) on [BE_Material].[MaterialCode] = [BE_Solution2Hardware].[HardwareCode]
                                        WHERE 1=1");


            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution].[SolutionID", "mbSolutionID", args.SolutionID.Value);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Solution2Hardware].[CabinetID", "mbCabinetID", args.CabinetID.Value);
            }
            if (!string.IsNullOrEmpty(args.SolutionCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionCode", "mbSolutionCode", args.SolutionCode);
            }
            if (!string.IsNullOrEmpty(args.SolutionName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Solution].[SolutionName", "mbSolutionName", args.SolutionName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.Size))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Size", "mbSize", args.Size);
            }

            if (!string.IsNullOrEmpty(args.MaterialCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialCategory", "mbMaterialCategory", args.MaterialCategory);
            }
            if (!string.IsNullOrEmpty(args.MaterialStyle))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialStyle", "mbMaterialStyle", args.MaterialStyle);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public SearchResult SearchSolutionQuoteHardwareDetail(Guid SolutonID)
        {
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"select 
	                                [BE_Solution2Hardware].[HardwareCode]
									,[BE_Solution2Hardware].[HardwareName]
									,[BE_Material].[Style]
									,[BE_Material].[Unit]
									,QuotedPrice
	                                ,TotalQty = Sum(Qty)
									,Amount = ISNULL( Sum(Qty) * QuotedPrice,0)
									,Remark = ''
                                from 
	                                [BE_Solution2Hardware] with(nolock) 
									LEFT JOIN [BE_Material]  with(nolock)  on [BE_Material].[MaterialCode] = [BE_Solution2Hardware].[HardwareCode]
                                where 
									1=1
	                                and SolutionID=@SolutionID
                                group by
									[BE_Solution2Hardware].[HardwareCode]
	                                ,[BE_Solution2Hardware].[HardwareName]
									,[BE_Material].[Style]
									,[BE_Material].[Unit]
									,[QuotedPrice]");
            mbBuilder.AppendFormat(") mb");
            cmd.Parameters.AddWithValue("SolutionID", SolutonID);
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, "HardwareName", null, null);
        }
        #endregion
    }
}
