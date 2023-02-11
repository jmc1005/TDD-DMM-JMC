using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP007
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
        }

        [TestMethod]
        public void TheEstadisticaMediaAritmeticaOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbMediaAritmetica")).Click();
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("5,71", driver.FindElement(By.Id("lbResult")).Text);

        }

        [TestMethod]
        public void TheEstadisticaMediaGeometricaOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbMediaGeometrica")).Click(); 
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("5,32", driver.FindElement(By.Id("lbResult")).Text);

        }

        [TestMethod]
        public void TheEstadisticaMediaArmonicaOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbMediaArmonica")).Click();
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("4,91", driver.FindElement(By.Id("lbResult")).Text);

        }

        [TestMethod]
        public void TheEstadisticaMedianaOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbMediana")).Click();
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("6,00", driver.FindElement(By.Id("lbResult")).Text);

        }

        [TestMethod]
        public void TheEstadisticaModaOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbModa")).Click();
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("3,00", driver.FindElement(By.Id("lbResult")).Text);

        }

        [TestMethod]
        public void TheEstadisticaDesviacionAbsolutaOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbDesviacionAbsoluta")).Click();
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("12,29", driver.FindElement(By.Id("lbResult")).Text);

        }

        [TestMethod]
        public void TheEstadisticaDesviacionMediaConSignoOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("TabEstadistica")).Click();
            driver.FindElement(By.Id("btnLimpiarEstadistica")).Click();
            driver.FindElement(By.Id("rbDesviacionMediaConSigno")).Click();
            driver.FindElement(By.Id("tbListaValores")).Click();
            driver.FindElement(By.Id("tbListaValores")).Clear();
            driver.FindElement(By.Id("tbListaValores")).SendKeys("5,3,8,6,3,8,7");
            driver.FindElement(By.Id("btnCalcular")).Click();
            Assert.AreEqual("1,76", driver.FindElement(By.Id("lbResult")).Text);

        }

    }
}
