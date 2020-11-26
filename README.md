# Nager.HetznerDns

Client for the DNS Api of Hetzner https://dns.hetzner.com/api-docs

## nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.HetznerDns)
```
PM> install-package Nager.HetznerDns
```
## Examples for .NET (nuget package)

### Get all records of a zone
```cs
var client = new HetznerDnsClient("apiKey");
var response = await client.GetRecordsAsync("zoneId");
```
