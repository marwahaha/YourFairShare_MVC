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
        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TennatModel t) {

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



        [HttpGet]
        public ActionResult Edit(string name) {
            if (name == null) {
                // return RedirectToAction("ViewBills");
            }
            var tennat = DataProcessor.GetTennat(name);

            return View(tennat[0]); //? Hacky but works
        }

        [HttpPost]
        public ActionResult Edit(TennatModel t) {

            if (ModelState.IsValid) {
                TennatModel newTennat = new TennatModel
                {
                    ID = t.ID,
                    FullName = t.FullName,
                    HasKids = t.HasKids,
                    HasPets = t.HasPets,
                    Payment = t.Payment
                };

                //string sql = $"UPDATE dbo.Bills SET Name = '{newTennat.Name}', " +
                //    $"Amount= {newTennat.Amount}, " +
                //    $"DueDate= '{newTennat.DueDate.ToShortDateString()}' " +
                //    $"WHERE ID = {newTennat.ID}";
                string sql = $"UPDATE dbo.Tennats SET FullName = '{newTennat.FullName}'," +
                    $"HasKids = '{newTennat.HasKids}', HasPets = '{newTennat.HasPets}'," +
                    $"Payment = {newTennat.Payment}" +
                    $"WHERE ID = { newTennat.ID }";

                SqlDataAccess.SaveData(sql, newTennat);
                return RedirectToAction("LoadTennats");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string name) {
            if (name == null) {
                //   return RedirectToAction("ViewBills");
            }
            var tennat = DataProcessor.GetTennat(name);

            return View(tennat[0]); //? Hacky but works

        }
        

        [HttpPost]
        public ActionResult Delete(TennatModel t) {
            //TODO Why does this have to be declared explicitly in the view, but Bill Does not???
            if (ModelState.IsValid) {
                //?  I think this can be simplified since we already have the full name (Same for the bill)
                TennatModel tennatToDelete = new TennatModel
                {
                    ID = t.ID,
                    FullName = t.FullName,
                    HasKids = t.HasKids,
                    HasPets = t.HasPets,
                    Payment = t.Payment
                };
                //TODO all this is redundant??? or do we need it for the save data function?

                string sql = $"DELETE FROM dbo.Tennats  WHERE FullName = '{tennatToDelete.FullName}'";


                SqlDataAccess.SaveData(sql, tennatToDelete);
                return RedirectToAction("LoadTennats");
            }
            return View();
        }

    }
}