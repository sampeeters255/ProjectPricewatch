using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricewatch_DAL
{
    public partial class Winkel
    {
        public override bool Equals(object obj)
        {
            return obj is Winkel winkel &&
                   id == winkel.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }

        public override string ToString()
        {
            return naam;
        }

    }

}
