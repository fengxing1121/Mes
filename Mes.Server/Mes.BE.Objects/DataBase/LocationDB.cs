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

        #region BE_Location InsertObject()
        public int InsertLocation(Location obj)
        {
            string sql = @"INSERT INTO[BE_Location]([LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@LocationID
				, @WarehouseID
				, @Category
				, @LocationCode
				, @MaxWeight
				, @MaxPackage
				, @CabinetNum
				, @LayerNum
				, @IsDisabled
				, @PackageQty
				, @Weight
				, @Flag
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            SqlParameter pWarehouseID = new SqlParameter("WarehouseID", Convert2DBnull(obj.WarehouseID));
            pWarehouseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWarehouseID);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pLocationCode = new SqlParameter("LocationCode", Convert2DBnull(obj.LocationCode));
            pLocationCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLocationCode);

            SqlParameter pMaxWeight = new SqlParameter("MaxWeight", Convert2DBnull(obj.MaxWeight));
            pMaxWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxWeight);

            SqlParameter pMaxPackage = new SqlParameter("MaxPackage", Convert2DBnull(obj.MaxPackage));
            pMaxPackage.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxPackage);

            SqlParameter pCabinetNum = new SqlParameter("CabinetNum", Convert2DBnull(obj.CabinetNum));
            pCabinetNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCabinetNum);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", Convert2DBnull(obj.LayerNum));
            pLayerNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pLayerNum);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pPackageQty = new SqlParameter("PackageQty", Convert2DBnull(obj.PackageQty));
            pPackageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageQty);

            SqlParameter pWeight = new SqlParameter("Weight", Convert2DBnull(obj.Weight));
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            SqlParameter pFlag = new SqlParameter("Flag", Convert2DBnull(obj.Flag));
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

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

        #region BE_Location UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateLocationByLocationID(Location obj)
        {
            string sql = @"UPDATE [BE_Location] SET [WarehouseID]=@WarehouseID
				, [Category]=@Category
				, [LocationCode]=@LocationCode
				, [MaxWeight]=@MaxWeight
				, [MaxPackage]=@MaxPackage
				, [CabinetNum]=@CabinetNum
				, [LayerNum]=@LayerNum
				, [IsDisabled]=@IsDisabled
				, [PackageQty]=@PackageQty
				, [Weight]=@Weight
				, [Flag]=@Flag
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWarehouseID = new SqlParameter("WarehouseID", Convert2DBnull(obj.WarehouseID));
            pWarehouseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWarehouseID);

            SqlParameter pCategory = new SqlParameter("Category", Convert2DBnull(obj.Category));
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            SqlParameter pLocationCode = new SqlParameter("LocationCode", Convert2DBnull(obj.LocationCode));
            pLocationCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLocationCode);

            SqlParameter pMaxWeight = new SqlParameter("MaxWeight", Convert2DBnull(obj.MaxWeight));
            pMaxWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxWeight);

            SqlParameter pMaxPackage = new SqlParameter("MaxPackage", Convert2DBnull(obj.MaxPackage));
            pMaxPackage.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxPackage);

            SqlParameter pCabinetNum = new SqlParameter("CabinetNum", Convert2DBnull(obj.CabinetNum));
            pCabinetNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCabinetNum);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", Convert2DBnull(obj.LayerNum));
            pLayerNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pLayerNum);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pPackageQty = new SqlParameter("PackageQty", Convert2DBnull(obj.PackageQty));
            pPackageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageQty);

            SqlParameter pWeight = new SqlParameter("Weight", Convert2DBnull(obj.Weight));
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            SqlParameter pFlag = new SqlParameter("Flag", Convert2DBnull(obj.Flag));
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

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

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationByLocationID(Guid locationID)
        {
            string sql = @"DELETE [BE_Location] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadLocationByLocationID(Location obj)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Location] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        obj.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        obj.WarehouseID = (Guid)dr["WarehouseID"];
                    obj.Category = dr["Category"].ToString();
                    obj.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        obj.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        obj.MaxPackage = (int)dr["MaxPackage"];
                    obj.CabinetNum = dr["CabinetNum"].ToString();
                    obj.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        obj.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        obj.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        obj.Flag = (bool)dr["Flag"];
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

        #region BE_Location CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountLocations()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByLocationID(Guid locationID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByWarehouseID(Guid warehouseID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [WarehouseID]=@WarehouseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWarehouseID = new SqlParameter("WarehouseID", warehouseID);
            pWarehouseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWarehouseID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByCategory(string category)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByLocationCode(string locationCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [LocationCode]=@LocationCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationCode = new SqlParameter("LocationCode", locationCode);
            pLocationCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLocationCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByMaxWeight(decimal maxWeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [MaxWeight]=@MaxWeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxWeight = new SqlParameter("MaxWeight", maxWeight);
            pMaxWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxWeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByMaxPackage(int maxPackage)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [MaxPackage]=@MaxPackage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxPackage = new SqlParameter("MaxPackage", maxPackage);
            pMaxPackage.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxPackage);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByCabinetNum(string cabinetNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [CabinetNum]=@CabinetNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetNum = new SqlParameter("CabinetNum", cabinetNum);
            pCabinetNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCabinetNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByLayerNum(string layerNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pLayerNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByPackageQty(int packageQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [PackageQty]=@PackageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageQty = new SqlParameter("PackageQty", packageQty);
            pPackageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByWeight(decimal weight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByFlag(bool flag)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountLocationsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Location] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsLocations()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Location]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByLocationID(Guid locationID)
        {
            string sql = "SELECT TOP 1 [LocationID] FROM [BE_Location] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByWarehouseID(Guid warehouseID)
        {
            string sql = "SELECT TOP 1 [WarehouseID] FROM [BE_Location] WITH(NOLOCK) WHERE [WarehouseID]=@WarehouseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWarehouseID = new SqlParameter("WarehouseID", warehouseID);
            pWarehouseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWarehouseID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByCategory(string category)
        {
            string sql = "SELECT TOP 1 [Category] FROM [BE_Location] WITH(NOLOCK) WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByLocationCode(string locationCode)
        {
            string sql = "SELECT TOP 1 [LocationCode] FROM [BE_Location] WITH(NOLOCK) WHERE [LocationCode]=@LocationCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationCode = new SqlParameter("LocationCode", locationCode);
            pLocationCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLocationCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByMaxWeight(decimal maxWeight)
        {
            string sql = "SELECT TOP 1 [MaxWeight] FROM [BE_Location] WITH(NOLOCK) WHERE [MaxWeight]=@MaxWeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxWeight = new SqlParameter("MaxWeight", maxWeight);
            pMaxWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxWeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByMaxPackage(int maxPackage)
        {
            string sql = "SELECT TOP 1 [MaxPackage] FROM [BE_Location] WITH(NOLOCK) WHERE [MaxPackage]=@MaxPackage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxPackage = new SqlParameter("MaxPackage", maxPackage);
            pMaxPackage.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxPackage);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByCabinetNum(string cabinetNum)
        {
            string sql = "SELECT TOP 1 [CabinetNum] FROM [BE_Location] WITH(NOLOCK) WHERE [CabinetNum]=@CabinetNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetNum = new SqlParameter("CabinetNum", cabinetNum);
            pCabinetNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCabinetNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByLayerNum(string layerNum)
        {
            string sql = "SELECT TOP 1 [LayerNum] FROM [BE_Location] WITH(NOLOCK) WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pLayerNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_Location] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByPackageQty(int packageQty)
        {
            string sql = "SELECT TOP 1 [PackageQty] FROM [BE_Location] WITH(NOLOCK) WHERE [PackageQty]=@PackageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageQty = new SqlParameter("PackageQty", packageQty);
            pPackageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByWeight(decimal weight)
        {
            string sql = "SELECT TOP 1 [Weight] FROM [BE_Location] WITH(NOLOCK) WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByFlag(bool flag)
        {
            string sql = "SELECT TOP 1 [Flag] FROM [BE_Location] WITH(NOLOCK) WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Location] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Location] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Location] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsLocationsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Location] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteLocations()
        {
            string sql = "DELETE FROM [BE_Location]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByLocationID(Guid locationID)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByWarehouseID(Guid warehouseID)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [WarehouseID]=@WarehouseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWarehouseID = new SqlParameter("WarehouseID", warehouseID);
            pWarehouseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWarehouseID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByCategory(string category)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByLocationCode(string locationCode)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [LocationCode]=@LocationCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationCode = new SqlParameter("LocationCode", locationCode);
            pLocationCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLocationCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByMaxWeight(decimal maxWeight)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [MaxWeight]=@MaxWeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxWeight = new SqlParameter("MaxWeight", maxWeight);
            pMaxWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxWeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByMaxPackage(int maxPackage)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [MaxPackage]=@MaxPackage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxPackage = new SqlParameter("MaxPackage", maxPackage);
            pMaxPackage.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxPackage);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByCabinetNum(string cabinetNum)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [CabinetNum]=@CabinetNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetNum = new SqlParameter("CabinetNum", cabinetNum);
            pCabinetNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCabinetNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByLayerNum(string layerNum)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pLayerNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByPackageQty(int packageQty)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [PackageQty]=@PackageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageQty = new SqlParameter("PackageQty", packageQty);
            pPackageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByWeight(decimal weight)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByFlag(bool flag)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteLocationsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Location] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Location> LoadLocations()
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByLocationID(Guid locationID)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByWarehouseID(Guid warehouseID)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [WarehouseID]=@WarehouseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWarehouseID = new SqlParameter("WarehouseID", warehouseID);
            pWarehouseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWarehouseID);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByCategory(string category)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [Category]=@Category";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCategory = new SqlParameter("Category", category);
            pCategory.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCategory);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByLocationCode(string locationCode)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [LocationCode]=@LocationCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationCode = new SqlParameter("LocationCode", locationCode);
            pLocationCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pLocationCode);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByMaxWeight(decimal maxWeight)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [MaxWeight]=@MaxWeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxWeight = new SqlParameter("MaxWeight", maxWeight);
            pMaxWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxWeight);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByMaxPackage(int maxPackage)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [MaxPackage]=@MaxPackage";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaxPackage = new SqlParameter("MaxPackage", maxPackage);
            pMaxPackage.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMaxPackage);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByCabinetNum(string cabinetNum)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [CabinetNum]=@CabinetNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetNum = new SqlParameter("CabinetNum", cabinetNum);
            pCabinetNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pCabinetNum);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByLayerNum(string layerNum)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [LayerNum]=@LayerNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLayerNum = new SqlParameter("LayerNum", layerNum);
            pLayerNum.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pLayerNum);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByPackageQty(int packageQty)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [PackageQty]=@PackageQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageQty = new SqlParameter("PackageQty", packageQty);
            pPackageQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageQty);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByWeight(decimal weight)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByFlag(bool flag)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [Flag]=@Flag";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFlag = new SqlParameter("Flag", flag);
            pFlag.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pFlag);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByCreated(DateTime created)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByModified(DateTime modified)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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
        public List<Location> LoadLocationsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [LocationID]
				, [WarehouseID]
				, [Category]
				, [LocationCode]
				, [MaxWeight]
				, [MaxPackage]
				, [CabinetNum]
				, [LayerNum]
				, [IsDisabled]
				, [PackageQty]
				, [Weight]
				, [Flag]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Location] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Location> ret = new List<Location>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Location iret = new Location();
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["WarehouseID"]))
                        iret.WarehouseID = (Guid)dr["WarehouseID"];
                    iret.Category = dr["Category"].ToString();
                    iret.LocationCode = dr["LocationCode"].ToString();
                    if (!Convert.IsDBNull(dr["MaxWeight"]))
                        iret.MaxWeight = (decimal)dr["MaxWeight"];
                    if (!Convert.IsDBNull(dr["MaxPackage"]))
                        iret.MaxPackage = (int)dr["MaxPackage"];
                    iret.CabinetNum = dr["CabinetNum"].ToString();
                    iret.LayerNum = dr["LayerNum"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["PackageQty"]))
                        iret.PackageQty = (int)dr["PackageQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
                    if (!Convert.IsDBNull(dr["Flag"]))
                        iret.Flag = (bool)dr["Flag"];
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

        #region BE_Loction SearchObject()
        public SearchResult SearchLoction(SearchLocationArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[LocationID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [LocationID]
                                          ,[WarehouseID]
                                          ,[Category]
                                          ,[LocationCode]
                                          ,[MaxWeight]
                                          ,[MaxPackage]
                                          ,[CabinetNum]
                                          ,[LayerNum]
                                          ,[IsDisabled]
                                          ,[PackageQty]
                                          ,[Weight]
                                          ,[Flag]
                                          ,[Created]
                                          ,[CreatedBy]
                                          ,[Modified]
                                          ,[ModifiedBy]
                                      FROM [BE_Location] with(nolock)
	                                  WHERE 1=1");


            if (!string.IsNullOrEmpty(args.LocationCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "LocationCode", "mbLocationCode", args.LocationCode);
            }
            if (!string.IsNullOrEmpty(args.CabinetNum))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "CabinetNum", "mbCabinetNum", args.CabinetNum);
            }
            if (!string.IsNullOrEmpty(args.Category))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "Category", "mbCategory", args.Category);
            }
            if (!string.IsNullOrEmpty(args.LayerNum))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "LayerNum", "mbLayerNum", args.LayerNum);
            }
            if (args.WarehouseID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "WarehouseID", "mbWarehouseID", args.WarehouseID.Value);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsDisabled", "mbIsDisabled", args.IsDisabled);
            }
            if (args.Flag.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "Flag", "mbFlag", args.Flag);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
