/*
 * @CreateTime: May 8, 2019 3:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 3:18 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Ledgers.Models;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntry {
    public class GetLedgerEntryByIdQuery : IRequest<LedgerEntryViewModel> {
        public int Id { get; set; }
    }
}