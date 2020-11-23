using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Nager.HetznerDns.Models;
using System.Threading;

namespace Nager.HetznerDns
{
    public partial class HetznerDnsClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _disposeHttpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public HetznerDnsClient(
            string authApiToken,
            string baseUrl = "https://dns.hetzner.com/api/",
            HttpClient httpClient = default)
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                this._disposeHttpClient = true;
            }

            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Add("Auth-API-Token", authApiToken);

            this._httpClient = httpClient;

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            this._jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposeHttpClient)
            {
                return;
            }
            this._httpClient.Dispose();
        }

        public async Task<ZoneResponse> GetZonesAsync(CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.GetAsync("v1/zones", cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                throw new HttpException($"{responseMessage.IsSuccessStatusCode} {errorMessage}");
            }

            var json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ZoneResponse>(json, this._jsonSerializerSettings);
        }

        public async Task<RecordResponse> GetRecordsAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.GetAsync($"v1/records?zone_id={zoneId}", cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                throw new HttpException($"{responseMessage.IsSuccessStatusCode} {errorMessage}");
            }

            var json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RecordResponse>(json, this._jsonSerializerSettings);
        }

        public async Task DeleteRecordAsync(string recordId, CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.DeleteAsync($"v1/records/{recordId}", cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                throw new HttpException($"{responseMessage.IsSuccessStatusCode} {errorMessage}");
            }
        }

        public async Task CreateRecordAsync(CreateRecord record, CancellationToken cancellationToken = default)
        {
            var json = JsonConvert.SerializeObject(record, this._jsonSerializerSettings);

            var responseMessage = await this._httpClient.PostAsync($"v1/records", new StringContent(json), cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                throw new HttpException($"{responseMessage.IsSuccessStatusCode} {errorMessage}");
            }
        }
    }
}
