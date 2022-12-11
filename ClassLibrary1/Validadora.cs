using Microsoft.VisualBasic;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using static ClassLibrary1.ValidadoraUtils;

namespace ClassLibrary1
{
    public class Validadora
    {
        private string codigoPostal;
        private string provincia;
        private string correoElectronico;
        private string nif;
        private string tarjetaCredito;
        private string ccc;
        private string iban;

        //getters y setters
        public string CodigoPostal
        {
            get { return this.codigoPostal; }
            set { this.codigoPostal = value; }
        }
        public string Provincia
        {
            get { return this.provincia; }
            set { this.provincia = value; }
        }

        public string CorreoElectronico
        {
            get { return this.correoElectronico; }
            set { this.correoElectronico = value; }
        }

        public string Nif
        {
            get { return this.nif; }
            set { this.nif = value; }
        }

        public string TarjetaCredito
        {
            get { return this.tarjetaCredito; }
            set { this.tarjetaCredito = value; }
        }

        public string Ccc
        {
            get { return this.ccc; }
            set { this.ccc = value; }
        }

        public string Iban
        {
            get { return this.iban; }
            set { this.iban = value; }
        }

        // Constructor

        public Validadora(string codigoPostal, string correoElectronico, string nif, string tarjetaCredito, string ccc, string iban)
        {
            this.codigoPostal = codigoPostal;
            this.correoElectronico = correoElectronico;
            this.nif = nif;
            this.tarjetaCredito = tarjetaCredito;
            this.ccc = ccc;
            this.iban = iban;

        }

        /*
         * Recibe una cadena y comprueba si es un código postal válido, si no lo es devuelve 
         * “null”, y si es correcto devuelve una cadena con la provincia a la que corresponde.
         * */
        public String ValidaCodigoPostal()
        {
            if (CodigoPostal.Length != 5)
                return "";

            Dictionary<int, string> dic = ValidadoraUtils.getDictionaryCodigoPostalProvincia();
            int cod = 0;
            Int32.TryParse(CodigoPostal.Substring(0, 2), out cod);

            if (cod > 0 && dic.ContainsKey(cod))
                Provincia = dic[cod];

            return !String.IsNullOrEmpty(Provincia) ? Provincia : "No existe provincia para el código postal indicado";
        }


        public static readonly string RegexEmail = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        public static readonly Regex RegexEmailMatch = new Regex(RegexEmail, RegexOptions.IgnoreCase);

        /*
         * Recibe una cadena y comprueba si se trata de un Email correcto.
         */
        public String ValidaCorreoElectronico()
        {
            string correoNoValido = "El correo electrónico no es válido";
            string correoValido = "El correo electrónico es válido";
            var isValid = RegexEmailMatch.IsMatch(this.correoElectronico);

            return !String.IsNullOrEmpty(this.correoElectronico) && isValid ? correoValido : correoNoValido;
        }

        /*
         * Recibe una cadena y devuelve un valor que determina el tipo de NIF y si es correcto o no.
         */
        public String ValidaNif()
        {
            string nifValido = "El NIF es válido";
            string nifNoValido = "El NIF no es válido";

            if (nif.Length != 9)
            {
                return nifNoValido;
            }

            string parteNumericNif = nif.Substring(0, nif.Length - 1);
            string letraNif = nif.Substring(nif.Length - 1, 1);

            if (!int.TryParse(parteNumericNif, out int numNif))
            {
                //No se pudo convertir los números a formato númerico
                return nifNoValido;
            }

            return ValidadoraUtils.CalculaLetraNif(numNif) != letraNif ? nifNoValido : nifValido;
        }

