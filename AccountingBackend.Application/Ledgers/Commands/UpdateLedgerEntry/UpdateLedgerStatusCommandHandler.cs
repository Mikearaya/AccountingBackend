/*
 * @CreateTime: May 8, 2019 5:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:46 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerStatusCommandHandler : IRequestHandler<UpdateLedgerStatusCommand, Unit> {
        private readonly IAccountingDatabaseService _database;
        private List<ValidationFailure> validationFailures;
        public UpdateLedgerStatusCommandHandler (IAccountingDatabaseService database) {
            _database = database;
            validationFailures = new List<ValidationFailure> ();
        }

        public async Task<Unit> Handle (UpdateLedgerStatusCommand request, CancellationToken cancellationToken) {
            bool hasError = false;

            var entry = await _database.Ledger.Include (e => e.LedgerEntry).FirstOrDefaultAsync (l => l.Id == request.Id);

            if (entry == null) {
                throw new NotFoundException ("Ledger entry", request.Id);
            }

            if (entry.LedgerEntry.Sum (c => c.Credit) != entry.LedgerEntry.Sum (d => d.Debit) && request.Posted != 0) {

                hasError = true;
                validationFailures.Add (new ValidationFailure ("Balance", "Can not post unbalanced entry"));
            }

            if (hasError) {
                throw new ValidationException (validationFailures);
            }
            entry.IsPosted = request.Posted;

            _database.Ledger.Update (entry);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}