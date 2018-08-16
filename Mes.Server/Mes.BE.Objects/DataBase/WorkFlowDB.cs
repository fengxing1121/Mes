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
        #region BE_WorkFlow InsertObject()
        public int InsertWorkFlow(WorkFlow obj)
        {
            string sql = @"Insert Into [BE_WorkFlow](
                              [WorkFlowID]
                             ,[WorkFlowCode]
                             ,[WorkFlowName]
                             ,[ImageUrl]
                             ,[Remark]
                             ,[SortNo]
                             ,[Created]
                             ,[CreatedBy]
            )Values (
                              @WorkFlowID
                             ,@WorkFlowCode
                             ,@WorkFlowName
                             ,@ImageUrl
                             ,@Remark
                             ,@SortNo
                             ,@Created
                             ,@CreatedBy
                    )";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pWorkFlowCode = new SqlParameter("WorkFlowCode", Convert2DBnull(obj.WorkFlowCode));
            pWorkFlowCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkFlowCode);

            SqlParameter pWorkFlowName = new SqlParameter("WorkFlowName", Convert2DBnull(obj.WorkFlowName));
            pWorkFlowName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkFlowName);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pSortNo = new SqlParameter("SortNo", Convert2DBnull(obj.SortNo));
            pSortNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortNo);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkFlow UpdateObject()、DeleteObject()
        public int UpdateWorkFlowByWorkFlowID(WorkFlow obj)
        {
            string sql = @"Update [BE_WorkFlow] Set
                              [WorkFlowCode]=@WorkFlowCode
                             ,[WorkFlowName]=@WorkFlowName
                             ,[ImageUrl]=@ImageUrl
                             ,[Remark]=@Remark
                             ,[SortNo]=@SortNo
                             ,[Created]=@Created
                             ,[CreatedBy]=@CreatedBy
                          Where WorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            SqlParameter pWorkFlowCode = new SqlParameter("WorkFlowCode", Convert2DBnull(obj.WorkFlowCode));
            pWorkFlowCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkFlowCode);

            SqlParameter pWorkFlowName = new SqlParameter("WorkFlowName", Convert2DBnull(obj.WorkFlowName));
            pWorkFlowName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pWorkFlowName);

            SqlParameter pImageUrl = new SqlParameter("ImageUrl", Convert2DBnull(obj.ImageUrl));
            pImageUrl.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pImageUrl);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pSortNo = new SqlParameter("SortNo", Convert2DBnull(obj.SortNo));
            pSortNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSortNo);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }

        public int DeleteWorkFlowByWorkFlowID(Guid WorkFlowID)
        {
            string sql = @"Delete [BE_WorkFlow]  Where WorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_WorkFlow LoadObject()
        public List<WorkFlow> LoadWorkFlows()
        {
            string sql = @"Select 
                              [WorkFlowID]
                             ,[WorkFlowCode]
                             ,[WorkFlowName]
                             ,[ImageUrl]
                             ,[Remark]
                             ,[SortNo]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkFlow] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<WorkFlow> ret = new List<WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkFlow iret = new WorkFlow();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkFlowCode"]))
                        iret.WorkFlowCode = (string)dr["WorkFlowCode"];
                    if (!Convert.IsDBNull(dr["WorkFlowName"]))
                        iret.WorkFlowName = (string)dr["WorkFlowName"];
                    if (!Convert.IsDBNull(dr["ImageUrl"]))
                        iret.ImageUrl = (string)dr["ImageUrl"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["SortNo"]))
                        iret.SortNo = (int)dr["SortNo"];
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

        public List<WorkFlow> LoadWorkFlowByWorkFlowID(WorkFlow obj)
        {
            string sql = @"Select 
                              [WorkFlowID]
                             ,[WorkFlowCode]
                             ,[WorkFlowName]
                             ,[ImageUrl]
                             ,[Remark]
                             ,[SortNo]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkFlow] With(NoLock) Where WorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            List<WorkFlow> ret = new List<WorkFlow>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    WorkFlow iret = new WorkFlow();
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        iret.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkFlowCode"]))
                        iret.WorkFlowCode = (string)dr["WorkFlowCode"];
                    if (!Convert.IsDBNull(dr["WorkFlowName"]))
                        iret.WorkFlowName = (string)dr["WorkFlowName"];
                    if (!Convert.IsDBNull(dr["ImageUrl"]))
                        iret.ImageUrl = (string)dr["ImageUrl"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        iret.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["SortNo"]))
                        iret.SortNo = (int)dr["SortNo"];
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

        public int LoadWorkFlow(WorkFlow obj)
        {
            string sql = @"Select 
                              [WorkFlowID]
                             ,[WorkFlowCode]
                             ,[WorkFlowName]
                             ,[ImageUrl]
                             ,[Remark]
                             ,[SortNo]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkFlow] With(NoLock) Where WorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(obj.WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["WorkFlowID"]))
                        obj.WorkFlowID = (Guid)dr["WorkFlowID"];
                    if (!Convert.IsDBNull(dr["WorkFlowCode"]))
                        obj.WorkFlowCode = (string)dr["WorkFlowCode"];
                    if (!Convert.IsDBNull(dr["WorkFlowName"]))
                        obj.WorkFlowName = (string)dr["WorkFlowName"];
                    if (!Convert.IsDBNull(dr["ImageUrl"]))
                        obj.ImageUrl = (string)dr["ImageUrl"];
                    if (!Convert.IsDBNull(dr["Remark"]))
                        obj.Remark = (string)dr["Remark"];
                    if (!Convert.IsDBNull(dr["SortNo"]))
                        obj.SortNo = (int)dr["SortNo"];
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

        #region BE_WorkFlow CountObjects()、ExistsObjects()
        public int CountWorkFlow()
        {
            string sql = @"Select Count(*) From [BE_WorkFlow] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public int CountWorkFlowByWorkFlowID(Guid WorkFlowID)
        {
            string sql = @"Select Count(*) From [BE_WorkFlow]  Where WorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }

        public bool ExistsWorkFlow()
        {
            string sql = @"Select Top 1 * From [BE_WorkFlow] With(NoLock)";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsWorkFlowByWorkFlowID(Guid WorkFlowID)
        {
            string sql = @"Select Top 1 * From [BE_WorkFlow]  Where WorkFlowID=@WorkFlowID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWorkFlowID = new SqlParameter("WorkFlowID", Convert2DBnull(WorkFlowID));
            pWorkFlowID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pWorkFlowID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        #endregion

        #region BE_WorkFlow SearchObject()
        public SearchResult SearchWorkFlow(SearchWorkFlowArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[WorkFlowID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"Select 
                              [WorkFlowID]
                             ,[WorkFlowCode]
                             ,[WorkFlowName]
                             ,[ImageUrl]
                             ,[Remark]
                             ,[SortNo]
                             ,[Created]
                             ,[CreatedBy]
                       From [BE_WorkFlow] With(NoLock) Where 1=1 ");

            //this.SetParameters_In(mbBuilder, cmd, "BE_WorkFlow].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID);

            //if (args.ProduceOrderID.HasValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkFlow].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID);
            //}
            //if (!string.IsNullOrEmpty(args.OrderNo))
            //{
            //    this.SetParameters_Contains(mbBuilder, cmd, "BE_WorkFlow].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID);
            //}
            //if (!string.IsNullOrEmpty(args.ProduceOrderID))
            //{
            //    this.SetParameters_Between(mbBuilder, cmd, "BE_WorkFlow].[WorkFlowID", "mbWorkFlowID", args.BookingDateFrom, args.BookingDateTo);
            //}
            //if (args.Ended != DateTime.MinValue)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_WorkFlow].[WorkFlowID", "mbWorkFlowID", args.WorkFlowID);
            //}
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}

