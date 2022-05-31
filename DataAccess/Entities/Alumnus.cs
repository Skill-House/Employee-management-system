using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class Alumnus
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? AddressId { get; set; }
        public string YearOfGraduation { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
