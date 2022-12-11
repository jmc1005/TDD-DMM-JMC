using System.Net;
using System.Text.RegularExpressions;

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

            return ValidadoraUtils.CalculaLetraNif(numNif) != letraNif ? nifNoValido:nifValido;
        }
    }
}