/*
 * @CreateTime: Apr 24, 2019 6:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:14 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountsListQuery : ApiQueryString, IRequest<IEnumerable<AccountViewModel>> {

        public string Year { get; set; }

    }
}