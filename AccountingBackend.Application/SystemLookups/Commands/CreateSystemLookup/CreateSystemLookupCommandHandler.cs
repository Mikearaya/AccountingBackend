/*
 * @CreateTime: May 6, 2019 11:05 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:20 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Commands.CreateSystemLookup {
    public class CreateSystemLookupCommandHandler : IRequestHandler<CreateSystemLookupCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public CreateSystemLookupCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (CreateSystemLookupCommand request, CancellationToken cancellationToken) {

            foreach (var item in request.Lookups) {
                _database.SystemLookup.Add (new SystemLookup () {
                    Type = item.Type,
                        Value = item.Value,
                        DateAdded = DateTime.Now,
                        DateUpdated = DateTime.Now
                });
            }

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}