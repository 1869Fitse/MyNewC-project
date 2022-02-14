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
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            
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
            Driver.FindElement(By.XPath("//a[@class= 'ui__link ui__whiteText ui__mediumText footer__link' and text()= 'Cards']")).Click();
            Thread.Sleep(5000);

           var iceSpirit = Driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
           Assert.True(iceSpirit.Displayed);
            iceSpirit.Click();
            //Added thread.sleep for 5 minutes delay time
            Thread.Sleep(5000);
        }
    }
}
