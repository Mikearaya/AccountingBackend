/*
 * @CreateTime: Apr 24, 2019 5:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 11:00 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Accounts.Queries.GetAccount {
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountViewModel> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<AccountViewModel> Handle (GetAccountQuery request, CancellationToken cancellationToken) {
            var account = await _database.Account
                .Select (AccountViewModel.Projection)
                .FirstOrDefaultAsync (c => c.Id == request.Id);

            if (account == null) {
                throw new NotFoundException ("Account", request.Id);
            }

            return account;
        }
    }
}