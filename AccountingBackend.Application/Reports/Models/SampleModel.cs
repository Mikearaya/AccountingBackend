using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class SampleModel {
        public string AccountName { get; set; }
        public string AccountId { get; set; }
        public Account ParentAccount { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
    }
}