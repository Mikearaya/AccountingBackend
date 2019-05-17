using System;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;
/*
 * @CreateTime: May 15, 2019 7:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:23 PM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Reports.Models {
    public class TrialBalanceDetailListModel {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }

        public static Expression<Func<Account, TrialBalanceDetailListModel>> Projection {
            get {
                return entry => new TrialBalanceDetailListModel () {
                    Credit = (decimal?) entry.LedgerEntry.Sum (a => a.Credit),
                    Debit = (decimal?) entry.LedgerEntry.Sum (a => a.Debit),
                    AccountName = entry.AccountName,

                };
            }
        }
    }
}