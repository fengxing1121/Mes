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

        #region BE_RoomDesigner InsertObject()
        public int InsertRoomDesigner(RoomDesigner obj)
        {
            string sql = @"INSERT INTO[BE_RoomDesigner]([DesignerID],[DesignerNo]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				) VALUES(@DesignerID,@DesignerNo
				, @CustomerID
				, @Designer
				, @Designed
				, @Rooms
				, @SittingAndDiningRoom
				, @TotalAreal
				, @FamilyMembers
				, @Budget
				, @VillageName
				, @Building
				, @Unit
				, @RoomNo
				, @Color
				, @Style
				, @Remark
				, @Status
				, @Created
				, @CreatedBy
				, @Modified
				, @ModifiedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            SqlParameter pDesignerNo = new SqlParameter("DesignerNo", Convert2DBnull(obj.DesignerNo));
            pDesignerNo.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pDesignerNo);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pDesigner = new SqlParameter("Designer", Convert2DBnull(obj.Designer));
            pDesigner.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesigner);

            SqlParameter pDesigned = new SqlParameter("Designed", Convert2DBnull(obj.Designed));
            pDesigned.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pDesigned);

            SqlParameter pRooms = new SqlParameter("Rooms", Convert2DBnull(obj.Rooms));
            pRooms.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pRooms);

            SqlParameter pSittingAndDiningRoom = new SqlParameter("SittingAndDiningRoom", Convert2DBnull(obj.SittingAndDiningRoom));
            pSittingAndDiningRoom.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSittingAndDiningRoom);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pFamilyMembers = new SqlParameter("FamilyMembers", Convert2DBnull(obj.FamilyMembers));
            pFamilyMembers.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pFamilyMembers);

            SqlParameter pBudget = new SqlParameter("Budget", Convert2DBnull(obj.Budget));
            pBudget.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pBudget);

            SqlParameter pVillageName = new SqlParameter("VillageName", Convert2DBnull(obj.VillageName));
            pVillageName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVillageName);

            SqlParameter pBuilding = new SqlParameter("Building", Convert2DBnull(obj.Building));
            pBuilding.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBuilding);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pRoomNo = new SqlParameter("RoomNo", Convert2DBnull(obj.RoomNo));
            pRoomNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoomNo);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

        #region BE_RoomDesigner UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateRoomDesignerByDesignerID(RoomDesigner obj)
        {
            string sql = @"UPDATE [BE_RoomDesigner] SET [CustomerID]=@CustomerID
				, [Designer]=@Designer
				, [Designed]=@Designed
				, [Rooms]=@Rooms
				, [SittingAndDiningRoom]=@SittingAndDiningRoom
				, [TotalAreal]=@TotalAreal
				, [FamilyMembers]=@FamilyMembers
				, [Budget]=@Budget
				, [VillageName]=@VillageName
				, [Building]=@Building
				, [Unit]=@Unit
				, [RoomNo]=@RoomNo
				, [Color]=@Color
				, [Style]=@Style
				, [Remark]=@Remark
				, [Status]=@Status
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
				, [Modified]=@Modified
				, [ModifiedBy]=@ModifiedBy
 				WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", Convert2DBnull(obj.CustomerID));
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pDesigner = new SqlParameter("Designer", Convert2DBnull(obj.Designer));
            pDesigner.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesigner);

            SqlParameter pDesigned = new SqlParameter("Designed", Convert2DBnull(obj.Designed));
            pDesigned.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pDesigned);

            SqlParameter pRooms = new SqlParameter("Rooms", Convert2DBnull(obj.Rooms));
            pRooms.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pRooms);

            SqlParameter pSittingAndDiningRoom = new SqlParameter("SittingAndDiningRoom", Convert2DBnull(obj.SittingAndDiningRoom));
            pSittingAndDiningRoom.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSittingAndDiningRoom);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", Convert2DBnull(obj.TotalAreal));
            pTotalAreal.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalAreal);

            SqlParameter pFamilyMembers = new SqlParameter("FamilyMembers", Convert2DBnull(obj.FamilyMembers));
            pFamilyMembers.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pFamilyMembers);

            SqlParameter pBudget = new SqlParameter("Budget", Convert2DBnull(obj.Budget));
            pBudget.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pBudget);

            SqlParameter pVillageName = new SqlParameter("VillageName", Convert2DBnull(obj.VillageName));
            pVillageName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVillageName);

            SqlParameter pBuilding = new SqlParameter("Building", Convert2DBnull(obj.Building));
            pBuilding.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBuilding);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pRoomNo = new SqlParameter("RoomNo", Convert2DBnull(obj.RoomNo));
            pRoomNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoomNo);

            SqlParameter pColor = new SqlParameter("Color", Convert2DBnull(obj.Color));
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pRemark = new SqlParameter("Remark", Convert2DBnull(obj.Remark));
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            SqlParameter pStatus = new SqlParameter("Status", Convert2DBnull(obj.Status));
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

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

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignerByDesignerID(Guid designerID)
        {
            string sql = @"DELETE [BE_RoomDesigner] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }

        public int LoadRoomDesignerByDesignerID(RoomDesigner obj)
        {
            string sql = @"SELECT [DesignerID]
                ,[DesignerNo]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
 				FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", Convert2DBnull(obj.DesignerID));
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        obj.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        obj.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        obj.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        obj.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        obj.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        obj.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        obj.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        obj.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        obj.Budget = (decimal)dr["Budget"];



                    obj.DesignerNo = dr["DesignerNo"].ToString();
                    obj.VillageName = dr["VillageName"].ToString();
                    obj.Building = dr["Building"].ToString();
                    obj.Unit = dr["Unit"].ToString();
                    obj.RoomNo = dr["RoomNo"].ToString();
                    obj.Color = dr["Color"].ToString();
                    obj.Style = dr["Style"].ToString();
                    obj.Remark = dr["Remark"].ToString();
                    obj.Status = dr["Status"].ToString();
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

        #region BE_RoomDesigner CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountRoomDesigners()
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByDesignerID(Guid designerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByCustomerID(Guid customerID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByDesigner(Guid designer)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesigner);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByDesigned(DateTime designed)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Designed]=@Designed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigned = new SqlParameter("Designed", designed);
            pDesigned.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pDesigned);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByRooms(int rooms)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Rooms]=@Rooms";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRooms = new SqlParameter("Rooms", rooms);
            pRooms.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pRooms);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersBySittingAndDiningRoom(int sittingAndDiningRoom)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [SittingAndDiningRoom]=@SittingAndDiningRoom";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSittingAndDiningRoom = new SqlParameter("SittingAndDiningRoom", sittingAndDiningRoom);
            pSittingAndDiningRoom.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSittingAndDiningRoom);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByTotalAreal(int totalAreal)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByFamilyMembers(int familyMembers)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [FamilyMembers]=@FamilyMembers";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFamilyMembers = new SqlParameter("FamilyMembers", familyMembers);
            pFamilyMembers.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pFamilyMembers);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByBudget(decimal budget)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Budget]=@Budget";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBudget = new SqlParameter("Budget", budget);
            pBudget.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pBudget);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByVillageName(string villageName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [VillageName]=@VillageName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVillageName = new SqlParameter("VillageName", villageName);
            pVillageName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVillageName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByBuilding(string building)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Building]=@Building";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBuilding = new SqlParameter("Building", building);
            pBuilding.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBuilding);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByRoomNo(string roomNo)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [RoomNo]=@RoomNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoomNo = new SqlParameter("RoomNo", roomNo);
            pRoomNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoomNo);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByColor(string color)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByRemark(string remark)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByStatus(string status)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByModified(DateTime modified)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountRoomDesignersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsRoomDesigners()
        {
            string sql = "SELECT TOP 1 * FROM [BE_RoomDesigner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByDesignerID(Guid designerID)
        {
            string sql = "SELECT TOP 1 [DesignerID] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByCustomerID(Guid customerID)
        {
            string sql = "SELECT TOP 1 [CustomerID] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByDesigner(Guid designer)
        {
            string sql = "SELECT TOP 1 [Designer] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesigner);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByDesigned(DateTime designed)
        {
            string sql = "SELECT TOP 1 [Designed] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Designed]=@Designed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigned = new SqlParameter("Designed", designed);
            pDesigned.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pDesigned);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByRooms(int rooms)
        {
            string sql = "SELECT TOP 1 [Rooms] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Rooms]=@Rooms";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRooms = new SqlParameter("Rooms", rooms);
            pRooms.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pRooms);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByDesignerNo(int designerNo)
        {
            string sql = "SELECT TOP 1 [DesignerNo] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [DesignerNo]=@DesignerNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerNo = new SqlParameter("DesignerNo", designerNo);
            pDesignerNo.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pDesignerNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }

        public bool ExistsRoomDesignersBySittingAndDiningRoom(int sittingAndDiningRoom)
        {
            string sql = "SELECT TOP 1 [SittingAndDiningRoom] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [SittingAndDiningRoom]=@SittingAndDiningRoom";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSittingAndDiningRoom = new SqlParameter("SittingAndDiningRoom", sittingAndDiningRoom);
            pSittingAndDiningRoom.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSittingAndDiningRoom);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByTotalAreal(int totalAreal)
        {
            string sql = "SELECT TOP 1 [TotalAreal] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalAreal);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByFamilyMembers(int familyMembers)
        {
            string sql = "SELECT TOP 1 [FamilyMembers] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [FamilyMembers]=@FamilyMembers";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFamilyMembers = new SqlParameter("FamilyMembers", familyMembers);
            pFamilyMembers.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pFamilyMembers);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByBudget(decimal budget)
        {
            string sql = "SELECT TOP 1 [Budget] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Budget]=@Budget";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBudget = new SqlParameter("Budget", budget);
            pBudget.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pBudget);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByVillageName(string villageName)
        {
            string sql = "SELECT TOP 1 [VillageName] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [VillageName]=@VillageName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVillageName = new SqlParameter("VillageName", villageName);
            pVillageName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVillageName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByBuilding(string building)
        {
            string sql = "SELECT TOP 1 [Building] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Building]=@Building";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBuilding = new SqlParameter("Building", building);
            pBuilding.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBuilding);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByRoomNo(string roomNo)
        {
            string sql = "SELECT TOP 1 [RoomNo] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [RoomNo]=@RoomNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoomNo = new SqlParameter("RoomNo", roomNo);
            pRoomNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoomNo);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByColor(string color)
        {
            string sql = "SELECT TOP 1 [Color] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByRemark(string remark)
        {
            string sql = "SELECT TOP 1 [Remark] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByStatus(string status)
        {
            string sql = "SELECT TOP 1 [Status] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByModified(DateTime modified)
        {
            string sql = "SELECT TOP 1 [Modified] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsRoomDesignersByModifiedBy(string modifiedBy)
        {
            string sql = "SELECT TOP 1 [ModifiedBy] FROM [BE_RoomDesigner] WITH(NOLOCK) WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteRoomDesigners()
        {
            string sql = "DELETE FROM [BE_RoomDesigner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByDesignerID(Guid designerID)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByCustomerID(Guid customerID)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByDesigner(Guid designer)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesigner);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByDesigned(DateTime designed)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Designed]=@Designed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigned = new SqlParameter("Designed", designed);
            pDesigned.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pDesigned);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByRooms(int rooms)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Rooms]=@Rooms";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRooms = new SqlParameter("Rooms", rooms);
            pRooms.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pRooms);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersBySittingAndDiningRoom(int sittingAndDiningRoom)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [SittingAndDiningRoom]=@SittingAndDiningRoom";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSittingAndDiningRoom = new SqlParameter("SittingAndDiningRoom", sittingAndDiningRoom);
            pSittingAndDiningRoom.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSittingAndDiningRoom);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByTotalAreal(int totalAreal)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalAreal);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByFamilyMembers(int familyMembers)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [FamilyMembers]=@FamilyMembers";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFamilyMembers = new SqlParameter("FamilyMembers", familyMembers);
            pFamilyMembers.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pFamilyMembers);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByBudget(decimal budget)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Budget]=@Budget";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBudget = new SqlParameter("Budget", budget);
            pBudget.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pBudget);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByVillageName(string villageName)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [VillageName]=@VillageName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVillageName = new SqlParameter("VillageName", villageName);
            pVillageName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVillageName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByBuilding(string building)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Building]=@Building";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBuilding = new SqlParameter("Building", building);
            pBuilding.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBuilding);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByRoomNo(string roomNo)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [RoomNo]=@RoomNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoomNo = new SqlParameter("RoomNo", roomNo);
            pRoomNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoomNo);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByColor(string color)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByStyle(string style)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByRemark(string remark)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByStatus(string status)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByModified(DateTime modified)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteRoomDesignersByModifiedBy(string modifiedBy)
        {
            string sql = "DELETE FROM [BE_RoomDesigner] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<RoomDesigner> LoadRoomDesigners()
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByDesignerID(Guid designerID)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [DesignerID]=@DesignerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesignerID = new SqlParameter("DesignerID", designerID);
            pDesignerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesignerID);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByCustomerID(Guid customerID)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [CustomerID]=@CustomerID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCustomerID = new SqlParameter("CustomerID", customerID);
            pCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCustomerID);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByDesigner(Guid designer)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Designer]=@Designer";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigner = new SqlParameter("Designer", designer);
            pDesigner.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDesigner);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByDesigned(DateTime designed)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Designed]=@Designed";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDesigned = new SqlParameter("Designed", designed);
            pDesigned.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pDesigned);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByRooms(int rooms)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Rooms]=@Rooms";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRooms = new SqlParameter("Rooms", rooms);
            pRooms.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pRooms);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersBySittingAndDiningRoom(int sittingAndDiningRoom)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [SittingAndDiningRoom]=@SittingAndDiningRoom";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSittingAndDiningRoom = new SqlParameter("SittingAndDiningRoom", sittingAndDiningRoom);
            pSittingAndDiningRoom.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pSittingAndDiningRoom);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByTotalAreal(int totalAreal)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [TotalAreal]=@TotalAreal";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pTotalAreal = new SqlParameter("TotalAreal", totalAreal);
            pTotalAreal.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pTotalAreal);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByFamilyMembers(int familyMembers)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [FamilyMembers]=@FamilyMembers";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pFamilyMembers = new SqlParameter("FamilyMembers", familyMembers);
            pFamilyMembers.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pFamilyMembers);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByBudget(decimal budget)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Budget]=@Budget";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBudget = new SqlParameter("Budget", budget);
            pBudget.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pBudget);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByVillageName(string villageName)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [VillageName]=@VillageName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pVillageName = new SqlParameter("VillageName", villageName);
            pVillageName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pVillageName);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByBuilding(string building)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Building]=@Building";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pBuilding = new SqlParameter("Building", building);
            pBuilding.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pBuilding);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByUnit(string unit)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByRoomNo(string roomNo)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [RoomNo]=@RoomNo";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRoomNo = new SqlParameter("RoomNo", roomNo);
            pRoomNo.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRoomNo);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByColor(string color)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Color]=@Color";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pColor = new SqlParameter("Color", color);
            pColor.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pColor);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByStyle(string style)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByRemark(string remark)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Remark]=@Remark";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pRemark = new SqlParameter("Remark", remark);
            pRemark.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pRemark);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByStatus(string status)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Status]=@Status";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStatus = new SqlParameter("Status", status);
            pStatus.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(pStatus);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByCreated(DateTime created)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByModified(DateTime modified)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [Modified]=@Modified";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModified = new SqlParameter("Modified", modified);
            pModified.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pModified);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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
        public List<RoomDesigner> LoadRoomDesignersByModifiedBy(string modifiedBy)
        {
            string sql = @"SELECT [DesignerID]
				, [CustomerID]
				, [Designer]
				, [Designed]
				, [Rooms]
				, [SittingAndDiningRoom]
				, [TotalAreal]
				, [FamilyMembers]
				, [Budget]
				, [VillageName]
				, [Building]
				, [Unit]
				, [RoomNo]
				, [Color]
				, [Style]
				, [Remark]
				, [Status]
				, [Created]
				, [CreatedBy]
				, [Modified]
				, [ModifiedBy]
				 FROM [BE_RoomDesigner] WHERE [ModifiedBy]=@ModifiedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pModifiedBy = new SqlParameter("ModifiedBy", modifiedBy);
            pModifiedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pModifiedBy);

            List<RoomDesigner> ret = new List<RoomDesigner>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    RoomDesigner iret = new RoomDesigner();
                    if (!Convert.IsDBNull(dr["DesignerID"]))
                        iret.DesignerID = (Guid)dr["DesignerID"];
                    if (!Convert.IsDBNull(dr["CustomerID"]))
                        iret.CustomerID = (Guid)dr["CustomerID"];
                    if (!Convert.IsDBNull(dr["Designer"]))
                        iret.Designer = (Guid)dr["Designer"];
                    if (!Convert.IsDBNull(dr["Designed"]))
                        iret.Designed = (DateTime)dr["Designed"];
                    if (!Convert.IsDBNull(dr["Rooms"]))
                        iret.Rooms = (int)dr["Rooms"];
                    if (!Convert.IsDBNull(dr["SittingAndDiningRoom"]))
                        iret.SittingAndDiningRoom = (int)dr["SittingAndDiningRoom"];
                    if (!Convert.IsDBNull(dr["TotalAreal"]))
                        iret.TotalAreal = (int)dr["TotalAreal"];
                    if (!Convert.IsDBNull(dr["FamilyMembers"]))
                        iret.FamilyMembers = (int)dr["FamilyMembers"];
                    if (!Convert.IsDBNull(dr["Budget"]))
                        iret.Budget = (decimal)dr["Budget"];
                    iret.VillageName = dr["VillageName"].ToString();
                    iret.Building = dr["Building"].ToString();
                    iret.Unit = dr["Unit"].ToString();
                    iret.RoomNo = dr["RoomNo"].ToString();
                    iret.Color = dr["Color"].ToString();
                    iret.Style = dr["Style"].ToString();
                    iret.Remark = dr["Remark"].ToString();
                    iret.Status = dr["Status"].ToString();
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

        #region BE_RoomDesigner SearchObject()
        public SearchResult SearchRoomDesigner(SearchRoomDesignerArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[BE_Customer].[PartnerID],[BE_RoomDesigner].[CustomerID] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_RoomDesigner].[DesignerID]
                                          ,[BE_RoomDesigner].[CustomerID]
                                          ,[BE_RoomDesigner].[DesignerNo]
                                          ,[Designer]
										  ,[UserName]
                                          ,[Designed]
                                          ,[Rooms]
                                          ,[SittingAndDiningRoom]
                                          ,[TotalAreal]
                                          ,[FamilyMembers]
                                          ,[Budget]
                                          ,[VillageName]
                                          ,[Building]
                                          ,[Unit]
                                          ,[RoomNo]
                                          ,[Color]
                                          ,[Style]
                                          ,[BE_RoomDesigner].[Remark]
                                          ,[BE_RoomDesigner].[Status]
                                          ,[BE_RoomDesigner].[Created]
                                          ,[BE_RoomDesigner].[CreatedBy]
                                          ,[BE_RoomDesigner].[Modified]
                                          ,[BE_RoomDesigner].[ModifiedBy]
	                                      ,[BE_Customer].[CustomerName]
	                                      ,[BE_Customer].[PartnerID]
	                                      ,[BE_Partner].[PartnerName]
                                      FROM 
	                                     [BE_RoomDesigner] with(nolock)
	                                     LEFT JOIN [BE_Customer] with(nolock) on [BE_RoomDesigner].[CustomerID] = [BE_Customer].[CustomerID]
	                                     LEFT JOIN [BE_Partner] with(nolock) on [BE_Partner].[PartnerID] = [BE_Customer].[PartnerID]
										 LEFT JOIN [BE_PartnerUser] with(nolock) on [BE_RoomDesigner].[Designer] = [BE_PartnerUser].[UserID]
	                                  WHERE 1=1");


            if (!string.IsNullOrEmpty(args.Building))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Building", "mbBuilding", args.Building);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.PartnerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "PartnerName", "mbPartnerName", args.PartnerName);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_RoomDesigner].[CustomerID", "mCustomerID", args.CustomerID.Value);
            }
            if (args.DesignerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_RoomDesigner].[DesignerID", "mDesignerID", args.DesignerID.Value);
            }
            //if (args.DesignerNo.ToString().Length!=-1)
            //{
            //    this.SetParameters_Equals(mbBuilder, cmd, "BE_RoomDesigner].[DesignerNo", "DesignerNo", args.DesignerNo);
            //}
            if (args.PartnerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Customer].[PartnerID", "mPartnerID", args.PartnerID.Value);
            }
            if (!string.IsNullOrEmpty(args.VillageName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "VillageName", "mbVillageName", args.VillageName);
            }
            if (!string.IsNullOrEmpty(args.Designer))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "Designer", "mbDesigner", args.Designer);
            }
            if (!string.IsNullOrEmpty(args.DesignerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "UserName", "mbDesignerName", args.DesignerName);
            }

            this.SetParameters_In(mbBuilder, cmd, "Status", "mbStatus", args.Status);
            this.SetParameters_Between(mbBuilder, cmd, "Designed", "mbDesigned", args.DesignedFrom, args.DesignedTo);
            mbBuilder.AppendFormat(") mb");

            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
