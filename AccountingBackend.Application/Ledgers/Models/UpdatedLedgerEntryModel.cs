/*
 * @CreateTime: May 8, 2019 2:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:30 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace AccountingBackend.Application.Ledgers.Models {
    public class UpdatedLedgerEntryModel {

        public UpdatedLedgerEntryModel () {
            DeletedIds = new List<int> ();
        }

        public int? Id { get; set; }
        public int AccountId { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public List<int> DeletedIds;

    }
}