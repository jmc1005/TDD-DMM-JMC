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
    public class CP005
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
            driver.FindElement(By.Id("tbCCC")).Click();
            driver.FindElement(By.Id("tbCCC")).Clear();
            driver.FindElement(By.Id("tbCCC")).SendKeys("00246912501234567891");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("Cuenta bancaria válida", driver.FindElement(By.Id("lbCCC")).Text);
        }

        [TestMethod]
        public void TheValidacionKOTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbCCC")).Click();
            driver.FindElement(By.Id("tbCCC")).Clear();
            driver.FindElement(By.Id("tbCCC")).SendKeys("246912501234567891");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("Cuenta bancaria no válida", driver.FindElement(By.Id("lbCCC")).Text);
        }

        [TestMethod]
        public void TheValidacionVacioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbCCC")).Click();
            driver.FindElement(By.Id("tbCCC")).Clear();
            driver.FindElement(By.Id("tbCCC")).SendKeys("");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El número del CCC bancario está vacío.", driver.FindElement(By.Id("lbCCC")).Text);
        }
    }
}
