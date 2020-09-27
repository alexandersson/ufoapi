using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ufoapi.Models;

namespace ufoapi.Data.EFCore
{
    public class EfCoreSightingRepository : EfCoreRepository<Sighting, SightingContext>
    {
        public EfCoreSightingRepository(SightingContext context) : base(context)
        {
            
        }
    }
}
