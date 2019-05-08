/*
 * @CreateTime: May 8, 2019 4:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:49 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace AccountingBackend.Domain {
    public partial class LedgerEntry {
        public int Id { get; set; }
        public int LedgerId { get; set; }
        public int AccountId { get; set; }
        public float? Credit { get; set; }
        public float? Debit { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Account Account { get; set; }
        public virtual Ledger Ledger { get; set; }
    }
}