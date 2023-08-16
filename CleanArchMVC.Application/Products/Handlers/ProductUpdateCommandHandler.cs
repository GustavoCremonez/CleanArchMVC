using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Entity could not be found");

            product.Update(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Image,
                request.CategoryId);

            return await _productRepository.UpdateAsync(product);
        }
    }
}