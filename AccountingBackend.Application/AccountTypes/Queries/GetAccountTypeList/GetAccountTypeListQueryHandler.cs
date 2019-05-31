/*
 * @CreateTime: May 14, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 23, 2019 3:36 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.AccountTypes.Models;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeListQueryHandler : IRequestHandler<GetAccountTypeListQuery, FilterResultModel<AccountTypeView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountTypeListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<AccountTypeView>> Handle (GetAccountTypeListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Type";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<AccountTypeView> result = new FilterResultModel<AccountTypeView> ();
            var accountType = _database.AccountType.Where (a => a.TypeOfNavigation != null)
                .Select (AccountTypeView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<AccountTypeView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                accountType = accountType
                    .Where (DynamicQueryHelper
                        .BuildWhere<AccountTypeView> (request.Filter)).AsQueryable ();
            }
            result.Count = accountType.Count ();

            result.Items = accountType.OrderBy (sortBy, sortDirection).Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<AccountTypeView>> (result);
        }
    }
}