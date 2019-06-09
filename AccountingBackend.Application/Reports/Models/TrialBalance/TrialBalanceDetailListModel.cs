using System;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;
/*
 * @CreateTime: May 15, 2019 7:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 11:25 AM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Reports.Models {
    public class TrialBalanceDetailListModel {
        public string ControlAccountId { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }

        public static Expression<Func<Account, TrialBalanceDetailListModel>> Projection {
            get {
                return entry => new TrialBalanceDetailListModel () {
                    ControlAccountId = entry.ParentAccountNavigation.AccountId,
                    AccountId = entry.AccountId,
                    Credit = (decimal?) entry.LedgerEntry.Sum (a => a.Credit),
                    Debit = (decimal?) entry.LedgerEntry.Sum (a => a.Debit),
                    AccountName = entry.AccountName,

                };
            }
        }
    }

}