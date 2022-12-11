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
    }
}