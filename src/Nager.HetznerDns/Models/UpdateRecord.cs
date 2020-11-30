using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nager.HetznerDns.Models
{
    public class UpdateRecord
    {
        public string ZoneId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DnsRecordType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ulong Ttl { get; set; }
    }
}
