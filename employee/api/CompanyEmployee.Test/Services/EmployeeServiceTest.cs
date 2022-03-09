namespace CompanyEmployee.Test.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using CompanyEmployee.Services;
    using CompanyEmployee.API;
    using CompanyEmployee.Services.Models;

    public class EmployeeServiceTest
    {
        readonly EmployeeService employeeService;
        readonly CompanyEmployeeDBContext db;
        readonly EmployeeRequestModel model = new EmployeeRequestModel
        {
            EmployeeId = "1",
            EmployeeNumber = "123",
            Extension = "2222",
            FirstName = "Sara",
            LastName = "John",
            RoleId = "1",
            DateJoined = DateTime.Now
        };
        public EmployeeServiceTest()
        {
            db = this.GetDatabase();
            employeeService = new EmployeeService(db);
        }

        [Fact]
        public async Task CreateEmployeeShouldSaveCorrectData()
        {
            // Arrange
            const long Id = 1;
            var employeeService = new EmployeeService(db);

            // Act
            await employeeService.Create(model);
            var result = await db.Employees.FindAsync(Id);

            // Assert
            Assert.Equal(Id, result.EmployeeId);
            Assert.Equal(123, result.EmployeeNumber);
            Assert.Equal("Sara", result.FirstName);
            Assert.Equal("John", result.LastName);
        }

        [Fact]
        public async Task UpdateEmployeeShouldSaveCorrectData()
        {
            // Arrange
            const long Id = 1;
            await employeeService.Create(model);
            var employee = await db.Employees.FindAsync(Id);
            var updateEmployee = new EmployeeUpdateRequestModel
            {
                Extension=employee.Extension,
                EmployeeNumber= 123456,
                DateJoined= employee.DateJoined,
                EmployeeId= employee.EmployeeId,
                RoleId= 1,
                FirstName = "Mike",
                LastName = "Floor",
            };

            // Act
            await employeeService.Update(updateEmployee);
            var result = await db.Employees.FindAsync(Id);

            // Assert
            Assert.Equal(Id, result.EmployeeId);
            Assert.Equal(123456, result.EmployeeNumber);
            Assert.Equal("Mike", result.FirstName);
            Assert.Equal("Floor", result.LastName);
        }

        [Fact]
        public async Task DeleteEmployeeShouldDeleteData()
        {
            // Arrange
            const long Id = 1;
            await employeeService.Create(model);
            var employee = await db.Employees.FindAsync(Id);
           
            // Act
            await employeeService.Delete(Id);
            var result = await db.Employees.FindAsync(Id);

            // Assert
            Assert.Null(result);
        }

        private CompanyEmployeeDBContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<CompanyEmployeeDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new CompanyEmployeeDBContext(dbOptions);
        }
    }
}
