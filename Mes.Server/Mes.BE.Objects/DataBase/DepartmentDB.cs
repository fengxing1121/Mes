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
        
        #region BE_Department InsertObject()
        public int InsertDepartment(Department obj)
        {
            string sql = @"INSERT INTO[BE_Department]([DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@DepartmentID
				, @DepartmentCode
				, @DepartmentName
				, @Tel
				, @Fax
				, @IsDisabled
				, @Description
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", Convert2DBnull(obj.DepartmentCode));
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", Convert2DBnull(obj.DepartmentName));
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

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

        #region BE_Department UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateDepartmentByDepartmentCode(Department obj)
        {
            string sql = @"UPDATE [BE_Department] SET [DepartmentID]=@DepartmentID
				, [DepartmentName]=@DepartmentName
				, [Tel]=@Tel
				, [Fax]=@Fax
				, [IsDisabled]=@IsDisabled
				, [Description]=@Description
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", Convert2DBnull(obj.DepartmentName));
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

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

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", Convert2DBnull(obj.DepartmentCode));
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateDepartmentByDepartmentName(Department obj)
        {
            string sql = @"UPDATE [BE_Department] SET [DepartmentID]=@DepartmentID
				, [DepartmentCode]=@DepartmentCode
				, [Tel]=@Tel
				, [Fax]=@Fax
				, [IsDisabled]=@IsDisabled
				, [Description]=@Description
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", Convert2DBnull(obj.DepartmentCode));
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

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

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", Convert2DBnull(obj.DepartmentName));
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateDepartmentByDepartmentID(Department obj)
        {
            string sql = @"UPDATE [BE_Department] SET [DepartmentCode]=@DepartmentCode
				, [DepartmentName]=@DepartmentName
				, [Tel]=@Tel
				, [Fax]=@Fax
				, [IsDisabled]=@IsDisabled
				, [Description]=@Description
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", Convert2DBnull(obj.DepartmentCode));
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", Convert2DBnull(obj.DepartmentName));
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            SqlParameter pTel = new SqlParameter("Tel", Convert2DBnull(obj.Tel));
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            SqlParameter pFax = new SqlParameter("Fax", Convert2DBnull(obj.Fax));
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", Convert2DBnull(obj.IsDisabled));
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

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

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentByDepartmentCode(string departmentCode)
        {
            string sql = @"DELETE [BE_Department] WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", departmentCode);
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentByDepartmentName(string departmentName)
        {
            string sql = @"DELETE [BE_Department] WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", departmentName);
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentByDepartmentID(Guid departmentID)
        {
            string sql = @"DELETE [BE_Department] WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadDepartmentByDepartmentCode(Department obj)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", Convert2DBnull(obj.DepartmentCode));
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        obj.DepartmentID = (Guid)dr["DepartmentID"];
                    obj.DepartmentCode = dr["DepartmentCode"].ToString();
                    obj.DepartmentName = dr["DepartmentName"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.Description = dr["Description"].ToString();
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
        public int LoadDepartmentByDepartmentName(Department obj)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", Convert2DBnull(obj.DepartmentName));
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        obj.DepartmentID = (Guid)dr["DepartmentID"];
                    obj.DepartmentCode = dr["DepartmentCode"].ToString();
                    obj.DepartmentName = dr["DepartmentName"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.Description = dr["Description"].ToString();
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
        public int LoadDepartmentByDepartmentID(Department obj)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        obj.DepartmentID = (Guid)dr["DepartmentID"];
                    obj.DepartmentCode = dr["DepartmentCode"].ToString();
                    obj.DepartmentName = dr["DepartmentName"].ToString();
                    obj.Tel = dr["Tel"].ToString();
                    obj.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        obj.IsDisabled = (bool)dr["IsDisabled"];
                    obj.Description = dr["Description"].ToString();
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

        #region BE_Department CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountDepartments()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByDepartmentID(Guid departmentID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByDepartmentCode(string departmentCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", departmentCode);
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByDepartmentName(string departmentName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", departmentName);
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByTel(string tel)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByFax(string fax)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountDepartmentsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Department] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsDepartments()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Department]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByDepartmentID(Guid departmentID)
        {
            string sql = "SELECT TOP 1 [DepartmentID] FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByDepartmentCode(string departmentCode)
        {
            string sql = "SELECT TOP 1 [DepartmentCode] FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", departmentCode);
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByDepartmentName(string departmentName)
        {
            string sql = "SELECT TOP 1 [DepartmentName] FROM [BE_Department] WITH(NOLOCK) WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", departmentName);
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByTel(string tel)
        {
            string sql = "SELECT TOP 1 [Tel] FROM [BE_Department] WITH(NOLOCK) WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByFax(string fax)
        {
            string sql = "SELECT TOP 1 [Fax] FROM [BE_Department] WITH(NOLOCK) WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_Department] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_Department] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Department] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Department] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Department] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsDepartmentsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Department] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteDepartments()
        {
            string sql = "DELETE FROM [BE_Department]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByDepartmentID(Guid departmentID)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByDepartmentCode(string departmentCode)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", departmentCode);
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByDepartmentName(string departmentName)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", departmentName);
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByTel(string tel)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByFax(string fax)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByDescription(string description)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteDepartmentsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Department] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Department> LoadDepartments()
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByDepartmentID(Guid departmentID)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByDepartmentCode(string departmentCode)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [DepartmentCode]=@DepartmentCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentCode = new SqlParameter("DepartmentCode", departmentCode);
            pDepartmentCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentCode);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByDepartmentName(string departmentName)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [DepartmentName]=@DepartmentName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentName = new SqlParameter("DepartmentName", departmentName);
            pDepartmentName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDepartmentName);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByTel(string tel)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [Tel]=@Tel";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTel = new SqlParameter("Tel", tel);
            pTel.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTel);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByFax(string fax)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [Fax]=@Fax";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFax = new SqlParameter("Fax", fax);
            pFax.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pFax);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByDescription(string description)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByCreated(DateTime created)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByModified(DateTime modified)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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
        public List<Department> LoadDepartmentsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [DepartmentID]
				, [DepartmentCode]
				, [DepartmentName]
				, [Tel]
				, [Fax]
				, [IsDisabled]
				, [Description]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Department] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Department> ret = new List<Department>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Department iret = new Department();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.DepartmentCode = dr["DepartmentCode"].ToString();
                    iret.DepartmentName = dr["DepartmentName"].ToString();
                    iret.Tel = dr["Tel"].ToString();
                    iret.Fax = dr["Fax"].ToString();
                    if (!Convert.IsDBNull(dr["IsDisabled"]))
                        iret.IsDisabled = (bool)dr["IsDisabled"];
                    iret.Description = dr["Description"].ToString();
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

        #region BE_Department SearchObject()
        public SearchResult SearchDepartment(SearchDepartmentArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[DepartmentName] ASC";
            }
            SqlCommand cmd = new SqlCommand();
            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat("SELECT * FROM [BE_Department] with(nolock) WHERE 1=1 ");

            this.SetParameters_In(mbBuilder, cmd, "DepartmentID", "mbDepartmentIDs", args.DepartmentIDs);


            if (args.DepartmentCodes != null && args.DepartmentCodes.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DepartmentCode", "mbDptCode", args.DepartmentCodes[0]);
            }
            else
            {
                this.SetParameters_In(mbBuilder, cmd, "DepartmentCode", "mbDptCode", args.DepartmentCodes);
            }

            if (args.DepartmentNames != null && args.DepartmentNames.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DepartmentName", "mbName", args.DepartmentNames[0]);
            }
            else
            {
                this.SetParameters_In(mbBuilder, cmd, "DepartmentName", "mbNames", args.DepartmentNames);
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
