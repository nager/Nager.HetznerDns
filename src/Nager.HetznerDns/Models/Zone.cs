namespace Nager.HetznerDns.Models
{
    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Ttl { get; set; }
        public string Registrar { get; set; }
        public string LegacyDnsHost { get; set; }
        public string[] LegacyNs { get; set; }
        public string[] Ns { get; set; }
        public string Created { get; set; }
        public string Verified { get; set; }
        public string Modified { get; set; }
        public string Project { get; set; }
        public string Owner { get; set; }
        public string Permission { get; set; }
        public ZoneType ZoneType { get; set; }
        public string Status { get; set; }
        public bool Paused { get; set; }
        public bool IsSecondaryDns { get; set; }
        public TxtVerification TxtVerification { get; set; }
        public int RecordsCount { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Name}";
        }
    }
}
