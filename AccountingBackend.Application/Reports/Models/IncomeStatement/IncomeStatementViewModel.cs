/*
 * @CreateTime: May 17, 2019 6:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 17, 2019 6:00 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace AccountingBackend.Application.Reports.Models {
    public class IncomeStatementViewModel {
        public IList<IncomeStatementItemModel> Expense { get; set; } = new List<IncomeStatementItemModel> ();

        public float? CostOfGoodsSold { get; set; }
        public IList<IncomeStatementItemModel> Revenue { get; set; } = new List<IncomeStatementItemModel> ();

        public float? NetSurplus { get; set; }
    }
}