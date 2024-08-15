using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static webapi.Controllers.Controller;
using System.ComponentModel.DataAnnotations;
using webapi.Data;
using webapi.CustomerServices;
using webapi.Dtos.CustomerDtos;
using webapi.CustomerRelationServices;
using webapi.Dtos.CustomerRelationDtos;
using webapi.CustomerJobServices;
using webapi.Dtos.CustomerJobDtos;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{

    private readonly ApplicationDbContext _context;
    private readonly ICustomerService _customerService;
    private readonly ICustomerRelationService _customerRelationService;
    private readonly ICustomerJobService _customerJobService;
    public Controller(ApplicationDbContext context, ICustomerService customerService, ICustomerRelationService customerRelationService, ICustomerJobService customerJobService)
    {
        _context = context;
        _customerService = customerService;
        _customerRelationService = customerRelationService;
        _customerJobService = customerJobService;
    }

    [HttpPost("PostCustomers")]
    public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        await _customerService.CreateCustomerAsync(createCustomerDto);
        return Ok("Çalýþanlar baþarý ile eklendi");
    }
    [HttpDelete("DeleteCustomer/{customerId}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        
        await _customerService.DeleteCustomerAsync(customerId);
        return Ok("Müþteri baþarý ile silindi");
       
       
    }
    [HttpPut("UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
    {
       
         await _customerService.UpdateCustomerAsync(updateCustomerDto);
         return Ok("Müþteri baþarý ile güncellendi");
      
       
    }
    [HttpGet("GetCustomerById/{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {       
        var customer = await _customerService.GetByIdCustomersync(id);
        return Ok(customer);     
       
    }


    [HttpGet("GetCustomers")]
    public async Task<ActionResult<IEnumerable<object>>> GetCustomers()
    {
        var result = await _context.Customer
            .Select(c => new
            {
                c.CustomerID,
                c.IDNumber,
                c.CustomerName,
                c.CustomerLastName,
                c.CustomerType,
                c.NetIncomeAmount
            })
            .ToListAsync();

        return Ok(result);
    }


    [HttpPost("CreateCustomerJob")]
    public async Task<IActionResult> CreateCustomerJob(CreateCustomerJobDto createCustomerJobDto)
    {
        try
        {
            await _customerJobService.CreateCustomerJobAsync(createCustomerJobDto);
            return Ok("Müþteri iþi baþarý ile eklendi");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("UpdateCustomerJob")]
    public async Task<IActionResult> UpdateCustomerJob(UpdateCustomerJobDto updateCustomerJobDto)
    {
        try
        {
            await _customerJobService.UpdateCustomerJobAsync(updateCustomerJobDto);
            return Ok("Müþteri iþi baþarý ile güncellendi");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("DeleteCustomerJob/{jobId}")]
    public async Task<IActionResult> DeleteCustomerJob(int jobId)
    {
        try
        {
            await _customerJobService.DeleteCustomerJobAsync(jobId);
            return Ok("Müþteri iþi baþarý ile silindi");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetCustomerJobById/{id}")]
    public async Task<IActionResult> GetCustomerJobById(int id)
    {
        try
        {
            var customerJob = await _customerJobService.GetByIdCustomerJobAsync(id);
            return Ok(customerJob);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet("GetCustomerJob")]

    public async Task<ActionResult<IEnumerable<object>>> GetCustomerJob()
    {
        var result = await _context.CustomerJob
            .Select(c => new
            {
                c.JobID,
                c.CustomerID,
                c.CompanyName,
                c.StartDate,
                c.EndDate,
                c.Position,
                c.Salary
            })
            .ToListAsync();

        return Ok(result);
    }


    [HttpPost("PostCustomerRelations")]
    public async Task<IActionResult> CreateCustomerRelation(CreateCustomerRelationDto createCustomerRelationDto)
    {
        await _customerRelationService.CreateCustomerRelationAsync(createCustomerRelationDto);
        return Ok("Müþteri iliþkisi baþarý ile eklendi");
    }

    [HttpPut("UpdateCustomerRelation")]
    public async Task<IActionResult> UpdateCustomerRelation(UpdateCustomerRelationDto updateCustomerRelationDto)
    {
        try
        {
            await _customerRelationService.UpdateCustomerRelationAsync(updateCustomerRelationDto);
            return Ok("Müþteri iliþkisi baþarý ile güncellendi");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("DeleteCustomerRelation/{relationId}")]
    public async Task<IActionResult> DeleteCustomerRelation(int relationId)
    {
        try
        {
            await _customerRelationService.DeleteCustomerRelationAsync(relationId);
            return Ok("Müþteri iliþkisi baþarý ile silindi");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetCustomerRelationById/{id}")]
    public async Task<IActionResult> GetCustomerRelationById(int id)
    {
        try
        {
            var customerRelation = await _customerRelationService.GetByIdCustomerRelationAsync(id);
            return Ok(customerRelation);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetCustomerRelation")]
    public async Task<ActionResult<IEnumerable<object>>> GetCustomerRelation()
    {
        var result = await _context.CustomerRelation
            .Select(c => new
            {
                c.RelationID,
                c.CustomerID,
                c.RelationName,
                c.RelatedPersonName
            })
            .ToListAsync();

        return Ok(result);
    }



}

