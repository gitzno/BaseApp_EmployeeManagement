using Core.DTOs;
using Core.Entities;
using Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// get list search with pagesize and paeg number
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// @author: htthuy
        /// @date: 24/01/2024
        ServiceResult SearchService(int pageSize, int page, string search);
        /// <summary>
        /// service duplicate employee
        /// </summary>
        /// <param name="employee">employee id</param>
        /// <returns>
        ///  Success = true,
        ///  StatusCode = HttpStatusCode.OK,
        ///  Data = $"Dulicate thành công với, mã nhân viên mới là {employee.EmployeeCode}"
        /// </returns>
        /// @author: htthuy
        /// @date: 24/01/2024
        public ServiceResult Duplicate(Guid employeeID);
        /// <summary>
        /// get a bigest employeecode
        /// </summary>
        /// <returns></returns>
        public string GetBiggestEmployeeCode();
    }
}
