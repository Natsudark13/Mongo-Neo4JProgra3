using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ReservationModel
    {
        public string Descr { get; set; }
        public string QTY { get; set; }
        public string Checkout { get; set; }
        public string SpecialNeeds { get; set; }
        public string TotalPrice { get; set; }
    }
}