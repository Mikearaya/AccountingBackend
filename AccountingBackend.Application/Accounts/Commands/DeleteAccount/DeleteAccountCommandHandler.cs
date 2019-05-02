/*
 * @CreateTime: Apr 24, 2019 5:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:12 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountCommand request, CancellationToken cancellationToken) {
            var account = await _database.Account.FindAsync (request.Id);

            if (account == null) {
                throw new NotFoundException ("Account", request.Id);
            }

            _database.Account.Remove (account);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}