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

        #region BE_SpecialCompanent InsertObject()
        public int InsertSpecialCompanent(SpecialCompanent obj)
        {
            string sql = @"INSERT INTO[BE_SpecialCompanent]([SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@SpecialID
				, @ItemName
				, @IsDisabled
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", Convert2DBnull(obj.SpecialID));
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

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

        #region BE_SpecialCompanent UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSpecialCompanentBySpecialID(SpecialCompanent obj)
        {
            string sql = @"UPDATE [BE_SpecialCompanent] SET [ItemName]=@ItemName
				, [IsDisabled]=@IsDisabled
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

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

            SqlParameter pSpecialID = new SqlParameter("SpecialID", Convert2DBnull(obj.SpecialID));
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentBySpecialID(Guid specialID)
        {
            string sql = @"DELETE [BE_SpecialCompanent] WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSpecialCompanentBySpecialID(SpecialCompanent obj)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", Convert2DBnull(obj.SpecialID));
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        obj.SpecialID = (Guid)dr["SpecialID"];
                    obj.ItemName = dr["ItemName"].ToString();
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

        #region BE_SpecialCompanent CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSpecialCompanents()
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsBySpecialID(Guid specialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanentsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSpecialCompanents()
        {
            string sql = "SELECT TOP 1 * FROM [BE_SpecialCompanent]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsBySpecialID(Guid specialID)
        {
            string sql = "SELECT TOP 1 [SpecialID] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanentsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_SpecialCompanent] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSpecialCompanents()
        {
            string sql = "DELETE FROM [BE_SpecialCompanent]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsBySpecialID(Guid specialID)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanentsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<SpecialCompanent> LoadSpecialCompanents()
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsBySpecialID(Guid specialID)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsByItemName(string itemName)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsByCreated(DateTime created)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsByModified(DateTime modified)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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
        public List<SpecialCompanent> LoadSpecialCompanentsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [SpecialID]
				, [ItemName]
				, [IsDisabled]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_SpecialCompanent] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<SpecialCompanent> ret = new List<SpecialCompanent>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent iret = new SpecialCompanent();
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    iret.ItemName = dr["ItemName"].ToString();
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

        #region BE_SpecialCompanent SearchObject()
        public SearchResult SearchSpecialCompanent(SearchSpecialCompanentArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[SpecialID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [SpecialID]                                          
                                          ,[ItemName]
                                          ,[IsDisabled]
                                          ,[Created]
                                          ,[CreatedBy]
                                          ,[Modified]
                                          ,[ModifiedBy]
                                      FROM [BE_SpecialCompanent] with(nolock)
	                                  WHERE 1=1");


            if (args.SpecialID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "SpecialID", "mbSpecialID", args.SpecialID.Value);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsDisabled", "mbIsDisabled", args.IsDisabled.Value);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
