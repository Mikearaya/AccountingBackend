/*
 * @CreateTime: Apr 30, 2019 8:29 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 8:40 AM
 * @Description: Model used while creating account
 */
using AccountingBackend.Application.AccountCategories.Models;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommand : IRequest<int> {

        public string CategoryName { get; set; }
        public string AccountType { get; set; }
    }
}