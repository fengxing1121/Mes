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
        #region BE_OrderStepLog InsertObject()
        public int InsertOrderStepLog(OrderStepLog obj)
        {
            string sql = @"Insert Into [BE_OrderStepLog](
                              [StepID]
                             ,[OrderID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StartedBy]
                             ,[Started]
                             ,[Remark]
            )Values (
                              @StepID
                             ,@OrderID
                             ,@StepNo
                             ,@StepName
                             ,@StartedBy
                             ,@Started
                             ,@Remark
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderStepLog UpdateObject()、DeleteObject()
        public int UpdateOrderStepLogByStepID(OrderStepLog obj)
        {
            string sql = @"Update [BE_OrderStepLog] Set
                              [OrderID]=@OrderID
                             ,[StepNo]=@StepNo
                             ,[StepName]=@StepName
                             ,[StartedBy]=@StartedBy
                             ,[Started]=@Started
                             ,[Remark]=@Remark
                          Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pStartedBy = new SqlParameter("StartedBy", Convert2DBnull(obj.StartedBy));
            pStartedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStartedBy);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteOrderStepLogByStepID(Guid StepID)
        {
            string sql = @"Delete [BE_OrderStepLog]  Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderStepLog LoadObject()
        public List<OrderStepLog> LoadOrderStepLogs()
        {
            string sql = @"Select 
                              [StepID]
                             ,[OrderID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StartedBy]
                             ,[Started]
                             ,[Remark]
                       From [BE_OrderStepLog] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderStepLog> ret = new List<OrderStepLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderStepLog iret = new OrderStepLog();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        iret.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StartedBy"]))
                        iret.StartedBy = (string)dr["StartedBy"];
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<OrderStepLog> LoadOrderStepLogByOrderID(OrderStepLog obj)
        {
            string sql = @"Select 
                              [StepID]
                             ,[OrderID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StartedBy]
                             ,[Started]
                             ,[Remark]
                       From [BE_OrderStepLog] With(NoLock) Where OrderID=@OrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<OrderStepLog> ret = new List<OrderStepLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderStepLog iret = new OrderStepLog();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        iret.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StartedBy"]))
                        iret.StartedBy = (string)dr["StartedBy"];
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadOrderStepLog(OrderStepLog obj)
        {
            string sql = @"Select 
                              [StepID]
                             ,[OrderID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StartedBy]
                             ,[Started]
                             ,[Remark]
                       From [BE_OrderStepLog] With(NoLock) Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["StepID"]))
                        obj.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        obj.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StartedBy"]))
                        obj.StartedBy = (string)dr["StartedBy"];
                    if (!Convert.IsDBNull(dr["Started"]))
                        obj.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        obj.Remark = (string)dr["Remark"];
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

        #region BE_OrderStepLog CountObjects()、ExistsObjects()
        public int CountOrderStepLog()
        {
            string sql = @"Select Count(*) From [BE_OrderStepLog] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountOrderStepLogStepID(Guid StepID)
        {
            string sql = @"Select Count(*) From [BE_OrderStepLog]  Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsOrderStepLog()
        {
            string sql = @"Select Top 1 * From [BE_OrderStepLog] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsOrderStepLogStepID(Guid StepID)
        {
            string sql = @"Select Top 1 * From [BE_OrderStepLog]  Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

