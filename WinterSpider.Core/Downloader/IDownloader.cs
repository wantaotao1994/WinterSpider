﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WinterSpider.Core
{
   public interface IDownloader
    {

        Page DownLoadRequest(Request request);
    }
}
