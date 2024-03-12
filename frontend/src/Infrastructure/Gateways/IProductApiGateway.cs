using Domain.Dtos.Products;
using Refit;

namespace Infrastructure.Gateways;

public interface IProductApiGateway
{
    [Get("/Products")]
    Task<IEnumerable<ResponseProductDto>> GetAllAsync();

    [Get("/Products/{id}")]
    Task<ResponseProductDto> GetByIdAsync(Guid id);

    [Post("/Products")]
    Task CreateAsync([Body] RequestProductDto dto);

    [Put("/Products/{id}")]
    Task UpdateAsync(Guid id, [Body] RequestProductDto dto);

    [Delete("/Products")]
    Task DeleteAsync(Guid id);

}
