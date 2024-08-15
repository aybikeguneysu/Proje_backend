using webapi.Data;
using webapi.Dtos.CustomerJobDtos;
using webapi.Models;

namespace webapi.CustomerJobServices
{
    public class CustomerJobService : ICustomerJobService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerJobService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateCustomerJobAsync(CreateCustomerJobDto createCustomerJobDto)
        {
            var customerJob = new CustomerJob
            {
                CustomerID = createCustomerJobDto.CustomerID,
                CompanyName = createCustomerJobDto.CompanyName,
                StartDate = createCustomerJobDto.StartDate,
                EndDate = createCustomerJobDto.EndDate,
                Position = createCustomerJobDto.Position,
                Salary = createCustomerJobDto.Salary
            };

            await _applicationDbContext.CustomerJob.AddAsync(customerJob);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerJobAsync(int jobId)
        {
            var customerJob = await _applicationDbContext.CustomerJob.FindAsync(jobId);
            if (customerJob != null)
            {
                _applicationDbContext.CustomerJob.Remove(customerJob);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("CustomerJob not found");
            }
        }

        public async Task<GetByIdCustomerJobDto> GetByIdCustomerJobAsync(int id)
        {
            var customerJob = await _applicationDbContext.CustomerJob.FindAsync(id);
            if (customerJob == null)
            {
                throw new ArgumentException("CustomerJob not found");
            }

            return new GetByIdCustomerJobDto
            {
                JobID = customerJob.JobID,
                CustomerID = customerJob.CustomerID,
                CompanyName = customerJob.CompanyName,
                StartDate = customerJob.StartDate,
                EndDate = customerJob.EndDate,
                Position = customerJob.Position,
                Salary = customerJob.Salary
            };
        }

        public async Task UpdateCustomerJobAsync(UpdateCustomerJobDto updateCustomerJobDto)
        {
            var customerJob = await _applicationDbContext.CustomerJob.FindAsync(updateCustomerJobDto.JobID);
            if (customerJob != null)
            {
                customerJob.CustomerID = updateCustomerJobDto.CustomerID;
                customerJob.CompanyName = updateCustomerJobDto.CompanyName;
                customerJob.StartDate = updateCustomerJobDto.StartDate;
                customerJob.EndDate = updateCustomerJobDto.EndDate;
                customerJob.Position = updateCustomerJobDto.Position;
                customerJob.Salary = updateCustomerJobDto.Salary;

                _applicationDbContext.CustomerJob.Update(customerJob);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("CustomerJob not found");
            }
        }
    }
}
