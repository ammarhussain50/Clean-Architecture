using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<ApiResponse<int>>
    {
        public string Name { get; set; }
        public string remarks { get; set; }
        public decimal Rate { get; set; }


        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<int>>
        {
            private readonly IMapper _mapper;

            private readonly IApplicationDbContext _context;
            private readonly IAuthenticatedUser _authenticatedUser;

            public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper, IAuthenticatedUser authenticatedUser)
            {
                _context = context;
                _mapper = mapper;
                _authenticatedUser = authenticatedUser;
            }
            public async Task<ApiResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                //var product = new Domain.Entities.Product
                //{
                //    Name = request.Name,
                //    Description = request.Description,
                //    Rate = request.Rate
                //};
                product.CreatedBy = _authenticatedUser.UserId;
                product.CreatedOn = DateTime.Now;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return new ApiResponse<int>(product.Id, "Product created successfuly");
            }
        }
    }
}
