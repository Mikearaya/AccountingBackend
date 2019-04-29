/*
 * @CreateTime: Apr 29, 2019 4:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 4:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace AccountingBackend.Domain {
    public partial class AccountCatagory {
        public AccountCatagory () {
            Account = new HashSet<Account> ();
        }

        public int Id { get; set; }
        public string Catagory { get; set; }
        public string Name { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}