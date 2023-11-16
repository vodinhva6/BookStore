using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.View
{
    public class Price : INotifyPropertyChanged
    {
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public int currentPrice { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
