namespace CompanyEmployee.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CompanyEmployee.Services.Contracts;
    using CompanyEmployee.Services.Models;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using CompanyEmployee.API;

    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyEmployeeDBContext db;

        public EmployeeService(CompanyEmployeeDBContext db)
        {
            this.db = db;
        }

        public async Task Create(EmployeeRequestModel model)
        {
            var employee = new Employee();
            employee.EmployeeNumber = Convert.ToInt32(model.EmployeeNumber);
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.RoleId = Convert.ToInt32(model.RoleId);
            employee.Extension = Convert.ToInt16(model.Extension);
            employee.DateJoined = model.DateJoined;

            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
        }

        public async Task Update(EmployeeUpdateRequestModel model)
        {
            var employee = await db.Employees.FindAsync(model.EmployeeId);
            if (employee != null)
            {
                if (employee.FirstName != model.FirstName || employee.LastName != model.LastName ||
                employee.RoleId != Convert.ToInt32(model.RoleId) || employee.DateJoined != model.DateJoined ||
                employee.Extension != model.Extension || employee.EmployeeNumber != model.EmployeeNumber)                    
                {
                    employee.FirstName = model.FirstName;
                    employee.EmployeeNumber = model.EmployeeNumber;
                    employee.LastName = model.LastName;
                    employee.RoleId = Convert.ToInt32(model.RoleId);
                    employee.Extension = model.Extension;
                    employee.DateJoined = model.DateJoined;

                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task Delete(long id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee != null)
            {
                db.Remove(employee);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(long id)
             => await db.Employees.AnyAsync(c => c.EmployeeId == id);

        public async Task<Employee> GetEmployee(long Id) =>
            await db
           .Employees
           .Where(c => c.EmployeeId == Id)
           .FirstOrDefaultAsync();

        public async Task<IEnumerable<Employee>> AllEmployees() =>
          await db
         .Employees
         .ToListAsync();
    }
}
