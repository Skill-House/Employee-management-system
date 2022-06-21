using EmployeeManagement_Repository.Contracts;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement_Repository
{
    public static class SQLDependencyRegistry
    {
        public static void DependencyRegistry(this IServiceCollection serviceCollection,AppSettings appsettings)
        {
            serviceCollection.AddDbContext<EmployeeManagementContext>(options =>
            {
                options.UseSqlServer(appsettings.ConnectionString);
            });
            //serviceCollection.AddDbContext<EmployeeManagementContext>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IUserRoleRepository, UserRoleRepository>();
            serviceCollection.AddTransient<CompanyRepository>();
            serviceCollection.AddTransient<EmployeeRepository>();
            serviceCollection.AddTransient<ProjectRepository>();
        }
    }
}
