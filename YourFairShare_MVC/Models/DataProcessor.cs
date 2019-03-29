using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourFairShare_MVC.Models
{
    public static class DataProcessor
    {

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


    }
}