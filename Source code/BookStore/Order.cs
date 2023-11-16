using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookStore
{

    public class Order : INotifyPropertyChanged, ICloneable
    {
        public int id { get; set; }
        public DateOnly date { get; set; }
        public int totalPrice { get; set; }
        public string username { get; set; }
         public int status { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }



    class OrderDao
    {
        public OrderDao() {
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

        public ObservableCollection<Order> GetAll()
        {
            var list = new ObservableCollection<Order>();
            string sql =
                "select * from ORDERS";

            var command = new SqlCommand(sql, _connection);


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id =(int) reader["id"];
                DateTime datetime =(DateTime) reader["date"];
                DateOnly date = DateOnly.FromDateTime(datetime);
                int totalPrice = (int)reader["totalPrice"];
                string username = (string)reader["username"];
                int status = (int)reader["status"];

                list.Add(new Order()
                {
                    id = id,
                    date = date,
                    totalPrice = totalPrice,
                    username = username,
                    status = status,
                });
            }

            reader.Close();
            return list;
        }
        public int getOrdersMonth()
        {
            var date = DateTime.Now.ToString("M/d/yyyy");
            var split = date.Split('/');
            var current_month = split[0];
            var current_year = split[2];
            var list = new ObservableCollection<Order>();
            string sql =
                "select * from ORDERS where MONTH(date) = @current_month and YEAR(date) = @current_year";

            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("@current_month", SqlDbType.VarChar).Value = current_month;
            command.Parameters.Add("@current_year", SqlDbType.VarChar).Value = current_year;

            var reader = command.ExecuteReader();
            int countMonth = 0;

            while (reader.Read())
            {
                countMonth++;
            }
            reader.Close();
            return countMonth;
        }
        public int getOrdersWeek()
        {
            var date = DateTime.Now.ToString("M/d/yyyy");
            var split = date.Split('/');
            var list = new ObservableCollection<Order>();
            string sql =
                "select id, DATEDIFF(week, date, CURRENT_TIMESTAMP) AS wm from ORDERS";

            var command = new SqlCommand(sql, _connection);


            var reader = command.ExecuteReader();
            int countWeek = 0;

            while (reader.Read())
            {
                if((int)reader["wm"] == 0)
                {
                    countWeek++;   
                }
            }
            reader.Close();
            return countWeek;
        }

            public Order GetById(int Id)
        {
            string sql =
                "select * from ORDERS where id=@id";

            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;

            var reader = command.ExecuteReader();

          
                int id = (int)reader["id"];
                DateTime datetime = (DateTime)reader["date"];
                DateOnly date = DateOnly.FromDateTime(datetime);
                int totalPrice = (int)reader["totalPrice"];
                string username = (string)reader["username"];
                int status = (int)reader["status"];

               var result=new Order()
                {
                    id = id,
                    date = date,
                    totalPrice = totalPrice,
                    username = username,
                    status = status,
                };
            

            reader.Close();
            return result;
        }

        public void insert(int id,DateOnly date, string username , int totalPrice=0,int status=1)
        {
            string sql = "INSERT INTO ORDERS VALUES (@id,@date, @totalPrice,@username,@status)";
            
            var command = new SqlCommand(sql, _connection);
  
            
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@date", SqlDbType.Date).Value = date;
            command.Parameters.Add("@totalPrice", SqlDbType.Int).Value = totalPrice;
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.Int).Value = status;

            command.ExecuteNonQuery();

        }
        public void delete(int id)
        {
            string sql = "delete from orders where id=@id";
            var command = new SqlCommand(sql,_connection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            command.ExecuteNonQuery();
        }

        public int count()
        {
            string sql = "SELECT MAX(ID) FROM ORDERS";
            var command = new SqlCommand(sql, _connection);
            var result = command.ExecuteScalar();
            int count = (result.ToString() != "")? (int)result:0 ;
            return count;
        }

        public void updateTotalPrice(int id,int totalPrice) {
            string sql = "UPDATE ORDERS SET totalPrice = @totalPrice WHERE id=@id";

            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@totalPrice", SqlDbType.Int).Value = totalPrice;
            

            command.ExecuteNonQuery();
        }
        public void updateOrder(int id,DateOnly date,string username,int totalPrice,int status) {
            string sql = "UPDATE ORDERS SET date=@date,username=@username,totalPrice = @totalPrice,status=@status WHERE id=@id";

            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@status", SqlDbType.Int).Value = status;
            command.Parameters.Add("@totalPrice", SqlDbType.Int).Value = totalPrice;
            command.Parameters.Add("@date", SqlDbType.Date).Value = date;
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

            command.ExecuteNonQuery();
        }
    }
}
