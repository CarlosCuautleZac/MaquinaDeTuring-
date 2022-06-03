using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaquinaDeTuring.Helpers
{
    internal class DeEstadoATextoConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Texto = "Transparent";
            if (value.ToString() == "Error")
            {
                Texto = "Error: Recuerda que solo puedes introducir letras.";
                return Texto;
            }
            else if (value.ToString() == "Codificando")
            {
                Texto = "En proceso...";
                return Texto;
            }
            else if (value.ToString() == "Listo")
            {
                Texto = "Listo";
                return Texto;
            }
            return Texto;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        
    }
}
