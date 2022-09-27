using MediatR;

namespace ElUniversidad.Domain.SeedWork
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
