using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mes.BE.Objects
{
    /// <summary>
    /// 勿必使用using语句初始化ObjectProxy类的新实例，否则数据库连接不会释放，事务不会回滚。
    /// </summary>
    partial class ObjectProxy : IDisposable
    {
        public ObjectProxy()
        {
            this.conn = new SqlConnection(Config.DatabaseProvider);
            this.conn.Open();
        }
        public ObjectProxy(bool beginTransaction)
        {
            this.conn = new SqlConnection(Config.DatabaseProvider);
            this.conn.Open();
            if (beginTransaction)
            {
                this.BeginTransaction();
            }
        }
        private SqlConnection conn;
        private SqlTransaction trans;

        public void BeginTransaction()
        {
            if (this.trans == null)
            {
                this.trans = this.conn.BeginTransaction();
            }
        }
        public void CommitTransaction()
        {
            try
            {
                if (this.trans != null)
                {
                    this.trans.Commit();
                }
            }
            finally
            {
                this.trans = null;
            }
        }
        public void Dispose()
        {
            try
            {
                if (this.trans != null)
                {
                    this.trans.Rollback();
                }
            }
            catch
            {
            }
            finally
            {
                try
                {
                    this.conn.Close();
                }
                catch
                {
                }
            }
        }
        private object Convert2DBnull(object obj)
        {
            if (obj == null || (obj.GetType() == typeof(DateTime) && DateTime.MinValue == (DateTime)obj))
            {
                return Convert.DBNull;
            }
            else
            {
                return obj;
            }
        }

        #region 基础方法
        private SearchResult SearchBaseSqls(string baseSql, SqlCommand command, string orderBy, int? rowNumberFrom, int? rowNumberTo)
        {
            try
            {

                string count = string.Format("SELECT COUNT(*) FROM {0}", baseSql);
                string rowNumber = string.Format("(SELECT RowNumber = Row_Number() OVER(ORDER BY {0}), * FROM {1}) baseRowNumber", orderBy, baseSql);

                StringBuilder execBuilder = new StringBuilder();
                execBuilder.AppendFormat("SELECT * FROM {0} WHERE 1=1", rowNumber);
                this.SetParameters_Between(execBuilder, command, "RowNumber", "execRowNumber", rowNumberFrom, rowNumberTo);
                execBuilder.AppendLine("");
                execBuilder.AppendFormat(count);
                execBuilder.AppendLine("");

                command.Connection = this.conn;
                command.Transaction = this.trans;
                command.CommandType = CommandType.Text;
                command.CommandText = execBuilder.ToString();

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);

                SearchResult sr = new SearchResult();
                sr.DataSet = ds;
                sr.Total = (int)ds.Tables[1].Rows[0][0];
                return sr;
            }
            catch (Exception ex)
            {
                PLogger.LogError(command.CommandText);
                throw ex;
            }
        }
        private void SetParameters_Contains(StringBuilder builder, SqlCommand command, string column, List<string> values)
        {
            if (values == null)
            {
                return;
            }
            builder.AppendFormat(" AND (1>2");
            foreach (string text in values)
            {
                builder.AppendFormat(" OR [{0}] LIKE '%{1}%'", column, text);
            }
            builder.AppendFormat(" )");

        }
        private void SetParameters_Contains(StringBuilder builder, SqlCommand command, string column, string alias, string value)
        {
            if (value == null)
            {
                return;
            }
            builder.AppendFormat(" AND [{0}] LIKE '%{1}%'", column, value);
        }
        private void SetParameters_NotContains(StringBuilder builder, SqlCommand command, string column, List<string> values)
        {
            if (values == null)
            {
                return;
            }
            foreach (string text in values)
            {
                builder.AppendFormat(" AND [{0}] NOT LIKE '%{1}%'", column, text);
            }
        }

        private void SetParameters_Equals(StringBuilder builder, SqlCommand command, string column, string alias, object value)
        {
            if (value == null)
            {
                return;
            }
            builder.AppendFormat(" AND [{0}]=@{1}", column, alias);
            command.Parameters.Add(new SqlParameter(alias, value));
        }
        private void SetParameters_NotEquals(StringBuilder builder, SqlCommand command, string column, string alias, object value)
        {
            if (value == null)
            {
                return;
            }
            builder.AppendFormat(" AND [{0}] != @{1}", column, alias);
            command.Parameters.Add(new SqlParameter(alias, value));
        }
        private void SetParameters_In(StringBuilder builder, SqlCommand command, string column, string alias, List<string> values)
        {
            if (values == null)
            {
                return;
            }
            if (values.Count == 0)
            {
                builder.AppendFormat(" AND 1=2");
            }
            else if (values.Count == 1)
            {
                builder.AppendFormat(" AND @{1}=[{0}]", column, alias);
                string pv = values[0];
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
            else
            {
                builder.AppendFormat(" AND @{1} LIKE N'%,'+[{0}]+N',%'", column, alias);
                string pv = ",";
                foreach (string text in values)
                {
                    pv += text + ",";
                }
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
        }
        private void SetParameters_NotIn(StringBuilder builder, SqlCommand command, string column, string alias, List<string> values)
        {
            if (values == null)
            {
                return;
            }
            if (values.Count == 0)
            {
                builder.AppendFormat(" AND 1=1");
            }
            else if (values.Count == 1)
            {
                builder.AppendFormat(" AND @{1}<>[{0}]", column, alias);
                string pv = values[0];
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
            else
            {
                builder.AppendFormat(" AND @{1} NOT LIKE N'%,'+[{0}]+N',%'", column, alias);
                string pv = ",";
                foreach (string text in values)
                {
                    pv += text + ",";
                }
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
        }
        private void SetParameters_In(StringBuilder builder, SqlCommand command, string column, string alias, List<Guid> values)
        {
            if (values == null)
            {
                return;
            }
            if (values.Count == 0)
            {
                builder.AppendFormat(" AND 1=2");
            }
            else if (values.Count == 1)
            {
                builder.AppendFormat(" AND @{1}=[{0}]", column, alias);
                Guid pv = values[0];
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
            else
            {
                builder.AppendFormat(" AND @{1} LIKE N'%,'+Convert(NCHAR(36),[{0}])+N',%'", column, alias);
                string pv = ",";
                foreach (Guid id in values)
                {
                    pv += id.ToString() + ",";
                }
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
        }
        private void SetParameters_In(StringBuilder builder, SqlCommand command, string column, string alias, List<int> values)
        {
            if (values == null)
            {
                return;
            }
            if (values.Count == 0)
            {
                builder.AppendFormat(" AND 1=2");
            }
            else if (values.Count == 1)
            {
                builder.AppendFormat(" AND @{1}=[{0}]", column, alias);
                int pv = values[0];
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
            else
            {
                builder.AppendFormat(" AND @{1} LIKE N'%,'+[{0}]+N',%'", column, alias);
                string pv = ",";
                foreach (int id in values)
                {
                    pv += id.ToString() + ",";
                }
                command.Parameters.Add(new SqlParameter(alias, pv));
            }
        }
        private void SetParameters_Between(StringBuilder builder, SqlCommand command, string column, string alias, object from, object to)
        {
            if (from != null)
            {
                builder.AppendFormat(" AND [{0}]>=@{1}From", column, alias);
                command.Parameters.Add(new SqlParameter(alias + "From", from));
            }
            if (to != null)
            {
                builder.AppendFormat(" AND [{0}]<=@{1}To", column, alias);
                command.Parameters.Add(new SqlParameter(alias + "To", to));
            }
        }
        #endregion
    }
}
