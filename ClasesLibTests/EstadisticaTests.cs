using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesLib.Tests
{
    [TestClass()]
    public class EstadisticaTests
    {
        [TestMethod()]
        public void CalculaMediaAritmeticaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediaAritmetica();
            Assert.AreNotEqual(media, 7);
        }

        [TestMethod()]
        public void CalculaMediaAritmeticaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediaAritmetica();
            Assert.AreEqual(media, 5);
        }

        [TestMethod()]
        public void CalculaMediaGeometricaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediaGeometrica();
            Assert.AreNotEqual(media, 7);
        }

        [TestMethod()]
        public void CalculaMediaGeometricaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediaGeometrica();
            Assert.AreEqual(Math.Round(media, 2), 4.64);
        }

        [TestMethod()]
        public void CalculaMediaArmonicaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediaArmonica();
            Assert.AreNotEqual(media, 7);
        }

        [TestMethod()]
        public void CalculaMediaArmonicaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediaArmonica();
            Assert.AreEqual(Math.Round(media, 2), 4.32);
        }

        [TestMethod()]
        public void CalculaMedianaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediana();
            Assert.AreNotEqual(media, 7);
        }

        [TestMethod()]
        public void CalculaMedianaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double media = estadistica.CalculaMediana();
            Assert.AreEqual(media, 5);
        }

        [TestMethod()]
        public void CalculaModaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double moda = estadistica.CalculaModa();
            Assert.AreNotEqual(moda, 7);
        }

        [TestMethod()]
        public void CalculaModaTest_Verde()
        {
            string valores = "5,3,8,6,3,6,5,5,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double moda = estadistica.CalculaModa();
            Assert.AreEqual(moda, 3);
        }

        [TestMethod()]
        public void CalculaDesviacionAbsolutaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double desviacion = estadistica.CalculaDesviacionAbsoluta();
            Assert.AreNotEqual(desviacion, 2);
        }

        [TestMethod()]
        public void CalculaDesviacionAbsolutaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double desviacion = estadistica.CalculaDesviacionAbsoluta();
            Assert.AreEqual(Math.Round(desviacion, 2), 8);
        }

        [TestMethod()]
        public void CalculaDesviacionMediaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double desviacion = estadistica.CalculaDesviacionMedia();
            Assert.AreNotEqual(desviacion, 2);
        }

        [TestMethod()]
        public void CalculaDesviacionMediaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            double desviacion = estadistica.CalculaDesviacionMedia();
            Assert.AreEqual(Math.Round(desviacion, 2), 1.60);
        }
    }
}