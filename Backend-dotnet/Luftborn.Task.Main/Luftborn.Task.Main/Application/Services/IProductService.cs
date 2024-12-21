using Luftborn.Task.Main.Domain.Dtos;

namespace Luftborn.Task.Main.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
    }
}
