using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Services
{

    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
            _employeeRepository = repository;
        }
        /// <summary>
        /// validate employee overide validateobject in baseservice
        /// </summary>
        /// <param name="entity">Employee object</param>
        /// <exception cref="ValidateException">If employee code dulicate throw validate exception</exception>
        protected override void ValidateObject(Employee entity)
        {
            var isDulicate = _employeeRepository.GetByCode(entity.EmployeeCode);

            if (Regex.IsMatch(entity.EmployeeCode, "^NV-[0-9]{5,}$") == false)
            {
                throw new ValidateException("Mã nhân viên phải có dạng MV-00000..");
            }
            if (isDulicate != null)
            {
                throw new ValidateException("Mã nhân viên đã tồn tại trong hệ thống");
            }
        }
        public string GetBiggestEmployeeCode()
        {
            string currentCode = _employeeRepository.newEmployeeCodeBigger();
            string numberPart = currentCode.Substring(3);
            // no record in db
            if (currentCode == null)
            {
                return "VN-00000";
            }
            if (int.TryParse(numberPart, out int currentNumber))
            {
                // Tăng giá trị của số nguyên
                currentNumber++;

                // Format lại mã nhân viên với số nguyên mới
                string newEmployeeCode = $"NV-{currentNumber:D5}";

                return newEmployeeCode;
            }
            throw new ValidateException("");
        }

        public ServiceResult Duplicate(Guid employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            employee.EmployeeId = Guid.NewGuid();
            // thuật toán tăng mã nhân viên mà không trùng

            employee.EmployeeCode = GetBiggestEmployeeCode();
            // thay đổi modifi 
            employee.ModifiedBy = null;
            employee.ModifiedDate = null;

            // cho createdate là hiện tại
            employee.CreatedDate = DateTime.Now;
            employee.CreatedBy = "Dulicate";
            //insert vào bản ghi
            var res = _employeeRepository.Insert(employee);
            return new ServiceResult()
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Data = res,
                DevMsg = new List<string> { },
                UserMsg = new List<string> { }
            };
        }

        public ServiceResult SearchService(int pageSize, int page, string search)
        {
            // 1. xử lý trường hợp page < 0
            if (page < 0)
            {
                page = 0;
            }
            else
            {
                page--;
            }
            // 2. xử lý text searching
            // nếu không có text searching thì trả về danh sách đã phân trang
            if (search == null || search == "")
            {
                var res = new
                {
                    total = _employeeRepository.getSearch(""),
                    list = _employeeRepository.getPaging(pageSize, page)
                };
                return new ServiceResult()
                {
                    Success = true,
                    Data = res,
                    StatusCode = HttpStatusCode.OK,
                    DevMsg = new List<string> { "" },
                    UserMsg = new List<string> { "" }
                };
            }
            var respon = new
            {
                total = _employeeRepository.getSearch(search),
                list = _employeeRepository.getSearching(pageSize, page, search)
            };

            return new ServiceResult()
            {
                Success = true,
                Data = respon,
                StatusCode = HttpStatusCode.OK,
                DevMsg = new List<string> { "" },
                UserMsg = new List<string> { "" }
            }; ;

        }

    }
}
