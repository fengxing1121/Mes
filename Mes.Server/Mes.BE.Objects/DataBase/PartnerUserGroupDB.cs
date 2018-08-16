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

        #region BE_PartnerUserGroup InsertObject()
        public int InsertPartnerUserGroup(PartnerUserGroup obj)
        {
            string sql = @"INSERT INTO[BE_PartnerUserGroup]([GroupID]
				, [PartnerID]
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
				, @PartnerID
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

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

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

        #region BE_PartnerUserGroup UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerUserGroupByPartnerID_GroupName(PartnerUserGroup obj)
        {
            string sql = @"UPDATE [BE_PartnerUserGroup] SET [GroupID]=@GroupID
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PartnerID]=@PartnerID AND [GroupName]=@GroupName";
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

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pGroupName = new SqlParameter("GroupName", Convert2DBnull(obj.GroupName));
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePartnerUserGroupByGroupID(PartnerUserGroup obj)
        {
            string sql = @"UPDATE [BE_PartnerUserGroup] SET [PartnerID]=@PartnerID
				, [GroupName]=@GroupName
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

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

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
        public int DeletePartnerUserGroupByPartnerID_GroupName(Guid partnerID, string groupName)
        {
            string sql = @"DELETE [BE_PartnerUserGroup] WHERE [PartnerID]=@PartnerID AND [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupByGroupID(Guid groupID)
        {
            string sql = @"DELETE [BE_PartnerUserGroup] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerUserGroupByPartnerID_GroupName(PartnerUserGroup obj)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID AND [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

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
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
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
        public int LoadPartnerUserGroupByGroupID(PartnerUserGroup obj)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
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
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
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

        #region BE_PartnerUserGroup CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerUserGroups()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByGroupID(Guid groupID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByGroupName(string groupName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByIsLocked(bool isLocked)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByIsSystem(bool isSystem)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerUserGroups()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerUserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByGroupID(Guid groupID)
        {
            string sql = "SELECT TOP 1 [GroupID] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByGroupName(string groupName)
        {
            string sql = "SELECT TOP 1 [GroupName] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByIsLocked(bool isLocked)
        {
            string sql = "SELECT TOP 1 [IsLocked] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByIsSystem(bool isSystem)
        {
            string sql = "SELECT TOP 1 [IsSystem] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PartnerUserGroup] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerUserGroups()
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByGroupID(Guid groupID)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByGroupName(string groupName)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByDescription(string description)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByIsLocked(bool isLocked)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByIsSystem(bool isSystem)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PartnerUserGroup] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerUserGroup> LoadPartnerUserGroups()
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByGroupID(Guid groupID)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [GroupID]=@GroupID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupID = new SqlParameter("GroupID", groupID);
            pGroupID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pGroupID);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByGroupName(string groupName)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [GroupName]=@GroupName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pGroupName = new SqlParameter("GroupName", groupName);
            pGroupName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pGroupName);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByDescription(string description)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByIsLocked(bool isLocked)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByIsSystem(bool isSystem)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByCreated(DateTime created)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByModified(DateTime modified)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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
        public List<PartnerUserGroup> LoadPartnerUserGroupsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [GroupID]
				, [PartnerID]
				, [GroupName]
				, [Description]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PartnerUserGroup] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PartnerUserGroup> ret = new List<PartnerUserGroup>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUserGroup iret = new PartnerUserGroup();
                    if (!Convert.IsDBNull(dr["GroupID"]))
                        iret.GroupID = (Guid)dr["GroupID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
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

        #region BE_PartnerUserGroup SearchObject()
        public SearchResult SearchPartnerUserGroup(SearchPartnerUserGroupArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[GroupName] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat("SELECT * FROM [BE_PartnerUserGroup] with(nolock) WHERE 1=1");
            this.SetParameters_In(mbBuilder, cmd, "GroupID", "mbIDs", args.UserGroupIDs);

            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerUserGroup].[PartnerID", "mbPartnerID", args.PartnerID);
            }

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
