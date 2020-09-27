using GraphQL.Types;
using ufoapi.Models;

namespace ufoapi.GraphQL.Queries
{
    public class SightingQuery : ObjectGraphType
    {
        public SightingQuery()
        {
            //Field<ListGraphType<Sighting>>(SightingRepository sightingRepository)
            //    "sightings",
            //    resolve: context => sightingRepository);
        }
    }
}
