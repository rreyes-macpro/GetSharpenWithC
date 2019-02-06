using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Drawing;

namespace IWDe
{
    class Iwde
    {
        static IWebElement cssReadyElmnt;
        static IWebElement clsBtnElmnt;
        static IWebElement idPrizeImage; // element id variable for prize image path name
        //static IWebElement xPathPN;
        static IWebDriver driver = new ChromeDriver();

        static void Main()
        {
            string url = "https://promosuat.icgrouplp.com/DE/de/handshake?uid=837FA97A9C2C85B7046A2163FFFFFFFF&token=c24f7ad0-f72e-40cd-b9a5-80a946b02c6a&gpid=MS_SW_UAT_JAN_DE_19-30&c=a5831c3eb514f7f439afed9420e1d431d11bcc3767438c7dee03319f527ec6a2";
            string cssReady = "body > div.scratch.scratch-win > div";
            string clsBtn = "btn";
            string idPI = "prizeImage";
            //string clsPN = "prize-details"; // this class holds all the text within win page
            string path = @"C:\iwwinlogs\DE\ScratchNWinListDE.txt";




            var playAgain = true;
            //using (StreamWriter sw1 = File.CreateText(path + timestmp +" .txt" ))
            driver.Navigate().GoToUrl(url);

            while (playAgain)
            {

                string timestmp = DateTime.Now.ToString("yyyy-MM-dd-T-HH-mm-ss");

                cssReadyElmnt = driver.FindElement(By.CssSelector(cssReady));
                Console.WriteLine(cssReadyElmnt.Text);
                Console.WriteLine(timestmp);
                Thread.Sleep(1000);
                cssReadyElmnt.Click();
                Thread.Sleep(1000);

                idPrizeImage = driver.FindElement(By.Id(idPI));
                string text = idPrizeImage.GetAttribute("src");
                //string prizewon = "ASUS Windows Mixed Reality"; //"BURGER"; //"SWEEPS";



                if (idPrizeImage.Displayed)
                {
                    Console.WriteLine(idPrizeImage.Text);
                    Console.WriteLine(text);

                    //using (StreamWriter sw1 = File.CreateText(path))
                    using (StreamWriter sw2 = File.AppendText(path))
                    {
                        sw2.WriteLine(timestmp + "-" + text);
                    }
                }
                else
                {
                    message.RedMessage("No,  Element Exist");
                    //clsBtnElmnt = driver.FindElement(By.ClassName(clsBtn));
                    //clsBtnElmnt.Click();
                }

                string winitem = Parse(text);
                Console.WriteLine(winitem);



                Thread.Sleep(500);

                //string xPN = "/html/body/div[1]/div[2]/div/div/div/p[1]/strong"; //IW Flip and Win Game
                string xPN = "/html/body/div[1]/div/div/div/p[1]/strong";  //IW Scratch and Win game
                                                                           //IWebElement xPathPN = null;
                var xPathPrizeName = driver.FindElement(By.XPath(xPN));
                string text5 = xPathPrizeName.Text;
                if (xPathPrizeName.Displayed)
                {
                    message.YellowMessage(text5);
                    using (StreamWriter sw5 = File.AppendText(path))
                    {
                        sw5.WriteLine(text5);
                    }
                }

                // xpath for plays left upon winning physical prize
                // string xPL = "/html/body/div[1]/div[2]/div/div/div/p[3]"; // 11/30/18 Flip and Win
                string xPL = "/html/body/div[1]/div/div/div/p[3]"; // 12/13/18 Scratch and Win
                IWebElement xPlaysLeft = null; // 12/01/18
                var xPathPL = By.XPath(xPL);

                // xpath for plays left upon winning points only
                //string xPL2 = "/html/body/div[1]/div[2]/div/div/div/p[2]"; // 12/01/18
                //IWebElement xPlaysLeft2 = null; // 12/01/18
                //var xPathPL2 = By.XPath(xPL2);
                //string luck2 = "Test your luck";

                // xpath for look email upon winning physical prize ( no pts win)
                //string xLE = "/html/body/div[1]/div[2]/div/div/div/p[2]"; // 11/30/18 IW Flip and Win
                string xLE = "/ html/body/div[1]/div/div/div/p[2]"; // 12/13/18 IW Scratch and Win
                IWebElement xLookEmail = null; //11/30/18
                var xPathLE = By.XPath(xLE);

                // DE
                string look = "E-Mail"; // DE
                string luck = "erneut"; // DE

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
                                using (StreamWriter sw3 = File.AppendText(path))
                                {
                                    sw3.WriteLine("---" + text2);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //nothing
                }
                try
                {
                    if (xPathLE != null)
                    {
                        xLookEmail = driver.FindElement(xPathLE);
                        if (xLookEmail != null)
                        {
                            string text3 = xLookEmail.Text;

                            if (text3.Contains(look) == true)
                            {
                                Console.WriteLine(text3);
                                using (StreamWriter sw3 = File.AppendText(path))
                                {
                                    sw3.WriteLine("---" + text3);
                                }
                            }
                            else
                            if (text3.Contains(luck) == true)  // will be the same path when player win points only
                            {
                                Console.WriteLine(text3);
                                using (StreamWriter sw3 = File.AppendText(path))
                                {
                                    sw3.WriteLine("---" + text3);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    //nothing
                }




                //if (text.Contains(prizewon) == true)
                //------------------------------------------
                //uncomment to isolate a specific win item
                //if (text5.Contains(prizewon) == true)
                //{
                //    message.GreenMessage("We won the " + prizewon);
                //    Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                //    string screenshotdir = @"\screenshotsSWUK\";
                //    //string screenshotdir = @"\screenshotsSWDE\";
                //    //string screenshotdir = @"\screenshotsSWFR\";
                //    //string screenshotdir = @"\screenshotsSWCAEn\";
                //    //string screenshotdir = @"\screenshotsSWCAFr\";
                //    //prizewonscreenshot.SaveAsFile(Directory.GetCurrentDirectory() + screenshotdir + prizewon + "-" + timestmp + ".jpeg", ScreenshotImageFormat.Jpeg);
                //    prizewonscreenshot.SaveAsFile(Directory.GetCurrentDirectory() + screenshotdir + prizewon + ".jpeg", ScreenshotImageFormat.Jpeg);
                //    break;
                //}
                //else
                //{
                //    message.RedMessage("Keep playing to win " + prizewon);
                //}
                //-----------------------------------------

                string screenshotdir = @"\screenshotsSWDE\";
                var file = @"C:" + screenshotdir + winitem + ".jpeg";
                //var file = Directory.GetCurrentDirectory() + screenshotdir + winitem + ".jpeg";
                //string  dirfile = "C:\Users\rreyes\source\repos\SeleniumWithCSharp\GetSharpenWithC\Selectors\SeleniumSelectors\ForMSIW-SW-UKDEFR\bin\Debug"
                if (!File.Exists(file))
                {
                    Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    prizewonscreenshot.SaveAsFile(file, ScreenshotImageFormat.Jpeg);
                }

                string clsPts = "points";
                var cls = By.ClassName(clsPts);
                IWebElement clsPtsElmnt = null;

                try
                {
                    if (cls != null)
                    {
                        clsPtsElmnt = driver.FindElement(cls);
                        if (clsPtsElmnt != null)
                        {
                            Console.WriteLine(clsPtsElmnt.Text);
                        }
                    }
                }
                catch (Exception)
                {
                    //EAT
                }


                if (clsPtsElmnt != null)
                {
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
                        //message.GreenMessage("Yes, An Element ID '" + clsBtn + "' Has Been Found");
                        clsBtnElmnt.Click();
                    }
                    else
                    {
                        message.RedMessage("No,  Element " + clsBtn + " Exist");

                    }
                }


            }

        }
        public static string Parse(string input)
        {
            var s = input.Replace(".png", "").Split('_');

            if (s[1] == "SWEEPSENTRY")
                return "SW_SWEEPSENTRY";

            return s[s.Length - 2] + "_" + s[s.Length - 1];
        }
    }
}
