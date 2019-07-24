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
using AccountingBackend.Commons;
using AccountingBackend.Domain;
namespace AccountingBackend.Application.Reports.Models {
    public class LedgerCheckListDetailModel {

        private string ControlAccount;
        private string SubAccount;

        public int LedgerId { get; set; }
        public string ControlAccountId {
            get {
                return $"{ControlAccount} {SubAccount}";
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
                    Credit = entry.Credit == 0 ? null : entry.Credit,
                    Debit = entry.Debit == 0 ? null : entry.Debit,
                    LedgerId = entry.LedgerId,
                    AccountName = entry.Account.AccountName
                };
            }
        }
    }
}