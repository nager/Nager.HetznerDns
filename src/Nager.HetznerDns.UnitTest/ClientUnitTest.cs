using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.HetznerDns.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Nager.HetznerDns.UnitTest
{
    [TestClass]
    public class ClientUnitTest
    {
        private readonly string _apiKey = "";

        [TestMethod]
        public async Task GetZonesAsync()
        {
            var client = new HetznerDnsClient(this._apiKey);
            var response = await client.GetZonesAsync();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetRecordsAsync()
        {
            var client = new HetznerDnsClient(this._apiKey);
            var zoneResponse = await client.GetZonesAsync();
            var zoneId = zoneResponse.Zones.FirstOrDefault()?.Id;

            var response = await client.GetRecordsAsync(zoneId);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task CreateRecordAsync()
        {
            var client = new HetznerDnsClient(this._apiKey);
            var zoneResponse = await client.GetZonesAsync();
            Assert.IsNotNull(zoneResponse);
            var zoneId = zoneResponse.Zones.FirstOrDefault()?.Id;

            var record = new CreateRecord()
            {
                Name = "_acme-challenge.test",
                Type = "TXT",
                Value = "testest",
                Ttl = 0,
                ZoneId = zoneId
            };

            await client.CreateRecordAsync(record);
        }

        [TestMethod]
        public async Task DeleteRecordAsync()
        {
            var client = new HetznerDnsClient(this._apiKey);
            var zoneResponse = await client.GetZonesAsync();
            var zoneId = zoneResponse.Zones.FirstOrDefault()?.Id;

            var recordResponse = await client.GetRecordsAsync(zoneId);
            Assert.IsNotNull(recordResponse);

            var txtRecords = recordResponse.Records.Where(o => o.Type == "TXT" && o.Name.StartsWith("_acme-challenge")).ToList();
            await client.DeleteRecordAsync(txtRecords.FirstOrDefault()?.Id);
        }
    }
}
