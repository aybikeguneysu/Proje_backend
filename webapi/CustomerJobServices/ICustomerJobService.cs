using webapi.Dtos.CustomerJobDtos;

namespace webapi.CustomerJobServices
{
    public interface ICustomerJobService
    {
        Task CreateCustomerJobAsync(CreateCustomerJobDto createCustomerJobDto);
        Task UpdateCustomerJobAsync(UpdateCustomerJobDto updateCustomerJobDto);
        Task DeleteCustomerJobAsync(int jobId);
        Task<GetByIdCustomerJobDto> GetByIdCustomerJobAsync(int id);
       
    }
}
