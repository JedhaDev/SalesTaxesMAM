using SalesRepository.Context;
using SalesRepository.Entities;
using SalesRepository.Repositories.Interfaces;

namespace SalesRepository.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

    }
}
