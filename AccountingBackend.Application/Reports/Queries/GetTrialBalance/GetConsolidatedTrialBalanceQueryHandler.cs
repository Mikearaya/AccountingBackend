/*
 * @CreateTime: May 15, 2019 6:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:09 PM
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
using AccountingBackend.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Reports.Queries.GetTrialBalance {
    public class GetConsolidatedTrialBalanceQueryHandler : IRequestHandler<GetConsolidatedTrialBalanceQuery, FilterResultModel<TrialBalanceModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetConsolidatedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<TrialBalanceModel>> Handle (GetConsolidatedTrialBalanceQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "AccountName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<TrialBalanceModel> result = new FilterResultModel<TrialBalanceModel> ();
            var entry = _database.LedgerEntry.AsQueryable ();

            if (request.StartDate != null) {
                entry = entry.Where (d => d.Ledger.Date >= request.StartDate);
            }

            if (request.EndDate != null) {
                entry = entry.Where (d => d.Ledger.Date <= request.EndDate);
            }

            var filtered = entry
                .Join (_database.Account.Where (a => a.Year == request.Year), l => l.AccountId, a => a.Id, (l, a) => new {
                    AccountId = a.ParentAccountNavigation.AccountId,
                        AccountName = a.ParentAccountNavigation.AccountName,
                        Credit = a.LedgerEntry.Sum (c => (decimal?) c.Credit),
                        Debit = a.LedgerEntry.Sum (c => (decimal?) c.Debit)
                }).GroupBy (a => a.AccountId)
                .Select (x => new TrialBalanceModel () {
                    AccountId = x.Key,
                        Credit = x.Sum (c => c.Credit),
                        AccountName = x.Select (s => s.AccountName).First (),
                        Debit = x.Sum (c => c.Debit),
                }).AsQueryable ();

            if (request.Filter.Count () > 0) {
                filtered = filtered
                    .Where (DynamicQueryHelper
                        .BuildWhere<TrialBalanceModel> (request.Filter)).AsQueryable ();
            }

            result.Count = filtered.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = filtered.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<TrialBalanceModel>> (result);

        }
    }
}