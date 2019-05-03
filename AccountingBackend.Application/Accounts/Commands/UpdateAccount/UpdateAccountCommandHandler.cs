/*
 * @CreateTime: Apr 24, 2019 5:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 9:00 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateAccountCommand request, CancellationToken cancellationToken) {

            var account = await _database.Account.FindAsync (request.Id);

            if (account == null) {
                throw new NotFoundException ("Account", request.Id);
            }

            account.AccountName = request.Name;
            account.AccountId = request.AccountId;
            account.Active = request.Active;
            account.ParentAccount = request.ParentAccount;
            account.DateUpdated = DateTime.Now;

            _database.Account.Update (account);

            await _database.SaveAsync ();

            return Unit.Value;
        }

    }
}