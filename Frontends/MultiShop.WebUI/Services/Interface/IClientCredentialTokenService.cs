namespace MultiShop.WebUI.Services.Interface
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
