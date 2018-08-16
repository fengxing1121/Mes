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
        #region BE_Cabinet2Door InsertObject()
        public int InsertCabinet2Door(Cabinet2Door obj)
        {
            string sql = @"INSERT INTO[BE_Cabinet2Door]([DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@DoorID
				, @CabinetID
				, @DoorName
				, @DoorSize
				, @Qty
				, @Remark
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", Convert2DBnull(obj.DoorID));
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pDoorName = new SqlParameter("DoorName", Convert2DBnull(obj.DoorName));
            pDoorName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorName);

            SqlParameter pDoorSize = new SqlParameter("DoorSize", Convert2DBnull(obj.DoorSize));
            pDoorSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorSize);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Cabinet2Door UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCabinet2DoorByDoorID(Cabinet2Door obj)
        {
            string sql = @"UPDATE [BE_Cabinet2Door] SET [CabinetID]=@CabinetID
				, [DoorName]=@DoorName
				, [DoorSize]=@DoorSize
				, [Qty]=@Qty
				, [Remark]=@Remark
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pDoorName = new SqlParameter("DoorName", Convert2DBnull(obj.DoorName));
            pDoorName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorName);

            SqlParameter pDoorSize = new SqlParameter("DoorSize", Convert2DBnull(obj.DoorSize));
            pDoorSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorSize);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pModified = new SqlParameter("Modified", Convert2DBnull(obj.Modified));
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", Convert2DBnull(obj.ModifiedBy));
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            SqlParameter pDoorID = new SqlParameter("DoorID", Convert2DBnull(obj.DoorID));
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorByDoorID(Guid doorID)
        {
            string sql = @"DELETE [BE_Cabinet2Door] WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", doorID);
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCabinet2DoorByDoorID(Cabinet2Door obj)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", Convert2DBnull(obj.DoorID));
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        obj.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    obj.DoorName = dr["DoorName"].ToString();
                    obj.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (int)dr["Qty"];
                    obj.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        obj.Created = (DateTime)dr["Created"];
                    obj.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        obj.Modified = (DateTime)dr["Modified"];
                    obj.ModifiedBy = dr["ModifiedBy"].ToString();
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

        #region BE_Cabinet2Door CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCabinet2Doors()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByDoorID(Guid doorID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", doorID);
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByDoorName(string doorName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorName]=@DoorName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorName = new SqlParameter("DoorName", doorName);
            pDoorName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByDoorSize(string doorSize)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorSize]=@DoorSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorSize = new SqlParameter("DoorSize", doorSize);
            pDoorSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorSize);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByQty(int qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCabinet2DoorsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCabinet2Doors()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Cabinet2Door]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByDoorID(Guid doorID)
        {
            string sql = "SELECT TOP 1 [DoorID] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", doorID);
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByDoorName(string doorName)
        {
            string sql = "SELECT TOP 1 [DoorName] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorName]=@DoorName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorName = new SqlParameter("DoorName", doorName);
            pDoorName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByDoorSize(string doorSize)
        {
            string sql = "SELECT TOP 1 [DoorSize] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [DoorSize]=@DoorSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorSize = new SqlParameter("DoorSize", doorSize);
            pDoorSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorSize);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByQty(int qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCabinet2DoorsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Cabinet2Door] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCabinet2Doors()
        {
            string sql = "DELETE FROM [BE_Cabinet2Door]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByDoorID(Guid doorID)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", doorID);
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByDoorName(string doorName)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [DoorName]=@DoorName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorName = new SqlParameter("DoorName", doorName);
            pDoorName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByDoorSize(string doorSize)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [DoorSize]=@DoorSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorSize = new SqlParameter("DoorSize", doorSize);
            pDoorSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorSize);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByQty(int qty)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCabinet2DoorsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Cabinet2Door] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Cabinet2Door> LoadCabinet2Doors()
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByDoorID(Guid doorID)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [DoorID]=@DoorID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorID = new SqlParameter("DoorID", doorID);
            pDoorID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDoorID);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByDoorName(string doorName)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [DoorName]=@DoorName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorName = new SqlParameter("DoorName", doorName);
            pDoorName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorName);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByDoorSize(string doorSize)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [DoorSize]=@DoorSize";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDoorSize = new SqlParameter("DoorSize", doorSize);
            pDoorSize.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDoorSize);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByQty(int qty)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pQty);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByRemark(string remark)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByCreated(DateTime created)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByModified(DateTime modified)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<Cabinet2Door> LoadCabinet2DoorsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [DoorID]
				, [CabinetID]
				, [DoorName]
				, [DoorSize]
				, [Qty]
				, [Remark]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Cabinet2Door] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Cabinet2Door> ret = new List<Cabinet2Door>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Cabinet2Door iret = new Cabinet2Door();
                    if (!Convert.IsDBNull(dr["DoorID"]))
                        iret.DoorID = (Guid)dr["DoorID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    iret.DoorName = dr["DoorName"].ToString();
                    iret.DoorSize = dr["DoorSize"].ToString();
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (int)dr["Qty"];
                    iret.Remark = dr["Remark"].ToString();
                    if (!Convert.IsDBNull(dr["Created"]))
                        iret.Created = (DateTime)dr["Created"];
                    iret.CreatedBy = dr["CreatedBy"].ToString();
                    if (!Convert.IsDBNull(dr["Modified"]))
                        iret.Modified = (DateTime)dr["Modified"];
                    iret.ModifiedBy = dr["ModifiedBy"].ToString();
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

        #region BE_Cabinet2Door SearchObject()
        public SearchResult SearchCabinet2Door(SearchCabinet2DoorArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[CabinetID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Order].[OrderID]
                                          ,[BE_Order].[CustomerID]
                                          ,[BE_Order].[PartnerID]
                                          ,[BE_Order].[OrderNo]
                                          ,[BE_Order].[OutOrderNo]
                                          ,[BE_Order].[PurchaseNo]
                                          ,[BE_Order].[OrderType]
                                          ,[BE_Order].[CabinetType]
                                          ,[BE_Order].[CustomerName]
                                          ,[BE_Order].[Address]
                                          ,[BE_Order].[LinkMan]
                                          ,[BE_Order].[Mobile]
                                          ,[BE_Order].[BookingDate]
                                          ,[BE_Order].[ShipDate]
                                          ,[BE_Order].[Status]
                                          ,[BE_Order].[BattchNum]
                                          ,[BE_Order].[ManufactureDate]
                                          ,[BE_Order].[StepNo]
                                          ,[BE_Order].[IsStandard]
                                          ,[BE_Order].[IsOutsourcing]
                                          ,[BE_Order].[Created]
                                          ,[BE_Order].[CreatedBy]
                                          ,[BE_Order].[Modified]
                                          ,[BE_Order].[ModifiedBy]										
										  ,[BE_Partner].[PartnerName]
										  ,[BE_Customer].[Province]
										  ,[BE_Customer].[City]
										  ,[BE_Order2Cabinet].[CabinetID]
										  ,[BE_Order2Cabinet].[CabinetName]
										  ,[BE_Order2Cabinet].[Size]
										  ,[BE_Order2Cabinet].[MaterialCategory]
										  ,[BE_Order2Cabinet].[MaterialStyle]
										  ,[BE_Order2Cabinet].[Color]
										  ,[BE_Cabinet2Door].[DoorID]
										  ,[BE_Cabinet2Door].[DoorName]
										  ,[BE_Cabinet2Door].[DoorSize]
										  ,[BE_Cabinet2Door].[Qty]
										  ,[BE_Cabinet2Door].[Remark]		  									  
                                      FROM 		                                     
										   [BE_Cabinet2Door]										   
										   LEFT JOIN [BE_Order2Cabinet]  on [BE_Cabinet2Door].[CabinetID] = [BE_Order2Cabinet].[CabinetID]
										   LEFT JOIN [BE_Order]  on  [BE_Order].[OrderID] = [BE_Order2Cabinet].[OrderID]                                     
										   LEFT JOIN [BE_Partner] on [BE_Partner].[PartnerID] = [BE_Order].[PartnerID]
										   LEFT JOIN [BE_Customer] on [BE_Customer].[CustomerID] = [BE_Order].[CustomerID]										   
	                                  WHERE 1=1");


            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderID", "mbIDs", args.OrderIDs);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[OrderType", "mbOrderTypes", args.OrderTypes);
            this.SetParameters_In(mbBuilder, cmd, "BE_Order].[Status", "mbStatus", args.Status);
            if (args.DoorID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "DoorID", "mbDoorID", args.DoorID.Value);
            }
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[PartnerID", "mbPartnerID", args.PartnerID.Value);
            }
            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order2Cabinet].[CabinetID", "mbCabinetID", args.CabinetID.Value);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[CustomerID", "mbCustomerID", args.CustomerID.Value);
            }
            if (!string.IsNullOrEmpty(args.PurchaseNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[PurchaseNo", "mbPurchaseNo", args.PurchaseNo);
            }
            if (!string.IsNullOrEmpty(args.OrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OrderNo", "mbOrderNo", args.OrderNo);
            }
            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Mobile", "mbMobile", args.Mobile);
            }
            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[Address", "mbAddress", args.Address);
            }
            if (!string.IsNullOrEmpty(args.BattchNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[BattchNum", "mbBattchNum", args.BattchNo);
            }
            if (!string.IsNullOrEmpty(args.CabinetType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[CabinetType", "mbCabinetType", args.CabinetType);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }

            if (!string.IsNullOrEmpty(args.CabinetName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetName);
            }
            if (!string.IsNullOrEmpty(args.Color))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Color", "mbColor", args.Color);
            }
            if (!string.IsNullOrEmpty(args.MaterialStyle))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "MaterialStyle", "mbMaterialStyle", args.MaterialStyle);
            }

            if (args.IsOutsourcing.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsOutsourcing", "mbIsOutsourcing", args.IsOutsourcing);
            }

            if (args.IsStandard.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "IsStandard", "mbIsStandard", args.IsStandard);
            }

            if (!string.IsNullOrEmpty(args.DoorName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DoorName", "mbDoorName", args.DoorName);
            }
            if (!string.IsNullOrEmpty(args.DoorSize))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DoorSize", "mbDoorSize", args.DoorSize);
            }
            this.SetParameters_Between(mbBuilder, cmd, "BookingDate", "mbBookingDate", args.BookingDateFrom, args.BookingDateTo);
            this.SetParameters_Between(mbBuilder, cmd, "ShipDate", "mbBookingDate", args.ShipDateFrom, args.ShipDateTo);

            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
