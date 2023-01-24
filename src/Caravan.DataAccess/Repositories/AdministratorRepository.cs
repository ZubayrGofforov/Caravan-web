using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Repositories
{
    public class AdministratorRepository : GenericRepository<Administrator>,
        IAdministratorRepository
    {
        public AdministratorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
