/*
 * @CreateTime: May 15, 2019 10:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 10:19 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Reports.Queries.GetSubsidaryLedger {
    public class GetSubsidaryLedgerQueryHandler : IRequestHandler<GetSubsidaryLedgerQuery, IEnumerable<SubsidaryLedgerModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetSubsidaryLedgerQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<SubsidaryLedgerModel>> Handle (GetSubsidaryLedgerQuery request, CancellationToken cancellationToken) {
            return await _database.Account
                .Select (SubsidaryLedgerModel.Projection)
                .Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToListAsync ();
        }
    }
}