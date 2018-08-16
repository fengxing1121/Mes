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
        
        #region BE_Package InsertObject()
        public int InsertPackage(Package obj)
        {
            string sql = @"INSERT INTO[BE_Package]([PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				) VALUES(@PackageID
				, @PackageBarcode
				, @OrderID
				, @CabinetID
				, @PackageNum
				, @PackageWidth
				, @PackageHeight
				, @PackageLength
				, @ItemsQty
				, @Weight
				, @Created
				, @CreatedBy
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", Convert2DBnull(obj.PackageID));
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            SqlParameter pPackageBarcode = new SqlParameter("PackageBarcode", Convert2DBnull(obj.PackageBarcode));
            pPackageBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageBarcode);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pPackageNum = new SqlParameter("PackageNum", Convert2DBnull(obj.PackageNum));
            pPackageNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageNum);

            SqlParameter pPackageWidth = new SqlParameter("PackageWidth", Convert2DBnull(obj.PackageWidth));
            pPackageWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageWidth);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", Convert2DBnull(obj.PackageHeight));
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            SqlParameter pPackageLength = new SqlParameter("PackageLength", Convert2DBnull(obj.PackageLength));
            pPackageLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageLength);

            SqlParameter pItemsQty = new SqlParameter("ItemsQty", Convert2DBnull(obj.ItemsQty));
            pItemsQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemsQty);

            SqlParameter pWeight = new SqlParameter("Weight", Convert2DBnull(obj.Weight));
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_Package UpdateObject()、DeleteObject()、LoadObject()
        public int UpdatePackageByPackageID(Package obj)
        {
            string sql = @"UPDATE [BE_Package] SET [PackageBarcode]=@PackageBarcode
				, [OrderID]=@OrderID
				, [CabinetID]=@CabinetID
				, [PackageNum]=@PackageNum
				, [PackageWidth]=@PackageWidth
				, [PackageHeight]=@PackageHeight
				, [PackageLength]=@PackageLength
				, [ItemsQty]=@ItemsQty
				, [Weight]=@Weight
				, [Created]=@Created
				, [CreatedBy]=@CreatedBy
 				WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageBarcode = new SqlParameter("PackageBarcode", Convert2DBnull(obj.PackageBarcode));
            pPackageBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageBarcode);

            SqlParameter pOrderID = new SqlParameter("OrderID", Convert2DBnull(obj.OrderID));
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", Convert2DBnull(obj.CabinetID));
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            SqlParameter pPackageNum = new SqlParameter("PackageNum", Convert2DBnull(obj.PackageNum));
            pPackageNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageNum);

            SqlParameter pPackageWidth = new SqlParameter("PackageWidth", Convert2DBnull(obj.PackageWidth));
            pPackageWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageWidth);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", Convert2DBnull(obj.PackageHeight));
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            SqlParameter pPackageLength = new SqlParameter("PackageLength", Convert2DBnull(obj.PackageLength));
            pPackageLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageLength);

            SqlParameter pItemsQty = new SqlParameter("ItemsQty", Convert2DBnull(obj.ItemsQty));
            pItemsQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemsQty);

            SqlParameter pWeight = new SqlParameter("Weight", Convert2DBnull(obj.Weight));
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            SqlParameter pCreated = new SqlParameter("Created", Convert2DBnull(obj.Created));
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", Convert2DBnull(obj.CreatedBy));
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            SqlParameter pPackageID = new SqlParameter("PackageID", Convert2DBnull(obj.PackageID));
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackageByPackageID(Guid packageID)
        {
            string sql = @"DELETE [BE_Package] WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadPackageByPackageID(Package obj)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
 				FROM [BE_Package] WITH(NOLOCK) WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", Convert2DBnull(obj.PackageID));
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        obj.PackageID = (Guid)dr["PackageID"];
                    obj.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        obj.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        obj.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        obj.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        obj.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        obj.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        obj.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        obj.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        obj.Weight = (decimal)dr["Weight"];
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

        #region BE_Package CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountPackages()
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByPackageID(Guid packageID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByPackageBarcode(string packageBarcode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [PackageBarcode]=@PackageBarcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageBarcode = new SqlParameter("PackageBarcode", packageBarcode);
            pPackageBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageBarcode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByOrderID(Guid orderID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByPackageNum(int packageNum)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [PackageNum]=@PackageNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageNum = new SqlParameter("PackageNum", packageNum);
            pPackageNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageNum);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByPackageWidth(decimal packageWidth)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [PackageWidth]=@PackageWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageWidth = new SqlParameter("PackageWidth", packageWidth);
            pPackageWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByPackageHeight(decimal packageHeight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByPackageLength(decimal packageLength)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [PackageLength]=@PackageLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageLength = new SqlParameter("PackageLength", packageLength);
            pPackageLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByItemsQty(int itemsQty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [ItemsQty]=@ItemsQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemsQty = new SqlParameter("ItemsQty", itemsQty);
            pItemsQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemsQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByWeight(decimal weight)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByCreated(DateTime created)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountPackagesByCreatedBy(string createdBy)
        {
            string sql = "SELECT COUNT(*) FROM [BE_Package] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsPackages()
        {
            string sql = "SELECT TOP 1 * FROM [BE_Package]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByPackageID(Guid packageID)
        {
            string sql = "SELECT TOP 1 [PackageID] FROM [BE_Package] WITH(NOLOCK) WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByPackageBarcode(string packageBarcode)
        {
            string sql = "SELECT TOP 1 [PackageBarcode] FROM [BE_Package] WITH(NOLOCK) WHERE [PackageBarcode]=@PackageBarcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageBarcode = new SqlParameter("PackageBarcode", packageBarcode);
            pPackageBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageBarcode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByOrderID(Guid orderID)
        {
            string sql = "SELECT TOP 1 [OrderID] FROM [BE_Package] WITH(NOLOCK) WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByCabinetID(Guid cabinetID)
        {
            string sql = "SELECT TOP 1 [CabinetID] FROM [BE_Package] WITH(NOLOCK) WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByPackageNum(int packageNum)
        {
            string sql = "SELECT TOP 1 [PackageNum] FROM [BE_Package] WITH(NOLOCK) WHERE [PackageNum]=@PackageNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageNum = new SqlParameter("PackageNum", packageNum);
            pPackageNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageNum);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByPackageWidth(decimal packageWidth)
        {
            string sql = "SELECT TOP 1 [PackageWidth] FROM [BE_Package] WITH(NOLOCK) WHERE [PackageWidth]=@PackageWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageWidth = new SqlParameter("PackageWidth", packageWidth);
            pPackageWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByPackageHeight(decimal packageHeight)
        {
            string sql = "SELECT TOP 1 [PackageHeight] FROM [BE_Package] WITH(NOLOCK) WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByPackageLength(decimal packageLength)
        {
            string sql = "SELECT TOP 1 [PackageLength] FROM [BE_Package] WITH(NOLOCK) WHERE [PackageLength]=@PackageLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageLength = new SqlParameter("PackageLength", packageLength);
            pPackageLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByItemsQty(int itemsQty)
        {
            string sql = "SELECT TOP 1 [ItemsQty] FROM [BE_Package] WITH(NOLOCK) WHERE [ItemsQty]=@ItemsQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemsQty = new SqlParameter("ItemsQty", itemsQty);
            pItemsQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemsQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByWeight(decimal weight)
        {
            string sql = "SELECT TOP 1 [Weight] FROM [BE_Package] WITH(NOLOCK) WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByCreated(DateTime created)
        {
            string sql = "SELECT TOP 1 [Created] FROM [BE_Package] WITH(NOLOCK) WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsPackagesByCreatedBy(string createdBy)
        {
            string sql = "SELECT TOP 1 [CreatedBy] FROM [BE_Package] WITH(NOLOCK) WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeletePackages()
        {
            string sql = "DELETE FROM [BE_Package]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByPackageID(Guid packageID)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByPackageBarcode(string packageBarcode)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [PackageBarcode]=@PackageBarcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageBarcode = new SqlParameter("PackageBarcode", packageBarcode);
            pPackageBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageBarcode);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByOrderID(Guid orderID)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByCabinetID(Guid cabinetID)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByPackageNum(int packageNum)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [PackageNum]=@PackageNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageNum = new SqlParameter("PackageNum", packageNum);
            pPackageNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageNum);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByPackageWidth(decimal packageWidth)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [PackageWidth]=@PackageWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageWidth = new SqlParameter("PackageWidth", packageWidth);
            pPackageWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByPackageHeight(decimal packageHeight)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByPackageLength(decimal packageLength)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [PackageLength]=@PackageLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageLength = new SqlParameter("PackageLength", packageLength);
            pPackageLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByItemsQty(int itemsQty)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [ItemsQty]=@ItemsQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemsQty = new SqlParameter("ItemsQty", itemsQty);
            pItemsQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemsQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByWeight(decimal weight)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByCreated(DateTime created)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            return cmd.ExecuteNonQuery();
        }
        public int DeletePackagesByCreatedBy(string createdBy)
        {
            string sql = "DELETE FROM [BE_Package] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            return cmd.ExecuteNonQuery();
        }
        public List<Package> LoadPackages()
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByPackageID(Guid packageID)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [PackageID]=@PackageID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageID = new SqlParameter("PackageID", packageID);
            pPackageID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pPackageID);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByPackageBarcode(string packageBarcode)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [PackageBarcode]=@PackageBarcode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageBarcode = new SqlParameter("PackageBarcode", packageBarcode);
            pPackageBarcode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pPackageBarcode);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByOrderID(Guid orderID)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [OrderID]=@OrderID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", orderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByCabinetID(Guid cabinetID)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [CabinetID]=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", cabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByPackageNum(int packageNum)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [PackageNum]=@PackageNum";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageNum = new SqlParameter("PackageNum", packageNum);
            pPackageNum.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pPackageNum);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByPackageWidth(decimal packageWidth)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [PackageWidth]=@PackageWidth";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageWidth = new SqlParameter("PackageWidth", packageWidth);
            pPackageWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageWidth);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByPackageHeight(decimal packageHeight)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [PackageHeight]=@PackageHeight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageHeight = new SqlParameter("PackageHeight", packageHeight);
            pPackageHeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageHeight);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByPackageLength(decimal packageLength)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [PackageLength]=@PackageLength";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pPackageLength = new SqlParameter("PackageLength", packageLength);
            pPackageLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pPackageLength);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByItemsQty(int itemsQty)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [ItemsQty]=@ItemsQty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemsQty = new SqlParameter("ItemsQty", itemsQty);
            pItemsQty.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(pItemsQty);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByWeight(decimal weight)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [Weight]=@Weight";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWeight = new SqlParameter("Weight", weight);
            pWeight.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWeight);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByCreated(DateTime created)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [Created]=@Created";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreated = new SqlParameter("Created", created);
            pCreated.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(pCreated);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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
        public List<Package> LoadPackagesByCreatedBy(string createdBy)
        {
            string sql = @"SELECT [PackageID]
				, [PackageBarcode]
				, [OrderID]
				, [CabinetID]
				, [PackageNum]
				, [PackageWidth]
				, [PackageHeight]
				, [PackageLength]
				, [ItemsQty]
				, [Weight]
				, [Created]
				, [CreatedBy]
				 FROM [BE_Package] WHERE [CreatedBy]=@CreatedBy";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCreatedBy = new SqlParameter("CreatedBy", createdBy);
            pCreatedBy.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCreatedBy);

            List<Package> ret = new List<Package>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Package iret = new Package();
                    if (!Convert.IsDBNull(dr["PackageID"]))
                        iret.PackageID = (Guid)dr["PackageID"];
                    iret.PackageBarcode = dr["PackageBarcode"].ToString();
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        iret.OrderID = (Guid)dr["OrderID"];
                    if (!Convert.IsDBNull(dr["CabinetID"]))
                        iret.CabinetID = (Guid)dr["CabinetID"];
                    if (!Convert.IsDBNull(dr["PackageNum"]))
                        iret.PackageNum = (int)dr["PackageNum"];
                    if (!Convert.IsDBNull(dr["PackageWidth"]))
                        iret.PackageWidth = (decimal)dr["PackageWidth"];
                    if (!Convert.IsDBNull(dr["PackageHeight"]))
                        iret.PackageHeight = (decimal)dr["PackageHeight"];
                    if (!Convert.IsDBNull(dr["PackageLength"]))
                        iret.PackageLength = (decimal)dr["PackageLength"];
                    if (!Convert.IsDBNull(dr["ItemsQty"]))
                        iret.ItemsQty = (int)dr["ItemsQty"];
                    if (!Convert.IsDBNull(dr["Weight"]))
                        iret.Weight = (decimal)dr["Weight"];
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

        #region BE_Package SearchObject()
        public SearchResult SearchPackage(SearchPackageArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[OrderID] ASC,[CabinetID] ASC,[PackageID] ASC,[PackageNum] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [BE_Package].[PackageID]
                                        ,[BE_Package].[PackageBarcode]
                                        ,[BE_Package].[OrderID]
                                        ,[BE_Package].[CabinetID]
                                        ,[BE_Package].[PackageNum]
                                        ,[BE_Package].[PackageWidth]
                                        ,[BE_Package].[PackageHeight]
                                        ,[BE_Package].[PackageLength]
                                        ,[BE_Package].[Weight]
                                        ,[BE_Package].[ItemsQty]
                                        ,[BE_Package].[Created]
                                        ,[BE_Package].[CreatedBy]
										,[BE_Order].[OrderNo]
										,[BE_Order].[OutOrderNo]
										,[BE_Order].[PurchaseNo]
										,[BE_Order].[CustomerID]
										,[BE_Order].[BattchNum]
										,[BE_Customer].[CustomerName]
										,[BE_Customer].[Province]
										,[BE_Customer].[City]
										,[BE_Customer].[Address]
										,[BE_Customer].[LinkMan]
										,[BE_Customer].[Mobile]
										,[BE_Customer].[Tel]
										,[BE_Order2Cabinet].[CabinetCode]
										,[BE_Order2Cabinet].[CabinetName]
										,[BE_Order2Cabinet].[Size]
										,[BE_Order2Cabinet].[Color]
										,[BE_Order2Cabinet].[MaterialStyle]
                                    FROM 
                                        [BE_Package] with(nolock)
										LEFT JOIN [BE_Order] with(nolock) on [BE_Package].[OrderID] = [BE_Order].[OrderID]
										LEFT JOIN [BE_Order2Cabinet] with(nolock) on [BE_Order2Cabinet].[CabinetID] = [BE_Package].[CabinetID]
										LEFT JOIN [BE_Customer] with(nolock) on [BE_Customer].[CustomerID] = [BE_Order].[CustomerID]
	                                WHERE 1=1");

            if (args.CabinetID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[CabinetID", "mbCabinetID", args.CabinetID);
            }
            if (args.PackageID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[PackageID", "mbPackageID", args.PackageID);
            }
            if (args.PackageNum.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[PackageNum", "mbPackageNum", args.PackageNum);
            }
            if (!string.IsNullOrEmpty(args.PackageBarcode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Package].[PackageBarcode", "mbPackageBarcode", args.PackageBarcode);
            }
            if (args.OrderID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Package].[OrderID", "mbOrderID", args.OrderID);
            }
            if (args.CustomerID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BE_Order].[CustomerID", "mbCustomerID", args.CustomerID);
            }

            if (!string.IsNullOrEmpty(args.CabinetName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetName", "mbCabinetName", args.CabinetName);
            }
            if (!string.IsNullOrEmpty(args.CustomerName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Customer].[CustomerName", "mbCustomerName", args.CustomerName);
            }
            if (!string.IsNullOrEmpty(args.BattchNo))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "BattchNo", "mbBattchNo", args.BattchNo);
            }

            if (!string.IsNullOrEmpty(args.CabinetCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "CabinetCode", "mbCabinetCode", args.CabinetCode);
            }
            if (!string.IsNullOrEmpty(args.OutOrderNo))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "BE_Order].[OutOrderNo", "mbOutOrderNo", args.OutOrderNo);
            }

            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }

        public int LoadMaxPackageNum(Guid OrderID, Guid CabinetID)
        {
            string sql = "SELECT isnull(Max(PackageNum),0) as ID FROM [BE_Package] WHERE [OrderID]=@OrderID and CabinetID=@CabinetID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pOrderID = new SqlParameter("OrderID", OrderID);
            pOrderID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pOrderID);

            SqlParameter pCabinetID = new SqlParameter("CabinetID", CabinetID);
            pCabinetID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pCabinetID);

            object objret = cmd.ExecuteScalar();
            return int.Parse(objret.ToString()) + 1;
        }
        #endregion
    }
}
