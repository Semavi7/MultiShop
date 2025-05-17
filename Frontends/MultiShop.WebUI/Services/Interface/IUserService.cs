using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Interface
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
