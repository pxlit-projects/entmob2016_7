using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.Converters
{
    public class MaxTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seconds = (int)value;
            int minutes = 0;
            if (seconds >= 60)
            {
                minutes = seconds / 60;
                seconds -= 60 * (seconds / 60);
            }
            string maxTime = "Max Time: ";
            if (minutes > 0)
            {
                if (minutes > 1)
                    maxTime += minutes + " Minutes";
                else
                    maxTime += minutes + " Minute";
                if (seconds > 0)
                    maxTime += " and ";
            }
            if(seconds > 0)
            {
                maxTime += seconds + " Seconds";
            }
            return maxTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // no need, only a one way binding
            return null;
        }
    }
}
