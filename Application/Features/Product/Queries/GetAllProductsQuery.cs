using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = new List<Product>
                {
                    new Product { Name = "Product1", Description = "Description1", Rate = 10.0m },
                    new Product { Name = "Product2", Description = "Description2", Rate = 20.0m },
                    new Product { Name = "Product3", Description = "Description3", Rate = 30.0m }
                };
                return products;
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
