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

        #region BE_Material2Supplier InsertObject()
        public int InsertMaterial2Supplier(Material2Supplier obj)
        {
            string sql = @"INSERT INTO[BE_Material2Supplier]([MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				) VALUES(@MaterialID
				, @SupplierID
				, @Price
				, @MinPurchaseQty
				, @MinDelivery
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pMinPurchaseQty = new SqlParameter("MinPurchaseQty", Convert2DBnull(obj.MinPurchaseQty));
            pMinPurchaseQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinPurchaseQty);

            SqlParameter pMinDelivery = new SqlParameter("MinDelivery", Convert2DBnull(obj.MinDelivery));
            pMinDelivery.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinDelivery);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Material2Supplier UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateMaterial2SupplierByMaterialID_SupplierID(Material2Supplier obj)
        {
            string sql = @"UPDATE [BE_Material2Supplier] SET [Price]=@Price
				, [MinPurchaseQty]=@MinPurchaseQty
				, [MinDelivery]=@MinDelivery
 				WHERE [MaterialID]=@MaterialID AND [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pMinPurchaseQty = new SqlParameter("MinPurchaseQty", Convert2DBnull(obj.MinPurchaseQty));
            pMinPurchaseQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinPurchaseQty);

            SqlParameter pMinDelivery = new SqlParameter("MinDelivery", Convert2DBnull(obj.MinDelivery));
            pMinDelivery.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinDelivery);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterial2SupplierByMaterialID_SupplierID(Guid materialID, Guid supplierID)
        {
            string sql = @"DELETE [BE_Material2Supplier] WHERE [MaterialID]=@MaterialID AND [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadMaterial2SupplierByMaterialID_SupplierID(Material2Supplier obj)
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
 				FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID AND [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", Convert2DBnull(obj.SupplierID));
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        obj.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        obj.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        obj.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        obj.MinDelivery = (int)dr["MinDelivery"];
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

        #region BE_Material2Supplier CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountMaterial2Suppliers()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material2Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterial2SuppliersByMaterialID(Guid materialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterial2SuppliersBySupplierID(Guid supplierID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterial2SuppliersByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterial2SuppliersByMinPurchaseQty(int minPurchaseQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MinPurchaseQty]=@MinPurchaseQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinPurchaseQty = new SqlParameter("MinPurchaseQty", minPurchaseQty);
            pMinPurchaseQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinPurchaseQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterial2SuppliersByMinDelivery(int minDelivery)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MinDelivery]=@MinDelivery";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinDelivery = new SqlParameter("MinDelivery", minDelivery);
            pMinDelivery.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinDelivery);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsMaterial2Suppliers()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Material2Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterial2SuppliersByMaterialID(Guid materialID)
        {
            string sql = "SELECT TOP 1 [MaterialID] FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterial2SuppliersBySupplierID(Guid supplierID)
        {
            string sql = "SELECT TOP 1 [SupplierID] FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterial2SuppliersByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterial2SuppliersByMinPurchaseQty(int minPurchaseQty)
        {
            string sql = "SELECT TOP 1 [MinPurchaseQty] FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MinPurchaseQty]=@MinPurchaseQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinPurchaseQty = new SqlParameter("MinPurchaseQty", minPurchaseQty);
            pMinPurchaseQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinPurchaseQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterial2SuppliersByMinDelivery(int minDelivery)
        {
            string sql = "SELECT TOP 1 [MinDelivery] FROM [BE_Material2Supplier] WITH(NOLOCK) WHERE [MinDelivery]=@MinDelivery";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinDelivery = new SqlParameter("MinDelivery", minDelivery);
            pMinDelivery.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinDelivery);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteMaterial2Suppliers()
        {
            string sql = "DELETE FROM [BE_Material2Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterial2SuppliersByMaterialID(Guid materialID)
        {
            string sql = "DELETE FROM [BE_Material2Supplier] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterial2SuppliersBySupplierID(Guid supplierID)
        {
            string sql = "DELETE FROM [BE_Material2Supplier] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterial2SuppliersByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_Material2Supplier] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterial2SuppliersByMinPurchaseQty(int minPurchaseQty)
        {
            string sql = "DELETE FROM [BE_Material2Supplier] WHERE [MinPurchaseQty]=@MinPurchaseQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinPurchaseQty = new SqlParameter("MinPurchaseQty", minPurchaseQty);
            pMinPurchaseQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinPurchaseQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterial2SuppliersByMinDelivery(int minDelivery)
        {
            string sql = "DELETE FROM [BE_Material2Supplier] WHERE [MinDelivery]=@MinDelivery";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinDelivery = new SqlParameter("MinDelivery", minDelivery);
            pMinDelivery.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinDelivery);

            return cmd.ExecuteNonQuery();
        }
        public List<Material2Supplier> LoadMaterial2Suppliers()
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				 FROM [BE_Material2Supplier]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Material2Supplier> ret = new List<Material2Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material2Supplier iret = new Material2Supplier();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        iret.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        iret.MinDelivery = (int)dr["MinDelivery"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Material2Supplier> LoadMaterial2SuppliersByMaterialID(Guid materialID)
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				 FROM [BE_Material2Supplier] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            List<Material2Supplier> ret = new List<Material2Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material2Supplier iret = new Material2Supplier();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        iret.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        iret.MinDelivery = (int)dr["MinDelivery"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Material2Supplier> LoadMaterial2SuppliersBySupplierID(Guid supplierID)
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				 FROM [BE_Material2Supplier] WHERE [SupplierID]=@SupplierID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSupplierID = new SqlParameter("SupplierID", supplierID);
            pSupplierID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSupplierID);

            List<Material2Supplier> ret = new List<Material2Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material2Supplier iret = new Material2Supplier();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        iret.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        iret.MinDelivery = (int)dr["MinDelivery"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Material2Supplier> LoadMaterial2SuppliersByPrice(decimal price)
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				 FROM [BE_Material2Supplier] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<Material2Supplier> ret = new List<Material2Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material2Supplier iret = new Material2Supplier();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        iret.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        iret.MinDelivery = (int)dr["MinDelivery"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Material2Supplier> LoadMaterial2SuppliersByMinPurchaseQty(int minPurchaseQty)
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				 FROM [BE_Material2Supplier] WHERE [MinPurchaseQty]=@MinPurchaseQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinPurchaseQty = new SqlParameter("MinPurchaseQty", minPurchaseQty);
            pMinPurchaseQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinPurchaseQty);

            List<Material2Supplier> ret = new List<Material2Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material2Supplier iret = new Material2Supplier();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        iret.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        iret.MinDelivery = (int)dr["MinDelivery"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Material2Supplier> LoadMaterial2SuppliersByMinDelivery(int minDelivery)
        {
            string sql = @"SELECT [MaterialID]
				, [SupplierID]
				, [Price]
				, [MinPurchaseQty]
				, [MinDelivery]
				 FROM [BE_Material2Supplier] WHERE [MinDelivery]=@MinDelivery";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMinDelivery = new SqlParameter("MinDelivery", minDelivery);
            pMinDelivery.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMinDelivery);

            List<Material2Supplier> ret = new List<Material2Supplier>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Material2Supplier iret = new Material2Supplier();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["SupplierID"]))
                        iret.SupplierID = (Guid)dr["SupplierID"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["MinPurchaseQty"]))
                        iret.MinPurchaseQty = (int)dr["MinPurchaseQty"];
                    if (!Convert.IsDBNull(dr["MinDelivery"]))
                        iret.MinDelivery = (int)dr["MinDelivery"];
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

        #region BE_Material2Supplier SearchObject()
        public SearchResult SeachMaterial2Supplier(SearchMaterial2SupplierArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[MaterialID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
	                                       [BE_Material2Supplier].[MaterialID]
                                          ,[BE_Material2Supplier].[SupplierID]
                                          ,[BE_Material2Supplier].[Price]
                                          ,[BE_Material2Supplier].[MinPurchaseQty]
                                          ,[BE_Material2Supplier].[MinDelivery]	                                     
                                          ,[BE_Material].[Category]
                                          ,[BE_Material].[SubCategory]
                                          ,[BE_Material].[MaterialCode]
                                          ,[BE_Material].[MaterialName]
                                          ,[BE_Material].[Style]
                                          ,[BE_Material].[Color]
                                          ,[BE_Material].[Deepth]
                                          ,[BE_Material].[QuotedPrice]
                                          ,[BE_Material].[Unit]
                                          ,[BE_Material].[ImageUrl]    
                                          ,[BE_Material].[Withholding_Qty]
                                          ,[BE_Material].[SafetyStock_Qty]
	                                      ,[BE_Supplier].[SupplierCode]
                                          ,[BE_Supplier].[SupplierName]
                                          ,[BE_Supplier].[Address]
                                          ,[BE_Supplier].[Province]
                                          ,[BE_Supplier].[City]
                                          ,[BE_Supplier].[LinkMan]
                                          ,[BE_Supplier].[Tel]
                                          ,[BE_Supplier].[Mobile]
                                          ,[BE_Supplier].[Email]
                                      FROM [BE_Material2Supplier] with(nolock)
                                      LEFT JOIN [BE_Material] with(nolock) on [BE_Material2Supplier].[MaterialID] = [BE_Material].[MaterialID]
                                      LEFT JOIN [BE_Supplier] with(nolock) on [BE_Supplier].[SupplierID] = [BE_Material2Supplier].[SupplierID]                               
	                                  WHERE 1=1");
            this.SetParameters_In(mbBuilder, cmd, "BE_Material2Supplier].[MaterialID", "mbMaterialID", args.MaterialIDs);
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

            if (args.SupplierID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Material2Supplier].[SupplierID", "mbSupplierID", args.SupplierID);
            }
            if (!string.IsNullOrEmpty(args.SupplierCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Supplier].[SupplierCode", "mbSupplierCode", args.SupplierCode);
            }
            if (!string.IsNullOrEmpty(args.SupplierName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Supplier].[SupplierName", "mbSupplierName", args.SupplierName);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
