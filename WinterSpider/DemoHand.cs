using System;
using System.Collections.Generic;
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

            var  list=   htmlDocument.DocumentNode.SelectNodes("//body/div/div/div");
            foreach (var item in list)
            {
                string name = item.Attributes["class"].Value;
                if (name=="content")
                {
                    var liDocument=  item.SelectNodes("//div/ul/li/div/div/b"); //价钱

                    var time=  item.SelectNodes("//div/ul/li/div"); //时间
                    

                    var titleDocument = item.SelectNodes("//div/ul/li/div"); //标题
                    
                    
                    var document = item.SelectNodes("//div/ul/li/div/p"); //


                    int flag = 0;
                    
                    foreach (var money in liDocument)
                    {
                        _houseInfos.Add(new HouseInfo()
                        {
                           Price= money.InnerText
                        });
                        
                    }

                    foreach (var title in titleDocument)
                    {
                        string className = title.GetAttributeValue("class","");

                        if (className=="des")
                        {
                            var singleTitleEle = title.SelectSingleNode("//h2/a");
                            Console.WriteLine( singleTitleEle.InnerText+","+flag);
                            flag++;
                        }

                        /*var  refObj=  _houseInfos[flag];
                        
                        refObj.Title =     title.InnerText.Trim() ;
                        refObj.Url = title.Attributes["href"].Value;
                        flag++;*/
                    }

                    flag = 0;
                    foreach (var  pRef in document)
                    {
                        string className = pRef.GetAttributeValue("class","");
                        if (className=="room")
                        {
                            //todo  房型 
                            
                            var  refObj=  _houseInfos[flag];
                            refObj.Type = pRef.InnerText;
                            
                            flag++;
                            
                        }
                         if (className=="add")
                        {
                              var addressDoment = pRef.SelectNodes("//a");
                           
                               string  text =   pRef.ChildNodes[1].InnerText;
                               string  comu =   pRef.ChildNodes[3].InnerText;

                                Console.WriteLine(text);

                                var  refObj=  _houseInfos[flag];
                                refObj.Address = text;
                                 refObj.Community = comu;

                                flag++;
                                
                            
                        }
                    }

                    flag = 0;
                    foreach (var timeDoc in time)
                    {
                        string className = timeDoc.GetAttributeValue("class","");

                        if (className=="sendTime")
                        {
                            string timeText = timeDoc.InnerText;

                            if (timeText.Contains("前"))
                            {
                                timeText = $"{DateTime.Now.Month}-{DateTime.Now.Day}";
                                
                            }
                            var  refObj=  _houseInfos[flag];
                            refObj.SendTime = timeText;
                            Console.WriteLine(refObj.SendTime);

                            flag++;
                        }
                    }


                    int a = 0;
                }
                
            }
            
        }
    }
}