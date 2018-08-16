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

        #region BE_PrivilegeItem InsertObject()
        public int InsertPrivilegeItem(PrivilegeItem obj)
        {
            string sql = @"INSERT INTO[BE_PrivilegeItem]([PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@PrivilegeItemID
				, @PrivilegeID
				, @PrivilegeItemName
				, @PrivilegeItemCode
				, @Description
				, @IsDisabled
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", Convert2DBnull(obj.PrivilegeItemID));
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", Convert2DBnull(obj.PrivilegeItemName));
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", Convert2DBnull(obj.PrivilegeItemCode));
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

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

        #region BE_PrivilegeItem UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePrivilegeItemByPrivilegeID_PrivilegeItemCode(PrivilegeItem obj)
        {
            string sql = @"UPDATE [BE_PrivilegeItem] SET [PrivilegeItemID]=@PrivilegeItemID
				, [PrivilegeItemName]=@PrivilegeItemName
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PrivilegeID]=@PrivilegeID AND [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", Convert2DBnull(obj.PrivilegeItemID));
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", Convert2DBnull(obj.PrivilegeItemName));
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

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

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", Convert2DBnull(obj.PrivilegeItemCode));
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePrivilegeItemByPrivilegeItemID(PrivilegeItem obj)
        {
            string sql = @"UPDATE [BE_PrivilegeItem] SET [PrivilegeID]=@PrivilegeID
				, [PrivilegeItemName]=@PrivilegeItemName
				, [PrivilegeItemCode]=@PrivilegeItemCode
				, [Description]=@Description
				, [IsDisabled]=@IsDisabled
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", Convert2DBnull(obj.PrivilegeItemName));
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", Convert2DBnull(obj.PrivilegeItemCode));
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

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

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", Convert2DBnull(obj.PrivilegeItemID));
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemByPrivilegeID_PrivilegeItemCode(Guid privilegeID, string privilegeItemCode)
        {
            string sql = @"DELETE [BE_PrivilegeItem] WHERE [PrivilegeID]=@PrivilegeID AND [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", privilegeItemCode);
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = @"DELETE [BE_PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPrivilegeItemByPrivilegeID_PrivilegeItemCode(PrivilegeItem obj)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID AND [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(obj.PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", Convert2DBnull(obj.PrivilegeItemCode));
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        obj.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    obj.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    obj.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
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
        public int LoadPrivilegeItemByPrivilegeItemID(PrivilegeItem obj)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", Convert2DBnull(obj.PrivilegeItemID));
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        obj.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    obj.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    obj.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
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

        #region BE_PrivilegeItem CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPrivilegeItems()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByPrivilegeID(Guid privilegeID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByPrivilegeItemName(string privilegeItemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemName]=@PrivilegeItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", privilegeItemName);
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByPrivilegeItemCode(string privilegeItemCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", privilegeItemCode);
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPrivilegeItemsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPrivilegeItems()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "SELECT TOP 1 [PrivilegeItemID] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByPrivilegeID(Guid privilegeID)
        {
            string sql = "SELECT TOP 1 [PrivilegeID] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByPrivilegeItemName(string privilegeItemName)
        {
            string sql = "SELECT TOP 1 [PrivilegeItemName] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemName]=@PrivilegeItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", privilegeItemName);
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByPrivilegeItemCode(string privilegeItemCode)
        {
            string sql = "SELECT TOP 1 [PrivilegeItemCode] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", privilegeItemCode);
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPrivilegeItemsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PrivilegeItem] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePrivilegeItems()
        {
            string sql = "DELETE FROM [BE_PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByPrivilegeID(Guid privilegeID)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByPrivilegeItemName(string privilegeItemName)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [PrivilegeItemName]=@PrivilegeItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", privilegeItemName);
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByPrivilegeItemCode(string privilegeItemCode)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", privilegeItemCode);
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByDescription(string description)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePrivilegeItemsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PrivilegeItem] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PrivilegeItem> LoadPrivilegeItems()
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByPrivilegeItemID(Guid privilegeItemID)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [PrivilegeItemID]=@PrivilegeItemID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemID = new SqlParameter("PrivilegeItemID", privilegeItemID);
            pPrivilegeItemID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeItemID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByPrivilegeID(Guid privilegeID)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByPrivilegeItemName(string privilegeItemName)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [PrivilegeItemName]=@PrivilegeItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemName = new SqlParameter("PrivilegeItemName", privilegeItemName);
            pPrivilegeItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemName);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByPrivilegeItemCode(string privilegeItemCode)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [PrivilegeItemCode]=@PrivilegeItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeItemCode = new SqlParameter("PrivilegeItemCode", privilegeItemCode);
            pPrivilegeItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeItemCode);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByDescription(string description)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByCreated(DateTime created)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByModified(DateTime modified)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_PrivilegeItem] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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

        #region BE_PrivilegeItem SearchObject()
        public SearchResult SearchPrivilegeItem(SearchPrivilegeItemArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[PrivilegeItemCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat("SELECT * FROM [BE_PrivilegeItem] with(nolock) WHERE 1=1 ");


            this.SetParameters_In(mbBuilder, cmd, "PrivilegeID", "mbPrivilegeIDs", args.PrivilegeIDs);
            if (!string.IsNullOrEmpty(args.PrivilegeCode))
            {
                mbBuilder.Append(" AND [PrivilegeID] IN (SELECT DISTINCT [PrivilegeID] FROM [BE_Privilege] WHERE 1=1");
                this.SetParameters_Contains(mbBuilder, cmd, "PrivilegeCode", "mbPrivilegeCode", args.PrivilegeCode);
                mbBuilder.Append(")");
            }

            if (!string.IsNullOrEmpty(args.PrivilegeItemCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PrivilegeItemCode", "mbPrivilegeItemCode", args.PrivilegeItemCode);
            }
            if (!string.IsNullOrEmpty(args.PrivilegeItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PrivilegeItemName", "mbPrivilegeItemName", args.PrivilegeItemName);
            }
            if (args.IsLocked.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsLocked", "mbIsLocked", args.IsLocked.Value.ToString());
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsDisabled", "mbIsDisabled", args.IsDisabled.Value.ToString());
            }

            if (args.RKeyUserIDs != null)
            {
                mbBuilder.Append(" AND [PrivilegeItemID] IN (SELECT DISTINCT [PrivilegeItemID] FROM [BE_Role2PrivilegeItem]  with(nolock) ");
                mbBuilder.Append(" LEFT JOIN [BE_User2Role] with(nolock) ON BE_Role2PrivilegeItem.RoleID = BE_User2Role.RoleID WHERE 1=1");
                this.SetParameters_In(mbBuilder, cmd, "UserID", "rkUserID", args.RKeyUserIDs);
                mbBuilder.Append(")");
            }

            if (args.RKeyRoleIDs != null)
            {
                mbBuilder.Append(" AND [PrivilegeItemID] IN (SELECT DISTINCT [PrivilegeItemID] FROM [BE_Role2PrivilegeItem] with(nolock) WHERE 1=1");
                this.SetParameters_In(mbBuilder, cmd, "RoleID", "rkRoleID", args.RKeyRoleIDs);
                mbBuilder.Append(")");
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public int UpdatePrivilegeItemsByPrivilegeID(Guid PrivilegeID)
        {
            string sql = @"UPDATE [BE_PrivilegeItem] SET [IsDisabled] = 1				
 				WHERE [PrivilegeID]=@PrivilegeID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);
            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", Convert2DBnull(PrivilegeID));
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            return cmd.ExecuteNonQuery();
        }
       
        public List<PrivilegeItem> LoadPrivilegeItemByPrivilegeCode_UserID(string privilegeCode, Guid userID)
        {
            string sql = @"SELECT 
                                [PrivilegeItemID]
                                ,[PrivilegeID]
                                ,[PrivilegeItemName]
                                ,[PrivilegeItemCode]
                                ,[Description]
                                ,[IsDisabled]
                                ,[Created]
                                ,[CreatedBy]
                                ,[Modified]
                                ,[ModifiedBy]
                            FROM 
                                [BE_PrivilegeItem]
                WHERE [PrivilegeItemID] in (SELECT DISTINCT [PrivilegeItemID] FROM [BE_Role2PrivilegeItem] rp
                LEFT JOIN [BE_User2Role] ur on rp.[RoleID] = ur.[RoleID] WHERE [UserID] = @UserID)
                and [PrivilegeID] =(SELECT [PrivilegeID] FROM [BE_Privilege] p LEFT JOIN [BE_PrivilegeCategory] pc on p.CategoryID = pc.CategoryID WHERE [PrivilegeCode]=@PrivilegeCode)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemByPrivilegeCode_PartnerUserID(string privilegeCode, Guid userID)
        {
            string sql = @"SELECT 
                                [PrivilegeItemID]
                                ,[PrivilegeID]
                                ,[PrivilegeItemName]
                                ,[PrivilegeItemCode]
                                ,[Description]
                                ,[IsDisabled]
                                ,[Created]
                                ,[CreatedBy]
                                ,[Modified]
                                ,[ModifiedBy]
                            FROM 
                                [BE_PrivilegeItem]
                WHERE [PrivilegeItemID] in (SELECT DISTINCT [PrivilegeItemID] FROM [BE_PartnerRole2PrivilegeItem] rp
                LEFT JOIN [BE_PartnerUser2Role] ur on rp.[RoleID] = ur.[RoleID] WHERE [UserID] = @UserID)
                and [PrivilegeID] =(SELECT [PrivilegeID] FROM [BE_Privilege] p LEFT JOIN [BE_PrivilegeCategory] pc on p.CategoryID = pc.CategoryID WHERE [PrivilegeCode]=@PrivilegeCode)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPrivilegeCode = new SqlParameter("PrivilegeCode", privilegeCode);
            pPrivilegeCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPrivilegeCode);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByRoleID(Guid roleID)
        {
            string sql = @"SELECT 
                                                [PrivilegeItemID]
                                                ,[PrivilegeID]
                                                ,[PrivilegeItemName]
                                                ,[PrivilegeItemCode]
                                                ,[Description]
                                                ,[IsDisabled]
                                                ,[Created]
                                                ,[CreatedBy]
                                                ,[Modified]
                                                ,[ModifiedBy]
                                          FROM 
                                                [BE_PrivilegeItem] 
                                          WHERE [PrivilegeItemID] in (SELECT DISTINCT [PrivilegeItemID] FROM [BE_Role2PrivilegeItem] WHERE [RoleID] = @RoleID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("RoleID", roleID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByPartnerRoleID(Guid roleID)
        {
            string sql = @"SELECT 
                                                [PrivilegeItemID]
                                                ,[PrivilegeID]
                                                ,[PrivilegeItemName]
                                                ,[PrivilegeItemCode]
                                                ,[Description]
                                                ,[IsDisabled]
                                                ,[Created]
                                                ,[CreatedBy]
                                                ,[Modified]
                                                ,[ModifiedBy]
                                          FROM 
                                                [BE_PrivilegeItem] 
                                          WHERE [PrivilegeItemID] in (SELECT DISTINCT [PrivilegeItemID] FROM [BE_PartnerRole2PrivilegeItem] WHERE [RoleID] = @RoleID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("RoleID", roleID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByUserID(Guid userID)
        {
            string sql = @"SELECT [PrivilegeItemID]
				                            , [PrivilegeID]
				                            , [PrivilegeItemName]
				                            , [PrivilegeItemCode]
				                            , [Description]               
				                            , [IsDisabled]
				                            , [Created]
				                            , [CreatedBy]
				                            , [Modified]
				                            , [ModifiedBy]
				                    FROM 
                                            [BE_PrivilegeItem] 
                                    WHERE 
                                            [PrivilegeItemID] IN (SELECT DISTINCT [PrivilegeItemID]
                                            FROM [BE_Role2PrivilegeItem] rp
                                            LEFT JOIN [BE_User2Role] ur on rp.[RoleID] = ur.[RoleID] WHERE [UserID] = @UserID)
                                            AND [PrivilegeID] IN (SELECT DISTINCT [PrivilegeID] FROM [BE_Privilege] p LEFT JOIN [BE_PrivilegeCategory] pc on p.CategoryID = pc.CategoryID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("UserID", userID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemsByPartnerUserID(Guid userID)
        {
            string sql = @"SELECT [PrivilegeItemID]
				                            , [PrivilegeID]
				                            , [PrivilegeItemName]
				                            , [PrivilegeItemCode]
				                            , [Description]               
				                            , [IsDisabled]
				                            , [Created]
				                            , [CreatedBy]
				                            , [Modified]
				                            , [ModifiedBy]
				                    FROM 
                                            [BE_PrivilegeItem] 
                                    WHERE 
                                            [PrivilegeItemID] IN (SELECT DISTINCT [PrivilegeItemID]
                                            FROM [BE_PartnerRole2PrivilegeItem] rp
                                            LEFT JOIN [BE_PartnerUser2Role] ur on rp.[RoleID] = ur.[RoleID] WHERE [UserID] = @UserID)
                                            AND [PrivilegeID] IN (SELECT DISTINCT [PrivilegeID] FROM [BE_Privilege] p LEFT JOIN [BE_PrivilegeCategory] pc on p.CategoryID = pc.CategoryID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("UserID", userID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemByPrivilegeID_UserID(Guid privilegeID, Guid userID)
        {
            string sql = @"SELECT 
                                [PrivilegeItemID]
                                ,[PrivilegeID]
                                ,[PrivilegeItemName]
                                ,[PrivilegeItemCode]
                                ,[Description]
                                ,[IsDisabled]
                                ,[Created]
                                ,[CreatedBy]
                                ,[Modified]
                                ,[ModifiedBy]
                            FROM 
                                [BE_PrivilegeItem]
                WHERE [PrivilegeID] = @PrivilegeID and  [PrivilegeItemID] in (SELECT DISTINCT [PrivilegeItemID]
                FROM [BE_Role2PrivilegeItem] rp
                LEFT JOIN [BE_User2Role] ur on rp.[RoleID] = ur.[RoleID] WHERE [UserID] = @UserID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();

                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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
        public List<PrivilegeItem> LoadPrivilegeItemByPrivilegeID_PartnerUserID(Guid privilegeID, Guid userID)
        {
            string sql = @"SELECT 
                                [PrivilegeItemID]
                                ,[PrivilegeID]
                                ,[PrivilegeItemName]
                                ,[PrivilegeItemCode]
                                ,[Description]
                                ,[IsDisabled]
                                ,[Created]
                                ,[CreatedBy]
                                ,[Modified]
                                ,[ModifiedBy]
                            FROM 
                                [BE_PrivilegeItem]
                WHERE [PrivilegeID] = @PrivilegeID and  [PrivilegeItemID] in (SELECT DISTINCT [PrivilegeItemID]
                FROM [BE_PartnerRole2PrivilegeItem] rp
                LEFT JOIN [BE_PartnerUser2Role] ur on rp.[RoleID] = ur.[RoleID] WHERE [UserID] = @UserID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrivilegeID = new SqlParameter("PrivilegeID", privilegeID);
            pPrivilegeID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPrivilegeID);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<PrivilegeItem> ret = new List<PrivilegeItem>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PrivilegeItem iret = new PrivilegeItem();
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        iret.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        iret.PrivilegeID = (Guid)dr["PrivilegeID"];
                    iret.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    iret.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    iret.Description = dr["Description"].ToString();

                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
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

        public int LoadPrivilegeItemsByPrivilegeID_PrivilegeItemName(PrivilegeItem obj)
        {
            string sql = @"SELECT [PrivilegeItemID]
				, [PrivilegeID]
				, [PrivilegeItemName]
				, [PrivilegeItemCode]
				, [Description]              
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				FROM [BE_PrivilegeItem] 
                WHERE [PrivilegeID]=@PrivilegeID                
                and [PrivilegeItemName] = @PrivilegeItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            cmd.Parameters.AddWithValue("PrivilegeID", obj.PrivilegeID);
            cmd.Parameters.AddWithValue("PrivilegeItemName", obj.PrivilegeItemName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PrivilegeItemID"]))
                        obj.PrivilegeItemID = (Guid)dr["PrivilegeItemID"];
                    if (!Convert.IsDBNull(dr["PrivilegeID"]))
                        obj.PrivilegeID = (Guid)dr["PrivilegeID"];
                    obj.PrivilegeItemName = dr["PrivilegeItemName"].ToString();
                    obj.PrivilegeItemCode = dr["PrivilegeItemCode"].ToString();
                    obj.Description = dr["Description"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
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
    }
}
