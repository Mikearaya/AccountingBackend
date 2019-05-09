/*
 * @CreateTime: May 8, 2019 5:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:46 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerStatusCommandHandler : IRequestHandler<UpdateLedgerStatusCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateLedgerStatusCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateLedgerStatusCommand request, CancellationToken cancellationToken) {
            var entry = await _database.Ledger.FindAsync (request.Id);

            if (entry == null) {
                throw new NotFoundException ("Ledger entry", request.Id);
            }

            entry.IsPosted = request.Posted;

            _database.Ledger.Update (entry);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}