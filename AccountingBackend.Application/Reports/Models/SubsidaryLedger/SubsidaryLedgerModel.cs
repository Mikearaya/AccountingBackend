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

        public int Id { get; set; }

        public string AccountId { get; set; }
        public string ControlAccountId { get; set; }

        public string AccountType { get; set; }
        public string SubAccountId { get; set; }
        public string AccountName { get; set; }
        public float? BBF { get; set; }
        public IEnumerable<SubsidaryLedgerDetailModel> Entries { get; set; } = new List<SubsidaryLedgerDetailModel> ();

        public static Expression<Func<Account, SubsidaryLedgerModel>> Projection {
            get {
                return entry => new SubsidaryLedgerModel () {
                    Id = entry.Id,
                    AccountId = entry.ParentAccountNavigation.AccountId,
                    ControlAccountId = entry.ParentAccountNavigation.AccountId,
                    SubAccountId = entry.AccountId,
                    AccountType = entry.Catagory.AccountType.TypeOfNavigation.Type,
                    AccountName = entry.AccountName,
                    BBF = entry.OpeningBalance,
                    Entries = entry.LedgerEntry
                    .AsQueryable ()
                    .Select (SubsidaryLedgerDetailModel.Projection)
                    .OrderByDescending (d => d.Date)
                    .ThenBy (d => d.VoucherId)
                    .AsQueryable ()

                };
            }
        }

        public string getAccountId () {
            return $"{ControlAccountId} - {SubAccountId}";
        }

    }
}