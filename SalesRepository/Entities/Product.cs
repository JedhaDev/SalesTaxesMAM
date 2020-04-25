using System.Collections.Generic;

namespace SalesRepository.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Tax> Taxes { get; set; }
    }
}
