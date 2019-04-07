using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YourFairShare_MVC.Models;

namespace YourFairShare_MVC.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewBills() {
            ViewBag.Message = "View Bills";

            var data = DataProcessor.ViewBills();
            List<BillModel> bills = new List<BillModel>();
            foreach (var row in data) {
                bills.Add(new BillModel
                {
                    Name = row.Name,
                    Amount = row.Amount,
                    DueDate = row.DueDate
                });
            }
            return View(bills);
        }

        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BillModel b) {

            if (ModelState.IsValid) {
                DataProcessor.CreateBill(b.Name, b.Amount, b.DueDate);

                return RedirectToAction("ViewBills");
            }
            return View();
        }

   
        [HttpGet]
        public ActionResult Edit(string name) {
            if (name == null) {
               // return RedirectToAction("ViewBills");
            }
            var bill = DataProcessor.GetBill(name);
            
            return View(bill[0]); //? Hacky but works
        }

        [HttpPost]
        public ActionResult Edit(BillModel b) {

            if (ModelState.IsValid) {
                BillModel newBill = new BillModel
                {
                    ID = b.ID,
                    Name = b.Name,
                    Amount = b.Amount,
                    DueDate = b.DueDate
                };
                
                string sql = $"UPDATE dbo.Bills SET Name = '{newBill.Name}', " +
                    $"Amount= {newBill.Amount}, " +
                    $"DueDate= '{newBill.DueDate.ToShortDateString()}' " +
                    $"WHERE ID = {newBill.ID}";
            
                
                SqlDataAccess.SaveData(sql, newBill);
                return RedirectToAction("ViewBills");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string name) {
            if (name == null) {
             //   return RedirectToAction("ViewBills");
            }
            var bill = DataProcessor.GetBill(name);

            return View(bill[0]); //? Hacky but works
            
        }

        [HttpPost]
        public ActionResult Delete(BillModel b) {
            if (ModelState.IsValid) {
                BillModel BillToDelete = new BillModel
                {
                    ID = b.ID,
                    Name = b.Name,
                    Amount = b.Amount,
                    DueDate = b.DueDate
                };

                string sql = $"DELETE FROM dbo.Bills  WHERE Name = '{BillToDelete.Name}'";


                SqlDataAccess.SaveData(sql, BillToDelete);
                return RedirectToAction("ViewBills");
            }
            return View();
        }
    }
}