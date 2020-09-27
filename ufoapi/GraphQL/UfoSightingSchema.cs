using System;
using GraphQL.Types;
using GraphQL.Utilities;
using ufoapi.GraphQL.Queries;

namespace ufoapi.GraphQL
{
    public class UfoSightingSchema : Schema
    {
        public UfoSightingSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<SightingQuery>();
        }
    }
}
