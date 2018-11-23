using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NameSelectorTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://testing.todorvachev.com/selectors/name/");


            IWebElement element = driver.FindElement(By.Name("myName"));

            //Thread.Sleep(3000);


            Assert.IsTrue(element.Displayed, "An element has been found.");

        }

        [TestMethod]
        public void IdSelectorTest()
        {
            string url = "http://testing.todorvachev.com/selectors/id/";
            string ID = "testImage";
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);


            IWebElement iDelement = driver.FindElement(By.Id(ID));


            Assert.IsTrue(iDelement.Displayed, "An element " + ID + " has been found by id.");

        }

        [TestMethod]
        public void CssXpathTest()
        {
            string url = "https://bauschrewards.icgrouplp.local/register?returnUrl=%2F";
            //string className = "btn btn-long";
            string cssPath = "#regform > div.control-group > label:nth-child(3)";
            string xPath = "//*[@id=\"regform\"]/div[6]/label[2]";

            //string csselector = "body > div.flip.flip - landing > div.play > button";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);



            //IWebElement element = driver.FindElement(By.ClassName(className));
            IWebElement cssPathElement = driver.FindElement(By.CssSelector(cssPath));
            IWebElement xPathElement = driver.FindElement(By.XPath(xPath));



            Assert.IsTrue(cssPathElement.Displayed, "An element " + cssPath + "has been found by CSS");
            Assert.IsTrue(xPathElement.Displayed, "An element " + xPath + "has been found by X Path");

        }
    }

}
