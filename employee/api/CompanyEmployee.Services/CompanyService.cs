using AutoMapper.QueryableExtensions;
using CompanyEmployee.API;
using CompanyEmployee.Services.Contracts;
using CompanyEmployee.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployee.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyEmployeeDBContext db;

        public CompanyService(CompanyEmployeeDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AllCompanyModel>> All()
            => await this.db
            .Roles
            .ProjectTo<AllCompanyModel>()
            .ToListAsync();

        public async Task Create(AllCompanyModel model)
        {
            var company = new Role
            {
                RoleName = model.RoleName,
                RoleId = model.RoleId,
            };

            await db.Roles.AddAsync(company);
            await db.SaveChangesAsync();
        }

        public async Task<AllCompanyModel> Details(int id)
            => await db
            .Roles
            .Where(c => c.RoleId == id)
            .ProjectTo<AllCompanyModel>()
            .FirstOrDefaultAsync();
    }
}