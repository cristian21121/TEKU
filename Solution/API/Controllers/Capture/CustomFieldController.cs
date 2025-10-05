using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Capture
{
    [ApiController]
    [Route("[controller]")]
    public class CustomFieldController : ControllerBase
    {
        private readonly ICustomFieldService customFieldService;

        public CustomFieldController(ICustomFieldService customFieldService)
        {
            this.customFieldService = customFieldService;
        }

        [HttpPost]
        public IActionResult Create(CustomField customField)
        {
            customFieldService.Create(customField);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CustomField customField)
        {
            customFieldService.Update(customField);
            return Ok();
        }
    }
}