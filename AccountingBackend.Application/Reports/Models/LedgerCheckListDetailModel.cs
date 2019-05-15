/*
 * @CreateTime: May 15, 2019 8:27 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 8:46 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;
namespace AccountingBackend.Application.Reports.Models {
    public class LedgerCheckListDetailModel {

        private string ControlAccount;
        private string SubAccount;
        public string ControlAccountId {
            get {
                return ControlAccount == "" ? SubAccount : ControlAccount;
            }
            set {
                ControlAccount = value == null ? "" : value;
            }
        }
        public string SubAccountId {
            get {
                return ControlAccount == "" ? "" : SubAccount;
            }
            set {
                SubAccount = ControlAccount == null ? "" : value;
            }
        }
        public float? Credit { get; set; }
        public float? Debit { get; set; }
        public string AccountName { get; set; }

        public static Expression<Func<LedgerEntry, LedgerCheckListDetailModel>> Projection {
            get {
                return entry => new LedgerCheckListDetailModel () {
                    ControlAccountId = entry.Account.ParentAccountNavigation.AccountId,
                    SubAccountId = entry.Account.AccountId,
                    Credit = entry.Credit,
                    Debit = entry.Debit,
                    AccountName = entry.Account.AccountName
                };
            }
        }
    }
}