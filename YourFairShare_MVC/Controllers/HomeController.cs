using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static YourFairShare_MVC.Models.DataProcessor;
using YourFairShare_MVC.Models;
namespace YourFairShare_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View();
        }

        public ActionResult CreateTennat() {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTennat(TennatModel t) {

            if (ModelState.IsValid) {
                DataProcessor.CreateTennat(t.FullName, t.HasKids, t.HasPets, t.Payment);

                return RedirectToAction("Index");
            }
            return View();
        }



        public ActionResult LoadTennats() {
            ViewBag.Message = "View Tennats";
            DataProcessor.UpdateMonthlyPayments();
            var data = DataProcessor.LoadTennats();
            List<TennatModel> tennats = new List<TennatModel>();
            foreach (var row in data) {
                tennats.Add(new TennatModel
                {
                    FullName = row.FullName,
                    HasKids = row.HasKids,
                    HasPets = row.HasPets,
                    Payment = row.Payment
                });
            }

            return View(tennats);
        }
  
        public ActionResult ViewBills() {
            ViewBag.Message = "View Bills";
            
            var data = DataProcessor.ViewBills();
            List<BillModel> bills = new List<BillModel>();
            foreach (var row in data) {
                bills.Add(new BillModel
                {
                    Name=row.Name,
                    Amount = row.Amount,
                    DueDate = row.DueDate
                });
            }
            return View(bills);
        }

        public ActionResult CreateBill() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBill(BillModel b) {

            if (ModelState.IsValid) {
                DataProcessor.CreateBill(b.Name, b.Amount, b.DueDate);
                
                return RedirectToAction("Index");
            }
            return View();
        }
    }

  
}