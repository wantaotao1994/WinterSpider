using System;
using WinterSpider.Http;

namespace QuickTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SpiderHttpUtility httpUtility = new SpiderHttpUtility();

                string aa = httpUtility.GetResponseAsync("http://sh.58.com/chuzu/?PGTID=0d100000-0000-2f7e-add9-ea91e0490f2a&ClickID=3").Result;
                Console.WriteLine(aa);
        
            Console.ReadLine();
        }
    }
}
