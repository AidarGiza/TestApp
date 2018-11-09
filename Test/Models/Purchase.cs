using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int ItemID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}