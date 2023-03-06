using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        public Task<TEntity> Create(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
        public List<TEntity> Get();
        public Task<TEntity> Get(int id);
    }
}
