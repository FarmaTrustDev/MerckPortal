using Merck.Interfaces.Repositories;
using Merck.Models;

namespace Merck.Repositories
{
	public class PermissionRolesRepository : BaseRepository<PermissionRoles>, IPermissionRolesRepository
	{
		private readonly MyDbContext _dbContext;
		public PermissionRolesRepository(MyDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
