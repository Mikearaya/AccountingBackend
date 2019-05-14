/*
 * @CreateTime: May 14, 2019 12:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 12:37 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.AccountTypes.Models {
    public class AccountTypeIndexView {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint? TypeOf { get; set; }

        public static Expression<Func<AccountType, AccountTypeIndexView>> Projection {
            get {
                return accountType => new AccountTypeIndexView () {
                    Id = accountType.Id,
                    Name = accountType.Type,
                    TypeOf = accountType.TypeOf
                };
            }
        }
    }
}