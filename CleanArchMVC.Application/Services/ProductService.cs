using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using MediatR;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            GetProductsQuery productsQuery = new GetProductsQuery()
                ?? throw new ApplicationException("Entity could not be found");

            IEnumerable<Product> result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            GetProductByIdQuery productByIdQuery = new GetProductByIdQuery(id.Value)
                                                   ?? throw new ApplicationException("Entity could not be found");

            Product result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    GetProductByIdQuery productByIdQuery = new GetProductByIdQuery(id.Value)
        //                                           ?? throw new ApplicationException("Entity could not be found");

        //    Product result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task AddSync(ProductDTO productDTO)
        {
            ProductCreateCommand productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateSync(ProductDTO productDTO)
        {
            ProductUpdateCommand productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task CreateSync(int? id)
        {
            ProductRemoveCommand productRemoveCommand = new ProductRemoveCommand(id.Value)
                                                        ?? throw new ApplicationException("Entity could not found");

            await _mediator.Send(productRemoveCommand);
        }
    }
}