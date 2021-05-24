using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricewatch_DAL
{
    public partial class Product
    {
        public override string ToString()
        {
            return Merk.merkNaam + " " + productNaam;
        }
    }
}
