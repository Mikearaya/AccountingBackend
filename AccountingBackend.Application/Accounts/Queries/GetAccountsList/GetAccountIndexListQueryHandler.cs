/*
 * @CreateTime: May 4, 2019 9:34 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 9:40 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountIndexListQueryHandler : IRequestHandler<GetAccountIndexListQuery, IEnumerable<AccountIndexView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountIndexListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<AccountIndexView>> Handle (GetAccountIndexListQuery request, CancellationToken cancellationToken) {
            return await _database.Account
                .Select (AccountIndexView.Projection)
                .Where (a => a.Name.Contains (request.SearchString))
                .Take (10)
                .ToListAsync ();
        }
    }
}