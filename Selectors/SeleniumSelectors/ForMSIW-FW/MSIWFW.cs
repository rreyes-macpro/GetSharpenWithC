﻿using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Drawing;

namespace ForMSIWFW
{
    class MSIWFW
    {
        static IWebElement cssReadyElmnt;
        static IWebElement clsBtnElmnt;
        static IWebElement idPrizeImage;
        //static IWebElement xPathPN;
        static IWebDriver driver = new ChromeDriver();

        static void Main()
        {
            string url = "https://promosuat.icgrouplp.com/GB/en/handshake?uid=837FA97A9C2C85B7046A2163FFFFFFFF&token=1e017648-23c6-487d-a42d-5a1492b0cb56&gpid=MS_SW_UAT_JAN_UK_19-10&c=686094f322b7c5184a4900d2e40b4d1147dfd6508240e4a05fc3ed287ca5a5f1";
            string cssReady = "body > div.scratch.scratch-win > div";
            string clsBtn = "btn";
            string idPI = "prizeImage";
            //string clsPN = "prize-details"; // this class holds all the text within win page
            //System.Console.WriteLine(Directory.GetCurrentDirectory()); //C:\Users\rreyes\source\repos\SeleniumWithCSharp\GetSharpenWithC\Selectors\SeleniumSelectors\ForMS\bin\Debug\screenshots
            //string path = Directory.GetCurrentDirectory();
            //string xPL = "/html/body/div[1]/div[2]/div/div/div/p[3]"; // 11/30/18
            string path = @"C: \Users\rreyes\Documents\MS\ScratchNWinListUK.txt";
            //string path = @"C: \Users\rreyes\Documents\MS\ScratchNWinListDE.txt";
            //string path = @"C: \Users\rreyes\Documents\MS\ScratchNWinListFR.txt";
            //string path = @"C: \Users\rreyes\Documents\MS\ScratchNWinListCAEn.txt";
            //string path = @"C: \Users\rreyes\Documents\MS\ScratchNWinListCAFr.txt";
            //string path = @"C: \Users\rreyes\Documents\MS\list";


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
                string prizewon = "ASUS Windows Mixed Reality"; //"BURGER"; //"SWEEPS";


                //try
                //{
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
                //}
                //catch (Exception)
                //{
                //    clsBtnElmnt.Click();
                //    continue;
                //}
                
                Thread.Sleep(500);

                //string xPN = "/html/body/div[1]/div[2]/div/div/div/p[1]/strong"; //IW Flip and Win Game
                string xPN = "/html/body/div[1]/div/div/div/p[1]/strong";  //IW Scratch and Win game
                                                                           //IWebElement xPathPN = null;
                var xPathPrizeName = driver.FindElement(By.XPath(xPN));
                string text5 = xPathPrizeName.Text;
                if (xPathPrizeName.Displayed)
                {

                    /////////////////////////////
                    //try
                    //{
                    //    //Pass the file path and file name to the StreamReader constructor
                    //    using StreamReader sr = new StreamReader(path);

                    //    //Read the first line of text
                    //    string line = sr.ReadLine();

                    //    //Continue to read until you reach end of file
                    //    while (line != null)
                    //    {
                    //        //write the line to console window
                    //        //Console.WriteLine(line);
                    //        //Read the next line
                    //        line = sr.ReadLine();
                    //        if (line.Contains(text5) == false)
                    //        {
                    //            Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    //            prizewonscreenshot.SaveAsFile(Directory.GetCurrentDirectory() + @"\screenshots\" + text5 + "-" + timestmp + ".jpeg", ScreenshotImageFormat.Jpeg);
                    //            message.YellowMessage(text5);
                    //            using (StreamWriter sw5 = File.AppendText(path))
                    //            {
                    //                sw5.WriteLine(text5);

                    //            }

                    //        }
                    //        else
                    //        {
                    //            message.YellowMessage(text5);
                    //            using (StreamWriter sw5 = File.AppendText(path))
                    //            {
                    //                sw5.WriteLine(text5);

                    //            }
                    //        }

                    //    }

                    //    //close the file
                    //    StreamReader.Close();
                    //    //Console.ReadLine();
                    //}

                    //catch (Exception)
                    //{
                    //    //Console.WriteLine("Exception: " + e.Message);
                    //    //nothing

                    //}
                    //Console.ReadKey();
                    //finally
                    //{
                    //    //Console.WriteLine("Executing finally block.");
                    //    //nothing
                    //}
                    ////////////////////////////////


                    message.YellowMessage(text5);
                    using (StreamWriter sw5 = File.AppendText(path))
                    {
                        sw5.WriteLine(text5);
                    }
                }


                ////////////////////////////////////////////

                //if (idPrizeImage.Displayed)
                //{
                //    Console.WriteLine(idPrizeImage.Text);
                //    Console.WriteLine(text);

                //    //using (StreamWriter sw1 = File.CreateText(path))
                //    using (StreamWriter sw2 = File.AppendText(path))
                //    {
                //        sw2.WriteLine(timestmp + "-" + text);
                //    }
                //}
                //else
                //{
                //    message.RedMessage("No,  Element " + idPI + " Exist");
                //}
                //Thread.Sleep(500);


                /////////////////////////////////////////
                //this block reads and writes ALL the text on the winning page
                //string clsPN = "prize-details"; // 12/01/18
                // IWebElement clsPrizeName = null; // 12/01/18
                // var classNamePN = By.ClassName(clsPN);
                // string youjustwon = "You just won";


                // try
                // {
                //     if (classNamePN != null)
                //     {
                //         clsPrizeName = driver.FindElement(classNamePN);
                //         if (clsPrizeName != null)
                //         {
                //             string text4 = clsPrizeName.Text;

                //             if (text4.Contains(youjustwon) == true)
                //             {
                //                 Console.WriteLine(text4);
                //                 using (StreamWriter sw4 = File.AppendText(path))
                //                 {
                //                     sw4.WriteLine(text4);
                //                 }
                //             }
                //         }
                //     }
                // }
                // catch (Exception)
                // {
                //     //nothing
                // }
                /////////////////////////////////////////////////////////////////////


                // xpath for plays left upon winning physical prize
                // string xPL = "/html/body/div[1]/div[2]/div/div/div/p[3]"; // 11/30/18 Flip and Win
                string xPL = "/html/body/div[1]/div/div/div/p[3]"; // 12/13/18 Scratch and Win
                IWebElement xPlaysLeft = null; // 12/01/18
                var xPathPL = By.XPath(xPL);
                string luck = "Test your luck again";

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
                if (text5.Contains(prizewon) == true)
                {
                    message.GreenMessage("We won the " + prizewon);
                    Screenshot prizewonscreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    string screenshotdir = @"\screenshotsSWUK\";
                    //string screenshotdir = @"\screenshotsSWDE\";
                    //string screenshotdir = @"\screenshotsSWFR\";
                    //string screenshotdir = @"\screenshotsSWCAEn\";
                    //string screenshotdir = @"\screenshotsSWCAFr\";
                    prizewonscreenshot.SaveAsFile(Directory.GetCurrentDirectory() + screenshotdir + prizewon + "-" + timestmp + ".jpeg", ScreenshotImageFormat.Jpeg);
                    break;
                }
                else
                {
                    message.RedMessage("Keep playing to win " + prizewon);
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
    }
}



