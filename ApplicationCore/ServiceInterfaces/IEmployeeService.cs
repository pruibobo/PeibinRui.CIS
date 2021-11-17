using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> GetEmployeeList();
        Task<EmployeeResponseModel> GetEmployeeDetails(int id);
        Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel employeeRequestModel);
        Task<EmployeeResponseModel> UpdateEmployeeById(int id, EmployeeRequestModel employeeRequestModel);
        Task DeleteEmployeeById(int id);
    }
}
