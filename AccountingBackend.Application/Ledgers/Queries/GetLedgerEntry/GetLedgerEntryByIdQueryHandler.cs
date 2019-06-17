/*
 * @CreateTime: May 8, 2019 3:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 17, 2019 10:51 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntry {
    public class GetLedgerEntryByIdQueryHandler : IRequestHandler<GetLedgerEntryByIdQuery, LedgerEntryViewModel> {
        private readonly IAccountingDatabaseService _database;

        public GetLedgerEntryByIdQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<LedgerEntryViewModel> Handle (GetLedgerEntryByIdQuery request, CancellationToken cancellationToken) {
            var entry = await _database.Ledger
                .Include (l => l.LedgerEntry)
                .Select (LedgerEntryViewModel.Projection)
                .FirstOrDefaultAsync (x => x.Id == request.Id);

            entry.Next = await _database.Ledger.Where (a => a.Id > request.Id).Select (e => e.Id).OrderBy (a => a).Take (1).FirstOrDefaultAsync ();
            entry.Prev = await _database.Ledger.Where (a => a.Id < request.Id).Select (e => e.Id).OrderByDescending (a => a).Take (1).FirstOrDefaultAsync ();

            if (entry == null) {
                throw new NotFoundException ("Ledger Entry", request.Id);
            }

            return entry;
        }
    }
}