using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebDriver
{
    class Program
    {
        static void Main(string[] args)
        {

            //Start the firefox browser and maximize the window
            IWebDriver driver;
            driver = new FirefoxDriver("D:/Selenium WebDriver/Selenium WebDriver/drivers/");
            driver.Manage().Window.FullScreen();
            Test(driver, args);

            //Close the browser at the end of the program
            //driver.Close();

        }
        public static void Test(IWebDriver driver, string[] args)
        {

            //Connect the firefox browser to the webpage
            driver.Navigate().GoToUrl("https://cz.careers.veeam.com/vacancies");
            //Select the deparment
            string department = args[0];
            driver.FindElement(By.XPath("//*[text() = 'All departments']")).Click();
            List<IWebElement> departmentName = new List<IWebElement>();
            departmentName.AddRange(driver.FindElements(By.XPath("//*[text() = '" + department + "']")));
            if(departmentName.Count == 0)
            {
                Console.WriteLine("Can't find department: " + department);
                return;
            }
            departmentName[0].Click();

            //Select the languages
            driver.FindElement(By.XPath("//*[text() = 'All languages']")).Click();
            for (int i = 1; i < args.Length; i++)
            {
                string language = args[i];
                List<IWebElement> selectedLanguage = new List<IWebElement>();
                selectedLanguage.AddRange(driver.FindElements(By.XPath("//*[text() = '" + language + "']")));
                if (selectedLanguage.Count == 0)
                {
                    Console.WriteLine("Can't find language: " + language);
                    return;
                }
                selectedLanguage[0].Click();
            }

            //Count the displayed jobs
            List<IWebElement> jobList = new List<IWebElement>();
            jobList.AddRange(driver.FindElements(By.CssSelector("a[class='card card-sm card-no-hover']")));

            Console.WriteLine("Jobs Listed: "+jobList.Count);

        }
    }

}
