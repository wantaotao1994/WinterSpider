using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinterSpider.Host;
using WinterSpider.Http;

namespace WinterSpider
{
    internal class Startup
    {
        internal static void ConfigService(HostBuilderContext context, IServiceCollection service)
        {

            UrlQueue.UrlStringQueue.Enqueue("http://sh.58.com/chuzu/?PGTID=0d3090a7-0000-2523-ad0d-a8dadebd9924&ClickID=2");


            service.AddSingleton(new SpiderConfig()
            {
               MaxPool = 5
                
            });
            
            service.AddTransient<SpiderContext>();
            
            service.AddTransient<SpiderHttpUtility>();

            service.AddSingleton<IHandHtml,DemoHand>();
            service.AddSingleton<IHost, SpiderStartup>();
        }
    }
}