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
            InverseTypeOfNavigation = new HashSet<AccountType> ();
        }
        public uint Id { get; set; }
        public string Type { get; set; }
        public uint? TypeOf { get; set; }
        public sbyte IsSummery { get; set; }

        public virtual AccountType TypeOfNavigation { get; set; }
        public virtual ICollection<AccountCatagory> AccountCatagory { get; set; }
        public virtual ICollection<AccountType> InverseTypeOfNavigation { get; set; }
    }
}