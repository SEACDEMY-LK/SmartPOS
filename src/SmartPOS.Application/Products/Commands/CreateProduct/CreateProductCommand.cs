using MediatR;

namespace SmartPOS.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price
) : IRequest<int>;
