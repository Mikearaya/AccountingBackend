/*
 * @CreateTime: May 17, 2019 5:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 17, 2019 6:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class IncomeStatementItemModel {
        public string AccountType { get; set; }
        public float? Amount { get; set; }

        public static Expression<Func<AccountCatagory, IncomeStatementItemModel>> Projection {
            get {
                return account => new IncomeStatementItemModel () {
                    Amount = account.Account.Sum (s => s.LedgerEntry.Sum (d => d.Debit)),
                    AccountType = account.Catagory
                };
            }
        }
    }
}