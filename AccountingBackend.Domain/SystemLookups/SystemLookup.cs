/*
 * @CreateTime: May 6, 2019 10:28 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 10:28 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using AccountingBackend.Domain;

namespace AccountingBackend.Domain {
    public partial class SystemLookup {
        public SystemLookup () {
            Account = new HashSet<Account> ();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public virtual ICollection<Account> Account { get; set; }
    }
}