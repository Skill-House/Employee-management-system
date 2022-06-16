using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
