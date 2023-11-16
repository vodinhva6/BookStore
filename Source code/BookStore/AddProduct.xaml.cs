using BookStore.View;
using MahApps.Metro.Controls;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : MetroWindow
    {
        public Book book;
        List<Category> categories;
        FileInfo _selectedImage;
        public AddProduct(int id, ObservableCollection<Category> categories_list)
        {
            InitializeComponent();
            book = new Book()
            {
                ID = id,
                Name = "",
                Author = "",
                Image = "Images/0.jpg",
                Publish = "",
                CategoryID = 1,
                Price = "",
                RawPrice = "",
                Quantity = ""
            };

            categories = new List<Category>();
            foreach (Category category in categories_list)
            {
                if(category.CategoryName != "All")
                    categories.Add(category);
            }
            productDataAddWindow.DataContext = book;
            productCategoryCombobox.ItemsSource = categories;
        }

        private void browseProductImageButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            screen.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (screen.ShowDialog() == true)
            {
                _selectedImage = new FileInfo(screen.FileName);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(screen.FileName, UriKind.Absolute);
                bitmap.EndInit();
                productImage.Source = bitmap;
            }
        }

        private void productOKButton_Click(object sender, RoutedEventArgs e)
        {
            if(
                book.Name.IsNullOrEmpty() ||
                book.Author.IsNullOrEmpty() ||
                book.Publish.IsNullOrEmpty() ||
                book.Price.IsNullOrEmpty() ||
                book.RawPrice.IsNullOrEmpty() ||
                book.Quantity.IsNullOrEmpty() ||
                productCategoryCombobox.SelectedIndex < 0 ||
                _selectedImage == null
            ){
                MessageBox.Show("Please enter full information!!!");
                return;
            }
            DialogResult = true;
            book.CategoryID = productCategoryCombobox.SelectedIndex + 1;
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            string path = $"{folder}Images/{_selectedImage.Name}";
            if (!File.Exists(path))
            {
                File.Copy(_selectedImage.FullName, path);
            }
            book.Image = $"Images/{_selectedImage.Name}";
        }
    }
}
