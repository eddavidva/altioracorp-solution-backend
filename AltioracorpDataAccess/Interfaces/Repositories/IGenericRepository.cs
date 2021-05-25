using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.Interfaces
{
    // DEFINICIÓN DE LA ESTRUCTURA PARA UN CRUD GENÉRICO
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // TAREAS ASÍNCRONAS
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}
