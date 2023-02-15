using FirstApp.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstApp.Repository
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;
        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            var entityToChange= await context.Set<TEntity>().FindAsync(id);
            if (entity.FirstName != null) {
                entityToChange.FirstName = entity.FirstName;
            }
            if (entity.LastName != null)
            {
                entityToChange.LastName = entity.LastName;
            }
            if (entity.Email != null)
            {
                entityToChange.Email = entity.Email;
            }
            context.Entry(entityToChange).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entityToChange;
        }

        public async Task<TEntity> PatchAsync(int id, JsonPatchDocument<TEntity> patchDocument)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            patchDocument.ApplyTo(entity);
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
