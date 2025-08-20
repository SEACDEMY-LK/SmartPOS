using MediatR;
using SmartPOS.Application.DTOs;

namespace SmartPOS.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDTO>>
{
}
