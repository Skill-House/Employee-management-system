using System;
using System.Collections.Generic;
#nullable disable

namespace EmployeeMangement.Data.Models
{
    public partial class UserModel
    {
        public int Id { get; set; }
        public int RollId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
