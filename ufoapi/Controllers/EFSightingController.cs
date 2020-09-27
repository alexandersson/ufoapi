using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ufoapi.Data;

namespace ufoapi.Controllers
{
    public abstract class EFSightingController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public EFSightingController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var sighting = await repository.Get(id);
            if (sighting == null)
            {
                return NotFound();
            }
            return sighting;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity sighting)
        {
            if (id != sighting.Id)
            {
                return BadRequest();
            }
            await repository.Update(sighting);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity sighting)
        {
            await repository.Add(sighting);
            return CreatedAtAction("Get", new { id = sighting.Id }, sighting);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var sighting = await repository.Delete(id);
            if (sighting == null)
            {
                return NotFound();
            }
            return sighting;
        }
    }
}
