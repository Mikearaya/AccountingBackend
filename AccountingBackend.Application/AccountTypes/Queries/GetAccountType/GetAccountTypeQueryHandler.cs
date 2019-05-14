/*
 * @CreateTime: May 14, 2019 11:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:14 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountTypes.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.AccountTypes.Queries.GetAccountType {
    public class GetAccountTypeQueryHandler : IRequestHandler<GetAccountTypeQuery, AccountTypeView> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountTypeQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<AccountTypeView> Handle (GetAccountTypeQuery request, CancellationToken cancellationToken) {
            var accountType = await _database.AccountType
                .Select (AccountTypeView.Projection)
                .FirstOrDefaultAsync (a => a.Id == request.Id);

            if (accountType == null) {
                throw new NotFoundException ("Account Type", request.Id);
            }

            return accountType;
        }
    }
}