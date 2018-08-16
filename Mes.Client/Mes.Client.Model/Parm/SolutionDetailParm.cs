using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-04-06 21:37:39。
	/// </summary>
	public class SolutionDetailParm
	{
		private HttpContext _context;
		public SolutionDetailParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid CompanyID
		{
			get { return Guid.Parse(_context.Request["CompanyID"]);}
			set { this.companyID = value; }
		}
		private Guid companyID;
		
		///<summary>
		///子订单ID
		///</summary>
		public Guid ItemID
		{
			get { return Guid.Parse(_context.Request["ItemID"]);}
			set { this.itemID = value; }
		}
		private Guid itemID;
		
		///<summary>
		///部件名称
		///</summary>
		public string ItemName
		{
			get { return Convert.ToString(_context.Request["ItemName"]);}
			set { this.itemName = value; }
		}
		private string itemName;
		
		///<summary>
		///部件类型,B：板件，G：玻璃，I：铝材，D：移门，门板
		///</summary>
		public string ItemType
		{
			get { return Convert.ToString(_context.Request["ItemType"]);}
			set { this.itemType = value; }
		}
		private string itemType;
		
		///<summary>
		///板件条码
		///</summary>
		public string BarcodeNo
		{
			get { return Convert.ToString(_context.Request["BarcodeNo"]);}
			set { this.barcodeNo = value; }
		}
		private string barcodeNo;
		
		///<summary>
		///订单ID
		///</summary>
		public Guid SolutionID
		{
			get { return Guid.Parse(_context.Request["SolutionID"]);}
			set { this.solutionID = value; }
		}
		private Guid solutionID;
		
		///<summary>
		///
		///</summary>
		public Guid CabinetID
		{
			get { return Guid.Parse(_context.Request["CabinetID"]);}
			set { this.cabinetID = value; }
		}
		private Guid cabinetID;
		
		///<summary>
		///纹理方向
		///</summary>
		public string TextureDirection
		{
			get { return Convert.ToString(_context.Request["TextureDirection"]);}
			set { this.textureDirection = value; }
		}
		private string textureDirection;
		
		///<summary>
		///开孔信息
		///</summary>
		public string HoleDesc
		{
			get { return Convert.ToString(_context.Request["HoleDesc"]);}
			set { this.holeDesc = value; }
		}
		private string holeDesc;
		
		///<summary>
		///开料宽度
		///</summary>
		public decimal MadeWidth
		{
			get { return Convert.ToDecimal(_context.Request["MadeWidth"]);}
			set { this.madeWidth = value; }
		}
		private decimal madeWidth;
		
		///<summary>
		///开料高度
		///</summary>
		public decimal MadeHeight
		{
			get { return Convert.ToDecimal(_context.Request["MadeHeight"]);}
			set { this.madeHeight = value; }
		}
		private decimal madeHeight;
		
		///<summary>
		///开料长度
		///</summary>
		public decimal MadeLength
		{
			get { return Convert.ToDecimal(_context.Request["MadeLength"]);}
			set { this.madeLength = value; }
		}
		private decimal madeLength;
		
		///<summary>
		///成品宽度
		///</summary>
		public decimal EndWidth
		{
			get { return Convert.ToDecimal(_context.Request["EndWidth"]);}
			set { this.endWidth = value; }
		}
		private decimal endWidth;
		
		///<summary>
		///成品长度
		///</summary>
		public decimal EndLength
		{
			get { return Convert.ToDecimal(_context.Request["EndLength"]);}
			set { this.endLength = value; }
		}
		private decimal endLength;
		
		///<summary>
		///数量
		///</summary>
		public decimal Qty
		{
			get { return Convert.ToDecimal(_context.Request["Qty"]);}
			set { this.qty = value; }
		}
		private decimal qty;
		
		///<summary>
		///正面标签
		///</summary>
		public string FrontLabel
		{
			get { return Convert.ToString(_context.Request["FrontLabel"]);}
			set { this.frontLabel = value; }
		}
		private string frontLabel;
		
		///<summary>
		///反面标签
		///</summary>
		public string BackLabel
		{
			get { return Convert.ToString(_context.Request["BackLabel"]);}
			set { this.backLabel = value; }
		}
		private string backLabel;
		
		///<summary>
		///备注
		///</summary>
		public string Remarks
		{
			get { return Convert.ToString(_context.Request["Remarks"]);}
			set { this.remarks = value; }
		}
		private string remarks;
		
		///<summary>
		///封边1
		///</summary>
		public string Edge1
		{
			get { return Convert.ToString(_context.Request["Edge1"]);}
			set { this.edge1 = value; }
		}
		private string edge1;
		
		///<summary>
		///封边2
		///</summary>
		public string Edge2
		{
			get { return Convert.ToString(_context.Request["Edge2"]);}
			set { this.edge2 = value; }
		}
		private string edge2;
		
		///<summary>
		///封边3
		///</summary>
		public string Edge3
		{
			get { return Convert.ToString(_context.Request["Edge3"]);}
			set { this.edge3 = value; }
		}
		private string edge3;
		
		///<summary>
		///封边4
		///</summary>
		public string Edge4
		{
			get { return Convert.ToString(_context.Request["Edge4"]);}
			set { this.edge4 = value; }
		}
		private string edge4;
		
		///<summary>
		///封边描述
		///</summary>
		public string EdgeDesc
		{
			get { return Convert.ToString(_context.Request["EdgeDesc"]);}
			set { this.edgeDesc = value; }
		}
		private string edgeDesc;
		
		///<summary>
		///是否异形板
		///</summary>
		public bool IsSpecialShap
		{
			get { return Convert.ToBoolean(_context.Request["IsSpecialShap"]);}
			set { this.isSpecialShap = value; }
		}
		private bool isSpecialShap;
		
		///<summary>
		///
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///
		///</summary>
		public DateTime Modified
		{
			get { return  Convert.ToDateTime(_context.Request["Modified"]);}
			set { this.modified = value; }
		}
		private DateTime modified;
		
		///<summary>
		///
		///</summary>
		public string ModifiedBy
		{
			get { return Convert.ToString(_context.Request["ModifiedBy"]);}
			set { this.modifiedBy = value; }
		}
		private string modifiedBy;
	}
}
