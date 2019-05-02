/*
 * @CreateTime: Apr 30, 2019 10:33 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:17 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory {
    public class UpdateAccountCategoryCommandHandler : IRequestHandler<UpdateAccountCategoryCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateAccountCategoryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateAccountCategoryCommand request, CancellationToken cancellationToken) {
            var catagory = await _database.AccountCatagory.FindAsync (request.Id);

            if (catagory == null) {
                throw new NotFoundException ("Account Category", request.Id);
            }

            catagory.Catagory = request.CategoryName;
            catagory.Type = request.AccountType;

            _database.AccountCatagory.Update (catagory);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}