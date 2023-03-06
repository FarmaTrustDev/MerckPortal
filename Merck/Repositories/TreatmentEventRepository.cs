using Merck.Interfaces.Repositories;
using Merck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Repositories
{
    public class TreatmentEventRepository : BaseRepository<TreatmentEvent>, ITreatmentEventRepository
    {
        private readonly MyDbContext _dbContext;
        public TreatmentEventRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
