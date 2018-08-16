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
      
        #region BE_TransportMain InsertObject()
        public int InsertTransportMain(TransportMain obj)
        {
            string sql = @"INSERT INTO[BE_TransportMain]([TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				) VALUES(@TransportID
				, @TransportNo
				, @CarID
				, @Source
				, @Target
				, @Price
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", Convert2DBnull(obj.TransportID));
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            SqlParameter pTransportNo = new SqlParameter("TransportNo", Convert2DBnull(obj.TransportNo));
            pTransportNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pTransportNo);

            SqlParameter pCarID = new SqlParameter("CarID", Convert2DBnull(obj.CarID));
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            SqlParameter pSource = new SqlParameter("Source", Convert2DBnull(obj.Source));
            pSource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSource);

            SqlParameter pTarget = new SqlParameter("Target", Convert2DBnull(obj.Target));
            pTarget.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTarget);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_TransportMain UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateTransportMainByTransportID(TransportMain obj)
        {
            string sql = @"UPDATE [BE_TransportMain] SET [TransportNo]=@TransportNo
				, [CarID]=@CarID
				, [Source]=@Source
				, [Target]=@Target
				, [Price]=@Price
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportNo = new SqlParameter("TransportNo", Convert2DBnull(obj.TransportNo));
            pTransportNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pTransportNo);

            SqlParameter pCarID = new SqlParameter("CarID", Convert2DBnull(obj.CarID));
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            SqlParameter pSource = new SqlParameter("Source", Convert2DBnull(obj.Source));
            pSource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSource);

            SqlParameter pTarget = new SqlParameter("Target", Convert2DBnull(obj.Target));
            pTarget.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTarget);

            SqlParameter pPrice = new SqlParameter("Price", Convert2DBnull(obj.Price));
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pTransportID = new SqlParameter("TransportID", Convert2DBnull(obj.TransportID));
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainByTransportID(Guid transportID)
        {
            string sql = @"DELETE [BE_TransportMain] WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadTransportMainByTransportID(TransportMain obj)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
 				FROM [BE_TransportMain] WITH(NOLOCK) WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", Convert2DBnull(obj.TransportID));
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        obj.TransportID = (Guid)dr["TransportID"];
                    obj.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        obj.CarID = (Guid)dr["CarID"];
                    obj.Source = dr["Source"].ToString();
                    obj.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        obj.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_TransportMain CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountTransportMains()
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByTransportID(Guid transportID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByTransportNo(string transportNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [TransportNo]=@TransportNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportNo = new SqlParameter("TransportNo", transportNo);
            pTransportNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pTransportNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByCarID(Guid carID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsBySource(string source)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Source]=@Source";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSource = new SqlParameter("Source", source);
            pSource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSource);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByTarget(string target)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Target]=@Target";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTarget = new SqlParameter("Target", target);
            pTarget.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTarget);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByPrice(decimal price)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountTransportMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_TransportMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsTransportMains()
        {
            string sql = "SELECT TOP 1 * FROM [BE_TransportMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByTransportID(Guid transportID)
        {
            string sql = "SELECT TOP 1 [TransportID] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByTransportNo(string transportNo)
        {
            string sql = "SELECT TOP 1 [TransportNo] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [TransportNo]=@TransportNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportNo = new SqlParameter("TransportNo", transportNo);
            pTransportNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pTransportNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByCarID(Guid carID)
        {
            string sql = "SELECT TOP 1 [CarID] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsBySource(string source)
        {
            string sql = "SELECT TOP 1 [Source] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Source]=@Source";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSource = new SqlParameter("Source", source);
            pSource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSource);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByTarget(string target)
        {
            string sql = "SELECT TOP 1 [Target] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Target]=@Target";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTarget = new SqlParameter("Target", target);
            pTarget.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTarget);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByPrice(decimal price)
        {
            string sql = "SELECT TOP 1 [Price] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsTransportMainsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_TransportMain] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteTransportMains()
        {
            string sql = "DELETE FROM [BE_TransportMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByTransportID(Guid transportID)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByTransportNo(string transportNo)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [TransportNo]=@TransportNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportNo = new SqlParameter("TransportNo", transportNo);
            pTransportNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pTransportNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByCarID(Guid carID)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsBySource(string source)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [Source]=@Source";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSource = new SqlParameter("Source", source);
            pSource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSource);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByTarget(string target)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [Target]=@Target";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTarget = new SqlParameter("Target", target);
            pTarget.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTarget);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByPrice(decimal price)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteTransportMainsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_TransportMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<TransportMain> LoadTransportMains()
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByTransportID(Guid transportID)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [TransportID]=@TransportID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportID = new SqlParameter("TransportID", transportID);
            pTransportID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pTransportID);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByTransportNo(string transportNo)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [TransportNo]=@TransportNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTransportNo = new SqlParameter("TransportNo", transportNo);
            pTransportNo.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(pTransportNo);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByCarID(Guid carID)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsBySource(string source)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [Source]=@Source";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSource = new SqlParameter("Source", source);
            pSource.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pSource);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByTarget(string target)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [Target]=@Target";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTarget = new SqlParameter("Target", target);
            pTarget.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pTarget);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByPrice(decimal price)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [Price]=@Price";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPrice = new SqlParameter("Price", price);
            pPrice.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPrice);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByCreated(DateTime created)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<TransportMain> LoadTransportMainsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [TransportID]
				, [TransportNo]
				, [CarID]
				, [Source]
				, [Target]
				, [Price]
				, [Created]
				, [CreatedBy]
				 FROM [BE_TransportMain] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<TransportMain> ret = new List<TransportMain>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    TransportMain iret = new TransportMain();
                    if (!Convert.IsDBNull(dr["TransportID"]))
                        iret.TransportID = (Guid)dr["TransportID"];
                    iret.TransportNo = dr["TransportNo"].ToString();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    iret.Source = dr["Source"].ToString();
                    iret.Target = dr["Target"].ToString();
                    if (!Convert.IsDBNull(dr["Price"]))
                        iret.Price = (decimal)dr["Price"];
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
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

        #region BE_TransportMain SearchObject()
        public SearchResult SearchTransportMain(SearchTransportMainArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[TransportNo] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [TransportID]
                                      ,[TransportNo]
	                                  ,[EnterpriseName]
	                                  ,[Address]
                                      ,[BE_TransportMain].[CarID]
	                                  ,[PlateNo]
	                                  ,[DriverName]
	                                  ,[CarName]
	                                  ,[CarStyle]	 
                                      ,[Source]
                                      ,[Target]
                                      ,[Price]
                                      ,[BE_TransportMain].[Created]
                                      ,[BE_TransportMain].[CreatedBy]
                                  FROM [BE_TransportMain] with(nolock)
                                  LEFT JOIN [BE_Car] with(nolock) on [BE_TransportMain].[CarID] = [BE_Car].[CarID]
                                  LEFT JOIN [BE_LogisticsEnterprise] on [BE_Car].[EnterpriseID] = [BE_LogisticsEnterprise].[EnterpriseID]
                                WHERE 1=1");


            if (args.TransportID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "TransportID", "mbTransportID", args.TransportID.Value);
            }
            if (!string.IsNullOrEmpty(args.EnterpriseName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "EnterpriseName", "mbEnterpriseName", args.EnterpriseName);
            }

            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Address", "mbAddress", args.Address);
            }

            if (!string.IsNullOrEmpty(args.PlateNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PlateNo", "mbPlateNo", args.PlateNo);
            }

            if (!string.IsNullOrEmpty(args.DriverName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DriverName", "mbDriverName", args.DriverName);
            }

            if (!string.IsNullOrEmpty(args.TransportNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "TransportNo", "mbTransportNo", args.TransportNo);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
