using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.View
{
    public class Category : INotifyPropertyChanged
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Book> Books { get; } = new List<Book>();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
