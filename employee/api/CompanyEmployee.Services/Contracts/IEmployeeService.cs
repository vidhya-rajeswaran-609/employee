namespace CompanyEmployee.Services.Contracts
{
    using CompanyEmployee.API;
    using CompanyEmployee.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<bool> Exists(long id);

        Task Create(EmployeeRequestModel model);

        Task Update(EmployeeUpdateRequestModel model);

        Task Delete(long id);

        Task<IEnumerable<Employee>> AllEmployees();

        Task<Employee> GetEmployee(long Id);

    }
}
