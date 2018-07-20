using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WinterSpider.Core
{
    public interface ISpider
    {
        IMonitor Monitor { get; set; }

        IScheduler Scheduler { get; }

        IReadOnlyCollection<IPageProcessor> PageProcessor { get; set; }

        IDownloader Downloader { get; set; }

        IReadOnlyCollection<IPipeline> Pipelines { get; set; }





        void Run();

        Task RunAsync();
    }
}
