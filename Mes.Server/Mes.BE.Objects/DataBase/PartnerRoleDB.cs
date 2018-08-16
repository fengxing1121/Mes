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
       
        #region BE_PartnerRole InsertObject()
        public int InsertPartnerRole(PartnerRole obj)
        {
            string sql = @"INSERT INTO[BE_PartnerRole]([RoleID]
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

        #region BE_PartnerRole UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerRoleByGroupID_RoleName(PartnerRole obj)
        {
            string sql = @"UPDATE [BE_PartnerRole] SET [RoleID]=@RoleID
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
        public int UpdatePartnerRoleByRoleID(PartnerRole obj)
        {
            string sql = @"UPDATE [BE_PartnerRole] SET [GroupID]=@GroupID
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
        public int DeletePartnerRoleByGroupID_RoleName(Guid groupID, string roleName)
        {
            string sql = @"DELETE [BE_PartnerRole] WHERE [GroupID]=@GroupID AND [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRoleByRoleID(Guid roleID)
        {
            string sql = @"DELETE [BE_PartnerRole] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerRoleByGroupID_RoleName(PartnerRole obj)
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
 				FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [GroupID]=@GroupID AND [RoleName]=@RoleName";
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
        public int LoadPartnerRoleByRoleID(PartnerRole obj)
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
 				FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
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

        #region BE_PartnerRole CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerRoles()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByRoleID(Guid roleID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByGroupID(Guid groupID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByRoleName(string roleName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByIsLocked(bool isLocked)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByIsSystem(bool isSystem)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerRolesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerRoles()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerRole]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByRoleID(Guid roleID)
        {
            string sql = "SELECT TOP 1 [RoleID] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByGroupID(Guid groupID)
        {
            string sql = "SELECT TOP 1 [GroupID] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByRoleName(string roleName)
        {
            string sql = "SELECT TOP 1 [RoleName] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByIsLocked(bool isLocked)
        {
            string sql = "SELECT TOP 1 [IsLocked] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByIsSystem(bool isSystem)
        {
            string sql = "SELECT TOP 1 [IsSystem] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerRolesByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PartnerRole] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerRoles()
        {
            string sql = "DELETE FROM [BE_PartnerRole]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByRoleID(Guid roleID)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByGroupID(Guid groupID)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByRoleName(string roleName)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByDescription(string description)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByIsLocked(bool isLocked)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByIsSystem(bool isSystem)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerRolesByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PartnerRole] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerRole> LoadPartnerRoles()
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
				 FROM [BE_PartnerRole]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByRoleID(Guid roleID)
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
				 FROM [BE_PartnerRole] WHERE [RoleID]=@RoleID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByGroupID(Guid groupID)
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
				 FROM [BE_PartnerRole] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByRoleName(string roleName)
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
				 FROM [BE_PartnerRole] WHERE [RoleName]=@RoleName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleName = new SqlParameter("RoleName", roleName);
            pRoleName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoleName);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByDescription(string description)
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
				 FROM [BE_PartnerRole] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByIsDisabled(bool isDisabled)
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
				 FROM [BE_PartnerRole] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByIsLocked(bool isLocked)
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
				 FROM [BE_PartnerRole] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByIsSystem(bool isSystem)
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
				 FROM [BE_PartnerRole] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByCreated(DateTime created)
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
				 FROM [BE_PartnerRole] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByCreatedBy(string createdBy)
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
				 FROM [BE_PartnerRole] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByModified(DateTime modified)
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
				 FROM [BE_PartnerRole] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
        public List<PartnerRole> LoadPartnerRolesByModifiedBy(string modifiedBy)
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
				 FROM [BE_PartnerRole] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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

        #region BE_PartnerRole SearchObject()
        public SearchResult SearchPartnerRole(SearchPartnerRoleArgs args)
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
		                                        [BE_PartnerRole] r
		                                    LEFT JOIN BE_PartnerUserGroup ur on r.GroupID = ur.GroupID
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
        public List<PartnerRole> LoadPartnerRolesByUserID(Guid userID)
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
				 FROM [BE_PartnerRole] WHERE RoleID in(SELECT DISTINCT RoleID FROM [BE_PartnerUser2Role] where [UserID]=@UserID)
                ";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);
            SqlParameter pRoleID = new SqlParameter("UserID", userID);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<PartnerRole> ret = new List<PartnerRole>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerRole iret = new PartnerRole();
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
