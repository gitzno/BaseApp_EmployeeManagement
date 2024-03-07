using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.services
{
    public interface IBaseService<Entity>
    {
        /// <summary>
        /// get employees with condition
        /// </summary>
        /// <param name="pageSize">size of page</param>
        /// <param name="page">number of page</param>
        /// <param name="search">condition of entity </param>
        /// <returns>list of employee</returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        ServiceResult InsertService(Entity entity);
        /// <summary>
        /// update service for entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entiryId">ID Entity</param>
        /// <returns>
        /// 0 - thực thi không thành công
        /// != 0 - thực thi thành công
        /// </returns>
        ServiceResult UpdateService(Entity entity, Guid entiryId);
        /// <summary>
        /// Delete service 
        /// </summary>
        /// <param name="entiryId">IdEntity</param>
        /// <returns>
        /// 0 - thực thi không thành công
        /// != 0 - thực thi thành công
        /// </returns>
        ServiceResult DeleteService(Guid entityCode);

    }
}
