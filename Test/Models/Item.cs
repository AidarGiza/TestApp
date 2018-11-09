using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemCost { get; set; }
        public int ItemSizeID { get; set; }
        public string Description { get; set; }
    }
}