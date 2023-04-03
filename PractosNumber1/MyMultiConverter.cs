using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PractosNumber1
{
    internal class MyMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // values - это массив значений Text из TextBox
            // parameter - это дополнительный параметр, который можно передать в xaml
            // culture - это культура текущего потока

            // Проверяем, что values не null и содержит три элемента
            if (values != null && values.Length == 4)
            {
                // Приводим каждый элемент к строке и проверяем его на пустоту или пробелы
                string text1 = (string)values[0];
                string text2 = (string)values[1];
                string text3 = (string)values[2];
                string text4 = (string)values[3];

                return !string.IsNullOrWhiteSpace(text1) && !string.IsNullOrWhiteSpace(text2) &&
                       !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4);
            }
            else if (values != null && values.Length == 2)
            {
                string text1 = (string)values[0];
                string text2 = (string)values[1];

                return !string.IsNullOrWhiteSpace(text1) && !string.IsNullOrWhiteSpace(text2);
            }
            else if (values != null && values.Length == 3)
            {
                string text1 = (string)values[0];
                string text2 = (string)values[1];
                string text3 = (string)values[2];

                return !string.IsNullOrWhiteSpace(text1) && !string.IsNullOrWhiteSpace(text2) &&
                       !string.IsNullOrWhiteSpace(text3);
            }

            // Возвращаем false по умолчанию
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
