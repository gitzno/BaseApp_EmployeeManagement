using Core.Entities;
using Core.Interfaces.infrastructure;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        IDbContextMaria _dbContext;
        public DepartmentRepository(IDbContextMaria dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
