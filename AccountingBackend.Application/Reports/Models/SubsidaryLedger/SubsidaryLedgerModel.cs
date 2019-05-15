/*
 * @CreateTime: May 15, 2019 10:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 10:09 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class SubsidaryLedgerModel {
        public string AccountId {
            get {
                return $"{ControlAccountId} {SubAccountId}";
            }
        }
        private string ControlAccountId { get; set; }
        private string SubAccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Debit { get; set; }
        public IEnumerable<SubsidaryLedgerDetailModel> Entries { get; set; } = new List<SubsidaryLedgerDetailModel> ();

        public static Expression<Func<Account, SubsidaryLedgerModel>> Projection {
            get {
                return entry => new SubsidaryLedgerModel () {
                    ControlAccountId = entry.ParentAccountNavigation.AccountId,
                    SubAccountId = entry.AccountId,
                    AccountName = entry.AccountName,
                    Entries = entry.LedgerEntry
                    .AsQueryable ()
                    .Select (SubsidaryLedgerDetailModel.Projection)
                };
            }
        }

    }
}