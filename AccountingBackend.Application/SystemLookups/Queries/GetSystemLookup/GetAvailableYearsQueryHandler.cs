/*
 * @CreateTime: May 22, 2019 4:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 22, 2019 5:08 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.SystemLookups.Queries.GetSystemLookup {
    public class GetAvailableYearsQueryHandler : IRequestHandler<GetAvailableYearsQuery, IEnumerable<AvailableYearsModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetAvailableYearsQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<AvailableYearsModel>> Handle (GetAvailableYearsQuery request, CancellationToken cancellationToken) {
            return await _database.Account.Select (AvailableYearsModel.Projection).Distinct ().ToListAsync ();
        }
    }
}