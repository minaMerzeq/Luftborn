using Luftborn.Task.Main.Application.Mediators.Commands;
using Luftborn.Task.Main.Domain.Interfaces;
using Luftborn.Task.Main.Domain.Models;
using MediatR;

namespace Luftborn.Task.Main.Application.Mediators.CommandHandlers
{
    public class AddProductCommandHandler(IRepository<Product> repo) : IRequestHandler<AddProductCommand, int>
    {
        private readonly IRepository<Product> _repo = repo;

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description
            };

            _repo.Add(product);
            await _repo.SaveChangesAsync();

            return product.Id;
        }
    }
}
