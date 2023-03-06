using Merck.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MyDbContext _dbContext;

        public BaseRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                var Model = await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return Model.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            var Model = _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return Model.Entity;
        }

        public Task<TEntity> Get(int id)
        {

            throw new NotImplementedException();
        }



        public List<TEntity> Get()
        {
            try
            {
                return _dbContext.Set<TEntity>().Where(x => true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                var Model = _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return Model.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
