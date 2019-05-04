/*
 * @CreateTime: May 4, 2019 9:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 10:03 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.AccountCategories.Models {
    public class AccountCategoryIndexView {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<AccountCatagory, AccountCategoryIndexView>> Projection {
            get {
                return category => new AccountCategoryIndexView () {
                    Id = category.Id,
                    Name = category.Catagory
                };
            }
        }
    }
}