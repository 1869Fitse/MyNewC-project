using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace QAOnPoint
{

    public class Program
    {

        IWebDriver Driver;
        WebDriverWait wait;
       
        [SetUp]
        public void Initialize()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--start-maximized");
            Driver = new ChromeDriver();
            //wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }


        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }


        [Test]
        public void TestMethod()
        {
        
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://statsroyale.com/");
            IWebElement card = Driver.FindElement(By.XPath("//a[@class= 'ui__link ui__whiteText ui__mediumText footer__link' and text()= 'Cards']"));
            waitForElementAndClick(Driver, By.XPath("//a[@class= 'ui__link ui__whiteText ui__mediumText footer__link' and text()= 'Cards']"),5, card);

            var iceSpirit = Driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            waitForElementAndClick(Driver, By.CssSelector("a[href*='Ice+Spirit']"), 5, iceSpirit);
            Thread.Sleep(5000);
        }
        
        public void waitForElementAndClick(IWebDriver Driver,By element,int timewait, IWebElement webElement) {

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timewait));
            wait.Until(e => e.FindElement(element));
            webElement.Click();
                        
        }
    }
    }

