/*
 * @CreateTime: May 8, 2019 2:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:56 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.DeleteLedgerEntry {
    public class DeleteLedgerEntryCommandHandler : IRequestHandler<DeleteLedgerEntryCommand> {
        private readonly IAccountingDatabaseService _database;

        public DeleteLedgerEntryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteLedgerEntryCommand request, CancellationToken cancellationToken) {
            var entry = await _database.Ledger.FindAsync (request.Id);

            if (entry == null) {
                throw new NotFoundException ("Ledger Entry", request.Id);
            }

            _database.Ledger.Remove (entry);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}