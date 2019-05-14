/*
 * @CreateTime: Apr 30, 2019 1:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 9:16 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.AccountCategories.Models {
    public class AccountCategoryView {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        public static Expression<Func<AccountCatagory, AccountCategoryView>> Projection {
            get {
                return category => new AccountCategoryView () {
                    Id = category.Id,
                    AccountType = category.AccountType.Type,
                    CategoryName = category.Catagory,
                    DateAdded = (DateTime) category.DateAdded,
                    DateUpdated = (DateTime) category.DateUpdated
                };
            }
        }

        public static AccountCategoryView Create (AccountCatagory catagory) {
            return Projection.Compile ().Invoke (catagory);
        }

    }

}