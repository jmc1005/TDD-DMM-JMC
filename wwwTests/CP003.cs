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
    public class CP003
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
            driver.FindElement(By.Id("tbNIF")).Click();
            driver.FindElement(By.Id("tbNIF")).Clear();
            driver.FindElement(By.Id("tbNIF")).SendKeys("24392279C");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El NIF es válido", driver.FindElement(By.Id("lbNIF")).Text);
        }

        [TestMethod]
        public void TheValidacionKOTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbNIF")).Click();
            driver.FindElement(By.Id("tbNIF")).Clear();
            driver.FindElement(By.Id("tbNIF")).SendKeys("123456");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El NIF no es válido", driver.FindElement(By.Id("lbNIF")).Text);
        }

        [TestMethod]
        public void TheValidacionVacioTest()
        {
            driver.Navigate().GoToUrl("http://localhost:49985/Inicio.aspx");
            driver.FindElement(By.Id("btnLimpiarValidacion")).Click();
            driver.FindElement(By.Id("tbNIF")).Click();
            driver.FindElement(By.Id("tbNIF")).Clear();
            driver.FindElement(By.Id("tbNIF")).SendKeys("");
            driver.FindElement(By.Id("btnValidar")).Click();
            Assert.AreEqual("El NIF está vacío.", driver.FindElement(By.Id("lbNIF")).Text);
        }

    }
}
