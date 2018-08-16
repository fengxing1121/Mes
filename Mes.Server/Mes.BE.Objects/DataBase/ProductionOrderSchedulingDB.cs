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
        #region BE_ProductionOrderScheduling InsertObject()
        public int InsertProductionOrderScheduling(ProductionOrderScheduling obj)
        {
            string sql = @"Insert Into [BE_ProductionOrderScheduling](
                              [SchedulingID]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[DaysDetailID]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                              @SchedulingID
                             ,@OrderID
                             ,@ProductionID
                             ,@DaysDetailID
                             ,@TotalAreal
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(obj.SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pDaysDetailID = new SqlParameter("DaysDetailID", Convert2DBnull(obj.DaysDetailID));
            pDaysDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDaysDetailID);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionOrderScheduling UpdateObject()、DeleteObject()
        public int UpdateProductionOrderSchedulingBySchedulingID(ProductionOrderScheduling obj)
        {
            string sql = @"Update [BE_ProductionOrderScheduling] Set
                              [OrderID]=@OrderID
                             ,[ProductionID]=@ProductionID
                             ,[DaysDetailID]=@DaysDetailID
                             ,[TotalAreal]=@TotalAreal
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where SchedulingID=@SchedulingID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(obj.SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pProductionID = new SqlParameter("ProductionID", Convert2DBnull(obj.ProductionID));
            pProductionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pProductionID);

            SqlParameter pDaysDetailID = new SqlParameter("DaysDetailID", Convert2DBnull(obj.DaysDetailID));
            pDaysDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDaysDetailID);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductionOrderSchedulingBySchedulingID(Guid SchedulingID)
        {
            string sql = @"Delete [BE_ProductionOrderScheduling]  Where SchedulingID=@SchedulingID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionOrderScheduling LoadObject()
        public List<ProductionOrderScheduling> LoadProductionOrderSchedulings()
        {
            string sql = @"Select 
                              [SchedulingID]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[DaysDetailID]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionOrderScheduling] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductionOrderScheduling> ret = new List<ProductionOrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionOrderScheduling iret = new ProductionOrderScheduling();
                    if (!Convert.IsDBNull(dr["SchedulingID"]))
                        iret.SchedulingID = (Guid)dr["SchedulingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["DaysDetailID"]))
                        iret.DaysDetailID = (Guid)dr["DaysDetailID"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ProductionOrderScheduling> LoadProductionOrderSchedulingBySchedulingID(ProductionOrderScheduling obj)
        {
            string sql = @"Select 
                              [SchedulingID]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[DaysDetailID]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionOrderScheduling] With(NoLock) Where SchedulingID=@SchedulingID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(obj.SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            List<ProductionOrderScheduling> ret = new List<ProductionOrderScheduling>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionOrderScheduling iret = new ProductionOrderScheduling();
                    if (!Convert.IsDBNull(dr["SchedulingID"]))
                        iret.SchedulingID = (Guid)dr["SchedulingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        iret.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["DaysDetailID"]))
                        iret.DaysDetailID = (Guid)dr["DaysDetailID"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadProductionOrderScheduling(ProductionOrderScheduling obj)
        {
            string sql = @"Select 
                              [SchedulingID]
                             ,[OrderID]
                             ,[ProductionID]
                             ,[DaysDetailID]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionOrderScheduling] With(NoLock) Where SchedulingID=@SchedulingID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(obj.SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SchedulingID"]))
                        obj.SchedulingID = (Guid)dr["SchedulingID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["ProductionID"]))
                        obj.ProductionID = (Guid)dr["ProductionID"];
                    if (!Convert.IsDBNull(dr["DaysDetailID"]))
                        obj.DaysDetailID = (Guid)dr["DaysDetailID"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
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

        #region BE_ProductionOrderScheduling CountObjects()、ExistsObjects()
        public int CountProductionOrderScheduling()
        {
            string sql = @"Select Count(*) From [BE_ProductionOrderScheduling] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductionOrderSchedulingBySchedulingID(Guid SchedulingID)
        {
            string sql = @"Select Count(*) From [BE_ProductionOrderScheduling]  Where SchedulingID=@SchedulingID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductionOrderScheduling()
        {
            string sql = @"Select Top 1 * From [BE_ProductionOrderScheduling] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductionOrderSchedulingBySchedulingID(Guid SchedulingID)
        {
            string sql = @"Select Top 1 * From [BE_ProductionOrderScheduling]  Where SchedulingID=@SchedulingID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSchedulingID = new SqlParameter("SchedulingID", Convert2DBnull(SchedulingID));
            pSchedulingID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSchedulingID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

