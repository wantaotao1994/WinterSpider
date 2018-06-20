using System;
using System.Collections.Generic;
using System.Text;

namespace WinterSpider.Host
{
   public static class ProxQueue
    {

        public static Queue<string> IpProxQueue;
        static ProxQueue()
        {
            IpProxQueue = new Queue<string>();
        }



    }
}
