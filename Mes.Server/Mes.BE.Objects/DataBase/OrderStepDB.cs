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
        #region BE_OrderStep InsertObject()
        public int InsertOrderStep(OrderStep obj)
        {
            string sql = @"Insert Into [BE_OrderStep](
                              [StepID]
                             ,[PrivilegeID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StepCode]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                              @StepID
                             ,@PrivilegeID
                             ,@StepNo
                             ,@StepName
                             ,@StepCode
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pStepCode = new SqlParameter("StepCode", Convert2DBnull(obj.StepCode));
            pStepCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepCode);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderStep UpdateObject()、DeleteObject()
        public int UpdateOrderStepByStepID(OrderStep obj)
        {
            string sql = @"Update [BE_OrderStep] Set
                              [PrivilegeID]=@PrivilegeID
                             ,[StepNo]=@StepNo
                             ,[StepName]=@StepName
                             ,[StepCode]=@StepCode
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(obj.StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pStepNo = new SqlParameter("StepNo", Convert2DBnull(obj.StepNo));
            pStepNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pStepNo);

            SqlParameter pStepName = new SqlParameter("StepName", Convert2DBnull(obj.StepName));
            pStepName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepName);

            SqlParameter pStepCode = new SqlParameter("StepCode", Convert2DBnull(obj.StepCode));
            pStepCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStepCode);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteOrderStepByStepID(Guid StepID)
        {
            string sql = @"Delete [BE_OrderStep]  Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_OrderStep LoadObject()
        public List<OrderStep> LoadOrderSteps()
        {
            string sql = @"Select 
                              [StepID]
                             ,[PrivilegeID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StepCode]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_OrderStep] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<OrderStep> ret = new List<OrderStep>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    OrderStep iret = new OrderStep();
                    if (!Convert.IsDBNull(dr["StepID"]))
                        iret.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        iret.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        iret.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StepCode"]))
                        iret.StepCode = (string)dr["StepCode"];
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

        public int LoadOrderStep(OrderStep obj)
        {
            string sql = @"Select 
                              [StepID]
                             ,[PrivilegeID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StepCode]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_OrderStep] With(NoLock) Where StepID=@StepID";

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
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        obj.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StepCode"]))
                        obj.StepCode = (string)dr["StepCode"];
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

        public int LoadOrderStepByStepCode(OrderStep obj)
        {
            string sql = @"Select 
                              [StepID]
                             ,[PrivilegeID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StepCode]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_OrderStep] With(NoLock) Where StepCode=@StepCode";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepCode = new SqlParameter("StepCode", Convert2DBnull(obj.StepCode));
            pStepCode.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(pStepCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["StepID"]))
                        obj.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        obj.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StepCode"]))
                        obj.StepCode = (string)dr["StepCode"];
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

        public int LoadOrderStepByPrivilegeID(OrderStep obj)
        {
            string sql = @"Select 
                              [StepID]
                             ,[PrivilegeID]
                             ,[StepNo]
                             ,[StepName]
                             ,[StepCode]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_OrderStep] With(NoLock) Where PrivilegeID=@PrivilegeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["StepID"]))
                        obj.StepID = (Guid)dr["StepID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    if (!Convert.IsDBNull(dr["StepNo"]))
                        obj.StepNo = (int)dr["StepNo"];
                    if (!Convert.IsDBNull(dr["StepName"]))
                        obj.StepName = (string)dr["StepName"];
                    if (!Convert.IsDBNull(dr["StepCode"]))
                        obj.StepCode = (string)dr["StepCode"];
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

        #region BE_OrderStep CountObjects()、ExistsObjects()
        public int CountOrderStep()
        {
            string sql = @"Select Count(*) From [BE_OrderStep] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountOrderStepStepID(Guid StepID)
        {
            string sql = @"Select Count(*) From [BE_OrderStep]  Where StepID=@StepID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStepID = new SqlParameter("StepID", Convert2DBnull(StepID));
            pStepID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pStepID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsOrderStep()
        {
            string sql = @"Select Top 1 * From [BE_OrderStep] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsOrderStepStepID(Guid StepID)
        {
            string sql = @"Select Top 1 * From [BE_OrderStep]  Where StepID=@StepID";

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

