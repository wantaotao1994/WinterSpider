using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using WinterSpider.Http;

namespace WinterSpider.Host
{
    public class SpiderContext
    {
        private readonly IServiceProvider _serviceProvider;


        private readonly SpiderHttpUtility _httpUtility;

        private readonly SpiderConfig _spiderConfig;
        
        public SpiderContext(IServiceProvider serviceProvider, SpiderHttpUtility httpUtility, SpiderConfig spiderConfig)
        {
            _serviceProvider  = serviceProvider;
            _httpUtility = httpUtility;
            _spiderConfig = spiderConfig;
        }

        public  Task BeginWorkAsync()
        {
            List<Task> tasks = new List<Task>();
            
            for (int i = 0; i < _spiderConfig.MaxPool; i++)
            {
            var task =    Task.Factory.StartNew(()
                    =>
                {
                    
#pragma warning disable 4014
                    Run();
#pragma warning restore 4014
                    
                });
                tasks.Add(task);
            }

             Task.WaitAll(tasks.ToArray());

            return Task.CompletedTask;
        }

        private async Task Run()
        {
            int  flag = 0;
            
            while (flag<10)
            {

                try
                {
                    string url = string.Empty;

                    lock (UrlQueue.UrlStringQueue)
                    {
                        int urlLeft = UrlQueue.UrlStringQueue.Count;
                        if (urlLeft==0)
                        {
                            flag++;
                        }
                        else
                        {
                            url = UrlQueue.UrlStringQueue.Dequeue();
                        }
                    }

                    if (string.IsNullOrEmpty(url))
                    {
                        Thread.Sleep(3000);
                        continue;
                    }
                
                
                    string html =await _httpUtility.GetResponseAsync(url);
                    var  list = _serviceProvider.GetService<IEnumerable<IHandHtml>>();
                    foreach (var item in list)
                    {


                        item.DoHandHtml(html);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    flag = 100;
                    
                    continue;
                }
               
            }
           
            Console.WriteLine($"由于等待了30秒之后队列中还是为空，线程:{Thread.CurrentThread}工作完成");
            
        }


    }
}
