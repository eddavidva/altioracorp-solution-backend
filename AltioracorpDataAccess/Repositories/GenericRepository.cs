using AltioracorpDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.Repositories
{
    // REPOSITORIO CON LA LÓGICA DE UN CRUD GENÉRICO
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AltioracorpContext db;

        public GenericRepository(AltioracorpContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            // db.Entry(entity).State = EntityState.Modified;
            db.Set<TEntity>().AddOrUpdate(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
