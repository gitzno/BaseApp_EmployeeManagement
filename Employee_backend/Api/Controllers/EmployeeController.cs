using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.services;
using Infrastructure.Repository;
using static Dapper.SqlMapper;
using Core.Interfaces.Services;
using System.Net;
using Core.Services;
using Api.Controllers;

namespace  Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        #region feild
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;
        #endregion
        #region constructor
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository) : base(employeeService, employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }
        #endregion
        #region Method
        /// <summary>
        /// get a new employee code biggest + 1
        /// </summary>
        /// <returns>
        /// 400 - lỗi nghiệp vụ
        /// 500 - lỗi server
        /// 200 - hoàn thành
        /// </returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        [HttpGet("/NewEmployeeCode")]
        public IActionResult GetNewCode()
        {
            var res = _employeeService.GetBiggestEmployeeCode();
            return Ok(res);
        }
        /// <summary>
        /// api duplicate a employee object
        /// </summary>
        /// <param name="entityIdDuplicate">employee id want dulicate</param>
        /// <returns>
        /// 400 - lỗi nghiệp vụ
        /// 500 - lỗi server
        /// 200 - hoàn thành
        /// </returns>
        /// @author: htthuy
        /// @date: 23/01/2024

        [HttpGet("/Duplicate")]
        public IActionResult MakeACopy(Guid entityIdDuplicate)
        {
            try
            {
                var res = _employeeService.Duplicate(entityIdDuplicate);
                if (res.StatusCode == HttpStatusCode.OK)
                    return Ok(res);
                return BadRequest("Có lỗi gì đó");
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Lỗi khi validate data",
                    data = ex.InnerException
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "",
                    data = ex.InnerException
                };
                return StatusCode(501, response);
            }
        }
        /// <summary>
        /// get id with pagesize and page number by search
        /// </summary>
        /// <param name="pagesize">number employee with condition</param>
        /// <param name="page">number page user want view</param>
        /// <param name="search">conidtion of record</param>
        /// <returns> api match with api</returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        [HttpGet("{pagesize}/{page}")]
        public IActionResult GetPaging(int pagesize, int page, string? search)
        {
            try
            {
                var list = _employeeService.SearchService(pagesize, page, search);

                var response = new
                {
                    devMsg = "",
                    userMsg = "",
                    data = list.Data
                };
                return Ok(response);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Lỗi khi validate data",
                    data = ex.InnerException
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "",
                    data = ex.InnerException
                };
                return StatusCode(501, response);
            }
        }
        /// <summary>
        /// post a employee 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// 400 - lỗi nghiệp vụ
        /// 500 - lỗi server
        /// 200 - hoàn thành
        /// </returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        [HttpPost]
        public IActionResult Post(Employee entity)
        {
            try
            {
                var list = _employeeService.InsertService(entity);
                return Ok(new
                {
                    devMsg = "",
                    userMsg = "",
                    data = list.Data
                }
                );
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "",
                    data = ex.InnerException
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "",
                    data = ex.InnerException
                };
                return StatusCode(501, response);
            }
        }
        #endregion
    }
}
