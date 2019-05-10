/*
 * @CreateTime: May 10, 2019 10:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 3:53 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using AccountingBackend.Domain;
using AccountingBackend.Persistance;

namespace AccountingBackend.Application.Test {
    public class DatabaseInitializer {
        public static void Initialize (AccountingDatabaseService context) {

            if (context.Ledger.Any ()) {
                return;
            }
            SeedLedger (context);
            SeedSystemLookup (context);
        }

        private static void SeedLedger (AccountingDatabaseService context) {
            var ledger = new [] {
                new Ledger {
                Id = 10, Description = "ledger 1", VoucherId = "JV/001", Reference = "CH--001", IsPosted = 1, Date = DateTime.Now, DateUpdated = DateTime.Now,
                LedgerEntry = new List<LedgerEntry> () {
                new LedgerEntry () { Id = 20, LedgerId = 10, Credit = 100, Debit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new LedgerEntry () { Id = 21, LedgerId = 10, Credit = 0, Debit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
                }
                },
                new Ledger {
                Id = 11, Description = "ledger 2", VoucherId = "JV/002", Reference = "CH--002", IsPosted = 0, Date = DateTime.Now, DateUpdated = DateTime.Now,
                LedgerEntry = new List<LedgerEntry> () {
                new LedgerEntry () { Id = 22, LedgerId = 11, Credit = 100, Debit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new LedgerEntry () { Id = 23, LedgerId = 11, Credit = 0, Debit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
                }
                },
                new Ledger {
                Id = 13, Description = "ledger 3", VoucherId = "JV/003", Reference = "CH--003", IsPosted = 1, Date = DateTime.Now, DateUpdated = DateTime.Now,
                LedgerEntry = new List<LedgerEntry> () {
                new LedgerEntry () { Id = 24, LedgerId = 13, Credit = 100, Debit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new LedgerEntry () { Id = 25, LedgerId = 13, Credit = 0, Debit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
                }
                },

            };

            context.Ledger.AddRange (ledger);
            context.Save ();
        }

        private static void SeedSystemLookup (AccountingDatabaseService context) {
            var lookup = new [] {
                new SystemLookup { Id = 10, Type = "Cost Center", Value = "Production", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup { Id = 11, Type = "Cost Center", Value = "Manufacturing", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup { Id = 12, Type = "Cost Center", Value = "Maintainance", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new SystemLookup { Id = 14, Type = "Country", Value = "Ethiopia", DateAdded = DateTime.Now, DateUpdated = DateTime.Now }
            };

            context.SystemLookup.AddRange (lookup);
            context.Save ();
        }

    }
}