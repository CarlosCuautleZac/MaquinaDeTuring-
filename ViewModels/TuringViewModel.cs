using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaquinaDeTuring.ViewModels
{
    public class TuringViewModel : INotifyPropertyChanged
    {

        //Comandos
        public ICommand CodificarCommand { get; set; }
        public ICommand DecodificarCommand { get; set; }

        //Esta es la cadena que el usuario va a introducir
        private string cadena;

        public string Cadena
        {
            get { return cadena; }
            set { cadena = value; Actualizar("Cadena"); }
        }


        //Esta es la cadena que saldra codificada o decodificada
        private string cadenanueva;

        public string CadenaNueva
        {
            get { return cadenanueva; }
            set { cadenanueva = value; }
        }

        //Este es el estado de la maquina de turing
        public string Estado { get; set; } = "Listo";


        //constructor

        public TuringViewModel()
        {
            CodificarCommand = new RelayCommand(Codificar);
            DecodificarCommand = new RelayCommand(Decodificar);           
        }

        public bool ValidarPalabra()
        {
            Cadena = Cadena.ToUpper();
            if (Regex.IsMatch(Cadena, @"^[\p{L}]+$"))
                return true;
            else
                return false;
        }


        //Metodo para codificar
        public async void Codificar()
        {
            CadenaNueva = "";
            Actualizar("");
            if (ValidarPalabra())
            {
                CadenaNueva = "";
                Estado = "Codificando";

                for (int i = 0; i < Cadena.Length; i++)
                {
                    char letrasiguiente = (char)(Cadena[i] + 1);

                    if (letrasiguiente == '[')
                        letrasiguiente = 'A';

                    CadenaNueva += letrasiguiente;
                    Actualizar("");
                    await Task.Delay(2000);
                    
                    
                }

                Estado = "Listo";
                Actualizar("");
            }
            else
            {
                Estado = "Error";
                Actualizar("");
            }
        }


        //Metodo para decodificar
        public async void Decodificar()
        {
            CadenaNueva = "";
            Actualizar("");
            if (ValidarPalabra())
            {              
                Estado = "Codificando";

                for (int i = 0; i < Cadena.Length; i++)
                {
                    char letraanterior = (char)(Cadena[i] - 1);

                    if (letraanterior == '@')
                        letraanterior = 'Z';

                    CadenaNueva += letraanterior;
                    Actualizar("");
                    await Task.Delay(1000);
                }

                Estado = "Listo";
                Actualizar("");
            }
            else
            {
                Estado = "Error";
                Actualizar("");
            }
        }

        //Metodo para actualizar las propiedades
        public void Actualizar(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
