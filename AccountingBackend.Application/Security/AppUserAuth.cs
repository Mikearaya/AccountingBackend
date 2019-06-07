namespace AccountingBackend.Application.Security {
    public class AppUserAuth {
        public AppUserAuth () : base () {
            UserName = "Not Authorized";
            BearerToken = string.Empty;

        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool CanViewLedgerEntry { get; set; }
        public bool CanAddLedgerEntry { get; set; }
        public bool CanUpdateLedgerEntry { get; set; }
        public bool CanDeleteLedgerEntry { get; set; }

    }
}