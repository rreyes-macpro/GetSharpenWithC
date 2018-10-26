
using System;
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
            GreenMessage("An Element Has Been Found");
        }
        else
        {
            RedMessage("No Element Exist");
        }
        driver.Quit();
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
