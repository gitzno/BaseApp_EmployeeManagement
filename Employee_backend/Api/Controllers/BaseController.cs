using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.services;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity> : ControllerBase
    {
        #region feild
        private readonly IBaseService<Entity> _baseService;
        private readonly IBaseRepository<Entity> _baseRepository;
        #endregion

        #region constructor
        public BaseController(IBaseService<Entity> baseService, IBaseRepository<Entity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// get all data
        /// </summary>
        /// <returns>
        /// 200 - danh sách đối tượng
        /// 400 - lỗi về nghiệp vụ
        /// 500 - nếu có exception
        /// </returns>
        /// @createby: thuyht
        /// @date: 7/11/2023
        [HttpGet]
        public IActionResult Get()
        {
            var list = _baseRepository.GetAll();
            return Ok(list);
        }
        /// <summary>
        /// get a object with entity's id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// @Author: htthuy
        /// @Date: 10/11/23
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {

            var list = _baseRepository.GetById(entityId);
            return Ok(list);

        }

        /// <summary>
        /// update a entity object with id of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// @Author: htthuy
        /// @Date: 10/11/23
        [HttpPut("{entityId}")]
        public IActionResult Put(Entity entity, Guid entityId)
        {
            try
            {
                var list = _baseService.UpdateService(entity, entityId);
                return Ok(new
                {
                    devMsg = list.DevMsg,
                    userMsg = list.UserMsg,
                    data = list.Data
                });
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
        /// <summary>
        /// api delete an object with id
        /// </summary>
        /// <param name="entityId">id of entity</param>
        /// <returns></returns>
        /// @Author: htthuy
        /// @Date: 10/11/23
        [HttpDelete("{entityCode}")]
        public IActionResult Delete(Guid entityCode)
        {
            try
            {
                var list = _baseService.DeleteService(entityCode);

                var response = new
                {
                    devMsg = list.DevMsg,
                    userMsg = list.UserMsg,
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
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được hỗ trợ",
                    data = ex.InnerException
                };
                return StatusCode(501, response);
            }
        }
        #endregion
    }
}


