using Luftborn.Task.Main.Application.Strategies;
using Luftborn.Task.Main.Domain.Dtos;
using Luftborn.Task.Main.Domain.Interfaces;
using Luftborn.Task.Main.Domain.Models;

namespace Luftborn.Task.Main.Application.Services
{
    public class ProductService(IRepository<Product> repository, IDiscountStrategy discountStrategy) : IProductService
    {
        private readonly IRepository<Product> _repository = repository;
        private readonly IDiscountStrategy _discountStrategy = discountStrategy;

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = _discountStrategy.ApplyDiscount(p.Price)
            }).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = _discountStrategy.ApplyDiscount(product.Price)
            };
        }
    }
}
