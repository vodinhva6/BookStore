using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookStore.View;
using BookStore.View.Class;

namespace BookStore
{
    public class Book : INotifyPropertyChanged, ICloneable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Publish { get; set; }
        public string Author { get; set; }
        public int CategoryID { get; set; }
        public string Price { get; set; }
        public string RawPrice { get; set; }
        public string Quantity { get; set; }
        public virtual Category Category { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
