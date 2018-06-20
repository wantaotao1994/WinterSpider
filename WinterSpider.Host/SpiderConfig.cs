namespace WinterSpider.Host
{
    public class SpiderConfig
    {

        /// <summary>
        /// 并发数
        /// </summary>
        public int MaxPool { get; set; }

        
        /// <summary>
        /// 休眠时间
        /// </summary>
        public int SleepTime { get; set; }


        /// <summary>
        /// 证书路径
        /// </summary>
        public string CreditePath { get; set; }


        public string BeginUrl { get; set; }

    }
    
}