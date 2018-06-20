using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace WinterSpider.Host
{
    public class SpiderStartup:IHost
    {
        private readonly SpiderContext _spiderContext;
        public SpiderStartup(IServiceProvider services, SpiderContext spiderContext)
        {
            Services = services;
            _spiderContext = spiderContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task StartAsync(CancellationToken cancellationToken = new CancellationToken())
        {
           await _spiderContext.BeginWorkAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public IServiceProvider Services { get; }
    }
}