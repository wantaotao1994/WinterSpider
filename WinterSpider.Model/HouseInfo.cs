using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinterSpider.Model
{
    [Table("house")]
    public class HouseInfo
    {
        
        [Column("id")]
        public string Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("community")]
        public string Community { get; set; }

        
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }

        [Column("send_time")]
        public string SendTime { get; set; }

        [Column("price")]
        public string Price { get; set; }

        [Column("type")]
        public string Type { get; set; }
        
        [Column("url")]
        public string Url { get; set; }

        [Column("size")]
        public string Size { get; set; }
    }
}