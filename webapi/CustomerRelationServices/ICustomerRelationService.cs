using webapi.Dtos.CustomerRelationDtos;

namespace webapi.CustomerRelationServices
{
    public interface ICustomerRelationService
    {
        Task CreateCustomerRelationAsync(CreateCustomerRelationDto createCustomerRelationDto);
        Task UpdateCustomerRelationAsync(UpdateCustomerRelationDto updateCustomerRelationDto);
        Task DeleteCustomerRelationAsync(int relationId);
        Task<GetByIdCustomerRelationDto> GetByIdCustomerRelationAsync(int id);
     
    }
}
