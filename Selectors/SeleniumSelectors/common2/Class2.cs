using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common2
{
    public class Class2
    {
        public static void Prizename(string pname)
        {
            //this block reads and writes ALL the text on the winning page
            string clsPN = "prize-details"; // 12/01/18
            IWebElement clsPrizeName = null; // 12/01/18
            var classNamePN = By.ClassName(clsPN);
            string youjustwon = "You just won";

            / try
            {
                if (classNamePN != null)
                {
                    clsPrizeName = driver.FindElement(classNamePN);
                    if (clsPrizeName != null)
                    {
                        string text4 = clsPrizeName.Text;

                        if (text4.Contains(youjustwon) == true)
                        {
                            Console.WriteLine(text4);
                            using (StreamWriter sw4 = File.AppendText(path))
                            {
                                sw4.WriteLine(text4);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //nothing
            }
        }
    }
}


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