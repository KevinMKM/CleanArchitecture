using CleanArc_Kevin.Core.Contracts.ApplicationServices.Common;

namespace CleanArc_Kevin.Core.Contracts.ApplicationServices.Commands;

public class CommandResult : ApplicationServiceResult
{
}

public class CommandResult<TData> : CommandResult
{
    public TData? Data { get; set; }
}