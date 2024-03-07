using Core.Entities;
using Core.Interfaces.infrastructure;
using Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {

        IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository repository) : base(repository)
        {
            _departmentRepository = repository;
        }
    }
}
