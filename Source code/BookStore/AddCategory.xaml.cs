using BookStore.View;
using MahApps.Metro.Controls;
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

namespace BookStore
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : MetroWindow
    {
        public Category category;
        public AddCategory(int id)
        {
            InitializeComponent();
            category = new Category()
            {
                CategoryID = id,
                CategoryName = ""
            };
            categoryDataAddWindow.DataContext = category;
        }

        private void productOKButton_Click(object sender, RoutedEventArgs e)
        {
            if(category.CategoryName == "")
            {
                MessageBox.Show("Please enter full information!!!");
                return;
            }
            DialogResult = true;
        }
    }
}
