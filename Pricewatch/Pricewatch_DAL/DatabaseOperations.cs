using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pricewatch_DAL
{
    public static class DatabaseOperations
    {

        public static List<Categorie> CategorieOphalen()
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Categorie;
                return query.ToList();
            }
        }
        public static List<Subcategorie> SubcategorieOphalen(int categorieId)
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Subcategorie
                    .Where(x => x.Categorie.id == categorieId);

                return query.ToList();
            }
        }


        public static List<Product> OphalenViaSchermdiagonaal(double min, double max)
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Product
                    .Include(x => x.Merk)
                    .Where(x => x.schermdiagonaal > min && x.schermdiagonaal < max);
                return query.ToList();

            }
        }
        public static List<Product> ProductOphalen(int productId)
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Product
                    .Include(x => x.Merk)
                    .Where(x => x.subId.Equals(productId));
                return query.ToList();

            }
        }



        public static List<ProductWinkel> GetWinkels(int winkelNr)
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.ProductWinkel
                    .Include(x => x.Producten.Merk)
                    .Where(x => x.winkelId == winkelNr);
                return query.ToList();
            }
        }

        public static List<Product> ZoekenOpMerk(string merk)
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Product
                    .Include(x => x.Merk)
                    .Where(x => x.Merk.merkNaam.Contains(merk));
                return query.ToList();
            }
        }


        public static List<Product> HaalAlleProductenOp()
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Product
                    .Include(x=>x.Merk);
                return query.ToList();

            }
        }
        public static List<Winkel> HaalWinkels()
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.Winkel;
                return query.ToList();
            }
        }
        public static List<ProductWinkel> HaalPrijzenProduct(int productNr)
        {
            using (PricewatchEntities entities = new PricewatchEntities())
            {
                var query = entities.ProductWinkel
                    .Include(x => x.Winkels)
                    .Where(x => x.productId == productNr);
                return query.ToList();
            }
        }
        public static int ToevoegenProductWinkel(ProductWinkel productWinkel)
        {
            try
            {
                using (PricewatchEntities entities = new PricewatchEntities())
                {
                    entities.ProductWinkel.Add(productWinkel);
                    return entities.SaveChanges();
                }
            }
            catch ( Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
        public static int VerwijderenProductWinkel(ProductWinkel productWinkel)
        {
            try
            {
                using (PricewatchEntities entities = new PricewatchEntities())
                {
                    entities.Entry(productWinkel).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
        public static int AanpassenProductWinkel(ProductWinkel productWinkel)
        {
            try
            {
                using (PricewatchEntities entities = new PricewatchEntities())
                {
                    entities.Entry(productWinkel).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
    }
}
