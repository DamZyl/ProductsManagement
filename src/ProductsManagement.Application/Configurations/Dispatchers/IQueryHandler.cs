using MediatR;

namespace ProductsManagement.Application.Configurations.Dispatchers;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> { }