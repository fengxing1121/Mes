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
       
        #region BE_WarehouseOutDetail InsertObject()
        public int InsertWarehouseOutDetail(WarehouseOutDetail obj)
        {
            string sql = @"INSERT INTO[BE_WarehouseOutDetail]([DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				) VALUES(@DetailID
				, @OutID
				, @MaterialID
				, @Qty
				, @LocationID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pOutID = new SqlParameter("OutID", Convert2DBnull(obj.OutID));
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WarehouseOutDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateWarehouseOutDetailByDetailID(WarehouseOutDetail obj)
        {
            string sql = @"UPDATE [BE_WarehouseOutDetail] SET [OutID]=@OutID
				, [MaterialID]=@MaterialID
				, [Qty]=@Qty
				, [LocationID]=@LocationID
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", Convert2DBnull(obj.OutID));
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", Convert2DBnull(obj.MaterialID));
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutDetailByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_WarehouseOutDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWarehouseOutDetailByDetailID(WarehouseOutDetail obj)
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
 				FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
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
                    if (!Convert.IsDBNull(dr["OutID"]))
                        obj.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        obj.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
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

        #region BE_WarehouseOutDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWarehouseOutDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutDetailsByOutID(Guid outID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutDetailsByMaterialID(Guid materialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutDetailsByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWarehouseOutDetailsByLocationID(Guid locationID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWarehouseOutDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WarehouseOutDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutDetailsByOutID(Guid outID)
        {
            string sql = "SELECT TOP 1 [OutID] FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutDetailsByMaterialID(Guid materialID)
        {
            string sql = "SELECT TOP 1 [MaterialID] FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutDetailsByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWarehouseOutDetailsByLocationID(Guid locationID)
        {
            string sql = "SELECT TOP 1 [LocationID] FROM [BE_WarehouseOutDetail] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWarehouseOutDetails()
        {
            string sql = "DELETE FROM [BE_WarehouseOutDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutDetailsByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_WarehouseOutDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutDetailsByOutID(Guid outID)
        {
            string sql = "DELETE FROM [BE_WarehouseOutDetail] WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutDetailsByMaterialID(Guid materialID)
        {
            string sql = "DELETE FROM [BE_WarehouseOutDetail] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutDetailsByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_WarehouseOutDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWarehouseOutDetailsByLocationID(Guid locationID)
        {
            string sql = "DELETE FROM [BE_WarehouseOutDetail] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public List<WarehouseOutDetail> LoadWarehouseOutDetails()
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				 FROM [BE_WarehouseOutDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WarehouseOutDetail> ret = new List<WarehouseOutDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutDetail iret = new WarehouseOutDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
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
        public List<WarehouseOutDetail> LoadWarehouseOutDetailsByDetailID(Guid detailID)
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				 FROM [BE_WarehouseOutDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<WarehouseOutDetail> ret = new List<WarehouseOutDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutDetail iret = new WarehouseOutDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
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
        public List<WarehouseOutDetail> LoadWarehouseOutDetailsByOutID(Guid outID)
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				 FROM [BE_WarehouseOutDetail] WHERE [OutID]=@OutID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOutID = new SqlParameter("OutID", outID);
            pOutID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOutID);

            List<WarehouseOutDetail> ret = new List<WarehouseOutDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutDetail iret = new WarehouseOutDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
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
        public List<WarehouseOutDetail> LoadWarehouseOutDetailsByMaterialID(Guid materialID)
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				 FROM [BE_WarehouseOutDetail] WHERE [MaterialID]=@MaterialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMaterialID = new SqlParameter("MaterialID", materialID);
            pMaterialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pMaterialID);

            List<WarehouseOutDetail> ret = new List<WarehouseOutDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutDetail iret = new WarehouseOutDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
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
        public List<WarehouseOutDetail> LoadWarehouseOutDetailsByQty(decimal qty)
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				 FROM [BE_WarehouseOutDetail] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<WarehouseOutDetail> ret = new List<WarehouseOutDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutDetail iret = new WarehouseOutDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
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
        public List<WarehouseOutDetail> LoadWarehouseOutDetailsByLocationID(Guid locationID)
        {
            string sql = @"SELECT [DetailID]
				, [OutID]
				, [MaterialID]
				, [Qty]
				, [LocationID]
				 FROM [BE_WarehouseOutDetail] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            List<WarehouseOutDetail> ret = new List<WarehouseOutDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WarehouseOutDetail iret = new WarehouseOutDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["OutID"]))
                        iret.OutID = (Guid)dr["OutID"];
                    if (!Convert.IsDBNull(dr["MaterialID"]))
                        iret.MaterialID = (Guid)dr["MaterialID"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
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

        #region BE_WarehouseOutDetail SearchObject()
        public SearchResult SearchWarehouseOutDetail(SearchWarehouseOutDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BillNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WarehouseOutMain].[OutID]
                                          ,[BE_WarehouseOutMain].[BillNo]
                                          ,[BE_WarehouseOutMain].[WorkShopID]
                                          ,[BE_WarehouseOutMain].[Remark]
                                          ,[BE_WarehouseOutMain].[CheckOutDate]
                                          ,[BE_WarehouseOutMain].[HandlerMan]
                                          ,[BE_WarehouseOutMain].[Created]
                                          ,[BE_WarehouseOutMain].[CreatedBy]
                                          ,[BE_WarehouseOutMain].[Modified]
                                          ,[BE_WarehouseOutMain].[ModifiedBy]
	                                      ,[BE_WorkShop].[WorkShopName]
										  ,[BE_WarehouseOutDetail].[DetailID]
										  ,[BE_WarehouseOutDetail].[MaterialID]
										  ,[BE_WarehouseOutDetail].[Qty]
										  ,[BE_WarehouseOutDetail].[LocationID]
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
										  ,[BE_Location].[Category] as Warehouse
                                      FROM 
	                                        [BE_WarehouseOutMain] with(nolock)
											LEFT JOIN [BE_WarehouseOutDetail] with(nolock) on [BE_WarehouseOutMain].[OutID] = [BE_WarehouseOutDetail].[OutID]
											LEFT JOIN [BE_Material] with(nolock) on [BE_Material].[MaterialID] = [BE_WarehouseOutDetail].[MaterialID]
											LEFT JOIN [BE_Location] with(nolock) on [BE_WarehouseOutDetail].[LocationID] = [BE_Location].[LocationID]
		                                    LEFT JOIN [BE_WorkShop] with(nolock) on [BE_WarehouseOutMain].[WorkShopID] = [BE_WorkShop].[WorkShopID]
	                                  WHERE 1=1");


            if (args.OutID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseOutMain].[OutID", "mbOutID", args.OutID.Value);
            }
            if (!string.IsNullOrEmpty(args.BillNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WarehouseOutMain].[BillNo", "mbBillNo", args.BillNo);
            }
            if (!string.IsNullOrEmpty(args.HandlerMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WarehouseOutMain].[HandlerMan", "mbHandlerMan", args.HandlerMan);
            }

            if (args.WorkShopID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WarehouseOutMain].[WorkShopID", "mbWorkShopID", args.WorkShopID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkShopName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "WorkShopName", "mbWorkShopName", args.WorkShopName);
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
            this.SetParameters_Between(mbBuilder, cmd, "CheckOutDate", "mbCheckOutDate", args.CheckOutDateFrom, args.CheckOutDateTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
