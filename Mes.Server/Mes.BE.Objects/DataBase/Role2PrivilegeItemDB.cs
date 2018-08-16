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

        #region BE_Role2PrivilegeItem InsertObject()
        public int InsertRole2PrivilegeItem(Role2PrivilegeItem obj)
        {
            string sql = @"INSERT INTO[BE_Role2PrivilegeItem]([RoleID]
				, [PrivilegeItemID]
				) VALUES(@RoleID
				, @PrivilegeItemID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", Convert2DBnull(obj.PrivilegeItemID));
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Role2PrivilegeItem UpdateObject()、DeleteObject()、LoadObject()
        public int DeleteRole2PrivilegeItemByRoleID_PrivilegeItemID(Guid roleID, Guid privilegeItemID)
        {
            string sql = @"DELETE [BE_Role2PrivilegeItem] WHERE [RoleID]=@RoleID AND [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadRole2PrivilegeItemByRoleID_PrivilegeItemID(Role2PrivilegeItem obj)
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
 				FROM [BE_Role2PrivilegeItem] WITH(NOLOCK) WHERE [RoleID]=@RoleID AND [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", Convert2DBnull(obj.PrivilegeItemID));
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        obj.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        obj.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
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

        #region BE_Role2PrivilegeItem CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountRole2PrivilegeItems()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role2PrivilegeItem] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role2PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsRole2PrivilegeItems()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Role2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = "SELECT TOP 1 [RoleID] FROM [BE_Role2PrivilegeItem] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "SELECT TOP 1 [PrivilegeItemID] FROM [BE_Role2PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteRole2PrivilegeItems()
        {
            string sql = "DELETE FROM [BE_Role2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = "DELETE FROM [BE_Role2PrivilegeItem] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "DELETE FROM [BE_Role2PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public List<Role2PrivilegeItem> LoadRole2PrivilegeItems()
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
				 FROM [BE_Role2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Role2PrivilegeItem> ret = new List<Role2PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role2PrivilegeItem iret = new Role2PrivilegeItem();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Role2PrivilegeItem> LoadRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
				 FROM [BE_Role2PrivilegeItem] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<Role2PrivilegeItem> ret = new List<Role2PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role2PrivilegeItem iret = new Role2PrivilegeItem();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Role2PrivilegeItem> LoadRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
				 FROM [BE_Role2PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            List<Role2PrivilegeItem> ret = new List<Role2PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role2PrivilegeItem iret = new Role2PrivilegeItem();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
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

        #region BE_Role2PrivilegeItem SearchObject()
        public int DeletePrivilegeItemsByPrivilegeID_Disabled(Guid PrivilegeID)
        {
            string sql = @"DELETE [BE_Role2PrivilegeItem] WHERE [PrivilegeItemID] in (SELECT PrivilegeItemID FROM [BE_PrivilegeItem] WHERE [PrivilegeID] = @PrivilegeID and [IsDisabled] = 1);
                           DELETE [BE_PrivilegeItem] WHERE [PrivilegeID]=@PrivilegeID and [IsDisabled] = 1;";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);
            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);
            return cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
