/*
 * @CreateTime: May 14, 2019 12:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 12:38 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.AccountTypes.Models;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeIndexQuery : IRequest<IEnumerable<AccountTypeIndexView>> {
        public uint TypeOf { get; set; }
    }
}