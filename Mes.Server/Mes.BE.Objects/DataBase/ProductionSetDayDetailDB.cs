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
        #region BE_ProductionSetDayDetail InsertObject()
        public int InsertProductionSetDayDetail(ProductionSetDayDetail obj)
        {
            string sql = @"Insert Into [BE_ProductionSetDayDetail](
                              [ID]
                             ,[SetID]
                             ,[Datetime]
                             ,[TotalAreal]
                             ,[MadeTotalAreal]
                             ,[WeekNo]
            )Values (
                              @ID
                             ,@SetID
                             ,@Datetime
                             ,@TotalAreal
                             ,@MadeTotalAreal
                             ,@WeekNo
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            SqlParameter pDatetime = new SqlParameter("Datetime", Convert2DBnull(obj.Datetime));
            pDatetime.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pDatetime);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", Convert2DBnull(obj.MadeTotalAreal));
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            SqlParameter pWeekNo = new SqlParameter("WeekNo", Convert2DBnull(obj.WeekNo));
            pWeekNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWeekNo);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionSetDayDetail UpdateObject()、DeleteObject()
        public int UpdateProductionSetDayDetailByID(ProductionSetDayDetail obj)
        {
            string sql = @"Update [BE_ProductionSetDayDetail] Set
                              [SetID]=@SetID
                             ,[Datetime]=@Datetime
                             ,[TotalAreal]=@TotalAreal
                             ,[MadeTotalAreal]=@MadeTotalAreal
                             ,[WeekNo]=@WeekNo
                          Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            SqlParameter pDatetime = new SqlParameter("Datetime", Convert2DBnull(obj.Datetime));
            pDatetime.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pDatetime);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", Convert2DBnull(obj.MadeTotalAreal));
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            SqlParameter pWeekNo = new SqlParameter("WeekNo", Convert2DBnull(obj.WeekNo));
            pWeekNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWeekNo);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductionSetDayDetailByID(Guid ID)
        {
            string sql = @"Delete [BE_ProductionSetDayDetail]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionSetDayDetail LoadObject()
        public List<ProductionSetDayDetail> LoadProductionSetDayDetails()
        {
            string sql = @"Select 
                              [ID]
                             ,[SetID]
                             ,[Datetime]
                             ,[TotalAreal]
                             ,[MadeTotalAreal]
                             ,[WeekNo]
                       From [BE_ProductionSetDayDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductionSetDayDetail> ret = new List<ProductionSetDayDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSetDayDetail iret = new ProductionSetDayDetail();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        iret.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Datetime"]))
                        iret.Datetime = (DateTime)dr["Datetime"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        iret.WeekNo = (int)dr["WeekNo"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ProductionSetDayDetail> LoadProductionSetDayDetailByID(ProductionSetDayDetail obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[SetID]
                             ,[Datetime]
                             ,[TotalAreal]
                             ,[MadeTotalAreal]
                             ,[WeekNo]
                       From [BE_ProductionSetDayDetail] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            List<ProductionSetDayDetail> ret = new List<ProductionSetDayDetail>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSetDayDetail iret = new ProductionSetDayDetail();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        iret.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Datetime"]))
                        iret.Datetime = (DateTime)dr["Datetime"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        iret.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        iret.WeekNo = (int)dr["WeekNo"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadProductionSetDayDetailByMadeTotalAreal(ProductionSetDayDetail obj)
        {
            string sql = @"Select top 1
                              [ID]
                             ,[SetID]
                             ,[Datetime]
                             ,[TotalAreal]
                             ,[MadeTotalAreal]
                             ,[WeekNo]
                       From [BE_ProductionSetDayDetail] With(NoLock) where ([TotalAreal]-[MadeTotalAreal])>=@MadeTotalAreal order by [Datetime]";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMadeTotalAreal = new SqlParameter("MadeTotalAreal", Convert2DBnull(obj.MadeTotalAreal));
            pMadeTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pMadeTotalAreal);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSetDayDetail iret = new ProductionSetDayDetail();
                    if (!Convert.IsDBNull(dr["ID"]))
                        obj.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        obj.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Datetime"]))
                        obj.Datetime = (DateTime)dr["Datetime"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        obj.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        obj.WeekNo = (int)dr["WeekNo"];
                    ret++;
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadProductionSetDayDetail(ProductionSetDayDetail obj)
        {
            string sql = @"Select 
                              [ID]
                             ,[SetID]
                             ,[Datetime]
                             ,[TotalAreal]
                             ,[MadeTotalAreal]
                             ,[WeekNo]
                       From [BE_ProductionSetDayDetail] With(NoLock) Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ID"]))
                        obj.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["SetID"]))
                        obj.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Datetime"]))
                        obj.Datetime = (DateTime)dr["Datetime"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["MadeTotalAreal"]))
                        obj.MadeTotalAreal = (decimal)dr["MadeTotalAreal"];
                    if (!Convert.IsDBNull(dr["WeekNo"]))
                        obj.WeekNo = (int)dr["WeekNo"];
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

        #region BE_ProductionSetDayDetail CountObjects()、ExistsObjects()
        public int CountProductionSetDayDetail()
        {
            string sql = @"Select Count(*) From [BE_ProductionSetDayDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductionSetDayDetailByID(Guid ID)
        {
            string sql = @"Select Count(*) From [BE_ProductionSetDayDetail]  Where ID=@ID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductionSetDayDetail()
        {
            string sql = @"Select Top 1 * From [BE_ProductionSetDayDetail] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region BE_ProductionSetDayDetail SearchObject()

        public SearchResult SearchProductionSetDayDetail(SearchProductionSetDayDetailArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WeekNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_ProductionSetDayDetail].[ID]
                                          ,[BE_ProductionSetDayDetail].[SetID]
                                          ,[BE_ProductionSetDayDetail].[Datetime]
                                          ,[BE_ProductionSetDayDetail].[TotalAreal]
                                          ,[BE_ProductionSetDayDetail].[MadeTotalAreal]
                                          ,[BE_ProductionSetDayDetail].[WeekNo]
	                                      ,[BE_ProductionSetWeekDetail].[WeekNo] AS WeekDetailWeekNo
                                          ,[BE_ProductionSetWeekDetail].[MaxCapacity] AS WeekDetailMaxCapacity
                                          ,[BE_ProductionSetWeekDetail].[TotalAreal] AS WeekDetailTotalAreal
                                      FROM [dbo].[BE_ProductionSetDayDetail] 
                                      LEFT JOIN [dbo].[BE_ProductionSetWeekDetail]
                                      ON [BE_ProductionSetDayDetail].[SetID]=[BE_ProductionSetWeekDetail].[SetID] AND [BE_ProductionSetDayDetail].[WeekNo]=[BE_ProductionSetWeekDetail].[WeekNo]
                                    WHERE 1=1");

            this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductionSetDayDetail].[SetID", "mbSetID", args.SetID);

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public bool ExistsProductionSetDayDetailByDatetime(DateTime Started, DateTime Ended)
        {
            string sql = @"select* from [dbo].[BE_ProductionSetDayDetail] where [Datetime] BETWEEN @Started AND @Ended";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(Started));
            pStarted.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(Ended));
            pEnded.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pEnded);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion
    }
}

