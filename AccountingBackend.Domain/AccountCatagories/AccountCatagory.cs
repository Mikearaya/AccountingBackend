/*
 * @CreateTime: Apr 30, 2019 6:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 6:22 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace AccountingBackend.Domain {
    public partial class AccountCatagory {
        public AccountCatagory () {
            Account = new HashSet<Account> ();
            InverseOverflowAccountNavigation = new HashSet<AccountCatagory> ();
        }

        public int Id { get; set; }
        public string Catagory { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint AccountTypeId { get; set; }
        public int? OverflowAccount { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual AccountCatagory OverflowAccountNavigation { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<AccountCatagory> InverseOverflowAccountNavigation { get; set; }
    }
}