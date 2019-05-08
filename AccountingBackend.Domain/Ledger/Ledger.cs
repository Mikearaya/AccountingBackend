/*
 * @CreateTime: May 8, 2019 4:46 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:48 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace AccountingBackend.Domain {
    public partial class Ledger {
        public Ledger () {
            LedgerEntry = new HashSet<LedgerEntry> ();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public sbyte? IsPosted { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<LedgerEntry> LedgerEntry { get; set; }
    }
}