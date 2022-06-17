using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RollName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
