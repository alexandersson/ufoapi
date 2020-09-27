using GraphQL.Types;
using ufoapi.Data.EFCore;
using ufoapi.Entities;
using ufoapi.GraphQL.Types;

namespace ufoapi.GraphQL.Queries
{
    public class SightingQuery : ObjectGraphType
    {
        public SightingQuery(EfCoreSightingRepository sightingRepository)
        {
            Field<ListGraphType<SightingType>>(
                "sightings",
                resolve: context => sightingRepository.GetAll()
            );
        }
    }
}
