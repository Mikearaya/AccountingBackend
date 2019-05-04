/*
 * @CreateTime: May 4, 2019 10:06 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 10:10 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCategoryIndexListQueryHandler : IRequestHandler<GetAccountCategoryIndexListQuery, IEnumerable<AccountCategoryIndexView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountCategoryIndexListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<AccountCategoryIndexView>> Handle (GetAccountCategoryIndexListQuery request, CancellationToken cancellationToken) {
            return await _database.AccountCatagory
                .Select (AccountCategoryIndexView.Projection)
                .Where (a => a.Name.Contains (request.SearchString))
                .ToListAsync ();
        }
    }
}