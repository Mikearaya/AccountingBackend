/*
 * @CreateTime: May 1, 2019 3:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 1:18 PM
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
            SeedLedgerEntries (context);

            context.SaveChanges ();

        }

        public void SeedAccountType (AccountingDatabaseService database) {
            var accountType = new [] {
                new AccountType () { Id = 1, Type = "Asset", TypeOf = 0 },
                new AccountType () { Id = 2, Type = "Liability", TypeOf = 0 },
                new AccountType () { Id = 3, Type = "Capital", TypeOf = 0 },
                new AccountType () { Id = 4, Type = "Revenue", TypeOf = 0 },
                new AccountType () {
                Id = 5,
                Type = "Expence", TypeOf = 0,
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
                },
                new AccountType () { Id = 6, Type = "Finished Products", TypeOf = 1 },
                new AccountType () { Id = 7, Type = "COGS (Cost of Goods)", TypeOf = 5 }

            };

            database.AccountType.AddRange (accountType);

        }

        public void SeedSystemLookup (AccountingDatabaseService database) {

            var systemLookup = new [] {
                new SystemLookup () { Id = 700, Type = "Cost Center", Value = "Production", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup () { Id = 500, Type = "Cost Center", Value = "Sales", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup () { Id = 300, Type = "Cost Center", Value = "Manufacturing", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup () { Id = 90, Type = "Cost Center", Value = "Manufacturing", DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
            };

            database.SystemLookup.AddRange (systemLookup);
        }

        public void SeedLedgerEntries (AccountingDatabaseService database) {
            var ledgerEntries = new [] {
                new Ledger () {
                Id = 10, IsPosted = 0, Description = "Test entry", Date = DateTime.Now, DateAdded = DateTime.Now, DateUpdated = DateTime.Now, VoucherId = "JV/001",
                LedgerEntry = new [] {
                new LedgerEntry () { Id = 10, LedgerId = 10, AccountId = 10, Debit = 0, Credit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new LedgerEntry () { Id = 11, LedgerId = 10, AccountId = 11, Debit = 100, Credit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
                }
                },
                new Ledger () {
                Id = 11, IsPosted = 0, Description = "Test entry", Date = DateTime.Now, DateAdded = DateTime.Now, DateUpdated = DateTime.Now, VoucherId = "JV/001",
                LedgerEntry = new [] {
                new LedgerEntry () { Id = 15, LedgerId = 11, AccountId = 10, Debit = 0, Credit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new LedgerEntry () { Id = 16, LedgerId = 11, AccountId = 11, Debit = 100, Credit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
                }
                }
            };

            database.Ledger.AddRange (ledgerEntries);
            database.Save ();
        }

    }
}