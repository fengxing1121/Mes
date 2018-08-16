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

        #region BE_Role InsertObject()
        public int InsertRole(Role obj)
        {
            string sql = @"INSERT INTO[BE_Role]([RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@RoleID
				, @GroupID
				, @RoleName
				, @Description
				, @IsDisabled
				, @IsLocked
				, @IsSystem
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pRoleName = new SqlParameter("RoleName", Convert2DBnull(obj.RoleName));
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", Convert2DBnull(obj.IsLocked));
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", Convert2DBnull(obj.IsSystem));
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

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

        #region BE_Role UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateRoleByGroupID_RoleName(Role obj)
        {
            string sql = @"UPDATE [BE_Role] SET [RoleID]=@RoleID
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [GroupID]=@GroupID AND [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", Convert2DBnull(obj.IsLocked));
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", Convert2DBnull(obj.IsSystem));
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

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

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pRoleName = new SqlParameter("RoleName", Convert2DBnull(obj.RoleName));
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateRoleByRoleID(Role obj)
        {
            string sql = @"UPDATE [BE_Role] SET [GroupID]=@GroupID
				, [RoleName]=@RoleName
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pRoleName = new SqlParameter("RoleName", Convert2DBnull(obj.RoleName));
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", Convert2DBnull(obj.IsLocked));
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", Convert2DBnull(obj.IsSystem));
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

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

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoleByGroupID_RoleName(Guid groupID, string roleName)
        {
            string sql = @"DELETE [BE_Role] WHERE [GroupID]=@GroupID AND [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoleByRoleID(Guid roleID)
        {
            string sql = @"DELETE [BE_Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadRoleByGroupID_RoleName(Role obj)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Role] WITH(NOLOCK) WHERE [GroupID]=@GroupID AND [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pRoleName = new SqlParameter("RoleName", Convert2DBnull(obj.RoleName));
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        obj.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        obj.GroupID = (Guid)dr["GroupID"];
                    obj.RoleName = dr["RoleName"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        obj.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        obj.IsSystem = (bool)dr["IsSystem"];
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
        public int LoadRoleByRoleID(Role obj)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", Convert2DBnull(obj.RoleID));
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        obj.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        obj.GroupID = (Guid)dr["GroupID"];
                    obj.RoleName = dr["RoleName"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        obj.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        obj.IsSystem = (bool)dr["IsSystem"];
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

        #region BE_Role CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountRoles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByRoleID(Guid roleID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByGroupID(Guid groupID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByRoleName(string roleName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByIsLocked(bool isLocked)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByIsSystem(bool isSystem)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRolesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Role] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsRoles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByRoleID(Guid roleID)
        {
            string sql = "SELECT TOP 1 [RoleID] FROM [BE_Role] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByGroupID(Guid groupID)
        {
            string sql = "SELECT TOP 1 [GroupID] FROM [BE_Role] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByRoleName(string roleName)
        {
            string sql = "SELECT TOP 1 [RoleName] FROM [BE_Role] WITH(NOLOCK) WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_Role] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_Role] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByIsLocked(bool isLocked)
        {
            string sql = "SELECT TOP 1 [IsLocked] FROM [BE_Role] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByIsSystem(bool isSystem)
        {
            string sql = "SELECT TOP 1 [IsSystem] FROM [BE_Role] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Role] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Role] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Role] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRolesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Role] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteRoles()
        {
            string sql = "DELETE FROM [BE_Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByRoleID(Guid roleID)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByGroupID(Guid groupID)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByRoleName(string roleName)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByDescription(string description)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByIsLocked(bool isLocked)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByIsSystem(bool isSystem)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRolesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Role] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Role> LoadRoles()
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByRoleID(Guid roleID)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByGroupID(Guid groupID)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByRoleName(string roleName)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByDescription(string description)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByIsLocked(bool isLocked)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByIsSystem(bool isSystem)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByCreated(DateTime created)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByModified(DateTime modified)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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
        public List<Role> LoadRolesByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
                    if (!Convert.IsDBNull(dr["IsSystem"]))
                        iret.IsSystem = (bool)dr["IsSystem"];
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

        #region BE_Role SearchObject()
        public SearchResult SearchRole(SearchRoleArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[RoleName] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT r.[RoleID]
                                                ,r.[GroupID]
                                                ,r.[RoleName]
                                                ,r.[Description]
                                                ,r.[IsDisabled]
                                                ,r.[IsLocked]
                                                ,r.[IsSystem]
                                                ,r.[Created]
                                                ,r.[CreatedBy]
                                                ,r.[Modified]
                                                ,r.[ModifiedBy]
	                                        FROM 
		                                        [BE_Role] r
		                                    LEFT JOIN BE_UserGroup ur on r.GroupID = ur.GroupID
	                                        WHERE 1=1");
            this.SetParameters_In(mbBuilder, cmd, "RoleID", "mbIDs", args.RoleIDs);


            if (args.RoleNames != null && args.RoleNames.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "RoleName", "mbNames", args.RoleNames[0]);
            }
            else
            {
                this.SetParameters_In(mbBuilder, cmd, "RoleName", "mbNames", args.RoleNames);
            }
            if (args.GroupIDs != null)
            {
                this.SetParameters_In(mbBuilder, cmd, "r].[GroupID", "mbGroupIDs", args.GroupIDs);
            }
            if (args.IsLocked.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "r].[IsLocked", "mbIsLocked", args.IsLocked.Value.ToString());
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "r].[IsDisabled", "mbIsDisabled", args.IsDisabled.Value.ToString());
            }
            if (args.IsSystem.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "r].[IsSystem", "mbIsSystem", args.IsSystem.Value.ToString());
            }
            mbBuilder.AppendFormat(") mb");


            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public List<Role> LoadRolesByUserID(Guid userID)
        {
            string sql = @"SELECT [RoleID]
				, [GroupID]
				, [RoleName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Role] WHERE RoleID in(SELECT DISTINCT RoleID FROM [BE_User2Role] where [UserID]=@UserID)
                ";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);
            SqlParameter pRoleID = new SqlParameter("UserID", userID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<Role> ret = new List<Role>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Role iret = new Role();
                    if (!Convert.IsDBNull(dr["RoleID"]))
                        iret.RoleID = (Guid)dr["RoleID"];
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.RoleName = dr["RoleName"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    if (!Convert.IsDBNull(dr["IsLocked"]))
                        iret.IsLocked = (bool)dr["IsLocked"];
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
    }
}
