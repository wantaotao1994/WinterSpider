
using Microsoft.Extensions.Hosting;
using System;

namespace WinterSpider
{
    class Program
    {
        static void Main(string[] args)
        {


            var host = new HostBuilder()

                .ConfigureServices(Startup.ConfigService);
            host.RunConsoleAsync();


        }

        static void BuildRunAsync()
        {
          
        }


    }
}
