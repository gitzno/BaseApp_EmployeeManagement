using Core.Entities;
using Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.infrastructure
{
    public interface IPositionRepository : IBaseRepository<Positions>
    {
    }
}
