using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore
{
    public class OrderDetail : INotifyPropertyChanged, ICloneable
    {
        public int orderId { get; set; }
        public int bookId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    class OrderDetailDao
    {
        public OrderDetailDao()
        {
            //this.connectDb();
            _connection = MainWindow._connection;
        }
        public SqlConnection _connection;

        //private void connectDb()
        //{
        //    string connectionString = $"""
        //        Server = .\sqlexpress;
        //        Database = BookStore;
        //        TrustServerCertificate=True;
        //        Trusted_Connection=true;                
        //        """;
        //    _connection = new SqlConnection(connectionString);
        //    try
        //    {
        //        _connection.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            $"Cannot connect to database. Reason: {ex.Message}");
        //    }
        //}

        public ObservableCollection<OrderDetail> GetAll()
        {
            var list = new ObservableCollection<OrderDetail>();
            string sql =
                "select * from ORDERDETAIL";

            var command = new SqlCommand(sql, _connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int orderId = (int)reader["orderId"];
                int bookId = (int)reader["bookId"];
                int quantity = (int)reader["quantity"];
                int price = (int)reader["price"];

                list.Add(new OrderDetail()
                {
                    orderId = orderId,
                    bookId = bookId,
                    quantity = quantity,
                    price=price
                });
            }

            reader.Close();
            return list;
        } 
        public ObservableCollection<OrderDetail> GetById(int id)
        {
            var list = new ObservableCollection<OrderDetail>();
            string sql =
                 "select * from ORDERDETAIL where orderId=@orderId";

            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@orderId", SqlDbType.Int).Value = id;

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int orderId = (int)reader["orderId"];
                int bookId = (int)reader["bookId"];
                int quantity = (int)reader["quantity"];
                int price = (int)reader["price"];

                list.Add(new OrderDetail()
                {
                    orderId = orderId,
                    bookId = bookId,
                    quantity = quantity,
                    price=price
                });
            }

            reader.Close();
            return list;
        }

       


        public void insert(int orderId,int bookId,int quantity,int price)
        {
            string sql = "INSERT INTO ORDERDETAIL VALUES (@orderId,@bookId, @quantity,@price)";

            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
            command.Parameters.Add("@bookId", SqlDbType.Int).Value = bookId;
            command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@price", SqlDbType.Int).Value = price*quantity;

            command.ExecuteNonQuery();
        }
        public void delete(int orderId,int bookId)
        {
            String sql = "delete from orderdetail where orderId=@orderId and bookId=@bookId";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
            command.Parameters.Add("@bookId", SqlDbType.Int).Value = bookId;
            command.ExecuteNonQuery();
        }

        public void deleteAllByOrderId(int orderId)
        {
            String sql = "delete from orderdetail where orderId=@orderId";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

            command.ExecuteNonQuery();
        }
    }
}
