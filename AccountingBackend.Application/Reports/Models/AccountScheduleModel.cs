using System;
/*
 * @CreateTime: Jun 3, 2019 12:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 4, 2019 2:20 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class AccountScheduleModel {

        private decimal? Credit { get; set; }
        private decimal? Debit { get; set; }
        public string ControlAccountId { get; set; }
        public string ControlAccount { get; set; }
        public string SubsidaryId { get; set; }

        public string AccountType { get; set; }
        public string Subsidary { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TotalCredit { get { return Credit; } set { Credit = value == null ? 0 : value; } }
        public decimal? TotalDebit { get { return Debit; } set { Debit = value == null ? 0 : value; } }

        public decimal? Balance {
            get {
                return TotalDebit + TotalCredit;
            }
            set { }
        }
        public decimal? BBF { get; set; }

        public static Expression<Func<Account, AccountScheduleModel>> Projection {
            get {
                return account => new AccountScheduleModel () {
                    ControlAccount = account.ParentAccountNavigation.AccountName,
                    ControlAccountId = account.ParentAccountNavigation.AccountId,
                    SubsidaryId = account.AccountId,
                    Subsidary = account.AccountName,
                    BBF = (decimal?) account.OpeningBalance,
                    AccountType = account.Catagory.AccountType.TypeOfNavigation != null? account.Catagory.AccountType.TypeOfNavigation.Type : account.Catagory.AccountType.Type,
                    Date = (DateTime?) account.LedgerEntry.Select (d => d.Ledger.Date).FirstOrDefault ().Date,
                    TotalCredit = (decimal?) account.LedgerEntry.Sum (t => (decimal?) t.Credit),
                    TotalDebit = (decimal?) account.LedgerEntry.Sum (t => (decimal?) t.Debit)
                };
            }
        }

    }
}