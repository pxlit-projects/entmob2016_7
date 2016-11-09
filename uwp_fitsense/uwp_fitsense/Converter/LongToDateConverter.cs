using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace uwp_fitsense.Converter
{
    class LongToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String date = "" + value;
            return String.Format("{0}/{1}/{2} - {3}:{4}:{5}",
                date.Substring(0, 2),
                date.Substring(2, 2),
                date.Substring(4, 2),
                date.Substring(6, 2),
                date.Substring(8, 2),
                date.Substring(10, 2));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}