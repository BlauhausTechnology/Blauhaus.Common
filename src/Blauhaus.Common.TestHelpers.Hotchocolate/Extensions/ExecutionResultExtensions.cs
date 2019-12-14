﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Blauhaus.Common.Utils.Extensions;
using HotChocolate.Execution;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Blauhaus.Common.TestHelpers.Hotchocolate.Extensions
{
    public static class ExecutionResultExtensions
    {
        public static TProperty GetProperty<T, TProperty>(
            this IExecutionResult executionResult,
            Expression<Func<T, object>> expression)
        {
            var objectName = expression.ToPropertyName();
            var readOnlyQueryResult = (ReadOnlyQueryResult) executionResult;
            var index = -1;
            var flag = false;
            
            foreach (var key in readOnlyQueryResult.Data.Keys)
            {
                ++index;
                if (key == objectName)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
                Assert.Fail("ExecutionResult does not contain an object called " + objectName);
            return (TProperty)readOnlyQueryResult.Data.Values.ToArray<object>()[index];
        }
        
        public static List<OrderedDictionary> GetPropertyDictionaries<T>(this IExecutionResult executionResult, Expression<Func<T, object>> expression)
        {
            var objectName = expression.ToPropertyName();
            var result = (ReadOnlyQueryResult)executionResult;

            var index = -1;
            var foundKey=false;
            
            foreach (var key in result.Data.Keys)
            {
                index++;
                if (key == objectName)
                {
                    foundKey = true;
                    break;
                }
            }

            if(!foundKey)
                Assert.Fail($"ExecutionResult does not contain an object called {objectName}");
            
            var objectList = (List<object>)result.Data.Values.ToArray()[index];
            var dictionaries = new List<OrderedDictionary>();
            foreach (object listObject in objectList)
            {
                dictionaries.Add((OrderedDictionary)listObject);
            }

            return dictionaries;
        }

        public static IExecutionResult VerifyContainsNoData(this IExecutionResult executionResult)
        {
            Assert.That(((ReadOnlyQueryResult)executionResult).Data.Count, Is.EqualTo(0));
            return executionResult;
        } 

        public static IExecutionResult VerifyNoExceptions(this IExecutionResult executionResult)
        {
            var errors = executionResult.Errors;

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    Assert.Fail(error.Message);
                }
            }
            return executionResult;
        } 

        public static IExecutionResult VerifyException(this IExecutionResult executionResult, string exceptionErrorMessage)
        {
            var errors = executionResult.Errors;

            if (errors.Count == 0)
            {
                Assert.Fail("No errors were contained in the ExecutionResult");
            }

            var expectedError = errors.FirstOrDefault(x => x.Exception?.Message == exceptionErrorMessage);

            if(expectedError == null)
                Assert.Fail($"No errors contained the expected exception message {exceptionErrorMessage}");
            else
                Assert.That(exceptionErrorMessage, Is.EqualTo(exceptionErrorMessage));

            return executionResult;
        } 

        public static JObject ExtractData(this IExecutionResult executionResult)
        {
            var result = (ReadOnlyQueryResult) executionResult;
            
            using var stream = new MemoryStream();
            
            var resultSerializer = new JsonQueryResultSerializer();
            resultSerializer.SerializeAsync(
                result, stream).Wait();
            var jsonString =  Encoding.UTF8.GetString(stream.ToArray());
            
            var jObject = JObject.Parse(jsonString);

            var data = (JObject) jObject.GetValue("data");

            return data;
        }

        public static OrderedDictionary GetPropertyDictionary(this IExecutionResult executionResult, string objectName)
        {
            var result = (ReadOnlyQueryResult)executionResult;

            var index = -1;
            var foundKey=false;
            
            foreach (var key in result.Data.Keys)
            {
                index++;
                if (key == objectName)
                {
                    foundKey = true;
                    break;
                }
            }

            if(!foundKey)
                Assert.Fail($"ExecutionResult does not contain an object called {objectName}");
            
            return  (OrderedDictionary)result.Data.Values.ToArray()[index];
        }
        
        public static OrderedDictionary GetPropertyDictionary<T>(this IExecutionResult executionResult, Expression<Func<T, object>> expression)
        {
           return executionResult.GetPropertyDictionary(expression.ToPropertyName());
        }

        
        public static IExecutionResult VerifyException<TException>(this IExecutionResult executionResult, string exceptionErrorMessage = "")
        {
            var errors = executionResult.Errors;

            if (errors.Count == 0)
            {
                Assert.Fail("No errors were contained in the ExecutionResult");
            }

            var expectedError = errors.FirstOrDefault(x => x.Exception.GetType() == typeof(TException));

            if(expectedError == null)
                Assert.Fail($"No errors contained the expected exception message {exceptionErrorMessage}");
            else
            {
                if(string.IsNullOrEmpty(exceptionErrorMessage))
                    Assert.Pass();
                else
                    Assert.That(exceptionErrorMessage, Is.EqualTo(exceptionErrorMessage));
            }

            return executionResult;
        } 
    }
}