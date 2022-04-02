using MediatR;

namespace ProductsManagement.Application.Configurations.Dispatchers;

public interface ICommand : IRequest { }

public interface ICommand<out TResult> : IRequest<TResult> { }