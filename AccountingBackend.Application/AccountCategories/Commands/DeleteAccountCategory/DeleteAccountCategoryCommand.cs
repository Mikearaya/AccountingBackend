/*
 * @CreateTime: Apr 30, 2019 1:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:26 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory {
    public class DeleteAccountCategoryCommand : IRequest {
        public int Id { get; set; }
    }
}