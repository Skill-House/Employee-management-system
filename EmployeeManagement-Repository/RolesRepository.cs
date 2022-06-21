using EmployeeManagement_Repository.Entities;
using EmployeeManagement.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository
{
    public class RolesRepository
    {

        private readonly EmployeeManagementContext dbContext;

        public RolesRepository()
        {
            dbContext = new EmployeeManagementContext();
        }

        public async Task<List<RolesModel>> GetRolesAsync()
        {
            var result = dbContext.Roles.Include(x => x.Users).ToList();
            var roleDetails = new List<RolesModel>();
            foreach (var role in result)
            {
                roleDetails.Add(new RolesModel()
                {
                   Id = role.Id,
                   RollName = role.RollName,
                });
            }
            return roleDetails;
        }

        public async Task<RolesModel> GetRolesByID(int Id)
        {

            var result =   dbContext.Roles.FirstOrDefault(a => a.Id == Id);
            var  rolesdeatail = new RolesModel();
            rolesdeatail.Id = result.Id;
            rolesdeatail.RollName = result.RollName;
            return rolesdeatail;
        }

        public async Task DeleteRolesByID(int Id)
        {
            var DelRole =  dbContext.Roles.FirstOrDefault(a => a.Id == Id);
            if (DelRole != null)
            {
                dbContext.Remove(DelRole);
                dbContext.SaveChanges();

            }
        }

        public async Task CreateRoles(Role role)
        {
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();

        }

        public async Task UpdateRoles(Role roles)
        {
            var existingRole = dbContext.Roles.Where(h => h.Id == roles.Id).FirstOrDefault();
            if (existingRole != null)
            {
                //existingRole.Id = roles.Id;
                existingRole.RollName = roles.RollName;
                  await this.dbContext.SaveChangesAsync();
            }
        }

    }
}