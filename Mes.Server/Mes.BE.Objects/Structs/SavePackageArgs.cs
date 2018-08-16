using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SavePackageArgs
    {
        public Package Package;
        public PackageDetail PackageDetail;
    }
}
