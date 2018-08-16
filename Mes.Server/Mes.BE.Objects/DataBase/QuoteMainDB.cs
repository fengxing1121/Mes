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

        #region BE_QuoteMain InsertObject()
        public int InsertQuoteMain(QuoteMain obj)
        {
            string sql = @"INSERT INTO[BE_QuoteMain]([QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@QuoteID
				, @QuoteNo
				, @SolutionID
				, @PartnerID
				, @CustomerID
				, @ExpiryDate
				, @DiscountPercent
				, @TotalAmount
				, @DiscountAmount
				, @Remark
				, @Status
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", Convert2DBnull(obj.QuoteNo));
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", Convert2DBnull(obj.ExpiryDate));
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", Convert2DBnull(obj.DiscountPercent));
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", Convert2DBnull(obj.TotalAmount));
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", Convert2DBnull(obj.DiscountAmount));
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

        #region BE_QuoteMain UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateQuoteMainByQuoteNo(QuoteMain obj)
        {
            string sql = @"UPDATE [BE_QuoteMain] SET [QuoteID]=@QuoteID
				, [SolutionID]=@SolutionID
				, [PartnerID]=@PartnerID
				, [CustomerID]=@CustomerID
				, [ExpiryDate]=@ExpiryDate
				, [DiscountPercent]=@DiscountPercent
				, [TotalAmount]=@TotalAmount
				, [DiscountAmount]=@DiscountAmount
				, [Remark]=@Remark
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", Convert2DBnull(obj.ExpiryDate));
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", Convert2DBnull(obj.DiscountPercent));
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", Convert2DBnull(obj.TotalAmount));
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", Convert2DBnull(obj.DiscountAmount));
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", Convert2DBnull(obj.QuoteNo));
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateQuoteMainBySolutionID(QuoteMain obj)
        {
            string sql = @"UPDATE [BE_QuoteMain] SET [QuoteID]=@QuoteID
				, [QuoteNo]=@QuoteNo
				, [PartnerID]=@PartnerID
				, [CustomerID]=@CustomerID
				, [ExpiryDate]=@ExpiryDate
				, [DiscountPercent]=@DiscountPercent
				, [TotalAmount]=@TotalAmount
				, [DiscountAmount]=@DiscountAmount
				, [Remark]=@Remark
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", Convert2DBnull(obj.QuoteNo));
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", Convert2DBnull(obj.ExpiryDate));
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", Convert2DBnull(obj.DiscountPercent));
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", Convert2DBnull(obj.TotalAmount));
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", Convert2DBnull(obj.DiscountAmount));
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateQuoteMainByQuoteID(QuoteMain obj)
        {
            string sql = @"UPDATE [BE_QuoteMain] SET [QuoteNo]=@QuoteNo
				, [SolutionID]=@SolutionID
				, [PartnerID]=@PartnerID
				, [CustomerID]=@CustomerID
				, [ExpiryDate]=@ExpiryDate
				, [DiscountPercent]=@DiscountPercent
				, [TotalAmount]=@TotalAmount
				, [DiscountAmount]=@DiscountAmount
				, [Remark]=@Remark
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", Convert2DBnull(obj.QuoteNo));
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", Convert2DBnull(obj.PartnerID));
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", Convert2DBnull(obj.ExpiryDate));
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", Convert2DBnull(obj.DiscountPercent));
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", Convert2DBnull(obj.TotalAmount));
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", Convert2DBnull(obj.DiscountAmount));
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainByQuoteNo(string quoteNo)
        {
            string sql = @"DELETE [BE_QuoteMain] WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", quoteNo);
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainBySolutionID(Guid solutionID)
        {
            string sql = @"DELETE [BE_QuoteMain] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainByQuoteID(Guid quoteID)
        {
            string sql = @"DELETE [BE_QuoteMain] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadQuoteMainByQuoteNo(QuoteMain obj)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", Convert2DBnull(obj.QuoteNo));
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        obj.QuoteID = (Guid)dr["QuoteID"];
                    obj.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        obj.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        obj.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        obj.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        obj.DiscountAmount = (decimal)dr["DiscountAmount"];
                    obj.Remark = dr["Remark"].ToString();
                    obj.Status = dr["Status"].ToString();
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
        public int LoadQuoteMainBySolutionID(QuoteMain obj)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, Q.[SolutionID]
				, Q.[CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, Q.[Remark]
				, Q.[Status]
				, Q.[Created]
				, Q.[CreatedBy]
				, Q.[Modified]
				, Q.[ModifiedBy]
				, S.[PartnerID]
				,S.SolutionCode
				,R.DesignerNo
 				FROM [BE_QuoteMain] Q
				left join [BE_Solution] S on S.SolutionID=Q.SolutionID 
				left join [BE_RoomDesigner] R on R.DesignerID=S.DesignerID 
                where Q.SolutionID=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        obj.QuoteID = (Guid)dr["QuoteID"];
                    obj.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        obj.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        obj.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        obj.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        obj.DiscountAmount = (decimal)dr["DiscountAmount"];
                    obj.Remark = dr["Remark"].ToString();
                    obj.Status = dr["Status"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    obj.ModifiedBy = dr["ModifiedBy"].ToString();

                    if (!Convert.IsDBNull(dr["SolutionCode"]))
                        obj.SolutionCode = dr["SolutionCode"].ToString();
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["DesignerNo"]))
                        obj.DesignerNo = dr["DesignerNo"].ToString();
                    ret += 1;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public int LoadQuoteMainByQuoteID(QuoteMain obj)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", Convert2DBnull(obj.QuoteID));
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        obj.QuoteID = (Guid)dr["QuoteID"];
                    obj.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        obj.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        obj.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        obj.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        obj.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        obj.DiscountAmount = (decimal)dr["DiscountAmount"];
                    obj.Remark = dr["Remark"].ToString();
                    obj.Status = dr["Status"].ToString();
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

        #region BE_QuoteMain CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountQuoteMains()
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByQuoteID(Guid quoteID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByQuoteNo(string quoteNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", quoteNo);
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByCustomerID(Guid customerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByExpiryDate(DateTime expiryDate)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [ExpiryDate]=@ExpiryDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", expiryDate);
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByDiscountPercent(decimal discountPercent)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [DiscountPercent]=@DiscountPercent";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", discountPercent);
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByTotalAmount(decimal totalAmount)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [TotalAmount]=@TotalAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", totalAmount);
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByDiscountAmount(decimal discountAmount)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [DiscountAmount]=@DiscountAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", discountAmount);
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByStatus(string status)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountQuoteMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsQuoteMains()
        {
            string sql = "SELECT TOP 1 * FROM [BE_QuoteMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByQuoteID(Guid quoteID)
        {
            string sql = "SELECT TOP 1 [QuoteID] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByQuoteNo(string quoteNo)
        {
            string sql = "SELECT TOP 1 [QuoteNo] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", quoteNo);
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByPartnerID(Guid partnerID)
        {
            string sql = "SELECT TOP 1 [PartnerID] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByCustomerID(Guid customerID)
        {
            string sql = "SELECT TOP 1 [CustomerID] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByExpiryDate(DateTime expiryDate)
        {
            string sql = "SELECT TOP 1 [ExpiryDate] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [ExpiryDate]=@ExpiryDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", expiryDate);
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByDiscountPercent(decimal discountPercent)
        {
            string sql = "SELECT TOP 1 [DiscountPercent] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [DiscountPercent]=@DiscountPercent";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", discountPercent);
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByTotalAmount(decimal totalAmount)
        {
            string sql = "SELECT TOP 1 [TotalAmount] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [TotalAmount]=@TotalAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", totalAmount);
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByDiscountAmount(decimal discountAmount)
        {
            string sql = "SELECT TOP 1 [DiscountAmount] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [DiscountAmount]=@DiscountAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", discountAmount);
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByStatus(string status)
        {
            string sql = "SELECT TOP 1 [Status] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsQuoteMainsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_QuoteMain] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteQuoteMains()
        {
            string sql = "DELETE FROM [BE_QuoteMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByQuoteID(Guid quoteID)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByQuoteNo(string quoteNo)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", quoteNo);
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByPartnerID(Guid partnerID)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByCustomerID(Guid customerID)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByExpiryDate(DateTime expiryDate)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [ExpiryDate]=@ExpiryDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", expiryDate);
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByDiscountPercent(decimal discountPercent)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [DiscountPercent]=@DiscountPercent";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", discountPercent);
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByTotalAmount(decimal totalAmount)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [TotalAmount]=@TotalAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", totalAmount);
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByDiscountAmount(decimal discountAmount)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [DiscountAmount]=@DiscountAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", discountAmount);
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByStatus(string status)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteQuoteMainsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_QuoteMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<QuoteMain> LoadQuoteMains()
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByQuoteID(Guid quoteID)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [QuoteID]=@QuoteID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteID = new SqlParameter("QuoteID", quoteID);
            pQuoteID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pQuoteID);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByQuoteNo(string quoteNo)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [QuoteNo]=@QuoteNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQuoteNo = new SqlParameter("QuoteNo", quoteNo);
            pQuoteNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pQuoteNo);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByPartnerID(Guid partnerID)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [PartnerID]=@PartnerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPartnerID = new SqlParameter("PartnerID", partnerID);
            pPartnerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPartnerID);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByCustomerID(Guid customerID)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByExpiryDate(DateTime expiryDate)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [ExpiryDate]=@ExpiryDate";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pExpiryDate = new SqlParameter("ExpiryDate", expiryDate);
            pExpiryDate.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pExpiryDate);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByDiscountPercent(decimal discountPercent)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [DiscountPercent]=@DiscountPercent";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountPercent = new SqlParameter("DiscountPercent", discountPercent);
            pDiscountPercent.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountPercent);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByTotalAmount(decimal totalAmount)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [TotalAmount]=@TotalAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAmount = new SqlParameter("TotalAmount", totalAmount);
            pTotalAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAmount);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByDiscountAmount(decimal discountAmount)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [DiscountAmount]=@DiscountAmount";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDiscountAmount = new SqlParameter("DiscountAmount", discountAmount);
            pDiscountAmount.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pDiscountAmount);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByRemark(string remark)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByStatus(string status)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByCreated(DateTime created)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByModified(DateTime modified)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<QuoteMain> LoadQuoteMainsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [QuoteID]
				, [QuoteNo]
				, [SolutionID]
				, [PartnerID]
				, [CustomerID]
				, [ExpiryDate]
				, [DiscountPercent]
				, [TotalAmount]
				, [DiscountAmount]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_QuoteMain] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<QuoteMain> ret = new List<QuoteMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    QuoteMain iret = new QuoteMain();
                    if (!Convert.IsDBNull(dr["QuoteID"]))
                        iret.QuoteID = (Guid)dr["QuoteID"];
                    iret.QuoteNo = dr["QuoteNo"].ToString();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["PartnerID"]))
                        iret.PartnerID = (Guid)dr["PartnerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["ExpiryDate"]))
                        iret.ExpiryDate = (DateTime)dr["ExpiryDate"];
                    if (!Convert.IsDBNull(dr["DiscountPercent"]))
                        iret.DiscountPercent = (decimal)dr["DiscountPercent"];
                    if (!Convert.IsDBNull(dr["TotalAmount"]))
                        iret.TotalAmount = (decimal)dr["TotalAmount"];
                    if (!Convert.IsDBNull(dr["DiscountAmount"]))
                        iret.DiscountAmount = (decimal)dr["DiscountAmount"];
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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

        #region BE_QuoteMain SearchObject()
        public SearchResult SearchQuote(SearchQuoteMainArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[QuoteNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_QuoteMain].[QuoteID]
                                          ,[QuoteNo]
                                          ,[BE_QuoteMain].[SolutionID]
                                          ,[BE_QuoteMain].[CustomerID]
                                          ,[BE_QuoteMain].[PartnerID]
                                          ,[ExpiryDate]
                                          ,[DiscountPercent]
                                          ,[TotalAmount]
                                          ,[DiscountAmount]
										  ,[DebitAmount] = isnull([Debit],0)  
                                          ,[BE_QuoteMain].[Remark]
                                          ,[BE_QuoteMain].[Status]
                                          ,[BE_QuoteMain].[Created]
                                          ,[BE_QuoteMain].[CreatedBy]
                                          ,[BE_QuoteMain].[Modified]
                                          ,[BE_QuoteMain].[ModifiedBy]
	                                      ,[CustomerName]
	                                      ,[BE_Customer].[LinkMan]
	                                      ,[BE_Customer].[Address]
	                                      ,[BE_Customer].[Tel]
	                                      ,[BE_Customer].[Mobile]
	                                      ,[BE_Solution].[SolutionCode]
	                                      ,[BE_Solution].[SolutionName]
                                      FROM 
	                                      [BE_QuoteMain] with(nolock)
	                                      LEFT JOIN [BE_Customer] with(nolock) on [BE_QuoteMain].[CustomerID] = [BE_Customer].[CustomerID]
	                                      LEFT JOIN [BE_Solution] with(nolock) on [BE_Solution].[SolutionID] = [BE_QuoteMain].[SolutionID] 
										  LEFT JOIN 
										  (
											 select
													QuoteID,
													Sum(Amount) as Debit
												from 
													BE_CustomerTransDetail
												group by
													QuoteID
										  ) as trans on trans.QuoteID = [BE_QuoteMain].[QuoteID]
                                   WHERE 1=1");

            if (args.QuoteID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[QuoteID", "mbQuoteID", args.QuoteID);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[PartnerID", "mbPartnerID", args.PartnerID);
            }
            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[SolutionID", "mbSolutionID", args.SolutionID);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[CustomerID", "mbCustomerID", args.CustomerID);
            }
            if (!string.IsNullOrEmpty(args.QuoteNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "QuoteNo", "mbQuoteNo", args.QuoteNo);
            }
            if (!string.IsNullOrEmpty(args.Status))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_QuoteMain].[Status", "mbStatus", args.Status);
            }
            if (!string.IsNullOrEmpty(args.SolutionCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionCode", "mbSolutionCode", args.SolutionCode);
            }
            if (!string.IsNullOrEmpty(args.SolutionName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "SolutionName", "mbSolutionName", args.SolutionName);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
