
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
        string url = "https://promosuat.icgrouplp.com/CA/en/instantwin/index?id=MS_FW_UAT_NOV_CA_18&bruid=837FA97A9C2C85B7046A2163FFFFFFFF&Hash=f1a3c95b4e4ce97a126ce70c6609c1246febff8b30250a6ec6ab5133717b546a";
        string className = "btn btn-long";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);

        

        IWebElement element = driver.FindElement(By.ClassName(className));

        Console.WriteLine(element.Text);

        Thread.Sleep(3000);

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
