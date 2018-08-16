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
        #region BE_KeyValue InsertObject()
        public int InsertKeyValue(KeyValue obj)
        {
            string sql = @"INSERT INTO[BE_KeyValue]([Key]
				, [Value]
				, [Remark]
				) VALUES(@Key
				, @Value
				, @Remark
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", Convert2DBnull(obj.Key));
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            SqlParameter pValue = new SqlParameter("Value", Convert2DBnull(obj.Value));
            pValue.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pValue);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_KeyValue UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateKeyValueByKey(KeyValue obj)
        {
            string sql = @"UPDATE [BE_KeyValue] SET [Value]=@Value
				, [Remark]=@Remark
 				WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pValue = new SqlParameter("Value", Convert2DBnull(obj.Value));
            pValue.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pValue);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pKey = new SqlParameter("Key", Convert2DBnull(obj.Key));
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteKeyValueByKey(string key)
        {
            string sql = @"DELETE [BE_KeyValue] WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", key);
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            return cmd.ExecuteNonQuery();
        }
        public int LoadKeyValueByKey(KeyValue obj)
        {
            string sql = @"SELECT [Key]
				, [Value]
				, [Remark]
 				FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", Convert2DBnull(obj.Key));
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    obj.Key = dr["Key"].ToString();
                    obj.Value = dr["Value"].ToString();
                    obj.Remark = dr["Remark"].ToString();
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

        #region BE_KeyValue CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountKeyValues()
        {
            string sql = "SELECT COUNT(*) FROM [BE_KeyValue]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountKeyValuesByKey(string key)
        {
            string sql = "SELECT COUNT(*) FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", key);
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountKeyValuesByValue(string value)
        {
            string sql = "SELECT COUNT(*) FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Value]=@Value";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pValue = new SqlParameter("Value", value);
            pValue.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pValue);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountKeyValuesByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsKeyValues()
        {
            string sql = "SELECT TOP 1 * FROM [BE_KeyValue]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsKeyValuesByKey(string key)
        {
            string sql = "SELECT TOP 1 [Key] FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", key);
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsKeyValuesByValue(string value)
        {
            string sql = "SELECT TOP 1 [Value] FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Value]=@Value";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pValue = new SqlParameter("Value", value);
            pValue.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pValue);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsKeyValuesByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_KeyValue] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteKeyValues()
        {
            string sql = "DELETE FROM [BE_KeyValue]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteKeyValuesByKey(string key)
        {
            string sql = "DELETE FROM [BE_KeyValue] WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", key);
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteKeyValuesByValue(string value)
        {
            string sql = "DELETE FROM [BE_KeyValue] WHERE [Value]=@Value";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pValue = new SqlParameter("Value", value);
            pValue.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pValue);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteKeyValuesByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_KeyValue] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public List<KeyValue> LoadKeyValues()
        {
            string sql = @"SELECT [Key]
				, [Value]
				, [Remark]
				 FROM [BE_KeyValue]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<KeyValue> ret = new List<KeyValue>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    KeyValue iret = new KeyValue();
                    iret.Key = dr["Key"].ToString();
                    iret.Value = dr["Value"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<KeyValue> LoadKeyValuesByKey(string key)
        {
            string sql = @"SELECT [Key]
				, [Value]
				, [Remark]
				 FROM [BE_KeyValue] WHERE [Key]=@Key";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKey = new SqlParameter("Key", key);
            pKey.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pKey);

            List<KeyValue> ret = new List<KeyValue>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    KeyValue iret = new KeyValue();
                    iret.Key = dr["Key"].ToString();
                    iret.Value = dr["Value"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<KeyValue> LoadKeyValuesByValue(string value)
        {
            string sql = @"SELECT [Key]
				, [Value]
				, [Remark]
				 FROM [BE_KeyValue] WHERE [Value]=@Value";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pValue = new SqlParameter("Value", value);
            pValue.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pValue);

            List<KeyValue> ret = new List<KeyValue>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    KeyValue iret = new KeyValue();
                    iret.Key = dr["Key"].ToString();
                    iret.Value = dr["Value"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<KeyValue> LoadKeyValuesByRemark(string remark)
        {
            string sql = @"SELECT [Key]
				, [Value]
				, [Remark]
				 FROM [BE_KeyValue] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<KeyValue> ret = new List<KeyValue>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    KeyValue iret = new KeyValue();
                    iret.Key = dr["Key"].ToString();
                    iret.Value = dr["Value"].ToString();
                    iret.Remark = dr["Remark"].ToString();
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
