using webapi.Data;
using webapi.Dtos.CustomerDtos;
using webapi.Models;

namespace webapi.CustomerServices
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer
            {
                CustomerType = createCustomerDto.CustomerType,
                IDNumber = createCustomerDto.IDNumber,            
                CustomerName = createCustomerDto.CustomerName,
                CustomerLastName = createCustomerDto.CustomerLastName,
                NetIncomeAmount = createCustomerDto.NetIncomeAmount
               
            };
            await  _applicationDbContext.Customer.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();
         
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _applicationDbContext.Customer.FindAsync(id);
          
            _applicationDbContext.Customer.Remove(customer);
            await _applicationDbContext.SaveChangesAsync();
           
            
        }

        public async  Task<GetByIdCustomerDto> GetByIdCustomersync(int id)
        {
            var customer = await _applicationDbContext.Customer.FindAsync(id);
            

            return new GetByIdCustomerDto
            {
                CustomerID = customer.CustomerID,
                CustomerType = customer.CustomerType,
                IDNumber = customer.IDNumber,
                CustomerName = customer.CustomerName,
                CustomerLastName = customer.CustomerLastName,
                NetIncomeAmount = customer.NetIncomeAmount
            };
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var customer = await _applicationDbContext.Customer.FindAsync(updateCustomerDto.CustomerID);
           
             customer.CustomerType = updateCustomerDto.CustomerType;
             customer.IDNumber = updateCustomerDto.IDNumber;
             customer.CustomerName = updateCustomerDto.CustomerName;
             customer.CustomerLastName = updateCustomerDto.CustomerLastName;
             customer.NetIncomeAmount = updateCustomerDto.NetIncomeAmount;

             _applicationDbContext.Customer.Update(customer);
             await _applicationDbContext.SaveChangesAsync();
            
        }
    }
}
