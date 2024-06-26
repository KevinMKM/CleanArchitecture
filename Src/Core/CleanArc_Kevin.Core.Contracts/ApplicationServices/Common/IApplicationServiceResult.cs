﻿namespace CleanArc_Kevin.Core.Contracts.ApplicationServices.Common;

public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }

    ApplicationServiceStatus Status { get; set; }
}