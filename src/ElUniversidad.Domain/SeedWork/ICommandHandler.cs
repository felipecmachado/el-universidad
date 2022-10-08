using MediatR;

namespace ElUniversidad.Domain.SeedWork
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    {
    }
}
