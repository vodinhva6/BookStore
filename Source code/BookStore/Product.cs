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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookStore
{
   
    public class Product : INotifyPropertyChanged, ICloneable
    {
        public int Quantities { get; set; }
   
        public string Preiod { get; set; }

        public string Name { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    class ProductDAOKhoi
    {
        public List<string> getProductName()
        {
            try
            {
                var list = new List<string>();
                string sql = "select name from BOOK";
                using (SqlCommand command = new SqlCommand(sql, MainWindow._connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Do something with the data
                        while (reader.Read())
                        {
                            string name = (string)reader["name"];
                            list.Add(name);
                        }
                    }
                }
               
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new List<string>();

        }
        public  ObservableCollection<Product> GetAll(string name= "A Court of Mist and Fury", string preiod = "year")
        {

            try
            {
                var list = new ObservableCollection<Product>();
                string sql =
                    $"select {preiod}(preiod) as time,sum(quantities) as quantities from Quantity q inner join BOOK b on q.productid=b.id where name='{name}' group by name,{preiod}(preiod) order by {preiod}(preiod)\r\n";
                if (preiod.Equals("week"))
                {
                    sql = $"select DATEPART(wk, preiod) AS time,sum(quantities) as quantities from Quantity q inner join BOOK b on q.productid=b.id where name='{name}' group by name,DATEPART(wk, preiod) order by time\r\n";
                }
                using (SqlCommand command = new SqlCommand(sql, MainWindow._connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Do something with the data
                        while (reader.Read())
                        {
                            int Quantities = (int)reader["quantities"];
                            var time = reader["time"];

                            string timestr = $"{time}";

                            //MessageBox.Show(revenue.ToString() + profit.ToString()+ timestr);
                            list.Add(new Product()
                            {
                                Quantities = Quantities,
                                Preiod = timestr
                            });
                        }
                    }
                }
             


                

             
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"??");
            }
            return new ObservableCollection<Product>();
        }
        public List<Product> GetTop3(string preiod = "year")
        {

            try
            {
                var list = new List<Product>();
                string sql =
                    $"SELECT q1.name, q1.time, q1.quantities\r\nFROM (\r\n  SELECT name, {preiod}(preiod) AS time, SUM(quantities) AS quantities,\r\n         ROW_NUMBER() OVER (PARTITION BY {preiod}(preiod) ORDER BY SUM(quantities) DESC) AS rn\r\n  FROM Quantity q\r\n  INNER JOIN BOOK b ON q.productid=b.id\r\n  GROUP BY name, {preiod}(preiod)\r\n) q1\r\nWHERE q1.rn <= 3\r\nORDER BY q1.time, q1.quantities DESC";
                if (preiod.Equals("week"))
                {
                    sql = $"SELECT q1.name, q1.time, q1.quantities\r\nFROM (\r\n  SELECT name,DATEPART(wk, preiod) AS time, SUM(quantities) AS quantities,\r\n         ROW_NUMBER() OVER (PARTITION BY DATEPART(wk, preiod) ORDER BY SUM(quantities) DESC) AS rn\r\n  FROM Quantity q\r\n  INNER JOIN BOOK b ON q.productid=b.id\r\n  GROUP BY name, DATEPART(wk, preiod) \r\n) q1\r\nWHERE q1.rn <= 3\r\nORDER BY q1.time, q1.quantities DESC";
                }
                using (SqlCommand command = new SqlCommand(sql, MainWindow._connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Do something with the data
                        while (reader.Read())
                        {
                            int Quantities = (int)reader["quantities"];
                            var time = reader["time"];
                            var name = reader["name"];

                            string timestr = $"{time}";
                            string namestr = $"{name}";

                            //MessageBox.Show(revenue.ToString() + profit.ToString()+ timestr);
                            list.Add(new Product()
                            {
                                Quantities = Quantities,
                                Preiod = timestr,
                                Name= namestr
                            });
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "???");
            }
            return new List<Product>();
        }
        public void insert(int productid,int quantity,DateOnly period)
        {
            string sql = "INSERT INTO QUANTITY VALUES (@productid,@quantities,@period)";

            var command = new SqlCommand(sql, MainWindow._connection);


            command.Parameters.Add("@productid", SqlDbType.Int).Value = productid;
            command.Parameters.Add("@quantities", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@period", SqlDbType.Date).Value = period;

            command.ExecuteNonQuery();
        }
    }
}
