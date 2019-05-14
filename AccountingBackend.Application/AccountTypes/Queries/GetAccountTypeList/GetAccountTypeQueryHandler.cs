/*
 * @CreateTime: May 14, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:22 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.AccountTypes.Models;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeQueryHandler : IRequestHandler<GetAccountTypeListQuery, IEnumerable<AccountTypeView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountTypeQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<AccountTypeView>> Handle (GetAccountTypeListQuery request, CancellationToken cancellationToken) {
            var accountType = _database.AccountType
                .Select (AccountTypeView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<AccountTypeView> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<AccountTypeView>> (accountType);
        }
    }
}