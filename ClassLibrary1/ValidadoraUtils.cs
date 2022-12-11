using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal static class ValidadoraUtils
    {
        public static Dictionary<int, string> getDictionaryCodigoPostalProvincia()
        {
            Dictionary<int, string> codPostalProvincia = new Dictionary<int, string>();

            codPostalProvincia.Add(1, "\u00C1lava");
            codPostalProvincia.Add(2, "Albacete");
            codPostalProvincia.Add(3, "Alicante");
            codPostalProvincia.Add(4, "Almer\u00EDa");
            codPostalProvincia.Add(5, "\u00C1vila");
            codPostalProvincia.Add(6, "Badajoz");
            codPostalProvincia.Add(7, "Baleares");
            codPostalProvincia.Add(08, "Barcelona");
            codPostalProvincia.Add(09, "Burgos");
            codPostalProvincia.Add(10, "C\u00E1ceres");
            codPostalProvincia.Add(11, "C\u00E1diz");
            codPostalProvincia.Add(12, "Castell\u00F3n");
            codPostalProvincia.Add(13, "Ciudad Real");
            codPostalProvincia.Add(14, "C\u00F3rdoba");
            codPostalProvincia.Add(15, "Coruña");
            codPostalProvincia.Add(16, "Cuenca");
            codPostalProvincia.Add(17, "Gerona");
            codPostalProvincia.Add(18, "Granada");
            codPostalProvincia.Add(19, "Guadalajara");
            codPostalProvincia.Add(20, "Guip\u00FAzcoa");
            codPostalProvincia.Add(21, "Huelva");
            codPostalProvincia.Add(22, "Huesca");
            codPostalProvincia.Add(23, "Ja\u00E9n");
            codPostalProvincia.Add(24, "Le\u00F3n");
            codPostalProvincia.Add(25, "L\u00E9rida");
            codPostalProvincia.Add(26, "La Rioja");
            codPostalProvincia.Add(27, "Lugo");
            codPostalProvincia.Add(28, "Madrid");
            codPostalProvincia.Add(29, "M\u00E1laga");
            codPostalProvincia.Add(30, "Murcia");
            codPostalProvincia.Add(31, "Navarra");
            codPostalProvincia.Add(32, "Orense");
            codPostalProvincia.Add(33, "Asturias");
            codPostalProvincia.Add(34, "Palencia");
            codPostalProvincia.Add(35, "Las Palmas");
            codPostalProvincia.Add(36, "Pontevedra");
            codPostalProvincia.Add(37, "Salamanca");
            codPostalProvincia.Add(38, "Santa Cruz de Tenerife");
            codPostalProvincia.Add(39, "Cantabria");
            codPostalProvincia.Add(40, "Segovia");
            codPostalProvincia.Add(41, "Sevilla");
            codPostalProvincia.Add(42, "Soria");
            codPostalProvincia.Add(43, "Tarragona");
            codPostalProvincia.Add(44, "Teruel");
            codPostalProvincia.Add(45, "Toledo");
            codPostalProvincia.Add(46, "Valencia");
            codPostalProvincia.Add(47, "Valladolid");
            codPostalProvincia.Add(48, "Vizcaya");
            codPostalProvincia.Add(49, "Zamora");
            codPostalProvincia.Add(50, "Zaragoza");
            codPostalProvincia.Add(51, "Ceuta");
            codPostalProvincia.Add(52, "Melilla");

            return codPostalProvincia;
        }

        public static string CalculaLetraNif(int numNif)
        {
            string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            var mod = numNif % 23;
            return control[mod];
        }
    }
}
