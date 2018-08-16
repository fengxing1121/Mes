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
        #region BE_RoomDesignerKJLRelation InsertObject()
        public int InsertRoomDesignerKJLRelation(RoomDesignerKJLRelation obj)
        {
            string sql = @"INSERT INTO[BE_RoomDesignerKJLRelation]([ID]
				, [DesignerNo]
				, [KJLDesignID]
				, [Status]
				, [Created]
				, [CreatedBy]
				) VALUES(@ID
				, @DesignerNo
				, @KJLDesignID
				, @Status
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pID = new SqlParameter("ID", Convert2DBnull(obj.ID));
            pID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pID);

            SqlParameter pDesignerNo = new SqlParameter("DesignerNo", Convert2DBnull(obj.DesignerNo));
            pDesignerNo.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pDesignerNo);

            SqlParameter pKJLDesignID = new SqlParameter("KJLDesignID", Convert2DBnull(obj.KJLDesignID));
            pKJLDesignID.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pKJLDesignID);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(pStatus);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_RoomDesignerKJLRelation UpdateObject()、 ExistsObjects()、 LoadObject()
        public int UpdateRoomDesignerKJLRelationByDesignID(RoomDesignerKJLRelation obj)
        {
            string sql = @"UPDATE [BE_RoomDesignerKJLRelation] SET [DesignerNo]=@DesignerNo
 				WHERE [KJLDesignID]=@KJLDesignID";

            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerNo = new SqlParameter("DesignerNo", Convert2DBnull(obj.DesignerNo));
            pDesignerNo.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pDesignerNo);

            SqlParameter pKJLDesignID = new SqlParameter("KJLDesignID", Convert2DBnull(obj.KJLDesignID));
            pKJLDesignID.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pKJLDesignID);

            return cmd.ExecuteNonQuery();
        }

        public bool ExistsRoomDesignerKJLRelationByDesignerNo(int designerNo)
        {
            string sql = "SELECT TOP 1 [DesignerNo] FROM [BE_RoomDesignerKJLRelation] WITH(NOLOCK) WHERE [DesignerNo]=@DesignerNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerNo = new SqlParameter("DesignerNo", designerNo);
            pDesignerNo.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pDesignerNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public int LoadRoomDesignerKJLRelatioByDesignID(RoomDesignerKJLRelation obj)
        {
            string sql = @"SELECT [ID]
				, [DesignerNo]
				, [KJLDesignID]
				, [Status]
				, [Created]
				, [CreatedBy]
				 FROM [BE_RoomDesignerKJLRelation] WHERE [KJLDesignID]=@KJLDesignID OR [DesignerNo]=@DesignerNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pKJLDesignID = new SqlParameter("KJLDesignID", obj.KJLDesignID);
            pKJLDesignID.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pKJLDesignID);

            SqlParameter pDesignerNo = new SqlParameter("DesignerNo", obj.DesignerNo);
            pDesignerNo.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pDesignerNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["ID"]))
                        obj.ID = (Guid)dr["ID"];
                    if (!Convert.IsDBNull(dr["DesignerNo"]))
                        obj.DesignerNo = Convert.ToInt32(dr["DesignerNo"]);
                    if (!Convert.IsDBNull(dr["KJLDesignID"]))
                        obj.KJLDesignID = dr["KJLDesignID"].ToString();
                    if (!Convert.IsDBNull(dr["Status"]))
                        obj.Status = (bool)dr["Status"];
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
    }
}
