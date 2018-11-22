using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DestinationModel
    {
        public string _id { get; set; }
        public string Direction { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Description { get; set; }
        public string Activities { get; set; }
        public string PricePP { get; set; }
    }
}