using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Empolyee_Mangement.Data.Models
{
    public partial class ProjectModel
    {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public string ProjectDescription { get; set; }
            public int Projectduration { get; set; }
        
    }
}
