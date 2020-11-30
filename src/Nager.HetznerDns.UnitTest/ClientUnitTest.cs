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

            var record = new CreateRecord
            {
                ZoneId = zoneId,
                Name = "_acme-challenge.unittest",
                Type = DnsRecordType.TXT,
                Value = "testest",
                Ttl = 0
            };

            var createdRecord = await client.CreateRecordAsync(record);
            Assert.IsNotNull(createdRecord);
        }

        [TestMethod]
        public async Task UpdateRecordAsync()
        {
            var client = new HetznerDnsClient(this._apiKey);
            var zoneResponse = await client.GetZonesAsync();
            Assert.IsNotNull(zoneResponse);
            var zoneId = zoneResponse.Zones.FirstOrDefault()?.Id;

            var createRecord = new CreateRecord
            {
                ZoneId = zoneId,
                Name = "_acme-challenge.unittest",
                Type = DnsRecordType.TXT,
                Value = "testest",
                Ttl = 0
            };

            var createdRecord = await client.CreateRecordAsync(createRecord);
            Assert.IsNotNull(createdRecord);

            var updateRecord = new UpdateRecord
            {
                ZoneId = createRecord.ZoneId,
                Type = DnsRecordType.TXT,
                Name = createRecord.Name,
                Value = "update-record",
                Ttl = 10,
            };

            var updatedRecord = await client.UpdateRecordAsync(createdRecord.Id, updateRecord);
            Assert.IsNotNull(updatedRecord);
        }

        [TestMethod]
        public async Task DeleteRecordAsync()
        {
            var client = new HetznerDnsClient(this._apiKey);
            var zoneResponse = await client.GetZonesAsync();
            var zoneId = zoneResponse.Zones.FirstOrDefault()?.Id;

            var recordResponse = await client.GetRecordsAsync(zoneId);
            Assert.IsNotNull(recordResponse);

            var txtRecords = recordResponse.Records.Where(o => o.Type == DnsRecordType.TXT && o.Name.StartsWith("_acme-challenge")).ToList();
            var txtRecordId = txtRecords.FirstOrDefault()?.Id;
            Assert.IsNotNull(txtRecordId);

            await client.DeleteRecordAsync(txtRecordId);
        }
    }
}
