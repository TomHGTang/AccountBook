using System;
using System.Windows.Data;
using System.Globalization;

namespace AccountBook.Converter
{
    public class VoucherTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.GetType()==typeof(short))
            {
                switch (short.Parse(value.ToString()))
                {
                    case 1: return "支出";
                    case 2: return "收入";
                    case 3: return "转账";
                    default: return null;
                }
            }else if(value.GetType()==typeof(DateTime))
            {
                return DateTime.Parse(value.ToString()).ToShortDateString();
            }
            else
            {
                return null;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
