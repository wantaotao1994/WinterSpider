using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinterSpider.Host
{
   public interface IHandHtml
    {
        HtmlDocument htmlDocument { get; set; }

        void DoHandHtml(string  html);
    }
}
