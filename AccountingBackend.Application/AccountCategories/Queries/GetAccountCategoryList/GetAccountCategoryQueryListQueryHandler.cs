/*
 * @CreateTime: Apr 30, 2019 2:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 2:03 PM
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
    public class GetAccountCatugoryQueryListQueryHandler : IRequestHandler<GetAccountCategoryListQuery, IEnumerable<AccountCategoryView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountCatugoryQueryListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<AccountCategoryView>> Handle (GetAccountCategoryListQuery request, CancellationToken cancellationToken) {
            return await _database.AccountCatagory.Select (AccountCategoryView.Projection).ToListAsync ();
        }
    }
}