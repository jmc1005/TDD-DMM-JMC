namespace ClassLibrary1
{
    public class Validadora
    {
        private string codigoPostal;
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
    }
}