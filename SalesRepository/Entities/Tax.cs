namespace SalesRepository.Entities
{
    public class Tax : BaseEntity
    {
        public string Name { get; set; }
        public decimal Percent { get; set; }
    }
}
