namespace Nager.HetznerDns.Models
{
    public enum DnsRecordType
    {
        /// <summary>
        /// Address record
        /// </summary>
        A,
        /// <summary>
        /// IPv6 address record
        /// </summary>
        AAAA,
        /// <summary>
        /// Name server record
        /// </summary>
        NS,
        /// <summary>
        /// Mail exchange record
        /// </summary>
        MX,
        /// <summary>
        /// Canonical name record
        /// </summary>
        CNAME,
        /// <summary>
        /// Responsible Person
        /// </summary>
        RP,
        /// <summary>
        /// Text record
        /// </summary>
        TXT,
        /// <summary>
        /// Start of [a zone of] authority record
        /// </summary>
        SOA,
        /// <summary>
        /// Host Information
        /// </summary>
        HINFO,
        /// <summary>
        /// Service locator
        /// </summary>
        SRV,
        /// <summary>
        /// Delegation name record
        /// </summary>
        DANE,
        /// <summary>
        /// TLSA certificate association
        /// </summary>
        TLSA,
        /// <summary>
        /// Delegation signer
        /// </summary>
        DS,
        /// <summary>
        /// Certification Authority Authorization
        /// </summary>
        CAA
    }
}
