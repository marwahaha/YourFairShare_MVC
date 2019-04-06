using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourFairShare_MVC.Models;

namespace YourFairShare_MVC.Controllers
{
    public class TennatController : Controller
    {
        // GET: Tennat
        public ActionResult Index()
        {
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

                return RedirectToAction("LoadTennats");
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


    }
}