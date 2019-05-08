/*
 * @CreateTime: May 8, 2019 8:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 1:51 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry {
    public class CreateLedgerEntryCommandHandler : IRequestHandler<CreateLedgerEntryCommand, int> {
        private readonly IAccountingDatabaseService _database;

        public CreateLedgerEntryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<int> Handle (CreateLedgerEntryCommand request, CancellationToken cancellationToken) {
            bool error = false;

            List<ValidationFailure> validationFailures = new List<ValidationFailure> ();

            /* if (await _database.Ledger.AnyAsync (v => v.VoucherId.ToLower ().Trim () == request.VoucherId.ToLower ().Trim ())) {
                error = true;
                validationFailures.Add (new ValidationFailure ("VoucherId", "Voucher Id provided has already been used for anouther entry, use another Id"));
            } */

            Ledger ledger = new Ledger () {
                Description = request.Description,
                Date = request.Date,
                VoucherId = request.VoucherId.Trim (),
                IsPosted = request.Posted,
                Reference = request.Reference.Trim (),
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            float? totalCredit = 0;
            float? totalDebit = 0;
            foreach (var item in request.Entries) {
                ledger.LedgerEntry.Add (new LedgerEntry () {
                    AccountId = item.AccountId,
                        Credit = item.Credit,
                        Debit = item.Debit
                });

                totalCredit += totalCredit + item.Credit;
                totalDebit = totalDebit + item.Debit;
            }

            if (totalCredit != totalDebit) {
                error = true;
                validationFailures.Add (new ValidationFailure ("Balance", "Credit and debit amount for this are not balanced"));
            }

            if (error) {
                throw new ValidationException (validationFailures);
            }

            _database.Ledger.Add (ledger);

            await _database.SaveAsync ();

            return ledger.Id;
        }
    }
}