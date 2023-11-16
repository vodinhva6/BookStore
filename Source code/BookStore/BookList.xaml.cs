using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
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
using BookStore.View.Class;
using BookStore.View;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : Window
    {
        public BookList()
        {
            InitializeComponent();
            _books = new ObservableCollection<Book>();
            booksListView.ItemsSource = _books;
            _categories = new ObservableCollection<Category>() { new Category() { CategoryID = 0, CategoryName = "All" } };

        }
        public ObservableCollection<Category> _categories = null;

        ObservableCollection<Book> _books = null;
        public Book choosenBook;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Read Book data
            List<Book> _temp_books = ProductDAO._db.getAllBooks();
            var list=_temp_books.Where(c => int.Parse(c.Quantity) > 0);
            foreach (var book in list)
            {
                _books.Add(book);
            }

            //Read Category data
            List<Category> _temp_categories = ProductDAO._db.getCategories();
            foreach (var category in _temp_categories)
            {
                _categories.Add(category);
            }

        }

        private void chooseProduct_MouseClick(object sender, MouseButtonEventArgs e)
        {
            int i=booksListView.SelectedIndex;
            choosenBook = _books[i];
            this.DialogResult = true;
           this.Close();
        }
    }
}
