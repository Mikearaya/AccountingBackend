/*
 * @CreateTime: May 17, 2019 6:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 17, 2019 6:18 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Reports.Models;
using MediatR;

namespace AccountingBackend.Application.Reports.Queries.GetIncomeStatement {
    public class GetIncomeStatementQueryHandler : IRequestHandler<GetIncomeStatementQuery, IncomeStatementViewModel> {
        private IAccountingDatabaseService _database;

        public GetIncomeStatementQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<IncomeStatementViewModel> Handle (GetIncomeStatementQuery request, CancellationToken cancellationToken) {
            var x = _database.AccountType.Join (_database.AccountCatagory,
                type => type.Id, category => category.AccountTypeId, (type, category) => new {
                    Type = type.Type,
                        Category = category
                }).ToList ();

            foreach (var item in x) {
                Console.WriteLine ($"{item.Type}");
            }

            IncomeStatementViewModel incomeStateMent = new IncomeStatementViewModel ();

            return Task.FromResult (incomeStateMent);
        }
    }
}