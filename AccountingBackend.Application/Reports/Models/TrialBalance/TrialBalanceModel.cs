using System;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;
/*
 * @CreateTime: May 15, 2019 6:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:00 PM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Reports.Models {
    public class TrialBalanceModel {
        public string AccountId { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public string AccountName { get; set; }

        public static Expression<Func<LedgerEntry, TrialBalanceModel>> Projection {
            get {
                return entry => new TrialBalanceModel () {
                    AccountId = $"{entry.Account.ParentAccountNavigation.AccountId} parent {entry.Account.ParentAccountNavigation.ParentAccount}",
                    AccountName = entry.Account.ParentAccountNavigation.AccountName,
                    Credit = (decimal?) entry.Account.ParentAccountNavigation.InverseParentAccountNavigation.Sum (a => (decimal?) a.LedgerEntry.Sum (e => e.Credit)),
                };

            }
        }

    }
}