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
    public class RevenueProfit : INotifyPropertyChanged, ICloneable
    {
        public Double Revenue { get; set; }
        public Double Profit { get; set; }
        public string Preiod { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    class RevenueProfitDAO
    {
        public ObservableCollection<RevenueProfit> GetAll(string preiod = "year")
        {

            try
            {
                var list = new ObservableCollection<RevenueProfit>();
                string sql =
                    $"select sum(revenue) as revenue,sum(profit) as profit,{preiod}(preiod) as time from RevenueProfit group by {preiod}(preiod) order by time";
                if (preiod.Equals("week"))
                {
                    sql = "SELECT SUM(revenue) AS revenue, SUM(profit) AS profit, DATEPART(wk, preiod) AS time FROM RevenueProfit GROUP BY DATEPART(wk, preiod) ORDER BY time\r\n";
                }
                var command = new SqlCommand(sql, MainWindow._connection);


                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Double revenue = (Double)reader["revenue"];
                    Double profit = (Double)reader["profit"];
                    var time = reader["time"];
                    string timestr = $"{time}";
                    //MessageBox.Show(revenue.ToString() + profit.ToString()+ timestr);
                    list.Add(new RevenueProfit()
                    {
                        Revenue = revenue,
                        Profit = profit,
                        Preiod = timestr
                    });
                }

                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new ObservableCollection<RevenueProfit>();


        }
        public void insert(int id,float revenue,float profit,DateOnly preiod)
        {
            string sql = "INSERT INTO RevenueProfit VALUES (@id,@revenue, @profit,@preiod)";

            var command = new SqlCommand(sql, MainWindow._connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@revenue", SqlDbType.Float).Value = revenue;
            command.Parameters.Add("@profit", SqlDbType.Float).Value = profit;
            command.Parameters.Add("@preiod", SqlDbType.Date).Value = preiod;

            command.ExecuteNonQuery();
        }
        public int count()
        {
            string sql = "SELECT MAX(ID) FROM RevenueProfit";
            var command = new SqlCommand(sql, MainWindow._connection);
            var result = command.ExecuteScalar();
            int count = (result.ToString() != "") ? (int)result : 0;
            return count;
        }
    }


}
