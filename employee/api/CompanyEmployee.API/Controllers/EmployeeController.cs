namespace CompanyEmployee.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using CompanyEmployee.API.Infrastructure.Extensions;
    using CompanyEmployee.API.Infrastructure.Filters;
    using CompanyEmployee.Services.Contracts;
    using CompanyEmployee.Services.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(200, Type = typeof(EmployeeRequestModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] EmployeeRequestModel model)
        {
            await employeeService.Create(model);
            return Ok(model.EmployeeId);
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
            => this.OkOrNotFound(await employeeService.AllEmployees());

        [HttpGet]
        [Route("{id:long:min(1)}")]
        [ProducesResponseType(201, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmployees(long id)
            => this.OkOrNotFound(await employeeService.GetEmployee(id));

        [HttpDelete("{id:long:min(1)}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(long id)
        {
            var employeeExist = await employeeService.Exists(id);
            if (!employeeExist)
            {
                return NotFound("Employee does not exist.");
            }

            await employeeService.Delete(id);
            return Ok();
        }

        [HttpPut("{id:long:min(1)}")]
        [ValidateModelState]
        [ProducesResponseType(200, Type = typeof(EmployeeRequestModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeUpdateRequestModel model)
        {
            var employeeExists = await employeeService.Exists(id);
            if (!employeeExists)
            {
                return NotFound("Employee does not exist");
            }

            await employeeService.Update(model);
            return Ok();
        }
    }
}
