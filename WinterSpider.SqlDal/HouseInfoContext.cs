using System;
using Microsoft.EntityFrameworkCore;
using WinterSpider.Model;

namespace WinterSpider.SqlDal
{
    public class HouseInfoContext:DbContext
    {
        
        public HouseInfoContext(DbContextOptions<HouseInfoContext> options)
            : base(options)
        { }


        public DbSet<HouseInfo> HouseInfos { get; set; }

    }
    

    
}
    