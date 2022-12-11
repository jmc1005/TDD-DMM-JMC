using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class Estadistica
    {
        //
        private string listaValores;

        // Getters y Setters
        public string ListaValores
        {
            get { return listaValores; }
            set { listaValores = value; }
        }

        public Estadistica(string listaValores)
        {
            ListaValores = listaValores;
        }


    }
}
