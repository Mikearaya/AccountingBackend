/*
 * @CreateTime: Apr 24, 2019 6:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 11:05 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, IEnumerable<AccountViewModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountsListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<AccountViewModel>> Handle (GetAccountsListQuery request, CancellationToken cancellationToken) {
            var accountList = _database.Account
                .Select (AccountViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<AccountViewModel> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<AccountViewModel>> (accountList);
        }
    }
}