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

        #region BE_SolutionOthers InsertObject()
        public int InsertSolutionOthers(SolutionOthers obj)
        {
            string sql = @"INSERT INTO[BE_SolutionOthers]([SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				) VALUES(@SolutionID
				, @DetailID
				, @CabinetGroup
				, @ItemType
				, @ItemCode
				, @ItemName
				, @Style
				, @Length
				, @Width
				, @Qty
				, @Unit
				)";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pItemCode = new SqlParameter("ItemCode", Convert2DBnull(obj.ItemCode));
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pLength = new SqlParameter("Length", Convert2DBnull(obj.Length));
            pLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pLength);

            SqlParameter pWidth = new SqlParameter("Width", Convert2DBnull(obj.Width));
            pWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWidth);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region BE_SolutionOthers UpdateObject()、DeleteObject()、LoadObject()
        public int UpdateSolutionOthersByDetailID(SolutionOthers obj)
        {
            string sql = @"UPDATE [BE_SolutionOthers] SET [SolutionID]=@SolutionID
				, [CabinetGroup]=@CabinetGroup
				, [ItemType]=@ItemType
				, [ItemCode]=@ItemCode
				, [ItemName]=@ItemName
				, [Style]=@Style
				, [Length]=@Length
				, [Width]=@Width
				, [Qty]=@Qty
				, [Unit]=@Unit
 				WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", Convert2DBnull(obj.SolutionID));
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", Convert2DBnull(obj.CabinetGroup));
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            SqlParameter pItemType = new SqlParameter("ItemType", Convert2DBnull(obj.ItemType));
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            SqlParameter pItemCode = new SqlParameter("ItemCode", Convert2DBnull(obj.ItemCode));
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            SqlParameter pItemName = new SqlParameter("ItemName", Convert2DBnull(obj.ItemName));
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            SqlParameter pStyle = new SqlParameter("Style", Convert2DBnull(obj.Style));
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            SqlParameter pLength = new SqlParameter("Length", Convert2DBnull(obj.Length));
            pLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pLength);

            SqlParameter pWidth = new SqlParameter("Width", Convert2DBnull(obj.Width));
            pWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWidth);

            SqlParameter pQty = new SqlParameter("Qty", Convert2DBnull(obj.Qty));
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            SqlParameter pUnit = new SqlParameter("Unit", Convert2DBnull(obj.Unit));
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOthersByDetailID(Guid detailID)
        {
            string sql = @"DELETE [BE_SolutionOthers] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int LoadSolutionOthersByDetailID(SolutionOthers obj)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
 				FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", Convert2DBnull(obj.DetailID));
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            int ret = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        obj.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        obj.DetailID = (Guid)dr["DetailID"];
                    obj.CabinetGroup = dr["CabinetGroup"].ToString();
                    obj.ItemType = dr["ItemType"].ToString();
                    obj.ItemCode = dr["ItemCode"].ToString();
                    obj.ItemName = dr["ItemName"].ToString();
                    obj.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        obj.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        obj.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        obj.Qty = (decimal)dr["Qty"];
                    obj.Unit = dr["Unit"].ToString();
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

        #region BE_SolutionOthers CountObjects()、ExistsObjects()、DeleteObjects()、LoadObjects()
        public int CountSolutionOtherss()
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssBySolutionID(Guid solutionID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByDetailID(Guid detailID)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByCabinetGroup(string cabinetGroup)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByItemType(string itemType)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByItemCode(string itemCode)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByItemName(string itemName)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByStyle(string style)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByLength(decimal length)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Length]=@Length";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLength = new SqlParameter("Length", length);
            pLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pLength);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByWidth(decimal width)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Width]=@Width";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWidth = new SqlParameter("Width", width);
            pWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWidth);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByQty(decimal qty)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public int CountSolutionOtherssByUnit(string unit)
        {
            string sql = "SELECT COUNT(*) FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return (int)objret;
        }
        public bool ExistsSolutionOtherss()
        {
            string sql = "SELECT TOP 1 * FROM [BE_SolutionOthers]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssBySolutionID(Guid solutionID)
        {
            string sql = "SELECT TOP 1 [SolutionID] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByDetailID(Guid detailID)
        {
            string sql = "SELECT TOP 1 [DetailID] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByCabinetGroup(string cabinetGroup)
        {
            string sql = "SELECT TOP 1 [CabinetGroup] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByItemType(string itemType)
        {
            string sql = "SELECT TOP 1 [ItemType] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByItemCode(string itemCode)
        {
            string sql = "SELECT TOP 1 [ItemCode] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByItemName(string itemName)
        {
            string sql = "SELECT TOP 1 [ItemName] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByStyle(string style)
        {
            string sql = "SELECT TOP 1 [Style] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByLength(decimal length)
        {
            string sql = "SELECT TOP 1 [Length] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Length]=@Length";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLength = new SqlParameter("Length", length);
            pLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pLength);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByWidth(decimal width)
        {
            string sql = "SELECT TOP 1 [Width] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Width]=@Width";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWidth = new SqlParameter("Width", width);
            pWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWidth);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByQty(decimal qty)
        {
            string sql = "SELECT TOP 1 [Qty] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public bool ExistsSolutionOtherssByUnit(string unit)
        {
            string sql = "SELECT TOP 1 [Unit] FROM [BE_SolutionOthers] WITH(NOLOCK) WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            object objret = cmd.ExecuteScalar();
            return objret != null;
        }
        public int DeleteSolutionOtherss()
        {
            string sql = "DELETE FROM [BE_SolutionOthers]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssBySolutionID(Guid solutionID)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByDetailID(Guid detailID)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByCabinetGroup(string cabinetGroup)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByItemType(string itemType)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByItemCode(string itemCode)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByItemName(string itemName)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByStyle(string style)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByLength(decimal length)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [Length]=@Length";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLength = new SqlParameter("Length", length);
            pLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pLength);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByWidth(decimal width)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [Width]=@Width";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWidth = new SqlParameter("Width", width);
            pWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWidth);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByQty(decimal qty)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            return cmd.ExecuteNonQuery();
        }
        public int DeleteSolutionOtherssByUnit(string unit)
        {
            string sql = "DELETE FROM [BE_SolutionOthers] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            return cmd.ExecuteNonQuery();
        }
        public List<SolutionOthers> LoadSolutionOtherss()
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers]";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssBySolutionID(Guid solutionID)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [SolutionID]=@SolutionID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pSolutionID = new SqlParameter("SolutionID", solutionID);
            pSolutionID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pSolutionID);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByDetailID(Guid detailID)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [DetailID]=@DetailID";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pDetailID = new SqlParameter("DetailID", detailID);
            pDetailID.SqlDbType = SqlDbType.UniqueIdentifier;
            cmd.Parameters.Add(pDetailID);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByCabinetGroup(string cabinetGroup)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [CabinetGroup]=@CabinetGroup";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pCabinetGroup = new SqlParameter("CabinetGroup", cabinetGroup);
            pCabinetGroup.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pCabinetGroup);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByItemType(string itemType)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [ItemType]=@ItemType";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemType = new SqlParameter("ItemType", itemType);
            pItemType.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemType);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByItemCode(string itemCode)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [ItemCode]=@ItemCode";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemCode = new SqlParameter("ItemCode", itemCode);
            pItemCode.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemCode);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByItemName(string itemName)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [ItemName]=@ItemName";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pItemName = new SqlParameter("ItemName", itemName);
            pItemName.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pItemName);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByStyle(string style)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [Style]=@Style";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pStyle = new SqlParameter("Style", style);
            pStyle.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pStyle);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByLength(decimal length)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [Length]=@Length";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pLength = new SqlParameter("Length", length);
            pLength.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pLength);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByWidth(decimal width)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [Width]=@Width";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pWidth = new SqlParameter("Width", width);
            pWidth.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pWidth);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByQty(decimal qty)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [Qty]=@Qty";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pQty = new SqlParameter("Qty", qty);
            pQty.SqlDbType = SqlDbType.Decimal;
            cmd.Parameters.Add(pQty);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
                    ret.Add(iret);
                }
            }
            finally
            {
                dr.Close();
            }
            return ret;
        }
        public List<SolutionOthers> LoadSolutionOtherssByUnit(string unit)
        {
            string sql = @"SELECT [SolutionID]
				, [DetailID]
				, [CabinetGroup]
				, [ItemType]
				, [ItemCode]
				, [ItemName]
				, [Style]
				, [Length]
				, [Width]
				, [Qty]
				, [Unit]
				 FROM [BE_SolutionOthers] WHERE [Unit]=@Unit";
            SqlCommand cmd = new SqlCommand(sql, this.conn, this.trans);

            SqlParameter pUnit = new SqlParameter("Unit", unit);
            pUnit.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(pUnit);

            List<SolutionOthers> ret = new List<SolutionOthers>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    SolutionOthers iret = new SolutionOthers();
                    if (!Convert.IsDBNull(dr["SolutionID"]))
                        iret.SolutionID = (Guid)dr["SolutionID"];
                    if (!Convert.IsDBNull(dr["DetailID"]))
                        iret.DetailID = (Guid)dr["DetailID"];
                    iret.CabinetGroup = dr["CabinetGroup"].ToString();
                    iret.ItemType = dr["ItemType"].ToString();
                    iret.ItemCode = dr["ItemCode"].ToString();
                    iret.ItemName = dr["ItemName"].ToString();
                    iret.Style = dr["Style"].ToString();
                    if (!Convert.IsDBNull(dr["Length"]))
                        iret.Length = (decimal)dr["Length"];
                    if (!Convert.IsDBNull(dr["Width"]))
                        iret.Width = (decimal)dr["Width"];
                    if (!Convert.IsDBNull(dr["Qty"]))
                        iret.Qty = (decimal)dr["Qty"];
                    iret.Unit = dr["Unit"].ToString();
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

        #region BE_SolutionOthers SearchObject()
        public SearchResult SearchSolutionOthers(SearchSolutionOthersArgs args)
        {
            if (String.IsNullOrEmpty(args.OrderBy))
            {
                args.OrderBy = "[ItemType],[ItemCode] ASC";
            }
            SqlCommand cmd = new SqlCommand();

            StringBuilder mbBuilder = new StringBuilder();
            mbBuilder.AppendFormat("(");
            mbBuilder.AppendFormat(@"SELECT [SolutionID]
                                            ,[DetailID]
                                            ,[CabinetGroup]
                                            ,[ItemType]
                                            ,[ItemCode]
                                            ,[ItemName]
                                            ,[Style]
                                            ,[Length]
                                            ,[Width]
                                            ,[Qty]
                                            ,[Unit]
                                        FROM 
                                            [BE_SolutionOthers] with(nolock)
                                   WHERE 1=1");

            if (args.SolutionID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "SolutionID", "mbSolutionID", args.SolutionID);
            }
            if (args.DetailID.HasValue)
            {
                this.SetParameters_Equals(mbBuilder, cmd, "DetailID", "mbDetailID", args.DetailID);
            }

            if (!string.IsNullOrEmpty(args.CabinetGroup))
            {
                this.SetParameters_Equals(mbBuilder, cmd, "CabinetGroup", "mbCabinetGroup", args.CabinetGroup);
            }
            if (!string.IsNullOrEmpty(args.ItemType))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemType", "mbItemType", args.ItemType);
            }
            if (!string.IsNullOrEmpty(args.ItemCode))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemCode", "mbItemCode", args.ItemCode);
            }
            if (!string.IsNullOrEmpty(args.ItemName))
            {
                this.SetParameters_Contains(mbBuilder, cmd, "ItemName", "mbItemName", args.ItemName);
            }
            mbBuilder.AppendFormat(") mb");
            string baseSql = string.Format("(SELECT mb.* FROM {0}) baseSql", mbBuilder.ToString());
            return this.SearchBaseSqls(baseSql, cmd, args.OrderBy, args.RowNumberFrom, args.RowNumberTo);
        }
        #endregion
    }
}
