using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourFairShare_MVC.Models
{
    public class BillModel
    {
        public string Name { get; set; }
        //TODO figure out how to assign different tennats
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }

    }
}