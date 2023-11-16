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
    /// Interaction logic for UpdateCategory.xaml
    /// </summary>
    public partial class UpdateCategory : MetroWindow
    {
        public int selectedCategoryIndex;
        public Category category;
        List<Category> categories;
        public UpdateCategory(ObservableCollection<Category> categories_list)
        {
            InitializeComponent();

            category = new Category()
            {
                CategoryID = 0,
                CategoryName = ""
            };

            categories = new List<Category>();
            foreach (Category category_i in categories_list)
            {
                if (category_i.CategoryName != "All")
                    categories.Add(category_i);
            }
            categoryDataUpdateWindow.DataContext = category;
            productCategoryCombobox.ItemsSource = categories;
        }
        private void productOKButton_Click(object sender, RoutedEventArgs e)
        {
            if (category.CategoryName == "")
            {
                MessageBox.Show("Please enter full information!!!");
                return;
            }
            selectedCategoryIndex = productCategoryCombobox.SelectedIndex + 1;
            DialogResult = true;
        }

        private void categoryComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            category.CategoryID = categories[productCategoryCombobox.SelectedIndex].CategoryID;
            category.CategoryName = categories[productCategoryCombobox.SelectedIndex].CategoryName;
        }
    }
}
