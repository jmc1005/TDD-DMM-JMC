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
    public class CP006
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
            driver.FindElement(By.Id("tbIBAN")).Click();
            driver.FindElement(By.Id("tbIBAN")).Clear();
            driver.FindElement(By.Id("tbIBAN")).SendKeys("ES6621000418401234567891");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("Cuenta IBAN válido", driver.FindElement(By.Id("lbIBAN")).Text);
        }

        [TestMethod]
        public void TheValidacionKOTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbIBAN")).Click();
            driver.FindElement(By.Id("tbIBAN")).Clear();
            driver.FindElement(By.Id("tbIBAN")).SendKeys("PT6621000418401234567891");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("Cuenta IBAN no válido", driver.FindElement(By.Id("lbIBAN")).Text);
        }

        [TestMethod]
        public void TheValidacionVacioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbIBAN")).Click();
            driver.FindElement(By.Id("tbIBAN")).Clear();
            driver.FindElement(By.Id("tbIBAN")).SendKeys("");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El número del IBAN está vacío.", driver.FindElement(By.Id("lbIBAN")).Text);
        }
    }
}
