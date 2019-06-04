namespace AccountingBackend.Application.Reports.Models {
    public class AccountScheduleDetailModel {
        public string SubsidaryId { get; set; }
        public string Subsidary { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public decimal? EndingBalance { get; set; }
        public decimal? BeginingBalance { get; set; }
    }
}