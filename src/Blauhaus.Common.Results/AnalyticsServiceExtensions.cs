using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.ValueObjects.Errors;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Results
{
    public static class AnalyticsServiceExtensions
    {
        public static Result TraceErrorResult(this IAnalyticsService analyticsService, object sender, Error error,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.Trace(sender, error.Code, logSeverity, new Dictionary<string, object>(), caller);
            return Result.Failure(error.ToString());
        }
        public static Result TraceErrorResult(this IAnalyticsService analyticsService, object sender, Error error, Dictionary<string, object> properties,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.Trace(sender, error.Code, logSeverity, properties, caller);
            return Result.Failure(error.ToString());
        }
        public static Result TraceErrorResult(this IAnalyticsService analyticsService, object sender, Error error, string propertyName, string propertyValue,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.Trace(sender, error.Code, logSeverity, new Dictionary<string, object> {{propertyName, propertyValue}}, caller);
            return Result.Failure(error.ToString());
        }

        public static Result<T> TraceErrorResult<T>(this IAnalyticsService analyticsService, object sender, Error error,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.Trace(sender, error.Code, logSeverity, new Dictionary<string, object>(), caller);
            return Result.Failure<T>(error.ToString());
        }
        public static Result<T> TraceErrorResult<T>(this IAnalyticsService analyticsService, object sender, Error error, Dictionary<string, object> properties,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.Trace(sender, error.Code, logSeverity, properties, caller);
            return Result.Failure<T>(error.ToString());
        }
        public static Result<T> TraceErrorResult<T>(this IAnalyticsService analyticsService, object sender, Error error, string propertyName, string propertyValue,
            LogSeverity logSeverity = LogSeverity.Error, [CallerMemberName] string caller = "")
        {
            analyticsService.Trace(sender, error.Code, logSeverity, new Dictionary<string, object> {{propertyName, propertyValue}}, caller);
            return Result.Failure<T>(error.ToString());
        }

        //Exception and Error extensions
        public static Result LogExceptionResult(this IAnalyticsService analyticsService, object sender, Exception e, Error error, [CallerMemberName] string caller = "")
        {
            analyticsService.LogException(sender, e);
            return Result.Failure(error.ToString());
        }
        public static Result LogExceptionResult(this IAnalyticsService analyticsService, object sender, Exception e, Error error,  Dictionary<string, object> properties, [CallerMemberName] string caller = "")
        {
            analyticsService.LogException(sender, e, properties);
            return Result.Failure(error.ToString());
        }
        public static Result<T> LogExceptionResult<T>(this IAnalyticsService analyticsService, object sender, Exception e, Error error, [CallerMemberName] string caller = "")
        {
            analyticsService.LogException(sender, e);
            return Result.Failure<T>(error.ToString());
        }
        public static Result<T> LogExceptionResult<T>(this IAnalyticsService analyticsService, object sender, Exception e, Error error, Dictionary<string, object> properties, [CallerMemberName] string caller = "")
        {
            analyticsService.LogException(sender, e, properties);
            return Result.Failure<T>(error.ToString());
        }
    }
}