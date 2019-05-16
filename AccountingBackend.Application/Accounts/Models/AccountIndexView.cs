/*
 * @CreateTime: May 4, 2019 9:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 9:33 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Accounts.Models {
    public class AccountIndexView {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Account, AccountIndexView>> Projection {

            get {
                return account => new AccountIndexView () {
                    Id = account.Id,
                    Name = $"{account.ParentAccountNavigation.AccountId}  {account.AccountId} - {account.AccountName}"
                };
            }
        }

    }

}