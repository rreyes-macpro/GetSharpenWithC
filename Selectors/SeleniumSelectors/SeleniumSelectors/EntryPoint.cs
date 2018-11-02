
using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using System.Threading;

class EntryPoint
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();
        
        driver.Navigate().GoToUrl("http://testing.todorvachev.com/selectors/name/");


        IWebElement element = driver.FindElement(By.Name("myName"));

        //Thread.Sleep(3000);

        if (element.Displayed)
        {
            message.GreenMessage("An Element Has Been Found");
        }
        else
        {
            message.RedMessage("No Element Exist");
        }
        driver.Quit();
    }

    
}
