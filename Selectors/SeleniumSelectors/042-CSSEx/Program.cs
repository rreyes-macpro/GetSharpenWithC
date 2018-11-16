
using System;
using common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Drawing;
//msiw

class ChkClass
{
    //static IWebDriver driver = new ChromeDriver();
    //IWebElement element = driver.FindElement(By.ClassName(className));
    static IWebElement cssPathEmailElement;
    static IWebElement cssPathPWElement;
    static IWebElement cssPathPWCElement;
    static IWebElement idFNElement;
    static IWebElement idLNElement;
    static IWebElement idAddElement;
    static IWebElement idCityElement;
    static IWebElement idProvElement;
    static IWebElement idZipElement;
    static IWebElement cssPathMoElement;
    static IWebElement cssPathDtElement;
    static IWebElement cssPathYrElement;
    static IWebElement idTCElement;
    static IWebElement idJoinNowElement;
    static IWebElement cssPathVIElement;

    //IWebElement element = driver.FindElement(By.CssSelector(csselector));
    static void Main()
    {
        //string url = "https://bauschrewardsuat.icgrouplp.com/register?returnUrl=%2F";
        //string url = "https://bauschrewardsuat.icgrouplp.com/register?returnUrl=%2F";  // UAT
        string url = "https://bauschrewards.icgrouplp.local/register?returnUrl=%2F"; // DEV
        string cssPathEmail = "#EmailAddress";
        string cssPathPW = "#Password";
        string cssPathPWC = "#PasswordConfirmation";
        string idFN = "FirstName";
        string idLN = "LastName";
        string idAdd = "Address1";
        string idCity = "City";
        string idProv = "ProvinceStateCode";
        string idZip = "PostalZipCode";
        string cssPathMo = "#regform > div:nth-child(6) > div > select.date-picker-month.date-picker > option:nth-child(2)";
        string cssPathDt = "#regform > div:nth-child(6) > div > select.date-picker-day.date-picker > option:nth-child(2)";
        string cssPathYr = "#regform > div:nth-child(6) > div > select.date-picker-year.date-picker > option:nth-child(21)";
        //string idTC = "control_indicator";
        //string idTC = "HasAcceptedRules";
        //string idTC = "#regform > div.control-group > label:nth-child(3)";
        string idTC = "//*[@id=\"regform\"]/div[6]/label[2]/div";
        string idJoinNow = "JoinNow";
        //string cssPathVI= "#regform > div.validation-summary-errors > ul > li";
        string cssPathVI = "//*[contains(text(), 'You are not eligible to participate. Please see the Terms and Conditions for more information.')]";


        string path = @"C:\Users\rreyes\Documents\BL\Rewards\testoutputbl\MyTest.txt";

        //string csselector = "body > div.flip.flip - landing > div.play > button";






        //IWebElement element = driver.FindElement(By.ClassName(className));
        //IWebElement cssPathEmailElement = driver.FindElement(By.CssSelector(cssPathEmail));
        //IWebElement cssPathPWElement = driver.FindElement(By.CssSelector(cssPathPW));
        //IWebElement cssPathPWCElement = driver.FindElement(By.CssSelector(cssPathPWC));
        //IWebElement element = driver.FindElement(By.CssSelector(csselector));


        //////////////////////////////////loop
        int counter = 0;
        string line;

        // Read the file and display it line by line.  
        System.IO.StreamReader file =
        //new System.IO.StreamReader(@"C:\Users\rreyes\Documents\BL\Rewards\blacklisteddomains.txt");
        new System.IO.StreamReader(@"C:\Users\rreyes\Documents\BL\Rewards\blacklisteddomains3.txt");
        while ((line = file.ReadLine()) != null)
        {

            //string cssPathEmail = "#EmailAddress";
            IWebDriver driver = new ChromeDriver();
            //Console.WriteLine(driver.Manage().Window.Size);
            // set window size
            driver.Manage().Window.Size = new Size(850, 950);
            //Console.WriteLine(driver.Manage().Window.Size);

            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            cssPathEmailElement = driver.FindElement(By.CssSelector(cssPathEmail));
            //Thread.Sleep(1000);
            cssPathEmailElement.SendKeys(line);
            //Thread.Sleep(1000);

            cssPathPWElement = driver.FindElement(By.CssSelector(cssPathPW));
            //Thread.Sleep(1000);
            cssPathPWElement.SendKeys("icgQuality1!");
            //Thread.Sleep(1000);
            //System.Console.WriteLine(line);


            cssPathPWCElement = driver.FindElement(By.CssSelector(cssPathPWC));
            cssPathPWCElement.SendKeys("icgQuality1!");
            


            idFNElement = driver.FindElement(By.Id(idFN));
            idFNElement.SendKeys("icgRamon");



            idLNElement = driver.FindElement(By.Id(idLN));
            idLNElement.SendKeys("Qa");
           

            idAddElement = driver.FindElement(By.Id(idAdd));
            idAddElement.SendKeys("123 Dovercourt Dr");
            


            idCityElement = driver.FindElement(By.Id(idCity));
            idCityElement.SendKeys("Winterpeg");
            

            idProvElement = driver.FindElement(By.Id(idProv));
            idProvElement.SendKeys("Alabama");


            idZipElement = driver.FindElement(By.Id(idZip));
            idZipElement.SendKeys("45001");

            cssPathMoElement = driver.FindElement(By.CssSelector(cssPathMo));
            cssPathMoElement.Click();

            cssPathDtElement = driver.FindElement(By.CssSelector(cssPathDt));
            cssPathDtElement.Click();

            cssPathYrElement = driver.FindElement(By.CssSelector(cssPathYr));
            cssPathYrElement.Click();

            Thread.Sleep(1000);

            //idTCElement = driver.FindElement(By.CssSelector(idTC));
            idTCElement = driver.FindElement(By.XPath(idTC));
            idTCElement.Click();

            Thread.Sleep(1000);

            idJoinNowElement = driver.FindElement(By.Id(idJoinNow));
            Console.WriteLine(idJoinNowElement.Text);
            idJoinNowElement.Click();

            Thread.Sleep(1000);

            try
            {
                cssPathVIElement = driver.FindElement(By.XPath(cssPathVI));


                if (cssPathVIElement.Displayed)
                {
                    message.GreenMessage("Yes, An Element ID '" + cssPathVI + "' Has Been Found");
                    Console.WriteLine(cssPathVIElement.Text);

                }
                else
                {
                    message.RedMessage("No,  Element Does Not Exist For " + line);
                }

            }
            catch 
            {
                var msg = line + " is NOT Blacklisted. Found in row number " + (counter + 1);
                message.RedMessage(msg);
                //string path = @"C:\Users\rreyes\Documents\BL\Rewards\testoutputbl\MyTest.txt";
                // This text is added only once to the file.
                //if (!File.Exists(path))
                //{
                //    // Create a file to write to.
                //    using (StreamWriter sw = File.CreateText(path))
                //    {
                //        sw.WriteLine(line + " is NOT Blacklisted. Found in array " + (counter));
                //        sw.WriteLine("And");
                //        sw.WriteLine("Welcome");
                //    }
                //}

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(msg);
                }

            }



            //cssPathVIElement = driver.FindElement(By.XPath(cssPathVI));


            //if (cssPathVIElement.Displayed)
            //{
            //    message.GreenMessage("Yes, An Element ID '" + cssPathVI + "' Has Been Found");
            //    Console.WriteLine(cssPathVIElement.Text);

            //}
            //else
            //{
            //    message.RedMessage("No,  Element Does Not Exist For " + line);
            //}



            counter++;
            Thread.Sleep(3000);

            driver.Quit();
        }

