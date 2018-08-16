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
       
        #region BE_SpecialCompanent2WorkFlow InsertObject()
        public int InsertSpecialCompanent2WorkFlow(SpecialCompanent2WorkFlow obj)
        {
            string sql = @"INSERT INTO[BE_SpecialCompanent2WorkFlow]([SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
				) VALUES(@SpecialDetailID
				, @SpecialID
				, @WorkFlowID
				, @Sequence
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", Convert2DBnull(obj.SpecialDetailID));
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", Convert2DBnull(obj.SpecialID));
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_SpecialCompanent2WorkFlow UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSpecialCompanent2WorkFlowBySpecialDetailID(SpecialCompanent2WorkFlow obj)
        {
            string sql = @"UPDATE [BE_SpecialCompanent2WorkFlow] SET [SpecialID]=@SpecialID
				, [WorkFlowID]=@WorkFlowID
				, [Sequence]=@Sequence
 				WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", Convert2DBnull(obj.SpecialID));
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pSequence = new SqlParameter("Sequence", Convert2DBnull(obj.Sequence));
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", Convert2DBnull(obj.SpecialDetailID));
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanent2WorkFlowBySpecialDetailID(Guid specialDetailID)
        {
            string sql = @"DELETE [BE_SpecialCompanent2WorkFlow] WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", specialDetailID);
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSpecialCompanent2WorkFlowBySpecialDetailID(SpecialCompanent2WorkFlow obj)
        {
            string sql = @"SELECT [SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
 				FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", Convert2DBnull(obj.SpecialDetailID));
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SpecialDetailID"]))
                        obj.SpecialDetailID = (Guid)dr["SpecialDetailID"];
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        obj.SpecialID = (Guid)dr["SpecialID"];
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        obj.Sequence = (int)dr["Sequence"];
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

        #region BE_SpecialCompanent2WorkFlow CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSpecialCompanent2WorkFlows()
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent2WorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanent2WorkFlowsBySpecialDetailID(Guid specialDetailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", specialDetailID);
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanent2WorkFlowsBySpecialID(Guid specialID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanent2WorkFlowsByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSpecialCompanent2WorkFlowsBySequence(int sequence)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSpecialCompanent2WorkFlows()
        {
            string sql = "SELECT TOP 1 * FROM [BE_SpecialCompanent2WorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanent2WorkFlowsBySpecialDetailID(Guid specialDetailID)
        {
            string sql = "SELECT TOP 1 [SpecialDetailID] FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", specialDetailID);
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanent2WorkFlowsBySpecialID(Guid specialID)
        {
            string sql = "SELECT TOP 1 [SpecialID] FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanent2WorkFlowsByWorkFlowID(Guid workFlowID)
        {
            string sql = "SELECT TOP 1 [WorkFlowID] FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSpecialCompanent2WorkFlowsBySequence(int sequence)
        {
            string sql = "SELECT TOP 1 [Sequence] FROM [BE_SpecialCompanent2WorkFlow] WITH(NOLOCK) WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSpecialCompanent2WorkFlows()
        {
            string sql = "DELETE FROM [BE_SpecialCompanent2WorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanent2WorkFlowsBySpecialDetailID(Guid specialDetailID)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent2WorkFlow] WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", specialDetailID);
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanent2WorkFlowsBySpecialID(Guid specialID)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent2WorkFlow] WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanent2WorkFlowsByWorkFlowID(Guid workFlowID)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent2WorkFlow] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSpecialCompanent2WorkFlowsBySequence(int sequence)
        {
            string sql = "DELETE FROM [BE_SpecialCompanent2WorkFlow] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            return cmd.ExecuteNonQuery();
        }
        public List<SpecialCompanent2WorkFlow> LoadSpecialCompanent2WorkFlows()
        {
            string sql = @"SELECT [SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
				 FROM [BE_SpecialCompanent2WorkFlow]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SpecialCompanent2WorkFlow> ret = new List<SpecialCompanent2WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent2WorkFlow iret = new SpecialCompanent2WorkFlow();
                    if (!Convert.IsDBNull(dr["SpecialDetailID"]))
                        iret.SpecialDetailID = (Guid)dr["SpecialDetailID"];
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SpecialCompanent2WorkFlow> LoadSpecialCompanent2WorkFlowsBySpecialDetailID(Guid specialDetailID)
        {
            string sql = @"SELECT [SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
				 FROM [BE_SpecialCompanent2WorkFlow] WHERE [SpecialDetailID]=@SpecialDetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialDetailID = new SqlParameter("SpecialDetailID", specialDetailID);
            pSpecialDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialDetailID);

            List<SpecialCompanent2WorkFlow> ret = new List<SpecialCompanent2WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent2WorkFlow iret = new SpecialCompanent2WorkFlow();
                    if (!Convert.IsDBNull(dr["SpecialDetailID"]))
                        iret.SpecialDetailID = (Guid)dr["SpecialDetailID"];
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SpecialCompanent2WorkFlow> LoadSpecialCompanent2WorkFlowsBySpecialID(Guid specialID)
        {
            string sql = @"SELECT [SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
				 FROM [BE_SpecialCompanent2WorkFlow] WHERE [SpecialID]=@SpecialID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSpecialID = new SqlParameter("SpecialID", specialID);
            pSpecialID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSpecialID);

            List<SpecialCompanent2WorkFlow> ret = new List<SpecialCompanent2WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent2WorkFlow iret = new SpecialCompanent2WorkFlow();
                    if (!Convert.IsDBNull(dr["SpecialDetailID"]))
                        iret.SpecialDetailID = (Guid)dr["SpecialDetailID"];
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SpecialCompanent2WorkFlow> LoadSpecialCompanent2WorkFlowsByWorkFlowID(Guid workFlowID)
        {
            string sql = @"SELECT [SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
				 FROM [BE_SpecialCompanent2WorkFlow] WHERE [WorkFlowID]=@WorkFlowID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", workFlowID);
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<SpecialCompanent2WorkFlow> ret = new List<SpecialCompanent2WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent2WorkFlow iret = new SpecialCompanent2WorkFlow();
                    if (!Convert.IsDBNull(dr["SpecialDetailID"]))
                        iret.SpecialDetailID = (Guid)dr["SpecialDetailID"];
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SpecialCompanent2WorkFlow> LoadSpecialCompanent2WorkFlowsBySequence(int sequence)
        {
            string sql = @"SELECT [SpecialDetailID]
				, [SpecialID]
				, [WorkFlowID]
				, [Sequence]
				 FROM [BE_SpecialCompanent2WorkFlow] WHERE [Sequence]=@Sequence";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSequence = new SqlParameter("Sequence", sequence);
            pSequence.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSequence);

            List<SpecialCompanent2WorkFlow> ret = new List<SpecialCompanent2WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SpecialCompanent2WorkFlow iret = new SpecialCompanent2WorkFlow();
                    if (!Convert.IsDBNull(dr["SpecialDetailID"]))
                        iret.SpecialDetailID = (Guid)dr["SpecialDetailID"];
                    if (!Convert.IsDBNull(dr["SpecialID"]))
                        iret.SpecialID = (Guid)dr["SpecialID"];
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["Sequence"]))
                        iret.Sequence = (int)dr["Sequence"];
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

        #region BE_SpecialCompanent2WorkFlow SearchObject()
        public SearchResult SearchSpecialCompanent2WorkFlow(SearchSpecialCompanent2WorkFlowArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[SpecialID],[Sequence] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_SpecialCompanent].[SpecialID]                                       
                                          ,[BE_SpecialCompanent].[ItemName]
                                          ,[BE_SpecialCompanent].[IsDisabled]  
                                          ,[BE_SpecialCompanent2WorkFlow].[SpecialDetailID]
                                          ,[BE_SpecialCompanent2WorkFlow].[Sequence]  
	                                      ,[BE_SpecialCompanent2WorkFlow].[WorkFlowID]
	                                      ,[BE_WorkFlow].[WorkFlowCode]
	                                      ,[BE_WorkFlow].[WorkFlowName]	 
                                      FROM [BE_SpecialCompanent] with(nolock)
                                          LEFT JOIN [BE_SpecialCompanent2WorkFlow] with(nolock) on [BE_SpecialCompanent].[SpecialID] = [BE_SpecialCompanent2WorkFlow].[SpecialID]
                                          LEFT JOIN [BE_WorkFlow] with(nolock) on [BE_WorkFlow].[WorkFlowID] = [BE_SpecialCompanent2WorkFlow].[WorkFlowID]
	                                  WHERE 1=1");


            if (args.SpecialID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_SpecialCompanent].[SpecialID", "mbSpecialID", args.SpecialID.Value);
            }
            if (args.WorkFlowID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_SpecialCompanent2WorkFlow].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID.Value);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            if (args.IsDisabled.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_SpecialCompanent].[IsDisabled", "mbIsDisabled", args.IsDisabled.Value);
            }
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
