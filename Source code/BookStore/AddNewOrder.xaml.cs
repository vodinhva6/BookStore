using BookStore.View;
using BookStore.View.Class;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for AddNewOrder.xaml
    /// </summary>
    /// 
    class BookDetail : Book
    {
        public int quantity { get; set; }
        public BookDetail() { }
        public BookDetail(Book book,int quantity=1)
        {
            this.ID=book.ID;
            this.Name=book.Name;
            this.Image = book.Image;
            this.Author=book.Author;
            this.Publish=book.Publish;
            this.Price=book.Price;
            this.RawPrice=book.RawPrice;
        this.CategoryID=book.CategoryID;
            this.quantity = quantity;
            this.Quantity = book.Quantity;
        }
    }

    class TotalPrice: INotifyPropertyChanged
    {
        public string _price;
        public string total {
            get { return _price; }
            set { 
                _price = value; 
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("TotalPrice"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class AddNewOrder : MetroWindow
    {
        OrderDao dao=null;
        ObservableCollection<BookDetail> books = new ObservableCollection<BookDetail>();
        private int totalPrice=0;
    TotalPrice _all=new TotalPrice();

        ObservableCollection<Status> statuses;
        public AddNewOrder()
        {
            InitializeComponent();
            _all.total = "0";
            dao = new OrderDao();
            productsListView.ItemsSource = books;
            totalPriceTextBox.DataContext = _all;

        StatusDao statusDao = new StatusDao();
            statuses=statusDao.GetAll();
            statusCombobox.ItemsSource=statuses;
        }

        private void saveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dateTxt.Text != "" && nameTxt.Text != "" && statusCombobox.SelectedIndex>=0)
            {
                var dateTime = DateTime.Parse(dateTxt.Text);

                var date = DateOnly.FromDateTime(dateTime);
                string username=nameTxt.Text;
                int newOrderId = dao.count() + 1;
                int status=statusCombobox.SelectedIndex+1;
                dao.insert(newOrderId,date, username, int.Parse(_all.total), status);

                OrderDetailDao orderDetailDao = new OrderDetailDao();
               
                RevenueProfitDAO rpf = new RevenueProfitDAO();
                ProductDAOKhoi productDAOKhoi = new ProductDAOKhoi();

                foreach(BookDetail i in books)
                {
                    orderDetailDao.insert(newOrderId, i.ID, i.quantity, int.Parse(i.Price));
                    i.Quantity = (int.Parse(i.Quantity) - i.quantity).ToString();
                    ProductDAO._db.updateQuantityBook(i.ID, i.Quantity);

                    int newIdRevenue=rpf.count()+1;
                    float revenue = (float)(i.quantity * int.Parse(i.Price));
                    float profit = revenue - (float)(i.quantity* int.Parse(i.RawPrice));
                    rpf.insert(newIdRevenue,revenue,profit,date);

                    productDAOKhoi.insert(i.ID, i.quantity, date);
                }

                MessageBox.Show("Save successful !!!","Information",MessageBoxButton.OK, MessageBoxImage.Information);
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
                BookDetail temp=new BookDetail(bookList.choosenBook);
                if (books.Any(p=> p.ID.Equals(temp.ID)))
                {

                    foreach(BookDetail i in books)
                    {
                        if (i.ID.Equals(temp.ID))
                        {
                            i.quantity += 1;
                            break;
                        }
                    }

                    
                }else
                books.Add(temp);
     
                addTotalPrice(temp.Price);
            }
                updateTotalPrice2();
        }

        private void addTotalPrice(string price)
        {

                totalPrice += int.Parse(price);
                _all.total=totalPrice.ToString();
        }

        private bool updateTotalPrice()
        {
            totalPrice= 0;
            BookDetail temp=null;
            foreach(BookDetail book in books)
            {

                if (book.quantity == 0)
                {
                   temp=book;
                }
                if(book.quantity > int.Parse(book.Quantity))
                {
                totalPrice += int.Parse(book.Price) * int.Parse(book.Quantity);

                    book.quantity = int.Parse(book.Quantity);
                }
                else
                {
                totalPrice += int.Parse(book.Price) * book.quantity;

                }
               
            }
            if(temp!=null) books.Remove(temp);
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
                updateTotalPrice2 ();
            };
        }

    }
}
