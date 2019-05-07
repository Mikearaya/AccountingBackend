/*
 * @CreateTime: May 6, 2019 11:23 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 4:10 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommandHandler : IRequestHandler<DeleteSystemLookupCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteSystemLookupCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteSystemLookupCommand request, CancellationToken cancellationToken) {
            var lookup = await _database.SystemLookup
                .Include (x => x.Account)
                .FirstOrDefaultAsync (d => d.Id == request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            if (lookup.Account.Count () > 0) {
                throw new DeleteingParentOfMultipleChilderenException ("Lookup", request.Id);
            }

            _database.SystemLookup.Remove (lookup);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}