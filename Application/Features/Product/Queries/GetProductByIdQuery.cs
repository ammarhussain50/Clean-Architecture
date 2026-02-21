using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
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
        : IRequest<ApiResponse<Domain.Entities.Product>>
    {
        public int Id { get; set; }
    }

    // 👇 SAME FILE me Handler likh do (abhi ke liye)
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, ApiResponse<Domain.Entities.Product>>
    {
        
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Domain.Entities.Product>> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _context.Products
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (result == null) { 
                throw new ApiException($"Product with Id {request.Id} not found.");
            }

            return new ApiResponse<Domain.Entities.Product>(result,"Data fetched succesfully");
        }
    }
        
    


}
