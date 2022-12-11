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
    public class EstadisticaTests
    {
        [TestMethod()]
        public void CalculaMediaAritmeticaTest_Rojo()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            int media = estadistica.CalculaMediaAritmetica();
            Assert.AreNotEqual(media, 7);
        }

        [TestMethod()]
        public void CalculaMediaAritmeticaTest_Verde()
        {
            string valores = "5,3,8,6,3";
            Estadistica estadistica = new Estadistica(valores);
            Assert.IsNotNull(estadistica);
            int media = estadistica.CalculaMediaAritmetica();
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
    }
}