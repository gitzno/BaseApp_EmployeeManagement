using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces.infrastructure;
using Core.Interfaces.services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        #region Feild
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentService _departmentService;
        #endregion
        #region construtor
        public DepartmentController(IDepartmentService departmentService, IDepartmentRepository departmentRepository) : base(departmentService, departmentRepository)
        {
            _departmentService = departmentService;
            _departmentRepository = departmentRepository;
        }
        #endregion
    }
}
