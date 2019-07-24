/*
 * @CreateTime: May 15, 2019 8:23 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 15, 2019 8:46 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Commons;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class LedgerChecklistModel {
        CustomDateConverter converter;

        private DateTime _date;
        public LedgerChecklistModel () {
            converter = new CustomDateConverter ();
        }

        public string ReferenceNumber { get; set; }
        public int LedgerId { get; set; }

        public string EtDate {
            get;
            set;

        }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public IEnumerable<LedgerCheckListDetailModel> Entries { get; set; } = new List<LedgerCheckListDetailModel> ();

        public static Expression<Func<Ledger, LedgerChecklistModel>> Projection {
            get {
                return entry => new LedgerChecklistModel () {
                    LedgerId = entry.Id,
                    ReferenceNumber = entry.VoucherId,
                    Date = entry.Date,
                    EtDate = entry.DateEt,
                    Description = entry.Description,
                    Entries = entry.LedgerEntry
                    .AsQueryable ()
                    .Select (LedgerCheckListDetailModel.Projection)

                };
            }
        }
    }
}