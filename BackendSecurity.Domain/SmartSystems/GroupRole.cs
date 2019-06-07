namespace BackendSecurity.Domain.SmartSystems {
    public class GroupRole {
        public uint Id { get; set; }
        public uint? GroupId { get; set; }
        public string ApplicationName { get; set; }
        public string Page { get; set; }
        public string Event { get; set; }
    }
}