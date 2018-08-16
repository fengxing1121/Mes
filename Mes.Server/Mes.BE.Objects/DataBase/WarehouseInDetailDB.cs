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
       
        #region BE_WarehouseInDetail InsertObject()
        public int InsertWarehouseInDetail(WarehouseInDetail obj)
        {
            string sql = @"INSERT INTO[BE_WarehouseInDetail]([DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				) VALUES(@DetailID
				, @InID
				, @MaterialID
				, @Qty
				, @Price
				, @LocationID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WarehouseInDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWarehouseInDetailByDetailID(WarehouseInDetail obj)
        {
            string sql = @"UPDATE [BE_WarehouseInDetail] SET [InID]=@InID
				, [MaterialID]=@MaterialID
				, [Qty]=@Qty
				, [Price]=@Price
				, [LocationID]=@LocationID
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_WarehouseInDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWarehouseInDetailByDetailID(WarehouseInDetail obj)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
 				FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
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
                    if (!Convert.IsDBNull(dr["InID"]))
                        obj.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        obj.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        obj.LocationID = (Guid)dr["LocationID"];
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

        #region BE_WarehouseInDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWarehouseInDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInDetailsByInID(Guid inID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInDetailsByMaterialID(Guid materialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInDetailsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInDetailsByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseInDetailsByLocationID(Guid locationID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWarehouseInDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WarehouseInDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInDetailsByInID(Guid inID)
        {
            string sql = "SELECT TOP 1 [InID] FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInDetailsByMaterialID(Guid materialID)
        {
            string sql = "SELECT TOP 1 [MaterialID] FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInDetailsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInDetailsByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseInDetailsByLocationID(Guid locationID)
        {
            string sql = "SELECT TOP 1 [LocationID] FROM [BE_WarehouseInDetail] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWarehouseInDetails()
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailsByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailsByInID(Guid inID)
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailsByMaterialID(Guid materialID)
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailsByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseInDetailsByLocationID(Guid locationID)
        {
            string sql = "DELETE FROM [BE_WarehouseInDetail] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public List<WarehouseInDetail> LoadWarehouseInDetails()
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WarehouseInDetail> LoadWarehouseInDetailsByDetailID(Guid detailID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WarehouseInDetail> LoadWarehouseInDetailsByInID(Guid inID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WarehouseInDetail> LoadWarehouseInDetailsByMaterialID(Guid materialID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WarehouseInDetail> LoadWarehouseInDetailsByQty(decimal qty)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WarehouseInDetail> LoadWarehouseInDetailsByPrice(decimal price)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WarehouseInDetail> LoadWarehouseInDetailsByLocationID(Guid locationID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [MaterialID]
				, [Qty]
				, [Price]
				, [LocationID]
				 FROM [BE_WarehouseInDetail] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            List<WarehouseInDetail> ret = new List<WarehouseInDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseInDetail iret = new WarehouseInDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
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

        #region BE_WarehouseInDetail SearchObject()
        public SearchResult SearchWarehouseInDetail(SearchWarehouseInDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BillNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WarehouseInMain].[InID]
                                          ,[BE_WarehouseInMain].[BillNo]
                                          ,[BE_WarehouseInMain].[BattchNo]
                                          ,[BE_WarehouseInMain].[SupplierID]
                                          ,[BE_WarehouseInMain].[Remark]
                                          ,[BE_WarehouseInMain].[CheckInDate]
                                          ,[BE_WarehouseInMain].[HandlerMan]
                                          ,[BE_WarehouseInMain].[Created]
                                          ,[BE_WarehouseInMain].[CreatedBy]
                                          ,[BE_WarehouseInMain].[Modified]
                                          ,[BE_WarehouseInMain].[ModifiedBy]
	                                      ,[BE_Supplier].[SupplierCode]
	                                      ,[BE_Supplier].[SupplierName]
										  ,[BE_WarehouseInDetail].[DetailID]
										  ,[BE_WarehouseInDetail].[MaterialID]
										  ,[BE_WarehouseInDetail].[Qty]
										  ,[BE_WarehouseInDetail].[Price]
										  ,[BE_WarehouseInDetail].[LocationID]
										  ,[BE_Material].[MaterialCode]
										  ,[BE_Material].[MaterialName]
										  ,[BE_Material].[Category]
										  ,[BE_Material].[SubCategory]
										  ,[BE_Material].[Deepth]
										  ,[BE_Material].[Color]										  
										  ,[BE_Material].[Style]
										  ,[BE_Material].[Unit]
										  ,[BE_Location].[LocationCode]
										  ,[BE_Location].[CabinetNum]
										  ,[BE_Location].[LayerNum]
										  ,[BE_Location].[MaxPackage]
										  ,[BE_Location].[MaxWeight]
										  ,[BE_Location].[Category] as WarehouseName
                                      FROM 
		                                    [BE_WarehouseInMain] with(nolock)
											LEFT JOIN [BE_WarehouseInDetail] with(nolock) on [BE_WarehouseInMain].[InID] = [BE_WarehouseInDetail].[InID]
											LEFT JOIN [BE_Material] with(nolock) on [BE_WarehouseInDetail].[MaterialID] = [BE_Material].[MaterialID]
											LEFT JOIN [BE_Location] with(nolock) on [BE_WarehouseInDetail].[LocationID] = [BE_Location].[LocationID]
		                                    LEFT JOIN [BE_Supplier] with(nolock) on [BE_WarehouseInMain].[SupplierID] = [BE_Supplier].[SupplierID]
	                                  WHERE 1=1");


            if (!string.IsNullOrEmpty(args.SupplierCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Supplier].[SupplierCode", "mbSupplierCode", args.SupplierCode);
            }
            if (!string.IsNullOrEmpty(args.SupplierName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Supplier].[SupplierName", "mbSupplierName", args.SupplierName);
            }
            if (args.InID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseInMain].[InID", "mbInID", args.InID.Value);
            }
            if (args.SupplierID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseInMain].[SupplierID", "mbSupplierID", args.SupplierID.Value);
            }
            if (!string.IsNullOrEmpty(args.BillNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BillNo", "mbBillNo", args.BillNo);
            }
            if (!string.IsNullOrEmpty(args.HandlerMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "HandlerMan", "mbHandlerMan", args.HandlerMan);
            }
            if (args.MaterialID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseInDetail].[MaterialID", "mbMaterialID", args.MaterialID.Value);
            }
            if (!string.IsNullOrEmpty(args.MaterialCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialCode", "mbMaterialCode", args.MaterialCode);
            }
            if (!string.IsNullOrEmpty(args.MaterialName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialName", "mbMaterialName", args.MaterialName);
            }
            if (!string.IsNullOrEmpty(args.Category))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[Category", "mbCategory", args.Category);
            }
            if (!string.IsNullOrEmpty(args.SubCategory))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[SubCategory", "mbSubCategory", args.SubCategory);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.Style))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Material].[Style", "mbStyle", args.Style);
            }
            this.SetParameters_Between(mbBuilder, cmd, "CheckInDate", "mbCheckInDate", args.CheckInDateFrom, args.CheckInDateTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
