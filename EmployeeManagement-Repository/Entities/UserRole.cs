using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserRole1 { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
