using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entities.Product>>
        {
            public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = new List<Domain.Entities.Product>
                {
                    new Domain.Entities.Product { Name = "Product1", Description = "Description1", Rate = 10.0m },
                    new Domain.Entities.Product { Name = "Product2", Description = "Description2", Rate = 20.0m },
                    new Domain.Entities.Product { Name = "Product3", Description = "Description3", Rate = 30.0m }
                };
                return products;
            }
        }
    }


}
