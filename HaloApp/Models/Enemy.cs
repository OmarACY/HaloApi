using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaloApp.Models
{
    public class Enemy
    {
        public string Faction { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string SmallIconImageUrl { get; set; }
        public string Id { get; set; }
        public string ContentId { get; set; }       
    }
}