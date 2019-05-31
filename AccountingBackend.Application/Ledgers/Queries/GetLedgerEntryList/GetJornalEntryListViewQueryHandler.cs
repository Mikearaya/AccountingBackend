/*
 * @CreateTime: May 8, 2019 5:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:32 PM
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
    public class GetJornalEntryListViewQueryHandler : IRequestHandler<GetJornalEntryListQuery, FilterResultModel<JornalEntryListView>> {
        private readonly IAccountingDatabaseService _database;

        public GetJornalEntryListViewQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<JornalEntryListView>> Handle (GetJornalEntryListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "VoucherId";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<JornalEntryListView> result = new FilterResultModel<JornalEntryListView> ();
            var jornalEntries = _database.Ledger
                .Select (JornalEntryListView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<JornalEntryListView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                jornalEntries = jornalEntries
                    .Where (DynamicQueryHelper
                        .BuildWhere<JornalEntryListView> (request.Filter)).AsQueryable ();
            }
            result.Count = jornalEntries.Count ();

            result.Items = jornalEntries.OrderBy (sortBy, sortDirection).Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<JornalEntryListView>> (result);
        }
    }
}