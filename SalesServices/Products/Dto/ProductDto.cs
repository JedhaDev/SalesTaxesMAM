using SalesServices.Taxes.Dto;
using System.Collections.Generic;

namespace SalesServices.Products.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<TaxDto> Taxes { get; set; }

        public decimal TaxAmount { get; set; }
    }
}
