using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
