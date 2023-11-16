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

namespace BookStore.View
{
    class Status : INotifyPropertyChanged
    {
        public int statusId { get; set; }
        public string statusName { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    class StatusDao
    {
        public StatusDao()
        {
            this.connectDb();
        }
        public SqlConnection _connection;

        private void connectDb()
        {
            string connectionString = $"""
                Server = .\sqlexpress;
                Database = BookStore;
                TrustServerCertificate=True;
                Trusted_Connection=true;                
                """;
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot connect to database. Reason: {ex.Message}");
            }
        }

        public ObservableCollection<Status> GetAll()
        {
            var list = new ObservableCollection<Status>();
            string sql =
                "select * from Status";

            var command = new SqlCommand(sql, _connection);


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                string status = (string)reader["statusName"];

                list.Add(new Status()
                {
                    statusId = id,
                    statusName = status,
                });
            }

            reader.Close();
            return list;
        }

        
    }
}
