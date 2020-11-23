using System;
using System.Collections.Generic;
using System.Text;

namespace Nager.HetznerDns.Models
{
    public class CreateRecord
    {
        public string Name { get; set; }
        public ulong Ttl { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string ZoneId { get; set; }
    }
}
