/*
 * @CreateTime: May 8, 2019 3:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 17, 2019 10:27 AMAM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Ledgers.Models {
    public class LedgerEntryViewModel {

        public int? Prev { get; set; }

        public int? Next { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public string VoucherId { get; set; }
        public bool Posted { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<LedgerEntryDetailViewModel> Entries = new List<LedgerEntryDetailViewModel> ();

        public static Expression<Func<Ledger, LedgerEntryViewModel>> Projection {
            get {
                return entry => new LedgerEntryViewModel () {
                    Id = entry.Id,
                    VoucherId = entry.VoucherId,
                    Description = entry.Description,
                    Date = entry.Date,
                    Reference = entry.Reference,
                    Posted = (entry.IsPosted == 0) ? false : true,
                    Entries = entry.LedgerEntry
                    .AsQueryable ()
                    .Select (LedgerEntryDetailViewModel.Projection)
                    .ToList ()

                };
            }
        }

    }
}