using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        //Task<List<ResultAddressDto>> GetAllAddressAsync();
        Task CreateAddressAsync(CreateAddressDto createAddressDto);
        //Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
        //Task DeleteAddressAsync(string id);
        //Task<UpdateAddressDto> GetByIdAddressAsync(string id);
    }
}
