using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}