using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if(createRegisterDto.Password == createRegisterDto.ConfirmPassword)
            {
                var userRegisterDto = new UserRegisterDto
                {
                    Username = createRegisterDto.Username,
                    Email = createRegisterDto.Email,
                    Name = createRegisterDto.Name,
                    Surname = createRegisterDto.Surname,
                    Password = createRegisterDto.Password
                };
                var client = _httpClientFactory.CreateClient();
                var jsondata = JsonConvert.SerializeObject(userRegisterDto);
                StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

    }
}
