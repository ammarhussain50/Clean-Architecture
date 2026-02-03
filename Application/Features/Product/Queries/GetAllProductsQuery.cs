using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
   
        public class GetAllProductsQuery 
        : IRequest<IEnumerable<Domain.Entities.Product>>
    {
    }

    // 👇 SAME FILE me Handler likh do (abhi ke liye)
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
        
    


}
