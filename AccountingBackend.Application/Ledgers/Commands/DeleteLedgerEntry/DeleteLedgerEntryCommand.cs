/*
 * @CreateTime: May 8, 2019 2:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:53 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.DeleteLedgerEntry {
    public class DeleteLedgerEntryCommand : IRequest {
        public int Id { get; set; }
    }
}