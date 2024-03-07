using Core.Interfaces.infrastructure;
using Core.Interfaces.Services;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IDepartmentRepository Department { get; }
        IPositionRepository Position { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
