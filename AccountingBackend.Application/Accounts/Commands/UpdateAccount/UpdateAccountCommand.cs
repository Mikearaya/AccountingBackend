/*
 * @CreateTime: Apr 24, 2019 5:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:51 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommand : IRequest {

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