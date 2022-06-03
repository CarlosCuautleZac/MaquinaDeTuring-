using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaquinaDeTuring.Helpers
{
    internal class DeEstadoAColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Color = "Transparent";
            if (value.ToString().Substring(0,5) == "Error")
            {
                Color = "#ae0000";
                return Color; 
            }
            else if (value.ToString() == "Codificando")
            {
                Color = "#ff6d0a";
                return Color;
            }
            else if (value.ToString()== "Listo")
            {
                Color = "#2db83d";
                return Color;
            }
            return Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
