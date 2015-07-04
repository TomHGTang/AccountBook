using System;
using System.Windows.Data;
using System.Globalization;

namespace AccountBook.Converter
{
    public class VoucherDescConverter:IValueConverter
    {
        /// <summary>
        /// 将描述长度大于5的截断，末尾添加…
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>截断后的描述（说明）字符串</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Length > 5)
            {
                return value.ToString().Substring(0, 4) + "…";
            }
            else
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
