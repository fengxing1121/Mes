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

        #region BE_User InsertObject()
        public int InsertUser(User obj)
        {
            string sql = @"INSERT INTO[BE_User]([UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@UserID
				, @UserCode
				, @UserName
				, @DepartmentID
				, @Sex
				, @Position
				, @Email
				, @Mobile
				, @Description
				, @IDNumber
				, @Password
				, @LoginErrorCount
				, @LastLoginTime
				, @IsDisabled
				, @IsLocked
				, @IsSystem
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pSex = new SqlParameter("Sex", Convert2DBnull(obj.Sex));
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            SqlParameter pPosition = new SqlParameter("Position", Convert2DBnull(obj.Position));
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", Convert2DBnull(obj.IDNumber));
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            SqlParameter pPassword = new SqlParameter("Password", Convert2DBnull(obj.Password));
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", Convert2DBnull(obj.LoginErrorCount));
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", Convert2DBnull(obj.LastLoginTime));
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

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

        #region BE_User UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateUserByMobile(User obj)
        {
            string sql = @"UPDATE [BE_User] SET [UserID]=@UserID
				, [UserCode]=@UserCode
				, [UserName]=@UserName
				, [DepartmentID]=@DepartmentID
				, [Sex]=@Sex
				, [Position]=@Position
				, [Email]=@Email
				, [Description]=@Description
				, [IDNumber]=@IDNumber
				, [Password]=@Password
				, [LoginErrorCount]=@LoginErrorCount
				, [LastLoginTime]=@LastLoginTime
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pSex = new SqlParameter("Sex", Convert2DBnull(obj.Sex));
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            SqlParameter pPosition = new SqlParameter("Position", Convert2DBnull(obj.Position));
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", Convert2DBnull(obj.IDNumber));
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            SqlParameter pPassword = new SqlParameter("Password", Convert2DBnull(obj.Password));
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", Convert2DBnull(obj.LoginErrorCount));
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", Convert2DBnull(obj.LastLoginTime));
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

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

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateUserByUserCode(User obj)
        {
            string sql = @"UPDATE [BE_User] SET [UserID]=@UserID
				, [UserName]=@UserName
				, [DepartmentID]=@DepartmentID
				, [Sex]=@Sex
				, [Position]=@Position
				, [Email]=@Email
				, [Mobile]=@Mobile
				, [Description]=@Description
				, [IDNumber]=@IDNumber
				, [Password]=@Password
				, [LoginErrorCount]=@LoginErrorCount
				, [LastLoginTime]=@LastLoginTime
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pSex = new SqlParameter("Sex", Convert2DBnull(obj.Sex));
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            SqlParameter pPosition = new SqlParameter("Position", Convert2DBnull(obj.Position));
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", Convert2DBnull(obj.IDNumber));
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            SqlParameter pPassword = new SqlParameter("Password", Convert2DBnull(obj.Password));
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", Convert2DBnull(obj.LoginErrorCount));
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", Convert2DBnull(obj.LastLoginTime));
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

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

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateUserByUserID(User obj)
        {
            string sql = @"UPDATE [BE_User] SET [UserCode]=@UserCode
				, [UserName]=@UserName
				, [DepartmentID]=@DepartmentID
				, [Sex]=@Sex
				, [Position]=@Position
				, [Email]=@Email
				, [Mobile]=@Mobile
				, [Description]=@Description
				, [IDNumber]=@IDNumber
				, [Password]=@Password
				, [LoginErrorCount]=@LoginErrorCount
				, [LastLoginTime]=@LastLoginTime
				, [IsDisabled]=@IsDisabled
				, [IsLocked]=@IsLocked
				, [IsSystem]=@IsSystem
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", Convert2DBnull(obj.DepartmentID));
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            SqlParameter pSex = new SqlParameter("Sex", Convert2DBnull(obj.Sex));
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            SqlParameter pPosition = new SqlParameter("Position", Convert2DBnull(obj.Position));
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            SqlParameter pEmail = new SqlParameter("Email", Convert2DBnull(obj.Email));
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            SqlParameter pDescription = new SqlParameter("Description", Convert2DBnull(obj.Description));
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", Convert2DBnull(obj.IDNumber));
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            SqlParameter pPassword = new SqlParameter("Password", Convert2DBnull(obj.Password));
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", Convert2DBnull(obj.LoginErrorCount));
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", Convert2DBnull(obj.LastLoginTime));
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

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

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserByMobile(string mobile)
        {
            string sql = @"DELETE [BE_User] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserByUserCode(string userCode)
        {
            string sql = @"DELETE [BE_User] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUserByUserID(Guid userID)
        {
            string sql = @"DELETE [BE_User] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadUserByMobile(User obj)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_User] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["UserID"]))
                        obj.UserID = (Guid)dr["UserID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        obj.DepartmentID = (Guid)dr["DepartmentID"];
                    obj.Sex = dr["Sex"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Description = dr["Description"].ToString();
                    obj.IDNumber = dr["IDNumber"].ToString();
                    obj.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        obj.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        obj.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public int LoadUserByUserCode(User obj)
        {
            string sql = @"SELECT [UserID]
                , [CompanyID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_User] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["UserID"]))
                        obj.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["CompanyID"]))
                        obj.CompanyID = (Guid)dr["CompanyID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        obj.DepartmentID = (Guid)dr["DepartmentID"];
                    obj.Sex = dr["Sex"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Description = dr["Description"].ToString();
                    obj.IDNumber = dr["IDNumber"].ToString();
                    obj.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        obj.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        obj.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public int LoadUserByUserID(User obj)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_User] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["UserID"]))
                        obj.UserID = (Guid)dr["UserID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        obj.DepartmentID = (Guid)dr["DepartmentID"];
                    obj.Sex = dr["Sex"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Description = dr["Description"].ToString();
                    obj.IDNumber = dr["IDNumber"].ToString();
                    obj.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        obj.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        obj.LastLoginTime = (DateTime)dr["LastLoginTime"];
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

        #region BE_User CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountUsers()
        {
            string sql = "SELECT COUNT(*) FROM [BE_User]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByUserCode(string userCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByUserName(string userName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByDepartmentID(Guid departmentID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersBySex(string sex)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByPosition(string position)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByIDNumber(string iDNumber)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [IDNumber]=@IDNumber";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", iDNumber);
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByPassword(string password)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByIsLocked(bool isLocked)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByIsSystem(bool isSystem)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountUsersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_User] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsUsers()
        {
            string sql = "SELECT TOP 1 * FROM [BE_User]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_User] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByUserCode(string userCode)
        {
            string sql = "SELECT TOP 1 [UserCode] FROM [BE_User] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByUserName(string userName)
        {
            string sql = "SELECT TOP 1 [UserName] FROM [BE_User] WITH(NOLOCK) WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByDepartmentID(Guid departmentID)
        {
            string sql = "SELECT TOP 1 [DepartmentID] FROM [BE_User] WITH(NOLOCK) WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersBySex(string sex)
        {
            string sql = "SELECT TOP 1 [Sex] FROM [BE_User] WITH(NOLOCK) WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByPosition(string position)
        {
            string sql = "SELECT TOP 1 [Position] FROM [BE_User] WITH(NOLOCK) WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByEmail(string email)
        {
            string sql = "SELECT TOP 1 [Email] FROM [BE_User] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_User] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_User] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByIDNumber(string iDNumber)
        {
            string sql = "SELECT TOP 1 [IDNumber] FROM [BE_User] WITH(NOLOCK) WHERE [IDNumber]=@IDNumber";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", iDNumber);
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByPassword(string password)
        {
            string sql = "SELECT TOP 1 [Password] FROM [BE_User] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = "SELECT TOP 1 [LoginErrorCount] FROM [BE_User] WITH(NOLOCK) WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = "SELECT TOP 1 [LastLoginTime] FROM [BE_User] WITH(NOLOCK) WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_User] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByIsLocked(bool isLocked)
        {
            string sql = "SELECT TOP 1 [IsLocked] FROM [BE_User] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByIsSystem(bool isSystem)
        {
            string sql = "SELECT TOP 1 [IsSystem] FROM [BE_User] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_User] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_User] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_User] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsUsersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_User] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteUsers()
        {
            string sql = "DELETE FROM [BE_User]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_User] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByUserCode(string userCode)
        {
            string sql = "DELETE FROM [BE_User] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByUserName(string userName)
        {
            string sql = "DELETE FROM [BE_User] WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByDepartmentID(Guid departmentID)
        {
            string sql = "DELETE FROM [BE_User] WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersBySex(string sex)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByPosition(string position)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByEmail(string email)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByDescription(string description)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByIDNumber(string iDNumber)
        {
            string sql = "DELETE FROM [BE_User] WHERE [IDNumber]=@IDNumber";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", iDNumber);
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByPassword(string password)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = "DELETE FROM [BE_User] WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = "DELETE FROM [BE_User] WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_User] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByIsLocked(bool isLocked)
        {
            string sql = "DELETE FROM [BE_User] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByIsSystem(bool isSystem)
        {
            string sql = "DELETE FROM [BE_User] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_User] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_User] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteUsersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_User] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<User> LoadUsers()
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByUserCode(string userCode)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByUserName(string userName)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByDepartmentID(Guid departmentID)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [DepartmentID]=@DepartmentID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDepartmentID = new SqlParameter("DepartmentID", departmentID);
            pDepartmentID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDepartmentID);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersBySex(string sex)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByPosition(string position)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByEmail(string email)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByMobile(string mobile)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByDescription(string description)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByIDNumber(string iDNumber)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [IDNumber]=@IDNumber";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIDNumber = new SqlParameter("IDNumber", iDNumber);
            pIDNumber.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pIDNumber);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByPassword(string password)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByIsLocked(bool isLocked)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByIsSystem(bool isSystem)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByCreated(DateTime created)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByModified(DateTime modified)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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
        public List<User> LoadUsersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [UserID]
				, [UserCode]
				, [UserName]
				, [DepartmentID]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
				, [IDNumber]
				, [Password]
				, [LoginErrorCount]
				, [LastLoginTime]
				, [IsDisabled]
				, [IsLocked]
				, [IsSystem]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_User] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
                    if (!Convert.IsDBNull(dr["LastLoginTime"]))
                        iret.LastLoginTime = (DateTime)dr["LastLoginTime"];
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

        #region BE_User SearchObject()
        public SearchResult SearchUser(SearchUserArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[UserCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [UserID]
				                            , [UserCode]
				                            , [UserName]
				                            , [Sex]
				                            , [Position]
				                            , [Email]
				                            , [Mobile]
				                            , u.[Description]
				                            , [IDNumber]
				                            , [Password]
				                            , u.[DepartmentID]
				                            , [LoginErrorCount]
				                            , u.[IsDisabled]
				                            , [IsLocked]
                                            , [IsSystem]
				                            , u.[Created]
				                            , u.[CreatedBy]
				                            , u.[Modified]
				                            , u.[ModifiedBy]
											,d.[DepartmentCode]
											,d.[DepartmentName]																		
 				                            FROM 
												[BE_User] u with(nolock)
												LEFT JOIN [BE_Department] d with(nolock) on u.[DepartmentID] = d.[DepartmentID]
											WHERE 
												1=1");


            this.SetParameters_In(mbBuilder, cmd, "UserID", "mbIDs", args.UserIDs);
            if (args.UserCodes != null && args.UserCodes.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "UserCode", "mbUserCode", args.UserCodes[0]);
            }
            else
            {
                this.SetParameters_In(mbBuilder, cmd, "UserCode", "mbUserCodes", args.UserCodes);
            }

            if (args.UserNames != null && args.UserNames.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "UserName", "mbUserName", args.UserNames[0]);
            }
            else
            {
                this.SetParameters_In(mbBuilder, cmd, "UserName", "mbNames", args.UserNames);
            }

            if (args.IsLocked.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "u].[IsLocked", "mbIsLocked", args.IsLocked.Value.ToString());
            }
            if (args.IsSystem.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "u].[IsSystem", "mbIsSystem", args.IsSystem.Value.ToString());
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "u].[IsDisabled", "mbIsDisabled", args.IsDisabled.Value.ToString());
            }

            if (args.DepartmentID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "u].[DepartmentID", "mbDepartmentID", args.DepartmentID.Value);
            }
            if (!string.IsNullOrEmpty(args.DepartmentName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DepartmentName", "mbDepartmentName", args.DepartmentName);
            }

            if (!string.IsNullOrEmpty(args.IDNumber))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "IDNumber", "mbIDNumber", args.IDNumber);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "u].[Mobile", "mbMobile", args.Mobile);
            }

            if (args.RKeyUserIDs != null)
            {
                StringBuilder RKeyUserIDs = new StringBuilder();
                RKeyUserIDs.AppendFormat(" and u.UserID in(SELECT UserID FROM [BE_User2Role] with(nolock) Where 1=1");
                this.SetParameters_In(RKeyUserIDs, cmd, "UserID", "rkUserIDs", args.RKeyUserIDs);
                RKeyUserIDs.AppendFormat(")");
                mbBuilder.AppendFormat(RKeyUserIDs.ToString());
            }

            if (args.RKeyRoleIDs != null)
            {
                StringBuilder RKeyRoleIDs = new StringBuilder();
                RKeyRoleIDs.AppendFormat(" and UserID in (SELECT UserID FROM [BE_User2Role] with(nolock) Where 1=1");
                this.SetParameters_In(RKeyRoleIDs, cmd, "RoleID", "rkRoleIDs", args.RKeyRoleIDs);
                RKeyRoleIDs.AppendFormat(")");
                mbBuilder.AppendFormat(RKeyRoleIDs.ToString());
            }

            if (args.NotUsersByRoleID != Guid.Empty)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.AppendFormat(" and [UserID] NOT IN(SELECT DISTINCT UserID FROM  [BE_User2Role] WHERE 1=1");
                this.SetParameters_Equals(sBuilder, cmd, "RoleID", "u2rRoleID", args.NotUsersByRoleID);
                sBuilder.AppendFormat(")");
                mbBuilder.AppendFormat(sBuilder.ToString());
            }

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public List<User> LoadUsersByRoleID(Guid roleId)
        {
            string sql = @"SELECT
                                         [UserID]
                                        ,[UserCode]
                                        ,[UserName]
                                        ,[Sex]
                                        ,[Position]
                                        ,[Email]
                                        ,[Mobile]
                                        ,[Description]
                                        ,[IDNumber]
                                        ,[Password]
                                        ,[DepartmentID]
                                        ,[LoginErrorCount]
                                        ,[IsDisabled]
                                        ,[IsLocked]
                                        ,[Created]
                                        ,[CreatedBy]
                                        ,[Modified]
                                        ,[ModifiedBy]
				 FROM [BE_User] WHERE UserID in(
                SELECT DISTINCT UserID FROM [BE_User2Role] WHERE RoleID=@RoleID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleId);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<User> ret = new List<User>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    User iret = new User();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.IDNumber = dr["IDNumber"].ToString();
                    iret.Password = dr["Password"].ToString();
                    if (!Convert.IsDBNull(dr["DepartmentID"]))
                        iret.DepartmentID = (Guid)dr["DepartmentID"];
                    if (!Convert.IsDBNull(dr["LoginErrorCount"]))
                        iret.LoginErrorCount = (int)dr["LoginErrorCount"];
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
