/*
 * @CreateTime: Apr 24, 2019 4:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 10:39 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommand : IRequest<int> {
        public string AccountId { get; set; }
        public int? ParentAccount { get; set; }
        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public int? CostCenterId { get; set; }
        public int? OrganizationId { get; set; }
        public float OpeningBalance { get; set; }
    }
}