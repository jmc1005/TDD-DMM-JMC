﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesLib.Tests
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

            Assert.AreEqual(provincia, "El tamaño del código postal no es correcto"); // el tamaño no es correcto           

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
            string strValidacion = validadora.ValidaCorreoElectronico();
            Assert.AreEqual(strValidacion, "El correo electrónico no es válido");

        }

        [TestMethod()]
        public void ValidaCorreoElectronicoTest_Verde()
        {
            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");
            string strValidacion = validadora.ValidaCorreoElectronico();
            Assert.AreEqual(strValidacion, "El correo electrónico es válido");

        }

        [TestMethod()]
        public void ValidaNifTest_Rojo()
        {
            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "123456789E", "tarjeta", "ccc", "iban");
            string strValidacion = validadora.ValidaNif();
            Assert.AreEqual(strValidacion, "El NIF no es válido");
        }

        [TestMethod()]
        public void ValidaNifTest_Verde()
        {
            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "tarjeta", "ccc", "iban");
            string strValidacion = validadora.ValidaNif();
            Assert.AreEqual(strValidacion, "El NIF es válido");
        }

        [TestMethod()]
        public void validaTarjetaCreditoTest_Rojo()
        {
            string tarjetaNoValida = "tarjeta de crédito no válida";

            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "tarjeta", "ccc", "iban");
            string strValidacion = validadora.ValidaTarjetaCredito();
            Assert.AreEqual(strValidacion, tarjetaNoValida);
        }

        [TestMethod()]
        public void validaTarjetaCreditoTest_Verde()
        {
            string tarjetaValida = "tarjeta de crédito válida";

            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "5323581135443453", "ccc", "iban");
            string strValidacion = validadora.ValidaTarjetaCredito();
            Assert.AreEqual(strValidacion, tarjetaValida);
        }

        [TestMethod()]
        public void ValidaCuentaBancariaTest_Rojo()
        {
            string cccNoValida = "Cuenta bancaria no válida";

            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "5323581135443453", "ccc", "iban");
            string strValidacion = validadora.ValidaCuentaBancaria();
            Assert.AreEqual(strValidacion, cccNoValida);
        }

        [TestMethod()]
        public void ValidaCuentaBancariaTest_Verde()
        {
            string cccValido = "Cuenta bancaria válida";

            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "5323581135443453", "00246912501234567891", "iban");
            string strValidacion = validadora.ValidaCuentaBancaria();
            Assert.AreEqual(strValidacion, cccValido);
        }

        [TestMethod()]
        public void ValidaIbanTest_Rojo()
        {
            string ibanValido = "Cuenta IBAN válido";
            string ibanNoValido = "Cuenta IBAN no válido";

            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "5323581135443453", "00246912501234567891", "PT6621000418401234567891");
            string strValidacion = validadora.ValidaIban();
            Assert.AreEqual(strValidacion, ibanNoValido);
        }

        [TestMethod()]
        public void ValidaIbanTest_Verde()
        {
            string ibanValido = "Cuenta IBAN válido";

            Validadora validadora = new Validadora("46910", "jmc1005@alu.ubu.es", "24392279C", "5323581135443453", "00246912501234567891", "ES6621000418401234567891");
            string strValidacion = validadora.ValidaIban();
            Assert.AreEqual(strValidacion, ibanValido);
        }
    }
}