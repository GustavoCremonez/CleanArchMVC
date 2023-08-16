using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name,
                                  request.Description,
                                  request.Price,
                                  request.Stock,
                                  request.Image);

            if (product == null) throw new ApplicationException("Error creating entity");

            product.CategoryId = request.CategoryId;
            return await _productRepository.CreateAsync(product);
        }
    }
}