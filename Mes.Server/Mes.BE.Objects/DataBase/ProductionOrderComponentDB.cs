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
        #region BE_ProductionOrderComponent InsertObject()
        public int InsertProductionOrderComponent(ProductionOrderComponent obj)
        {
            string sql = @"Insert Into [BE_ProductionOrderComponent](
                              [ProductionID]
                             ,[ComponentID]
            )Values (
                              @ProductionID
                             ,@ComponentID
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionOrderComponent UpdateObject()、DeleteObject()
        public int UpdateProductionOrderComponentByProductionID(ProductionOrderComponent obj)
        {
            string sql = @"Update [BE_ProductionOrderComponent] Set
                              [ComponentID]=@ComponentID
                          Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductionOrderComponentByProductionID(Guid ProductionID)
        {
            string sql = @"Delete [BE_ProductionOrderComponent]  Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionOrderComponent LoadObject()
        public List<ProductionOrderComponent> LoadProductionOrderComponents()
        {
            string sql = @"Select 
                              [ProductionID]
                             ,[ComponentID]
                       From [BE_ProductionOrderComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductionOrderComponent> ret = new List<ProductionOrderComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionOrderComponent iret = new ProductionOrderComponent();
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ProductionOrderComponent> LoadProductionOrderComponentByProductionID(ProductionOrderComponent obj)
        {
            string sql = @"Select 
                              [ProductionID]
                             ,[ComponentID]
                       From [BE_ProductionOrderComponent] With(NoLock) Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            List<ProductionOrderComponent> ret = new List<ProductionOrderComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionOrderComponent iret = new ProductionOrderComponent();
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        iret.ComponentID = (int)dr["ComponentID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadProductionOrderComponent(ProductionOrderComponent obj)
        {
            string sql = @"Select 
                              [ProductionID]
                             ,[ComponentID]
                       From [BE_ProductionOrderComponent] With(NoLock) Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        obj.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["ComponentID"]))
                        obj.ComponentID = (int)dr["ComponentID"];
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

        #region BE_ProductionOrderComponent CountObjects()、ExistsObjects()
        public int CountProductionOrderComponent()
        {
            string sql = @"Select Count(*) From [BE_ProductionOrderComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductionOrderComponentProductionID(Guid ProductionID)
        {
            string sql = @"Select Count(*) From [BE_ProductionOrderComponent]  Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductionOrderComponent()
        {
            string sql = @"Select Top 1 * From [BE_ProductionOrderComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductionOrderComponentProductionID(Guid ProductionID)
        {
            string sql = @"Select Top 1 * From [BE_ProductionOrderComponent]  Where ProductionID=@ProductionID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

