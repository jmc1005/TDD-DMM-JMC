﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}