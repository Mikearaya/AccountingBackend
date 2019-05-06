/*
 * @CreateTime: May 6, 2019 11:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:35 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.SystemLookups.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookup {
    public class GetSystemLookupQueryHandler : IRequestHandler<GetSystemLookupQuery, SystemLookupViewModel> {
        private readonly IAccountingDatabaseService _database;

        public GetSystemLookupQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<SystemLookupViewModel> Handle (GetSystemLookupQuery request, CancellationToken cancellationToken) {
            var lookup = _database.SystemLookup
                .Select (SystemLookupViewModel.Projection)
                .FirstOrDefaultAsync (s => s.Id == request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            return lookup;

        }
    }
}