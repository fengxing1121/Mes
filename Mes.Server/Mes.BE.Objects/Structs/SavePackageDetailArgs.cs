using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SavePackageDetailArgs
    {
        public PackageDetail PackageDetail;
        public List<PackageDetail> PackageDetails;

    }
}
