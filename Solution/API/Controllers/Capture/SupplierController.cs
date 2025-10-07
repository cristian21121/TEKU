using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Capture
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly ISupplierRepository supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository, ISupplierService supplierService)
        {
            this.supplierService = supplierService;
            this.supplierRepository = supplierRepository;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetList()
        {
            return Ok(supplierRepository.GetList());
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(Supplier supplier)
        {
            supplierService.Create(supplier);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update(Supplier supplier)
        {
            supplierService.Update(supplier);
            return Ok();
        }
    }
}