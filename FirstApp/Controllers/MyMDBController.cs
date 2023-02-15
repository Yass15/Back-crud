using System.Collections.Generic;
using System.Threading.Tasks;
using FirstApp.Entities;
using FirstApp.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyMDBController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyMDBController(TRepository repository)
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
            var user = await repository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity user)
        {
            await repository.Update(id,user);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TEntity> patchDocument)
        {
            var entity = await repository.PatchAsync(id, patchDocument);
            if (entity == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity user)
        {
            await repository.Add(user);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var user = await repository.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    }
}
