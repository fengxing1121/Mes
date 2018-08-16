using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SavePartnerTaskArgs
    {
        public PartnerTask PartnerTask;

        public string TaskType;
        public string Resource;
        public string Action;
        public string ActionRemarks;
        public string ActionRemarksType;
        public string CurrentStep;
        public string NextStep;
        public string NextResource;

        public RoomDesigner RoomDesigner;
        public List<RoomDesignerFile> RoomDesignerFiles;

        public Solution Solution;
        public List<SolutionFile> SolutionFiles;

        public QuoteMain QuoteMain;
        public List<QuoteDetail> QuoteDetails;
    }
}
