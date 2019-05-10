/*
 * @CreateTime: May 10, 2019 10:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 10:17 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using AccountingBackend.Domain;
using AccountingBackend.Persistance;

namespace AccountingBackend.Application.Test {
    public class DatabaseInitializer {
        public static void Initialize (AccountingDatabaseService context) {

            if (context.Ledger.Any ()) {
                return;
            }
            Seed (context);
        }

        private static void Seed (AccountingDatabaseService context) {
            var customers = new [] {
                new Ledger { Id = 10, Description = "ledger 1", VoucherId = "JV/001", Reference = "CH--001", IsPosted = 1, Date = DateTime.Now, DateUpdated = DateTime.Now },
                new Ledger { Id = 11, Description = "ledger 2", VoucherId = "JV/002", Reference = "CH--002", IsPosted = 0, Date = DateTime.Now, DateUpdated = DateTime.Now },
                new Ledger { Id = 13, Description = "ledger 3", VoucherId = "JV/003", Reference = "CH--003", IsPosted = 1, Date = DateTime.Now, DateUpdated = DateTime.Now },

            };

            context.Ledger.AddRange (customers);
            context.SaveChanges ();
        }
    }
}