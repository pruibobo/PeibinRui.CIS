using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IInteractionRepository _interactionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IInteractionRepository interactionRepository)
        {
            _employeeRepository = employeeRepository;
            _interactionRepository = interactionRepository;
        }

        public async Task<List<EmployeeResponseModel>> GetEmployeeList()
        {
            var employees = await _employeeRepository.ListAllAsync();
            List<EmployeeResponseModel> employeeResponseModels = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                employeeResponseModels.Add(new EmployeeResponseModel
                {
                    Designation = employee.Designation,
                    Id = employee.Id,
                    Name = employee.Name,
                    Password = employee.Password
                });
            }

            return employeeResponseModels;
        }

        public async Task<EmployeeResponseModel> GetEmployeeDetails(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            var employeeResponseModel = new EmployeeResponseModel
            {
                Designation = employee.Designation,
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password
            };
            return employeeResponseModel;
        }

        public async Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel employeeRequestModel)
        {
            var employee = new Employee
            {
                Designation = employeeRequestModel.Designation,
                Name = employeeRequestModel.Name,
                Password = employeeRequestModel.Password
            };
            var employeeResponseModel = new EmployeeResponseModel
            {
                Designation = employee.Designation,
                Name = employee.Name,
                Password = employee.Password
            };
            await _employeeRepository.AddAsync(employee);
            return employeeResponseModel;
        }

        public async Task<EmployeeResponseModel> UpdateEmployeeById(int id, EmployeeRequestModel employeeRequestModel)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            employee.Designation = employeeRequestModel.Designation;
            employee.Name = employeeRequestModel.Name;
            employee.Password = employeeRequestModel.Password;

            var employeeResponseModel = new EmployeeResponseModel
            {
                Id = employee.Id,
                Designation = employee.Designation,
                Name = employee.Name,
                Password = employee.Password
            };
            await _employeeRepository.UpdateAsync(employee);
            return employeeResponseModel;
        }

        public async Task DeleteEmployeeById(int id)
        {
            var employee = await  _employeeRepository.GetByIdAsync(id);
            var employeeInteractions = await _interactionRepository.GetInteractionByEmployee(id);
            foreach (var employeeInteraction in employeeInteractions)
            {
                employeeInteraction.EmpId = null;
            }

            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
