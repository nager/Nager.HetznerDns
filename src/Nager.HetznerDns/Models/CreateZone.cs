namespace Nager.HetznerDns.Models
{
    public class CreateZone
    {
        public string Name { get; set; }
        /// <summary>
        /// Default TTL for records
        /// </summary>
        public ulong Ttl { get; set; }
    }
}
