/*
 * @CreateTime: May 8, 2019 2:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:44 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace AccountingBackend.Application.Ledgers.Models {
    public class UpdatedLedgerEntryModel {

        public int? Id { get; set; }
        public int AccountId { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }

    }
}