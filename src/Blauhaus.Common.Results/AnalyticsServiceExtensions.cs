using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Errors;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Results
{
    public static class AnalyticsServiceExtensions
    {
        public static Result TraceErrorResult(this IAnalyticsService analyticsService, object sender, Error error,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.TraceError(sender, error, logSeverity, caller);
            return Result.Failure(error.ToString());
        }
        public static Result TraceErrorResult(this IAnalyticsService analyticsService, object sender, Error error,
            Dictionary<string, object> properties, LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.TraceError(sender, error, properties, logSeverity, caller);
            return Result.Failure(error.ToString());
        } 

        public static Result<T> TraceErrorResult<T>(this IAnalyticsService analyticsService, object sender, Error error,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.TraceError(sender, error, logSeverity, caller);
            return Result.Failure<T>(error.ToString());
        }
        public static Result<T> TraceErrorResult<T>(this IAnalyticsService analyticsService, object sender, Error error, 
            Dictionary<string, object> properties, LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.TraceError(sender, error, properties, logSeverity, caller);
            return Result.Failure<T>(error.ToString());
        } 

        public static Result LogExceptionResult(this IAnalyticsService analyticsService, object sender, Exception e, Error error, 
            [CallerMemberName] string caller = "")
        {
            analyticsService.LogException(sender, e, new Dictionary<string, object>
            {
                {"ErrorCode", error.Code },
                {"ErrorDescription", error.Description},
            }, caller);
            return Result.Failure(error.ToString());
        }
        public static Result LogExceptionResult(this IAnalyticsService analyticsService, object sender, Exception e, Error error,  
            Dictionary<string, object> properties, [CallerMemberName] string caller = "")
        {
            properties["ErrorCode"] = error.Code;
            properties["ErrorDescription"] = error.Description;
            analyticsService.LogException(sender, e, properties, caller);
            return Result.Failure(error.ToString());
        }
        public static Result<T> LogExceptionResult<T>(this IAnalyticsService analyticsService, object sender, Exception e, Error error, 
            [CallerMemberName] string caller = "")
        {
            analyticsService.LogException(sender, e,  new Dictionary<string, object>
            {
                {"ErrorCode", error.Code },
                {"ErrorDescription", error.Description},
            }, caller);
            return Result.Failure<T>(error.ToString());
        }
        public static Result<T> LogExceptionResult<T>(this IAnalyticsService analyticsService, object sender, Exception e, Error error,
            Dictionary<string, object> properties, [CallerMemberName] string caller = "")
        {
            properties["ErrorCode"] = error.Code;
            properties["ErrorDescription"] = error.Description;
            analyticsService.LogException(sender, e, properties, caller);
            return Result.Failure<T>(error.ToString());
        }
    }
}