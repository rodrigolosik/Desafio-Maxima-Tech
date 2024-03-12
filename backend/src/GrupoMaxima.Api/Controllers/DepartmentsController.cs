using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GrupoMaxima.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentsService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentsService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Department))]
        public async Task<IActionResult> Get()
        {
            var departments = await _departmentsService.ListAllAsync();

            return Ok(departments);
        }

    }
}
