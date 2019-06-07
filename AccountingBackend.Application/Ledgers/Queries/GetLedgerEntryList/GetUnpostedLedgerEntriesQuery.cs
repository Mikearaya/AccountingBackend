using System.Collections.Generic;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntryList {
    public class GetUnpostedLedgerEntriesQuery : ApiQueryString, IRequest<FilterResultModel<JornalEntryListView>> {

    }
}