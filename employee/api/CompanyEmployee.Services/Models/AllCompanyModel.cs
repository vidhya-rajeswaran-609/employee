using CompanyEmployee.API;
using CompanyEmployee.Common.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompanyEmployee.Services.Models
{
    public class AllCompanyModel : IMapFrom<Role>
    {
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
