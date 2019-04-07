using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourFairShare_MVC.Models
{
    public class TennatModel

    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public bool HasKids { get; set; } = false;
        public bool HasPets { get; set; } = false;
        public float Payment { get; set; }
    }
}