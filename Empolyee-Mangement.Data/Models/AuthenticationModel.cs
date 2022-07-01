using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empolyee_Mangement.Data.Models
{
    public class AuthenticationModel
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;

        public DateTime TokenExpiryDate { get; set; }

        public Guid RefreshToken { get; set; }
        public string Error { get; set; } = null!;
    }
}
