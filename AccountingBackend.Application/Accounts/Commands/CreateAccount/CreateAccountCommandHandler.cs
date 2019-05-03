/*
 * @CreateTime: Apr 24, 2019 4:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 2:58 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int> {
        private readonly IAccountingDatabaseService _database;

        public CreateAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<int> Handle (CreateAccountCommand request, CancellationToken cancellationToken) {
            var account = new Account () {
                AccountName = request.Name,
                Active = request.Active,
                CatagoryId = request.CatagoryId,
                ParentAccount = request.ParentAccount,
                AccountId = request.AccountId,
                Year = DateTime.Now.Year.ToString (),
                OpeningBalance = request.OpeningBalance,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            _database.Account.Add (account);

            await _database.SaveAsync ();

            return account.Id;
        }
    }
}