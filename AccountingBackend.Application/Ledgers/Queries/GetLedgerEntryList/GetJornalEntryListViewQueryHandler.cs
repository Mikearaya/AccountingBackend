/*
 * @CreateTime: May 8, 2019 5:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:32 PM
 * @Description: Modify Here, Please 
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using AccountingBackend.Commons;
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

            CustomDateConverter converter = new CustomDateConverter ();
            var start = Convert.ToInt32(request.Year) -1;
            var start_date = converter.EthiopicToGregorian ($"1/11/{start}");
            var end_date = converter.EthiopicToGregorian ($"30/10/{request.Year}");

            var jornalEntries = _database.Ledger
                .Where (l => l.Date >= start_date && l.Date<=end_date)
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