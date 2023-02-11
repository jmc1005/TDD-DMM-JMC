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
    public class CP002
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
            driver.FindElement(By.Id("tbEmail")).Click();
            driver.FindElement(By.Id("tbEmail")).Clear();
            driver.FindElement(By.Id("tbEmail")).SendKeys("jmc1005@alu.ubu.es");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El correo electrónico es válido", driver.FindElement(By.Id("lbEmail")).Text);
        }

        [TestMethod]
        public void TheValidacionKOTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbEmail")).Click();
            driver.FindElement(By.Id("tbEmail")).Clear();
            driver.FindElement(By.Id("tbEmail")).SendKeys("123456");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El correo electrónico no es válido", driver.FindElement(By.Id("lbEmail")).Text);
        }

        [TestMethod]
        public void TheValidacionVacioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbEmail")).Click();
            driver.FindElement(By.Id("tbEmail")).Clear();
            driver.FindElement(By.Id("tbEmail")).SendKeys("");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El email está vacío.", driver.FindElement(By.Id("lbEmail")).Text);
        }

    }
}
