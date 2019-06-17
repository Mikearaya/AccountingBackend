/*
 * @CreateTime: Jun 9, 2019 11:13 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 2:02 PM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class SampleModel {

        public Account Parent { get; set; }
        public Account Account { get; set; }

        public int Id { get; set; }
        public LedgerEntry Ledger { get; set; }
        public string Type { get; set; }

        public string AccountName { get; set; }
        public string AccountId { get; set; }
        public Account ParentAccount { get; set; }
        public float? Credit { get; set; }
        public float? Debit { get; set; }
        public DateTime Date { get; set; }
    }
}