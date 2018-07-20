using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinterSpider.Host;
using WinterSpider.Http;
using WinterSpider.SqlDal;

namespace WinterSpider
{
    internal class Startup
    {
        internal static void ConfigService(HostBuilderContext context, IServiceCollection service)
        {

            UrlQueue.UrlStringQueue.Enqueue("http://sh.58.com/chuzu/?PGTID=0d3090a7-0000-2523-ad0d-a8dadebd9924&ClickID=2");

            
            var connection = @"server=127.0.0.1;port=3306;database=spider_house_rent;uid=root;pwd=Wan332617,;charset=utf8mb4;Connection Timeout=18000;SslMode=none;";
            service.AddDbContext<HouseInfoContext>(options => options.UseMySQL(connection));
            

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