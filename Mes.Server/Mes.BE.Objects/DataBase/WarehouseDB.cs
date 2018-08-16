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

        #region BE_Warehouse InsertObject()
        public int InsertWarehouse(Warehouse obj)
        {
            string sql = @"INSERT INTO[BE_Warehouse]([MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
				) VALUES(@MaterialID
				, @LocationID
				, @Qty
				, @Price
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Warehouse UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWarehouseByMaterialID_LocationID(Warehouse obj)
        {
            string sql = @"UPDATE [BE_Warehouse] SET [Qty]=@Qty
				, [Price]=@Price
 				WHERE [MaterialID]=@MaterialID AND [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseByMaterialID_LocationID(Guid materialID, Guid locationID)
        {
            string sql = @"DELETE [BE_Warehouse] WHERE [MaterialID]=@MaterialID AND [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWarehouseByMaterialID_LocationID(Warehouse obj)
        {
            string sql = @"SELECT [MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
 				FROM [BE_Warehouse] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID AND [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        obj.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        obj.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
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

        #region BE_Warehouse CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWarehouses()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Warehouse]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehousesByMaterialID(Guid materialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Warehouse] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehousesByLocationID(Guid locationID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Warehouse] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehousesByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Warehouse] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehousesByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Warehouse] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWarehouses()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Warehouse]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehousesByMaterialID(Guid materialID)
        {
            string sql = "SELECT TOP 1 [MaterialID] FROM [BE_Warehouse] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehousesByLocationID(Guid locationID)
        {
            string sql = "SELECT TOP 1 [LocationID] FROM [BE_Warehouse] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehousesByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Warehouse] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehousesByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_Warehouse] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWarehouses()
        {
            string sql = "DELETE FROM [BE_Warehouse]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehousesByMaterialID(Guid materialID)
        {
            string sql = "DELETE FROM [BE_Warehouse] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehousesByLocationID(Guid locationID)
        {
            string sql = "DELETE FROM [BE_Warehouse] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehousesByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_Warehouse] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehousesByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_Warehouse] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public List<Warehouse> LoadWarehouses()
        {
            string sql = @"SELECT [MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
				 FROM [BE_Warehouse]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Warehouse> ret = new List<Warehouse>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Warehouse iret = new Warehouse();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Warehouse> LoadWarehousesByMaterialID(Guid materialID)
        {
            string sql = @"SELECT [MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
				 FROM [BE_Warehouse] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            List<Warehouse> ret = new List<Warehouse>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Warehouse iret = new Warehouse();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Warehouse> LoadWarehousesByLocationID(Guid locationID)
        {
            string sql = @"SELECT [MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
				 FROM [BE_Warehouse] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            List<Warehouse> ret = new List<Warehouse>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Warehouse iret = new Warehouse();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Warehouse> LoadWarehousesByQty(decimal qty)
        {
            string sql = @"SELECT [MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
				 FROM [BE_Warehouse] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<Warehouse> ret = new List<Warehouse>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Warehouse iret = new Warehouse();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Warehouse> LoadWarehousesByPrice(decimal price)
        {
            string sql = @"SELECT [MaterialID]
				, [LocationID]
				, [Qty]
				, [Price]
				 FROM [BE_Warehouse] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<Warehouse> ret = new List<Warehouse>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Warehouse iret = new Warehouse();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
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

        #region BE_Warehouse SearchObject()
        public SearchResult SearchWarehouse(SearchWarehouseArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BE_Warehouse].[WarehouseID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Location].[WarehouseID]
										  ,[BE_Category].[CategoryName] as WarehouseName
                                          ,[BE_Warehouse].[MaterialID]
                                          ,[BE_Warehouse].[LocationID]
                                          ,[BE_Warehouse].[Qty]     
                                          ,[BE_Location].[LocationCode]
                                          ,[BE_Location].[MaxWeight]
                                          ,[BE_Location].[MaxPackage]
                                          ,[BE_Location].[CabinetNum]
                                          ,[BE_Location].[LayerNum]
                                          ,[BE_Location].[IsDisabled]
                                          ,[BE_Material].[Category]
                                          ,[BE_Material].[SubCategory]
                                          ,[BE_Material].[MaterialCode]
                                          ,[BE_Material].[MaterialName]
                                          ,[BE_Material].[Style]
                                          ,[BE_Material].[Color]
                                          ,[BE_Material].[Deepth]
                                          ,[BE_Material].[Unit]
                                          ,[BE_Material].[ImageUrl]
                                          ,[BE_Material].[Remark]
                                          ,[BE_Material].[Withholding_Qty]
                                          ,[BE_Material].[SafetyStock_Qty]      
                                      FROM [BE_Warehouse] with(nolock)
                                      LEFT JOIN [BE_Location] with(nolock) on [BE_Warehouse].[LocationID] = [BE_Location].[LocationID]
                                      LEFT JOIN [BE_Material] with(nolock) on [BE_Warehouse].[MaterialID] = [BE_Material].[MaterialID]
									  LEFT JOIN [BE_Category] with(nolock) on [BE_Location].[WarehouseID] = [BE_Category].[CategoryID]
	                                  WHERE 1=1");


            this.SetParameters_In(mbBuilder, cmd, "BE_Material].[Category", "mbCategory", args.Categorys);
            this.SetParameters_In(mbBuilder, cmd, "BE_Material].[SubCategory", "mbSubCategory", args.SubCategorys);

            if (!string.IsNullOrEmpty(args.MaterialCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[MaterialCode", "mbMaterialCode", args.MaterialCode);
            }

            if (!string.IsNullOrEmpty(args.MaterialName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[MaterialName", "mbMaterialName", args.MaterialName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.Style))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[Style", "mbStyle", args.Style);
            }
            if (args.Deepth.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Material].[Deepth", "mbDeepth", args.Deepth.Value);
            }

            if (!string.IsNullOrEmpty(args.LocationCode))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Location].[LocationCode", "mbLocationCode", args.LocationCode);
            }
            if (!string.IsNullOrEmpty(args.CabinetNum))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Location].[CabinetNum", "mbCabinetNum", args.CabinetNum);
            }
            if (!string.IsNullOrEmpty(args.LayerNum))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Location].[LayerNum", "mbLayerNum", args.LayerNum);
            }
            if (args.WarehouseID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Warehouse].[WarehouseID", "mbWarehouseID", args.WarehouseID.Value);
            }
            if (args.LocationID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Location].[LocationID", "mbLocationID", args.LocationID.Value);
            }
            if (args.MaterialID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Warehouse].[MaterialID", "mbMaterialID", args.MaterialID.Value);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Location].[IsDisabled", "mbIsDisabled", args.IsDisabled);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
