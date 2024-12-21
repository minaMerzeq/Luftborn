using Luftborn.Task.Main.Application.Mediators.Commands;
using Luftborn.Task.Main.Domain.Interfaces;
using Luftborn.Task.Main.Domain.Models;
using MediatR;

namespace Luftborn.Task.Main.Application.Mediators.CommandHandlers
{
    public class DeleteProductCommandHandler(IRepository<Product> repo) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IRepository<Product> _repo = repo;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            _repo.Delete(product);
            return await _repo.SaveChangesAsync();
        }
    }
}
