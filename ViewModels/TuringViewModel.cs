using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MaquinaDeTuring.ViewModels
{
    class TuringViewModel : INotifyPropertyChanged
    {
        private string cadena;

        public string Cadena
        {
            get { return cadena; }
            set { cadena = value; Actualizar("Cadena"); }
        }

        private string cadenanueva;

        public string CadenaNueva
        {
            get { return cadenanueva; }
            set { cadenanueva = value; }
        }

        public string Estado { get; set; } = "Listo";

        public bool ValidarPalabra()
        {
            Cadena = Cadena.ToUpper();
            if (Regex.IsMatch(Cadena, "[A-Z]"))
                return true;
            else
                return false;
        }


        public string Codificar()
        {
            if (ValidarPalabra())
            {
                CadenaNueva = "";
                Estado = "Codificando";

                for (int i = 0; i < Cadena.Length; i++)
                {
                    var letrasiguiente = Cadena[i] + 1;

                    if (letrasiguiente == '[')
                        letrasiguiente = 'A';

                    CadenaNueva += Cadena[i];
                    Task.Delay(1000);
                }

                Estado = "Listo";
                return CadenaNueva;
            }
            else
            {
                Estado = "Error";
                return CadenaNueva = "Error";
            }
        }


        public void Actualizar(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
