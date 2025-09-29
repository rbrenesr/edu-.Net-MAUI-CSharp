using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperDaily.Converters
{
    public class AmountToCurrencyConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var isIncome = ((Label)parameter!).Text;
            var amount = (decimal?)value ?? 0m;

            if (isIncome == "True")
            {
                return $"+ {amount:C}";
            }
            else
            {
                return $"- {amount:C}";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
