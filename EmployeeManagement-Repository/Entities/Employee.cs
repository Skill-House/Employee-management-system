using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public int? CompanyId { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
