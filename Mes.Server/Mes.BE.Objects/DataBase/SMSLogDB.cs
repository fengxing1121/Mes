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
       
        #region BE_SMSLog InsertObject()
        public int InsertSMSLog(SMSLog obj)
        {
            string sql = @"INSERT INTO[BE_SMSLog]([ID]
				, [Phone]
				, [Message]
				, [Created]
				, [Status]
				) VALUES(@ID
				, @Phone
				, @Message
				, @Created
				, @Status
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            SqlParameter pPhone = new SqlParameter("Phone", Convert2DBnull(obj.Phone));
            pPhone.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPhone);

            SqlParameter pMessage = new SqlParameter("Message", Convert2DBnull(obj.Message));
            pMessage.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMessage);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_SMSLog LoadObject()
        public List<SMSLog> LoadSMSLogs()
        {
            string sql = @"SELECT [ID]
				, [Phone]
				, [Message]
				, [Created]
                , [Status]
				 FROM [BE_SMSLog]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SMSLog> ret = new List<SMSLog>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SMSLog iret = new SMSLog();
                    if (!Convert.IsDBNull(dr["ID"]))
                        iret.ID = (Guid)dr["ID"];
                    iret.Phone = dr["Phone"].ToString();
                    if (!Convert.IsDBNull(dr["Message"]))
                        iret.Message = dr["Message"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    if (!Convert.IsDBNull(dr["Status"]))
                        iret.Status = (bool)dr["IStatusD"];
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

        #region BE_SMSLog SearchObject()
        public SearchResult SearchSMSLogs(SearchSMSLogArgs args)
        {
            if (string.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[Created] ASC";
            }
            SqlCommand cmd = new SqlCommand();
            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [ID]                                       
                                          ,[Phone]
                                          ,[Message]
                                          ,[Created]
                                          ,[Status]
                                      FROM 
                                           [BE_SMSLog] with(nolock)
	                                  WHERE 1=1");


            //if (args.Status)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "Status", "mbLogType", args.Status);
            //}

            SetParameters_Between(mbBuilder, cmd, "Created", "mbCreated", args.CreatedFrom, args.CreatedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
