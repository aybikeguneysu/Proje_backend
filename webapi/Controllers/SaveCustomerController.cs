//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using webapi.Models;
//using webapi.Data;
//using System.ComponentModel.DataAnnotations;

//namespace webapi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class SaveCustomerController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public SaveCustomerController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost("SaveCustomer")]
//        public async Task<IActionResult> SaveCustomer([FromBody] CustomerDTO customerDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var customer = new Customer
//            {
//                CustomerName = customerDto.CustomerName,
//                CustomerLastName = customerDto.CustomerLastName,
//                CustomerType = customerDto.CustomerType,
//                NetIncomeAmount = customerDto.NetIncomeAmount,
//                Jobs = customerDto.Job.Select(j => new CustomerJob
//                {
//                    CompanyName = j.CompanyName,
//                    StartDate = j.StartDate,
//                    EndDate = j.EndDate,
//                    Position = j.Position,
//                    Salary = j.Salary
//                }).ToList(),
//                Relations = customerDto.Relation.Select(r => new CustomerRelation
//                {
//                    RelationName = r.RelationName,
//                    RelatedPersonName = r.RelatedPersonName
//                }).ToList()
//            };

//            _context.Customer.Add(customer);
//            await _context.SaveChangesAsync();

//            return Ok("Customer has been saved successfully.");
//        }
//    }

//    public class CustomerDTO
//    {
//        [Required]
//        public string CustomerName { get; set; }

//        [Required]
//        public string CustomerLastName { get; set; }

//        public string CustomerType { get; set; }

//        [Range(0, double.MaxValue)]
//        public decimal NetIncomeAmount { get; set; }

//        public List<CustomerJobDTO> Job { get; set; } = new List<CustomerJobDTO>();
//        public List<CustomerRelationDTO> Relation { get; set; } = new List<CustomerRelationDTO>();
//    }

//    public class CustomerJobDTO
//    {
//        [Required]
//        public string CompanyName { get; set; }

//        public DateTime StartDate { get; set; }
//        public DateTime? EndDate { get; set; }

//        public string Position { get; set; }

//        [Range(0, double.MaxValue)]
//        public decimal Salary { get; set; }
//    }

//    public class CustomerRelationDTO
//    {
//        public string RelationName { get; set; }
//        public string RelatedPersonName { get; set; }
//    }
//}
