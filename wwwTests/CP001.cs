using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests
{
    [TestClass]
    public class CP001
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
            driver.FindElement(By.Id("tbCodigoPostal")).Click();
            driver.FindElement(By.Id("tbCodigoPostal")).Clear();
            driver.FindElement(By.Id("tbCodigoPostal")).SendKeys("46910");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("Valencia", driver.FindElement(By.Id("lbCodigoPostal")).Text);
        }

        [TestMethod]
        public void TheValidacionKOTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbCodigoPostal")).Click();
            driver.FindElement(By.Id("tbCodigoPostal")).Clear();
            driver.FindElement(By.Id("tbCodigoPostal")).SendKeys("123456");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El tamaño del código postal no es correcto", driver.FindElement(By.Id("lbCodigoPostal")).Text);

        }

        [TestMethod]
        public void TheValidacionVacioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbCodigoPostal")).Click();
            driver.FindElement(By.Id("tbCodigoPostal")).Clear();
            driver.FindElement(By.Id("tbCodigoPostal")).SendKeys("");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El código postal está vacío.", driver.FindElement(By.Id("lbCodigoPostal")).Text);

        }
    }
}
