/*
 * @CreateTime: Apr 24, 2019 5:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 4:47 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountCommand request, CancellationToken cancellationToken) {
            var account = await _database.Account
                .FindAsync (request.Id);

            if (account == null) {
                throw new NotFoundException ("Account", request.Id);
            }

            _database.Account.Remove (account);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}