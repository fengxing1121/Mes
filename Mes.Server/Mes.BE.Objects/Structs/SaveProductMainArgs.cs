using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveProductArgs
    {
        public ProductMain ProductMain;
        public List<ProductDetail> ProductDetails;
        public List<ProductProcessFile> ProductProcessFiles;
        public List<Product2Hardware> Product2Hardwares;
    }
}
