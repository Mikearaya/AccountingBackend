/*
 * @CreateTime: Apr 29, 2019 4:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 6:47 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace AccountingBackend.Domain {
    public partial class Account {

        public Account () {
            InverseParentAccountNavigation = new HashSet<Account> ();
        }

        public int Id { get; set; }
        public string AccountName { get; set; }
        public int? ParentAccount { get; set; }
        public int CatagoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? OpeningBalance { get; set; }
        public sbyte Active { get; set; }
        public string Year { get; set; }
        public string AccountId { get; set; }

        public virtual AccountCatagory Catagory { get; set; }
        public virtual Account ParentAccountNavigation { get; set; }
        public virtual ICollection<Account> InverseParentAccountNavigation { get; set; }
    }
}