/*
 * @CreateTime: Apr 24, 2019 5:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:44 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommand : IRequest {
        public string AccountId { get; set; }
    }
}