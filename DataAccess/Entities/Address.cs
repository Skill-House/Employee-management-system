using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
    }
}
