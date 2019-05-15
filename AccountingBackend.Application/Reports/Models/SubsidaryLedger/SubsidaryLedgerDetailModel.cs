/*
 * @CreateTime: May 15, 2019 9:57 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 10:00 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class SubsidaryLedgerDetailModel {
        public string ReferenceNumber { get; set; }
        public DateTime Date { get; set; }
        public string VoucherId { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public float? Balance { get; set; }

        public static Expression<Func<LedgerEntry, SubsidaryLedgerDetailModel>> Projection {
            get {
                return entry => new SubsidaryLedgerDetailModel () {
                    ReferenceNumber = entry.Ledger.Reference,
                    Date = entry.Ledger.Date,
                    VoucherId = entry.Ledger.VoucherId,
                    Debit = entry.Debit,
                    Credit = entry.Credit

                };
            }
        }

    }
}