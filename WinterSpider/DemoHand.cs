using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using HtmlAgilityPack;
using WinterSpider.Host;
using WinterSpider.Model;

namespace WinterSpider
{
    public class DemoHand:IHandHtml
    {
        IList<HouseInfo> _houseInfos = new List<HouseInfo>();
        public HtmlDocument htmlDocument { get; set; }
        public void DoHandHtml(string html)
        {
            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var  list=   htmlDocument.DocumentNode.SelectNodes("//body/div[@class='mainbox']/div[@class='main']/div[@class='content']/div[@class='listBox']/ul/li");
            int totle = list.Count - 1; //最后一个li是list
            for (int i = 0; i < list.Count-1; i++)
            {
                var  houseInfo = new HouseInfo();
                var desEle = list[i].SelectSingleNode("div[@class='des']");  //<div clas="des">
                if (desEle!=null)
                {
                    var titleEle = desEle.SelectSingleNode("h2/a");  //title
                    if (titleEle!=null)
                    {
                        houseInfo.Title = titleEle.InnerText.Replace(" ","").Replace("\n","");
                        houseInfo.Url = titleEle.GetAttributeValue("href", "");
                    }

                    var roomDes = desEle.SelectSingleNode("p[@class='room']");
                    string romText = roomDes.InnerText.Replace("&nbsp;&nbsp;&nbsp;&nbsp;","");
                    string[] arr = romText.Split(' ');
                    houseInfo.Type = arr[0];
                    houseInfo.Size = arr[arr.Length - 1];


                    var addEle = desEle.SelectSingleNode("p[@class='add']");
                    var firstA = addEle.SelectSingleNode("a[1]");
                    var  lastA =  addEle.SelectSingleNode("a[last()]");
                    if (firstA!=null)
                    {
                        houseInfo.Address = firstA.InnerText;
                    }
                    if (lastA!=null)
                    {
                        houseInfo.Community = firstA.InnerText;
                    }
                    
                    var listlirightEle = list[i].SelectSingleNode("div[@class='listliright']");  //<div clas="listliright">


                    if (listlirightEle!=null)
                    {
                        var sendTimeEle = listlirightEle.SelectSingleNode("div[@class='sendTime']");

                        var moneyEle = listlirightEle.SelectSingleNode("div[@class='money']/b");

                        if (sendTimeEle!=null)
                        {
                            string text = sendTimeEle.InnerText;

                            if (string.IsNullOrEmpty(text)||text.Contains("前"))
                            {
                                text = $"{DateTime.Now.Month}-{DateTime.Now.Day}";
                            }
                            houseInfo.SendTime =text;

                        }

                        if (moneyEle!=null)
                        {
                            houseInfo.Price = moneyEle.InnerText;
                        }
                    }
                    
                    _houseInfos.Add(houseInfo);

                }
            }
            

            
            
        }
    }
}