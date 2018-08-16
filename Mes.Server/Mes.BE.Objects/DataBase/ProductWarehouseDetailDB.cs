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

        #region BE_ProductWarehouseDetail InsertObject()
        public int InsertProductWarehouseDetail(ProductWarehouseDetail obj)
        {
            string sql = @"INSERT INTO[BE_ProductWarehouseDetail]([DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				) VALUES(@DetailID
				, @InID
				, @PackageID
				, @LocationID
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            SqlParameter pPackageID = new SqlParameter("PackageID", Convert2DBnull(obj.PackageID));
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductWarehouseDetail UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateProductWarehouseDetailByDetailID(ProductWarehouseDetail obj)
        {
            string sql = @"UPDATE [BE_ProductWarehouseDetail] SET [InID]=@InID
				, [PackageID]=@PackageID
				, [LocationID]=@LocationID
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            SqlParameter pPackageID = new SqlParameter("PackageID", Convert2DBnull(obj.PackageID));
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            SqlParameter pLocationID = new SqlParameter("LocationID", Convert2DBnull(obj.LocationID));
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_ProductWarehouseDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadProductWarehouseDetailByDetailID(ProductWarehouseDetail obj)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
 				FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
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
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        obj.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        obj.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_ProductWarehouseDetail CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountProductWarehouseDetails()
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseDetailsByInID(Guid inID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseDetailsByPackageID(Guid packageID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseDetailsByLocationID(Guid locationID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseDetailsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsProductWarehouseDetails()
        {
            string sql = "SELECT TOP 1 * FROM [BE_ProductWarehouseDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseDetailsByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseDetailsByInID(Guid inID)
        {
            string sql = "SELECT TOP 1 [InID] FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseDetailsByPackageID(Guid packageID)
        {
            string sql = "SELECT TOP 1 [PackageID] FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseDetailsByLocationID(Guid locationID)
        {
            string sql = "SELECT TOP 1 [LocationID] FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseDetailsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseDetailsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_ProductWarehouseDetail] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteProductWarehouseDetails()
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailsByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailsByInID(Guid inID)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailsByPackageID(Guid packageID)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail] WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailsByLocationID(Guid locationID)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseDetailsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetails()
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetailsByDetailID(Guid detailID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetailsByInID(Guid inID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetailsByPackageID(Guid packageID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail] WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetailsByLocationID(Guid locationID)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail] WHERE [LocationID]=@LocationID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLocationID = new SqlParameter("LocationID", locationID);
            pLocationID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pLocationID);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetailsByCreated(DateTime created)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<ProductWarehouseDetail> LoadProductWarehouseDetailsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [DetailID]
				, [InID]
				, [PackageID]
				, [LocationID]
				, [Created]
				, [CreatedBy]
				 FROM [BE_ProductWarehouseDetail] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<ProductWarehouseDetail> ret = new List<ProductWarehouseDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseDetail iret = new ProductWarehouseDetail();
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    if (!Convert.IsDBNull(dr["LocationID"]))
                        iret.LocationID = (Guid)dr["LocationID"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_ProductWarehouseDetail SearchObject()
        public SearchResult SearchProductWarehouseDetail(SearchProductWarehouseDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BillNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_ProductWarehouseMain].[InID]                                         
                                          ,[BillNo]
                                          ,[BE_ProductWarehouseMain].[OrderID]
	                                      ,[BE_Order].[OrderNo]
	                                      ,[BE_Order].[CustomerName]
	                                      ,[BE_Order].[Address]
	                                      ,[BE_Order].[LinkMan]
	                                      ,[BE_Order].[Mobile]
                                          ,[BE_ProductWarehouseMain].[Created]
                                          ,[BE_ProductWarehouseMain].[CreatedBy]
                                          ,[BE_ProductWarehouseMain].[Modified]
                                          ,[BE_ProductWarehouseMain].[ModifiedBy]
	                                      ,[BE_ProductWarehouseDetail].[DetailID]
	                                      ,[BE_ProductWarehouseDetail].[LocationID]
	                                      ,[BE_ProductWarehouseDetail].[PackageID]
	                                      ,[BE_Package].[PackageBarcode]
	                                      ,[BE_Package].[Weight]
	                                      ,[BE_Package].[ItemsQty]
	                                      ,[BE_Package].[PackageNum]
	                                      ,[BE_Package].[CabinetID]
	                                      ,[BE_Order2Cabinet].[CabinetName]
	                                      ,[BE_Order2Cabinet].[Size]
	                                      ,[BE_Order2Cabinet].[Color]
	                                      ,[BE_Order2Cabinet].[MaterialCategory]
	                                      ,[BE_Order2Cabinet].[MaterialStyle]
	                                      ,[BE_Location].[LocationCode]
	                                      ,[BE_Location].[LayerNum]	 
                                      FROM 
	                                    [BE_ProductWarehouseMain] with(nolock)
	                                    LEFT JOIN [BE_ProductWarehouseDetail] with(nolock) on [BE_ProductWarehouseMain].[InID] = [BE_ProductWarehouseDetail].[InID]
	                                    LEFT JOIN [BE_Order] with(nolock) on [BE_ProductWarehouseMain].[OrderID] = [BE_Order].[OrderID]
	                                    LEFT JOIN [BE_Package]  with(nolock) on [BE_Package].[PackageID] = [BE_ProductWarehouseDetail].[PackageID]
	                                    LEFT JOIN [BE_Location] with(nolock) on [BE_Location].[LocationID] = [BE_ProductWarehouseDetail].[LocationID]
	                                    LEFT JOIN [BE_Order2Cabinet]  with(nolock) on  [BE_Order2Cabinet].[CabinetID] = [BE_Package].[CabinetID]
									WHERE 1=1");


            if (args.InID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductWarehouseMain].[InID", "mbInID", args.InID.Value);
            }
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductWarehouseMain].[OrderID", "mbOrderID", args.OrderID.Value);
            }
            if (!string.IsNullOrEmpty(args.BillNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BillNo", "mbBillNo", args.BillNo);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Address", "mbCustomerAddress", args.Address);
            }

            if (!string.IsNullOrEmpty(args.LinkMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[LinkMan", "mbLinkMan", args.LinkMan);
            }

            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (args.PackageID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[PackageID", "mbPackageID", args.PackageID.Value);
            }
            if (!string.IsNullOrEmpty(args.PackageNum))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageNum", "mbPackageNum", args.PackageNum);
            }
            if (!string.IsNullOrEmpty(args.PackageBarcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PackageBarcode", "mbPackageBarcode", args.PackageBarcode);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
