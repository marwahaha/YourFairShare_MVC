using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourFairShare_MVC.Models
{
    public static class HouseHold
    {
        public static List<TennatModel> Tennats { get; set; }
        public static List<BillModel> TotalBills { get; set; }

        public static void CalculateBillShare() { 
            //TODO Right now this will divide Equally, Set up variables if a tennat has a greater portion
            float Total = 0;
            foreach (BillModel b in TotalBills) {

                Total += b.Amount;
            }
            float portion = Total / Tennats.Count;
            foreach (TennatModel t in Tennats) {
                t.Payment = portion;
            }
        }
    }
}