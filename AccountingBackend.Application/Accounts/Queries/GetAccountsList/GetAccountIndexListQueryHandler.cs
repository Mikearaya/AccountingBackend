/*
 * @CreateTime: May 4, 2019 9:34 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 10:24 AM
 * @Description: Modify Here, Please 
 */
using System;
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

            var accounts = _database.Account
                .Where (a => a.Year == request.Year);

            if (request.Type.ToUpper () == "CONTROL") {
                accounts = accounts.Where (a => a.ParentAccountNavigation == null);
            } else {
                accounts = accounts.Where (a => a.ParentAccountNavigation != null);
            }

            return await accounts.Select (AccountIndexView.Projection)
                .Where (a => a.Name.ToUpper ().Contains (request.SearchString.ToString ().ToUpper ()))
                .ToListAsync ();
        }
    }
}