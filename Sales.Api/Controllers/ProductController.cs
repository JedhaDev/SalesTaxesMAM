using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesServices.Products.Dto;
using SalesServices.Products.Interfaces;
using SalesServices.Services;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getProducts")]
        public async Task<ServiceResult<IEnumerable<ProductDto>>> Get()
        {
            return await _productService.GetProducts();
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult<ProductDto>> Get(int Id)
        {
            return await _productService.GetProductById(Id);
        }
    }
}
