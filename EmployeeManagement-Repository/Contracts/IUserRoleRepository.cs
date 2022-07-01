using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository.Contracts
{
    public interface IUserRoleRepository
    {
        Task Create(UserRole userole);
    }
}
