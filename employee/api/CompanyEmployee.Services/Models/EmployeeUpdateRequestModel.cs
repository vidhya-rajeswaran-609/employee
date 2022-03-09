namespace CompanyEmployee.Services.Models
{
    using CompanyEmployee.API;
    using CompanyEmployee.Common.Mapping;
    using System;

    public class EmployeeUpdateRequestModel : IMapFrom<Employee>
    {
        public long EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; }
        public short? Extension { get; set; }
        public int RoleId { get; set; }

    }
}
