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
       
        #region BE_UserGroup InsertObject()
        public int InsertUserGroup(UserGroup obj)
        {
            string sql = @"INSERT INTO[BE_UserGroup]([GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@GroupID
				, @GroupName
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

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            SqlParameter pGroupName = new SqlParameter("GroupName", Convert2DBnull(obj.GroupName));
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

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

        #region BE_UserGroup UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateUserGroupByGroupName(UserGroup obj)
        {
            string sql = @"UPDATE [BE_UserGroup] SET [GroupID]=@GroupID
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

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

            SqlParameter pGroupName = new SqlParameter("GroupName", Convert2DBnull(obj.GroupName));
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateUserGroupByGroupID(UserGroup obj)
        {
            string sql = @"UPDATE [BE_UserGroup] SET [GroupName]=@GroupName
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", Convert2DBnull(obj.GroupName));
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

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

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupByGroupName(string groupName)
        {
            string sql = @"DELETE [BE_UserGroup] WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupByGroupID(Guid groupID)
        {
            string sql = @"DELETE [BE_UserGroup] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadUserGroupByGroupName(UserGroup obj)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_UserGroup] WITH(NOLOCK) WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", Convert2DBnull(obj.GroupName));
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        obj.GroupID = (Guid)dr["GroupID"];
                    obj.GroupName = dr["GroupName"].ToString();
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
        public int LoadUserGroupByGroupID(UserGroup obj)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_UserGroup] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", Convert2DBnull(obj.GroupID));
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        obj.GroupID = (Guid)dr["GroupID"];
                    obj.GroupName = dr["GroupName"].ToString();
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

        #region BE_UserGroup CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountUserGroups()
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByGroupID(Guid groupID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByGroupName(string groupName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByIsLocked(bool isLocked)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByIsSystem(bool isSystem)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_UserGroup] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsUserGroups()
        {
            string sql = "SELECT TOP 1 * FROM [BE_UserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByGroupID(Guid groupID)
        {
            string sql = "SELECT TOP 1 [GroupID] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByGroupName(string groupName)
        {
            string sql = "SELECT TOP 1 [GroupName] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByIsLocked(bool isLocked)
        {
            string sql = "SELECT TOP 1 [IsLocked] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByIsSystem(bool isSystem)
        {
            string sql = "SELECT TOP 1 [IsSystem] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_UserGroup] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteUserGroups()
        {
            string sql = "DELETE FROM [BE_UserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByGroupID(Guid groupID)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByGroupName(string groupName)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByDescription(string description)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByIsLocked(bool isLocked)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByIsSystem(bool isSystem)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_UserGroup] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<UserGroup> LoadUserGroups()
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByGroupID(Guid groupID)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByGroupName(string groupName)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByDescription(string description)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByIsLocked(bool isLocked)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByIsSystem(bool isSystem)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByCreated(DateTime created)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByModified(DateTime modified)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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
        public List<UserGroup> LoadUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [GroupID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_UserGroup] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<UserGroup> ret = new List<UserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    UserGroup iret = new UserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    iret.GroupName = dr["GroupName"].ToString();
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

        #region BE_UserGroup SearchObject()
        public SearchResult SearchUserGroup(SearchUserGroupArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[GroupName] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat("SELECT * FROM [BE_UserGroup] with(nolock) WHERE 1=1");
            this.SetParameters_In(mbBuilder, cmd, "GroupID", "mbIDs", args.UserGroupIDs);

            if (!string.IsNullOrEmpty(args.GroupName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "GroupName", "mbName", args.GroupName);
            }
            if (args.IsLocked.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsLocked", "mbIsLocked", args.IsLocked.Value.ToString());
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsDisabled", "mbIsDisabled", args.IsDisabled.Value.ToString());
            }
            if (args.IsSystem.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsSystem", "mbIsSystem", args.IsSystem.Value.ToString());
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
