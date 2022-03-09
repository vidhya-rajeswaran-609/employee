namespace CompanyEmployee.Services.Contracts
{
    using CompanyEmployee.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<IEnumerable<AllCompanyModel>> All();

        Task Create(AllCompanyModel model);

        Task<AllCompanyModel> Details(int id);
    }
}
