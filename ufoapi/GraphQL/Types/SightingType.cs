using GraphQL.Types;
using ufoapi.Models;

namespace ufoapi.GraphQL.Types
{
    public class SightingType : ObjectGraphType<Sighting>
    {
        public SightingType()
        {
            Field(t => t.Id);
            Field(t => t.DateTime);
            Field(t => t.Location);
        }
    }
}
