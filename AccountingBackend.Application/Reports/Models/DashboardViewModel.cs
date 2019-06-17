/*
 * @CreateTime: May 25, 2019 4:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 15, 2019 8:37 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace AccountingBackend.Application.Reports.Models {
    public class DashboardViewModel {
        public decimal? TotalAssets { get; set; }
        public decimal? TotalLiability { get; set; }
        public decimal? TotalCapital { get; set; }
        public decimal? TotalExpense { get; set; }
        public decimal? TotalRevenue { get; set; }
        public int UnpostedEntries { get; set; }

        public IList<SalesSummaryModel> SalesSummert { get; set; } = new List<SalesSummaryModel> ();
    }
}