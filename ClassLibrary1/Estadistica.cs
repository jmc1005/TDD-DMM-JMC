using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Estadistica
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

        /**
         * Recibe una lista y calcula la media aritmética de los valores numéricos.
         **/
        public int CalculaMediaAritmetica()
        {
            String[] lista = ListaValores.Split(',');

            int suma = 0;
            foreach (String l in lista)
            {
                if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                {
                    suma += num;
                }
                else
                {
                    return int.MinValue;
                }
            }

            return suma / lista.Length;

        }


        /**
        * Recibe una lista y calcula la media geométrica de los valores numéricos.
        **/
        public double CalculaMediaGeometrica()
        {
            String[] lista = ListaValores.Split(',');

            double mediageom = 1;
            foreach (String l in lista)
            {
                if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                {
                    mediageom *= num;
                }
                else
                {
                    return double.MinValue;
                }
            }

            return Math.Pow(mediageom, 1.0 / lista.Length);

        }
    }
}
