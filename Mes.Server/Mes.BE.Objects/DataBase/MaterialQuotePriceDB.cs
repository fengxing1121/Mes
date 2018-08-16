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

        #region BE_MaterialQuotePrice InsertObject()
        public int InsertMaterialQuotePrice(MaterialQuotePrice obj)
        {
            string sql = @"INSERT INTO[BE_MaterialQuotePrice]([MaterialID]
				, [Price]
				) VALUES(@MaterialID
				, @Price
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_MaterialQuotePrice UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateMaterialQuotePriceByMaterialID(MaterialQuotePrice obj)
        {
            string sql = @"UPDATE [BE_MaterialQuotePrice] SET [Price]=@Price
 				WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialQuotePriceByMaterialID(Guid materialID)
        {
            string sql = @"DELETE [BE_MaterialQuotePrice] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadMaterialQuotePriceByMaterialID(MaterialQuotePrice obj)
        {
            string sql = @"SELECT [MaterialID]
				, [Price]
 				FROM [BE_MaterialQuotePrice] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
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

        #region BE_MaterialQuotePrice CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountMaterialQuotePrices()
        {
            string sql = "SELECT COUNT(*) FROM [BE_MaterialQuotePrice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialQuotePricesByMaterialID(Guid materialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_MaterialQuotePrice] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountMaterialQuotePricesByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_MaterialQuotePrice] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsMaterialQuotePrices()
        {
            string sql = "SELECT TOP 1 * FROM [BE_MaterialQuotePrice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialQuotePricesByMaterialID(Guid materialID)
        {
            string sql = "SELECT TOP 1 [MaterialID] FROM [BE_MaterialQuotePrice] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsMaterialQuotePricesByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_MaterialQuotePrice] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteMaterialQuotePrices()
        {
            string sql = "DELETE FROM [BE_MaterialQuotePrice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialQuotePricesByMaterialID(Guid materialID)
        {
            string sql = "DELETE FROM [BE_MaterialQuotePrice] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteMaterialQuotePricesByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_MaterialQuotePrice] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public List<MaterialQuotePrice> LoadMaterialQuotePrices()
        {
            string sql = @"SELECT [MaterialID]
				, [Price]
				 FROM [BE_MaterialQuotePrice]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<MaterialQuotePrice> ret = new List<MaterialQuotePrice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    MaterialQuotePrice iret = new MaterialQuotePrice();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
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
        public List<MaterialQuotePrice> LoadMaterialQuotePricesByMaterialID(Guid materialID)
        {
            string sql = @"SELECT [MaterialID]
				, [Price]
				 FROM [BE_MaterialQuotePrice] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            List<MaterialQuotePrice> ret = new List<MaterialQuotePrice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    MaterialQuotePrice iret = new MaterialQuotePrice();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
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
        public List<MaterialQuotePrice> LoadMaterialQuotePricesByPrice(decimal price)
        {
            string sql = @"SELECT [MaterialID]
				, [Price]
				 FROM [BE_MaterialQuotePrice] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<MaterialQuotePrice> ret = new List<MaterialQuotePrice>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    MaterialQuotePrice iret = new MaterialQuotePrice();
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
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

        #region BE_MaterialQuotePrice SearchObject()
        public SearchResult SearchMaterialQuotePrice(SearchMaterialQuotePriceArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[MaterialID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT 
	                                       [BE_Material].[MaterialID]                                                                        
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
	                                      ,[BE_MaterialQuotePrice].[Price]
                                      FROM 
                                          [BE_Material] with(nolock) 
                                           LEFT JOIN [BE_MaterialQuotePrice] with(nolock) on [BE_MaterialQuotePrice].[MaterialID] = [BE_Material].[MaterialID]                              
	                                  WHERE 1=1");
            this.SetParameters_In(mbBuilder, cmd, "BE_Material].[MaterialID", "mbMaterialID", args.MaterialIDs);
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
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
