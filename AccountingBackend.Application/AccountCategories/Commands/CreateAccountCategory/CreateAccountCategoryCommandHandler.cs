/*
 * @CreateTime: Apr 30, 2019 8:33 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 1:47 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommandHandler : IRequestHandler<CreateAccountCategoryCommand, int> {
        private readonly IAccountingDatabaseService _database;

        public CreateAccountCategoryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<int> Handle (CreateAccountCategoryCommand request, CancellationToken cancellationToken) {
            AccountCatagory category = new AccountCatagory () {
                Catagory = request.CategoryName,
                Type = request.AccountType,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            _database.AccountCatagory.Add (category);

            await _database.SaveAsync ();

            return category.Id;
        }
    }
}