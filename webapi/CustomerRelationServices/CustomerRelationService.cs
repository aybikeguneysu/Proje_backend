using webapi.Data;
using webapi.Dtos.CustomerRelationDtos;
using webapi.Models;

namespace webapi.CustomerRelationServices
{
    public class CustomerRelationService : ICustomerRelationService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRelationService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateCustomerRelationAsync(CreateCustomerRelationDto createCustomerRelationDto)
        {
            var customerRelation = new CustomerRelation
            {
                CustomerID = createCustomerRelationDto.CustomerID,
                RelationName = createCustomerRelationDto.RelationName,
                RelatedPersonName = createCustomerRelationDto.RelatedPersonName
            };

            await _applicationDbContext.CustomerRelation.AddAsync(customerRelation);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerRelationAsync(int relationId)
        {
            var customerRelation = await _applicationDbContext.CustomerRelation.FindAsync(relationId);
            if (customerRelation != null)
            {
                _applicationDbContext.CustomerRelation.Remove(customerRelation);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("CustomerRelation not found");
            }
        }

        public async Task<GetByIdCustomerRelationDto> GetByIdCustomerRelationAsync(int id)
        {
            var customerRelation = await _applicationDbContext.CustomerRelation.FindAsync(id);
            if (customerRelation == null)
            {
                throw new ArgumentException("CustomerRelation not found");
            }

            return new GetByIdCustomerRelationDto
            {
                RelationID = customerRelation.RelationID,
                CustomerID = customerRelation.CustomerID,
                RelationName = customerRelation.RelationName,
                RelatedPersonName = customerRelation.RelatedPersonName
            };
        }

        public async Task UpdateCustomerRelationAsync(UpdateCustomerRelationDto updateCustomerRelationDto)
        {
            var customerRelation = await _applicationDbContext.CustomerRelation.FindAsync(updateCustomerRelationDto.RelationID);
            if (customerRelation != null)
            {
                customerRelation.CustomerID = updateCustomerRelationDto.CustomerID;
                customerRelation.RelationName = updateCustomerRelationDto.RelationName;
                customerRelation.RelatedPersonName = updateCustomerRelationDto.RelatedPersonName;

                _applicationDbContext.CustomerRelation.Update(customerRelation);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("CustomerRelation not found");
            }
        }
    }
}
