using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<Entity>
    {

        /// <summary>
        /// get all object in database with entityname
        /// </summary>
        /// <returns>
        /// list all of object in database
        /// </returns>
        /// @date: 05/01/24
        /// @author: hhthuy
        /// 
        public IEnumerable<Entity> GetAll();

        /// <summary>
        /// insert a object in database
        /// </summary>
        /// <param name="entity">object want to insert in database</param>
        /// <returns>
        /// Status of command:
        /// != 0 sucessfully
        /// = 0 failed
        /// </returns>
        /// @date: 05/01/24
        /// @author: htthuy
        int Insert(Entity entity);

        /// <summary>
        /// update a object with id
        /// </summary>
        /// <param name="entity">object with new attribute</param>
        /// <param name="entityId">id object want change</param>
        /// <returns>
        /// Status of command:
        /// != 0 sucessfully
        /// = 0 failed
        /// </returns>
        /// @date: 05/01/24
        /// @author: htthuy
        int Update(Entity entity, Guid entityId);

        /// <summary>
        /// Delete record with id on database
        /// </summary>
        /// <param name="entityId">id of entity</param>
        /// <returns>
        /// Status of command:
        /// != 0 sucessfully
        /// = 0 failed
        /// </returns>
        /// @date: 30/12/23
        /// @author: htthuy
        int Delete(Guid entityCode);
        /// <summary>
        /// Get a object with object's id
        /// </summary>
        /// <param name="entityId">id of entity</param>
        /// <returns>
        /// object have id like id param
        /// </returns>
        /// @date: 30/12/23
        /// @author: htthuy
        Entity GetById(Guid entityId);

        /// <summary>
        /// get a object with object's code
        /// </summary>
        /// <param name="entityCode">code of entity</param>
        /// <returns>
        /// object have id like id param
        /// </returns>
        Entity GetByCode(string entityCode);
    }
}
