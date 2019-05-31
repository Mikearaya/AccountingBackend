/*
 * @CreateTime: Apr 30, 2019 2:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 8:17 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCatugoryQueryListQueryHandler : IRequestHandler<GetAccountCategoryListQuery, FilterResultModel<AccountCategoryView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountCatugoryQueryListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<AccountCategoryView>> Handle (GetAccountCategoryListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "CategoryName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<AccountCategoryView> result = new FilterResultModel<AccountCategoryView> ();

            var categoryList = _database.AccountCatagory
                .Select (AccountCategoryView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<AccountCategoryView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                categoryList = categoryList
                    .Where (DynamicQueryHelper
                        .BuildWhere<AccountCategoryView> (request.Filter)).AsQueryable ();
            }
            result.Count = categoryList.Count ();

            result.Items = categoryList.OrderBy(sortBy, sortDirection).Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<AccountCategoryView>> (result);
        }
    }
}