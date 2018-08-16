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

        #region BE_PartnerUser InsertObject()
        public int InsertPartnerUser(PartnerUser obj)
        {
            string sql = @"INSERT INTO[BE_PartnerUser]([UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
                , [IsFinishInfo]
                 ,[EndDate]
                ,[MemberClass]
				) VALUES(@UserID
				, @PartnerID
				, @UserCode
				, @UserName
				, @Sex
				, @Position
				, @Email
				, @Mobile
				, @Description
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
                , @IsFinishInfo
                ,@EndDate
                ,@MemberClass
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

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

            SqlParameter pIsFinishInfo = new SqlParameter("IsFinishInfo", Convert2DBnull(obj.IsFinishInfo));
            pIsFinishInfo.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsFinishInfo);

            SqlParameter pEndDate = new SqlParameter("EndDate", Convert2DBnull(obj.EndDate));
            pEndDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEndDate);

            SqlParameter pMemberClass = new SqlParameter("MemberClass", Convert2DBnull(obj.MemberClass));
            pMemberClass.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMemberClass);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_PartnerUser UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePartnerUserByMobile(PartnerUser obj)
        {
            string sql = @"UPDATE [BE_PartnerUser] SET [UserID]=@UserID
				, [PartnerID]=@PartnerID
				, [UserCode]=@UserCode
				, [UserName]=@UserName
				, [Sex]=@Sex
				, [Position]=@Position
				, [Email]=@Email
				, [Description]=@Description
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

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

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
        public int UpdatePartnerUserByUserCode(PartnerUser obj)
        {
            string sql = @"UPDATE [BE_PartnerUser] SET [UserID]=@UserID
				, [PartnerID]=@PartnerID
				, [UserName]=@UserName
				, [Sex]=@Sex
				, [Position]=@Position
				, [Email]=@Email
				, [Mobile]=@Mobile
				, [Description]=@Description
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

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

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
        public int UpdatePartnerUserByUserID(PartnerUser obj)
        {
            string sql = @"UPDATE [BE_PartnerUser] SET [PartnerID]=@PartnerID
				, [UserCode]=@UserCode
				, [UserName]=@UserName
				, [Sex]=@Sex
				, [Position]=@Position
				, [Email]=@Email
				, [Mobile]=@Mobile
				, [Description]=@Description
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
                , [IsAxamine]=@IsAxamine
                , [IsFinishInfo]=@IsFinishInfo
                , [EndDate]=@EndDate
                , [MemberClass]=@MemberClass
 				WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pUserCode = new SqlParameter("UserCode", Convert2DBnull(obj.UserCode));
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            SqlParameter pUserName = new SqlParameter("UserName", Convert2DBnull(obj.UserName));
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

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

            SqlParameter pIsAxamine = new SqlParameter("IsAxamine", obj.IsAxamine);
            pIsAxamine.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsAxamine);

            SqlParameter pIsFinishInfo = new SqlParameter("IsFinishInfo", obj.IsFinishInfo);
            pIsFinishInfo.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsFinishInfo);

            SqlParameter pEndDate = new SqlParameter("EndDate", Convert2DBnull(obj.EndDate));
            pEndDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEndDate);

            SqlParameter pMemberClass = new SqlParameter("MemberClass", Convert2DBnull(obj.MemberClass));
            pMemberClass.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pMemberClass);

            return cmd.ExecuteNonQuery();
        }

        public int UpdatePartnerUserDisabled(Guid UserID)
        {
            string sql = @"UPDATE [BE_PartnerUser] SET [IsDisabled]=1
 				WHERE [UserID]=@UserID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdatePartnerUserIsFinishInfoByUserID(PartnerUser obj)
        {
            string sql = @"UPDATE [BE_PartnerUser] SET [IsFinishInfo]=@IsFinishInfo
 				WHERE [UserID]=@UserID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsFinishInfo = new SqlParameter("IsFinishInfo", Convert2DBnull(obj.IsFinishInfo));
            pIsFinishInfo.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsFinishInfo);

            SqlParameter pUserID = new SqlParameter("UserID", Convert2DBnull(obj.UserID));
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserByMobile(string mobile)
        {
            string sql = @"DELETE [BE_PartnerUser] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserByUserCode(string userCode)
        {
            string sql = @"DELETE [BE_PartnerUser] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUserByUserID(Guid userID)
        {
            string sql = @"DELETE [BE_PartnerUser] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPartnerUserByMobile(PartnerUser obj)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
 				FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
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
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    obj.Sex = dr["Sex"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Description = dr["Description"].ToString();
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
        public int LoadPartnerUserByUserCode(PartnerUser obj)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
                , [IsFinishInfo]
                , [IsAxamine]
                 ,[EndDate]
                 ,[MemberClass]
 				FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
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
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    obj.Sex = dr["Sex"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Description = dr["Description"].ToString();
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
                    if (!Convert.IsDBNull(dr["IsFinishInfo"]))
                        obj.IsFinishInfo = (bool)dr["IsFinishInfo"];
                    if (!Convert.IsDBNull(dr["IsAxamine"]))
                        obj.IsAxamine = (bool)dr["IsAxamine"];
                    if (!Convert.IsDBNull(dr["EndDate"]))
                        obj.EndDate = (DateTime)dr["EndDate"];
                    if (!Convert.IsDBNull(dr["MemberClass"]))
                        obj.MemberClass = (int)dr["MemberClass"];
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        /// <summary>
        /// 查询数据，请务必保留IsAxamine字段
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
		public int LoadPartnerUserByUserID(PartnerUser obj)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
 				, [IsFinishInfo]
                , [IsAxamine]
                , [EndDate]
                ,[MemberClass]
                FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserID]=@UserID";
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
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    obj.UserCode = dr["UserCode"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    obj.Sex = dr["Sex"].ToString();
                    obj.Position = dr["Position"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
                    obj.Description = dr["Description"].ToString();
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
                    if (!Convert.IsDBNull(dr["IsFinishInfo"]))
                        obj.IsFinishInfo = (bool)dr["IsFinishInfo"];
                    if (!Convert.IsDBNull(dr["IsAxamine"]))
                        obj.IsAxamine = (bool)dr["IsAxamine"];
                    if (!Convert.IsDBNull(dr["EndDate"]))
                        obj.EndDate = (DateTime)dr["EndDate"];
                    obj.MemberClass = (int)dr["MemberClass"];
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

        #region BE_PartnerUser CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPartnerUsers()
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByUserID(Guid userID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByUserCode(string userCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByUserName(string userName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersBySex(string sex)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByPosition(string position)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByDescription(string description)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByPassword(string password)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByIsLocked(bool isLocked)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByIsSystem(bool isSystem)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPartnerUsersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPartnerUsers()
        {
            string sql = "SELECT TOP 1 * FROM [BE_PartnerUser]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByUserID(Guid userID)
        {
            string sql = "SELECT TOP 1 [UserID] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByUserCode(string userCode)
        {
            string sql = "SELECT TOP 1 [UserCode] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByUserName(string userName)
        {
            string sql = "SELECT TOP 1 [UserName] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersBySex(string sex)
        {
            string sql = "SELECT TOP 1 [Sex] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByPosition(string position)
        {
            string sql = "SELECT TOP 1 [Position] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByEmail(string email)
        {
            string sql = "SELECT TOP 1 [Email] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByDescription(string description)
        {
            string sql = "SELECT TOP 1 [Description] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByPassword(string password)
        {
            string sql = "SELECT TOP 1 [Password] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = "SELECT TOP 1 [LoginErrorCount] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = "SELECT TOP 1 [LastLoginTime] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByIsDisabled(bool isDisabled)
        {
            string sql = "SELECT TOP 1 [IsDisabled] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByIsLocked(bool isLocked)
        {
            string sql = "SELECT TOP 1 [IsLocked] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByIsSystem(bool isSystem)
        {
            string sql = "SELECT TOP 1 [IsSystem] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPartnerUsersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_PartnerUser] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePartnerUsers()
        {
            string sql = "DELETE FROM [BE_PartnerUser]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByUserID(Guid userID)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByUserCode(string userCode)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByUserName(string userName)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersBySex(string sex)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByPosition(string position)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByEmail(string email)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByDescription(string description)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByPassword(string password)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByIsDisabled(bool isDisabled)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByIsLocked(bool isLocked)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByIsSystem(bool isSystem)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePartnerUsersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_PartnerUser] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<PartnerUser> LoadPartnerUsers()
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
                ,[EndDate]
				 FROM [BE_PartnerUser]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
                    if (!Convert.IsDBNull(dr["EndDate"]))
                        iret.EndDate = (DateTime)dr["EndDate"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<PartnerUser> LoadPartnerUsersByUserID(Guid userID)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [UserID]=@UserID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserID = new SqlParameter("UserID", userID);
            pUserID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pUserID);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByUserCode(string userCode)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [UserCode]=@UserCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserCode = new SqlParameter("UserCode", userCode);
            pUserCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserCode);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByUserName(string userName)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUserName = new SqlParameter("UserName", userName);
            pUserName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUserName);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersBySex(string sex)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Sex]=@Sex";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSex = new SqlParameter("Sex", sex);
            pSex.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSex);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByPosition(string position)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Position]=@Position";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPosition = new SqlParameter("Position", position);
            pPosition.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPosition);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByEmail(string email)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Email]=@Email";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEmail = new SqlParameter("Email", email);
            pEmail.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pEmail);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByMobile(string mobile)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByDescription(string description)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Description]=@Description";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDescription = new SqlParameter("Description", description);
            pDescription.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDescription);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByPassword(string password)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Password]=@Password";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPassword = new SqlParameter("Password", password);
            pPassword.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPassword);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByLoginErrorCount(int loginErrorCount)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [LoginErrorCount]=@LoginErrorCount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLoginErrorCount = new SqlParameter("LoginErrorCount", loginErrorCount);
            pLoginErrorCount.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pLoginErrorCount);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByLastLoginTime(DateTime lastLoginTime)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [LastLoginTime]=@LastLoginTime";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLastLoginTime = new SqlParameter("LastLoginTime", lastLoginTime);
            pLastLoginTime.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pLastLoginTime);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByIsDisabled(bool isDisabled)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [IsDisabled]=@IsDisabled";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsDisabled = new SqlParameter("IsDisabled", isDisabled);
            pIsDisabled.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsDisabled);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByIsLocked(bool isLocked)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [IsLocked]=@IsLocked";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsLocked = new SqlParameter("IsLocked", isLocked);
            pIsLocked.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsLocked);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByIsSystem(bool isSystem)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [IsSystem]=@IsSystem";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pIsSystem = new SqlParameter("IsSystem", isSystem);
            pIsSystem.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pIsSystem);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByCreated(DateTime created)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByModified(DateTime modified)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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
        public List<PartnerUser> LoadPartnerUsersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [UserID]
				, [PartnerID]
				, [UserCode]
				, [UserName]
				, [Sex]
				, [Position]
				, [Email]
				, [Mobile]
				, [Description]
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
				 FROM [BE_PartnerUser] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
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

        #region BE_PartnerUser SearchObject()
        public SearchResult SearchPartnerUser(SearchPartnerUserArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Created] DESC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [UserID]
                                          ,[BE_PartnerUser].[PartnerID]
                                          ,[BE_PartnerUser].[CompanyID]
                                          ,[UserCode]
                                          ,[UserName]
                                          ,[Sex]
                                          ,[Position]
                                          ,[BE_PartnerUser].[Email]
                                          ,[BE_PartnerUser].[Mobile]
                                          ,[Description]
                                          ,[Password]
                                          ,[LoginErrorCount]
                                          ,[LastLoginTime]
                                          ,[IsDisabled]
                                          ,[IsLocked]
                                          ,[IsSystem]
                                          ,[BE_PartnerUser].[Created]
                                          ,[BE_PartnerUser].[CreatedBy]
                                          ,[BE_PartnerUser].[Modified]
                                          ,[BE_PartnerUser].[ModifiedBy]
                                          ,[IsFinishInfo]
                                          ,[IsAxamine]
                                          ,[EndDate]
                                          ,[MemberClass]
	                                      ,[BE_Partner].PartnerName
                                      FROM [dbo].[BE_PartnerUser] AS [BE_PartnerUser] 
                                      LEFT JOIN [dbo].[BE_Partner] AS [BE_Partner]
                                      ON [BE_PartnerUser].PartnerID=[BE_Partner].PartnerID WHERE 1=1 ");


            this.SetParameters_In(mbBuilder, cmd, "UserID", "mbIDs", args.UserIDs);
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerUser].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }
            if (args.UserCodes != null && args.UserCodes.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "UserCode", "mbUserCode", args.UserCodes[0]);
            }
            //else
            //{
            //    this.SetParameters_In(mbBuilder, cmd, "UserCode", "mbUserCodes", args.UserCodes);
            //}

            if (args.UserNames != null && args.UserNames.Count == 1)
            {
                this.SetParameters_Contains(mbBuilder, cmd, "UserName", "mbUserName", args.UserNames[0]);
            }
            //else
            //{
            //    this.SetParameters_In(mbBuilder, cmd, "UserName", "mbNames", args.UserNames);
            //}
            if (args.IsLocked.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerUser][IsLocked", "mbIsLocked", args.IsLocked.Value.ToString());
            }
            if (!string.IsNullOrEmpty(args.EndDate))
            {
                mbBuilder.AppendFormat(string.Format(@" and [BE_PartnerUser].[EndDate]{0}getdate() ", args.EndDate == "1" ? ">" : "<="));
            }
            //if (args.IsSystem.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "u].[IsSystem", "mbIsSystem", args.IsSystem.Value.ToString());
            //}
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerUser].[IsDisabled", "mbIsDisabled", args.IsDisabled.Value.ToString());
            }
            if (args.MemberClass.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_PartnerUser].[MemberClass", "mbMemberClass", args.MemberClass.Value.ToString());
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_PartnerUser].[Mobile", "mbMobile", args.Mobile);
            }

            if (args.RKeyUserIDs != null)
            {
                StringBuilder RKeyUserIDs = new StringBuilder();
                RKeyUserIDs.AppendFormat(" and u.UserID in(SELECT UserID FROM [BE_PartnerUser2Role] with(nolock) Where 1=1");
                this.SetParameters_In(RKeyUserIDs, cmd, "UserID", "rkUserIDs", args.RKeyUserIDs);
                RKeyUserIDs.AppendFormat(")");
                mbBuilder.AppendFormat(RKeyUserIDs.ToString());
            }

            if (args.RKeyRoleIDs != null)
            {
                StringBuilder RKeyRoleIDs = new StringBuilder();
                RKeyRoleIDs.AppendFormat(" and UserID in (SELECT UserID FROM [BE_PartnerUser2Role] with(nolock) Where 1=1");
                this.SetParameters_In(RKeyRoleIDs, cmd, "RoleID", "rkRoleIDs", args.RKeyRoleIDs);
                RKeyRoleIDs.AppendFormat(")");
                mbBuilder.AppendFormat(RKeyRoleIDs.ToString());
            }

            if (args.NotUsersByRoleID != Guid.Empty)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.AppendFormat(" and [UserID] NOT IN(SELECT DISTINCT UserID FROM  [BE_PartnerUser2Role] WHERE 1=1");
                this.SetParameters_Equals(sBuilder, cmd, "RoleID", "u2rRoleID", args.NotUsersByRoleID);
                sBuilder.AppendFormat(")");
                mbBuilder.AppendFormat(sBuilder.ToString());
            }

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        public List<PartnerUser> LoadPartnerUsersByRoleID(Guid roleId)
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
                                        ,[Password]                                      
                                        ,[LoginErrorCount]
                                        ,[IsDisabled]
                                        ,[IsLocked]
                                        ,[Created]
                                        ,[CreatedBy]
                                        ,[Modified]
                                        ,[ModifiedBy]
				 FROM [BE_PartnerUser] WHERE UserID in(
                SELECT DISTINCT UserID FROM [BE_PartnerUser2Role] WHERE RoleID=@RoleID)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoleID = new SqlParameter("RoleID", roleId);
            pRoleID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pRoleID);

            List<PartnerUser> ret = new List<PartnerUser>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    PartnerUser iret = new PartnerUser();
                    if (!Convert.IsDBNull(dr["UserID"]))
                        iret.UserID = (Guid)dr["UserID"];
                    iret.UserCode = dr["UserCode"].ToString();
                    iret.UserName = dr["UserName"].ToString();
                    iret.Sex = dr["Sex"].ToString();
                    iret.Position = dr["Position"].ToString();
                    iret.Email = dr["Email"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
                    iret.Description = dr["Description"].ToString();
                    iret.Password = dr["Password"].ToString();
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
