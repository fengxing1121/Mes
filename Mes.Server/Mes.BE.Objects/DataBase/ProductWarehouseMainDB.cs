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
       
        #region BE_ProductWarehouseMain InsertObject()
        public int InsertProductWarehouseMain(ProductWarehouseMain obj)
        {
            string sql = @"INSERT INTO[BE_ProductWarehouseMain]([InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@InID
				, @BillNo
				, @OrderID
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            SqlParameter pBillNo = new SqlParameter("BillNo", Convert2DBnull(obj.BillNo));
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

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

        #region BE_ProductWarehouseMain UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateProductWarehouseMainByInID(ProductWarehouseMain obj)
        {
            string sql = @"UPDATE [BE_ProductWarehouseMain] SET [BillNo]=@BillNo
				, [OrderID]=@OrderID
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", Convert2DBnull(obj.BillNo));
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

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

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainByInID(Guid inID)
        {
            string sql = @"DELETE [BE_ProductWarehouseMain] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadProductWarehouseMainByInID(ProductWarehouseMain obj)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", Convert2DBnull(obj.InID));
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["InID"]))
                        obj.InID = (Guid)dr["InID"];
                    obj.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
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

        #region BE_ProductWarehouseMain CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountProductWarehouseMains()
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByInID(Guid inID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByBillNo(string billNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountProductWarehouseMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsProductWarehouseMains()
        {
            string sql = "SELECT TOP 1 * FROM [BE_ProductWarehouseMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByInID(Guid inID)
        {
            string sql = "SELECT TOP 1 [InID] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByBillNo(string billNo)
        {
            string sql = "SELECT TOP 1 [BillNo] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsProductWarehouseMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_ProductWarehouseMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteProductWarehouseMains()
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByInID(Guid inID)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByBillNo(string billNo)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductWarehouseMainsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_ProductWarehouseMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<ProductWarehouseMain> LoadProductWarehouseMains()
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByInID(Guid inID)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [InID]=@InID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pInID = new SqlParameter("InID", inID);
            pInID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pInID);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByBillNo(string billNo)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [BillNo]=@BillNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBillNo = new SqlParameter("BillNo", billNo);
            pBillNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBillNo);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByOrderID(Guid orderID)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByCreated(DateTime created)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByModified(DateTime modified)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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
        public List<ProductWarehouseMain> LoadProductWarehouseMainsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [InID]
				, [BillNo]
				, [OrderID]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_ProductWarehouseMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<ProductWarehouseMain> ret = new List<ProductWarehouseMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductWarehouseMain iret = new ProductWarehouseMain();
                    if (!Convert.IsDBNull(dr["InID"]))
                        iret.InID = (Guid)dr["InID"];
                    iret.BillNo = dr["BillNo"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
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

        #region BE_ProductWarehouseMain SearchObject()
        public SearchResult SearchProductWarehouseMain(SearchProductWarehouseMainArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BillNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [InID]
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
                                      FROM 
	                                    [BE_ProductWarehouseMain] with(nolock)
	                                    LEFT JOIN [BE_Order] with(nolock) on [BE_ProductWarehouseMain].[OrderID] = [BE_Order].[OrderID]
									WHERE 1=1");

            if (args.InID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "InID", "mbInID", args.InID.Value);
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

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
