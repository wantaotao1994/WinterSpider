using System.Collections.Generic;

namespace WinterSpider.Host
{
    public class UrlQueue
    {
        public static Queue<string> UrlStringQueue;
        static UrlQueue()
        {
            UrlStringQueue = new Queue<string>();
        }

    }
}