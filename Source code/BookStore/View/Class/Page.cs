using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.View.Class
{
    class Page : INotifyPropertyChanged
    {
        public int currentPage { get; set; } = 1;
        public int rowsPerPage { get; set; } = 10;
        public int totalItems { get; set; } = 0;
        public int totalPages { get; set; } = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
