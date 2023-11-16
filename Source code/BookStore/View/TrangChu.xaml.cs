using BookStore.View.Class;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore.View
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : UserControl
    {
        public static ProductDAO _productDAO = new ProductDAO();

        ObservableCollection<Book> _books;

        int _categoryIndex, _totalProduct;

        string _keyword;
        OrderDao orderDao;

        public TrangChu()
        {
            InitializeComponent();
            
        }

       
        private void TrangChu_Initialized(object sender, EventArgs e)
        {
            (_books, _totalProduct) = _productDAO.getFiveOutOfStock();
            productListViewTrangChu.ItemsSource = _books;

            totalProduct.Text = _totalProduct.ToString();

            orderDao = new OrderDao();
            var _week = orderDao.getOrdersWeek().ToString();
            var _month = orderDao.getOrdersMonth().ToString();
            weekProduct.Text = _week;
            monthProduct.Text = _month;

        }
    }
}
