using Microsoft.AspNetCore.Mvc;
using Task_2.Models;
using System.Linq;

namespace CompanyApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CompanyDbContext _context;

        public DepartmentController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
    }
}
