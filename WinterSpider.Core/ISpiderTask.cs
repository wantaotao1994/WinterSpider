using System;
using System.Collections.Generic;
using System.Text;

namespace WinterSpider.Core
{
  public  interface ISpiderTask
    {

        string TaskId();

        Site GetTaskSite();

    }
}
