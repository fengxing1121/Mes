using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mes.Client.Utility
{
    public class PagingParm
    {
        private HttpContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PagingParm(HttpContext context)
        {
            this._context = context;
        }

        private int _PageSize;
        /// <summary>
        /// 
        /// </summary>
        public int PageSize
        {
            get { return string.IsNullOrEmpty(_context.Request["rows"]) ? 20 : int.Parse(_context.Request["rows"]); }
            set { _PageSize = value; }
        }
        private int _PageIndex;
        /// <summary>
        /// 
        /// </summary>
        public int PageIndex
        {
            get { return string.IsNullOrEmpty(_context.Request["page"]) ? 1 : int.Parse(_context.Request["page"]); }
            set { _PageIndex = value; }
        }
        private string _Sort;
        /// <summary>
        /// 
        /// </summary>
        public string Sort
        {
            get { return string.IsNullOrEmpty(_context.Request["sort"]) ? "" : _context.Request["sort"]; }
            set { _Sort = value; }
        }
        private string _Order;
        /// <summary>
        /// 
        /// </summary>
        public string Order
        {
            get { return string.IsNullOrEmpty(_context.Request["order"]) ? "" : _context.Request["order"]; }
            set { _Order = value; }
        }

        /// <summary>
        /// 排序语句
        /// </summary>
        public string SortOrder
        {
            get
            {
                return Sort + " " + Order;
            }
        }
        /// <summary>
        /// 开始第几页数
        /// </summary>
        public int RowNumberFrom
        {
            get { return (this.PageIndex - 1) * this.PageSize + 1; }
        }
        /// <summary>
        /// 结束第几页数
        /// </summary>
        public int RowNumberTo
        {
            get { return this.PageIndex * this.PageSize; }
        }
    }
}
