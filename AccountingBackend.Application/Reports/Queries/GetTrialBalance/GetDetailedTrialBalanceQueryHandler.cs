/*
 * @CreateTime: May 15, 2019 7:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 1:52 PM
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

            var fromLedger = _database.LedgerEntry
                .Join (_database.Account.Where (a => a.Year == request.Year && a.ParentAccountNavigation != null),
                    ledger => ledger.AccountId, account => account.Id, (ledger, account) => new SampleModel () {
                        Date = ledger.Ledger.Date,
                            ParentAccount = account.ParentAccountNavigation,
                            AccountId = $"{account.ParentAccountNavigation.AccountId} {account.AccountId}",
                            AccountName = $"{account.AccountName}",
                            Credit = account.LedgerEntry.Sum (d => (decimal?) d.Credit),
                            Debit = account.LedgerEntry.Sum (d => (decimal?) d.Debit)
                    }).AsQueryable ();

            if (request.StartDate != null) {
                fromLedger = fromLedger.Where (d => d.Date >= request.StartDate);
            }

            if (request.EndDate != null) {
                fromLedger = fromLedger.Where (d => d.Date <= request.EndDate);
            }

            if (request.Filter.Count () > 0) {
                fromLedger = fromLedger
                    .Where (DynamicQueryHelper
                        .BuildWhere<SampleModel> (request.Filter)).AsQueryable ();
            }

            var grouped = fromLedger.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .GroupBy (c => c.ParentAccount)
                .ToList ()
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

                    ((IList<TrialBalanceDetailListModel>) temp.Entries).Add (new TrialBalanceDetailListModel () {
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
            finalResult.Count = fromLedger.Count ();

            return Task.FromResult (finalResult);

        }
    }
}