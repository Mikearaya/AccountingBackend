/*
 * @CreateTime: Jun 15, 2019 8:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 15, 2019 9:35 AM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Reports.Models {
    public class SalesSummaryModel {
        System.Globalization.DateTimeFormatInfo mfi;
        public SalesSummaryModel () {
            mfi = new System.Globalization.DateTimeFormatInfo ();
        }

        public int Month { get; set; }
        public decimal? Sales { get; set; }
        public string MonthString {
            get {
                return mfi.GetMonthName (Month).ToString ();
            }
        }

    }
}