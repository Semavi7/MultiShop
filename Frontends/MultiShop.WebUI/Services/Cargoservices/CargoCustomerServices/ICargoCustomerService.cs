using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.Cargoservices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
