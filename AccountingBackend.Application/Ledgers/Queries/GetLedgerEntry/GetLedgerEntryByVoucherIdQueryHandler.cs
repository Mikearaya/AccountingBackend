/*
 * @CreateTime: Jun 17, 2019 9:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 17, 2019 9:31 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntry {
    public class GetLedgerEntryByVoucherIdQueryHandler : IRequestHandler<GetLedgerEntryByVoucherIdQuery, IEnumerable<LedgerEntryIndexView>> {
        private readonly IAccountingDatabaseService _database;

        public GetLedgerEntryByVoucherIdQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<LedgerEntryIndexView>> Handle (GetLedgerEntryByVoucherIdQuery request, CancellationToken cancellationToken) {
            return await _database.Ledger
                .Where (l => l.VoucherId.Trim ().ToUpper ().Contains (request.VoucherId.Trim ().ToUpper ()))
                .Select (LedgerEntryIndexView.Projection)
                .ToListAsync ();
        }
    }
}