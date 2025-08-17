using MediatR;

namespace SmartPOS.Application.Products.Commands;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price
) : IRequest<int>;
