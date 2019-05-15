/*
 * @CreateTime: May 15, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 8:38 AM
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

namespace AccountingBackend.Application.Reports.Queries {
    public class GetLedgerCheckListQueryHandler : IRequestHandler<GetLedgerCheckListQuery, IEnumerable<LedgerChecklistModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetLedgerCheckListQueryHandler (IAccountingDatabaseService database) {
            _database = database;

        }

        public async Task<IEnumerable<LedgerChecklistModel>> Handle (GetLedgerCheckListQuery request, CancellationToken cancellationToken) {
            return await _database.Ledger
                .Select (LedgerChecklistModel.Projection)
                .Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToListAsync ();
        }
    }
}