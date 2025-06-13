
using Newtonsoft.Json;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRMessageService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7240/api/usermessage/GetTotalMessageCountByReceiverId?id=" +  id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var messageCount = JsonConvert.DeserializeObject<int>(jsonData);
            return messageCount;
        }
    }
}
