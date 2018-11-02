
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
        string url = "http://testing.todorvachev.com/selectors/id/";
        string ID = "testImage";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);


        IWebElement element = driver.FindElement(By.Id(ID));

        //Thread.Sleep(3000);

        if (element.Displayed)
        {
            message.GreenMessage("Yes, An Element ID '" + ID + "' Has Been Found");
        }
        else
        {
            message.RedMessage("No,  Element " + ID + " Exist");
        }
        driver.Quit();
    }

    
}
