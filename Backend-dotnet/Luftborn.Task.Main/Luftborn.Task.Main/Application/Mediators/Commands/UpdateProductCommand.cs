using Luftborn.Task.Main.Domain.Dtos;
using MediatR;

namespace Luftborn.Task.Main.Application.Mediators.Commands
{
    public record UpdateProductCommand(int Id, ProductDto Dto) : IRequest<bool>;
}
