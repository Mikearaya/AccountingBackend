/*
 * @CreateTime: May 8, 2019 2:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 11:46 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using FluentValidation.Results;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerEntryCommandHandler : IRequestHandler<UpdateLedgerEntryCommand, Unit> {
        private readonly IAccountingDatabaseService _database;
        private List<ValidationFailure> validationFailures;
        private bool hasError;
        public UpdateLedgerEntryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
            validationFailures = new List<ValidationFailure> ();
        }

        public async Task<Unit> Handle (UpdateLedgerEntryCommand request, CancellationToken cancellationToken) {

            var entry = await _database.Ledger.FindAsync (request.Id);

            if (entry == null) {
                throw new NotFoundException ("Ledger", request.Id);
            }

            if (entry.IsPosted != 0) {
                hasError = true;
                validationFailures.Add (new ValidationFailure ("Ledger Posted", "Can't update posted ledger entry"));
            }

            entry.VoucherId = request.VoucherId;
            entry.Description = request.Description;
            entry.Date = request.Date;
            entry.IsPosted = request.Posted;
            entry.Reference = request.Reference;
            entry.DateUpdated = DateTime.Now;

            float? totalCredit = 0;
            float? totalDebit = 0;

            foreach (var item in request.DeletedIds) {
                var deleted = await _database.LedgerEntry.FindAsync (item);

                if (deleted == null) {
                    throw new NotFoundException ("Ledger Entry", item);
                }

                _database.LedgerEntry.Remove (deleted);
            }
            foreach (var item in request.Entries) {

                if (item.Id != 0) {

                    _database.LedgerEntry.Add (new LedgerEntry () {
                        Id = (int) item.Id,
                            AccountId = item.AccountId,
                            Credit = item.Credit,
                            Debit = item.Debit
                    });

                } else {
                    entry.LedgerEntry.Add (new LedgerEntry () {
                        AccountId = item.AccountId,
                            Credit = item.Credit,
                            Debit = item.Debit
                    });
                }

                totalCredit += item.Credit;
                totalDebit += item.Debit;
            }

            if (totalCredit != totalDebit) {
                hasError = true;
                validationFailures.Add (new ValidationFailure ("Balance", "Credit and debit amount for this are not balanced"));
            }

            if (hasError) {
                throw new ValidationException (validationFailures);
            }

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}