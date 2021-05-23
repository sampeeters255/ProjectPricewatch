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
            cmbProduct.DisplayMemberPath = "productNaam";
        }



        private void cmbWinkel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = cmbProduct.SelectedItem as Product;
            datagridPrijzen.ItemsSource = DatabaseOperations.HaalPrijzenProduct(product.id);

        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Product product = cmbProduct.SelectedItem as Product;
            ProductWinkel productwinkel = new ProductWinkel();
            productwinkel.productWinkelId = int.Parse(txtProductWinkelId.Text);
            productwinkel.prijs = double.Parse(txtPrijs.Text);
            productwinkel.productId = product.id;
            productwinkel.winkelId = int.Parse(txtWinkel.Text);
        }

        private void datagridPrijzen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridPrijzen.SelectedItem is ProductWinkel productwinkel)
            {
                txtPrijs.Text = productwinkel.prijs.ToString();
                txtProductWinkelId.Text = productwinkel.productWinkelId.ToString();
                txtWinkel.Text = productwinkel.winkelId.ToString();

            }
        }

        
    }
}
