using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PollSber.Converters
{
    public class SliderProgressConverter : IMultiValueConverter
    {
        private const double MinimumWidth = 0;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!IsValidInput(values))
                return MinimumWidth;

            var (currentValue, maxValue, actualWidth) = ParseInputValues(values);

            if (IsInvalidRange(maxValue))
                return MinimumWidth;

            return CalculateProgressWidth(currentValue, maxValue, actualWidth);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidInput(object[] values)
        {
            return values?.Length >= 3
                   && values[0] is double
                   && values[1] is double
                   && values[2] is double;
        }

        private static (double currentValue, double maxValue, double actualWidth) ParseInputValues(object[] values)
        {
            return ((double)values[0], (double)values[1], (double)values[2]);
        }

        private static bool IsInvalidRange(double maxValue)
        {
            return maxValue <= 0;
        }

        private static double CalculateProgressWidth(double currentValue, double maxValue, double actualWidth)
        {
            var progressPercentage = currentValue / maxValue;
            return (progressPercentage * actualWidth);
        }
    }
}
