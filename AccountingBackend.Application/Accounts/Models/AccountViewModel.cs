/*
 * @CreateTime: Apr 24, 2019 5:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 2:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Accounts.Models {
    public class AccountViewModel {

        public int Id { get; set; }
        public string AccountId { get; set; }
        public string ParentAccount { get; set; }
        public string AccountName { get; set; }
        public bool Active { get; set; }
        public string Year { get; set; }
        public float? OpeningBalance { get; set; }

        public int CostCenterId { get; set; }
        public string CostCenter { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Account, AccountViewModel>> Projection {

            get {
                return account => new AccountViewModel () {
                    Id = account.Id,
                    AccountId = account.AccountId,
                    AccountName = account.AccountName,
                    ParentAccount = account.ParentAccountNavigation.AccountId,
                    Active = (account.Active == 1) ? true : false,
                    OpeningBalance = account.OpeningBalance,
                    Year = account.Year,
                    Category = account.Catagory.Catagory,
                    CategoryId = account.CatagoryId,
                    CostCenterId = account.CostCenterId,
                    CostCenter = account.CostCenter.Value,
                    DateAdded = account.DateAdded,
                    DateUpdated = account.DateUpdated

                };
            }
        }

        public static Expression<Func<Account, AccountViewModel>> Index {

            get {
                return account => new AccountViewModel {
                    Id = account.Id,
                    AccountName = $"{account.AccountId} - {account.AccountName}"
                };
            }
        }
    }
}