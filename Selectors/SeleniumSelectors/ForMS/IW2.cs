using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Drawing;

namespace ForMS
{
    class Gameplay2
    {
        static IWebElement cssReadyElmnt;
        //static IWebElement xGamesCounter;
        //static IWebElement clsPtsElmnt;
        static IWebElement clsBtnElmnt;
        static IWebDriver driver = new ChromeDriver();

        private static void Main()
        {
            string url = "https://promosuat.icgrouplp.com/US/en/handshake?uid=837FA97A9C2C85B7046A2163FFFFFFFF&token=d4959090-5e98-40ff-b7e9-786769ca23bb&gpid=MS_FW_UAT_DEC_US_18-10&c=70fc99c25621a81879dd2144d10522e014b9c1bba38b95b3bde23be1c315dc57";
            string cssReady = "body > div.flip.flip-landing > div.play > button";
            //string xGC = "/html/body/div[1]/div[2]/div/div/div/p[2]";
            //string clsPts = "points";
            string clsBtn = "btn";



            driver.Navigate().GoToUrl(url);

            cssReadyElmnt = driver.FindElement(By.CssSelector(cssReady));

            Console.WriteLine(cssReadyElmnt.Text);

            Thread.Sleep(1000);

            if (cssReadyElmnt.Displayed)
            {
                message.GreenMessage("Yes, An Element ID '" + cssReady + "' Has Been Found");
                //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

            }
            else
            {
                message.RedMessage("No,  Element " + cssReady + " Exist");
                //message.RedMessage("No,  Element " + csselector + " Exist");
            }

            cssReadyElmnt.Click();

            Thread.Sleep(1000);

            clsBtnElmnt = driver.FindElement(By.ClassName(clsBtn));
            Console.WriteLine(clsBtnElmnt.Text);

            Thread.Sleep(2000);

            if (clsBtnElmnt.Displayed)
            {
                message.GreenMessage("Yes, An Element ID '" + clsBtn + "' Has Been Found");
                clsBtnElmnt.Click();
            }
            else
            {
                message.RedMessage("No,  Element " + clsBtn + " Exist");

            }


            //try
            //{



            //    while (clsPtsElmnt.Text != "FOR 100 POINTS")
            //    {

            //        //IWebDriver driver = new ChromeDriver
            //        xGamesCounter = driver.FindElement(By.XPath(xGC));
            //        Console.WriteLine(xGamesCounter.Text);



            //        if (xGamesCounter.Displayed)
            //        {
            //            message.GreenMessage("Yes, An Element ID '" + xGC + "' Has Been Found");
            //            //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

            //        }
            //        else
            //        {
            //            message.RedMessage("No,  Element " + xGC + " Exist");
            //            //message.RedMessage("No,  Element " + csselector + " Exist");
            //        }


            //        clsPtsElmnt = driver.FindElement(By.ClassName(clsPts));
            //        Console.WriteLine(clsPtsElmnt.Text);

            //        if (clsPtsElmnt.Displayed)
            //        {
            //            message.GreenMessage("Yes, An Element ID '" + clsPts + "' Has Been Found");
            //            //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

            //        }
            //        else
            //        {
            //            message.RedMessage("No,  Element " + clsPts + " Exist");
            //            //message.RedMessage("No,  Element " + csselector + " Exist");
            //        }

            //        try
            //        {
            //            clsBtnElmnt = driver.FindElement(By.ClassName(clsBtn));
            //            Console.WriteLine(clsBtnElmnt.Text);

            //            Thread.Sleep(2000);

            //            if (clsBtnElmnt.Displayed)
            //            {
            //                message.GreenMessage("Yes, An Element ID '" + clsBtn + "' Has Been Found");
            //                clsBtnElmnt.Click();
            //            }
            //            else
            //            {
            //                message.RedMessage("No,  Element " + clsBtn + " Exist");

            //            }

            //        }
            //        catch
            //        {

            //            throw;
            //        }


            //    }
            //}
            //catch
            //{

            //    clsBtnElmnt = driver.FindElement(By.ClassName(clsBtn));
            //    Console.WriteLine(clsBtnElmnt.Text);

            //    Thread.Sleep(2000);

            //    if (clsBtnElmnt.Displayed)
            //    {
            //        message.GreenMessage("Yes, An Element ID '" + clsBtn + "' Has Been Found");
            //        clsBtnElmnt.Click();
            //    }
            //    else
            //    {
            //        message.RedMessage("No,  Element " + clsBtn + " Exist");

            //    }
            //}



            //    }
            //}
        }
    }
}

    
