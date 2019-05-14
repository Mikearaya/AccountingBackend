/*
 * @CreateTime: May 14, 2019 11:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 2:46 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType {
    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountTypeCommandHandler (IAccountingDatabaseService database) {

            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountTypeCommand request, CancellationToken cancellationToken) {
            var error = false;

            List<ValidationFailure> validationFailures = new List<ValidationFailure> ();

            var accountType = await _database.AccountType.FindAsync (request.Id);

            if (accountType == null) {
                throw new NotFoundException ("Account Type");
            }

            if (accountType.TypeOf == 0) {
                error = true;
                validationFailures.Add (new ValidationFailure ("Account Type", "Can not delete account type created by system"));
            }

            if (error) {
                throw new ValidationException (validationFailures);
            }
            _database.AccountType.Remove (accountType);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}