using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }

        // One-to-Many: Employee → Department
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        // Many-to-Many: Employee ↔ Projects
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
