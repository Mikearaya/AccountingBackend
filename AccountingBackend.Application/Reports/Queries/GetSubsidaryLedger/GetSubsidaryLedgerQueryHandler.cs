/*
 * @CreateTime: May 15, 2019 10:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 10:19 AM
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

namespace AccountingBackend.Application.Reports.Queries.GetSubsidaryLedger {
    public class GetSubsidaryLedgerQueryHandler : IRequestHandler<GetSubsidaryLedgerQuery, FilterResultModel<SubsidaryLedgerModel>> {
        private readonly IAccountingDatabaseService _database;
        private readonly CustomDateConverter dateConverter;

        public GetSubsidaryLedgerQueryHandler (IAccountingDatabaseService database) {
            _database = database;
            dateConverter = new CustomDateConverter ();
        }

        public Task<FilterResultModel<SubsidaryLedgerModel>> Handle (GetSubsidaryLedgerQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "ControlAccountId";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<SubsidaryLedgerModel> finalResult = new FilterResultModel<SubsidaryLedgerModel> ();
            var PageSize = request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            var list = _database.Account
                .Include (e => e.ParentAccountNavigation)
                .Where (x => x.ParentAccountNavigation != null)
                .Where (x => x.Year == request.Year && x.LedgerEntry.Count > 0);

            if (request.ControlAccountId.Trim () != "") {
                list = list.Where (l => l.ParentAccountNavigation.AccountId == request.ControlAccountId);
            }

            if (request.SubsidaryId.Trim () != "") {
                list = list.Where (l => l.AccountId == request.SubsidaryId);
            }
            if (request.StartDate != null) {

                list = list.Where (a => a.LedgerEntry
                    .Any (e => e.Ledger.Date <= dateConverter.EthiopicToGregorian (request.EndDate)));
            }

            if (request.EndDate != null) {

                list = list.Where (a => a.LedgerEntry
                    .Any (e => e.Ledger.Date <= dateConverter.EthiopicToGregorian (request.EndDate)));
            }

            var filtered = list.Select (SubsidaryLedgerModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SubsidaryLedgerModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                filtered = filtered
                    .Where (DynamicQueryHelper
                        .BuildWhere<SubsidaryLedgerModel> (request.Filter)).AsQueryable ();
            }

            var fil = finalResult.Items = filtered.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            List<SubsidaryLedgerModel> adjusted = new List<SubsidaryLedgerModel> ();

            foreach (var item in fil) {
                var balance = item.BBF;
                SubsidaryLedgerModel mod = new SubsidaryLedgerModel () {
                    AccountId = item.ControlAccountId,
                    Id = item.Id,
                    AccountName = item.AccountName,
                    AccountType = item.AccountType,
                    SubAccountId = item.SubAccountId,
                    BBF = balance

                };
                foreach (var entry in item.Entries) {

                    if (item.AccountType.ToUpper () == "LIABILITY" || item.AccountType.ToUpper () == "REVENUE" || item.AccountType.ToUpper () == "CAPITAL") {
                        balance = balance + (entry.Credit - entry.Debit);

                    } else {
                        balance = balance + (entry.Debit - entry.Credit);

                    }

                    if (entry.Credit <= 0) {
                        entry.Credit = null;
                    } else {
                        entry.Debit = null;
                    }

                    entry.Balance = balance;
                    ((IList<SubsidaryLedgerDetailModel>) mod.Entries).Add (entry);
                }
                adjusted.Add (mod);
            }
            finalResult.Items = adjusted;
            finalResult.Count = filtered.Count ();

            return Task.FromResult<FilterResultModel<SubsidaryLedgerModel>> (finalResult);
        }
    }
}