using SalesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesServices.Taxes.Extensions
{
    public static class TaxExtension
    {
        public static decimal CalculateTaxAmount(this IEnumerable<Tax> taxes, decimal price)
        {
            var result = taxes.Sum(t => price * t.Percent / 100M);
            return result % 0.05M == 0M ? result : Round(result); 
        }

        public static decimal Round(decimal value)
        {
            var ceiling = Math.Ceiling(value * 20);
            if (ceiling == 0)
            {
                return 0;
            }
            return ceiling / 20;
        }
    }
}
