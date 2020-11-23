namespace Nager.HetznerDns.Models
{
    public class Record
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string ZoneId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ulong Ttl { get; set; }
    }
}
