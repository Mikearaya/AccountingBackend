/*
 * @CreateTime: Apr 24, 2019 5:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:06 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommand : IRequest {
        public int Id { get; set; }
        public int? ParentAccount { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public sbyte Active { get; set; }
    }
}