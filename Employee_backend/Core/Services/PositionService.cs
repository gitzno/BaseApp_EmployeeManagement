using Core.Entities;
using Core.Interfaces.infrastructure;
using Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PositionService : BaseService<Positions>, IPositionService
    {
        IPositionRepository _positionRepository;
        public PositionService(IPositionRepository repository) : base(repository)
        {
            _positionRepository = repository;
        }
    }
}
