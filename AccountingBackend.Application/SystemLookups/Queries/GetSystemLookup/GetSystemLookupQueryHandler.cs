/*
 * @CreateTime: May 6, 2019 11:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 2:52 PM
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

        public async Task<SystemLookupViewModel> Handle (GetSystemLookupQuery request, CancellationToken cancellationToken) {
            var lookup = await _database.SystemLookup
                .Select (SystemLookupViewModel.Projection)
                .FirstOrDefaultAsync (s => s.Id == request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            return lookup;

        }
    }
}