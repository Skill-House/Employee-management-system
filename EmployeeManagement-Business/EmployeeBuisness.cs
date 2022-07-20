﻿using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using System.Net;

namespace EmployeeManagement_Business
{
    public class EmployeeBuisness
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeBuisness(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            var alumnus = await employeeRepository.GetById(Id);
            return alumnus;
        }
        public async Task<HttpStatusCode> SaveEmployeeAsync(EmployeeAddModel employee)
        {
            var emp = new Employee();
            emp.FirstName=employee.FirstName;
            emp.LastName=employee.LastName;
            emp.Email=employee.Email;
            emp.Phone=employee.Phone;
            emp.CompanyId=employee.CompanyId;
            emp.Gender=employee.Gender;
            emp.DateCreated = employee.DateCreated;
            emp.DateModified = employee.DateModified;
             await employeeRepository.Create(emp);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> UpdateEmployeeAsync(EmployeeAddModel employee)
        {
            var emp = new Employee();
            emp.Id = (int)employee.Id;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.Phone = employee.Phone;
            emp.CompanyId = employee.CompanyId;
            emp.Gender = employee.Gender;            
            emp.DateModified = employee.DateModified;
            await employeeRepository.Update(emp);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteEmployeeAsync(int Id)
        {
            var employee = await employeeRepository.GetById(Id);
            if(employee == null)
            {
                return HttpStatusCode.NotFound;
            }
            else
            {
                await employeeRepository.Delete(Id);
                return HttpStatusCode.OK;
            }

        }
        public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync()
        {
            var employeeViewModelList = new List<EmployeeViewModel>();
            var employeeList = await employeeRepository.GetAllEmployeesAsync();
            foreach(var employee in employeeList)
            {
                employeeViewModelList.Add(new EmployeeViewModel
                {   Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Gender = employee.Gender,
                    Phone = employee.Phone,
                    DateCreated = employee.DateCreated,
                    DateModified = employee.DateModified,
                    CompanyName = employee.Company.CompanyName,
                    CompanyAddress = employee.Company.CompanyAddress,
                });
            }
            return employeeViewModelList;
        }
    }
}