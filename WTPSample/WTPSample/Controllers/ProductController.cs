using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WTPSample.Requests;
using WTPSample.Service.Contracts;
using WTPSample.Service.DTOs;

namespace WTPSample.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id:int}")]
        public async Task<ResultEmployee> Get(int id)
        {
            var data = await _productService.GetEmployee(id);
            return data;
        }
        [HttpPost]
        public async Task Post([FromBody] ProductRequest request)
        {
            var productDto = new ProductDto
            {
                Name = request.Name
            };
            try
            {
                await _productService.CreateProductAsync(productDto);
            }
            catch (System.Exception ex)
            {
               throw ex;
            }
        }
    }
}