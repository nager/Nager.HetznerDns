# Nager.HetznerDns  

**Nager.HetznerDns** is a lightweight .NET client library for the [Hetzner DNS API](https://dns.hetzner.com/api-docs).  
It allows you to manage DNS zones and records programmatically in C# with minimal effort.  

## ✨ Features  

- 🔑 Simple integration with Hetzner DNS API  
- 🌐 Manage zones and records (create, update, delete, list)  
- ⚡ Strongly typed models for easy usage in .NET projects  
- 🧩 Ready for automation and infrastructure tooling  

## 📦 Installation  

The package is available on **NuGet**:  

```powershell
PM> Install-Package Nager.HetznerDns
````

## 🚀 Usage Example

```csharp
using Nager.HetznerDns;

var apiToken = "your-api-token";
var client = new HetznerDnsClient(apiToken);

// List all zones
var zones = await client.GetZonesAsync();
foreach (var zone in zones)
{
    Console.WriteLine($"{zone.Id} - {zone.Name}");
}

// Create a new DNS record
await client.CreateRecordAsync(new DnsRecord
{
    ZoneId = "zone-id",
    Type = "A",
    Name = "test",
    Value = "192.0.2.123",
    Ttl = 3600
});
```

## 📜 License

This project is licensed under the **MIT License** – free to use, modify, and distribute.
