using System.Net.Cache;
/*
 * @CreateTime: Jun 3, 2019 12:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 4, 2019 2:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Models;
using AccountingBackend.Application.Reports.Models;
using AccountingBackend.Commons;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Reports.Queries {
    public class GetAccountScheduleQueryHandler : ApiQueryString, IRequestHandler<GetAccountScheduleQuery, FilterResultModel<AccountScheduleModel>> {
        private readonly IAccountingDatabaseService _database;

        public CustomDateConverter dateConverter { get; }

        public GetAccountScheduleQueryHandler (IAccountingDatabaseService database) {
            _database = database;
            dateConverter = new CustomDateConverter ();
        }

        public Task<FilterResultModel<AccountScheduleModel>> Handle (GetAccountScheduleQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "ControlAccountId";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<AccountScheduleModel> finalResult = new FilterResultModel<AccountScheduleModel> ();

            var PageSize = request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            var result = _database.Account.Where (a => a.ParentAccountNavigation != null).Where (y => y.Year == request.Year)
                .Select (AccountScheduleModel.Projection);

            if (request.ControlAccountId != null && request.ControlAccountId.Trim () != "") {
                result = result.Where (d => d.ControlAccountId == request.ControlAccountId);
            }
            if (request.StartDate != null) {
                result = result.Where (d => d.Date >= dateConverter.EthiopicToGregorian (request.StartDate));
            }
            if (request.EndDate != null) {
                result = result.Where (d => d.Date <= dateConverter.EthiopicToGregorian (request.EndDate));
            }

            var filtered = result
                .Select (DynamicQueryHelper.GenerateSelectedColumns<AccountScheduleModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                filtered = filtered
                    .Where (DynamicQueryHelper
                        .BuildWhere<AccountScheduleModel> (request.Filter)).AsQueryable ();
            }

            finalResult.Items = filtered.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            finalResult.Count = filtered.Count ();

            return Task.FromResult<FilterResultModel<AccountScheduleModel>> (finalResult);
        }
    }
}