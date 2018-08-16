using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveSolutionArgs
    {
        public Solution Solution;
        public List<Solution2Cabinet> Solution2Cabinets;
        public List<SolutionDetail> SolutionDetails;
        public List<Solution2Hardware> Solution2Hardwares;
        public List<SolutionOthers> SolutionOthers;

    }
}
