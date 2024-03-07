
using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces.infrastructure;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.services;
using Core.NewAttribute;
using System.Net;
using System.Reflection;

namespace Core.Services
{

    public class BaseService<Entity> : IBaseService<Entity>
    {
        #region feild
        private IBaseRepository<Entity> _baseRepository;
        private IDepartmentRepository repository;
        #endregion
        #region constructor
        public BaseService(IBaseRepository<Entity> repository)
        {
            _baseRepository = repository;
        }

        public BaseService(IDepartmentRepository repository)
        {
            this.repository = repository;
        }
        #endregion
        #region method

        public ServiceResult DeleteService(Guid entityCode)
        {
            var res = _baseRepository.Delete(entityCode);
            if (res == 1)
            {
                return new ServiceResult
                {
                    Success = true,
                    Data = 1,
                    StatusCode = HttpStatusCode.OK,
                    DevMsg = new List<string> { Core.Resources.DevMsg.DeleteSucess },
                    UserMsg = new List<string> { Core.Resources.UserMsg.DeleteSucess }
                };
            }
            return new ServiceResult
            {
                Success = true,
                Data = 0,
                StatusCode = HttpStatusCode.OK,
                DevMsg = new List<string> { Core.Resources.DevMsg.EmployeeNotFound },
                UserMsg = new List<string> { Core.Resources.UserMsg.EmployeeNotFound }
            };
        }



        ///
        public ServiceResult InsertService(Entity entity)
        {
            //2. Create new ID for entity
            // make new id by guid
            var newID = Guid.NewGuid();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            // list properties entity
            var idProperty = entity.GetType().GetProperties();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            // find identitfication attribute of entity and set new id for that
            foreach (var property in idProperty)
            {
                if (property.GetCustomAttribute<Identification>() != null)
                {
                    //1. set new id for entityId
                    property.SetValue(entity, newID);
                }
            }
            //validate object
            ValidateObject(entity);

            // return status of command in insert
            var res = new ServiceResult
            {
                Success = true,
                Data = _baseRepository.Insert(entity),
                StatusCode = HttpStatusCode.OK,
                DevMsg = new List<string>
                {
                    Core.Resources.DevMsg.AddSuccess
                },
                UserMsg = new List<string>
                {
                   Core.Resources.UserMsg.AddSuccess
                },
            };
            return res;
        }
        public ServiceResult UpdateService(Entity entity, Guid entityId)
        {
            //validate data
            var entityIds = entity.GetType().GetProperties().First().GetValue(entity);
            if (entityIds.ToString() != entityId.ToString())
            {
                throw new ValidateException($"Không được phép cập nhật ID của đối tượng");
            }
            ValidateObject(entity);

            // add into database
            var res = _baseRepository.Update(entity, entityId);
            return new ServiceResult
            {
                Success = true,
                Data = res,
                StatusCode = HttpStatusCode.OK,
                DevMsg = new List<string>
                {
                    Core.Resources.DevMsg.UpdateSuccess
                },
                UserMsg = new List<string>
                {
                    Core.Resources.UserMsg.UpdateSuccess
                },
            }; ;
        }
        protected virtual void ValidateObject(Entity entity)
        {

        }
        #endregion
    }

}
