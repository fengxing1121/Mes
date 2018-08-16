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
        #region BE_ProductionSet InsertObject()
        public int InsertProductionSet(ProductionSet obj)
        {
            string sql = @"Insert Into [BE_ProductionSet](
                              [SetID]
                             ,[Started]
                             ,[Ended]
                             ,[Weeks]
                             ,[Days]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                              @SetID
                             ,@Started
                             ,@Ended
                             ,@Weeks
                             ,@Days
                             ,@TotalAreal
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pWeeks = new SqlParameter("Weeks", Convert2DBnull(obj.Weeks));
            pWeeks.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWeeks);

            SqlParameter pDays = new SqlParameter("Days", Convert2DBnull(obj.Days));
            pDays.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDays);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionSet UpdateObject()、DeleteObject()
        public int UpdateProductionSetBySetID(ProductionSet obj)
        {
            string sql = @"Update [BE_ProductionSet] Set
                              [Started]=@Started
                             ,[Ended]=@Ended
                             ,[Weeks]=@Weeks
                             ,[Days]=@Days
                             ,[TotalAreal]=@TotalAreal
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where SetID=@SetID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            SqlParameter pStarted = new SqlParameter("Started", Convert2DBnull(obj.Started));
            pStarted.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pStarted);

            SqlParameter pEnded = new SqlParameter("Ended", Convert2DBnull(obj.Ended));
            pEnded.SqlDbType = SqlDbType.SmallDateTime;
            cmd.Parameters.Add(pEnded);

            SqlParameter pWeeks = new SqlParameter("Weeks", Convert2DBnull(obj.Weeks));
            pWeeks.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pWeeks);

            SqlParameter pDays = new SqlParameter("Days", Convert2DBnull(obj.Days));
            pDays.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDays);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductionSetBySetID(Guid SetID)
        {
            string sql = @"Delete [BE_ProductionSet]  Where SetID=@SetID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_ProductionSet LoadObject()
        public List<ProductionSet> LoadProductionSets()
        {
            string sql = @"Select 
                              [SetID]
                             ,[Started]
                             ,[Ended]
                             ,[Weeks]
                             ,[Days]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionSet] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<ProductionSet> ret = new List<ProductionSet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSet iret = new ProductionSet();
                    if (!Convert.IsDBNull(dr["SetID"]))
                        iret.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    if (!Convert.IsDBNull(dr["Weeks"]))
                        iret.Weeks = (int)dr["Weeks"];
                    if (!Convert.IsDBNull(dr["Days"]))
                        iret.Days = (int)dr["Days"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public List<ProductionSet> LoadProductionSetBySetID(ProductionSet obj)
        {
            string sql = @"Select 
                              [SetID]
                             ,[Started]
                             ,[Ended]
                             ,[Weeks]
                             ,[Days]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionSet] With(NoLock) Where SetID=@SetID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            List<ProductionSet> ret = new List<ProductionSet>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ProductionSet iret = new ProductionSet();
                    if (!Convert.IsDBNull(dr["SetID"]))
                        iret.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Started"]))
                        iret.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        iret.Ended = (DateTime)dr["Ended"];
                    if (!Convert.IsDBNull(dr["Weeks"]))
                        iret.Weeks = (int)dr["Weeks"];
                    if (!Convert.IsDBNull(dr["Days"]))
                        iret.Days = (int)dr["Days"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        iret.CreatedBy = (string)dr["CreatedBy"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }

        public int LoadProductionSet(ProductionSet obj)
        {
            string sql = @"Select 
                              [SetID]
                             ,[Started]
                             ,[Ended]
                             ,[Weeks]
                             ,[Days]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionSet] With(NoLock) Where SetID=@SetID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(obj.SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SetID"]))
                        obj.SetID = (Guid)dr["SetID"];
                    if (!Convert.IsDBNull(dr["Started"]))
                        obj.Started = (DateTime)dr["Started"];
                    if (!Convert.IsDBNull(dr["Ended"]))
                        obj.Ended = (DateTime)dr["Ended"];
                    if (!Convert.IsDBNull(dr["Weeks"]))
                        obj.Weeks = (int)dr["Weeks"];
                    if (!Convert.IsDBNull(dr["Days"]))
                        obj.Days = (int)dr["Days"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (decimal)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["CreatedBy"]))
                        obj.CreatedBy = (string)dr["CreatedBy"];
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

        #region BE_ProductionSet CountObjects()、ExistsObjects()
        public int CountProductionSet()
        {
            string sql = @"Select Count(*) From [BE_ProductionSet] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountProductionSetBySetID(Guid SetID)
        {
            string sql = @"Select Count(*) From [BE_ProductionSet]  Where SetID=@SetID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsProductionSet()
        {
            string sql = @"Select Top 1 * From [BE_ProductionSet] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsProductionSetBySetID(Guid SetID)
        {
            string sql = @"Select Top 1 * From [BE_ProductionSet]  Where SetID=@SetID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSetID = new SqlParameter("SetID", Convert2DBnull(SetID));
            pSetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region BE_ProductionSet SearchObject()
        public SearchResult SearchProductionSet(SearchProductionSetArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[SetID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              [SetID]
                             ,[Started]
                             ,[Ended]
                             ,[Weeks]
                             ,[Days]
                             ,[TotalAreal]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_ProductionSet] With(NoLock) Where 1=1 ");

            //this.SetParameters_In(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);

            //if (args.ProduceOrderID.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);
            //}
            //if (!string.IsNullOrEmpty(args.OrderNo))
            //{
            //    this.SetParameters_Contains(mbBuilder, cmd, "BE_ProduceOrder].[ProduceOrderID", "mbProduceOrderID", args.ProduceOrderID);
            //}
            if (args.Started!=DateTime.MinValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductionSet].[Started", "mbStarted", args.Started);
                //this.SetParameters_Between(mbBuilder, cmd, "ProduceOrderID", "mbProduceOrderID", args.BookingDateFrom, args.BookingDateTo);
            }
            if (args.Ended != DateTime.MinValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_ProductionSet].[Ended", "mbEnded", args.Ended);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}