        /*
         * Recibe una cadena y se debe comprobar si se trata de un número de tarjeta válido
         * Para simplificar se asumirá que solamente se deben validar las tarjetas VISA y MASTERCARD.
         * */
        public String validaTarjetaCredito()
        {
            string tarjetaValida = "tarjeta de crédito válida";
            string tarjetaNoValida = "tarjeta de crédito no válida";
            try
            {
                bool isMasterValida = Regex.IsMatch(this.tarjetaCredito, "^(51|52|53|54|55)") && this.tarjetaCredito.Length == 16;
                bool isVisaValida = Regex.IsMatch(this.tarjetaCredito, "^(4)") && (13 == this.tarjetaCredito.Length || 16 == this.tarjetaCredito.Length);

                if (!isMasterValida && !isVisaValida)
                    return tarjetaNoValida;

                // Array to contain individual numbers
                System.Collections.ArrayList CheckNumbers = new ArrayList();
                // So, get length of card
                int CardLength = tarjetaCredito.Length;

                // Double the value of alternate digits, starting with the second digit
                // from the right, i.e. back to front.
                // Loop through starting at the end
                for (int i = CardLength - 2; i >= 0; i = i - 2)
                {
                    // Now read the contents at each index, this
                    // can then be stored as an array of integers

                    // Double the number returned
                    CheckNumbers.Add(Int32.Parse(tarjetaCredito[i].ToString()) * 2);
                }

                int CheckSum = 0;    // Will hold the total sum of all checksum digits

                // Second stage, add separate digits of all products
                for (int iCount = 0; iCount <= CheckNumbers.Count - 1; iCount++)
                {
                    int _count = 0;    // will hold the sum of the digits

                    // determine if current number has more than one digit
                    if ((int)CheckNumbers[iCount] > 9)
                    {
                        int _numLength = ((int)CheckNumbers[iCount]).ToString().Length;
                        // add count to each digit
                        for (int x = 0; x < _numLength; x++)
                        {
                            _count = _count + Int32.Parse(
                                  ((int)CheckNumbers[iCount]).ToString()[x].ToString());
                        }
                    }
                    else
                    {
                        // single digit, just add it by itself
                        _count = (int)CheckNumbers[iCount];
                    }
                    CheckSum = CheckSum + _count;    // add sum to the total sum
                }
                // Stage 3, add the unaffected digits
                // Add all the digits that we didn't double still starting from the
                // right but this time we'll start from the rightmost number with 
                // alternating digits
                int OriginalSum = 0;
                for (int y = CardLength - 1; y >= 0; y = y - 2)
                {
                    OriginalSum = OriginalSum + Int32.Parse(tarjetaCredito[y].ToString());
                }

                // Perform the final calculation, if the sum Mod 10 results in 0 then
                // it's valid, otherwise its false.
                return ((OriginalSum + CheckSum) % 10) == 0 ? tarjetaValida : tarjetaNoValida;
            }
            catch
            {
                return tarjetaNoValida;
            }
        }

        /**
         * Recibe una cadena y se debe comprobar si se trata de un CCC bancario correcto.
         **/
        public String ValidaCuentaBancaria()
        {
            string cccValido = "Cuenta bancaria válida";
            string cccNoValido = "Cuenta bancaria no válida";

            if (this.ccc.Length != 20)
                return cccNoValido;

            string banco = this.ccc.Substring(0, 4);
            string oficina = this.ccc.Substring(4, 4);
            string dc = this.ccc.Substring(8, 2);
            string cuenta = this.ccc.Substring(10, 10);

            bool isValid = ValidaCuentaBancaria(banco, oficina, dc, cuenta);

            return isValid ? cccValido : cccNoValido;

        }

        public static bool ValidaCuentaBancaria(string banco, string oficina, string dc, string cuenta)
        {
            // Se comprueba que realmente sean números los datos pasados como parámetros y que las longitudes
            // sean correctas
            bool isBancoValid = IsNumeric(banco) && banco.Length == 4;
            bool isOficinaValid = IsNumeric(oficina) && oficina.Length == 4;
            bool isDCValid = IsNumeric(dc) && dc.Length == 2;
            bool isCuentaValid = IsNumeric(cuenta) && cuenta.Length == 10;

            return isBancoValid && isOficinaValid && isDCValid && isCuentaValid && CompruebaCuenta(banco, oficina, dc, cuenta);
        }

        private static bool CompruebaCuenta(string banco, string oficina, string dc, string cuenta)
        {
            return GetDigitoControl("00" + banco + oficina) + GetDigitoControl(cuenta) == dc;
        }

        private static string GetDigitoControl(string CadenaNumerica)
        {
            int[] pesos = { 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            UInt32 suma = 0;
            UInt32 resto;

            for (int i = 0; i < pesos.Length; i++)
            {
                suma += (UInt32)pesos[i] * UInt32.Parse(CadenaNumerica.Substring(i, 1));
            }
            resto = 11 - (suma % 11);

            if (resto == 10) resto = 1;
            if (resto == 11) resto = 0;

            return resto.ToString("0");
        }

        /*
         * Recibe una cadena y se debe comprobar si se trata de un IBAN español.
         * */
        public string ValidaIban()
        {
            string ibanValido = "Cuenta IBAN válido";
            string ibanNoValido = "Cuenta IBAN no válido";

            return isValidIBAN() ? ibanValido : ibanNoValido;
        }

        public bool isValidIBAN()
        {
            string mysIBAN = iban.Replace(" ", "");

            if (mysIBAN.Length > 34 || mysIBAN.Length < 5)
                return false;
            else
            {
                string codigoPais = mysIBAN.Substring(0, 2).ToUpper();
                string digitoControl = mysIBAN.Substring(2, 2).ToUpper();
                string codBanco = mysIBAN.Substring(4).ToUpper();
                if (!IsNumeric(digitoControl))
                    return false;

                if (!ExisteCodigoPais(codigoPais))
                    return false;
                string Umstellung = codBanco + codigoPais + "00";
                string Modulus = IBANCleaner(Umstellung);

                if (98 - Modulo(Modulus, 97) != int.Parse(digitoControl))
                    return false;
            }
            return true;
        }
    }
}
