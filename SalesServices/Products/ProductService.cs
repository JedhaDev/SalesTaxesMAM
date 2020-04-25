using AutoMapper;
using SalesRepository.Repositories.Interfaces;
using SalesServices.Products.Dto;
using SalesServices.Products.Interfaces;
using SalesServices.Services;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesRepository.Entities;

namespace SalesServices.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ProductDto>> GetProductById(int Id)
        {
            var product = await _productRepository.GetById(Id);

            return ServiceResult<ProductDto>.Success(_mapper.Map<ProductDto>(product));
        }

        public async Task<ServiceResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productRepository.Get()
                                                   .Include(p => p.Taxes)
                                                   .OrderBy(p => p.Name)
                                                   .ToListAsync();

            return ServiceResult<IEnumerable<ProductDto>>.Success(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
    }
}
