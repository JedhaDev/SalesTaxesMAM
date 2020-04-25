using AutoMapper;
using SalesRepository.Entities;
using SalesServices.Products.Dto;
using SalesServices.Taxes.Dto;
using SalesServices.Taxes.Extensions;
using System.Linq;

namespace SalesServices.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Tax, TaxDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Taxes, opt =>opt.MapFrom(src => src.Taxes.OrderBy(t => t.Name)))
                .ForMember(dest => dest.TaxAmount, opt => opt.MapFrom(src => src.Taxes.CalculateTaxAmount(src.Price)));
        }
    }
}
