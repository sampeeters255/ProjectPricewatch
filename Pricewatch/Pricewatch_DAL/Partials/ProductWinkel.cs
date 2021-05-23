using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricewatch_Models;

namespace Pricewatch_DAL
{
    public partial class ProductWinkel: BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "productWinkelId" && productWinkelId <= 0)
                {
                    return "productwinkelId moet groter zijn dan 0!";
                }
                if (columnName == "prijs" && prijs <= 0)
                {
                    return "prijs moet groter zijn dan 0";
                }
                if (columnName == "winkelId" && winkelId <1 || winkelId >4)
                {
                    return "winkelId is een getal van 1 tot 4";
                }
                return "";
                
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ProductWinkel winkel &&
                   productId == winkel.productId &&
                   winkelId == winkel.winkelId;
        }

        public override int GetHashCode()
        {
            int hashCode = 1724605979;
            hashCode = hashCode * -1521134295 + productId.GetHashCode();
            hashCode = hashCode * -1521134295 + winkelId.GetHashCode();
            return hashCode;
        }

    }
}
