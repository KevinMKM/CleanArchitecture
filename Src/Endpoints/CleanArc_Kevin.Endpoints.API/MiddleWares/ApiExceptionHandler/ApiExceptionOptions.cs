﻿namespace CleanArc_Kevin.Endpoints.API.MiddleWares.ApiExceptionHandler
{
    public class ApiExceptionOptions
    {
        public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
        public Func<Exception, LogLevel> DetermineLogLevel { get; set; }
    }
}