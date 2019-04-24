/*
 * @CreateTime: Apr 24, 2019 5:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:13 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace AccountingBackend.Application.Accounts.Models {
    public class AccountViewModel {
        public string AccountId { get; set; }
        public string ParentAccount { get; set; }
        public string AccountName { get; set; }
        public sbyte? Active { get; set; }
        public double TotalAmount { get; set; }
        public double OpeningBalance { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}