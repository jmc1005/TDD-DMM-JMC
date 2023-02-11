using System;
using System.Security.Cryptography;
using ClasesLib;

namespace www
{
    public partial class Inicio : System.Web.UI.Page
    {

        Validadora validadora;
        Estadistica estadistica;

        private static string ERROR_CODIGO_POSTAL1 = "El tamaño del código postal no es correcto";
        private static string ERROR_CODIGO_POSTAL2 = "No existe provincia para el código postal indicado";
        private static string ERROR_CODIGO_EMAIL = "El correo electrónico no es válido";
        private static string ERROR_CODIGO_NIF = "El NIF no es válido";
        private static string ERROR_CODIGO_TARJETA = "tarjeta de crédito no válida";
        private static string ERROR_CODIGO_CCC = "Cuenta bancaria no válida";
        private static string ERROR_CODIGO_IBAN = "Cuenta IBAN no válido";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TabValidacion.CssClass = "active";
                MainView.ActiveViewIndex = 0;
            }
        }

        protected void TabValidacion_Click(object sender, EventArgs e)
        {
            TabValidacion.CssClass = "active";
            TabEstadistica.CssClass = "inactive";
            MainView.ActiveViewIndex = 0;
        }

        protected void TabEstadistica_Click(object sender, EventArgs e)
        {
            TabEstadistica.CssClass = "active";
            TabValidacion.CssClass = "inactive";
            MainView.ActiveViewIndex = 1;
        }

        #region [ Validadora ]

        protected void BtnValidar_Click(object sender, EventArgs e)
        {
            string codigoPostal = tbCodigoPostal.Text;
            string correoElectronico = tbEmail.Text;
            string nif = tbNIF.Text;
            string tarjetaCredito = tbTarjetaCredito.Text;
            string ccc = tbCCC.Text;
            string iban = tbIBAN.Text;

            validadora = new Validadora(codigoPostal, correoElectronico, nif, tarjetaCredito, ccc, iban);

            ValidaCodigoPostal(validadora, codigoPostal);
            ValidaCorreoElectronico(validadora, correoElectronico);
            ValidaNif(validadora, nif);
            ValidaTarjetaCredito(validadora, tarjetaCredito);
            ValidaCuentaBancaria(validadora, ccc);
            ValidaIban(validadora, iban);
        }

        protected void btnLimpiarValidacion_Click(object sender, EventArgs e)
        {
            tbCodigoPostal.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbNIF.Text = String.Empty;
            tbTarjetaCredito.Text = String.Empty;
            tbCCC.Text = String.Empty;
            tbIBAN.Text = String.Empty;

            lbCodigoPostal.Text = String.Empty;
            lbEmail.Text = String.Empty;
            lbNIF.Text = String.Empty;
            lbTarjetaCredito.Text = String.Empty;
            lbCCC.Text = String.Empty;
            lbIBAN.Text = String.Empty;
        }

        private void ValidaCodigoPostal(Validadora validadora, string codigoPostal)
        {
            if (String.IsNullOrEmpty(codigoPostal))
            {
                lbCodigoPostal.Text = "El código postal está vacío.";
                lbCodigoPostal.CssClass = "bg-warning";
            }
            else
            {
                String retorno = validadora.ValidaCodigoPostal();
                bool hayError = retorno.Equals(ERROR_CODIGO_POSTAL1) || retorno.Equals(ERROR_CODIGO_POSTAL2);
                lbCodigoPostal.CssClass = hayError ? "text-white bg-danger" : "text-white bg-success";
                lbCodigoPostal.Text = retorno;
            }
        }

        private void ValidaCorreoElectronico(Validadora validadora, string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                lbEmail.Text = "El email está vacío.";
                lbEmail.CssClass = "bg-warning";
            }
            else
            {
                String retorno = validadora.ValidaCorreoElectronico();
                bool hayError = retorno.Equals(ERROR_CODIGO_EMAIL);
                lbEmail.CssClass = hayError ? "text-white bg-danger" : "text-white bg-success";
                lbEmail.Text = retorno;
            }
        }

        private void ValidaNif(Validadora validadora, string nif)
        {
            if (String.IsNullOrEmpty(nif))
            {
                lbNIF.Text = "El NIF está vacío.";
                lbNIF.CssClass = "bg-warning";
            }
            else
            {
                String retorno = validadora.ValidaNif();
                bool hayError = retorno.Equals(ERROR_CODIGO_NIF);
                lbNIF.CssClass = hayError ? "text-white bg-danger" : "text-white bg-success";
                lbNIF.Text = retorno;
            }
        }

        private void ValidaTarjetaCredito(Validadora validadora, string tarjetaCredito)
        {
            if (String.IsNullOrEmpty(tarjetaCredito))
            {
                lbTarjetaCredito.Text = "El número de tarjeta de credito está vacío.";
                lbTarjetaCredito.CssClass = "bg-warning";
            }
            else
            {
                String retorno = validadora.ValidaTarjetaCredito();
                bool hayError = retorno.Equals(ERROR_CODIGO_TARJETA);
                lbTarjetaCredito.CssClass = hayError ? "text-white bg-danger" : "text-white bg-success";
                lbTarjetaCredito.Text = retorno;
            }
        }

        private void ValidaCuentaBancaria(Validadora validadora, string ccc)
        {
            if (String.IsNullOrEmpty(ccc))
            {
                lbCCC.Text = "El número del CCC bancario está vacío.";
                lbCCC.CssClass = "bg-warning";
            }
            else
            {
                String retorno = validadora.ValidaCuentaBancaria();
                bool hayError = retorno.Equals(ERROR_CODIGO_CCC);
                lbCCC.CssClass = hayError ? "text-white bg-danger" : "text-white bg-success";
                lbCCC.Text = retorno;
            }
        }

        private void ValidaIban(Validadora validadora, string iban)
        {
            if (String.IsNullOrEmpty(iban))
            {
                lbIBAN.Text = "El número del IBAN está vacío.";
                lbIBAN.CssClass = "bg-warning";
            }
            else
            {
                String retorno = validadora.ValidaIban();
                bool hayError = retorno.Equals(ERROR_CODIGO_IBAN);
                lbIBAN.CssClass = hayError ? "text-white bg-danger" : "text-white bg-success";
                lbIBAN.Text = retorno;
            }
        }


        #endregion

        #region [ Estadística ]

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            string valores = tbListaValores.Text;

            if (!valores.Contains(","))
            {
                listaValoresError.Visible = true;
            }
            else
            {
                estadistica = new Estadistica(valores);
                double resultado = 0;

                if (rbMediaAritmetica.Checked)
                    resultado = estadistica.CalculaMediaAritmetica();
                else if (rbMediaGeometrica.Checked)
                    resultado = estadistica.CalculaMediaGeometrica();
                else if (rbMediaArmonica.Checked)
                    resultado = estadistica.CalculaMediaArmonica();
                else if (rbMediana.Checked)
                    resultado = estadistica.CalculaMediana();
                else if (rbModa.Checked)
                    resultado = estadistica.CalculaModa();
                else if (rbDesviacionAbsoluta.Checked)
                    resultado = estadistica.CalculaDesviacionAbsoluta();
                else if (rbDesviacionMediaConSigno.Checked)
                    resultado = estadistica.CalculaDesviacionMedia();


                divResult.Visible = true;
                lbResult.Text = string.Format("{0:0.00}", resultado);
            }
        }

        protected void btnLimpiarEstadistica_Click(object sender, EventArgs e)
        {
            tbListaValores.Text = String.Empty;
            listaValoresError.Visible = false;
            rbMediaAritmetica.Checked = true;
            divResult.Visible = false;
            lbResult.Text = String.Empty;
        }

        #endregion

    }
}