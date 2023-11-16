using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookStore.View
{
    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.ToString() == "0")
                return 0;
            CultureInfo cultureInfo= CultureInfo.GetCultureInfo("vi-VN");
            string price = int.Parse(value.ToString()).ToString("#,###", cultureInfo.NumberFormat);
            return price;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
