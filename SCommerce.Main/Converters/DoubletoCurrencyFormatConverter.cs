using System;
using Windows.UI.Xaml.Data;

namespace SCommerce.Main.Converters
{
    /// <summary>
    /// Conversor de double para int.
    /// </summary>
    public class DoubletoCurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value is double numero)
                {
                    return numero.ToString("0.##"); // Convetendo double em um número com duias casas decimais.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}