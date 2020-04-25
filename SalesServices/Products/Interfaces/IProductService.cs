using SalesServices.Products.Dto;
using SalesServices.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesServices.Products.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult<IEnumerable<ProductDto>>> GetProducts();
        Task<ServiceResult<ProductDto>> GetProductById(int Id);
    }
}
