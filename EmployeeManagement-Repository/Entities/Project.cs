using System;
using System.Collections.Generic;

namespace EmployeeManagement_Repository.Entities
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectDuration { get; set; }
    }
}
