/*
 * @CreateTime: Apr 24, 2019 4:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:43 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommand : IRequest<int> {
        public string ParentAccount { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public sbyte Active { get; set; }
        public uint AccountType { get; set; }
        public uint OrganizationId { get; set; }
        public string GlType { get; set; }
        public string PostingType { get; set; }
        public sbyte? IsReconcilation { get; set; }
        public sbyte? IsPosting { get; set; }
    }
}