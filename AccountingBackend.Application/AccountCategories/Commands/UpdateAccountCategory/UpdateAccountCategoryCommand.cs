/*
 * @CreateTime: Apr 30, 2019 10:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 11:03 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory {
    public class UpdateAccountCategoryCommand : IRequest {

        public int Id { get; set; }
        public string AccountType { get; set; }
        public string CategoryName { get; set; }
    }
}