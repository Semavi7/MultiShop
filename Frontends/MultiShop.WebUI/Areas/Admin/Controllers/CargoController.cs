using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoComponyDtos;
using MultiShop.WebUI.Services.Cargoservices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/About")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        void CargoCompanyViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kargo";
            ViewBag.v3 = "Kargo Firmaları Listesi";
            ViewBag.v4 = "Kargo Firmaları İşlemleri";
        }

        //[Route("Index")]
        public async Task<IActionResult> CargoCompanyList()
        {
            CargoCompanyViewBagList();
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }

        [HttpGet]
        //[Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            CargoCompanyViewBagList();
            return View();
        }

        [HttpPost]
        //[Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });

        }

        //[Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        //[Route("UpdateCargoCompany/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            CargoCompanyViewBagList();
            var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(values);
        }

        [HttpPost]
        //[Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
    }
}
