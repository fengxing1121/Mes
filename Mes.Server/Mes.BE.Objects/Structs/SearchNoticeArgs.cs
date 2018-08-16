using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SearchNoticeArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid? NoticeID;
     
        public string TargetID;        
        public DateTime? NoticeTimeFrom;
        public DateTime? NoticeTimeTo;       
        public bool? IsRead;       
    }
}
