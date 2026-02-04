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
   
        public class GetProductByIdQuery 
        : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }

    // 👇 SAME FILE me Handler likh do (abhi ke liye)
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
    {
        
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Product> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
        
    


}
