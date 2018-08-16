using Mes.BE.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SaveFavoritesArgs
    {
        public List<Favorite> Favorites;
    }
}
