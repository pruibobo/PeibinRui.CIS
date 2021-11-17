using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.OpenApi.Any;

namespace ClientInformationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IInteractionService _interactionService;

        public EmployeesController(IEmployeeService employeeService, IInteractionService interactionService)
        {
            _employeeService = employeeService;
            _interactionService = interactionService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetEmployeeList();
            if (employees.Any())
            {
                return Ok(employees);
            }

            return NotFound("Employees Not Found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var emp = await _employeeService.GetEmployeeDetails(id);
            if (emp != null)
            {
                return Ok(emp);
            }

            return NotFound("Employee Not Found");
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestModel model)
        {
            var newEmp = await _employeeService.AddEmployee(model);
            return Ok(newEmp);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeById(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequestModel model)
        {
            var emp = await _employeeService.UpdateEmployeeById(id, model);
            return Ok(emp);
        }

    }
}
