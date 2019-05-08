/*
 * @CreateTime: May 8, 2019 3:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Ledgers.Models {
    public class JornalEntryListView {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public string VoucherId { get; set; }
        public bool Posted { get; set; }

        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Ledger, JornalEntryListView>> Projection {
            get {
                return entry => new JornalEntryListView () {
                    Id = entry.Id,
                    VoucherId = entry.VoucherId,
                    Description = entry.Description,
                    Date = entry.Date,
                    Reference = entry.Reference,
                    Posted = (entry.IsPosted == 0) ? false : true,
                    DateAdded = entry.DateAdded,

                };
            }
        }

    }
}