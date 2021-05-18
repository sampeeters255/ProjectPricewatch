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
            datagridProducten.ItemsSource =
            DatabaseOperations.OphalenViaSchermdiagonaal(double.Parse(txtMin.Text), double.Parse(txtMax.Text));

        }
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCategorie.ItemsSource = DatabaseOperations.CategorieOphalen();
            cmbCategorie.DisplayMemberPath = "naam";
        }

        private void cmbCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorie categorie = cmbCategorie.SelectedItem as Categorie;
            if (categorie.id==1)
            {          
                cmbSubcat.ItemsSource = DatabaseOperations.SubcategorieOphalen(1);
                cmbSubcat.DisplayMemberPath = "subcategorieNaam";
            }
            else if (categorie.id==2)
            {
                cmbSubcat.ItemsSource = DatabaseOperations.SubcategorieOphalen(2);
                cmbSubcat.DisplayMemberPath = "subcategorieNaam";
            }
            else if (categorie.id==3)
            {                
                cmbSubcat.ItemsSource = DatabaseOperations.SubcategorieOphalen(3);
                cmbSubcat.DisplayMemberPath = "subcategorieNaam";
            }
            
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
                switch (subcategorie.subId)
                {
                    case 1:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(1);
                        break;
                    case 2:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(2);
                        break;
                    case 3:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(3);
                        break;
                    case 4:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(4);
                        break;
                    case 5:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(5);
                        break;
                    case 6:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(6);
                        break;
                    case 7:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(7);
                        break;
                    case 8:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(8);
                        break;
                    case 9:
                        datagridProducten.ItemsSource = DatabaseOperations.ProductOphalen(9);
                        break;

                    default:
                        break;

                }
            
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
    }
}

