using Core.Entities;
using Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// get employee with page size and page number
        /// </summary>
        /// <param name="pageSize">size of page</param>
        /// <param name="page">page number</param>
        /// <returns>list of employee</returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        IEnumerable<Employee> getPaging(int pageSize, int page);
        /// <summary>
        /// get employee with page size and page number by search
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        IEnumerable<Employee> getSearching(int pageSize, int page, string search);
        /// <summary>
        /// get record of employee if search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        public int getSearch(string search);
        /// <summary>
        /// get new employee code biggest
        /// </summary>
        /// <returns></returns>
        /// @author: htthuy
        /// @date: 23/01/2024
        String newEmployeeCodeBigger();
    }
}
