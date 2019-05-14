/*
 * @CreateTime: May 14, 2019 12:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 12:44 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountTypes.Models;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeIndexQueryHandler : IRequestHandler<GetAccountTypeIndexQuery, IEnumerable<AccountTypeIndexView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountTypeIndexQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<AccountTypeIndexView>> Handle (GetAccountTypeIndexQuery request, CancellationToken cancellationToken) {
            var accountTypeIndex = _database.AccountType
                .Select (AccountTypeIndexView.Projection);
            if (request.TypeOf != 0) {
                accountTypeIndex.Where (a => a.TypeOf == request.TypeOf);
            }

            return await accountTypeIndex.ToListAsync ();
        }
    }
}