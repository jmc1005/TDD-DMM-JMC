using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal static class EstadisticaUtils
    {
        public static bool IsNumeric(string numero)
        {
            Regex regex = new Regex("[0-9]");
            return regex.Match(numero).Success;
        }
    }
}
