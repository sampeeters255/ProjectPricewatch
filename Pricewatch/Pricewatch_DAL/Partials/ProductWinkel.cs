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
                return "";
                
            }
        }

        

    }
}
