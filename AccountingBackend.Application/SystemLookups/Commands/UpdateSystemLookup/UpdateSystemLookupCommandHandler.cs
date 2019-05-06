/*
 * @CreateTime: May 6, 2019 11:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:20 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommandHandler : IRequestHandler<UpdateSystemLookupCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateSystemLookupCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateSystemLookupCommand request, CancellationToken cancellationToken) {

            foreach (var item in request.Lookups) {

                if (item.Id != 0) {
                    var look = await _database.SystemLookup.FindAsync (item.Id);

                    if (look == null) {
                        throw new NotFoundException ("System lookup", item.Id);
                    }
                    look.Type = item.Type;
                    look.Value = item.Value;
                    look.DateUpdated = DateTime.Now;
                    _database.SystemLookup.Update (look);

                } else {

                    _database.SystemLookup.Add (new SystemLookup () {
                        Type = item.Type,
                            Value = item.Value,
                            DateAdded = DateTime.Now,
                            DateUpdated = DateTime.Now
                    });
                }
            }

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}