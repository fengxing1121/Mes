using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Model
{
   public class Calendar
    {
        public int weekno { get; set; }

        public DateTime datetime { get; set; }

        public string lunarcalendar { get; set; }

        public bool isworkday { get; set; }
    }

    public class WeekCapacity
    {
        /// <summary>
        /// 周
        /// </summary>
        public int weekno { get; set; }

        /// <summary>
        /// 建议周比列
        /// </summary>
        public decimal maxcapacity { get; set; }

        /// <summary>
        /// 周总量
        /// </summary>
        public decimal totalareal { get; set; }

        /// <summary>
        /// 周工作日
        /// </summary>
        public int weekdaycount { get; set; }

        /// <summary>
        /// 日总量平均值
        /// </summary>
        public decimal dayaverage { get; set; }
        
    }
}
