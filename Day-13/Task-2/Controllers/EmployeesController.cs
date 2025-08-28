using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeesController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult GetEmployeesAjax()
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Select(e => new {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    departmentName = e.Department.Name
                })
                .ToList();

            return Json(employees);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // Only Admins can delete
            return View();
        }

    }
}
