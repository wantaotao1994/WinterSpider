using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinterSpider.Http
{
    public  class SpiderHttpUtility
    {
        public  async Task<string>  GetResponseAsync(string url)
        {

            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);

            SetHttpHead(httpWebRequest);
            string retString = string.Empty;
            try
            {
                var response = await httpWebRequest.GetResponseAsync();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine(e.StackTrace);
            }
            return retString;

        }


        private void SetHttpHead(HttpWebRequest httpWebRequest,bool isMobile = false)
        {
            string userAngent = string.Empty;
            Random random = new Random(DateTime.Now.Millisecond);
            int index;
            if (isMobile)
            {
                index =  random.Next(0,HttpUserAngent.MobileUserAngent.Count-1);

                userAngent = HttpUserAngent.MobileUserAngent[index];
            }
            else
            {
                index = random.Next(0, HttpUserAngent.PcUserAngent.Count - 1);
                userAngent = HttpUserAngent.PcUserAngent[index];
            }


            httpWebRequest.Headers["user-agent"] =userAngent;

        }

        





    }
}
