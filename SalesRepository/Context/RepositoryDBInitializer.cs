using SalesRepository.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using SalesRepository.Extensions;

namespace SalesRepository.Context
{
    public class RepositoryDBInitializer : CreateDatabaseIfNotExists<RepositoryContext>
    {
        protected override void Seed(RepositoryContext context)
        {
            base.Seed(context);

            Tax generalTax = new Tax() { Name = "General Tax", Percent = 10M };
            Tax bookTax = new Tax() { Name = "Book Tax", Percent = 0M };
            Tax foodTax = new Tax() { Name = "Food Tax", Percent = 0M };
            Tax medicamentTax = new Tax() { Name = "Medicament Tax", Percent = 0M };
            Tax importedTax = new Tax() { Name = "Imported Tax", Percent = 5M };

            IList<Tax> taxes = new List<Tax>
                {
                    generalTax,
                    bookTax,
                    foodTax,
                    medicamentTax,
                    importedTax
                };
            context.Taxes.AddRange(taxes);

            IList<Product> products = new List<Product>
                {
                    new Product() { Name = "Book", Price = 12.49M, Taxes = new List<Tax> { bookTax.Copy() } },
                    new Product() { Name = "Music CD", Price = 14.99M, Taxes = new List<Tax> { generalTax.Copy() } },
                    new Product() { Name = "Chocolate Bar", Price = 0.85M, Taxes = new List<Tax> { foodTax.Copy() } },
                    new Product() { Name = "Imported box of chocolates", Price = 10.00M, Taxes = new List<Tax> { foodTax.Copy(), importedTax.Copy() } },
                    new Product() { Name = "Imported bottle of perfume", Price = 47.50M, Taxes = new List<Tax> { generalTax.Copy(), importedTax.Copy() } },
                    new Product() { Name = "Imported bottle of perfume 2", Price = 27.99M, Taxes = new List<Tax> { generalTax.Copy(), importedTax.Copy() } },
                    new Product() { Name = "Bottle of perfume", Price = 18.99M, Taxes = new List<Tax> { generalTax.Copy() } },
                    new Product() { Name = "Packet of paracetamol", Price = 9.75M, Taxes = new List<Tax> { medicamentTax.Copy() } },
                    new Product() { Name = "Box of imported chocolates", Price = 11.25M, Taxes = new List<Tax> { foodTax.Copy(), importedTax.Copy() } },

                };
            context.Products.AddRange(products);

            context.SaveChanges();
        }
    }
}
