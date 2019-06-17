using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;
/*
 * @CreateTime: Jun 17, 2019 9:26 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 17, 2019 9:28 AM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Ledgers.Models {
    public class LedgerEntryIndexView {
        public int Id { get; set; }
        public string VoucherId { get; set; }

        public static Expression<Func<Ledger, LedgerEntryIndexView>> Projection {
            get {
                return ledger => new LedgerEntryIndexView () {
                    Id = ledger.Id,
                    VoucherId = ledger.VoucherId
                };
            }
        }
    }
}