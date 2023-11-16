using BookStore.View;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookStore
{
    /// <summary>
    /// Interaction logic for DeleteCategory.xaml
    /// </summary>
    public partial class DeleteCategory : MetroWindow
    {
        public int selectedCategoryIndex;
        List<Category> categories;
        public DeleteCategory(ObservableCollection<Category> categories_list)
        {
            InitializeComponent();
            categories = new List<Category>();
            foreach (Category category in categories_list)
            {
                if (category.CategoryName != "All")
                    categories.Add(category);
            }
            productCategoryCombobox.ItemsSource = categories;
        }

        private void productOKButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCategoryIndex = productCategoryCombobox.SelectedIndex + 1;
            if(selectedCategoryIndex == -1)
            {
                MessageBox.Show("Please enter full information!!!");
                return;
            }
            DialogResult = true;
        }
    }
}
