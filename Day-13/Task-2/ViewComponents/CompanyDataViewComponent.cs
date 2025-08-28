using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_2.Models;

public class CompanyDataViewComponent : ViewComponent
{
    private readonly CompanyDbContext _context;

    public CompanyDataViewComponent(CompanyDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var model = new
        {
            TotalEmployees = _context.Employees.Count(),
            TotalDepartments = _context.Departments.Count(),
            AverageSalary = _context.Employees.Any(e => e.Salary.HasValue)
                            ? _context.Employees.Average(e => e.Salary.Value)
                            : 0
        };

        return View(model); // sends to Default.cshtml
    }
}
