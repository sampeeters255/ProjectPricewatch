using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pricewatch_DAL;

namespace PeetersSam_GPRd1._1_DM_Project
{
    /// <summary>
    /// Interaction logic for Navigatie.xaml
    /// </summary>
    public partial class Navigatie : Window
    {
        public Navigatie()
        {
            InitializeComponent();
        }

        private void btnBol_Click(object sender, RoutedEventArgs e)
        {
            lblGegevens.Content = "";

            List<ProductWinkel> winkellijst = DatabaseOperations.GetWinkels(1);
            foreach (ProductWinkel product in winkellijst)
            {
                lblGegevens.Content += product.Producten.Merk.merkNaam + " " + product.Producten.productNaam + " " + "€ " + product.prijs.ToString().PadRight(10) + Environment.NewLine;
            }
        }

        private void btnCoolblue_Click(object sender, RoutedEventArgs e)
        {
            lblGegevens.Content = "";
            List<ProductWinkel> winkellijst = DatabaseOperations.GetWinkels(2);
            foreach (ProductWinkel product in winkellijst)
            {
                lblGegevens.Content += product.Producten.Merk.merkNaam + " " + product.Producten.productNaam + " " + "€ "+ product.prijs.ToString().PadRight(10) + Environment.NewLine;
            }
        }

        private void btnVandenborre_Click(object sender, RoutedEventArgs e)
        {
            lblGegevens.Content = "";
            List<ProductWinkel> winkellijst = DatabaseOperations.GetWinkels(3);
            foreach (ProductWinkel product in winkellijst)
            {
                lblGegevens.Content += product.Producten.Merk.merkNaam + " " + product.Producten.productNaam + " " + "€ " + product.prijs.ToString().PadRight(10) + Environment.NewLine;
            }
        }

        private void btnKrefel_Click(object sender, RoutedEventArgs e)
        {
            lblGegevens.Content = "";
            List<ProductWinkel> winkellijst = DatabaseOperations.GetWinkels(4);
            foreach (ProductWinkel product in winkellijst)
            {
                lblGegevens.Content += product.Producten.Merk.merkNaam + " " + product.Producten.productNaam + " " + "€ " + product.prijs.ToString().PadRight(10) + Environment.NewLine;
            }
        }
    }
}
