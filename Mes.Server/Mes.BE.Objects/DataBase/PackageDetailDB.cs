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
       
        #region BE_PackageDetail InsertObject()
        public int InsertPackageDetail(PackageDetail obj)
        {
            string sql = @"INSERT INTO[BE_PackageDetail]([DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@DetailID
				, @BattchNo
				, @ItemID
				, @Qty
				, @PakageID
				, @LayerNum
				, @IsPackaged
				, @IsOptimized
				, @IsPlanning
				, @IsDisabled
				, @CheckedBy
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", Convert2DBnull(obj.BattchNo));
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            SqlParameter pPakageID = new SqlParameter("PakageID", Convert2DBnull(obj.PakageID));
            pPakageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPakageID);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", Convert2DBnull(obj.LayerNum));
            pLayerNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLayerNum);

            SqlParameter pIsPackaged = new SqlParameter("IsPackaged", Convert2DBnull(obj.IsPackaged));
            pIsPackaged.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPackaged);

            SqlParameter pIsOptimized = new SqlParameter("IsOptimized", Convert2DBnull(obj.IsOptimized));
            pIsOptimized.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimized);

            SqlParameter pIsPlanning = new SqlParameter("IsPlanning", Convert2DBnull(obj.IsPlanning));
            pIsPlanning.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPlanning);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pCheckedBy = new SqlParameter("CheckedBy", Convert2DBnull(obj.CheckedBy));
            pCheckedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCheckedBy);

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

        #region BE_PackageDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePackageDetailByDetailID(PackageDetail obj)
        {
            string sql = @"UPDATE [BE_PackageDetail] SET [BattchNo]=@BattchNo
				, [ItemID]=@ItemID
				, [Qty]=@Qty
				, [PakageID]=@PakageID
				, [LayerNum]=@LayerNum
				, [IsPackaged]=@IsPackaged
				, [IsOptimized]=@IsOptimized
				, [IsPlanning]=@IsPlanning
				, [IsDisabled]=@IsDisabled
				, [CheckedBy]=@CheckedBy
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", Convert2DBnull(obj.BattchNo));
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            SqlParameter pItemID = new SqlParameter("ItemID", Convert2DBnull(obj.ItemID));
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            SqlParameter pPakageID = new SqlParameter("PakageID", Convert2DBnull(obj.PakageID));
            pPakageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPakageID);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", Convert2DBnull(obj.LayerNum));
            pLayerNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLayerNum);

            SqlParameter pIsPackaged = new SqlParameter("IsPackaged", Convert2DBnull(obj.IsPackaged));
            pIsPackaged.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPackaged);

            SqlParameter pIsOptimized = new SqlParameter("IsOptimized", Convert2DBnull(obj.IsOptimized));
            pIsOptimized.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimized);

            SqlParameter pIsPlanning = new SqlParameter("IsPlanning", Convert2DBnull(obj.IsPlanning));
            pIsPlanning.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPlanning);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pCheckedBy = new SqlParameter("CheckedBy", Convert2DBnull(obj.CheckedBy));
            pCheckedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCheckedBy);

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

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_PackageDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPackageDetailByDetailID(PackageDetail obj)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        obj.DetailID = (Guid)dr["DetailID"];
                    obj.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        obj.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        obj.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        obj.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        obj.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        obj.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        obj.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.CheckedBy = dr["CheckedBy"].ToString();
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

        #region BE_PackageDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPackageDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByBattchNo(string battchNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByQty(int qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByPakageID(Guid pakageID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [PakageID]=@PakageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPakageID = new SqlParameter("PakageID", pakageID);
            pPakageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPakageID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByLayerNum(int layerNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLayerNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByIsPackaged(bool isPackaged)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsPackaged]=@IsPackaged";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPackaged = new SqlParameter("IsPackaged", isPackaged);
            pIsPackaged.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPackaged);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByIsOptimized(bool isOptimized)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsOptimized]=@IsOptimized";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsOptimized = new SqlParameter("IsOptimized", isOptimized);
            pIsOptimized.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimized);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByIsPlanning(bool isPlanning)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsPlanning]=@IsPlanning";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPlanning = new SqlParameter("IsPlanning", isPlanning);
            pIsPlanning.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPlanning);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByCheckedBy(string checkedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [CheckedBy]=@CheckedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckedBy = new SqlParameter("CheckedBy", checkedBy);
            pCheckedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCheckedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackageDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPackageDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PackageDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByBattchNo(string battchNo)
        {
            string sql = "SELECT TOP 1 [BattchNo] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByItemID(Guid itemID)
        {
            string sql = "SELECT TOP 1 [ItemID] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByQty(int qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByPakageID(Guid pakageID)
        {
            string sql = "SELECT TOP 1 [PakageID] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [PakageID]=@PakageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPakageID = new SqlParameter("PakageID", pakageID);
            pPakageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPakageID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByLayerNum(int layerNum)
        {
            string sql = "SELECT TOP 1 [LayerNum] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLayerNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByIsPackaged(bool isPackaged)
        {
            string sql = "SELECT TOP 1 [IsPackaged] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsPackaged]=@IsPackaged";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPackaged = new SqlParameter("IsPackaged", isPackaged);
            pIsPackaged.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPackaged);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByIsOptimized(bool isOptimized)
        {
            string sql = "SELECT TOP 1 [IsOptimized] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsOptimized]=@IsOptimized";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsOptimized = new SqlParameter("IsOptimized", isOptimized);
            pIsOptimized.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimized);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByIsPlanning(bool isPlanning)
        {
            string sql = "SELECT TOP 1 [IsPlanning] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsPlanning]=@IsPlanning";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPlanning = new SqlParameter("IsPlanning", isPlanning);
            pIsPlanning.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPlanning);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByCheckedBy(string checkedBy)
        {
            string sql = "SELECT TOP 1 [CheckedBy] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [CheckedBy]=@CheckedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckedBy = new SqlParameter("CheckedBy", checkedBy);
            pCheckedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCheckedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackageDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PackageDetail] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePackageDetails()
        {
            string sql = "DELETE FROM [BE_PackageDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByBattchNo(string battchNo)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByItemID(Guid itemID)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByQty(int qty)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByPakageID(Guid pakageID)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [PakageID]=@PakageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPakageID = new SqlParameter("PakageID", pakageID);
            pPakageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPakageID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByLayerNum(int layerNum)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLayerNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByIsPackaged(bool isPackaged)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [IsPackaged]=@IsPackaged";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPackaged = new SqlParameter("IsPackaged", isPackaged);
            pIsPackaged.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPackaged);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByIsOptimized(bool isOptimized)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [IsOptimized]=@IsOptimized";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsOptimized = new SqlParameter("IsOptimized", isOptimized);
            pIsOptimized.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimized);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByIsPlanning(bool isPlanning)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [IsPlanning]=@IsPlanning";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPlanning = new SqlParameter("IsPlanning", isPlanning);
            pIsPlanning.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPlanning);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByCheckedBy(string checkedBy)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [CheckedBy]=@CheckedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckedBy = new SqlParameter("CheckedBy", checkedBy);
            pCheckedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCheckedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageDetailsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PackageDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PackageDetail> LoadPackageDetails()
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByDetailID(Guid detailID)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByBattchNo(string battchNo)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [BattchNo]=@BattchNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBattchNo = new SqlParameter("BattchNo", battchNo);
            pBattchNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBattchNo);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByItemID(Guid itemID)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [ItemID]=@ItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemID = new SqlParameter("ItemID", itemID);
            pItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pItemID);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByQty(int qty)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByPakageID(Guid pakageID)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [PakageID]=@PakageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPakageID = new SqlParameter("PakageID", pakageID);
            pPakageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPakageID);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByLayerNum(int layerNum)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLayerNum);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByIsPackaged(bool isPackaged)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [IsPackaged]=@IsPackaged";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPackaged = new SqlParameter("IsPackaged", isPackaged);
            pIsPackaged.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPackaged);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByIsOptimized(bool isOptimized)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [IsOptimized]=@IsOptimized";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsOptimized = new SqlParameter("IsOptimized", isOptimized);
            pIsOptimized.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsOptimized);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByIsPlanning(bool isPlanning)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [IsPlanning]=@IsPlanning";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsPlanning = new SqlParameter("IsPlanning", isPlanning);
            pIsPlanning.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsPlanning);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByCheckedBy(string checkedBy)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [CheckedBy]=@CheckedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCheckedBy = new SqlParameter("CheckedBy", checkedBy);
            pCheckedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCheckedBy);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByModified(DateTime modified)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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
        public List<PackageDetail> LoadPackageDetailsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [DetailID]
				, [BattchNo]
				, [ItemID]
				, [Qty]
				, [PakageID]
				, [LayerNum]
				, [IsPackaged]
				, [IsOptimized]
				, [IsPlanning]
				, [IsDisabled]
				, [CheckedBy]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PackageDetail] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PackageDetail> ret = new List<PackageDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PackageDetail iret = new PackageDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.BattchNo = dr["BattchNo"].ToString();
                    if (!Convert.IsDBNull(dr["ItemID"]))
                        iret.ItemID = (Guid)dr["ItemID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    if (!Convert.IsDBNull(dr["PakageID"]))
                        iret.PakageID = (Guid)dr["PakageID"];
                    if (!Convert.IsDBNull(dr["LayerNum"]))
                        iret.LayerNum = (int)dr["LayerNum"];
                    if (!Convert.IsDBNull(dr["IsPackaged"]))
                        iret.IsPackaged = (bool)dr["IsPackaged"];
                    if (!Convert.IsDBNull(dr["IsOptimized"]))
                        iret.IsOptimized = (bool)dr["IsOptimized"];
                    if (!Convert.IsDBNull(dr["IsPlanning"]))
                        iret.IsPlanning = (bool)dr["IsPlanning"];
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.CheckedBy = dr["CheckedBy"].ToString();
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

        #region BE_PackageDetail SearchObject()
        public SearchResult SearchPackageDetail(SearchPackageDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderID] ASC,[CabinetID] ASC,[PackageID] ASC,[PackageNum] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Package].[PackageID]
                                        ,[BE_Package].[PackageBarcode]
                                        ,[BE_Order].[OrderID]
                                        ,[BE_Order2Cabinet].[CabinetID]
                                        ,[BE_Package].[PackageNum]
                                        ,[BE_Package].[PackageWidth]
                                        ,[BE_Package].[PackageHeight]
                                        ,[BE_Package].[PackageLength]
                                        ,[BE_Package].[Weight]
                                        ,[BE_Package].[ItemsQty]                                                                      
										,[BE_Order].[OrderNo]
										,[BE_Order].[OutOrderNo]
										,[BE_Order].[OrderType]
										,[BE_Order].[PurchaseNo]
										,[BE_Order].[CustomerID]
										,[BE_Order].[CustomerName]
										,[BE_Order].[BattchNum]
										,[BE_Order].[BookingDate]
										,[BE_Order].[ShipDate]
                                        ,[BE_Order].[IsStandard]
                                        ,[BE_Order].[IsOutsourcing]
										,[BE_Order2Cabinet].[CabinetCode]
										,[BE_Order2Cabinet].[CabinetName]
										,[BE_Order2Cabinet].[Size]
										,[BE_Order2Cabinet].[Color]
										,[BE_Order2Cabinet].[MaterialStyle]
										,[BE_Order2Cabinet].[MaterialCategory]
										,[DetailID]
										,[BattchNo]
										,[BE_PackageDetail].[ItemID]
										,[BE_PackageDetail].[Qty]
										,[BE_PackageDetail].[PakageID]
										,[BE_PackageDetail].[LayerNum]
										,[BE_PackageDetail].[IsPackaged]
										,[BE_PackageDetail].[IsOptimized]
										,[BE_PackageDetail].[IsPlanning]
										,[BE_PackageDetail].[IsDisabled]
										,[BE_PackageDetail].[CheckedBy]
										,[BE_PackageDetail].[Created]
										,[BE_PackageDetail].[CreatedBy]
										,[BE_PackageDetail].[Modified]
										,[BE_PackageDetail].[ModifiedBy]
										,[BE_OrderDetail].[ItemName]
										,[BE_OrderDetail].[ItemCategory]
										,[BE_OrderDetail].[MaterialType]
										,[BE_OrderDetail].[ItemType]
										,[BE_OrderDetail].[PackageSizeType]
										,[BE_OrderDetail].[PackageCategory]
										,[BE_OrderDetail].[BarcodeNo]
										,[BE_OrderDetail].[MadeHeight]
										,[BE_OrderDetail].[MadeWidth]
										,[BE_OrderDetail].[MadeLength]
										,[BE_OrderDetail].[EndWidth]
										,[BE_OrderDetail].[EndLength]										
                                    FROM 
										[BE_PackageDetail] with(nolock)
                                        LEFT JOIN [BE_Package] with(nolock) on [BE_PackageDetail].[PakageID] = [BE_Package].[PackageID]
										LEFT JOIN [BE_OrderDetail] with(nolock) on [BE_OrderDetail].[ItemID] = [BE_PackageDetail].[ItemID]
										LEFT JOIN [BE_Order] with(nolock) on [BE_OrderDetail].[OrderID] = [BE_Order].[OrderID]
										LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_Order2Cabinet].[CabinetID] = [BE_OrderDetail].[CabinetID]										
	                                WHERE 1=1");

            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderDetail].[CabinetID", "mbCabinetID", args.CabinetID);
            }
            if (args.PackageID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[PackageID", "mbPackageID", args.PackageID);
            }
            if (args.PackageNum.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[PackageNum", "mbPackageNum", args.PackageNum);
            }
            if (!string.IsNullOrEmpty(args.PackageBarcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Package].[PackageBarcode", "mbPackageBarcode", args.PackageBarcode);
            }
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderDetail].[OrderID", "mbOrderID", args.OrderID);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[CustomerID", "mbCustomerID", args.CustomerID);
            }
            if (!string.IsNullOrEmpty(args.CabinetName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetName);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.BattchNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[BattchNum", "mbBattchNo", args.BattchNo);
            }
            if (!string.IsNullOrEmpty(args.Barcode))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_OrderDetail].[BarcodeNo", "mbBarcode", args.Barcode);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsDisabled", "mbIsDisabled", args.IsDisabled);
            }
            if (args.IsOptimized.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOptimized", "mbIsOptimized", args.IsOptimized);
            }
            if (args.IsPackaged.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsPackaged", "mbIsPackaged", args.IsPackaged);
            }
            if (args.IsPlanning.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsPlanning", "mbIsPlanning", args.IsPlanning);
            }
            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }
            if (!string.IsNullOrEmpty(args.ItemCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemCategory", "mbItemCategory", args.ItemCategory);
            }
            if (!string.IsNullOrEmpty(args.CabinetCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetCode", "mbCabinetCode", args.CabinetCode);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }
            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }
            if (!string.IsNullOrEmpty(args.MaterialType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[MaterialType", "mbMaterialType", args.MaterialType);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemName", "mbItemName", args.ItemName);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.PackageCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[PackageCategory", "mbPackageCategory", args.PackageCategory);
            }
            if (!string.IsNullOrEmpty(args.PackageSizeType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_OrderDetail].[PackageSizeType", "mbPackageSizeType", args.PackageSizeType);
            }
            if (args.IsSpecialShap.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsSpecialShap", "mbIsSpecialShap", args.IsSpecialShap);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
