/*
 * @CreateTime: Apr 30, 2019 1:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 1:57 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory {
    public class DeleteAccountCategoryCommandHandler : IRequestHandler<DeleteAccountCategoryCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountCategoryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountCategoryCommand request, CancellationToken cancellationToken) {
            var category = await _database.AccountCatagory.FindAsync (request.Id);

            if (category == null) {
                throw new NotFoundException ("Account category", request.Id);
            }

            _database.AccountCatagory.Remove (category);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}