using System.Collections.Generic;
using System.Threading.Tasks;
using FirstApp.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace FirstApp.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);
        Task<T> PatchAsync(int id, JsonPatchDocument<T> patchDocument);
    }
}
