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
        #region BE_WorkOrderComponent InsertObject()
        public int InsertWorkOrderComponent(WorkOrderComponent obj)
        {
            string sql = @"Insert Into [BE_WorkOrderComponent](
                              [WorkOrderID]
                             ,[ComponentID]
            )Values (
                              @WorkOrderID
                             ,@ComponentID
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkOrderComponent UpdateObject()、DeleteObject()
        public int UpdateWorkOrderComponentByWorkOrderID(WorkOrderComponent obj)
        {
            string sql = @"Update [BE_WorkOrderComponent] Set
                              [ComponentID]=@ComponentID
                          Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            SqlParameter pComponentID = new SqlParameter("ComponentID", Convert2DBnull(obj.ComponentID));
            pComponentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentID);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteWorkOrderComponentByWorkOrderID(Guid WorkOrderID)
        {
            string sql = @"Delete [BE_WorkOrderComponent]  Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkOrderComponent LoadObject()
        public List<WorkOrderComponent> LoadWorkOrderComponents()
        {
            string sql = @"Select 
                              [WorkOrderID]
                             ,[ComponentID]
                       From [BE_WorkOrderComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkOrderComponent> ret = new List<WorkOrderComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkOrderComponent iret = new WorkOrderComponent();
                    if (!Convert.IsDBNull(dr["WorkOrderID"]))
                        iret.WorkOrderID = (Guid)dr["WorkOrderID"];
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

        public List<WorkOrderComponent> LoadWorkOrderComponentByWorkOrderID(WorkOrderComponent obj)
        {
            string sql = @"Select 
                              [WorkOrderID]
                             ,[ComponentID]
                       From [BE_WorkOrderComponent] With(NoLock) Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            List<WorkOrderComponent> ret = new List<WorkOrderComponent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkOrderComponent iret = new WorkOrderComponent();
                    if (!Convert.IsDBNull(dr["WorkOrderID"]))
                        iret.WorkOrderID = (Guid)dr["WorkOrderID"];
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

        public int LoadWorkOrderComponent(WorkOrderComponent obj)
        {
            string sql = @"Select 
                              [WorkOrderID]
                             ,[ComponentID]
                       From [BE_WorkOrderComponent] With(NoLock) Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(obj.WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkOrderID"]))
                        obj.WorkOrderID = (Guid)dr["WorkOrderID"];
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

        #region BE_WorkOrderComponent CountObjects()、ExistsObjects()
        public int CountWorkOrderComponent()
        {
            string sql = @"Select Count(*) From [BE_WorkOrderComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountWorkOrderComponentByWorkOrderID(Guid WorkOrderID)
        {
            string sql = @"Select Count(*) From [BE_WorkOrderComponent]  Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsWorkOrderComponent()
        {
            string sql = @"Select Top 1 * From [BE_WorkOrderComponent] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsWorkOrderComponentByWorkOrderID(Guid WorkOrderID)
        {
            string sql = @"Select Top 1 * From [BE_WorkOrderComponent]  Where WorkOrderID=@WorkOrderID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkOrderID = new SqlParameter("WorkOrderID", Convert2DBnull(WorkOrderID));
            pWorkOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

