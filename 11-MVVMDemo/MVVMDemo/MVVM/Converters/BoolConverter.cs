using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.MVVM.Converters
{
    public class BoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var answer = value as string;
            if (answer == "Yes")
            {
                return true;
            }

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var boolena = (bool)value;
            if (boolena)
            {
                return "Yes";
            }
            return "No";
        }
    }
}
