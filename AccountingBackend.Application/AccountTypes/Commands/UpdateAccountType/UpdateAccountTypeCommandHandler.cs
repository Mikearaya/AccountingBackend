/*
 * @CreateTime: May 14, 2019 10:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:48 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateAccountTypeCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateAccountTypeCommand request, CancellationToken cancellationToken) {
            var accountType = await _database.AccountType.FindAsync (request.Id);

            if (accountType == null) {
                throw new NotFoundException ("AccountType", request.Id);
            }

            accountType.IsSummery = request.IsSummary;
            accountType.Type = request.Type;
            accountType.TypeOf = request.IsTypeOf;

            _database.AccountType.Update (accountType);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}