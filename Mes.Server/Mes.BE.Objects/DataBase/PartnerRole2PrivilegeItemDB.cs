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
        #region BE_PartnerRole2PrivilegeItem InsertObject()
        public int InsertPartnerRole2PrivilegeItem(PartnerRole2PrivilegeItem obj)
        {
            string sql = @"INSERT INTO[BE_PartnerRole2PrivilegeItem]([RoleID]
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

        #region BE_PartnerRole2PrivilegeItem UpdateObject()、DeleteObject()、LoadObject()
        public int DeletePartnerRole2PrivilegeItemByRoleID_PrivilegeItemID(Guid roleID, Guid privilegeItemID)
        {
            string sql = @"DELETE [BE_PartnerRole2PrivilegeItem] WHERE [RoleID]=@RoleID AND [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerRole2PrivilegeItemByRoleID_PrivilegeItemID(PartnerRole2PrivilegeItem obj)
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
 				FROM [BE_PartnerRole2PrivilegeItem] WITH(NOLOCK) WHERE [RoleID]=@RoleID AND [PrivilegeItemID]=@PrivilegeItemID";
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

        #region BE_PartnerRole2PrivilegeItem CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerRole2PrivilegeItems()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole2PrivilegeItem] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole2PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerRole2PrivilegeItems()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerRole2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = "SELECT TOP 1 [RoleID] FROM [BE_PartnerRole2PrivilegeItem] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "SELECT TOP 1 [PrivilegeItemID] FROM [BE_PartnerRole2PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerRole2PrivilegeItems()
        {
            string sql = "DELETE FROM [BE_PartnerRole2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = "DELETE FROM [BE_PartnerRole2PrivilegeItem] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "DELETE FROM [BE_PartnerRole2PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerRole2PrivilegeItem> LoadPartnerRole2PrivilegeItems()
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
				 FROM [BE_PartnerRole2PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerRole2PrivilegeItem> ret = new List<PartnerRole2PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole2PrivilegeItem iret = new PartnerRole2PrivilegeItem();
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
        public List<PartnerRole2PrivilegeItem> LoadPartnerRole2PrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
				 FROM [BE_PartnerRole2PrivilegeItem] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<PartnerRole2PrivilegeItem> ret = new List<PartnerRole2PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole2PrivilegeItem iret = new PartnerRole2PrivilegeItem();
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
        public List<PartnerRole2PrivilegeItem> LoadPartnerRole2PrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = @"SELECT [RoleID]
				, [PrivilegeItemID]
				 FROM [BE_PartnerRole2PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            List<PartnerRole2PrivilegeItem> ret = new List<PartnerRole2PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole2PrivilegeItem iret = new PartnerRole2PrivilegeItem();
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
    }
}
