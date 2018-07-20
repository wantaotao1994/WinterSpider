using System;
using System.Collections.Generic;
using System.Text;

namespace WinterSpider.Core
{
  public  interface IScheduler
    {

        void Push();

        Page Poll();

    }
}
