/*
 * @CreateTime: May 19, 2019 8:46 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 19, 2019 9:15 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace AccountingBackend.Application.Reports.Models {
    public class BalanceSheetViewModel {
        public IList<BalanceSheetItemModel> Assets { get; set; } = new List<BalanceSheetItemModel> ();
        public float? TotalAsset { get; set; }
        public IList<BalanceSheetItemModel> Capitals { get; set; } = new List<BalanceSheetItemModel> ();
        public float? TotalLiability { get; set; }
        public IList<BalanceSheetItemModel> Liabilities { get; set; } = new List<BalanceSheetItemModel> ();
        public float? TotalCapital { get; set; }
    }
}