using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Capture
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            serviceService.Create(service);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Service service)
        {
            serviceService.Create(service);
            return Ok();
        }
    }
}