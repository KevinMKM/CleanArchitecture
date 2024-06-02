using CleanArc_Kevin.Core.Contracts.ApplicationServices.Common;
using CleanArc_Kevin.Core.Contracts.ApplicationServices.Queries;

namespace CleanArc_Kevin.Core.ApplicationService.Queries;

public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData> where TQuery : class, IQuery<TData>
{
    private readonly QueryResult<TData> _result = new();
    
    public abstract Task<QueryResult<TData>> Handle(TQuery request);

    protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        _result.Data = data;
        _result.Status = status;
        return Task.FromResult(_result);
    }

    protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        _result.Data = data;
        _result.Status = status;
        return _result;
    }

    protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return ResultAsync(data, status);
    }

    protected virtual QueryResult<TData> Result(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return Result(data, status);
    }
}