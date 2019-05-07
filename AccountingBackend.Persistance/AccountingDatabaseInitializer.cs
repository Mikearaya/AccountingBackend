/*
 * @CreateTime: May 1, 2019 3:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 2:31 PM
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
        private readonly Dictionary<int, AccountType> AccountType = new Dictionary<int, AccountType> ();
        private readonly Dictionary<int, SystemLookup> SystemLookup = new Dictionary<int, SystemLookup> ();

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
            SeedSystemLookup (context);

            context.SaveChanges ();

        }

        public void SeedAccountType (AccountingDatabaseService database) {
            var accountType = new [] {
                new AccountType () { Type = "Asset" },
                new AccountType () { Type = "Liability" },
                new AccountType () { Type = "Capital" },
                new AccountType () { Type = "Revenue" },
                new AccountType () {
                Type = "Expence",
                AccountCatagory = new [] {
                new AccountCatagory () { Id = 2, Catagory = "Cash Account", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new AccountCatagory () { Id = 3, Catagory = "COGE", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new AccountCatagory () {
                Id = 4, Catagory = "COGE", DateAdded = DateTime.Now, DateUpdated = DateTime.Now, Account = new [] {
                new Account () {
                Id = 10, AccountId = "5000", AccountName = "Cash", OpeningBalance = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now,
                CostCenter = new SystemLookup () { Id = 30, Type = "Cost Center", Value = "Production" },
                },
                new Account () {
                Id = 11, AccountId = "7000", AccountName = "Cash at Bank", OpeningBalance = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now,
                CostCenter = new SystemLookup () { Id = 50, Type = "Cost Center", Value = "Production" },
                }
                }
                }
                }
                }

            };

            database.AccountType.AddRange (accountType);

        }

        public void SeedSystemLookup (AccountingDatabaseService database) {

            var systemLookup = new [] {
                new SystemLookup () { Id = 40, Type = "Cost Center", Value = "Production", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup () { Id = 50, Type = "Cost Center", Value = "Sales", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup () { Id = 30, Type = "Cost Center", Value = "Manufacturing", DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
            };
        }

    }
}