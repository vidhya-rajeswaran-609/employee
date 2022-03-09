namespace CompanyEmployee.Test.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using CompanyEmployee.Services;
    using CompanyEmployee.API;
    using CompanyEmployee.Services.Models;

    public class CompanyServiceTest
    {
        [Fact]
        public async Task CreateCompanyShouldSaveCorrectData()
        {
            // Arrange
            var db = this.GetDatabase();
            const int Id = 1;
            const string Name = "Project Manager";

            var companyService = new CompanyService(db);

            var model = new AllCompanyModel
            {
                RoleId = 1,
                RoleName = Name,
            };

            // Act
            await companyService.Create(model);
            var result = await db.Roles.FindAsync(Id);

            // Assert
            Assert.Equal(Id, result.RoleId);
            Assert.Equal(Name, result.RoleName);
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
