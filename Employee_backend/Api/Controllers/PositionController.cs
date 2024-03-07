using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces.infrastructure;
using Core.Interfaces.services;
using Core.Interfaces.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : BaseController<Positions>
    {
        #region Feild
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionService _positionService;
        #endregion
        #region Constructor
        public PositionController(IPositionService positionService, IPositionRepository positionRepository) : base(positionService, positionRepository)
        {
            _positionService = positionService;
            _positionRepository = positionRepository;
        }
        #endregion
    }
}
