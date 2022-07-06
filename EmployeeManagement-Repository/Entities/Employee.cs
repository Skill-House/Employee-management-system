﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement_Repository.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