        file.Close();
        System.Console.WriteLine("There were {0} lines.", counter);
        // Suspend the screen.  
        System.Console.ReadLine();
        ////////////////////////////////loop end






        //Console.WriteLine(element.Text);
        //Console.WriteLine(cssPathEmailElement.Text);
        //Console.WriteLine(cssPathPWElement.Text);
        //Console.WriteLine(cssPathPWCElement.Text);

        //Thread.Sleep(3000);

        //if (element.Displayed)
        //{
        //    message.GreenMessage("Yes, An Element ID '" + className + "' Has Been Found");
        //    //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

        //}
        //else
        //{
        //    message.RedMessage("No,  Element " + className + " Exist");
        //    //message.RedMessage("No,  Element " + csselector + " Exist");
        //}


        //if (cssPathEmailElement.Displayed)
        //{
        //    message.GreenMessage("Yes, An Element " + cssPathEmail + " Has Been Found");
        //    //message.GreenMessage("Yes, An Element cssPath  Has Been Found");
        //    //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

        //}
        //else
        //{
        //    message.RedMessage("No,  Element " + cssPathEmail + " Exist");
        //    //message.RedMessage("No,  Element " + csselector + " Exist");
        //}


        //if (cssPathPWElement.Displayed)
        //{
        //    message.GreenMessage("Yes, An Element ID '" + cssPathPW + "' Has Been Found");
        //    //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

        //}
        //else
        //{
        //    message.RedMessage("No,  Element " + cssPathPW + " Exist");
        //    //message.RedMessage("No,  Element " + csselector + " Exist");
        //}

        //if (cssPathPWCElement.Displayed)
        //{
        //    message.GreenMessage("Yes, An Element ID '" + cssPathPWC + "' Has Been Found");
        //    //message.GreenMessage("Yes, An Element ID '" + csselector + "' Has Been Found");

        //}
        //else
        //{
        //    message.RedMessage("No,  Element " + cssPathPWC + " Exist");
        //    //message.RedMessage("No,  Element " + csselector + " Exist");
        //}
        ////driver.Quit();
    }




}
