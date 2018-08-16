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
        #region ComponentType InsertObject()
        public int InsertComponentType(ComponentType obj)
        {
            string sql = @"Insert Into [ComponentType](
                             [ComponentTypeName]
                             ,[ComponentTypeCode]
                             ,[ParentID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                             @ComponentTypeName
                             ,@ComponentTypeCode
                             ,@ParentID
                             ,@Status
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeName = new SqlParameter("ComponentTypeName", Convert2DBnull(obj.ComponentTypeName));
            pComponentTypeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentTypeName);

            SqlParameter pComponentTypeCode = new SqlParameter("ComponentTypeCode", Convert2DBnull(obj.ComponentTypeCode));
            pComponentTypeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentTypeCode);

            SqlParameter pParentID = new SqlParameter("ParentID", Convert2DBnull(obj.ParentID));
            pParentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pParentID);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ComponentType UpdateObject()、DeleteObject()
        public int UpdateComponentTypeByComponentTypeID(ComponentType obj)
        {
            string sql = @"Update [ComponentType] Set
                              [ComponentTypeName]=@ComponentTypeName
                             ,[ComponentTypeCode]=@ComponentTypeCode
                             ,[ParentID]=@ParentID
                             ,[Status]=@Status
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where ComponentTypeID=@ComponentTypeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            SqlParameter pComponentTypeName = new SqlParameter("ComponentTypeName", Convert2DBnull(obj.ComponentTypeName));
            pComponentTypeName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentTypeName);

            SqlParameter pComponentTypeCode = new SqlParameter("ComponentTypeCode", Convert2DBnull(obj.ComponentTypeCode));
            pComponentTypeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pComponentTypeCode);

            SqlParameter pParentID = new SqlParameter("ParentID", Convert2DBnull(obj.ParentID));
            pParentID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pParentID);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteComponentTypeByComponentTypeID(Int32 ComponentTypeID)
        {
            string sql = @"Delete [ComponentType]  Where ComponentTypeID=@ComponentTypeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region ComponentType LoadObject()
        public List<ComponentType> LoadComponentTypes()
        {
            string sql = @"Select 
                              [ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[ComponentTypeCode]
                             ,[ParentID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ComponentType] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ComponentType> ret = new List<ComponentType>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ComponentType iret = new ComponentType();
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        iret.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["ComponentTypeCode"]))
                        iret.ComponentTypeCode = (string)dr["ComponentTypeCode"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (int)dr["ParentID"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public List<ComponentType> LoadComponentTypeByComponentTypeID(ComponentType obj)
        {
            string sql = @"Select 
                              [ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[ComponentTypeCode]
                             ,[ParentID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ComponentType] With(NoLock) Where ComponentTypeID=@ComponentTypeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            List<ComponentType> ret = new List<ComponentType>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ComponentType iret = new ComponentType();
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        iret.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        iret.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["ComponentTypeCode"]))
                        iret.ComponentTypeCode = (string)dr["ComponentTypeCode"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        iret.ParentID = (int)dr["ParentID"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["Status"];
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

        public int LoadComponentType(ComponentType obj)
        {
            string sql = @"Select 
                              [ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[ComponentTypeCode]
                             ,[ParentID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ComponentType] With(NoLock) Where ComponentTypeID=@ComponentTypeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(obj.ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ComponentTypeID"]))
                        obj.ComponentTypeID = (int)dr["ComponentTypeID"];
                    if (!Convert.IsDBNull(dr["ComponentTypeName"]))
                        obj.ComponentTypeName = (string)dr["ComponentTypeName"];
                    if (!Convert.IsDBNull(dr["ComponentTypeCode"]))
                        obj.ComponentTypeCode = (string)dr["ComponentTypeCode"];
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        obj.ParentID = (int)dr["ParentID"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (bool)dr["Status"];
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

        #region ComponentType CountObjects()、ExistsObjects()
        public int CountComponentType()
        {
            string sql = @"Select Count(*) From [ComponentType] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountComponentTypeComponentTypeID(Int32 ComponentTypeID)
        {
            string sql = @"Select Count(*) From [ComponentType]  Where ComponentTypeID=@ComponentTypeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsComponentType()
        {
            string sql = @"Select Top 1 * From [ComponentType] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsComponentTypeComponentTypeID(Int32 ComponentTypeID)
        {
            string sql = @"Select Top 1 * From [ComponentType]  Where ComponentTypeID=@ComponentTypeID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pComponentTypeID = new SqlParameter("ComponentTypeID", Convert2DBnull(ComponentTypeID));
            pComponentTypeID.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pComponentTypeID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region ComponentType SearchObject()
        public SearchResult SearchComponentType(SearchComponentTypeArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ComponentTypeID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              [ComponentTypeID]
                             ,[ComponentTypeName]
                             ,[ComponentTypeCode]
                             ,[ParentID]
                             ,[Status]
                             ,[Created]
                             ,[CreatedBy]
                       From [ComponentType] With(NoLock) Where 1=1 ");

            if (!string.IsNullOrEmpty(args.ComponentTypeCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ComponentTypeCode", "mComponentTypeCode", args.ComponentTypeCode);
            }
            if (!string.IsNullOrEmpty(args.ComponentTypeName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ComponentTypeName", "mComponentTypeName", args.ComponentTypeName);
            }

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}

