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
    /// Interaction logic for ProductOverzicht.xaml
    /// </summary>
    public partial class ProductOverzicht : Window
    {
        public ProductOverzicht()
        {
            InitializeComponent();
        }
        
        private void btnScherm_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtMin.Text, out double min) && double.TryParse(txtMax.Text, out double max))
            {
                datagridProducten.ItemsSource =
            DatabaseOperations.OphalenViaSchermdiagonaal(min, max);
            }
            else
            {
                MessageBox.Show("Min en max moeten numerieke waarden zijn");
            }

        }
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCategorie.ItemsSource = DatabaseOperations.CategorieOphalen();
            cmbCategorie.DisplayMemberPath = "naam";
        }

        private void cmbCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorie categorie = cmbCategorie.SelectedItem as Categorie;
            cmbSubcat.ItemsSource = DatabaseOperations.SubcategorieOphalen(categorie.id);
            cmbSubcat.DisplayMemberPath = "subcategorieNaam";           
            
        }

        private void cmbSubcat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Subcategorie subcategorie = cmbSubcat.SelectedItem as Subcategorie;
            if (subcategorie==null)
            {
                datagridProducten.ItemsSource = null;
            }
            else
            {
                datagridProducten.ItemsSource = DatabaseOperations.ProductOphalenViaSubCategorie(subcategorie.subId);              


            }
        }

        private void btnPrijslijst_Click(object sender, RoutedEventArgs e)
        {
            Navigatie navigatie = new Navigatie();
            navigatie.Show();
        }

        private void btnLaden_Click(object sender, RoutedEventArgs e)
        {
            datagridProducten.ItemsSource =
            DatabaseOperations.ZoekenOpMerk(txtMerk.Text);
        }

        private void btnCud_Click(object sender, RoutedEventArgs e)
        {
            CRUD crud = new CRUD();
            crud.Show();
        }
    }
}

