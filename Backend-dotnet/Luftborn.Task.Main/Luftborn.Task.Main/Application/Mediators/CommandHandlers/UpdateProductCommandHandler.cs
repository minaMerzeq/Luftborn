using Luftborn.Task.Main.Application.Mediators.Commands;
using Luftborn.Task.Main.Domain.Interfaces;
using Luftborn.Task.Main.Domain.Models;
using MediatR;

namespace Luftborn.Task.Main.Application.Mediators.CommandHandlers
{
    public class UpdateProductCommandHandler(IRepository<Product> repo) : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IRepository<Product> _repo = repo;

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var product = await _repo.GetByIdAsync(dto.Id);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;

            _repo.Update(product);
            return await _repo.SaveChangesAsync();
        }
    }
}
