using CleanArc_Kevin.Core.Contracts.ApplicationServices.Commands;
using CleanArc_Kevin.Core.Contracts.ApplicationServices.Events;
using CleanArc_Kevin.Core.Contracts.ApplicationServices.Queries;
using CleanArc_Kevin.Utilities;

namespace CleanArc_Kevin.Endpoints.API.Extensions;

public static class HttpContextExtentions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));

    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));

    public static CommonService CommonService(this HttpContext httpContext) =>
        (CommonService)httpContext.RequestServices.GetService(typeof(CommonService));
}