using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveQuoteMainArgs
    {
        public QuoteMain QuoteMain;
        public List<QuoteDetail> QuoteDetails;
    }
}
