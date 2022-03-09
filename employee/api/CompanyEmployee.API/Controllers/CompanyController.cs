namespace CompanyEmployee.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using CompanyEmployee.Services.Models;
    using CompanyEmployee.Services.Contracts;
    using CompanyEmployee.API.Infrastructure.Extensions;
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(AllCompanyModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
            => this.OkOrNotFound(await companyService.All());

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [ProducesResponseType(200, Type = typeof(AllCompanyModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
           => this.OkOrNotFound(await companyService.Details(id));


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AllCompanyModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] AllCompanyModel model)
        {
            await companyService.Create(model);
            return Ok();
        }
    }
}
