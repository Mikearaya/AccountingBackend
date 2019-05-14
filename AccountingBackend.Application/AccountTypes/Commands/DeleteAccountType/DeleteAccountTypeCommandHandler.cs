/*
 * @CreateTime: May 14, 2019 11:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:07 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType {
    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountTypeCommandHandler (IAccountingDatabaseService database) {

            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountTypeCommand request, CancellationToken cancellationToken) {
            var accountType = await _database.AccountType.FindAsync (request.Id);

            if (accountType == null) {
                throw new NotFoundException ("Account Type");
            }

            _database.AccountType.Remove (accountType);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}