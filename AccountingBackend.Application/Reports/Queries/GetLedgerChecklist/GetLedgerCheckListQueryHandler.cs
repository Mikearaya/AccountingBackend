/*
 * @CreateTime: May 15, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 22, 2019 4:45 PM
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
    public class GetLedgerCheckListQueryHandler : IRequestHandler<GetLedgerCheckListQuery, FilterResultModel<LedgerChecklistModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetLedgerCheckListQueryHandler (IAccountingDatabaseService database) {
            _database = database;

        }

        public Task<FilterResultModel<LedgerChecklistModel>> Handle (GetLedgerCheckListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Date";
            var sortDirection = (request.SortDirection.ToUpper () != "DESCENDING") ? true : false;

            FilterResultModel<LedgerChecklistModel> result = new FilterResultModel<LedgerChecklistModel> ();

            CustomDateConverter converter = new CustomDateConverter ();
            var start = Convert.ToInt32 (request.Year) - 1;
            var start_date = converter.EthiopicToGregorian ($"1/11/{start}");
            var end_date = converter.EthiopicToGregorian ($"30/10/{request.Year}");
            var list = _database.Ledger
                .Where (x => x.Date >= start_date && x.Date <= end_date);

            if (request.FromVoucherId.Trim () != "") {
                list = list.Where (l => l.VoucherId.CompareTo (request.FromVoucherId) > 0 || l.VoucherId.CompareTo (request.FromVoucherId) == 0);
            }

            if (request.ToVoucherId.Trim () != "") {
                list = list.Where (l => l.VoucherId.CompareTo (request.ToVoucherId) < 0 || l.VoucherId.CompareTo (request.ToVoucherId) == 0);
            }

            if (request.StartDate != null) {
                list = list.Where (a => a.LedgerEntry
                    .Any (e => e.Ledger.Date > request.StartDate && e.Ledger.Date < request.EndDate));
            }

            var filtered = list.Select (LedgerChecklistModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<LedgerChecklistModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                filtered = filtered
                    .Where (DynamicQueryHelper
                        .BuildWhere<LedgerChecklistModel> (request.Filter));
            }

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Count = filtered.Count ();
            result.Items = filtered.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<LedgerChecklistModel>> (result);
        }

    }
}