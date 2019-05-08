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
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntryList {
    public class GetJornalEntryListViewQueryHandler : IRequestHandler<GetJornalEntryListQuery, IEnumerable<JornalEntryListView>> {
        private readonly IAccountingDatabaseService _database;

        public GetJornalEntryListViewQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<JornalEntryListView>> Handle (GetJornalEntryListQuery request, CancellationToken cancellationToken) {
            var jornalEntries = _database.Ledger
                .Select (JornalEntryListView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<JornalEntryListView> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<JornalEntryListView>> (jornalEntries);
        }
    }
}