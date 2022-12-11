using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class ValidadoraTests
    {
        [TestMethod()]
        public void ValidadoraTest()
        {
            // Comprobamos constructor
            Validadora validadora = new Validadora("44120", "jmc1005@alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");
            Assert.IsNotNull(validadora);
        }

        [TestMethod()]
        public void ValidaCodigoPostalTest_Rojo()
        {
            Validadora validadora = new Validadora("4691", "jmc1005@alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");

            String provincia = validadora.ValidaCodigoPostal();

            Assert.AreEqual(provincia, ""); // el tamaño no es correcto           

        }

        [TestMethod()]
        public void ValidaCodigoPostalTest_Verde()
        {
            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");

            String provincia = validadora.ValidaCodigoPostal();

            Assert.AreEqual(provincia.ToUpper(), "Valencia".ToUpper()); // el tamaño es correcto y la provincia coincide

        }

        [TestMethod()]
        public void ValidaCorreoElectronicoTest_Rojo()
        {
            Validadora validadora = new Validadora("46910", "jmc1005alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");
            string strValidacion =validadora.ValidaCorreoElectronico();
            Assert.AreEqual(strValidacion, "El correo electrónico no es válido");

        }

        [TestMethod()]
        public void ValidaCorreoElectronicoTest_Verde()
        {
            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");
            string strValidacion = validadora.ValidaCorreoElectronico();
            Assert.AreEqual(strValidacion, "El correo electrónico es válido");

        }
    }
}