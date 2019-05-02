/*
 * @CreateTime: Apr 24, 2019 5:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:09 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommand : IRequest {
        public string Id { get; set; }
    }
}