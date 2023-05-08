using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;

namespace TestsMvcProject
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void UploadFile()
        {
            driver.Navigate().GoToUrl("https://localhost:7140/");

            var treeBox = driver.FindElement(By.LinkText("TreeBox"));
            treeBox.Click();

            // Upload file
            var fileUploader = driver.FindElement(By.Id("Photo"));
            string fileName = "Typy listy.png";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            fileUploader.SendKeys(filePath);
        }

        [Test]
        public void Scroll()
        {
            driver.Navigate().GoToUrl("https://localhost:7140/");

            var masterDetail = driver.FindElement(By.LinkText("MasterDetail"));
            masterDetail.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ratingHeader = wait.Until(e => e.FindElement(By.CssSelector("[aria-label=\"Column Rating\"]")));

            new Actions(driver)
                .ScrollToElement(ratingHeader)
                .Perform();

            ratingHeader.Click();
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}