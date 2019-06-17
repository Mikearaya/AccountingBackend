/*
 * @CreateTime: May 15, 2019 7:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 2:48 PM
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
    public class GetDetailedTrialBalanceQueryHandler : IRequestHandler<GetDetailedTrialBalanceQuery, FilterResultModel<TrialBalanceDetailModel>> {
        private readonly IAccountingDatabaseService _database;

        public CustomDateConverter dateConverter { get; }

        public GetDetailedTrialBalanceQueryHandler (IAccountingDatabaseService database) {
            _database = database;
            dateConverter = new CustomDateConverter ();
        }

        public Task<FilterResultModel<TrialBalanceDetailModel>> Handle (GetDetailedTrialBalanceQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "AccountId";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : true;

            FilterResultModel<TrialBalanceDetailModel> finalResult = new FilterResultModel<TrialBalanceDetailModel> ();

            var PageSize = request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            var fromLedger = _database.Account.Where (a => a.ParentAccountNavigation != null && a.Year == request.Year)
                .Join (_database.LedgerEntry, a => a.Id, d => d.AccountId, (a, d) => new SampleModel () {

                    Parent = a.ParentAccountNavigation,
                        Account = a,
                        Type = a.Catagory.AccountType.TypeOfNavigation.Type,
                        Id = a.Id,
                        AccountName = a.AccountName,
                        AccountId = a.ParentAccountNavigation.AccountId,
                        Credit = d.Credit,
                        Debit = d.Debit,
                        Date = d.Ledger.Date
                });

            if (request.StartDate != null) {
                fromLedger = fromLedger.Where (d => d.Date >= dateConverter.EthiopicToGregorian (request.StartDate));
            }

            if (request.EndDate != null) {
                fromLedger = fromLedger.Where (d => d.Date <= dateConverter.EthiopicToGregorian (request.EndDate));
            }

            if (request.Filter.Count () > 0) {
                fromLedger = fromLedger
                    .Where (DynamicQueryHelper
                        .BuildWhere<SampleModel> (request.Filter)).AsQueryable ();
            }

            var grouped = fromLedger.OrderBy (sortBy, sortDirection)

                .GroupBy (a => new { a.Id, a.Account, a.Parent })
                .Select (d => new {
                    AccountName = d.Key.Account.AccountName,
                        AccountId = d.Key.Account.AccountId,
                        Type = d.Select (e => e.Type).First (),
                        ControlAccountId = d.Key.Parent.AccountId,
                        ControlAccountName = d.Key.Parent.AccountName,
                        CreditSum = d.Sum (c => (decimal?) c.Credit),
                        DebitSum = d.Sum (c => (decimal?) c.Debit)

                }).GroupBy (s => new { s.ControlAccountId, s.ControlAccountName })
                .Skip (PageNumber)
                .Take (PageSize)
                .ToList ();

            IList<TrialBalanceDetailModel> detail = new List<TrialBalanceDetailModel> ();

            foreach (var parent in grouped) {
                TrialBalanceDetailModel temp = new TrialBalanceDetailModel () {

                    AccountId = parent.Key.ControlAccountId,
                    AccountName = parent.Key.ControlAccountName,
                    ControlAccountId = parent.Key.ControlAccountId
                };

                foreach (var sub in parent) {

                    var det = new TrialBalanceDetailListModel () {
                        AccountName = sub.AccountName,
                        ControlAccountId = parent.Key.ControlAccountId,
                        Credit = sub.CreditSum,
                        Debit = sub.DebitSum,
                        AccountId = sub.AccountId
                    };

                    if (sub.Type.ToUpper () == "ASSET") {
                        Console.WriteLine ($"{sub.Type}");
                        det.Debit = sub.DebitSum - sub.CreditSum;
                        det.Credit = 0;
                    }
                    ((IList<TrialBalanceDetailListModel>) temp.Entries).Add (det);

                }

                detail.Add (temp);

            }

            finalResult.Items = detail;
            finalResult.Count = fromLedger.Count ();

            return Task.FromResult (finalResult);

        }
    }
}