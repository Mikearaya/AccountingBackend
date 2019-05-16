using System;
using System.Linq;
using System.Linq.Expressions;
/*
 * @CreateTime: May 15, 2019 7:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class TrialBalanceDetailModel {

        public string AccountId { get; set; }
        public string AccountName { get; set; }

        public List<TrialBalanceDetailListModel> Entries = new List<TrialBalanceDetailListModel> ();

        public static Expression<Func<LedgerEntry, TrialBalanceDetailModel>> Projection {
            get {
                return entry => new TrialBalanceDetailModel () {
                    AccountId = entry.Account.AccountId,
                    AccountName = entry.Account.AccountName,
                    Entries = entry.Account.InverseParentAccountNavigation
                    .Where (a => a.ParentAccountNavigation != null).AsQueryable ()
                    .Select (TrialBalanceDetailListModel.Projection)
                    .Where (e => e.Credit != null || e.Debit != null)
                    .ToList ()
                };
            }
        }

    }
}