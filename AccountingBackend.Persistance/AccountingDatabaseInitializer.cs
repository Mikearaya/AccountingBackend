/*
 * @CreateTime: May 1, 2019 3:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 3:07 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using AccountingBackend.Domain;

namespace AccountingBackend.Persistance {
    public class AccountingDatabaseInitializer {

        private readonly Dictionary<string, Account> Accounts = new Dictionary<string, Account> ();
        private readonly Dictionary<int, AccountCatagory> AccountCatagorys = new Dictionary<int, AccountCatagory> ();
        private readonly Dictionary<int, AccountType> accountType = new Dictionary<int, AccountType> ();

        public static void Initialize (AccountingDatabaseService context) {
            var initializer = new AccountingDatabaseInitializer ();
            initializer.SeedEverything (context);
        }

        public void SeedEverything (AccountingDatabaseService context) {

            context.Database.EnsureDeleted ();
            context.Database.EnsureCreated ();

            if (context.AccountType.Any ()) {
                return; // Db has been seeded
            }

            SeedAccountType (context);
            SeedAccountCategory (context);
            SeedAccount (context);

            context.SaveChanges ();

        }

        public void SeedAccountType (AccountingDatabaseService database) {
            var accountType = new [] {
                new AccountType () { Type = "Asset" },
                new AccountType () { Type = "Liability" },
                new AccountType () { Type = "Capital" },
                new AccountType () { Type = "Revenue" },
                new AccountType () { Type = "Expence" }

            };

            database.AccountType.AddRange (accountType);

        }

        public void SeedAccountCategory (AccountingDatabaseService database) {

            database.AccountCatagory.Add (new AccountCatagory () { Id = 2, Catagory = "Cash Account", DateAdded = DateTime.Now, DateUpdated = DateTime.Now });
            database.AccountCatagory.Add (new AccountCatagory () { Id = 3, Catagory = "COGE", DateAdded = DateTime.Now, DateUpdated = DateTime.Now });

        }

        public void SeedAccount (AccountingDatabaseService database) {

            database.Account.Add (new Account () { Id = "2000", AccountName = "Cash", OpeningBalance = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now });
            database.Account.Add (new Account () { Id = "3000", AccountName = "Cash at Bank", OpeningBalance = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now });

        }

    }
}