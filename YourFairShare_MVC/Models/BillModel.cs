using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourFairShare_MVC.Models
{
    public class BillModel
    {
        public string Name { get; set; }
        public List<TennatModel> ResponsibleTennats { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { get; set; }

    }
}