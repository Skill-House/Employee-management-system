using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeMangement.Data.Models
{
    public partial class CompanyModel
    {

        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }

    }
}
