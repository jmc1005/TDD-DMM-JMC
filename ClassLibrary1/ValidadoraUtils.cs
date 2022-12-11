using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool IsNumeric(string numero)
        {
            Regex regex = new Regex("[0-9]");
            return regex.Match(numero).Success;
        }

        public static bool ExisteCodigoPais(string code)
        {
            if (code.Length != 2)
                return false;
            else
            {
                code = code.ToUpper();
                // comentamos códigos otros países para cumplir con la especificación de la práctica 
                /*string[] codigos = { "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI",
                "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV",
                "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI",
                "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV",
                "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI",
                "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV",
                "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI",
                "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV",
                "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI",
                "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV",
                "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI",
                "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV",
                "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI",
                "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV",
                "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI",
                "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV",
                "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II",
                "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV",
                "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI",
                "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV",
                "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI",
                "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV",
                "KW", "KX", "KY", "KZ", "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LI",
                "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LQ", "LR", "LS", "LT", "LU", "LV",
                "LW", "LX", "LY", "LZ", "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MI",
                "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV",
                "MW", "MX", "MY", "MZ", "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NI",
                "NJ", "NK", "NL", "NM", "NN", "NO", "NP", "NQ", "NR", "NS", "NT", "NU", "NV",
                "NW", "NX", "NY", "NZ", "OA", "OB", "OC", "OD", "OE", "OF", "OG", "OH", "OI",
                "OJ", "OK", "OL", "OM", "ON", "OO", "OP", "OQ", "OR", "OS", "OT", "OU", "OV",
                "OW", "OX", "OY", "OZ", "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PI",
                "PJ", "PK", "PL", "PM", "PN", "PO", "PP", "PQ", "PR", "PS", "PT", "PU", "PV",
                "PW", "PX", "PY", "PZ", "QA", "QB", "QC", "QD", "QE", "QF", "QG", "QH", "QI",
                "QJ", "QK", "QL", "QM", "QN", "QO", "QP", "QQ", "QR", "QS", "QT", "QU", "QV",
                "QW", "QX", "QY", "QZ", "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI",
                "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RQ", "RR", "RS", "RT", "RU", "RV",
                "RW", "RX", "RY", "RZ", "SA", "SB", "SC", "SD", "SE", "SF", "SG", "SH", "SI",
                "SJ", "SK", "SL", "SM", "SN", "SO", "SP", "SQ", "SR", "SS", "ST", "SU", "SV",
                "SW", "SX", "SY", "SZ", "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI",
                "TJ", "TK", "TL", "TM", "TN", "TO", "TP", "TQ", "TR", "TS", "TT", "TU", "TV",
                "TW", "TX", "TY", "TZ", "UA", "UB", "UC", "UD", "UE", "UF", "UG", "UH", "UI",
                "UJ", "UK", "UL", "UM", "UN", "UO", "UP", "UQ", "UR", "US", "UT", "UU", "UV",
                "UW", "UX", "UY", "UZ", "VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VI",
                "VJ", "VK", "VL", "VM", "VN", "VO", "VP", "VQ", "VR", "VS", "VT", "VU", "VV",
                "VW", "VX", "VY", "VZ", "WA", "WB", "WC", "WD", "WE", "WF", "WG", "WH", "WI",
                "WJ", "WK", "WL", "WM", "WN", "WO", "WP", "WQ", "WR", "WS", "WT", "WU", "WV",
                "WW", "WX", "WY", "WZ", "XA", "XB", "XC", "XD", "XE", "XF", "XG", "XH", "XI",
                "XJ", "XK", "XL", "XM", "XN", "XO", "XP", "XQ", "XR", "XS", "XT", "XU", "XV",
                "XW", "XX", "XY", "XZ", "YA", "YB", "YC", "YD", "YE", "YF", "YG", "YH", "YI",
                "YJ", "YK", "YL", "YM", "YN", "YO", "YP", "YQ", "YR", "YS", "YT", "YU", "YV",
                "YW", "YX", "YY", "YZ", "ZA", "ZB", "ZC", "ZD", "ZE", "ZF", "ZG", "ZH", "ZI",
                "ZJ", "ZK", "ZL", "ZM", "ZN", "ZO", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV",
                "ZW", "ZX", "ZY", "ZZ" };*/

                string[] codigos = { "ES" };
                if (Array.IndexOf(codigos, code) == -1)
                    return false;
                else
                    return true;
            }
        }
        public static string IBANCleaner(string sIBAN)
        {
            for (int x = 65; x < 90; x++)
            {
                int replacewith = x - 64 + 9;
                string replace = ((char)x).ToString();
                sIBAN = sIBAN.Replace(replace, replacewith.ToString());
            }
            return sIBAN;
        }

        public static int Modulo(string sModulus, int iTeiler)
        {
            int iStart, iEnde, iErgebniss, iRestTmp, iBuffer;
            string iRest = "", sErg = "";

            iStart = 0;
            iEnde = 0;
            while (iEnde <= sModulus.Length - 1)
            {
                iBuffer = int.Parse(iRest + sModulus.Substring(iStart, iEnde - iStart + 1));

                if (iBuffer >= iTeiler)
                {
                    iErgebniss = iBuffer / iTeiler;
                    iRestTmp = iBuffer - iErgebniss * iTeiler;
                    iRest = iRestTmp.ToString();

                    sErg = sErg + iErgebniss.ToString();

                    iStart = iEnde + 1;
                    iEnde = iStart;
                }
                else
                {
                    if (sErg != "")
                        sErg = sErg + "0";

                    iEnde = iEnde + 1;
                }
            }
            if (iStart <= sModulus.Length)
                iRest = iRest + sModulus.Substring(iStart);
            return int.Parse(iRest);
        }

    }
}
