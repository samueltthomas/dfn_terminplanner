using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace dfn_terminplanner
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Schedule Name :");
            String schedule_name = Console.ReadLine();
            Console.WriteLine("Expiry (YYYY - MM - DD HH:MM) :");
            String expiry = Console.ReadLine();
            Console.WriteLine("Description :");
            String description = Console.ReadLine();
            Console.WriteLine("Column Name :");
            String column_name = Console.ReadLine();

            String url = "https://terminplaner.dfn.de/schedule.php?language=en";

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArgument("--log-level=3");

            IWebDriver driver = new ChromeDriver(chromeOptions);

            driver.Url = url;
            
            driver.FindElement(By.Name("name")).SendKeys(schedule_name);
            driver.FindElement(By.Name("expire")).SendKeys(expiry);
            //driver.FindElement(By.Id("foodledescr")).Click();
            driver.FindElement(By.Id("foodledescr")).SendKeys(description);

            driver.FindElement(By.PartialLinkText("Next")).Click();

            driver.FindElement(By.ClassName("fcoli")).SendKeys(column_name);

            driver.FindElement(By.PartialLinkText("Next")).Click();

            driver.FindElement(By.CssSelector("input[value=\"Publish schedule\"]")).Click();

            String foodle = driver.FindElement(By.Name("foodleid")).GetAttribute("value");

            Console.WriteLine("########################");
            Console.WriteLine(foodle);
            Console.WriteLine("########################");

            driver.Close();
        }
    }
}
