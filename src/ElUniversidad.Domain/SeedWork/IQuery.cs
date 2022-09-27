using MediatR;

namespace ElUniversidad.Domain.SeedWork
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
