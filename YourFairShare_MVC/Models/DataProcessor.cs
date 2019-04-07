using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Web;

namespace YourFairShare_MVC.Models
{
    public static class DataProcessor
    {
        //TODO convert to linq
        public static int CreateTennat(string fullName, bool hasKids, bool hasPets, float payment) {
             
            TennatModel data = new TennatModel{
                FullName = fullName,
                HasKids = hasKids,
                HasPets = hasPets,
                Payment = payment
            };
            
            string sql = @"insert into dbo.Tennats(FullName, HasKids, HasPets, Payment)
                            values(@FullName, @HasKids, @HasPets, @Payment);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateTennat(string fullName, bool hasKids, bool hasPets, float payment) {

            TennatModel data = new TennatModel
            {
                FullName = fullName,
                HasKids = hasKids,
                HasPets = hasPets,
                Payment = payment
            };

            string sql = @"insert into dbo.Tennats(FullName, HasKids, HasPets, Payment)
                            values(@FullName, @HasKids, @HasPets, @Payment);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TennatModel> LoadTennats() {
            
            string sql = @"select FullName, HasKids, HasPets, Payment from dbo.Tennats;";

            return SqlDataAccess.LoadData<TennatModel>(sql);
        }

        public static int CreateBill(string name, decimal amount, DateTime dueDate) {

            BillModel data = new BillModel
            {
                Name = name,
                Amount = amount,
                DueDate = dueDate
            };

            string sql = @"insert into dbo.Bills(Name, Amount, DueDate)
                            values(@Name, @Amount, @DueDate);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<BillModel> ViewBills() {

            string sql = "select* from dbo.Bills " ;


                return SqlDataAccess.LoadData<BillModel>(sql);
        }
        

        //GET Single Bills and Tennats
        public static List<BillModel> GetBill(string input) {
            //throw new NotImplementedException();
            var sql = $"dbo.GetBill '{input}'";
            return SqlDataAccess.LoadData<BillModel>(sql);
        }

        public static List<TennatModel> GetTennat(string input) {
            //throw new NotImplementedException();
            var sql = $"dbo.GetTennat '{input}'";
            return SqlDataAccess.LoadData<TennatModel>(sql);
        }

        public static void UpdateMonthlyPayments() {

            //Determine Portion
            List<BillModel> bills = ViewBills();
            decimal portion = 0;
            foreach (BillModel bill in bills) {
                portion += bill.Amount;
            }
            // Load Tennats and update
            List<TennatModel> allTennats = LoadTennats();
          

            float payment = (float)portion / allTennats.Count;

            foreach (var t in allTennats) {
                t.Payment = payment;
            }

            string sql = @"UPDATE dbo.Tennats
                        SET Payment = @payment;";

            int index = SqlDataAccess.SaveData(sql, allTennats);
        }

    }
}