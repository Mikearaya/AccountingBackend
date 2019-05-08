/*
 * @CreateTime: May 8, 2019 5:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:42 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerStatusCommand : IRequest {
        public int Id { get; set; }
        public bool Posted { get; set; }
    }
}