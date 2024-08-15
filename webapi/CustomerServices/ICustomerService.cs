using webapi.Dtos.CustomerDtos;

namespace webapi.CustomerServices
{
    public interface ICustomerService
    {
     
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);

        Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(int id);
        Task<GetByIdCustomerDto> GetByIdCustomersync(int id);

    }
}
