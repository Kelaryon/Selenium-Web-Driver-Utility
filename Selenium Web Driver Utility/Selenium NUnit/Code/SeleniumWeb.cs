using NUnit.Framework;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium_WebDriver
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            //Start the firefox browser and maximize the window
            driver = new FirefoxDriver("D:/Selenium WebDriver/Selenium WebDriver/drivers/");
            driver.Manage().Window.FullScreen();
        }

        [TestCase("Research & Development",new string[] {"English","Russian"})]
        public void Test(string department,string[] languages)
        {
            //Connect the firefox browser to the webpage
            driver.Navigate().GoToUrl("https://cz.careers.veeam.com/vacancies");
            //Select the deparment
            driver.FindElement(By.XPath("//*[text() = 'All departments']")).Click();
            driver.FindElement(By.XPath("//*[text() = '" + department + "']")).Click();

            //Select the languages
            driver.FindElement(By.XPath("//*[text() = 'All languages']")).Click();
            for (int i = 0; i < languages.Length; i++)
            {
                driver.FindElement(By.XPath("//*[text() = '" + languages[i] + "']")).Click();
            }
            //Count the displayed jobs
            List<IWebElement> jobList = new List<IWebElement>();
            jobList.AddRange(driver.FindElements(By.CssSelector("a[class='card card-sm card-no-hover']")));

            Console.WriteLine(jobList.Count);
        }

        //Close the Browser after finish
        //[TearDown]
        //public void closeBrowser()
        //{
        //    driver.Close();
        //}
    }
}