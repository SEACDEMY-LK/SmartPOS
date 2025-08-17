using MediatR;
using SmartPOS.Application.DTOs;

namespace SmartPOS.Application.Products.Queries.Definitions;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDTO>>
{
}
