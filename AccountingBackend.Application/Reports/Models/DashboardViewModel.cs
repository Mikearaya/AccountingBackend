/*
 * @CreateTime: May 25, 2019 4:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 25, 2019 5:25 PM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Reports.Models {
    public class DashboardViewModel {
        public decimal? TotalAssets { get; set; }
        public decimal? TotalLiability { get; set; }
        public decimal? TotalCapital { get; set; }
        public decimal? TotalExpense { get; set; }
        public decimal? TotalRevenue { get; set; }
    }
}