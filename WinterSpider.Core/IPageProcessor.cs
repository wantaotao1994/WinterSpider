using System;
using System.Collections.Generic;
using System.Text;

namespace WinterSpider.Core
{
   public interface IPageProcessor
    {

         Site GetSite();

        void  Process(Page page);
    }
}
