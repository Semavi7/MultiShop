
namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var reponseMessage = await _httpClient.GetAsync("comments/GetTotalCommentCount");
            var values = await reponseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
