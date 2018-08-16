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
       
        #region BE_Car InsertObject()
        public int InsertCar(Car obj)
        {
            string sql = @"INSERT INTO[BE_Car]([CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@CarID
				, @EnterpriseID
				, @PlateNo
				, @CarName
				, @CarStyle
				, @DriverName
				, @Mobile
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", Convert2DBnull(obj.CarID));
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", Convert2DBnull(obj.EnterpriseID));
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", Convert2DBnull(obj.PlateNo));
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            SqlParameter pCarName = new SqlParameter("CarName", Convert2DBnull(obj.CarName));
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", Convert2DBnull(obj.CarStyle));
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            SqlParameter pDriverName = new SqlParameter("DriverName", Convert2DBnull(obj.DriverName));
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

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

        #region BE_Car UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateCarByPlateNo(Car obj)
        {
            string sql = @"UPDATE [BE_Car] SET [CarID]=@CarID
				, [EnterpriseID]=@EnterpriseID
				, [CarName]=@CarName
				, [CarStyle]=@CarStyle
				, [DriverName]=@DriverName
				, [Mobile]=@Mobile
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", Convert2DBnull(obj.CarID));
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", Convert2DBnull(obj.EnterpriseID));
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            SqlParameter pCarName = new SqlParameter("CarName", Convert2DBnull(obj.CarName));
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", Convert2DBnull(obj.CarStyle));
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            SqlParameter pDriverName = new SqlParameter("DriverName", Convert2DBnull(obj.DriverName));
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

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

            SqlParameter pPlateNo = new SqlParameter("PlateNo", Convert2DBnull(obj.PlateNo));
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            return cmd.ExecuteNonQuery();
        }
        public int UpdateCarByCarID(Car obj)
        {
            string sql = @"UPDATE [BE_Car] SET [EnterpriseID]=@EnterpriseID
				, [PlateNo]=@PlateNo
				, [CarName]=@CarName
				, [CarStyle]=@CarStyle
				, [DriverName]=@DriverName
				, [Mobile]=@Mobile
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", Convert2DBnull(obj.EnterpriseID));
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", Convert2DBnull(obj.PlateNo));
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            SqlParameter pCarName = new SqlParameter("CarName", Convert2DBnull(obj.CarName));
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", Convert2DBnull(obj.CarStyle));
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            SqlParameter pDriverName = new SqlParameter("DriverName", Convert2DBnull(obj.DriverName));
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            SqlParameter pMobile = new SqlParameter("Mobile", Convert2DBnull(obj.Mobile));
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

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

            SqlParameter pCarID = new SqlParameter("CarID", Convert2DBnull(obj.CarID));
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarByPlateNo(string plateNo)
        {
            string sql = @"DELETE [BE_Car] WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", plateNo);
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarByCarID(Guid carID)
        {
            string sql = @"DELETE [BE_Car] WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadCarByPlateNo(Car obj)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Car] WITH(NOLOCK) WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", Convert2DBnull(obj.PlateNo));
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CarID"]))
                        obj.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        obj.EnterpriseID = (Guid)dr["EnterpriseID"];
                    obj.PlateNo = dr["PlateNo"].ToString();
                    obj.CarName = dr["CarName"].ToString();
                    obj.CarStyle = dr["CarStyle"].ToString();
                    obj.DriverName = dr["DriverName"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
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
        public int LoadCarByCarID(Car obj)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_Car] WITH(NOLOCK) WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", Convert2DBnull(obj.CarID));
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["CarID"]))
                        obj.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        obj.EnterpriseID = (Guid)dr["EnterpriseID"];
                    obj.PlateNo = dr["PlateNo"].ToString();
                    obj.CarName = dr["CarName"].ToString();
                    obj.CarStyle = dr["CarStyle"].ToString();
                    obj.DriverName = dr["DriverName"].ToString();
                    obj.Mobile = dr["Mobile"].ToString();
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

        #region BE_Car CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountCars()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByCarID(Guid carID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByEnterpriseID(Guid enterpriseID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByPlateNo(string plateNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", plateNo);
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByCarName(string carName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [CarName]=@CarName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarName = new SqlParameter("CarName", carName);
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByCarStyle(string carStyle)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [CarStyle]=@CarStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", carStyle);
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByDriverName(string driverName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [DriverName]=@DriverName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDriverName = new SqlParameter("DriverName", driverName);
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByMobile(string mobile)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountCarsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Car] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsCars()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Car]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByCarID(Guid carID)
        {
            string sql = "SELECT TOP 1 [CarID] FROM [BE_Car] WITH(NOLOCK) WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByEnterpriseID(Guid enterpriseID)
        {
            string sql = "SELECT TOP 1 [EnterpriseID] FROM [BE_Car] WITH(NOLOCK) WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByPlateNo(string plateNo)
        {
            string sql = "SELECT TOP 1 [PlateNo] FROM [BE_Car] WITH(NOLOCK) WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", plateNo);
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByCarName(string carName)
        {
            string sql = "SELECT TOP 1 [CarName] FROM [BE_Car] WITH(NOLOCK) WHERE [CarName]=@CarName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarName = new SqlParameter("CarName", carName);
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByCarStyle(string carStyle)
        {
            string sql = "SELECT TOP 1 [CarStyle] FROM [BE_Car] WITH(NOLOCK) WHERE [CarStyle]=@CarStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", carStyle);
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByDriverName(string driverName)
        {
            string sql = "SELECT TOP 1 [DriverName] FROM [BE_Car] WITH(NOLOCK) WHERE [DriverName]=@DriverName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDriverName = new SqlParameter("DriverName", driverName);
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByMobile(string mobile)
        {
            string sql = "SELECT TOP 1 [Mobile] FROM [BE_Car] WITH(NOLOCK) WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Car] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Car] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_Car] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsCarsByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_Car] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteCars()
        {
            string sql = "DELETE FROM [BE_Car]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByCarID(Guid carID)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByEnterpriseID(Guid enterpriseID)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByPlateNo(string plateNo)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", plateNo);
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByCarName(string carName)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [CarName]=@CarName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarName = new SqlParameter("CarName", carName);
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByCarStyle(string carStyle)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [CarStyle]=@CarStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", carStyle);
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByDriverName(string driverName)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [DriverName]=@DriverName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDriverName = new SqlParameter("DriverName", driverName);
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByMobile(string mobile)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteCarsByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_Car] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Car> LoadCars()
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByCarID(Guid carID)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [CarID]=@CarID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarID = new SqlParameter("CarID", carID);
            pCarID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCarID);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByEnterpriseID(Guid enterpriseID)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [EnterpriseID]=@EnterpriseID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pEnterpriseID = new SqlParameter("EnterpriseID", enterpriseID);
            pEnterpriseID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pEnterpriseID);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByPlateNo(string plateNo)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [PlateNo]=@PlateNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPlateNo = new SqlParameter("PlateNo", plateNo);
            pPlateNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPlateNo);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByCarName(string carName)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [CarName]=@CarName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarName = new SqlParameter("CarName", carName);
            pCarName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarName);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByCarStyle(string carStyle)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [CarStyle]=@CarStyle";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCarStyle = new SqlParameter("CarStyle", carStyle);
            pCarStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCarStyle);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByDriverName(string driverName)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [DriverName]=@DriverName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDriverName = new SqlParameter("DriverName", driverName);
            pDriverName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pDriverName);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByMobile(string mobile)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [Mobile]=@Mobile";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pMobile = new SqlParameter("Mobile", mobile);
            pMobile.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pMobile);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByCreated(DateTime created)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByModified(DateTime modified)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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
        public List<Car> LoadCarsByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [CarID]
				, [EnterpriseID]
				, [PlateNo]
				, [CarName]
				, [CarStyle]
				, [DriverName]
				, [Mobile]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_Car] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<Car> ret = new List<Car>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Car iret = new Car();
                    if (!Convert.IsDBNull(dr["CarID"]))
                        iret.CarID = (Guid)dr["CarID"];
                    if (!Convert.IsDBNull(dr["EnterpriseID"]))
                        iret.EnterpriseID = (Guid)dr["EnterpriseID"];
                    iret.PlateNo = dr["PlateNo"].ToString();
                    iret.CarName = dr["CarName"].ToString();
                    iret.CarStyle = dr["CarStyle"].ToString();
                    iret.DriverName = dr["DriverName"].ToString();
                    iret.Mobile = dr["Mobile"].ToString();
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

        #region BE_Car SearchObject()
        public SearchResult SearchCar(SearchCarArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[EnterpriseName] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Car].[EnterpriseID]
                                          ,[EnterpriseName]
                                          ,[BE_Car].[CarID]										
										  ,[BE_Car].[PlateNo]
										  ,[BE_Car].[CarName]
										  ,[BE_Car].[CarStyle]
										  ,[BE_Car].[DriverName]
										  ,[BE_Car].[Mobile]
										  ,[BE_Car].[Created]
										  ,[BE_Car].[CreatedBy]
										  ,[BE_Car].[Modified]
										  ,[BE_Car].[ModifiedBy]
                                      FROM 
											[BE_Car]  with(nolock)
											LEFT JOIN [BE_LogisticsEnterprise] with(nolock) on [BE_Car].[EnterpriseID] = [BE_LogisticsEnterprise].[EnterpriseID]									   
                                      WHERE 1=1");

            if (args.CarID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "CarID", "mbCarID", args.CarID.Value);
            }

            if (!string.IsNullOrEmpty(args.EnterpriseName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "EnterpriseName", "mbEnterpriseName", args.EnterpriseName);
            }

            if (!string.IsNullOrEmpty(args.Address))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Address", "mbAddress", args.Address);
            }

            if (!string.IsNullOrEmpty(args.Mobile))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Car].[Mobile", "mbMobile", args.Mobile);
            }

            if (!string.IsNullOrEmpty(args.Tel))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Tel", "mbTel", args.Tel);
            }

            if (!string.IsNullOrEmpty(args.LinkMan))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "LinkMan", "mbLinkMan", args.LinkMan);
            }

            if (!string.IsNullOrEmpty(args.PlateNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PlateNo", "mbPlateNo", args.PlateNo);
            }

            if (!string.IsNullOrEmpty(args.DriverName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "DriverName", "mbDriverName", args.DriverName);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
