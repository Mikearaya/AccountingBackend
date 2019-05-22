/*
 * @CreateTime: May 20, 2019 5:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 20, 2019 5:50 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Reports.Models;

namespace AccountingBackend.Application.Reports.Queries.GetLedgerChecklist {
    public class LedgerChecklistView {
        public IEnumerable<LedgerChecklistModel> Items { get; set; }
        public int Count { get; set; }
    }
}