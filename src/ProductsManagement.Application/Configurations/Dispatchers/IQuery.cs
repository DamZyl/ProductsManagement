using MediatR;

namespace ProductsManagement.Application.Configurations.Dispatchers;

public interface IQuery<out TResult> : IRequest<TResult> { }