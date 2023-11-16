using BookStore.View.Class;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Page = BookStore.View.Class.Page;

namespace BookStore.View
{
    public partial class QLHangHoa : System.Windows.Controls.UserControl
    {
        public QLHangHoa()
        {
            InitializeComponent();
        }

        public static ProductDAO _productDAO = new ProductDAO();

        Page _page;

        ObservableCollection<Book> _books;

        int _categoryIndex;

        string _keyword;

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            _page = new Page();
            _categoryIndex = 0;
            _keyword = "";

            updateDataSource(1);
            updatePagingInfo();

            currentProductPageComboBox.SelectedIndex = _page.currentPage - 1;
        }

        public void import()
        {
            _productDAO.import();
        }

        private void updateDataSource(int page)
        {
            _page.currentPage = page;
            (_books, _page.totalItems) = _productDAO.getAll(_page.currentPage, _page.rowsPerPage, _keyword, _categoryIndex, _productDAO._price.currentPrice);
            productListView.ItemsSource = _books;
        }

        private void updatePagingInfo()
        {
            _page.totalPages = _page.totalItems / _page.rowsPerPage +
                   (_page.totalItems % _page.rowsPerPage == 0 ? 0 : 1);

            // Cập nhật ComboBox
            var lines = new List<Tuple<int, int>>();
            for (int i = 1; i <= _page.totalPages; i++)
            {
                lines.Add(new Tuple<int, int>(i, _page.totalPages));
            }
            currentProductPageComboBox.ItemsSource = lines;
        }

        public void addProduct()
        {
            _productDAO.addProduct();
            updateDataSource(0);
        }

        public void deleteProduct()
        {
            int selectedBookIndex = productListView.SelectedIndex;
            if (selectedBookIndex == -1) return;
            if (System.Windows.MessageBox.Show("Do you want to delete this product?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _productDAO.deleteProduct(_books[selectedBookIndex].ID);
                updateDataSource(_page.currentPage);
            }
        }

        public void updateProduct()
        {
            int selectedBookIndex = productListView.SelectedIndex;
            if (selectedBookIndex == -1) return;
            _productDAO.updateProduct(_books[selectedBookIndex].ID);
            updateDataSource(_page.currentPage);
        }

        public void searchProduct(string keyword)
        {
            _keyword = keyword;   
            updateDataSource(1);
            updatePagingInfo();

            currentProductPageComboBox.SelectedIndex = _page.currentPage - 1;
        }

        public void updatePrice()
        {
            updateDataSource(1);
            updatePagingInfo();

            currentProductPageComboBox.SelectedIndex = _page.currentPage - 1;
        }

        public void filterCategory(int categoryID)
        {
            _categoryIndex = categoryID;
            updateDataSource(1);
            updatePagingInfo();

            currentProductPageComboBox.SelectedIndex = _page.currentPage - 1;
        }

        public void addCategory()
        {
            _productDAO.addCategory();
        }

        public void deleteCategory()
        {
            _productDAO.deleteCategory();
        }

        public void updateCategory()
        {
            _productDAO.updateCategory();
        }

        private void deleteProduct_MouseClick(object sender, RoutedEventArgs e)
        {
            deleteProduct();
        }

        private void updateProduct_MouseClick(object sender, RoutedEventArgs e)
        {
            updateProduct();
        }

        private void currentProductPageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentProductPageComboBox.SelectedIndex >= 0)
            {
                _page.currentPage = currentProductPageComboBox.SelectedIndex + 1;

                updateDataSource(_page.currentPage);
            }
        }

        private void previousProductPageClick(object sender, RoutedEventArgs e)
        {
            if (currentProductPageComboBox.SelectedIndex > 0)
            {
                currentProductPageComboBox.SelectedIndex--;
                updateDataSource(_page.currentPage);
            }
        }

        private void nextProductPageCLick(object sender, RoutedEventArgs e)
        {
            if (currentProductPageComboBox.SelectedIndex < _page.totalPages - 1)
            {
                currentProductPageComboBox.SelectedIndex++;
                updateDataSource(_page.currentPage);
            }
        }
    }
}