using MediatR;

namespace Luftborn.Task.Main.Application.Mediators.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<bool>;
}
