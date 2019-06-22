/*
 * @CreateTime: May 15, 2019 6:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 1:27 PM
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

namespace AccountingBackend.Application.Reports.Queries.GetTrialBalance {
    public class GetConsolidatedTrialBalanceQueryHandler : IRequestHandler<GetConsolidatedTrialBalanceQuery, FilterResultModel<TrialBalanceModel>> {
        private readonly IAccountingDatabaseService _database;

        public CustomDateConverter dateConverter { get; }

        public GetConsolidatedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
            dateConverter = new CustomDateConverter ();

        }

        public Task<FilterResultModel<TrialBalanceModel>> Handle (GetConsolidatedTrialBalanceQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "AccountName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<TrialBalanceModel> result = new FilterResultModel<TrialBalanceModel> ();
            var entry = _database.LedgerEntry.Join (_database.Account.Where (a => a.Year == request.Year && a.ParentAccountNavigation != null), l => l.AccountId, a => a.Id, (l, a) => new {
                AccountId = a.ParentAccountNavigation.AccountId,
                    AccountName = a.ParentAccountNavigation.AccountName,
                    Type = a.Catagory.AccountType.TypeOfNavigation.Type,
                    Credit = l.Credit,
                    Debit = l.Debit,
                    ledger = l
            });

            if (request.StartDate != null) {
                entry = entry.Where (d => d.ledger.Ledger.Date >= dateConverter.EthiopicToGregorian (request.StartDate));
            }

            if (request.EndDate != null) {
                entry = entry.Where (d => d.ledger.Ledger.Date <= dateConverter.EthiopicToGregorian (request.EndDate));
            }

            var filtered = entry.GroupBy (a => new { a.AccountId, a.Type })
                .Select (x => new TrialBalanceModel () {
                    AccountId = x.Key.AccountId,
                        AccountType = x.Key.Type,
                        Credit = x.Sum (c => (decimal?) c.Credit),
                        AccountName = x.Select (s => s.AccountName).First (),
                        Debit = x.Sum (c => (decimal?) c.Debit),
                }).AsQueryable ();

            if (request.Filter.Count () > 0) {
                filtered = filtered
                    .Where (DynamicQueryHelper
                        .BuildWhere<TrialBalanceModel> (request.Filter)).AsQueryable ();
            }

            var PageSize = request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Count = filtered.Count ();

            result.Items = filtered.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            decimal? difference = 0;

            foreach (var item in result.Items) {

                if (item.AccountType.ToUpper () == "LIABILITY" || item.AccountType.ToUpper () == "REVENUE" || item.AccountType.ToUpper () == "CAPITAL") {

                    difference = item.Credit - item.Debit;
                    if (difference < 0) {
                        item.Debit = difference * -1;
                        item.Credit = null;
                    } else {
                        item.Credit = difference;
                        item.Debit = null;
                    }

                } else {

                    difference = item.Debit - item.Credit;
                    if (difference < 0) {
                        item.Credit = difference * -1;
                        item.Debit = null;
                    } else {
                        item.Debit = difference;
                        item.Credit = null;
                    }
                }
            }

            return Task.FromResult<FilterResultModel<TrialBalanceModel>> (result);

        }
    }
}