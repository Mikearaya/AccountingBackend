/*
 * @CreateTime: Apr 30, 2019 10:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:17 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountCategories.Models;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory {

    public class UpdateAccountCategoryCommand : IRequest {

        public int Id { get; set; }
        public AccountTypes AccountType { get; set; }
        public string CategoryName { get; set; }
    }
}