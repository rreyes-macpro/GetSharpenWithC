
using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using System.Threading;
//msiw

class EntryPoint
{
    static void Main()
    {
        string url = "http://testing.todorvachev.com/selectors/class-name/";
        string className = "testClass";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);


        IWebElement element = driver.FindElement(By.ClassName(className));

        Console.WriteLine(element.Text);

        //Thread.Sleep(3000);

        if (element.Displayed)
        {
            message.GreenMessage("Yes, An Element ID '" + className + "' Has Been Found");

        }
        else
        {
            message.RedMessage("No,  Element " + className + " Exist");
        }
        driver.Quit();
    }

   

   
}
