/*
 * @CreateTime: May 15, 2019 7:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 7:35 PM
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
    public class GetDetailedTrialBalanceQueryHandler : IRequestHandler<GetDetailedTrialBalanceQuery, FilterResultModel<TrialBalanceDetailModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetDetailedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<TrialBalanceDetailModel>> Handle (GetDetailedTrialBalanceQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "AccountName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<TrialBalanceDetailModel> finalResult = new FilterResultModel<TrialBalanceDetailModel> ();

            var PageSize = request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            var fromLedger = _database.LedgerEntry.AsQueryable ();

            if (request.StartDate != null) {
                fromLedger = fromLedger.Where (d => d.Ledger.Date >= request.StartDate);
            }

            if (request.EndDate != null) {
                fromLedger = fromLedger.Where (d => d.Ledger.Date <= request.EndDate);
            }
            var filtered = fromLedger
                .Join (_database.Account.Where (a => a.Year == request.Year),
                    ledger => ledger.AccountId, account => account.Id, (ledger, account) => new SampleModel () {
                        ParentAccount = account.ParentAccountNavigation,
                            AccountId = $"{account.ParentAccountNavigation.AccountId} {account.AccountId}",
                            AccountName = $"{account.AccountName}",
                            Credit = (decimal?) account.LedgerEntry.Sum (d => d.Credit),
                            Debit = (decimal?) account.LedgerEntry.Sum (d => d.Debit)
                    });

            if (request.Filter.Count () > 0) {
                filtered = filtered
                    .Where (DynamicQueryHelper
                        .BuildWhere<SampleModel> (request.Filter)).AsQueryable ();
            }

            var grouped = filtered.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ().GroupBy (c => c.ParentAccount)
                .Select (x => new TrialBalanceDetailModel () {
                    AccountName = x.Key.AccountName,
                        ControlAccountId = x.Key.Id,
                        AccountId = x.Key.AccountId,
                        Entries = x.Select (f => new TrialBalanceDetailListModel () {
                            AccountName = f.AccountName,
                                ControlAccountId = f.ParentAccount.Id,
                                AccountId = f.AccountId,
                                Credit = (decimal?) f.Credit,
                                Debit = (decimal?) f.Debit
                        }).ToList ()
                });

            IList<TrialBalanceDetailModel> detail = new List<TrialBalanceDetailModel> ();

            foreach (var parent in grouped) {
                TrialBalanceDetailModel temp = new TrialBalanceDetailModel () {
                    ControlAccountId = parent.ControlAccountId,
                    AccountId = parent.AccountId,
                    AccountName = parent.AccountName
                };

                foreach (var sub in parent.Entries) {

                    temp.Entries.Add (new TrialBalanceDetailListModel () {
                        AccountName = sub.AccountName,
                            ControlAccountId = sub.ControlAccountId,
                            Credit = sub.Credit,
                            Debit = sub.Debit,
                            AccountId = sub.AccountId
                    });

                }

                detail.Add (temp);

            }

            finalResult.Items = detail;
            finalResult.Count = filtered.Count ();

            return Task.FromResult (finalResult);

        }
    }
}