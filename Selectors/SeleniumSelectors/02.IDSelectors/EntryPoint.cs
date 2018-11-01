
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using System.Threading;

class EntryPoint
{
    static void Main()
    {
        string url = "http://testing.todorvachev.com/selectors/id/";
        string ID = "testImage";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);


        IWebElement element = driver.FindElement(By.Id(ID));

        //Thread.Sleep(3000);

        if (element.Displayed)
        {
            GreenMessage("Yes, An Element ID '" + ID + "' Has Been Found");
        }
        else
        {
            RedMessage("No,  Element "+ ID + " Exist");
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
