using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Services.Interfaces;

public interface IProducService
{
    Task<IResponseResult<IEnumerable<ProductDTO>>> GetAllAsync();
    Task<IResponseResult<ProductDTO>> GetByIdAsync(Guid id);
    Task<ResponseResult> AddAsync(ProductDTO dto);
    Task<ResponseResult> DeleteAsync(Guid id);
    Task<ResponseResult> UpdateAsync(ProductDTO dto);
}
