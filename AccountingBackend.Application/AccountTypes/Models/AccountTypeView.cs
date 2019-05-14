/*
 * @CreateTime: May 14, 2019 10:51 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:59 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.AccountTypes.Models {
    public class AccountTypeView {
        public uint Id { get; set; }
        public string Type { get; set; }
        public uint? TypeOf { get; set; }
        public bool IsSummary { get; set; }

        public static Expression<Func<AccountType, AccountTypeView>> Projection {
            get {
                return accountType => new AccountTypeView () {
                    Id = accountType.Id,
                    Type = accountType.Type,
                    IsSummary = accountType.IsSummery == 0 ? false : true
                };
            }
        }
    }
}