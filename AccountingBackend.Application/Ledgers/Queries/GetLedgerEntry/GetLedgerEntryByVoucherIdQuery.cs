/*
 * @CreateTime: Jun 17, 2019 9:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 17, 2019 9:24 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Ledgers.Models;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Queries.GetLedgerEntry {
    public class GetLedgerEntryByVoucherIdQuery : IRequest<IEnumerable<LedgerEntryIndexView>> {
        private string id { get; set; } = "";
        public string VoucherId {
            get {
                return id;
            }
            set {
                id = (value == null) ? "" : value;
            }
        }
    }
}