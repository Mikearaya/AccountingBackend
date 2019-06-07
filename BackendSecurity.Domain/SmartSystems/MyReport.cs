namespace BackendSecurity.Domain.SmartSystems {
    public class MyReport {
        public uint Id { get; set; }
        public string ReportTitle { get; set; }
        public string Description { get; set; }
        public string BaseReport { get; set; }
        public string MyOptions { get; set; }
        public string ReportOwner { get; set; }
        public string ReportStatus { get; set; }
    }
}