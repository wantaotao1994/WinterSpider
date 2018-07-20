using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WinterSpider.Core
{
    public class Spider : ISpider,ISpiderTask
    {

        private string _taskId;


        private Site _site;

        public int MaxThread = 4; //默认为4
        public Spider()
        {
            _taskId = new Guid().ToString();

        }

        public Spider(string taskId) {
            _taskId = taskId;

        }

        public IMonitor Monitor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IScheduler Scheduler => throw new NotImplementedException();

        public IReadOnlyCollection<IPageProcessor> PageProcessor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDownloader Downloader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public IReadOnlyCollection<IPipeline> Pipelines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Site GetTaskSite()
        {
            return _site;
        }

        public void Run()
        {
            Parallel.For(0, MaxThread, new ParallelOptions()
            {
                MaxDegreeOfParallelism = MaxThread
            },i=>{

                var request = Scheduler.Poll();


            });

        }


        private void DoDownLoad(Request  request) {

          Page page =   Downloader.DownLoadRequest(request);
        }

        private void HandProcessor(Page  page) {
            foreach (var item in PageProcessor)
            {
                item.Process(page);
            }

        }

        private void HandPipeline()
        {
            foreach (var item in Pipelines)
            {
               
            }
        }

        public Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public string TaskId() => this._taskId;
    }
}
