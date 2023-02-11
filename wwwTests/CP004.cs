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
    public class CP004

    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
        }

        [TestMethod]
        public void TheValidacionOKTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbTarjetaCredito")).Click();
            driver.FindElement(By.Id("tbTarjetaCredito")).Clear();
            driver.FindElement(By.Id("tbTarjetaCredito")).SendKeys("5323581135443453");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("tarjeta de crédito válida", driver.FindElement(By.Id("lbTarjetaCredito")).Text);
        }

        [TestMethod]
        public void TheValidacionKOTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbTarjetaCredito")).Click();
            driver.FindElement(By.Id("tbTarjetaCredito")).Clear();
            driver.FindElement(By.Id("tbTarjetaCredito")).SendKeys("123456");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("tarjeta de crédito no válida", driver.FindElement(By.Id("lbTarjetaCredito")).Text);

        }

        [TestMethod]
        public void TheValidacionVacioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbTarjetaCredito")).Click();
            driver.FindElement(By.Id("tbTarjetaCredito")).Clear();
            driver.FindElement(By.Id("tbTarjetaCredito")).SendKeys("");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El número de tarjeta de credito está vacío.", driver.FindElement(By.Id("lbTarjetaCredito")).Text);

        }
    }
}
