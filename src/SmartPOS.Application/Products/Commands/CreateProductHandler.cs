using MediatR;
using SmartPOS.Application.Interfaces;
using SmartPOS.Domain.Entities;

namespace SmartPOS.Application.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Description, request.Price);
        await _productRepository.AddProductAsync(product);
        await _productRepository.SaveChanges(); ;

        return product.Id;
    }
}
