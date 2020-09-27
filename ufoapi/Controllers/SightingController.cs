using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ufoapi.Data.EFCore;
using ufoapi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ufoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightingController : EFSightingController<Sighting, EfCoreSightingRepository>
    {
        public SightingController(EfCoreSightingRepository repository) : base(repository)
        {
            
        }
    }
}
