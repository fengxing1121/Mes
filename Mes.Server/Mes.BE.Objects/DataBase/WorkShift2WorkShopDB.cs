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
       
        #region BE_WorkShift2WorkShop InsertObject()
        public int InsertWorkShift2WorkShop(WorkShift2WorkShop obj)
        {
            string sql = @"INSERT INTO[BE_WorkShift2WorkShop]([WorkShiftID]
				, [WorkShopID]
				) VALUES(@WorkShiftID
				, @WorkShopID
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkShift2WorkShop UpdateObject()、DeleteObject()、LoadObject()
        public int DeleteWorkShift2WorkShopByWorkShiftID_WorkShopID(Guid workShiftID, Guid workShopID)
        {
            string sql = @"DELETE [BE_WorkShift2WorkShop] WHERE [WorkShiftID]=@WorkShiftID AND [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadWorkShift2WorkShopByWorkShiftID_WorkShopID(WorkShift2WorkShop obj)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShopID]
 				FROM [BE_WorkShift2WorkShop] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID AND [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", Convert2DBnull(obj.WorkShiftID));
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", Convert2DBnull(obj.WorkShopID));
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        obj.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        obj.WorkShopID = (Guid)dr["WorkShopID"];
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

        #region BE_WorkShift2WorkShop CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountWorkShift2WorkShops()
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift2WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShift2WorkShopsByWorkShiftID(Guid workShiftID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift2WorkShop] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountWorkShift2WorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_WorkShift2WorkShop] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsWorkShift2WorkShops()
        {
            string sql = "SELECT TOP 1 * FROM [BE_WorkShift2WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShift2WorkShopsByWorkShiftID(Guid workShiftID)
        {
            string sql = "SELECT TOP 1 [WorkShiftID] FROM [BE_WorkShift2WorkShop] WITH(NOLOCK) WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsWorkShift2WorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = "SELECT TOP 1 [WorkShopID] FROM [BE_WorkShift2WorkShop] WITH(NOLOCK) WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteWorkShift2WorkShops()
        {
            string sql = "DELETE FROM [BE_WorkShift2WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShift2WorkShopsByWorkShiftID(Guid workShiftID)
        {
            string sql = "DELETE FROM [BE_WorkShift2WorkShop] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteWorkShift2WorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = "DELETE FROM [BE_WorkShift2WorkShop] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            return cmd.ExecuteNonQuery();
        }
        public List<WorkShift2WorkShop> LoadWorkShift2WorkShops()
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShopID]
				 FROM [BE_WorkShift2WorkShop]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkShift2WorkShop> ret = new List<WorkShift2WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift2WorkShop iret = new WorkShift2WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift2WorkShop> LoadWorkShift2WorkShopsByWorkShiftID(Guid workShiftID)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShopID]
				 FROM [BE_WorkShift2WorkShop] WHERE [WorkShiftID]=@WorkShiftID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShiftID = new SqlParameter("WorkShiftID", workShiftID);
            pWorkShiftID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShiftID);

            List<WorkShift2WorkShop> ret = new List<WorkShift2WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift2WorkShop iret = new WorkShift2WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<WorkShift2WorkShop> LoadWorkShift2WorkShopsByWorkShopID(Guid workShopID)
        {
            string sql = @"SELECT [WorkShiftID]
				, [WorkShopID]
				 FROM [BE_WorkShift2WorkShop] WHERE [WorkShopID]=@WorkShopID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkShopID = new SqlParameter("WorkShopID", workShopID);
            pWorkShopID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkShopID);

            List<WorkShift2WorkShop> ret = new List<WorkShift2WorkShop>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkShift2WorkShop iret = new WorkShift2WorkShop();
                    if (!Convert.IsDBNull(dr["WorkShiftID"]))
                        iret.WorkShiftID = (Guid)dr["WorkShiftID"];
                    if (!Convert.IsDBNull(dr["WorkShopID"]))
                        iret.WorkShopID = (Guid)dr["WorkShopID"];
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

        #region BE_WorkShift2WorkShop SearchObject()
        public SearchResult SearchWorkShift2WorkShop(SearchWorkShift2WorkShopArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkShiftCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_WorkShift].[WorkShiftID]
                                          ,[BE_WorkShift].[WorkShiftCode]
                                          ,[BE_WorkShift].[WorkShiftName]
                                          ,[BE_WorkShift].[Started]
                                          ,[BE_WorkShift].[Ended]
                                          ,[BE_WorkShift].[Created]
                                          ,[BE_WorkShift].[CreatedBy]
                                          ,[BE_WorkShift].[Modified]
                                          ,[BE_WorkShift].[ModifiedBy]
										  ,[BE_WorkShop].[WorkShopID]
										  ,[BE_WorkShop].[WorkShopCode]
										  ,[BE_WorkShop].[WorkShopName]
                                      FROM 
										  [BE_WorkShift] with(nolock)   
										  LEFT JOIN [BE_WorkShift2WorkShop] with(nolock) on [BE_WorkShift].[WorkShiftID] = [BE_WorkShift2WorkShop].[WorkShiftID]  
										  LEFT JOIN [BE_WorkShop] with(nolock) on [BE_WorkShift2WorkShop].[WorkShopID] = [BE_WorkShop].[WorkShopID]                        
	                                  WHERE 1=1");


            if (args.WorkShiftID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkShift].[WorkShiftID", "mbWorkFlowID", args.WorkShiftID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkShiftCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkShift].[WorkShiftCode", "mbWorkShiftCode", args.WorkShiftCode);
            }
            if (!string.IsNullOrEmpty(args.WorkShiftName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkShift].[WorkShiftName", "mbWorkShiftName", args.WorkShiftName);
            }
            if (args.WorkShopID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkShop].[WorkShopID", "mbWorkShopID", args.WorkShopID.Value);
            }
            if (!string.IsNullOrEmpty(args.WorkShopName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkShop].[WorkShopName", "mbWorkShopName", args.WorkShopName);
            }
            if (!string.IsNullOrEmpty(args.WorkShopCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkShop].[WorkShopCode", "mbWorkShopCode", args.WorkShopCode);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
