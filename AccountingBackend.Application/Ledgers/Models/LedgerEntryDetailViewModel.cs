/*
 * @CreateTime: May 8, 2019 3:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Ledgers.Models {
    public class LedgerEntryDetailViewModel {
        public int Id { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public string AccountName { get; set; }
        public int AccountId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<LedgerEntry, LedgerEntryDetailViewModel>> Projection {
            get {
                return entry => new LedgerEntryDetailViewModel () {
                    Id = entry.Id,
                    AccountId = entry.Account.Id,
                    AccountName = entry.Account.AccountName,
                    Debit = entry.Debit,
                    Credit = entry.Credit,
                    DateAdded = entry.DateAdded,
                    DateUpdated = entry.DateUpdated
                };
            }
        }
    }
}