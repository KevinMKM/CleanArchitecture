using CleanArc_Kevin.Core.Contracts.ApplicationServices.Common;

namespace CleanArc_Kevin.Core.Contracts.ApplicationServices.Queries;

public sealed class QueryResult<TData> : ApplicationServiceResult
{
    public TData? Data { get; set; }
}