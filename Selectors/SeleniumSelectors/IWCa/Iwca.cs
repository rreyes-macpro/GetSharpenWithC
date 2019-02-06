using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace IWCa
{
    class Iwca
    {
        static IWebElement cssReadyElmnt;
        static IWebElement clsBtnElmnt;
        static IWebElement idPrizeImage;
        static IWebElement idSTQElement;
        static IWebElement idSubmitElement;
        //static IWebElement xPathPN;
        static IWebDriver driver = new ChromeDriver();

        static void Main()
        {
            //string url = "https://promosuat.icgrouplp.com/CA/en/scratchandwin/index?id=MS_SW_UAT_JAN_CA_19&bruid=837FA97A9C2C85B7046A2163FFFFFFFF&Hash=f4643f02b23a114189ac4e1e96cda1109fa196baa9bf935b8528a04f373420fe";
            string url = "https://promosuat.icgrouplp.com/CA/fr/handshake?uid=837FA97A9C2C85B7046A2163FFFFFFFF&token=427b38b9-1b56-425c-b5dc-16a5deb4a30b&gpid=MS_SW_UAT_JAN_CA_19-30&c=a9c148c7a6a2cd806c94d8a6d9c6b66a8bbaa43af0d54689cb6506166cc09f10";
            string cssReady = "body > div.scratch.scratch-win > div";
            string idSTQ = "StqAnswer";
            string idSubmit = "submit";
            string clsBtn = "btn";
            string idPI = "prizeImage";
            //string screenshotdir = @"c:\screenshotsSWCAEn\";

            //string screenshotdir = @"\screenshotsSWCAEn\";
            string screenshotdir = @"\screenshotsSWCAFr\";

            //string logFilePath = @"C:\iwwinlogs\CA\ScratchNWinListCAEn.txt";
            string logFilePath = @"C:\iwwinlogs\CA\ScratchNWinListCAFr.txt";
            var messages = new List<string>();

            var playAgain = true;
            driver.Navigate().GoToUrl(url);
            var imagePath = "";

            while (playAgain)
            {

                string timestmp = DateTime.Now.ToString("yyyy-MM-dd-T-HH-mm-ss");

                //int ans = 3;
                cssReadyElmnt = driver.FindElement(By.CssSelector(cssReady));
                Console.WriteLine(cssReadyElmnt.Text);
                Console.WriteLine(timestmp);
                Thread.Sleep(1000);
                cssReadyElmnt.Click();
                Thread.Sleep(1000);

                //idPrizeImage = driver.FindElement(By.Id(idPI));

                //string prizewon = "5,000 Microsoft Rewards"; //"BURGER"; //"SWEEPS"; //- uncomment to target specific win item

                idSTQElement = driver.FindElement(By.Id(idSTQ));
                idSubmitElement = driver.FindElement(By.Id(idSubmit));

                if (idSTQElement.Displayed)
                {
                    idSTQElement.SendKeys("3");
                }
                else
                {
                    Util.WriteToScreen("No, Element Exist");
                }

                Thread.Sleep(500);

                idSubmitElement.Click();

                Thread.Sleep(2000);


                idPrizeImage = driver.FindElement(By.Id(idPI));
                if (idPrizeImage.Displayed)
                {
                    imagePath = idPrizeImage.GetAttribute("src");
                    Console.WriteLine(idPrizeImage.Text);
                    Console.WriteLine(imagePath);

                    messages.Add(timestmp + "-" + imagePath);
                }
                else
                {
                    Util.WriteToScreen("No, Element Exist", ConsoleColor.Red);
                }

                string winitem = Util.Parse(imagePath);
                Console.WriteLine(winitem);

                Thread.Sleep(500);

                //string xPN = "/html/body/div[1]/div[2]/div/div/div/p[1]/strong"; //IW Flip and Win Game
                string prizeName = Util.GetTextByXpath(driver, "/html/body/div[1]/div/div/div/p[1]/strong"); //IW Scratch and Win game

                if (prizeName != null)
                {
                    Util.WriteToScreen(prizeName, ConsoleColor.Yellow);
                    messages.Add(prizeName);
                }

                // xpath for plays left upon winning physical prize
                // string xPL = "/html/body/div[1]/div[2]/div/div/div/p[3]"; // 11/30/18 Flip and Win
                string xPL = "/html/body/div[1]/div/div/div/p[3]"; // 12/13/18 Scratch and Win
                IWebElement xPlaysLeft = null; // 12/01/18
                var xPathPL = By.XPath(xPL);
                string luck = "Test your luck again";



                // xpath for look email upon winning physical prize ( no pts win)
                //string xLE = "/html/body/div[1]/div[2]/div/div/div/p[2]"; // 11/30/18 IW Flip and Win
                string xLE = "/ html/body/div[1]/div/div/div/p[2]"; // 12/13/18 IW Scratch and Win
                IWebElement xLookEmail = null; //11/30/18
                var xPathLE = By.XPath(xLE);
                string look = "Look for an email about how to claim your prize";

                try
                {
                    if (xPathPL != null)
                    {
                        xPlaysLeft = driver.FindElement(xPathPL);
                        if (xPlaysLeft != null)
                        {
                            string text2 = xPlaysLeft.Text;

                            if (text2.Contains(luck) == true)
                            {
                                Console.WriteLine(text2);

                                messages.Add("---" + text2);

                            }
                        }
                    }

                    if (xPathLE != null)
                    {
                        xLookEmail = driver.FindElement(xPathLE);
                        if (xLookEmail != null)
                        {
                            string text3 = xLookEmail.Text;

                            if (text3.Contains(look) == true)
                            {
                                Console.WriteLine(text3);
                                messages.Add("---" + text3);
                            }
                            else if (text3.Contains(luck) == true) // will be the same path when player win points only
                            {
                                Console.WriteLine(text3);
                                messages.Add("---" + text3);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //nothing
                }


                ////- uncomment to target specific win
                //if (prizeName.Contains(prizewon) == true)
                //{
                //    Util.WriteToScreen("We won the " + prizewon, ConsoleColor.Green);
                //    Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                //    var filePath = screenshotdir + Util.Parse(imagePath) + ".jpeg";
                //    if (!File.Exists(filePath))
                //    {
                //        prizewonscreenshot.SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);
                //    }
                //    break;
                //}
                //else
                //{
                //    Util.WriteToScreen("Keep playing to win " + prizewon, ConsoleColor.Red);
                //}
                ////--------------------------

                //string screenshotdir = @"\screenshotsSWCAFr\";
                //string screenshotdir = @"\screenshotsSWCAEn\";

                var file = @"C:" + screenshotdir + winitem + ".jpeg";
                //var file = Directory.GetCurrentDirectory() + screenshotdir + winitem + ".jpeg";
                //string  dirfile = "C:\Users\rreyes\source\repos\SeleniumWithCSharp\GetSharpenWithC\Selectors\SeleniumSelectors\ForMSIW-SW-UKDEFR\bin\Debug"
                if (!File.Exists(file))
                {
                    Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    prizewonscreenshot.SaveAsFile(file, ScreenshotImageFormat.Jpeg);
                }

                IWebElement clsPtsElmnt = Util.GetElementByClassName(driver, "points");

                if (clsPtsElmnt != null)
                {
                    Console.WriteLine(clsPtsElmnt.Text);
                    playAgain = false;
                }
                else
                {
                    playAgain = true;

                    clsBtnElmnt = driver.FindElement(By.ClassName(clsBtn));
                    Console.WriteLine(clsBtnElmnt.Text);

                    Thread.Sleep(2000);

                    if (clsBtnElmnt.Displayed)
                    {
                        clsBtnElmnt.Click();
                    }
                    else
                    {
                        Util.WriteToScreen("No, Element " + clsBtn + " Exist", ConsoleColor.Red);

                    }
                }
            }

            //write to file
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                foreach (var item in messages)
                {
                    sw.WriteLine(item);
                }
            }

        }
    }

    public static class Util
    {
        //public static string Parse(string input)
        //{
        //    var s = input.Replace(".png", "").Split('_');

        //    if (s.Length == 2)
        //        return "SWP_SWEEPENTRY";

        //    return s[s.Length - 1] + "_" + s[s.Length - 2];
        //}

        public static string Parse(string input)
        {
            var s = input.Replace(".png", "").Split('_');

            if (s[1] == "SWEEPSENTRY")
                return "SW_SWEEPSENTRY";

            return s[s.Length - 2] + "_" + s[s.Length - 1];
        }

        public static void WriteToScreen(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string GetTextByXpath(IWebDriver driver, string xPath)
        {
            var element = driver.FindElement(By.XPath(xPath));
            return element.Text;
        }

        public static IWebElement GetElementByClassName(IWebDriver driver, string className)
        {
            var byClass = By.ClassName(className);
            IWebElement element = null;

            try
            {
                if (byClass != null)
                {
                    element = driver.FindElement(byClass);
                    if (element != null)
                    {
                        Console.WriteLine(element.Text);
                    }
                }
            }
            catch (Exception)
            {
                //EAT
            }

            return element;

        }
    }
}
