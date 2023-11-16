using BookStore.View;
using BookStore.View.Class;
using MahApps.Metro.Controls;
using System;
using System.Collections;
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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    /// 



    public partial class UpdateOrder : MetroWindow
    {
        Order currentOrder = null;
        OrderDao dao = null;
        OrderDetailDao orderDetailDao = null;

        ObservableCollection<OrderDetail> orderDetail;
        ObservableCollection<BookDetail> books = new ObservableCollection<BookDetail>();
        ObservableCollection<Status> statuses;


        private int totalPrice = 0;
        TotalPrice _all = new TotalPrice();
        public UpdateOrder(Order oldOrder)
        {
            InitializeComponent();
            _all.total = "0";
            dao = new OrderDao();
            orderDetailDao = new OrderDetailDao();
            currentOrder = oldOrder;
            this.DataContext = currentOrder;
            productsListView.ItemsSource = books;
            totalPriceTextBox.DataContext = _all;

            StatusDao statusDao = new StatusDao();
            statuses = statusDao.GetAll();
            statusCombobox.ItemsSource = statuses;
            statusCombobox.SelectedIndex = currentOrder.status - 1;
            loadData();
        }

        private void loadData()
        {
            orderDetail= orderDetailDao.GetById(currentOrder.id);
            foreach(OrderDetail detail in orderDetail)
            {
                Book temp = ProductDAO._db.GetBook(detail.bookId);
                books.Add(new BookDetail(temp, detail.quantity));

            }
            updateTotalPrice(0);
        }

        private void saveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dateTxt.Text != "" && nameTxt.Text != "" && statusCombobox.SelectedIndex>=0)
            {
                var dateTime = DateTime.Parse(dateTxt.Text);

                var date = DateOnly.FromDateTime(dateTime);
                string username = nameTxt.Text;
                int status=statusCombobox.SelectedIndex+1;

                dao.updateOrder(currentOrder.id, date,username, int.Parse(_all.total),status);

                orderDetailDao.deleteAllByOrderId(currentOrder.id);

                foreach (BookDetail i in books)
                {
                    orderDetailDao.insert(currentOrder.id, i.ID, i.quantity, int.Parse(i.Price));
                    i.Quantity = (int.Parse(i.Quantity) - i.quantity).ToString();

                    ProductDAO._db.updateQuantityBook(i.ID, i.Quantity);
                }

                MessageBox.Show("Update successful !!!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill the blank !!!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteProductsButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            BookDetail book = b.CommandParameter as BookDetail;

            books.Remove(book);
        }

        private void cancelOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            BookList bookList = new BookList();
            bool? result = bookList.ShowDialog();

            if (result == true)
            {
                BookDetail temp = new BookDetail(bookList.choosenBook);
                if (books.Any(p => p.ID.Equals(temp.ID)))
                {

                    foreach (BookDetail i in books)
                    {
                        if (i.ID.Equals(temp.ID))
                        {
                            i.quantity += 1;
                            break;
                        }
                    }


                }
                else
                    books.Add(temp);
                addTotalPrice(temp.Price);
            }
            updateTotalPrice2();
        }

        private void addTotalPrice(string price)
        {
            totalPrice += int.Parse(price);
            _all.total = totalPrice.ToString();
        }

        private bool updateTotalPrice(int mode=1)
        {
            totalPrice = 0;
            BookDetail temp = null;
            foreach (BookDetail book in books)
            {
                if (book.quantity == 0)
                {
                    temp = book;
                }
                if(mode==1)
                {
                if (book.quantity > int.Parse(book.Quantity))
                {
                    totalPrice += int.Parse(book.Price) * int.Parse(book.Quantity);

                    book.quantity = int.Parse(book.Quantity);
                }
                else
                {
                    totalPrice += int.Parse(book.Price) * book.quantity;
                }
                }
                else
                {
                    book.Quantity=book.quantity.ToString();
                    totalPrice += int.Parse(book.Price) * book.quantity;
                }
            }
            if (temp != null)
            {
                    ProductDAO._db.updateQuantityBook(temp.ID, temp.Quantity);
                books.Remove(temp);
            }
            _all.total = totalPrice.ToString();
            return true;
        }

        public void updateTotalPrice2()
        {
            totalPrice = 0;
            BookDetail temp = null;
            foreach (BookDetail book in books)
            {
                totalPrice += int.Parse(book.Price) * book.quantity;
            }
            _all.total = totalPrice.ToString();
        }

        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (updateTotalPrice())
            {
                updateTotalPrice2();
            };
        }

    }
}
