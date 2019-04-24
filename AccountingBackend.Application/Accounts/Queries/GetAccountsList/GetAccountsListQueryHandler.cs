/*
 * @CreateTime: Apr 24, 2019 6:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:16 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading;
using AccountingBackend.Application.Accounts.Models;
using MediatR;

namespace AccountingBackend.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, IEnumerable<AccountViewModel>> {
        public System.Threading.Tasks.Task<IEnumerable<AccountViewModel>> Handle (GetAccountsListQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}