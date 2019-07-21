/*
 * @CreateTime: May 4, 2019 9:33 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 9:38 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountIndexListQuery : ApiQueryString, IRequest<IEnumerable<AccountIndexView>> {

        private string AccountType { get; set; } = "All";

        public string Type {
            get {
                return AccountType;
            }
            set {
                AccountType = (value == null) ? "All" : value;
            }
        }
    }
}