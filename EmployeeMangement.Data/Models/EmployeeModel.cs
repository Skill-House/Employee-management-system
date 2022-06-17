using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeMangement.Data.Models
{
    public partial class EmployeeModel
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
       
    }
}
