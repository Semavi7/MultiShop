using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargodetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoCargoDetailService;

        public CargodetailsController(ICargoDetailService cargoCargoDetailService)
        {
            _cargoCargoDetailService = cargoCargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoCargoDetailList()
        {
            var values = _cargoCargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCargoDetail(CreateCargoDetailDto createCargoCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoCargoDetailDto.Barcode,
                CargoCompanyId = createCargoCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoCargoDetailDto.SenderCustomer,
                SenderCustomer = createCargoCargoDetailDto.SenderCustomer
            };
            _cargoCargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Deayları Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCargoDetail(int id)
        {
            _cargoCargoDetailService.TDelete(id);
            return Ok("Kargo Detayları Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCargoDetailById(int id)
        {
            var values = _cargoCargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCargoDetail(UpdateCargoDetailDto updateCargoCargoDetailDto)
        {
            CargoDetail updatedCargoCargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoCargoDetailDto.CargoDetailId,
                Barcode = updateCargoCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoCargoDetailDto.SenderCustomer
            };
            _cargoCargoDetailService.TUpdate(updatedCargoCargoDetail);
            return Ok("Kargo Detayları Başarıyla Güncellendi");
        }
    }
}
