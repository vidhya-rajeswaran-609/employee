namespace CompanyEmployee.Services.Models
{
    using CompanyEmployee.API;
    using CompanyEmployee.Common.Mapping;
    using System;

    public class EmployeeRequestModel: IMapFrom<Employee>
    {
        public string EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; }
        public string Extension { get; set; }
        public string RoleId { get; set; }

    }
}
