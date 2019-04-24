/*
 * @CreateTime: Apr 24, 2019 5:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:13 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using MediatR;

namespace AccountingBackend.Application.Accounts.Queries.GetAccount {
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountViewModel> {
        public Task<AccountViewModel> Handle (GetAccountQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}