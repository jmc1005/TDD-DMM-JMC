using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography;

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
        public double CalculaMediaAritmetica()
        {
            String[] lista = ListaValores.Split(',');

            if (lista != null && lista.Length > 0)
            {
                double suma = 0;
                foreach (String l in lista)
                {
                    if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                    {
                        suma += num;
                    }
                    else
                    {
                        return double.MinValue;
                    }
                }

                return suma / lista.Length;
            }

            return double.MinValue;

        }


        /**
        * Recibe una lista y calcula la media geométrica de los valores numéricos.
        **/
        public double CalculaMediaGeometrica()
        {
            String[] lista = ListaValores.Split(',');
            if (lista != null && lista.Length > 0)
            {
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
            return double.MinValue;
        }

        /**
        * Recibe una lista y calcula la media armónica de los valores numéricos.
        **/
        public double CalculaMediaArmonica()
        {
            String[] lista = ListaValores.Split(',');

            if (lista != null && lista.Length > 0)
            {
                double suma = 0;
                foreach (String l in lista)
                {
                    if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                    {
                        suma += 1.0 / num;
                    }
                    else
                    {
                        return double.MinValue;
                    }
                }

                return lista.Length / suma;
            }

            return double.MinValue;

        }

        /**
        * Recibe una lista y calcula la mediana de los valores numéricos.
        **/
        public double CalculaMediana()
        {
            String[] lista = ListaValores.Split(',');

            if (lista != null && lista.Length > 0)
            {
                List<double> listaNum = new List<double>();
                foreach (String l in lista)
                {
                    if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                    {
                        listaNum.Add(num);
                    }
                    else
                    {
                        return double.MinValue;
                    }
                }

                listaNum.Sort();
                int tam = listaNum.Count;
                int mitad = tam / 2;
                return (tam % 2 != 0) ? (double)listaNum[mitad] : ((double)listaNum[mitad] + (double)listaNum[mitad - 1]) / 2;

            }

            return double.MinValue;

        }

        /**
        * Recibe una lista y calcula la moda de los valores numéricos.
        **/
        public double CalculaModa()
        {
            String[] lista = ListaValores.Split(',');

            if (lista != null && lista.Length > 0)
            {
                Dictionary<double, int> dicNum = new Dictionary<double, int>();

                int aux_rep = 1;
                foreach (String l in lista)
                {
                    if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                    {
                        if (dicNum.ContainsKey(num))
                        {
                            int repeticiones = dicNum[num];
                            repeticiones++;
                            dicNum[num] = repeticiones;

                            if (repeticiones > aux_rep)
                                aux_rep = repeticiones;
                        }
                        else dicNum.Add(num, 1);
                    }
                    else
                    {
                        return double.MinValue;
                    }
                }

                foreach (var d in dicNum.OrderBy(d => d.Key))
                {
                    if (d.Value == aux_rep)
                        return d.Key;
                }

            }

            return double.MinValue;

        }

        /**
        * Recibe una lista y calcula la desviación absoluta de los valores numéricos.
        **/
        public double CalculaDesviacionAbsoluta()
        {
            double media = CalculaMediaAritmetica();

            String[] lista = ListaValores.Split(',');

            if (lista != null && lista.Length > 0)
            {
                double suma = 0;
                foreach (String l in lista)
                {
                    if (EstadisticaUtils.IsNumeric(l) && int.TryParse(l, out int num))
                    {
                        suma = suma + Math.Abs(num - media);
                    }
                    else
                    {
                        return double.MinValue;
                    }
                }

                return suma / lista.Length;

            }

            return double.MinValue;

        }


    }
}
