/*
 * @CreateTime: Apr 24, 2019 4:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 5:25 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string> {
        private readonly IAccountingDatabaseService _database;

        public CreateAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<string> Handle (CreateAccountCommand request, CancellationToken cancellationToken) {
            var account = new Account () {
                AccountName = request.Name,
                Active = request.Active,
                CatagoryId = request.CatagoriId,
                ParentAccount = request.ParentAccount,
                Id = request.Id,
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