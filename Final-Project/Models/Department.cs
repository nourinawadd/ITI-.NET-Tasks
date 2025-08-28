using Final_Project.Models;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        // One-to-Many: Department → Employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
