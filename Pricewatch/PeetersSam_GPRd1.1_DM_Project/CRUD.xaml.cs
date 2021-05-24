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
using Pricewatch_Models;

namespace PeetersSam_GPRd1._1_DM_Project
{
    /// <summary>
    /// Interaction logic for CRUD.xaml
    /// </summary>
    public partial class CRUD : Window
    {
        public CRUD()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbProduct.ItemsSource = DatabaseOperations.HaalAlleProductenOp();
            cmbWinkels.ItemsSource = DatabaseOperations.HaalWinkels();
        }

        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Resetten();
            Product product = cmbProduct.SelectedItem as Product;
            datagridPrijzen.ItemsSource = DatabaseOperations.HaalPrijzenProduct(product.id);
        }



        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("ProductId");             
            foutmeldingen += Valideer("ProductWinkelId");
            foutmeldingen += Valideer("Prijs");
            foutmeldingen += Valideer("winkelId");

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Winkel winkel = cmbWinkels.SelectedItem as Winkel;
                Product product = cmbProduct.SelectedItem as Product;
                ProductWinkel productwinkel = new ProductWinkel();
                productwinkel.productWinkelId = int.Parse(txtProductWinkelId.Text);
                productwinkel.prijs = double.Parse(txtPrijs.Text);
                productwinkel.productId = product.id;                
                productwinkel.winkelId = winkel.id;

                if (productwinkel.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenProductWinkel(productwinkel);

                    if (ok > 0)
                    {
                        datagridPrijzen.ItemsSource = DatabaseOperations.HaalPrijzenProduct(product.id);
                        Resetten();
                    }
                    else
                    {
                        MessageBox.Show("Product is niet toegevoegd aan winkel");
                        Resetten();
                    }
                }
                else
                {
                    MessageBox.Show(productwinkel.Error);
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
           
        }
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("ProductWinkel");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                ProductWinkel productWinkel = datagridPrijzen.SelectedItem as ProductWinkel;
                int productId = productWinkel.productId;

                int ok = DatabaseOperations.VerwijderenProductWinkel(productWinkel);
                if (ok > 0)
                {
                    datagridPrijzen.ItemsSource = DatabaseOperations.HaalPrijzenProduct(productId);
                    Resetten();
                }
                else
                {
                    MessageBox.Show("Orderlijn is niet verwijderd.");
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }
        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("ProductWinkel");
            foutmeldingen += Valideer("winkelId");
            foutmeldingen += Valideer("Prijs");
            foutmeldingen += Valideer("ProductId");

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                ProductWinkel productWinkel = datagridPrijzen.SelectedItem as ProductWinkel;
                productWinkel.prijs = double.Parse(txtPrijs.Text);
                

                if (productWinkel.IsGeldig())
                {
                    int ok = DatabaseOperations.AanpassenProductWinkel(productWinkel);
                    if (ok > 0)
                    {
                        datagridPrijzen.ItemsSource = DatabaseOperations.HaalPrijzenProduct(productWinkel.productId);
                        Resetten();
                    }
                    else
                    {
                        MessageBox.Show("Orderlijn is niet aangepast");
                    }
                }
                else
                {
                    MessageBox.Show(productWinkel.Error);
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        private void datagridPrijzen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridPrijzen.SelectedItem is ProductWinkel productwinkel)
            {               
                txtPrijs.Text = productwinkel.prijs.ToString();
                txtProductWinkelId.Text = productwinkel.productWinkelId.ToString();                                
                txtProductWinkelId.IsEnabled = false;                
                btnToevoegen.IsEnabled = false;
                cmbWinkels.SelectedItem = productwinkel.Winkels;

            }
        }
        private string Valideer(string columnName)
        {
            if (columnName == "ProductWinkel" && datagridPrijzen.SelectedItem == null)
            {
                return "Selecteer een lijn" + Environment.NewLine;
            }
            if (columnName == "ProductId" && cmbProduct.SelectedItem == null)
            {
                return "Selecteer een product" + Environment.NewLine;
            }
            if (columnName == "ProductWinkelId" && !int.TryParse(txtProductWinkelId.Text, out int productwinkelId))
            {
                return "productwinkelID moet een numerieke waarde zijn" + Environment.NewLine;
            }
            if (columnName =="Prijs" && !double.TryParse(txtPrijs.Text, out double prijs))
            {
                return "Prijs moet een numerieke waarde zijn" + Environment.NewLine;
            }
            if (columnName == "winkelId" && cmbWinkels.SelectedItem == null)
            {
                return "Selecteer een winkel!";
            }
            return "";
        }
        private void Resetten()
        {
            txtPrijs.Text = "";
            txtProductWinkelId.Text = "";            
            btnToevoegen.IsEnabled = true;            
            txtProductWinkelId.IsEnabled = true;            
            datagridPrijzen.SelectedItem = null;
            cmbWinkels.SelectedIndex = -1;

        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            Resetten();
        }
    }
}
