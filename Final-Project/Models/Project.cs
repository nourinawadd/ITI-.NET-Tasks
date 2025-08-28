using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }

        // Many-to-Many: Projects ↔ Employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
