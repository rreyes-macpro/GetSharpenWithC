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
        static IWebElement idPrizeImage;
        //static IWebElement xPlaysLeft; // 11/30/18
        static IWebDriver driver = new ChromeDriver();

        static void Main()
        {
            string url = "https://promosuat.icgrouplp.com/US/en/handshake?uid=837FA97A9C2C85B7046A2163FFFFFFFF&token=e2f518a0-ecb5-4859-8e1e-8986cf5e8ce5&gpid=MS_FW_UAT_DEC_US_18-10&c=0142b76c1206f34bcc60eb1126b001342b747c7efbca490ce7e3bd7e77289761";
            string cssReady = "body > div.flip.flip-landing > div.play > button";
            //string xGC = "/html/body/div[1]/div[2]/div/div/div/p[2]";
            //string clsPts = "points";
            string clsBtn = "btn";
            string idPI = "prizeImage";
            //string timestmp2 = DateTime.Now.ToString("yyyy-MM-dd-T-HH:mm:ss");
            //System.Console.WriteLine(Directory.GetCurrentDirectory());
            //string path = Directory.GetCurrentDirectory();

            //string xPL = "/html/body/div[1]/div[2]/div/div/div/p[3]"; // 11/30/18

            string path = @"C: \Users\rreyes\Documents\MS\list.txt";
            //string path = @"C: \Users\rreyes\Documents\MS\list";
            // string filedir = "@\'list\'winners" + timestmp + ".txt";


            //var path2 = File.Create(path + "-" + timestmp2 + ".txt");

            var playAgain = true;

            //using (StreamWriter sw1 = File.CreateText(path + timestmp +" .txt" ))

            driver.Navigate().GoToUrl(url);

            while (playAgain)
            {

                string timestmp = DateTime.Now.ToString("yyyy-MM-dd-T-HH:mm:ss");

                cssReadyElmnt = driver.FindElement(By.CssSelector(cssReady));

                Console.WriteLine(cssReadyElmnt.Text);
                Console.WriteLine(timestmp);
                Thread.Sleep(1000);

                if (cssReadyElmnt.Displayed)
                {
                    message.GreenMessage("Yes, An Element ID '" + cssReady + "' Has Been Found");
                }
                else
                {
                    message.RedMessage("No,  Element " + cssReady + " Exist");
                }

                cssReadyElmnt.Click();

                Thread.Sleep(1000);

                idPrizeImage = driver.FindElement(By.Id(idPI));
                string text = idPrizeImage.GetAttribute("src");
                //string prizewon = "FW_BING_REWARDS_CREDITS_100.png";
                string prizewon = "SWEEPS";

                if (idPrizeImage.Displayed)
                {
                    message.GreenMessage("Yes, An Element ID '" + idPI + "' Has Been Found");
                    Console.WriteLine(idPrizeImage.Text);
                    Console.WriteLine(text);

                    //using (StreamWriter sw1 = File.CreateText(path))

                    using (StreamWriter sw2 = File.AppendText(path))
                    {
                        sw2.WriteLine(timestmp +"-"+text);
                    }


                }
                else
                {
                    message.RedMessage("No,  Element " + idPI+ " Exist");
                }

                string xPL = "/html/body/div[1]/div[2]/div/div/div/p[3]"; // 11/30/18
                IWebElement xPlaysLeft  = null; // 11/30/18
                var xPathPL = By.XPath(xPL);
                //string look = "Look for an email about how to claim your prize";
                string luck = "Test your luck again";

                string xLE = "/html/body/div[1]/div[2]/div/div/div/p[2]"; // 11/30/18
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
                                using (StreamWriter sw3 = File.AppendText(path))
                                {
                                    sw3.WriteLine(text2);
                                }

                                //if (text2.Contains(look) == true)
                                //{
                                //    Console.WriteLine(text2);
                                //    using (StreamWriter sw3 = File.AppendText(path))
                                //    {
                                //        sw3.WriteLine(text2);
                                //    }
                                //}

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
                                using (StreamWriter sw3 = File.AppendText(path))
                                {
                                    sw3.WriteLine(text3);
                                }

                                //if (text2.Contains(look) == true)
                                //{
                                //    Console.WriteLine(text2);
                                //    using (StreamWriter sw3 = File.AppendText(path))
                                //    {
                                //        sw3.WriteLine(text2);
                                //    }
                                //}

                            }
                        }


                    }
                }
                catch (Exception)
                {

                    //nothing
                }

                


                if (text.Contains(prizewon) == true)
                {
                    message.GreenMessage("We won the " + prizewon);
                    Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    prizewonscreenshot.SaveAsFile(Directory.GetCurrentDirectory() + @"\screenshots\"+prizewon+".jpeg", ScreenshotImageFormat.Jpeg);
                    break;
                }
                else
                {
                    message.RedMessage("Keep playing to win " + prizewon );
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
                        message.GreenMessage("Yes, An Element ID '" + clsBtn + "' Has Been Found");
                        clsBtnElmnt.Click();
                    }
                    else
                    {
                        message.RedMessage("No,  Element " + clsBtn + " Exist");

                    }
                }


            }


            
        }
    }
}

    
