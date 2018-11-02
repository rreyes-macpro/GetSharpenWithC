
using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
//msiw

class ChkClass
{
    static void Main()
    {
        string url = "https://promosuat.icgrouplp.com/CA/en/handshake?uid=837FA97A9C2C85B7046A2163FFFFFFFF&token=6dbf9d97-9515-4780-a139-508e24e4c865&gpid=MS_FW_UAT_NOV_CA_18-20&c=303bff478b06a256601dfeddd6d0386fe313195c3aeeab2bcec81f80b2baeab6";
        //string className = "btn btn-long";

        string csselector = "body > div.flip.flip - landing > div.play > button";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);

        

        //IWebElement element = driver.FindElement(By.ClassName(className));
        IWebElement element = driver.FindElement(By.CssSelector(csselector));

        Console.WriteLine(element.Text);

        Thread.Sleep(3000);

        if (element.Displayed)
        {
            //message.GreenMessage("Yes, An Element ID '" + className + "' Has Been Found");
            message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

        }
        else
        {
            //message.RedMessage("No,  Element " + className + " Exist");
            message.RedMessage("No,  Element " + csselector + " Exist");
        }
        driver.Quit();
    }




}
