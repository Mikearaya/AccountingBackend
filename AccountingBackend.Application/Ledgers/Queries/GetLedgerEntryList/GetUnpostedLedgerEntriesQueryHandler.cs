/*
 * @CreateTime: Jun 7, 2019 12:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 1:07 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntryList {
    public class GetUnpostedLedgerEntriesQueryHandler : IRequestHandler<GetUnpostedLedgerEntriesQuery, FilterResultModel<JornalEntryListView>> {
        private readonly IAccountingDatabaseService _database;

        public GetUnpostedLedgerEntriesQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<JornalEntryListView>> Handle (GetUnpostedLedgerEntriesQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "VoucherId";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;
            var entry = _database.Ledger
                .Where (l => l.IsPosted == 0)
                .Select (JornalEntryListView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<JornalEntryListView> (request.SelectedColumns))
                .AsQueryable ();

            FilterResultModel<JornalEntryListView> result = new FilterResultModel<JornalEntryListView> ();

            if (request.Filter.Count () > 0) {
                entry = entry
                    .Where (DynamicQueryHelper
                        .BuildWhere<JornalEntryListView> (request.Filter)).AsQueryable ();
            }

            result.Count = entry.Count ();

            var PageSize = request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = entry.OrderBy (sortBy, sortDirection).Skip (request.PageNumber)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<JornalEntryListView>> (result);

        }
    }
}