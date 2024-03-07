using Core.Entities;
using Core.Interfaces.infrastructure;
using Core.Interfaces.Services;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PositionRepository : BaseRepository<Positions>, IPositionRepository
    {
        IDbContextMaria _dbContext;
        public PositionRepository(IDbContextMaria dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
