/*
 * @CreateTime: Apr 30, 2019 8:29 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:18 PM
 * @Description: Model used while creating account
 */
using AccountingBackend.Application.AccountCategories.Models;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommand : IRequest<int> {

        public string CategoryName { get; set; }
        public AccountTypes AccountType { get; set; }
    }
}