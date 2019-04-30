/*
 * @CreateTime: Apr 30, 2019 6:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 6:21 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace AccountingBackend.Domain {
    public partial class AccountType {
        public AccountType () {
            AccountCatagory = new HashSet<AccountCatagory> ();
        }

        public string Type { get; set; }

        public virtual ICollection<AccountCatagory> AccountCatagory { get; set; }
    }
}