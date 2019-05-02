/*
 * @CreateTime: Apr 24, 2019 4:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 6:50 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommand : IRequest<int> {
        public string Id { get; set; }
        public int ParentAccount { get; set; }
        public int CatagoriId { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public int OrganizationId { get; set; }
        public float OpeningBalance { get; set; }
    }
}