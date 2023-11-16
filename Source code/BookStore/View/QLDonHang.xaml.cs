using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for QLDonHang.xaml
    /// </summary>
    public partial class QLDonHang : UserControl
    {

        List<Order> _orders;
        OrderDao orderDao;

        DateOnly? currentFromDate=null;
        DateOnly? currentToDate=null;

        public QLDonHang()
        {
            InitializeComponent();
            orderDao = new OrderDao();
         
            updateOrderList();

            currentPageComboBox.SelectedIndex = _currentPage - 1;
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Order order = button.CommandParameter as Order;
            if (System.Windows.MessageBox.Show("Do you want to delete this order?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
            deleteItem(order);
            }
        }
        
        public void deleteOrder()
        {
            int index=ordersListView.SelectedIndex;
            if (index == -1) return;
            if (System.Windows.MessageBox.Show("Do you want to delete this order?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteItem(_orders[index]);

            }
        }

        private void deleteItem(Order order)
        {
            OrderDetailDao dao = new OrderDetailDao();
            dao.deleteAllByOrderId(order.id);
            orderDao.delete(order.id);
            _orders.Remove(order);
            updateOrderList();

        }

        private void updateOrder_MouseClick(object sender, MouseButtonEventArgs e)
        {
            int selectedOrderIndex = ordersListView.SelectedIndex;
            if (selectedOrderIndex == -1) return;
            UpdateOrder updateOrder = new UpdateOrder(_orders[selectedOrderIndex]);
            bool? result=updateOrder.ShowDialog();

            if (result == true)
            {
                updateOrderList();
            }
        }

        public void updateOrder()
        {
            int selectedOrderIndex = ordersListView.SelectedIndex;
            if (selectedOrderIndex == -1) return;
            UpdateOrder updateOrder = new UpdateOrder(_orders[selectedOrderIndex]);
            bool? result = updateOrder.ShowDialog();

            if (result == true)
            {
                updateOrderList();
            }
        }

        public void addOrder()
        {
            AddNewOrder addNewOrder = new AddNewOrder();
            bool? result = addNewOrder.ShowDialog();

            if (result == true)
            {
                updateOrderList();
            }
        }

        public void updateOrderList()
        {
            _orders = orderDao.GetAll().ToList();
            ordersListView.ItemsSource = _orders;

            _updateDataSource(1);
            _updatePagingInfo();

            currentPageComboBox.SelectedIndex = _currentPage - 1;
        }

        int _currentPage = 1;
        int _rowsPerPage = 10;
        int _totalItems = 0;
        int _totalPages = 0;

        private void currentPageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentPageComboBox.SelectedIndex >= 0)
            {
                _currentPage = currentPageComboBox.SelectedIndex + 1;

                _updateDataSource(_currentPage,currentFromDate,currentToDate);
            }
        }

        private void _updateDataSource(int page, DateOnly? fromDate=null,DateOnly? toDate=null)
        {
            _currentPage = page;
            (_orders, _totalItems) = GetPagination(
                _currentPage, _rowsPerPage, fromDate,toDate);
            ordersListView.ItemsSource = _orders;
            if (_totalPages == 1)
            {
                previousPageButton.IsEnabled = false;
                nextPageButton.IsEnabled = false;
            }
            else if (currentPageComboBox.SelectedIndex == 0)
            {
                previousPageButton.IsEnabled = false;
                nextPageButton.IsEnabled = true;

            }
            else if (currentPageComboBox.SelectedIndex + 1 == _totalPages)
            {
                nextPageButton.IsEnabled = false;
                previousPageButton.IsEnabled = true;
            }
            else
            {
                previousPageButton.IsEnabled = true;
                nextPageButton.IsEnabled = true;
            }
        }
        private void _updatePagingInfo()
        {
            _totalPages = _totalItems / _rowsPerPage +
                   (_totalItems % _rowsPerPage == 0 ? 0 : 1);

            // Cập nhật ComboBox
            var lines = new List<Tuple<int, int>>();
            for (int i = 1; i <= _totalPages; i++)
            {
                lines.Add(new Tuple<int, int>(i, _totalPages));
            }
            currentPageComboBox.ItemsSource = lines;
        }

        public Tuple<List<Order>, int> GetPagination(
               int currentPage = 1, int rowsPerPage = 10,DateOnly? fromDate=null, DateOnly? toDate=null)
        {
            var origin = orderDao.GetAll();
            if(fromDate==null || toDate == null) {
               

                var items1 = origin.Skip((currentPage - 1) * rowsPerPage)
                    .Take(rowsPerPage);

                // Trang i - Skip((i-1) * rowsPerPage ) Take(rowsPerPage)
                var result1 = new Tuple<List<Order>, int>(
                    items1.ToList(), origin.Count()
                );
                return result1;
            }
            else
            {
            var list = origin.Where(
                item => (item.date>=fromDate && item.date<= toDate)
            );
           
            var items = list.Skip((currentPage - 1) * rowsPerPage)
                .Take(rowsPerPage);

            // Trang i - Skip((i-1) * rowsPerPage ) Take(rowsPerPage)
            var result = new Tuple<List<Order>, int>(
                items.ToList(), list.Count()
            );
            return result;

            }
        }

        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            currentPageComboBox.SelectedIndex += 1;
            previousPageButton.IsEnabled = true;
            if (currentPageComboBox.SelectedIndex + 1 == _totalPages)
            {
                nextPageButton.IsEnabled = false;
            }
            if (currentPageComboBox.SelectedIndex >= 0)
            {
                _currentPage = currentPageComboBox.SelectedIndex + 1;

                _updateDataSource(_currentPage);
            }
        }

        private void previousPageButton_Click(object sender, RoutedEventArgs e)
        {
            currentPageComboBox.SelectedIndex -= 1;

            nextPageButton.IsEnabled = true;
            if (currentPageComboBox.SelectedIndex == 0)
            {
                previousPageButton.IsEnabled = false;
            }
            if (currentPageComboBox.SelectedIndex >= 0)
            {
                _currentPage = currentPageComboBox.SelectedIndex + 1;

                _updateDataSource(_currentPage);
            }
        }

        public void filterOrder(DateOnly? fromDate, DateOnly? toDate)
        {
            currentFromDate= fromDate;
            currentToDate= toDate;

            _updateDataSource(1,fromDate,toDate);
            _updatePagingInfo();

            currentPageComboBox.SelectedIndex = _currentPage - 1;
        }
    }
}
