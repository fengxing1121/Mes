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
        #region BE_ProductionSetWeekDetail InsertObject()
        public int InsertProductionSetWeekDetail(ProductionSetWeekDetail obj)
        {
            string sql = @"Insert Into [BE_ProductionSetWeekDetail](
                              [ID]
                             ,[SetID]
                             ,[WeekNo]
                             ,[MaxCapacity]
                             ,[TotalAreal]
            )Values (
                              @ID
                             ,@SetID
                             ,@WeekNo
                             ,@MaxCapacity
                             ,@TotalAreal
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            SqlParameter pWeekNo = new SqlParameter("WeekNo", Convert2DBnull(obj.WeekNo));
            pWeekNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWeekNo);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", Convert2DBnull(obj.MaxCapacity));
            pMaxCapacity.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxCapacity);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionSetWeekDetail UpdateObject()、DeleteObject()
        public int UpdateProductionSetWeekDetailByID(ProductionSetWeekDetail obj)
        {
            string sql = @"Update [BE_ProductionSetWeekDetail] Set
                              [SetID]=@SetID
                             ,[WeekNo]=@WeekNo
                             ,[MaxCapacity]=@MaxCapacity
                             ,[TotalAreal]=@TotalAreal
                          Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            SqlParameter pWeekNo = new SqlParameter("WeekNo", Convert2DBnull(obj.WeekNo));
            pWeekNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWeekNo);

            SqlParameter pMaxCapacity = new SqlParameter("MaxCapacity", Convert2DBnull(obj.MaxCapacity));
            pMaxCapacity.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMaxCapacity);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductionSetWeekDetailByID(Guid ID)
        {
            string sql = @"Delete [BE_ProductionSetWeekDetail]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionSetWeekDetail LoadObject()
        public List<ProductionSetWeekDetail> LoadProductionSetWeekDetails()
        {
            string sql = @"Select 
                              [ID]
                             ,[SetID]
                             ,[WeekNo]
                             ,[MaxCapacity]
                             ,[TotalAreal]
                       From [BE_ProductionSetWeekDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductionSetWeekDetail> ret = new List<ProductionSetWeekDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSetWeekDetail iret = new ProductionSetWeekDetail();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        iret.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        iret.WeekNo = (int)dr["WeekNo"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (decimal)dr["MaxCapacity"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ProductionSetWeekDetail> LoadProductionSetWeekDetailByID(ProductionSetWeekDetail obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[SetID]
                             ,[WeekNo]
                             ,[MaxCapacity]
                             ,[TotalAreal]
                       From [BE_ProductionSetWeekDetail] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            List<ProductionSetWeekDetail> ret = new List<ProductionSetWeekDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSetWeekDetail iret = new ProductionSetWeekDetail();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        iret.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        iret.WeekNo = (int)dr["WeekNo"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        iret.MaxCapacity = (decimal)dr["MaxCapacity"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadProductionSetWeekDetail(ProductionSetWeekDetail obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[SetID]
                             ,[WeekNo]
                             ,[MaxCapacity]
                             ,[TotalAreal]
                       From [BE_ProductionSetWeekDetail] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ID"]))
                        obj.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        obj.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        obj.WeekNo = (int)dr["WeekNo"];
                    if (!Convert.IsDBNull(dr["MaxCapacity"]))
                        obj.MaxCapacity = (decimal)dr["MaxCapacity"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
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

        #region BE_ProductionSetWeekDetail CountObjects()、ExistsObjects()
        public int CountProductionSetWeekDetail()
        {
            string sql = @"Select Count(*) From [BE_ProductionSetWeekDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductionSetWeekDetailByID(Guid ID)
        {
            string sql = @"Select Count(*) From [BE_ProductionSetWeekDetail]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductionSetWeekDetail()
        {
            string sql = @"Select Top 1 * From [BE_ProductionSetWeekDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductionSetWeekDetailByID(Guid ID)
        {
            string sql = @"Select Top 1 * From [BE_ProductionSetWeekDetail]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

