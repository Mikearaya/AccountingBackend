/*
 * @CreateTime: Apr 30, 2019 2:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 9:31 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.AccountCategories.Queries.GetAccountCategory {
    public class GetAccountCategoryQueryHandler : IRequestHandler<GetAccountCategoryQuery, AccountCategoryView> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountCategoryQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<AccountCategoryView> Handle (GetAccountCategoryQuery request, CancellationToken cancellationToken) {
            var accountCategory = await _database.AccountCatagory
                .Select (AccountCategoryView.Projection)
                .FirstOrDefaultAsync (c => c.Id == request.Id);

            if (accountCategory == null) {
                throw new NotFoundException ("Account category", request.Id);
            }

            return accountCategory;
        }
    }
}