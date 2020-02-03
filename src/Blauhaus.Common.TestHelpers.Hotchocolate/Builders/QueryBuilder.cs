using System.Collections.Generic;
using System.Security.Claims;
using Blauhaus.Auth.Abstractions.Builders;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Common.TestHelpers.Hotchocolate.Builders
{
    public class QueryBuilder
    {

        private ClaimsPrincipalBuilder? _claimsPrincipalBuilder;
        private readonly QueryRequestBuilder _queryRequestBuilder;
        private readonly IServiceCollection _serviceCollection;

        public QueryBuilder(ServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            _queryRequestBuilder = QueryRequestBuilder.New();
        }
        
        public QueryBuilder With_Property(string name, object value)
        {
            _queryRequestBuilder.SetProperty(name, value);
            return this;
        }

        public QueryBuilder With_ClaimsPrincipalUserId(string userId)
        {
            if(_claimsPrincipalBuilder == null)
                _claimsPrincipalBuilder = new ClaimsPrincipalBuilder();

            _claimsPrincipalBuilder.With_NameIdentifier(userId);

            return this;
        }
        
        public QueryBuilder With_Context_property(string key, object value)
        {
            _queryRequestBuilder.SetProperty(key, value);
            return this;
        }


        public QueryBuilder With_Query(string query)
        {
            _queryRequestBuilder.SetQuery(query);
            return this;
        }

        public QueryBuilder With_Variables(Dictionary<string, object> variables)
        {
            _queryRequestBuilder.SetVariableValues(variables);
            return this;
        }

        public QueryBuilder With_Variable(string name, object value)
        {
            _queryRequestBuilder.SetVariableValue(name, value);
            return this;
        }

        public IReadOnlyQueryRequest Build()
        {
            if (_claimsPrincipalBuilder != null)
                _queryRequestBuilder.SetProperty(nameof(ClaimsPrincipal), _claimsPrincipalBuilder.Build());

            if (_serviceCollection != null)
                _queryRequestBuilder.SetServices(_serviceCollection.BuildServiceProvider());

            return _queryRequestBuilder.Create();
        }


    }
}