using MediatR;

namespace ProductsManagement.Application.Configurations.Dispatchers;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand { }

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult> { }